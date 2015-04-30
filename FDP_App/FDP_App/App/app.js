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
        var partidosEquipo = [ "Atletico de Rafaela", "Estudiantes(LP)", "Velez", "Olimpo", "Racing Club", "Banfield",
                            "Quilmes", "River Plate", "Rosario Central", "Godoy Cruz", "Defensa y Justicia", "San Lorenzo",
                            "Tigre", "Arsenal", "Gimnasia", "Lanus", "Boca Juniors", "Newells", "Belgrano" ]

        
        
        $scope.equipoElegido = "Independiente";
        $scope.equipoPareja = "Estudiantes(LP)";
        esLocalDistinto = true;
        esLocalElegido = true;
        
      
        /*Cargar los arrays auxiliares (aux1 y aux2)*/
        function cargarArray(aux1, aux2) {
            cantFechas = partidosEquipo.length;
            pos = cantFechas;
            for (i = 0; i < cantFechas; i++) {
                if (partidosEquipo[i] == $scope.equipoDistinto) {
                    pos = i;
                    aux1.push($scope.equipoElegido);
                }
                if (i < pos)
                    aux1.push(partidosEquipo[i]);
                else if (i > pos)
                    aux2.push(partidosEquipo[i]);
            }
        }
        
        /*Función: buscar posición de un equipo dentro del array partidosEquipo*/
        function buscarPosicion(equipo) {
            for (p = 0; p < partidosEquipo.length; p++) {
                if (partidosEquipo[p] == equipo)
                    return p;
            }
        };

        /*Función: cargar partidos por fecha*/
        function cargarPartido(ini, fin, aux, id, partido) {
                var partido = {};
                partido.id = id;
                partido.resLocal = 0;
                partido.resVisitante = 0;
                
                if (ini == fin) {
                    if (esLocalDistinto) {
                        partido.local = $scope.equipoDistinto;
                        partido.visitante = aux[ini];
                    } else {
                        partido.local = aux[ini];
                        partido.visitante = $scope.equipoDistinto;
                    }
                    if (aux[ini] != $scope.equipoPareja)
                        esLocalDistinto = !esLocalDistinto;
                }
                else {
                    partido.local = aux[ini];
                    partido.visitante = aux[fin];
                }
                return partido;
        };

        /*Armar fixture completo*/
        $scope.armarFixture = function () {
            var aux1 = [];
            var aux2 = [];
            cargarArray(aux1, aux2);
            $scope.fixture = [];
            posDistinto = buscarPosicion($scope.equipoDistinto);
            for (i = 0; i < cantFechas; i++) {
                var fecha = {};
                fecha.id = i + 1;
                fecha.partidos = [];

                //Recorro aux1
                a = aux1.length - 1;
                j = 0;
                partidoId = 1;
                while (j <= a) {
                    if (i <= posDistinto) {
                        if (esLocalElegido)
                            partido = cargarPartido(a, j, aux1, partidoId, i);
                        else
                            partido = cargarPartido(j, a, aux1, partidoId, i);
                    } else {
                        if (esLocalElegido)
                            partido = cargarPartido(j, a, aux1, partidoId, i);
                        else
                            partido = cargarPartido(a, j, aux1, partidoId, i);
                    }

                    fecha.partidos.push(partido);
                    j++;
                    a--;
                    partidoId++;
                }
                //Recorro aux2
                b = aux2.length - 1;
                k = 0;
                while (k <= b) {
                    if (i <= posDistinto) {
                        if (esLocalElegido)
                            partido = cargarPartido(k, b, aux2, partidoId, i);
                        else
                            partido = cargarPartido(b, k, aux2, partidoId, i);
                    } else {
                        if (esLocalElegido)
                            partido = cargarPartido(b, k, aux2, partidoId, i);
                        else
                            partido = cargarPartido(k, b, aux2, partidoId, i);
                    }

                    fecha.partidos.push(partido);
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
                if (i != posDistinto)
                    esLocalElegido = !esLocalElegido;
            }
        }

    }]);
})();