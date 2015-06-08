(function () {
    'use strict';

    angular.module('FDPApp.posiciones', [])
        .controller('PosicionesController', ['$routeParams', 'tempData', PosicionesController]);

    function PosicionesController($routeParams, tempData) {
        var vm = this;
        vm.equipos = tempData.getTorneosByIdEquipos($routeParams.id);
        
        /*--- FECHA ANTERIOR/ACTUAL ---*/

        var actualFechaId = 1;
        vm.anteriorFechaId = 0;
   
        vm.fechaActual = tempData.getFechaById($routeParams.id, actualFechaId);

        vm.finalizarFecha = function () {
            vm.anteriorFechaId = actualFechaId;
            actualFechaId++;
            vm.fechaAnterior = vm.fechaActual;
            vm.fechaActual = tempData.getFechaById($routeParams.id, actualFechaId);
        }
    }
})();
