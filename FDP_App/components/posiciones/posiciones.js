(function () {
    'use strict';

    angular.module('FDPApp.posiciones', [])
        .controller('PosicionesController', ['$routeParams', 'leaguesData', 'gamesLeagueData', 'gamesData', PosicionesController]);

    function PosicionesController($routeParams, leaguesData, gamesLeagueData, gamesData) {
        var vm = this;
        vm.torneo = leaguesData.get({ id: $routeParams.id });
        vm.id = $routeParams.id;
           
     
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
            } else
                vm.fechaActual = null;
            
        }

        /* Función: finalizar torneo */
        vm.finalizarTorneo = function () {
            alert("El torneo: " + vm.torneo.name + " " + vm.torneo.season + " ha finalizado");
        }
    }
})();
