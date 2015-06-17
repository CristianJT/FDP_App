(function () {
    'use strict';

    angular.module('FDPApp.posiciones', [])
        .controller('PosicionesController', ['$routeParams', 'leaguesData', PosicionesController]);

    function PosicionesController($routeParams, leaguesData) {
        var vm = this;
        vm.torneo = leaguesData.get({ id: $routeParams.id });
        vm.id = $routeParams.id;
        
        /*--- FECHA ANTERIOR/ACTUAL ---*/



        vm.anteriorFechaId = 0;
   


        /*vm.finalizarFecha = function () {
            vm.anteriorFechaId = actualFechaId;
            actualFechaId++;
            vm.fechaAnterior = vm.fechaActual;
            vm.fechaActual = tempData.getFechaById($routeParams.id, actualFechaId);
        }*/
    }
})();
