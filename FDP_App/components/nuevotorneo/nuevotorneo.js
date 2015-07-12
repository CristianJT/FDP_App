(function () {
    //'use strict';

    angular.module('FDPApp.nuevoTorneo', [])
        .controller('NuevotorneoController', ['leaguesData', 'teamsData', '$mdSidenav', '$location' , NuevotorneoController]);

    function NuevotorneoController(leaguesData, teamsData, $mdSidenav, $location) {

        var vm = this;

        /*Obtener datos de 'appService'*/
        vm.torneos = leaguesData.query();
        vm.equipos = teamsData.query();
   
        /* --- DATOS DEL TORNEO --- */

        /*Array: Cargar equipos ascendidos*/
        vm.equiposSelec = [];
        vm.seleccion = function (nombreEquipo) {
            var idx = vm.equiposSelec.indexOf(nombreEquipo);
            if (idx > -1)
                vm.equiposSelec.splice(idx, 1);
            else
                vm.equiposSelec.push(nombreEquipo);
        };

        /*Calcular datos extras formulario (fixture y equipos)  */
        vm.cantidadFechasEquipos = function () {
            vm.totalFechas;
            vm.fechaEspecial;
            vm.fechaEspecialNum;

            vm.totalEquipos;
            vm.totalEquiposPrimera = 0;
            vm.totalEquiposAscendidos;

            for (i = 0; i < vm.equipos.length; i++) {
                if (vm.equipos[i].isTopDivision)
                    vm.totalEquiposPrimera++;
            }
            if (vm.fechaEspecial)
                vm.totalEquipos = vm.totalFechas;
            else
                vm.totalEquipos = vm.totalFechas + 1;

            vm.totalEquiposAscendidos = vm.totalEquipos - vm.totalEquiposPrimera;
        };

        /*Función: Confirmar datos torneo*/
        vm.torneo = new leaguesData()
        vm.confirmado = false;

        vm.confirmarTorneo = function () {

            vm.torneo.isCurrent = true;
            vm.torneo.champion = null;
            vm.torneo.teams = [];

            vm.torneo.fixture = {};
            vm.torneo.fixture.totalGames = vm.totalFechas;
            vm.torneo.fixture.specialGame = vm.fechaEspecialNum;

            vm.torneo.fixture.games = [];

            /*Recorro el array de equipos. Si un equipo es "ascendido" modifico atributo "esPrimera"*/
            /*Si "esPrimera" = true cargo el equipo al nuevo torneo*/
            for (i = 0; i < vm.equipos.length; i++) {
                if (vm.equiposSelec.indexOf(vm.equipos[i].name) > -1) {
                    vm.equipos[i].isTopDivision = true;
                    vm.equipos[i].$update({id: vm.equipos[i].teamId});
                }
                if (vm.equipos[i].isTopDivision) {
                    vm.torneo.teams.push(vm.equipos[i]);
                }
            };
            vm.confirmado = true;
        };

        /*Función: Resetear formulario*/
        vm.reset = function () {
            vm.torneo = {};
            vm.totalFechas = null;
        };


        /* --- CREAR FIXTURE --- */

        /*Partidos Sidenav*/
        vm.open = function () {
            $mdSidenav('partidos').open()
        };

        vm.close = function () {
            $mdSidenav('partidos').close()
        };


        /*Array: Cargar los partidos de un equipo*/
        vm.partidosEquipo = [];
        vm.selection = function (teamName) {
            var idx = vm.partidosEquipo.indexOf(teamName);
            if (idx > -1)
                vm.partidosEquipo.splice(idx, 1);
            else
                vm.partidosEquipo.push(teamName);
        };


        /*Función: buscar posición de un equipo dentro del array partidosEquipo*/
        function buscarPosicion(equipo, partidos) {
            for (p = 0; p < partidos.length; p++) {
                if (partidos[p] == equipo)
                    return p;
            }
        };


        /*Cargar los arrays auxiliares (aux1 y aux2)*/
        function cargarArray(aux1, aux2, partidos, equipoDistinto, equipoElegido ) {
            var posicionDistinto = buscarPosicion(equipoDistinto, partidos);
            for (i = 0; i < partidos.length; i++) {
                if (i < posicionDistinto)
                    aux1.push(partidos[i]);
                else if (i > posicionDistinto)
                    aux2.push(partidos[i]);
                else
                    aux1.push(equipoElegido);
            }
        }


        /*Función: cargar partidos por fecha*/
        function cargarPartido(ini, fin, aux, partido) {

            var partido = {};
            if (ini == fin) {
                if (vm.esLocalDistinto) {
                    partido.home_team = vm.equipoDistinto;
                    partido.away_team = aux[ini];
                } else {
                    partido.home_team = aux[ini];
                    partido.away_team = vm.equipoDistinto;
                }
                if (aux[ini] != vm.equipoPareja)
                    vm.esLocalDistinto = !vm.esLocalDistinto;
            }
            else {
                partido.home_team = aux[ini];
                partido.away_team = aux[fin];
            }
            return partido;
        };

        /*Armar fixture completo*/
        vm.armarFixture = function () {
            var aux1 = [];
            var aux2 = [];
            cargarArray(aux1, aux2, vm.partidosEquipo, vm.equipoDistinto, vm.equipoElegido);

            for (i = 0; i < vm.torneo.fixture.totalGames; i++) {
                var fecha = {};
                fecha.gameNumber = i + 1;
                fecha.matches = [];

                if (vm.torneo.fixture.specialGame != fecha.gameNumber) {

                    var posicionDistinto = buscarPosicion(vm.equipoDistinto, vm.partidosEquipo);
                    /*Recorro aux1*/
                    var aux1Fin = aux1.length - 1;
                    var aux1Inicio = 0;
                  
                    while (aux1Inicio <= aux1Fin) {
                        if (i <= posicionDistinto) {
                            if (vm.esLocalElegido)
                                partido = cargarPartido(aux1Fin, aux1Inicio, aux1, i);
                            else
                                partido = cargarPartido(aux1Inicio, aux1Fin, aux1, i);
                        } else {
                            if (vm.esLocalElegido)
                                partido = cargarPartido(aux1Inicio, aux1Fin, aux1, i);
                            else
                                partido = cargarPartido(aux1Fin, aux1Inicio, aux1, i);
                        }

                        fecha.matches.push(partido);
                        aux1Inicio++;
                        aux1Fin--;
                    }

                    /*Recorro aux2*/
                    var aux2Fin = aux2.length - 1;
                    var aux2Inicio = 0;
                    while (aux2Inicio <= aux2Fin) {
                        if (i <= posicionDistinto) {
                            if (vm.esLocalElegido)
                                partido = cargarPartido(aux2Inicio, aux2Fin, aux2, i);
                            else
                                partido = cargarPartido(aux2Fin, aux2Inicio, aux2, i);
                        } else {
                            if (vm.esLocalElegido)
                                partido = cargarPartido(aux2Fin, aux2Inicio, aux2, i);
                            else
                                partido = cargarPartido(aux2Inicio, aux2Fin, aux2, i);
                        }

                        fecha.matches.push(partido);
                        aux2Inicio++;
                        aux2Fin--;
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
                        vm.esLocalElegido = !vm.esLocalElegido;
                } 

                vm.torneo.fixture.games.push(fecha);
            }
            vm.torneo.fixture.games[0].isCurrent = true;
            vm.torneo.$save(function () {
                vm.torneo.startDate = new Date(vm.torneo.startDate);
                vm.torneo.finishDate = new Date(vm.torneo.finishDate);
                $location.path("/torneo/" + vm.torneo.leagueId);
            });
        }

    }

})();
