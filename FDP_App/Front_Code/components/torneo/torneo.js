(function () {
    'use strict';

    angular.module('FDPApp.torneo', [])
        .controller('TorneoController', ['$routeParams', TorneoController])
        

    function TorneoController($routeParams) {
        var vm = this;
        vm.title = 'NOVEDADES DEL TORNEO';
        vm.id = $routeParams.id;
    }

    
   
   
})();
