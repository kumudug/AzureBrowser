(function () {
    'use strict';

    angular
        .module('app')
        .factory('tableRepository', tableRepository);

    tableRepository.$inject = ['$resource'];

    function tableRepository($resource) {
        var service = {
            getAllTables: getAllTables,
            getTableRowCount: getTableRowCount

        };

        return service;

        function getAllTables() {
            return $resource('/api/azuretable/getalltables').query();
        };

        function getTableRowCount(tableName) {
            return $resource('/api/azuretable/' + tableName).query();
        };
    }
})();