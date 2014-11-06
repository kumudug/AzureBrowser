(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules 
        'ngRoute',
        'ngResource'

        // Custom modules 

        // 3rd Party Modules
        
    ]);

    app.config(function ($routeProvider, $locationProvider) {
        $routeProvider.when('/Azure/Tables', { templateUrl: '/templates/azure-tables.html', controller: 'TableController' });
        $routeProvider.otherwise({ redirectTo: "/Azure" });
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: false
        })
    });

})();