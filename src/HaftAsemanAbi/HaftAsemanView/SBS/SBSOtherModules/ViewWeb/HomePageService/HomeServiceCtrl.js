/// <reference path="D:\SBSProject\SBSWebProject_95-11-30\src\HaftAsemanAbi\scripts/angular.js" />

'use strict'
angular.module('homeServiceModule').controller('homeServiceCtrl', ['$scope', '$rootScope', 'homeServiceModelFactory', 'internalFlightModelFactory', 'homeServiceFactory', '$routeParams', '$location', '$http', '$interval', 'ngProgressFactory', 'allContentInModal', 'modalContentFactory', function ($scope, $rootScope, homeServiceModelFactory, internalFlightModelFactory, homeServiceFactory, $routeParams, $location, $http, $interval, ngProgressFactory, allContentInModal, modalContentFactory) {
    //#region get Data
    $scope.progressbar = ngProgressFactory.createInstance(); $scope.progressbar.setColor("#3F92D6");///// set progress bar config
    $scope.dp = { _J: { id: '1', b: false, }, _G: { id: '2', b: false, }, };
    $scope.__ShowContent = true;
    $scope.baseData = $rootScope.baseDefaultSearchData;
    $scope.dataCitys = $scope.baseData.lstCitys;
    $scope.initDataPage = new homeServiceModelFactory();
    $scope.searchFlight = new internalFlightModelFactory();
    $scope.progressbar.start();
    homeServiceFactory.homefactory.FillingHomePage('_f').then(function (data) {
        $scope.initDataPage.banner = data.data;
        $scope.progressbar.complete();
    });
    //#endregion
    //#region Method content
    $scope.changeTab = function (kindTab) {
        if (kindTab === '_f')
            $scope.__ShowContent = true;
        else if (kindTab === '_h')
            $scope.__ShowContent = false;
        homeServiceFactory.homefactory.FillingHomePage(kindTab).then(function (data) {
            $scope.initDataPage.banner = data.data;
            $scope.progressbar.complete();
        });

    }
    $scope.SearchInternalFlight = function (source, destination) {
        modalContentFactory.modalContent.open(allContentInModal.allContent.CreateInnerModal, allContentInModal.allContent.FlightBooking);
        $scope.progressbar.setColor("#6C1B78");
        $scope.progressbar.start();
        $scope.searchFlight.Source = source;
        $scope.searchFlight.Destination = destination;
        $rootScope.DomesticResultTickets.searchFlightItem = $scope.searchFlight;
        if ($scope.searchFlight.ReturningDate == null)
            $scope.searchFlight.ReturningDate = "0/0/0";
        //homeServiceFactory.homefactory.InternalFlight($scope.searchFlight).then(function (response) {
        //    if (!angular.isUndefined(response.data.Departing))
        //        if (response.data.Departing.length > 0)
        //            angular.copy(response.data.Departing, $rootScope.DomesticResultTickets.Departing);
        //    if (!angular.isUndefined(response.data.Returning)) {
        //        if (response.data.Returning.length > 0)
        //            angular.copy(response.data.Returning, $rootScope.DomesticResultTickets.Returning);
        //    }
        //    $scope.progressbar.complete();
        //    modalContentFactory.modalContent.close("#innermodal");
        //    $location.path('/haft-aseman-abi/travel-agency/booking/domestic/domestic-flight-booking-service');
        //});
        $scope.progressbar.complete();
        modalContentFactory.modalContent.close("#innermodal");
        $location.path('/haft-aseman-abi/travel-agency/booking/domestic/domestic-flight-booking-service');
    };
    $scope.SearchHotel = function () {
        $location.path('/haft-aseman-abi/travel-agency/booking/domestic/domestic-hotels-booking-service');
    };
    //#endregion

    //#region Calc method
    $scope.C_Jalali_Gregorian = function (obj) {
        $scope.dp._J.b = false; $scope.dp._G.b = false;
        if (obj.id === '1') {
            obj.b = true;
            $('.hasDatepicker').each(function (t, i) {
                var r = $(i);
                r.datepicker('option', $.datepicker.regional['fa']);
            });
        }
        else {
            obj.b = true;
            $('.hasDatepicker').each(function (t, i) {
                var r = $(i);
                r.datepicker('option', $.datepicker.regional['']);
            });
        }
    };
    //#endregion

}]);