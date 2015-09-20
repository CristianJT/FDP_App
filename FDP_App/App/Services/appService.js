var appService = angular.module('appService', ['ngResource']);

appService.factory('leaguesService', ['$http', function ($http) {

    return {
        get: function (leagueId) {
            if (typeof (leagueId) === 'undefined')
                return $http.get('/api/leagues')
            return $http.get('/api/leagues/' + leagueId)
        },
        update: function (leagueId, league) {
            return $http.put('/api/leagues/' + leagueId, league)
        },
        create: function (league) {
            return $http.post('/api/leagues', league)
        },
        delete: function (leagueId) {
            return $http.delete('/api/leagues/' + leagueId)
        },
        teams: {
            get: function (leagueId, teamId) {
                if (typeof (teamId) === 'undefined')
                    return $http.get('/api/leagues/' + leagueId + '/teams')
                return $http.get('/api/leagues/' + leagueId + '/teams/' + teamId)
            },
            update: function (leagueId, teamId, team) {
                return $http.put('/api/leagues/'+ leagueId + '/teams/' + teamId, team)
            }
        },
        games: {
            get: function (leagueId, gameNumber) {
                if (typeof (gameNumber) === 'undefined')
                    return $http.get('/api/leagues/' + leagueId + '/games')
                return $http.get('/api/leagues/' + leagueId + '/games/' + gameNumber)
            }
        }
    }

}]);

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