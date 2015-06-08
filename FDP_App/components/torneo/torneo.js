(function () {
    'use strict';

    angular.module('FDPApp.torneo', [])
        .controller('TorneoController', [TorneoController])
        

    function TorneoController() {
        var vm = this;
        vm.title = 'NOVEDADES DEL TORNEO';
    }

   
})();
