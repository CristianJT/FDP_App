(function () {

    var app = angular.module('FDPApp', ['ui.router', 'ui.bootstrap', 'appService']);

    app.config(function ($stateProvider) {

        $stateProvider
            .state('torneos', {
                url: '/torneos',
                templateUrl: '/App/Views/Torneos.html',
                controller: 'TorneoController'
            })
            .state('nuevoTorneo', {
                url: '/torneos/crear',
                templateUrl: '/App/Views/TorneosNuevo.html',
                controller: 'TorneoNuevoController'
            })
    });

    app.controller('TorneoController', ['$scope', 'appData', function ($scope, appData) {
        $scope.torneos = appData.getTorneos();
    }]);

app.controller('TorneoNuevoController', ['$scope', '$location', 'appData',  function ($scope, $location, appData) {
        $scope.torneos = appData.getTorneos();
        $scope.equipos = appData.getEquipos();

        $scope.selectedTeams = [];
        $scope.selection = function (teamName) {
            var idx = $scope.selectedTeams.indexOf(teamName);
            if (idx > -1) {
                $scope.selectedTeams.splice(idx, 1);
            }
            else {
                $scope.selectedTeams.push(teamName);
            }
        };

        $scope.crearTorneo = function(unTorneo) {
            var lastId = $scope.torneos[$scope.torneos.length - 1].id;
            unTorneo.id = lastId + 1;
            unTorneo.isCurrent = true;

            $scope.torneos.push(unTorneo);
            $scope.backToTournaments();
        };
        
       


   

        $scope.backToTournaments = function() {
            $location.path('/torneos');
        };

        $scope.reset = function() {
            $scope.torneo = {};
        };

    }]);

})();