(function () {

    var app = angular.module('FDPApp', ['ui.router', 'ui.bootstrap', 'appService', 'ngMaterial']);

    app.config(function ($stateProvider) {
        $stateProvider
            .state('nuevoTorneo', {
                url: '/nuevo',
                templateUrl: '/App/Views/TorneosNuevo.html',
                controller: 'TorneoNuevoController'
            })
            .state('fixture', {
                url: '/fixture',
                templateUrl: '/App/Views/Fixture.html',
                controller: 'FixtureController'
            })
    });

    app.controller('NavController', ['$scope', 'appData', function ($scope, appData) {
        $scope.torneos = appData.getTorneos();       
    }]);

    app.controller('TorneoNuevoController', ['$scope', '$location', 'appData', function ($scope, $location, appData) {
        $scope.torneos = appData.getTorneos();
        $scope.equipos = appData.getEquipos();

        $scope.open = function ($event, opened) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope[opened] = !$scope[opened];
        };

        $scope.selectedTeams = [];
        $scope.selection = function (teamName) {
            var idx = $scope.selectedTeams.indexOf(teamName);
            if (idx > -1) 
                $scope.selectedTeams.splice(idx, 1);  
            else 
                $scope.selectedTeams.push(teamName);        
        };

        $scope.crearTorneo = function(unTorneo) {
            var lastId = $scope.torneos[$scope.torneos.length - 1].id;
            unTorneo.id = lastId + 1;
            unTorneo.isCurrent = true;
            unTorneo.equipos = [];
            angular.forEach($scope.equipos, function (item) {
                if ($scope.selectedTeams.indexOf(item.nombre) > -1) {
                    item.esPrimera = true;
                }
                if (item.esPrimera) {
                    unTorneo.equipos.push(item);
                }
            });

            $scope.torneos.push(unTorneo);
            $scope.reset();
        };

        $scope.reset = function() {
            $scope.torneo = undefined;
        };

    }]);

    app.controller('FixtureController', ['$scope', 'appData', function ($scope, appData) {

        $scope.equipos = appData.getEquipos();
        var partidosEquipo = [
                            {"nombre":"Rafaela", "isLocal": true }, {"nombre": "Estudiantes", "isLocal": false }, {"nombre": "Velez", "isLocal": true },
                            {"nombre": "Olimpo", "isLocal": false }, {"nombre": "Racing", "isLocal": true }, {"nombre": "Banfield", "isLocal": false },
                            {"nombre": "Quilmes", "isLocal": true }, {"nombre": "River", "isLocal": false }, {"nombre": "Rosario", "isLocal": true },
                            {"nombre": "Godoy Cruz", "isLocal": false }, {"nombre": "Defensa", "isLocal": true }, {"nombre": "San Lorenzo", "isLocal": false },
                            {"nombre": "Tigre", "isLocal": true }, {"nombre": "Arsenal", "isLocal": false }, {"nombre": "Gimnasia", "isLocal": true },
                            {"nombre": "Lanus", "isLocal": true }, {"nombre": "Boca", "isLocal": false }, {"nombre": "Newells", "isLocal": true },
                            {"nombre": "Belgrano", "isLocal": false } ]

        var aux1 = [];
        var aux2 = [];
        $scope.equipoDistinto = "Gimnasia";
        $scope.equipoElegido = "Independiente";
        

        /*Cargar los arrays auxiliares (aux1 y aux2)*/
        cantFechas = partidosEquipo.length;
        pos = cantFechas;
        for (i = 0; i < cantFechas; i++) {
            if (partidosEquipo[i].nombre == $scope.equipoDistinto) {
                pos = i;
                aux1.push($scope.equipoElegido);
            }
            if (i < pos)
                aux1.push(partidosEquipo[i].nombre);
            else if (i > pos)
                aux2.push(partidosEquipo[i].nombre);
        }
        
        /*Función: cargar partidos por fecha*/
        function cargarPartido(ini, fin, id, aux) {
            while (ini <= fin) {
                var partido = {};
                partido.id = id;
                partido.resLocal = 0;
                partido.resVisitante = 0;
                partido.local = aux[ini];
                if (ini == fin)
                    partido.visitante = $scope.equipoDistinto;
                else
                    partido.visitante = aux[fin];

                fecha.partidos.push(partido);
                id++;
                ini++;
                fin--;                
            }
        };

        /*Armar fixture completo*/
        $scope.fixture = [];
        for (i = 0; i < cantFechas; i++) {
            var fecha = { };
            fecha.id = i + 1;
            fecha.partidos = [];
           
            //Recorro aux1
            a = aux1.length - 1;
            j = 0;
            partidoId = 1;
            cargarPartido(j, a, partidoId, aux1);
           
            //Recorro aux2
            b = aux2.length - 1;
            k = 0;
            partidoId = partidoId + fecha.partidos.length;
            cargarPartido(k, b, partidoId, aux2);
            
            if (aux1.length > 1) {
                equipoSale = aux1[0];
                aux1.splice(0, 1);
                aux2.push(equipoSale);
            } else {
                equipoSale = aux2[0];
                aux2.splice(0, 1);
                aux1.push(equipoSale);
            }

            $scope.fixture.push(fecha);
        }

    }]);
})();