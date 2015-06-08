﻿
(function () {
    

    var app = angular.module('FDPApp', ['ngNewRouter', 'appService', 'ngMaterial', 'FDPApp.main', 'FDPApp.nuevoTorneo', 'FDPApp.torneo', 'FDPApp.fixture', 'FDPApp.posiciones']);

    app.controller('AppController', ['$router', 'leaguesData', 'teamsData', AppController]);

    function AppController($router, leaguesData, teamsData) {
        $router.config([
           {
               path: '/', redirectTo: 'home'    
           },
           {
               path: '/home', component: 'main'         
           },
           {
               path: '/nuevo/torneo', component: 'nuevotorneo', as: 'nuevo'
           },
           {
               path: '/torneo/:id', component: 'torneo', as: 'torneo'
           },
           {
               path: '/torneo/:id/fixture', component: 'fixture', as: 'fixture'
           },
           {
               path: '/torneo/:id/posiciones', component: 'posiciones', as: 'posiciones'
           }
            
        ]);
        var vm = this;
        vm.torneos = leaguesData.query();
        vm.equipos = teamsData.query();
    }

    app.directive('tabsPage', [tabsPage])
    function tabsPage() {
        return {
            restrict: 'E',
            templateUrl: '/app/Views/TabsPage.html',
            controller: function ($routeParams) {
                this.tab = 1;
                this.selectedTab = function (newTab) {
                    this.tab = newTab;
                };
                this.id = $routeParams.id;
            },
        };
    };
    
})(); 