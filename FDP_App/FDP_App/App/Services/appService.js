var appService = angular.module('appService', ['ngResource']);

appService.factory('appData', ['$resource', function ($resource) {

    var torneos = [
            {
                "id": 1, "nombre": "Transición 2014", "inicio": "", "fin": "", "descripcion": "Torneo sin descensos", "isCurrent": false,
                "equipos": [{ "id": 3, "nombre": "Boca Juniors", "estadio": "Alberto J. Armando", "ubicacion": "La Boca(CapFed)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }]
            }
    ];

    var equipos = [ 
            { "id": 1, "nombre": "Independiente", "estadio": "Libertadores de América" , "ubicacion": "Avellaneda(BsAs)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 2, "nombre": "River Plate", "estadio": "Antonio Vespucio Liberti" , "ubicacion": "Nuñez(CapFed)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 3, "nombre": "Boca Juniors", "estadio": "Alberto J. Armando" , "ubicacion": "La Boca(CapFed)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 4, "nombre": "Racing Club", "estadio": "Presidente Perón" , "ubicacion": "Avellaneda(BsAs)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 5, "nombre": "San Lorenzo", "estadio": "Pedro Bidegain" , "ubicacion": "Bajo Flores(CapFed)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 6, "nombre": "Huracan", "estadio": "Tomás Adolfo Ducó" , "ubicacion": "Parque Patricios(CapFed)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false }, 
            { "id": 7, "nombre": "Estudiantes(LP)" , "estadio": "Ciudad de La Plata" , "ubicacion": "La Plata(BsAs)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true }, 
            { "id": 8, "nombre": "Colon", "estadio": "Brigadier López" , "ubicacion": "Santa Fe(SFe)" , "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false }, 
            { "id": 9, "nombre": "Quilmes", "estadio": "Centenario", "ubicacion": "Quilmes(BsAs)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 10, "nombre": "Arsenal", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 11, "nombre": "Godoy Cruz", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 12, "nombre": "Atletico de Rafaela", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 13, "nombre": "Tigre", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 14, "nombre": "Newell's", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 15, "nombre": "Lanus", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 16, "nombre": "Banfield", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 17, "nombre": "Belgrano", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 18, "nombre": "Defensa y Justicia", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 19, "nombre": "Velez", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 20, "nombre": "Olimpo(BB)", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 21, "nombre": "Gimnasia(LP)", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 22, "nombre": "Rosario Central", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": true },
            { "id": 23, "nombre": "Gimnasia(J)", "estadio": "23 de Agosto", "ubicacion": "San Salvador(J)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 24, "nombre": "All Boys", "estadio": "Islas Malvinas", "ubicacion": "Floresta(CapFed)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 25, "nombre": "Chacarita Juniors", "estadio": "Chacarita Juniors", "ubicacion": "Villa Maipú(BsAs)", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 26, "nombre": "Crucero del Norte", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 27, "nombre": "Temperley", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 28, "nombre": "Nueva Chicago", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 29, "nombre": "Union(SF)", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 30, "nombre": "Sarmiento", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 31, "nombre": "San Martin(SJ)", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 32, "nombre": "Argentinos Jr.", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false },
            { "id": 33, "nombre": "Aldosivi", "estadio": "", "ubicacion": "", "puntos": 0, "jugados": 0, "ganados": 0, "empatados": 0, "perdidos": 0, "golesFavor": 0, "golesContra": 0, "diferencia": 0, "esPrimera": false }
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
                if (equipos[i].id == teamId)
                    return equipos[i];
            }
        },
        getTorneosById: function (torneoId) {
            for (i = 0; i < torneos.length; i++) {
                if (torneos[i].id == torneoId) 
                    return torneos[i];
            }
        },
        getTorneosByIdFixture: function (torneoId) {
            for (i = 0; i < torneos.length; i++) {
                if (torneos[i].id == torneoId)
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