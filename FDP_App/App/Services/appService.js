﻿var appService = angular.module('appService', ['ngResource']);

appService.factory('leaguesData', ['$resource', function ($resource) {

    return $resource("/api/leagues/:id", null,
        {
            'update': { method: 'PUT' }
        });

}]);

appService.factory('teamsData', ['$resource', function ($resource) {

    return $resource("/api/teams/:id", null,
        {
            'update': { method: 'PUT' }
        });

}]);

appService.factory('gamesLeagueData', ['$resource', function ($resource) {

    return $resource("/api/leagues/:id/games");

}]);

appService.factory('gamesData', ['$resource', function ($resource) {

    return $resource("/api/games/:id", null,
        {
            'update': { method: 'PUT' }
        });
}]);

appService.factory('matchesData', ['$http', function ($http) {
    return {
        get: function (id) {
            return $http.get('api/matches/' +id)
        },
        update: function (id, partido) {
            return $http.put('api/matches/' +id, partido)
        }
    }
}]);