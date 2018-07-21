
'use strict'
angular.module('SearchFlightModule').controller('SearchFlightCtrl', ['$scope', '$rootScope', '$routeParams', '$location', '$http', '$interval', 'ngProgressFactory', 'allContentInModal', 'modalContentFactory', 'internalFlightModelFactory', 'FlightServiceFactory',
    function ($scope, $rootScope, $routeParams, $location, $http, $interval, ngProgressFactory, allContentInModal, modalContentFactory, internalFlightModelFactory, FlightServiceFactory) {
    //#region variable
    $scope.progressbar = ngProgressFactory.createInstance(); $scope.progressbar.setColor("#3F92D6");///// set progress bar config
    $scope.dp = { _J: { id: '1', b: false, }, _G: { id: '2', b: false, }, };
    $scope.searchFlight = new internalFlightModelFactory();
    $scope.baseData = $rootScope.baseDefaultSearchData;
    $scope.dataCitys = $scope.baseData.lstCitys;
    //#endregion
    //#region Calc method
    $scope.SearchInternalFlight = function (source, destination) {
        modalContentFactory.modalContent.open(allContentInModal.allContent.CreateInnerModal, allContentInModal.allContent.FlightBooking);
        $scope.progressbar.setColor("#6C1B78");
        $scope.progressbar.start();
        $scope.searchFlight.Source = source;
        $scope.searchFlight.Destination = destination;
        $rootScope.DomesticResultTickets.searchFlightItem = $scope.searchFlight;
        if ($scope.searchFlight.ReturningDate == null)
            $scope.searchFlight.ReturningDate = "0/0/0";
        FlightServiceFactory.flightfactory.InternalFlight($scope.searchFlight).then(function (response) {
            if (!angular.isUndefined(response.data.Departing))
                if (response.data.Departing.length > 0)
                    angular.copy(response.data.Departing, $rootScope.DomesticResultTickets.Departing);
            if (!angular.isUndefined(response.data.Returning)) {
                if (response.data.Returning.length > 0)
                    angular.copy(response.data.Returning, $rootScope.DomesticResultTickets.Returning);
            }
            $scope.progressbar.complete();
            modalContentFactory.modalContent.close("#innermodal");
            $location.path('/haft-aseman-abi/CMS-Console/travel-agency/booking/domestic/domestic-flight-booking-service');
        });
    };
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