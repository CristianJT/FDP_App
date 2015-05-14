(function () {

    var app = angular.module('FDPApp', ['ui.router', 'ui.bootstrap', 'appService', 'ngMaterial']);

    app.config(function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('nuevoTorneo', {
                url: '/nuevo',
                templateUrl: '/App/Views/TorneosNuevo.html',
                controller: 'TorneoNuevoController'
            })
            .state('torneo', {
                url: '/torneos/:id',
                templateUrl: '/App/Views/Torneo.html',
                controller: 'TorneoController'
            })
            .state('fixture', {
                url: '/torneos/:id/fixture',
                templateUrl: '/App/Views/Fixture.html',
                controller: 'FixtureController',
                controllerAs: 'fecha'
            })
            .state('posiciones', {
                url: '/torneos/:id/posiciones',
                templateUrl: '/App/Views/Posiciones.html',
                controller: 'PosicionesController',
                controllerAs: 'tabla'
            })
        $urlRouterProvider.otherwise('/');
    });

    app.controller('NavController', ['appData', function (appData) {
        this.torneos = appData.getTorneos();       
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
            unTorneo.fixture = [];

            angular.forEach($scope.equipos, function (item) {
                if ($scope.selectedTeams.indexOf(item.nombre) > -1) {
                    item.esPrimera = true;
                }
                if (item.esPrimera) {
                    unTorneo.equipos.push(item);
                }
            });

            $scope.torneos.push(unTorneo);
            redirect(unTorneo.id);
        };

        $scope.reset = function() {
            $scope.torneo = undefined;
        };

        redirect = function (id) {
            $location.path('/torneos/' + id);
        };

    }]);

    app.controller('TorneoController', ['$scope', '$stateParams', 'appData', '$mdDialog', '$mdSidenav', function ($scope, $stateParams, appData, $mdDialog, $mdSidenav) {

        $scope.torneo = appData.getTorneosById($stateParams.id);

        //$scope.ayuda = function (ev, team) {
        //    var confirm = $mdDialog.confirm()
        //      .title('Seleccione localía')
        //      .content('Como jugará ' + team + ' en la 1º fecha')
        //      .ariaLabel('Localia')
        //      .ok('Local')
        //      .cancel('Visitante')
        //    $mdDialog.show(confirm).then(function () {
        //        $scope.esLocalDistinto = true;
        //    }, function () {
        //        $scope.esLocalDistinto = false;
        //    });
        //};

        /*Partidos Sidenav*/
        $scope.open = function() {
            $mdSidenav('partidos').open()
        };

        $scope.close = function () {
            $mdSidenav('partidos').close()
        };
        

        /*Array: Cargar los partidos de un equipo*/
        $scope.partidosEquipo = [];
        $scope.selection = function (teamName) {
            var idx = $scope.partidosEquipo.indexOf(teamName);
            if (idx > -1)
                $scope.partidosEquipo.splice(idx, 1);
            else
                $scope.partidosEquipo.push(teamName);
        };
             
        /*Cargar los arrays auxiliares (aux1 y aux2)*/
        function cargarArray(aux1, aux2) {
            cantFechas = $scope.partidosEquipo.length;
            pos = cantFechas;
            for (i = 0; i < cantFechas; i++) {
                if ($scope.partidosEquipo[i] == $scope.equipoDistinto) {
                    pos = i;
                    aux1.push($scope.equipoElegido);
                }
                if (i < pos)
                    aux1.push($scope.partidosEquipo[i]);
                else if (i > pos)
                    aux2.push($scope.partidosEquipo[i]);
            }
        }
        
        /*Función: buscar posición de un equipo dentro del array partidosEquipo*/
        function buscarPosicion(equipo) {
            for (p = 0; p < $scope.partidosEquipo.length; p++) {
                if ($scope.partidosEquipo[p] == equipo)
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
                    if ($scope.esLocalDistinto) {
                        partido.local = $scope.equipoDistinto;
                        partido.visitante = aux[ini];
                    } else {
                        partido.local = aux[ini];
                        partido.visitante = $scope.equipoDistinto;
                    }
                    if (aux[ini] != $scope.equipoPareja)
                        $scope.esLocalDistinto = !$scope.esLocalDistinto;
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
                        if ($scope.esLocalElegido)
                            partido = cargarPartido(a, j, aux1, partidoId, i);
                        else
                            partido = cargarPartido(j, a, aux1, partidoId, i);
                    } else {
                        if ($scope.esLocalElegido)
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
                        if ($scope.esLocalElegido)
                            partido = cargarPartido(k, b, aux2, partidoId, i);
                        else
                            partido = cargarPartido(b, k, aux2, partidoId, i);
                    } else {
                        if ($scope.esLocalElegido)
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
                             
                if (i != posDistinto)
                    $scope.esLocalElegido = !$scope.esLocalElegido;

                $scope.torneo.fixture.push(fecha);
            }


        }

    }]);

    app.controller('FixtureController', ['$stateParams', 'appData', function ($stateParams, appData) {

        this.fixture = appData.getTorneosByIdFixture($stateParams.id);

    }]);

    app.controller('PosicionesController', ['$stateParams', 'appData', function ($stateParams, appData) {

        this.equipos = appData.getTorneosByIdEquipos($stateParams.id);

        var actualFechaId = 1;
        this.fechaActual = appData.getFechaById($stateParams.id, actualFechaId);

        this.finalizarFecha = function (fechaId) {
            actualFechaId = fechaId + 1;
            this.fechaActual = appData.getFechaById($stateParams.id, actualFechaId);
        };

    }]);

    app.directive('tabsPage', [function () {
        return {
            restrict: 'E',
            templateUrl: '/App/Views/TabsPage.html',
            controller: function ($stateParams) {
                this.tab = 1;                                             
                this.selectedTab = function(newTab) {                    
                    this.tab = newTab;
                };
                this.id = $stateParams.id;
            },
            controllerAs: 'tab'
        };
    }]);
})();