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
                            {"nombre":"Rafaela", "esLocal": true }, {"nombre": "Estudiantes", "esLocal": false }, {"nombre": "Velez", "esLocal": true },
                            {"nombre": "Olimpo", "esLocal": false }, {"nombre": "Racing", "esLocal": true }, {"nombre": "Banfield", "esLocal": false },
                            {"nombre": "Quilmes", "esLocal": true }, {"nombre": "River", "esLocal": false }, {"nombre": "Rosario", "esLocal": true },
                            {"nombre": "Godoy Cruz", "esLocal": false }, {"nombre": "Defensa", "esLocal": true }, {"nombre": "San Lorenzo", "esLocal": false },
                            {"nombre": "Tigre", "esLocal": true }, {"nombre": "Arsenal", "esLocal": false }, {"nombre": "Gimnasia", "esLocal": true },
                            {"nombre": "Lanus", "esLocal": true }, {"nombre": "Boca", "esLocal": false }, {"nombre": "Newells", "esLocal": true },
                            {"nombre": "Belgrano", "esLocal": false } ]

        var aux1 = [];
        var aux2 = [];
        $scope.equipoDistinto = "Gimnasia";
        $scope.equipoElegido = "Independiente";
        $scope.equipoPareja = "Estudiantes";
        esLocalDist = true;
        
      
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
        
        function buscarPosicion(equipo) {
            for (p = 0; p < partidosEquipo.length; p++) {
                if (partidosEquipo[p].nombre == equipo)
                    return p;
            }
        };



        /*Función: cargar partidos por fecha*/
        function cargarPartido(ini, fin, aux, id) {
                var partido = {};
                partido.id = id;
                partido.resLocal = 0;
                partido.resVisitante = 0;
                
                if (ini == fin) {
                    if (esLocalDist) {
                        partido.local = $scope.equipoDistinto;
                        partido.visitante = aux[ini];
                    } else {
                        partido.local = aux[ini];
                        partido.visitante = $scope.equipoDistinto;
                    }
                    if (aux[ini] == $scope.equipoPareja || aux[fin] == $scope.equipoPareja)
                        esLocalDist = esLocalDist;
                    else
                        esLocalDist = !esLocalDist;
                }
                else {
                    partido.local = aux[ini];
                    partido.visitante = aux[fin];
                }
                fecha.partidos.push(partido);
        };

        /*Armar fixture completo*/
        $scope.fixture = [];
        posDistinto = buscarPosicion($scope.equipoDistinto);
        for (i = 0; i < cantFechas; i++) {
            var fecha = { };
            fecha.id = i + 1;
            fecha.partidos = [];
           
            //Recorro aux1
            a = aux1.length - 1;
            j = 0;
            partidoId = 1;
            while (j <= a) {
                if (i <= posDistinto) {
                    if (partidosEquipo[i].esLocal)
                        cargarPartido(a, j, aux1, partidoId, i);
                    else
                        cargarPartido(j, a, aux1, partidoId, i);
                } else {
                    if (partidosEquipo[i].esLocal)
                        cargarPartido(j, a, aux1, partidoId, i);
                    else
                        cargarPartido(a, j, aux1, partidoId, i);
                }
                j++;
                a--;
                partidoId++;
            }
            //Recorro aux2
            b = aux2.length - 1;
            k = 0;
            while (k <= b) {
                if (i <= posDistinto) {
                    if (partidosEquipo[i].esLocal)
                        cargarPartido(k, b, aux2, partidoId, i);
                    else
                        cargarPartido(b, k, aux2, partidoId, i);
                } else {
                    if (partidosEquipo[i].esLocal)
                        cargarPartido(b, k, aux2, partidoId, i);
                    else
                        cargarPartido(k, b, aux2, partidoId, i);
                }
                k++;
                b--;
                partidoId++;
            }
            
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