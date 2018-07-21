
'use strict'
angular.module('CMSModule').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        /// base url config
        {
            url: '/haft-aseman-abi/CMS-Console/hotels/facilities-Cat-config',
            config:
                {
                    template: '<wwa-hotel-facilitiescat-config-service class="_w100 _h100"></wwa-hotel-facilitiescat-config-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/hotels/facilities-config',
            config:
                {
                    template: '<wwa-hotel-facilities-config-service class="_w100 _h100"></wwa-hotel-facilities-config-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/hotels/city-public-place-config',
            config:
                {
                    template: '<wwa-hotel-city-public-place-config-service class="_w100 _h100"></wwa-hotel-city-public-place-config-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/hotels/hotel-base-config',
            config:
                {
                    template: '<wwa-hotel-base-config-service class="_w100 _h100"></wwa-hotel-base-config-service>'
                }
        },
        //#region Panel website URL Config

        //#endregion

    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
}]);