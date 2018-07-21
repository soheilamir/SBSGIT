
'use strict'
angular.module('CMSModule').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        /// base url config
        {
            url: '/haft-aseman-abi/CMS-Console/dashboard',
            config:
                {
                    template: '<wwa-dashboard-service class="_w100 _h100"></wwa-dashboard-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/upload-files',
            config:
                {
                    template: '<wwa-upload-file-service class="_w100 _h100"></wwa-upload-file-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/req-credit-limit',
            config:
                {
                    template: '<wwa-req-credit-limit-service class="_w100 _h100"></wwa-req-credit-limit-service>'
                },
        },

    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
    $routeProvider.otherwise({ redirectTo: '/haft-aseman-abi/CMS-Console/dashboard' });
}]);