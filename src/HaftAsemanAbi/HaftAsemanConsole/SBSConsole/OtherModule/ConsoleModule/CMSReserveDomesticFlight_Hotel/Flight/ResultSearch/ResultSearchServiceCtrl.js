
'use strict'
angular.module('ResultSearchFlightModule').controller('ResultSearchFlightServiceCtrl', ['$scope', '$rootScope', '$routeParams', '$location', '$http', '$interval', 'ngProgressFactory', 'allContentInModal', 'modalContentFactory', 'internalFlightModelFactory', 'FlightServiceFactory', 'DomesticFlightBookingServiceModelFactory', 'DomesticFlightBookingServiceFactory', '$window',
    function ($scope, $rootScope, $routeParams, $location, $http, $interval, ngProgressFactory, allContentInModal, modalContentFactory, internalFlightModelFactory, FlightServiceFactory, DomesticFlightBookingServiceModelFactory, DomesticFlightBookingServiceFactory, $window) {
        //#region set default & variable
        $scope.progressbar = ngProgressFactory.createInstance(); $scope.progressbar.setColor("#3F92D6");///// set progress bar config
        $scope.dp = { _J: { id: '1', b: false, }, _G: { id: '2', b: false, }, };
        $scope.searchFlight = new internalFlightModelFactory();
        $scope.baseData = $rootScope.baseDefaultSearchData;
        $scope.dataCitys = $scope.baseData.lstCitys;
        $scope.totalPrice = 0;
        $scope.Departing = {
            lst: [],
            item: new DomesticFlightBookingServiceModelFactory(),
            selectedItem: null,
            selected_c_f: null,
        }
        $scope.Returning = {
            lst: [],
            item: new DomesticFlightBookingServiceModelFactory(),
            selectedItem: null,
            selected_c_f: null,
        };
        angular.forEach($rootScope.DomesticResultTickets.Departing, function (d_item, index) {
            $scope.Departing.item = d_item;
            $scope.Departing.lst.push($scope.Departing.item);
        });
        angular.forEach($rootScope.DomesticResultTickets.Returning, function (r_item, index) {
            $scope.Returning.item = r_item;
            $scope.Returning.lst.push($scope.Returning.item);
        });
        //#endregion
        //#region Method
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
                angular.forEach($rootScope.DomesticResultTickets.Departing, function (d_item, index) {
                    $scope.Departing.item = d_item;
                    $scope.Departing.lst.push($scope.Departing.item);
                });
                angular.forEach($rootScope.DomesticResultTickets.Returning, function (r_item, index) {
                    $scope.Returning.item = r_item;
                    $scope.Returning.lst.push($scope.Returning.item);
                });
                //$location.path('/haft-aseman-abi/CMS-Console/travel-agency/booking/domestic/domestic-flight-booking-service');
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
        this.ChangeFlight = function (val) {
            $scope.Show_searchFlightContent = val;
        }
        $scope.DepartingSelectedFlight = function (departing, classFareListItem) {
            DomesticFlightBookingServiceFactory.dfbsFactory.UnSelectedItem($scope.Departing.lst);
            departing.selected = true;
            $scope.Departing.selectedItem = departing;
            classFareListItem.selected = true;
            $scope.Departing.selected_c_f = classFareListItem;
            // sum price section
            if ($scope.Departing.selected_c_f != null)
                $scope.totalPrice = parseInt($scope.Departing.selected_c_f.AdultFare);
            if ($scope.Departing.selected_c_f != null && $scope.Returning.selected_c_f != null)
                $scope.totalPrice = parseInt($scope.Departing.selected_c_f.AdultFare) + parseInt($scope.Returning.selected_c_f.AdultFare);
        };
        $scope.ReturningSelectedFlight = function (returning, classFareListItem) {
            DomesticFlightBookingServiceFactory.dfbsFactory.UnSelectedItem($scope.Returning.lst);
            returning.selected = true;
            $scope.Returning.selectedItem = returning;
            classFareListItem.selected = true;
            $scope.Returning.selected_c_f = classFareListItem;
            // sum price section
            if ($scope.Departing.selected_c_f != null)
                $scope.totalPrice = parseInt($scope.Departing.selected_c_f.AdultFare);
            if ($scope.Departing.selected_c_f != null && $scope.Returning.selected_c_f != null)
                $scope.totalPrice = parseInt($scope.Departing.selected_c_f.AdultFare) + parseInt($scope.Returning.selected_c_f.AdultFare);
        };
        $scope.SubmitFlightSelected = function () {
            var URI = "";
            if ($scope.Returning.selectedItem == null) {
                URI = "/haft-aseman-abi/CMS-Console/reserve-domestic-flight/" + $rootScope.DomesticResultTickets.searchFlightItem.Source.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CityName + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CharCode + "/" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CityName + '_' + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CharCode + "/"
                + $rootScope.DomesticResultTickets.searchFlightItem.DepartingDate.replace(/\//g, '_') + "/"
                + $rootScope.DomesticResultTickets.searchFlightItem.Adult.Number + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Child.Number + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Infant.Number + "/"

                + $scope.Departing.selectedItem.AirLine + "/"
                + $scope.Departing.selectedItem.Name.replace(/\ /g, '_') + "/"
                + $scope.Departing.selectedItem.PlaneType + "/"
                + $scope.Departing.selectedItem.FlightNo + "/"
                + $scope.Departing.selectedItem.DepartureTime.replace(/\:/g, '_') + "/"
                + $scope.Departing.selectedItem.ArrivalTime.replace(/\:/g, '_') + "/"
                + $scope.Departing.selected_c_f.FlightClass + "/"
                + $scope.Departing.selected_c_f.AdultFare + "/"
                + $scope.Departing.selected_c_f.ChildFare + "/"
                + $scope.Departing.selected_c_f.InfantFare + "/"
                + $scope.Departing.selected_c_f.AirlineClassPathFeeId;
            }
            else {

                URI = "/haft-aseman-abi/CMS-Console/reserve-domestic-flight/" + $rootScope.DomesticResultTickets.searchFlightItem.Source.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CityName + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CharCode + "/" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CityName + '_' + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CharCode + "/"
               + $rootScope.DomesticResultTickets.searchFlightItem.DepartingDate.replace(/\//g, '_') + "/" + $rootScope.DomesticResultTickets.searchFlightItem.ReturningDate.replace(/\//g, '_') + "/"
               + $rootScope.DomesticResultTickets.searchFlightItem.Adult.Number + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Child.Number + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Infant.Number + "/"

               + $scope.Departing.selectedItem.AirLine + "/"
               + $scope.Departing.selectedItem.Name.replace(/\ /g, '_') + "/"
               + $scope.Departing.selectedItem.PlaneType + "/"
               + $scope.Departing.selectedItem.FlightNo + "/"
               + $scope.Departing.selectedItem.DepartureTime.replace(/\:/g, '_') + "/"
               + $scope.Departing.selectedItem.ArrivalTime.replace(/\:/g, '_') + "/"
               + $scope.Departing.selected_c_f.FlightClass + "/"
               + $scope.Departing.selected_c_f.AdultFare + "/"
               + $scope.Departing.selected_c_f.ChildFare + "/"
               + $scope.Departing.selected_c_f.InfantFare + "/"
               + $scope.Departing.selected_c_f.AirlineClassPathFeeId + "/"

               + $scope.Returning.selectedItem.AirLine + "/"
               + $scope.Returning.selectedItem.Name.replace(/\//g, '_') + "/"
               + $scope.Returning.selectedItem.PlaneType + "/"
               + $scope.Returning.selectedItem.FlightNo + "/"
               + $scope.Returning.selectedItem.DepartureTime.replace(/\:/g, '_') + "/"
               + $scope.Returning.selectedItem.ArrivalTime.replace(/\:/g, '_') + "/"
               + $scope.Returning.selected_c_f.FlightClass + "/"
               + $scope.Returning.selected_c_f.AdultFare + "/"
               + $scope.Returning.selected_c_f.ChildFare + "/"
               + $scope.Returning.selected_c_f.InfantFare + "/"
               + $scope.Returning.selected_c_f.AirlineClassPathFeeId;

            }
            $location.path(URI);
        };
        $scope.CancelFlightSelected = function () {
            DomesticFlightBookingServiceFactory.dfbsFactory.UnSelectedItem($scope.Departing.lst);
            $scope.Departing.selectedItem = null;
            $scope.Departing.selected_c_f = null;
            DomesticFlightBookingServiceFactory.dfbsFactory.UnSelectedItem($scope.Returning.lst);
            $scope.Returning.selectedItem = null;
            $scope.Returning.selected_c_f = null;
            $scope.totalPrice = 0;
        };
        //#endregion
    }]).filter('custFilterTicket', function () {
        return function (items, airline) {
            var filtered = [];
            if (angular.isUndefined(airline))
                return items;
            else
                for (var i = 0; i < items.length; i++) {
                    if (airline == items[i].AirLine) {
                        filtered.push(items[i]);
                    }
                }
            return filtered;
        };
    });