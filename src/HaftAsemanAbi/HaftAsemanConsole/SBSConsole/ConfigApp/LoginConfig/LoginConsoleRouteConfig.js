
'use strict'
angular.module('LoginConsoleModule').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        {
            url: '/haft-aseman-abi/CMS-Console/login',
            config:
                {
                    template: "<wwa-cms-login-service class='_flex _w100 _h100 base-login-content'></wwa-cms-login-service>"
                }
        },

    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
    $routeProvider.otherwise({ redirectTo: '/haft-aseman-abi/CMS-Console/login' });
}]);