(function () {
    'use strict';

    angular
        .module('app')
        .controller('TableController', TableController);

    TableController.$inject = ['$scope', 'tableRepository'];

    function TableController($scope, tableRepository) {
        $scope.tables = tableRepository.getAllTables();
    }
})();
