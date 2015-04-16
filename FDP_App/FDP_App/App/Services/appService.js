var appService = angular.module('appService', ['ngResource']);

appService.factory('appData', ['$resource', function ($resource) {

    var torneos = [
            { "id": 1, "nombre": "Transición 2014", "inicio": "agosto de 2014", "fin": "diciembre de 2014", "descripcion": "Torneo sin descensos", "isCurrent": false, "equipos": [] },
            { "id": 2, "nombre": "Primera División 2015", "inicio": "febrero de 2015", "fin": "diciembre de 2015", "descripcion": "Primer torneo de 30 equipos", "isCurrent": true, "equipos": [] }
    ];

    var equipos = [ 
            { "id": 1, "nombre": "Independiente", "estadio": "Libertadores de América" , "ubicacion": "Avellaneda(BsAs)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 2, "nombre": "River Plate", "estadio": "Antonio Vespucio Liberti" , "ubicacion": "Nuñez(CapFed)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 3, "nombre": "Boca Juniors", "estadio": "Alberto J. Armando" , "ubicacion": "La Boca(CapFed)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 4, "nombre": "Racing Club", "estadio": "Presidente Perón" , "ubicacion": "Avellaneda(BsAs)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 5, "nombre": "San Lorenzo", "estadio": "Pedro Bidegain" , "ubicacion": "Bajo Flores(CapFed)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 6, "nombre": "Huracan", "estadio": "Tomás Adolfo Ducó" , "ubicacion": "Parque Patricios(CapFed)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 7, "nombre": "Estudiantes(LP)" , "estadio": "Ciudad de La Plata" , "ubicacion": "La Plata(BsAs)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 8, "nombre": "Colon", "estadio": "Brigadier López" , "ubicacion": "Santa Fe(SFe)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 9, "nombre": "Quilmes", "estadio": "Centenario", "ubicacion": "Quilmes(BsAs)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 10, "nombre": "Gimnasia(J)", "estadio": "23 de Agosto", "ubicacion": "San Salvador(J)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 11, "nombre": "All Boys", "estadio": "Islas Malvinas", "ubicacion": "Floresta(CapFed)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 12, "nombre": "Chacarita Juniors", "estadio": "Chacarita Juniors", "ubicacion": "Villa Maipú(BsAs)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false }
    ];

    return {
        getTorneos: function() {
            return torneos;
        },
        getEquipos: function() {
            return equipos;
        },
        getEquiposById: function (teamId) {
            for (i = 0; i < equipos.length; i++) {
                if (equipos[i].id == teamId) {
                    return equipos[i];
                }
            }
        }
    }
    
       
}]);