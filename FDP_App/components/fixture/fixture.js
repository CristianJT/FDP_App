(function () {
    'use strict';

    angular.module('FDPApp.fixture', [])
        .controller('FixtureController', ['$routeParams', 'tempData', FixtureController]);

    function FixtureController($routeParams, tempData) {
        var vm = this;
        vm.fixtureTorneo = tempData.getTorneosByIdFixture($routeParams.id)
    }
})();
