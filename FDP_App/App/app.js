(function () {

    var app = angular.module('FDPApp', ['ui.router', 'ui.bootstrap', 'appService', 'ngMaterial']);

    app.config(function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('nuevoTorneo', {
                url: '/nuevo',
                templateUrl: '/App/Views/TorneosNuevo.html',
                controller: 'TorneoNuevoController',
                controllerAs: 'nuevoCtrl'
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
                controllerAs: 'fechaCtrl'
            })
            .state('posiciones', {
                url: '/torneos/:id/posiciones',
                templateUrl: '/App/Views/Posiciones.html',
                controller: 'PosicionesController',
                controllerAs: 'posicionCtrl'
            })
        $urlRouterProvider.otherwise('/');
    });

    app.controller('NavController', ['appData', function (appData) {
        this.torneos = appData.getTorneos();       
    }]);

    app.controller('TorneoNuevoController', ['$scope', '$location', 'appData', function ($scope, $location, appData) {

        this.torneos = appData.getTorneos();
        this.equipos = appData.getEquipos();
    
        /*Funcionalidad para el monthPicker*/
        $scope.open = function ($event, opened) {
            $event.preventDefault();
            $event.stopPropagation();
            $scope[opened] = !$scope[opened];
        };

        /*Array: Cargar equipos ascendidos*/
        this.equiposSelec = [];
        this.seleccion = function (nombreEquipo) {
            var idx = this.equiposSelec.indexOf(nombreEquipo);
            if (idx > -1) 
                this.equiposSelec.splice(idx, 1);
            else 
                this.equiposSelec.push(nombreEquipo);
        };
   
        /*Calcular datos extras formulario (fixture y equipos)  */
        this.cantidadFechasEquipos = function () {
            this.totalFechas;
            this.fechaEspecial;
            this.fechaEspecialNum;

            this.totalEquipos;
            this.totalEquiposPrimera = 0;
            this.totalEquiposAscendidos;

            for (i = 0; i < this.equipos.length; i++) {
                if (this.equipos[i].esPrimera)
                    this.totalEquiposPrimera++;
            }
            if (this.fechaEspecial)
                this.totalEquipos = this.totalFechas;
            else
                this.totalEquipos = this.totalFechas + 1;

            this.totalEquiposAscendidos = this.totalEquipos - this.totalEquiposPrimera;
        };

        /*Función: Crear torneo*/
        this.torneo = {};     

        this.crearTorneo = function () {
            var lastId = 0;
            if (this.torneos.length != 0)
                lastId = this.torneos[this.torneos.length - 1].id;
            this.torneo.id = lastId + 1;
            this.torneo.isCurrent = true;
            this.torneo.campeon = null;

            this.torneo.fixture = {};
            this.torneo.fixture.totalFechas = this.totalFechas;
            this.torneo.fixture.fechaEspecialNumero = this.fechaEspecialNum;
         
            this.torneo.fixture.fechas = [];
            this.torneo.equipos = [];

            /*Recorro el array de equipos. Si un equipo es "ascendido" modifico atributo "esPrimera"*/
            /*Si "esPrimera" = true cargo el equipo al nuevo torneo*/
            for (i = 0; i < this.equipos.length; i++) {
                if (this.equiposSelec.indexOf(this.equipos[i].nombre) > -1) {
                    this.equipos[i].esPrimera = true;
                }
                if (this.equipos[i].esPrimera) {
                    this.torneo.equipos.push(this.equipos[i]);
                }
            };
            
            this.torneos.push(this.torneo);
            redirect(this.torneo.id);
        };

        /*Función: Resetear formulario*/
        this.reset = function() {
            this.torneo = {};
            this.totalFechas = null;
        };

        /*Redireccionar al nuevo torneo*/
        redirect = function (id) {
            $location.path('/torneos/' + id);
        };

    }]);

    app.controller('TorneoController', ['$scope', '$stateParams', 'appData', '$mdDialog', '$mdSidenav', function ($scope, $stateParams, appData, $mdDialog, $mdSidenav) {

        $scope.torneo = appData.getTorneosById($stateParams.id);
        
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
         

        /*Función: buscar posición de un equipo dentro del array partidosEquipo*/
        function buscarPosicion(equipo) {
            for (p = 0; p < $scope.partidosEquipo.length; p++) {
                if ($scope.partidosEquipo[p] == equipo)
                    return p;
            }
        };


        /*Cargar los arrays auxiliares (aux1 y aux2)*/
        function cargarArray(aux1, aux2) {
            posicionDistinto = buscarPosicion($scope.equipoDistinto);
            for (i = 0; i < $scope.partidosEquipo.length; i++) {
                if (i < posicionDistinto)
                    aux1.push($scope.partidosEquipo[i]);
                else if (i > posicionDistinto)
                    aux2.push($scope.partidosEquipo[i]);
                else
                    aux1.push($scope.equipoElegido);
            }
        }
             

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
            
            for (i = 0; i < $scope.torneo.fixture.totalFechas; i++) {
                var fecha = {};
                fecha.id = i + 1;
                fecha.partidos = [];

                if ($scope.torneo.fixture.fechaEspecialNumero != fecha.id) {

                    //Recorro aux1
                    aux1Fin = aux1.length - 1;
                    aux1Inicio = 0;
                    partidoId = 1;
                    while (aux1Inicio <= aux1Fin) {
                        if (i <= posicionDistinto) {
                            if ($scope.esLocalElegido)
                                partido = cargarPartido(aux1Fin, aux1Inicio, aux1, partidoId, i);
                            else
                                partido = cargarPartido(aux1Inicio, aux1Fin, aux1, partidoId, i);
                        } else {
                            if ($scope.esLocalElegido)
                                partido = cargarPartido(aux1Inicio, aux1Fin, aux1, partidoId, i);
                            else
                                partido = cargarPartido(aux1Fin, aux1Inicio, aux1, partidoId, i);
                        }

                        fecha.partidos.push(partido);
                        aux1Inicio++;
                        aux1Fin--;
                        partidoId++;
                    }

                    //Recorro aux2
                    aux2Fin = aux2.length - 1;
                    aux2Inicio = 0;
                    while (aux2Inicio <= aux2Fin) {
                        if (i <= posicionDistinto) {
                            if ($scope.esLocalElegido)
                                partido = cargarPartido(aux2Inicio, aux2Fin, aux2, partidoId, i);
                            else
                                partido = cargarPartido(aux2Fin, aux2Inicio, aux2, partidoId, i);
                        } else {
                            if ($scope.esLocalElegido)
                                partido = cargarPartido(aux2Fin, aux2Inicio, aux2, partidoId, i);
                            else
                                partido = cargarPartido(aux2Inicio, aux2Fin, aux2, partidoId, i);
                        }

                        fecha.partidos.push(partido);
                        aux2Inicio++;
                        aux2Fin--;
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

                    if (i != posicionDistinto)
                        $scope.esLocalElegido = !$scope.esLocalElegido;
                }
   
                $scope.torneo.fixture.fechas.push(fecha);
            }


        }

    }]);

    app.controller('FixtureController', ['$stateParams', 'appData', function ($stateParams, appData) {

        this.fixture = appData.getTorneosByIdFixture($stateParams.id);

    }]);

    app.controller('PosicionesController', ['$stateParams', 'appData', function ($stateParams, appData) {

        this.equipos = appData.getTorneosByIdEquipos($stateParams.id);

        var actualFechaId = 1;
        this.anteriorFechaId = 0;
   
        this.fechaActual = appData.getFechaById($stateParams.id, actualFechaId);

        this.finalizarFecha = function () {
            this.anteriorFechaId = actualFechaId;
            actualFechaId ++;
            this.fechaAnterior = this.fechaActual;
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