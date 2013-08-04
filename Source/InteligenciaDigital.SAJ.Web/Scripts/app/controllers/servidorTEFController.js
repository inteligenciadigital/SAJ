'use strict';
/* App Controllers */


function ServidorTEFController($scope, $http, $window, $location) {
    JqGridHelper.criarGrid({
        url: '/api/servidortef',
        caption: "Cadastro de Servidores TEF",
        editurl: "/api/servidortef",
        colNames: ['Id', 'Nome', 'EnderecoIP'],
        colModel: [
            { name: 'Id', index: 'Id', width: 60, sorttype: "int", key: true },
            { name: 'Nome', index: 'Nome', width: 100, editable: true },
            { name: 'EnderecoIP', index: 'EnderecoIP', width: 100, editable: true }
        ]
    });
}

ServidorTEFController.$inject = ['$scope', '$http', '$window', '$location'];