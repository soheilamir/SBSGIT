'use strict'
angular.module('CMSModule').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        {
            url: '/haft-aseman-abi/CMS-Console/base-info/airline-config',
            config:
                {
                    template: '<wwa-airline-config-service class="_w100 _h100"></wwa-airline-config-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/base-info/airplane-config',
            config:
                {
                    template: '<wwa-airplane-config-service class="_w100 _h100"></wwa-airplane-config-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/base-info/airline-classes-config',
            config:
                {
                    template: '<wwa-airline-classes-config-service class="_w100 _h100"></wwa-airline-classes-config-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/base-info/airline-sub-classes-config',
            config:
                {
                    template: '<wwa-airline-sub-classes-config-service class="_w100 _h100"></wwa-airline-sub-classes-config-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/base-info/flight-path-config',
            config:
                {
                    template: '<wwa-flight-path-config-service class="_w100 _h100"></wwa-flight-path-config-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/base-info/airline-class-path-config',
            config:
                {
                    template: '<wwa-airline-class-path-config-service class="_w100 _h100"></wwa-airline-class-path-config-service>'
                },
        },
    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
}]);