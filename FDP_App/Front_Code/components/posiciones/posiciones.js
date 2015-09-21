(function () {
    'use strict';

    angular.module('FDPApp.posiciones', [])
        .controller('PosicionesController', ['$routeParams', 'leaguesData', 'gamesLeagueData', 'gamesData', 'teamsData', 'matchesData', 'leaguesService', PosicionesController]);

    function PosicionesController($routeParams, leaguesData, gamesLeagueData, gamesData, teamsData, matchesData, leaguesService) {
        var vm = this;
        vm.torneo = leaguesData.get({ id: $routeParams.id });
        vm.equipos = teamsData.query();
        vm.id = $routeParams.id;
         
        /* Función: obtener estadio del equipo local */
        vm.getEstadio = function(teamName) {
            var i;
            for (i = 0; i < vm.equipos.length; i++) {
                if (vm.equipos[i].name == teamName)
                    return vm.equipos[i].stadium;
            }
        }

        /* Función: obtener ciudad donde se desarrolla el partido */
        vm.getCiudad = function (teamName) {
            var i;
            for (i = 0; i < vm.equipos.length; i++) {
                if (vm.equipos[i].name == teamName)
                    return vm.equipos[i].city;
            }
        }

        function getTeamId(teamName) {
            var i;
            for (i = 0; i < vm.equipos.length; i++) {
                if (vm.equipos[i].name == teamName)
                    return vm.equipos[i].teamId;
            }
        }

        /* Función: setear fecha (fecha actual) y hora (15hs) de partidos */
        function setFechaHoraDefault() {
            var j = 0;
            for (j = 0; j < vm.fechaActual.matches.length; j++) {
                vm.fechaActual.matches[j].fecha = new Date();
                vm.fechaActual.matches[j].hora = new Date(0, 0, 0, 15, 0, 0);
            }
        }

        /* Obtener todas las fechas del torneo */
        vm.fechas = gamesLeagueData.query({ id: $routeParams.id }, function () {
            var i;           
            for (i = 0; i < vm.fechas.length; i++) {
                if (vm.fechas[i].is_current == true) {
                    vm.fechaActual = vm.fechas[i];
                    setFechaHoraDefault();
                    if (i > 0)
                        vm.fechaAnterior = vm.fechas[i - 1];
                    if (i < vm.fechas.length - 1)
                        vm.fechaSiguiente = vm.fechas[i + 1];
                } 
            }
            /* permite obtener la última fecha */
            if (vm.fechaActual == null)
                vm.fechaAnterior = vm.fechas[i - 1];
        });
        
        /* Función: finalizar fecha */
        vm.finalizarFecha = function (fechaId, fechaNumber) {

            vm.fechaAnterior = gamesData.get({ id: fechaId }, function () {
                vm.fechaAnterior.is_current = false;
                vm.fechaAnterior.$update({ id: fechaId });
            });          

            if (fechaNumber < vm.fechas.length) {
                vm.fechaActual = gamesData.get({ id: fechaId + 1 }, function () {
                    setFechaHoraDefault();
                    vm.fechaActual.is_current = true;
                    vm.fechaActual.$update({ id: fechaId + 1 });
                });
                if (fechaNumber < vm.fechas.length - 1)
                    vm.fechaSiguiente = gamesData.get({ id: fechaId + 2 });
                else
                    vm.fechaSiguiente = null;
            } else
                vm.fechaActual = null;
            
        }

        /* Función: finalizar torneo */
        vm.finalizarTorneo = function () {
            alert("El torneo: " + vm.torneo.name + " " + vm.torneo.season + " ha finalizado");
        }
       
        /* Función: confirmar fecha y hora de partidos */
        vm.confirmarFechaHora = function (partido, fecha, hora) {
            partido.match_date = new Date(fecha.getFullYear(), fecha.getMonth(), fecha.getDate(), hora.getHours(), hora.getMinutes(), 0);
            partido.is_confirm = true;
            matchesData.update(partido.match_id, partido).then(
                function (result) {

                });                          
        }
        
        vm.confirmarResultado = function (partido, local, visitante) {
            partido.home_result = local;
            partido.away_result = visitante;

            matchesData.update(partido.match_id, partido).then(
                function (result) {

                });

            //leaguesService.teams.get($routeParams.id, getTeamId(partido.home_team)).then(
            //    function (result) {
            //        var equipoLocal = result.data;
            //        equipoLocal.played += 1;
            //        equipoLocal.goalsFor += local;
            //        equipoLocal.goalsAgainst += visitante;

            //        leaguesService.teams.update(equipoLocal.leagueId, equipoLocal.teamId, equipoLocal).then(
            //            function (result) {

            //            });
            //    })
           
        }

    }
})();
