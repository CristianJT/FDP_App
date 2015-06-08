(function () {
    'use strict';

    angular.module('FDPApp.fixture', [])
        .controller('FixtureController', ['$routeParams', 'leaguesData', FixtureController]);

    function FixtureController($routeParams, leaguesData) {
        var vm = this;
        vm.torneo = leaguesData.get({ id: $routeParams.id });
    }
})();
