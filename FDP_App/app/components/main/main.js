(function () {
    'use strict';

    angular.module('FDPApp.main', [])
        .controller('MainController', ['leaguesData', 'teamsData', MainController]);

    function MainController(leaguesData, teamsData) {
        var vm = this;
        vm.torneos = leaguesData.query();
        vm.equipos = teamsData.query();
    }
})();
