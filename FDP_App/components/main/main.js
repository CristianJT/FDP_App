(function () {
    'use strict';

    angular.module('FDPApp.main', [])
        .controller('MainController', ['teamsData', MainController])

    function MainController(teamsData) {
        var vm = this;
        vm.title = 'main';
    }
})();
