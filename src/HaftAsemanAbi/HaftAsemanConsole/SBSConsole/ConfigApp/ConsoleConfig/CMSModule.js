
'use strict'
var CMSModule = angular.module("CMSModule", [
    'ngRoute',
    'ngMaterial',
    'angucomplete-alt',
    // ng progress
    'ngProgress',
    //grid module
    'ui.grid', 'ui.grid.selection', 'ui.grid.resizeColumns', 'ui.grid.moveColumns', 'ui.grid.infiniteScroll',
    //ngCkeditor
    'ngCkeditor',
    ///////////////
    'ngFileUpload',
    '720kb.tooltips',
    'SBSCmsRunModule',
    'FileManagerModule',
    'ngDialog',
]);
CMSModule.config(['ngDialogProvider', function (ngDialogProvider) {
    ngDialogProvider.setDefaults({
        className: 'ngdialog-theme-default',
        plain: false,
        showClose: true,
        closeByDocument: false,
        closeByEscape: false,
        appendTo: false,
        preCloseCallback: function () {
            console.log('default pre-close callback');
        }
    });
}]);
CMSModule.directive('ckEditor', [function () {
    return {
        require: '?ngModel',
        link: function (scope, elm, attr, ngModel) {
            var ck = CKEDITOR.replace(elm[0]);
            if (!ngModel) return;
            ck.on('instanceReady', function () {
                ck.setData(ngModel.$viewValue);
            });
            ck.on('pasteState', function () {
                scope.$apply(function () {
                    ngModel.$setViewValue(ck.getData());
                });
            });
            function updateModel() {
                scope.$apply(function () {
                    ngModel.$setViewValue(ck.getData());
                });
            }
            scope.$on('update', function () {
                ck.setData("");
            });
            ck.on('change', updateModel);
            ck.on('key', updateModel);
            ck.on('dataReady', updateModel);

            ngModel.$render = function (value) {
                ck.setData(ngModel.$viewValue);
            };
        }
    };
}]);
CMSModule.run(['$rootScope', 'config', function ($rootScope, config) {
    $rootScope.SelectedFilesList = [];
    $rootScope.baseData = {
        G_URI_API: config.G_URI_API,
        New_G_URI_API: config.New_G_URI_API,
        Post: config.Post,
        Get: config.Get,
        ChackedHttp: true,
        AssignBttnIsMultiSelectConfig: false,
    };
    $rootScope.baseDefaultSearchData = {
        
        lstJourneyType: [
            { Id: '1', JourneyTypeName: 'رفت' },
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
        Departing: [],
        Returning: [],
        searchFlightItem: {},
    };
}]);
fetchData();
bootstrapApplication();
function fetchData() {
    var configuration = {
        G_URI_API: "http://localhost:9983/",
        New_G_URI_API: "http://localhost:15609/",
        Post: 'POST',
        Get: 'GET',
    }
    CMSModule.constant("config", configuration);
    return 0;
}
function bootstrapApplication() {
    angular.element(document).ready(function () {
        angular.bootstrap(document, ["CMSModule"]);
    });
}