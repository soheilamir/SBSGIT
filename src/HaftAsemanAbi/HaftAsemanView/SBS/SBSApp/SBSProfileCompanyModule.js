
'use strict'
var SBSProfileCompanyApp = angular.module("SBSProfileCompanyApp", [
    'ngRoute',
    'ngMaterial',
    'angucomplete-alt',
    'SBSLinkUserCompany',
    'SBSLinkAllModule',
    'LocalStorageModule',
    'companyModule',
    'extraSBSModule',
    //grid module
    'ui.grid', 'ui.grid.selection', 'ui.grid.resizeColumns', 'ui.grid.moveColumns',
    // ng progress
    'ngProgress',
    'ngFileUpload',
]);
SBSProfileCompanyApp.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
SBSProfileCompanyApp.run(['$rootScope', '$http', 'config', 'AuthManager', '$window', function ($rootScope, $http, config, AuthManager, $window) {
    $rootScope.baseData = {
        G_URI_SBS_Services: config.G_URI_SBS_Services,
        G_URI_New_API: config.G_URI_New_API,
        locationInfo: config.locationInfo,
        currencyInfo: config.currencyInfo,
        UserCompanyAccounts: config.UserCompanyAccounts,
        DomesticFlightInfo: null,
        objReserveFlight: null,
        Post: 'POST',
        Get: 'GET',
    };
    $rootScope.DepOrgItem = {
    };
    $rootScope.operation = {
        orderItemEdited: false,
    };
    $rootScope.ProfileDefaultData = {
        lstTicketType: [
            { id: '1', name: 'بلیط داخلی' },
            { id: '2', name: 'بلیط خارجی' },
        ],
        lstJourneyType: [
            { id: '1', name: 'تک سفره' },
            { id: '2', name: 'رفت و برگشت' },
            { id: '3', name: 'چند سفره' },

        ],
        lstCabinClass: [
            { id: '1', name: 'Economy' },
            { id: '2', name: 'Premium Economy' },
            { id: '3', name: 'Business' },
            { id: '4', name: 'First' },
        ],
        lstPreferredTime: [
            { id: '1', name: 'صبح' },
            { id: '2', name: 'ظهر' },
            { id: '3', name: 'بعد از ظهر' },
            { id: '4', name: 'عصر' },
            { id: '5', name: 'شب' },
        ],
        lstPassengerKind: [
            { id: '1', name: 'کهنسال' },
            { id: '2', name: 'بزرگسال' },
            { id: '3', name: 'جوان' },
            { id: '4', name: 'نوجوان' },
            { id: '5', name: 'کودک' },
        ],
        lstProvince: [
            { id: '1', name: 'ایران' },
        ],
        lstCity: [
            { id: '1', name: 'تهران' },
        ],
        // hotel param
        lstHotelType: [
            { id: '1', name: 'هتل داخلی' },
            { id: '2', name: 'هتل خارجی' },
        ],
        lstHotelRate: [
            { id: "1", number: "1" },
            { id: "2", number: "2" },
            { id: "3", number: "3" },
            { id: "4", number: "4" },
            { id: "5", number: "5" },
        ],
        lstRoomType: [
            { id: '1', name: 'single' },
            { id: '2', name: 'double' },
            { id: '3', name: 'triple' },
            { id: '4', name: 'quad' },
        ],
        lstRoomCnt: [
            { id: '1', number: '1' },
            { id: '2', number: '2' },
            { id: '3', number: '3' },
            { id: '4', number: '4' },
        ],
    };

    document.addEventListener("keyup", function (e) {
        if (e.keyCode === 27)
            $rootScope.$broadcast("escapePressed", e.target);
    });

    document.addEventListener("click", function (e) {
        $rootScope.$broadcast("documentClicked", e.target);
    });
}]);
// create function for fech data from server, then call fn(bootstrapProfileApplication)
fetchData().then(bootstrapProfileApplication);
function fetchData() {
    var configuration = {
        G_URI_SBS_Services: "http://localhost:9983/",
        G_URI_API: "http://localhost:9983/",
        G_URI_New_API: "http://localhost:15609/",
        Post: 'POST',
        Get: 'GET',
        locationInfo: null,
        currencyInfo: null,
        UserCompanyAccounts: [],
    }
    var initInjector = angular.injector(["ng"]);
    var $http = initInjector.get("$http");
    $http({
        method: configuration.Get,
        url: configuration.G_URI_SBS_Services + 'api/V1/LacationInfo/GetInfoCurrency',
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        configuration.currencyInfo = data;
        SBSProfileCompanyApp.constant("config", configuration);
    });
    return $http({
        method: configuration.Get,
        url: configuration.G_URI_SBS_Services + 'api/V1/LacationInfo/GetInfoLocation',
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        configuration.locationInfo = data;
        SBSProfileCompanyApp.constant("config", configuration);
    });
}
function bootstrapProfileApplication() {
    angular.element(document).ready(function () {
        angular.bootstrap(document, ["SBSProfileCompanyApp"]);
    });
}