(function () {
    'use strict';

    angular.module('FDPApp.posiciones', [])
        .controller('PosicionesController', ['$routeParams', 'leaguesData', 'gamesLeagueData', 'gamesData', 'teamsData', PosicionesController]);

    function PosicionesController($routeParams, leaguesData, gamesLeagueData, gamesData, teamsData) {
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
        //vm.fecha = gamesData.get({ id: 20 }, function () {
        //    vm.fecha.isCurrent = true;
        //    vm.fecha.$update({ id: 20 });
        //});

        /* Obtener todas las fechas del torneo */
        vm.fechas = gamesLeagueData.query({ id: $routeParams.id }, function () {
            var i;           
            for (i = 0; i < vm.fechas.length; i++) {
                if (vm.fechas[i].isCurrent == true) {
                    vm.fechaActual = vm.fechas[i];
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
                vm.fechaAnterior.isCurrent = false;
                vm.fechaAnterior.$update({ id: fechaId });
            });          

            if (fechaNumber < vm.fechas.length) {
                vm.fechaActual = gamesData.get({ id: fechaId + 1 }, function () {
                    vm.fechaActual.isCurrent = true;
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
       
        vm.isConfirm = true;

        vm.confirmar = function (date, time) {
            var dateTime;
            dateTime = new Date(date + ' ' + time);
            alert(date.getMonth());
        } 
        

    }
})();
