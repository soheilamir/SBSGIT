
'use strict'
var SBSLinkUserCompany = angular.module("SBSLinkUserCompany", [
'FileManagerModule',
]);
SBSLinkUserCompany.config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        {
            url: '/sbs/profile/reserve-domestic-flight/:source/:destination/:departingDate/:returningDate/:numberPassenger/:d_AirLine/:d_Name/:d_PlaneType/:d_FlightNo/:d_DepartureTime/:d_ArrivalTime/:d_FlightClass/:d_AdultFare/:d_ChildFare/:d_InfantFare/:d_AirlineClassPathFeeId/:r_AirLine/:r_Name/:r_PlaneType/:r_FlightNo/:r_DepartureTime/:r_ArrivalTime/:r_FlightClass/:r_AdultFare/:r_ChildFare/:r_InfantFare/:r_AirlineClassPathFeeId',
            config:
                {
                    template: '<wwa-domestic-flight-reserve-service></wwa-domestic-flight-reserve-service>'
                },
        },
        {
            url: '/sbs/profile/reserve-domestic-flight/:source/:destination/:departingDate/:numberPassenger/:d_AirLine/:d_Name/:d_PlaneType/:d_FlightNo/:d_DepartureTime/:d_ArrivalTime/:d_FlightClass/:d_AdultFare/:d_ChildFare/:d_InfantFare/:d_AirlineClassPathFeeId',
            config:
                {
                    template: '<wwa-domestic-flight-reserve-service></wwa-domestic-flight-reserve-service>'
                },
        },
        {
            url: '/sbs/profile/reserve-domestic-flight/checkout-ticket/:refrenceId',
            config:
                {
                    template: '<wwa-checkout-ticket-service></wwa-checkout-ticket-service>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/sbs-airplane-service',
            config:
                {
                    template: '<wwa-airplane-service></wwa-airplane-service>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/sbs-hotel-service',
            config:
                {
                    template: '<wwa-hotel-service></wwa-hotel-service>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/:orderId/sbs-running-services',
            config:
                {
                    template: '<wwa-sbs-running-service></wwa-sbs-running-service>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/sbs-upload-file-services',
            config:
                {
                    template: '<wwa-sbs-upload-file-service class="_w100 _h100"></wwa-sbs-upload-file-service>'
                },
        },
         {
             url: '/sbs/profile/sbs-services/history/flight/booking-online-history',
             config:
                 {
                     template: '<wwa-sbs-booking-online-history-services class="_w100 _h100"></wwa-sbs-booking-online-history-services>'
                 },
         },
        {
            url: '/sbs/profile/sbs-services/history/serach-all-history-of-services',
            config:
                {
                    template: '<wwa-sbs-serach-history-services class="_w100 _h100"></wwa-sbs-serach-history-services>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/history/show-detail-history-of-services',
            config:
                {
                    template: '<wwa-sbs-detail-history-services class="_w100 _h100"></wwa-sbs-detail-history-services>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/print/flight/flgiht-ticket',
            config:
                {
                    template: '<wwa-sbs-flight-ticket-print-services class="_w100 _h100"></wwa-sbs-flight-ticket-print-services>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/print/hotel/hotel-voucher',
            config:
                {
                    template: '<wwa-sbs-hotel-voucher-print-services class="_w100 _h100"></wwa-sbs-hotel-voucher-print-services>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/flight/request/payment',
            config:
                {
                    template: '<wwa-sbs-req-peyment-services class="_w100 _h100"></wwa-sbs-req-peyment-services>'
                },
        },
        {
            url: '/sbs/profile/sbs-services/flight/detail/ordering',
            config:
                {
                    template: '<wwa-sbs-detail-flight-order-services class="_w100 _h100"></wwa-sbs-detail-flight-order-services>'
                },
        },
    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
}]);