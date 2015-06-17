(function() {
    'use strict';

    angular.module('FDPApp.tabsPage', [])
        .directive('tabsPage', [tabsPage])
        .controller('TabsController', [TabsController])
    function TabsController() {
        
    }
    
    function tabsPage () {
       
        var directive = {
            restrict: 'EA',
            templateUrl: '/app/Views/TabsPage.html',
            controller: 'TabsController'
                         
        };

        return directive;

        
    }
    /*function tabsPage() {
        return {
            restrict: 'E',
            templateUrl: '/app/Views/TabsPage.html',
            controller: function ($routeParams, $location) {
                this.tab = 1;
                this.selectedTab = function (newTab) {
                    this.tab = newTab;
                }

                this.id = $routeParams.id;
            },
            controllerAs: 'tab'
        };
    };*/

})();