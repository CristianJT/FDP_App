var appService = angular.module('appService', ['ngResource']);

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

appService.factory('tempData', ['leaguesData', function (leaguesData) {

    var torneos = leaguesData.query();

    return {
        getTorneosById: function (torneoId) {
            for (i = 0; i < torneos.length; i++) {
                if (torneos[i].leagueId == torneoId)
                    return torneos[i];
            }
        },
        getTorneosByIdFixture: function (torneoId) {
            for (i = 0; i < torneos.length; i++) {
                if (torneos[i].leagueId == torneoId)
                    return torneos[i].fixture;
            }
        },
        getTorneosByIdEquipos: function (torneoId) {
            for (i = 0; i < torneos.length; i++) {
                if (torneos[i].leagueId == torneoId)
                    return torneos[i].teams;
            }
        },  
        getFechaById: function (torneoId, fechaId) {
            for (i = 0; i < torneos.length; i++) {
                if (torneos[i].leagueId == torneoId) {
                    for (j = 0; j < torneos[i].fixture.games.length; j++) {
                        if (torneos[i].fixture.games[j].gameId == fechaId)
                            return torneos[i].fixture.games[j];
                    }
                }
            }
        }

    }

}]);


