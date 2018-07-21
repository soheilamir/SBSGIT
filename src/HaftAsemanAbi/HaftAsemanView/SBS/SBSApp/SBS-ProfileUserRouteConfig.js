
'use strict'
angular.module("SBSProfileUserApp").config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
         {
             url: '/sbs/user-profile/user-page',
             config:
                 {
                     template: '<wwa-user-profile-page-service></wwa-user-profile-page-service>'
                 },
         },
         {
             url: '/sbs/user-profile/company/acception-company-req',
             config:
                 {
                     template: '<wwa-user-acception-req-company-services></wwa-user-acception-req-company-services>'
                 },
         },
         {
             url: '/sbs/profile/sbs-services/passenger/show-all-passenger',
             config:
                 {
                     template: '<wwa-sbs-passenger-service class="_w100 _h100"></wwa-sbs-passenger-service>'
                 },
         },
         {
             url: '/sbs/user-profile/users/change-user-information',
             config:
                 {
                     template: '<wwa-change-user-info-services></wwa-change-user-info-services>'
                 },
         },
         {
             url: '/sbs/user-profile/users/charge-account',
             config:
                 {
                     template: '<wwa-user-charge-account-services></wwa-user-charge-account-services>'
                 },
         },
    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
    $routeProvider.otherwise({ redirectTo: '/sbs/user-profile/user-page' });
}]);

