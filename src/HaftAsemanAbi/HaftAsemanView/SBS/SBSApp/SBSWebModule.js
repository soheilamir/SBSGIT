
'use strict'
var SBSWebApp = angular.module("SBSWebApp", [
    'ngRoute',
    'ngMaterial',
    'angucomplete-alt',
    'websiteModule',
    'extraSBSModule',
    'SBSLinkAllModule',
    'LocalStorageModule',
    // ng progress
    'ngProgress',
    'ADM-dateTimePicker',
    'kk.timepicker'
]);
SBSWebApp.config(['$httpProvider', 'ADMdtpProvider', function ($httpProvider, ADMdtp) {
    $httpProvider.interceptors.push('authInterceptorService');
    ADMdtp.setOptions({
        calType: "jalali", format: "YYYY/MM/DD", gregorianStartDay: 1,
        autoClose: true,

    });
}]);
SBSWebApp.run(['$rootScope', '$http', 'config', 'AuthManager', function ($rootScope, $http, config, AuthManager) {
    AuthManager.objAuth.fillAuthData();
    $rootScope.baseData = {
        G_URI_SBS_Services: config.G_URI_SBS_Services,
        locationInfo: config.locationInfo,
        currencyInfo: config.currencyInfo,
    };
    $rootScope.baseDefaultSearchData = {
        lstJourneyType: [
            { Id: '1', JourneyTypeName: 'یک طرفه' },
            { Id: '2', JourneyTypeName: 'رفت و برگشت' },
        ],
        lstAdult: [
            { Id: '1', Number: '1' },
            { Id: '2', Number: '2' },
            { Id: '3', Number: '3' },
            { Id: '4', Number: '4' },
            { Id: '5', Number: '5' },
            { Id: '6', Number: '6' },
            { Id: '7', Number: '7' },
            { Id: '8', Number: '8' },
            { Id: '9', Number: '9' },
        ],
        lstChild: [
            { Id: '1', Number: '1' },
            { Id: '2', Number: '2' },
            { Id: '3', Number: '3' },
            { Id: '4', Number: '4' },
            { Id: '5', Number: '5' },
            { Id: '6', Number: '6' },
            { Id: '7', Number: '7' },
            { Id: '8', Number: '8' },
            { Id: '9', Number: '9' },
        ],
        lstInfant: [
            { Id: '1', Number: '1' },
            { Id: '2', Number: '2' },
            { Id: '3', Number: '3' },
            { Id: '4', Number: '4' },
            { Id: '5', Number: '5' },
            { Id: '6', Number: '6' },
            { Id: '7', Number: '7' },
            { Id: '8', Number: '8' },
            { Id: '9', Number: '9' },
        ],
        lstDomesticAirline: [
            { Id: '1', D_AirlineName: 'آتا', AirlineATAName: 'I3' },
            { Id: '2', D_AirlineName: 'ایران ایر', AirlineATAName: 'IR' },
            { Id: '3', D_AirlineName: 'قشم اير', AirlineATAName: 'QB' },
            { Id: '6', D_AirlineName: 'آسمان', AirlineATAName: 'EP' },
            { Id: '7', D_AirlineName: 'تابان', AirlineATAName: 'HH' },
            { Id: '8', D_AirlineName: 'نفت', AirlineATAName: 'NV' },
        ],
        lstCitys: [
            { Id: '1', CityName: 'تهران', CharCode: 'THR' },
            { Id: '2', CityName: 'مشهد', CharCode: 'MHD' },
            { Id: '3', CityName: 'شیراز', CharCode: 'SYZ' },
            { Id: '4', CityName: 'اصفهان', CharCode: 'IFN' },
            { Id: '5', CityName: 'کیش', CharCode: 'KIH' },
            { Id: '6', CityName: 'یزد', CharCode: 'AZD' },
            { Id: '7', CityName: 'کرمانشاه', CharCode: 'KSH' },
            { Id: '8', CityName: 'اهواز', CharCode: 'AWZ' },
            { Id: '9', CityName: 'کرمان', CharCode: 'KER' },
            { Id: '10', CityName: 'رشت', CharCode: 'RAS' },
            { Id: '11', CityName: 'تبریز', CharCode: 'TBZ' },
            { Id: '12', CityName: 'گرگان', CharCode: 'GBT' },
            { Id: '13', CityName: 'بندرعباس', CharCode: 'BND' },
            { Id: '14', CityName: 'بیرجند', CharCode: 'XBJ' },
            { Id: '15', CityName: 'بوشهر', CharCode: 'BUZ' },
            { Id: '16', CityName: 'اردبیل', CharCode: 'ADU' },
        ],
    };
    $rootScope.DomesticResultTickets = {
        Departing: [{
            AirLine: "IR",
            Name: "ایران ایر",
            LogoImg: "https://cdn.alibaba.ir/static/img/airlines/Domestic/IR.png",
            Origin: "تهران",
            OriginIATACODE: "THR",
            Destination: "شیراز",
            DestinationIATACODE: "SYZ",
            DepartureDateMiladi: "10/22/2017",
            DepartureDateShamsi: "1396/7/30",
            ArrivalTime: "15:45",
            DepartureTime: "16:20",
            FlightNo: "IR426",
            PlaneType: "Airbus",
            PlaneTypeCode: "A320",
            ClassFareList: [
                {
                    FlightClass: "C",
                    InfantFare: "494000",
                    ChildFare: "1794000",
                    AdultFare: "2494000",
                    selected: false,
                    AirlineClassPathFeeId: "1",
                },
                {
                    FlightClass: "D",
                    InfantFare: "594000",
                    ChildFare: "1324000",
                    AdultFare: "3494000",
                    selected: false,
                    AirlineClassPathFeeId: "2",
                },
                {
                    FlightClass: "F",
                    InfantFare: "394000",
                    ChildFare: "1294000",
                    AdultFare: "3584000",
                    selected: false,
                    AirlineClassPathFeeId: "3",
                }
            ]

        }
        ],
        Returning: [{
            AirLine: "IR",
            Name: "ایران ایر",
            LogoImg: "https://cdn.alibaba.ir/static/img/airlines/Domestic/IR.png",
            Origin: "تهران",
            OriginIATACODE: "THR",
            Destination: "شیراز",
            DestinationIATACODE: "SYZ",
            DepartureDateMiladi: "10/22/2017",
            DepartureDateShamsi: "1396/7/30",
            ArrivalTime: "15:45",
            DepartureTime: "16:20",
            FlightNo: "IR426",
            PlaneType: "Airbus",
            PlaneTypeCode: "A320",
            ClassFareList: [
                {
                    FlightClass: "C",
                    InfantFare: "494000",
                    ChildFare: "1794000",
                    AdultFare: "2494000",
                    selected: false,
                    AirlineClassPathFeeId: "1",
                },
                {
                    FlightClass: "D",
                    InfantFare: "594000",
                    ChildFare: "1324000",
                    AdultFare: "3494000",
                    selected: false,
                    AirlineClassPathFeeId: "2",
                },
                {
                    FlightClass: "F",
                    InfantFare: "394000",
                    ChildFare: "1294000",
                    AdultFare: "3584000",
                    selected: false,
                    AirlineClassPathFeeId: "3",
                }
            ]

        }],
        searchFlightItem: {},
    };

    document.addEventListener("keyup", function (e) {
        if (e.keyCode === 27)
            $rootScope.$broadcast("escapePressed", e.target);
    });

    document.addEventListener("click", function (e) {
        $rootScope.$broadcast("documentClicked", e.target);
    });
}]);
fetchData().then(bootstrapApplication);
function fetchData() {
    var configuration = {
        G_URI_SBS_Services: "http://localhost:9983/",
        G_URI_API: "http://localhost:9983/",
        Post: 'POST',
        Get: 'GET',
        locationInfo: null,
        currencyInfo: null,
    }
    var initInjector = angular.injector(["ng"]);
    var $http = initInjector.get("$http");
    $http({
        method: configuration.Get,
        url: configuration.G_URI_SBS_Services + 'api/V1/LacationInfo/GetInfoCurrency',
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        configuration.currencyInfo = data;
        SBSWebApp.constant("config", configuration);
    });
    return $http({
        method: configuration.Get,
        url: configuration.G_URI_SBS_Services + 'api/V1/LacationInfo/GetInfoLocation',
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        configuration.locationInfo = data;
        SBSWebApp.constant("config", configuration);
    });
}
function bootstrapApplication() {
    angular.element(document).ready(function () {
        angular.bootstrap(document, ["SBSWebApp"]);
    });
}