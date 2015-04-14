(function () {

    var app = angular.module('FDPApp', ['ui.router', 'appService']);

    app.config(function ($stateProvider) {

        $stateProvider
            .state('torneos', {
                url: '/torneos',
                templateUrl: '/App/Views/Torneos.html',
                controller: 'TorneoController'
            })
    });

    app.controller('TorneoController', ['$scope', 'appData', function ($scope, appData) {
        $scope.torneos = appData.getTorneos();
    }]);


})();