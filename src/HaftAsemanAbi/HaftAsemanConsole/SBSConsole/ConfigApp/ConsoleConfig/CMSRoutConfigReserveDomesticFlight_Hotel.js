
'use strict'
angular.module('CMSModule').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        /// base url config
        {
            url: '/haft-aseman-abi/CMS-Console/reserve/domestic/flight',
            config:
                {
                    template: '<wwa-reserve-domestic-flight-service class="_w100 _h100"></wwa-reserve-domestic-flight-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/booking/domestic/domestic-flight-booking-service',
            config:
                {
                    template: '<wwa-dfb-service></wwa-dfb-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/reserve/domestic/hotel',
            config:
                {
                    template: '<wwa-reserve-domestic-hotel-service class="_w100 _h100"></wwa-reserve-domestic-hotel-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/booking/domestic/domestic-hotel-booking-service',
            config:
                {
                    template: '<wwa-dhb-service></wwa-dhb-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/reserve-domestic-flight/:source/:destination/:departingDate/:returningDate/:numberPassenger/:d_AirLine/:d_Name/:d_PlaneType/:d_FlightNo/:d_DepartureTime/:d_ArrivalTime/:d_FlightClass/:d_AdultFare/:d_ChildFare/:d_InfantFare/:d_AirlineClassPathFeeId/:r_AirLine/:r_Name/:r_PlaneType/:r_FlightNo/:r_DepartureTime/:r_ArrivalTime/:r_FlightClass/:r_AdultFare/:r_ChildFare/:r_InfantFare/:r_AirlineClassPathFeeId',
            config:
                {
                    template: '<wwa-domestic-flight-reserve-service></wwa-domestic-flight-reserve-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/reserve-domestic-flight/:source/:destination/:departingDate/:numberPassenger/:d_AirLine/:d_Name/:d_PlaneType/:d_FlightNo/:d_DepartureTime/:d_ArrivalTime/:d_FlightClass/:d_AdultFare/:d_ChildFare/:d_InfantFare/:d_AirlineClassPathFeeId',
            config:
                {
                    template: '<wwa-domestic-flight-reserve-service></wwa-domestic-flight-reserve-service>'
                },
        },
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/request-hotel-before-booking',
            config:
                {
                    template: '<wwa-req-hotel-before-booking-service></wwa-req-hotel-before-booking-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/send-req-hotel',
            config:
                {
                    template: '<wwa-send-req-hotel-service></wwa-send-req-hotel-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/hotel-ordering',
            config:
                {
                    template: '<wwa-ordering-hotel-service></wwa-ordering-hotel-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/detail-ordering-hotel',
            config:
                {
                    template: '<wwa-detail-ordering-hotel-service></wwa-detail-ordering-hotel-service>'
                }
        },
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/passenger-vocher-hotel',
            config:
                {
                    template: '<wwa-vocher-hotel-service></wwa-vocher-hotel-service>'
                }
        },
        //#region Panel website URL Config
        {
            url: '/haft-aseman-abi/CMS-Console/travel-agency/insurance-services',
            config:
                {
                    template: '<wwa-insurance-service></wwa-insurance-service>'
                }
        },
        //#endregion

    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });

}]);