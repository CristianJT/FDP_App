var appService = angular.module('appService', ['ngResource']);

appService.factory('leaguesData', ['$resource', function ($resource) {

    return $resource("/api/leagues/:id", null, 
        {
            'update': { method: 'PUT' }
        });

}]);

appService.factory('teamsData', ['$resource', function ($resource) {

    return $resource("/api/teams");

}]);

appService.factory('tempData', ['leaguesData', function (leaguesData) {

    torneos = leaguesData.query();

    return {
        getTorneos: function () {
            return torneos;
        },
        getEquipos: function () {
            return equipos;
        },
        getEquiposById: function (teamId) {
            for (i = 0; i < equipos.length; i++) {
                if (equipos[i].id == teamId)
                    return equipos[i];
            }
        },
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
                if (torneos[i].id == torneoId)
                    return torneos[i].equipos;
            }
        },
        getFechaById: function (torneoId, fechaId) {
            for (i = 0; i < torneos.length; i++) {
                if (torneos[i].id == torneoId) {
                    for (j = 0; j < torneos[i].fixture.length; j++) {
                        if (torneos[i].fixture[j].id == fechaId)
                            return torneos[i].fixture[j];
                    }
                }
            }
        }

    }

}]);


