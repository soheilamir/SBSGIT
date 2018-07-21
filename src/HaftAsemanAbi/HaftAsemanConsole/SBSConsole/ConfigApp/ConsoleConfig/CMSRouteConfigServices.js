
'use strict'
angular.module('CMSModule').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        {
            url: '/haft-aseman-abi/CMS-Console/oneway-roundTrip-airplane',
            config:
                {
                    template: "<wwa-one-rt-way-airplane-service></wwa-one-rt-way-airplane-service>"
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/multiway-airplane',
            config:
                {
                    template: "<wwa-multi-way-airplane-service></wwa-multi-airplane-service>"
                }
        },

    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
}]);