var appService = angular.module('appService', ['ngResource']);

appService.factory('appData', ['$resource', function ($resource) {

    var torneos = [
            { "id": 1, "nombre": "Transición 2014", "descripcion": "Torneo sin descensos", "isCurrent": false, "equipos": [] },
            { "id": 2, "nombre": "Primera División 2015", "descripcion": "Primer torneo de 30 equipos", "isCurrent": true, "equipos": [] }
    ];

    return {
        getTorneos: function() {
            return torneos;
        }
    }
    
       
}]);