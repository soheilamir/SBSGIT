
'use strict'
angular.module('flightBookingServiceModule').controller('DomesticFlightCtrl', ['$scope', '$rootScope', 'DomesticFlightBookingServiceModelFactory', 'DomesticFlightBookingServiceFactory', 'DomesticHotelBookingServiceModelFactory', 'DomesticHotelBookingServiceFactory', 'localStorageService', '$window', function ($scope, $rootScope, DomesticFlightBookingServiceModelFactory, DomesticFlightBookingServiceFactory, DomesticHotelBookingServiceModelFactory, DomesticHotelBookingServiceFactory, localStorageService, $window) {

    //#region Hotel Section

    //#region set default & variable Hotel
    $scope.Math = window.Math;
    $scope.HotelModel = new DomesticHotelBookingServiceModelFactory();
    $scope.LsthotelData = [];
    $scope.LsthotelData = DomesticHotelBookingServiceFactory.HotelData.FillHotel();
    angular.forEach($scope.LsthotelData, function (itemHotel, index) {
        itemHotel.minPrice = Math.min.apply(Math, itemHotel.HotelRoomS.map(function (item) { return item.ActiveNightPriceItem.Price; }))
    });
    //#endregion

    //#endregion

    //#region Flight Section

    //#region set default & variable
    $scope.selectedHotel_1 = false;
    $scope.selectedHotel_2 = false;
    $scope.selectedHotel_3 = false;
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
            URI = "userprofile.html#/sbs/profile/reserve-domestic-flight/" + $rootScope.DomesticResultTickets.searchFlightItem.Source.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CityName + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CharCode + "/" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CityName + '_' + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CharCode + "/"
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

            URI = "userprofile.html#/sbs/profile/reserve-domestic-flight/" + $rootScope.DomesticResultTickets.searchFlightItem.Source.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CityName + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Source.CharCode + "/" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.Id + "_" + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CityName + '_' + $rootScope.DomesticResultTickets.searchFlightItem.Destination.CharCode + "/"
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
        $window.location.href = URI;
    };
    $scope.CancelFlightSelected = function () {
        DomesticFlightBookingServiceFactory.dfbsFactory.UnSelectedItem($scope.Departing.lst);
        $scope.Departing.selectedItem = null;
        $scope.Departing.selected_c_f = null;
        DomesticFlightBookingServiceFactory.dfbsFactory.UnSelectedItem($scope.Returning.lst);
        $scope.Returning.selectedItem = null;
        $scope.Returning.selected_c_f = null;
        $scope.totalPrice = 0;
        localStorageService.remove('ReqHotel');
    };

    //#endregion

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