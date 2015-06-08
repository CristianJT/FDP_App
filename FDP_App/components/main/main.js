(function () {
    'use strict';

    angular.module('FDPApp.main', [])
        .controller('MainController', [MainController])

    function MainController() {
        var vm = this;
        vm.title = 'main';

       
    }
})();
