(function () {
    'use strict';

    angular.module('FDPApp.posiciones', [])
        .controller('PosicionesController', ['$routeParams', 'leaguesData', 'gamesLeagueData', 'gamesData', PosicionesController]);

    function PosicionesController($routeParams, leaguesData, gamesLeagueData, gamesData) {
        var vm = this;
        vm.torneo = leaguesData.get({ id: $routeParams.id });
        vm.id = $routeParams.id;
        
        
     
        vm.fecha = gamesData.get({ id: 1 }, function () {
            vm.fecha.isCurrent = true;
            vm.fecha.$update({ id: 1 });
        });

        vm.fechas = gamesLeagueData.query({ id: $routeParams.id }, function () {
            var i;           
            for (i = 0; i < vm.fechas.length; i++) {
                if (vm.fechas[i].isCurrent == true) 
                    vm.fechaActual = vm.fechas[i];            
            }
        });
        
        vm.numeroFecha = 1;
        vm.anteriorFechaId = 0;
        
        vm.finalizarFecha = function (fechaId) {
            vm.numeroFecha ++;
            vm.fechaAnterior = gamesData.get({ id: fechaId }, function () {
                vm.fechaAnterior.isCurrent = false;
                vm.fechaAnterior.$update({ id: fechaId });
            });
            
            //si el numero es menor igual al total de fechas
            vm.anteriorFechaId = fechaId;
            vm.fechaActual = gamesData.get({ id: fechaId + 1 }, function () {
                vm.fechaActual.isCurrent = true;
                vm.fechaActual.$update({ id: fechaId + 1 });
            });

            
            

        }
    }
})();
