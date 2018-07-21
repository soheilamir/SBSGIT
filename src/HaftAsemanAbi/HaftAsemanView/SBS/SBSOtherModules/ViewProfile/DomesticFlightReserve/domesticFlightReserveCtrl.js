
'use strict'
angular.module('domesticFlightReserveModule').controller('domesticFlightReserveCtrl', ['$scope', '$rootScope', '$routeParams', '$location', 'AllInfoDomesticFlightModelFactory', 'FlightPassengerModelFactory', 'ManageFlightPassengerFactory', 'ngProgressFactory', 'allContentInModal', 'modalContentFactory', 'ManageDomesticFlightReserveProcessFactory', 'ReserveFlightModelFactory', 'localStorageService', function ($scope, $rootScope, $routeParams, $location, AllInfoDomesticFlightModelFactory, FlightPassengerModelFactory, ManageFlightPassengerFactory, ngProgressFactory, allContentInModal, modalContentFactory, ManageDomesticFlightReserveProcessFactory, ReserveFlightModelFactory, localStorageService) {

    //#region Global variable
    $scope.Section = {
        _1: true,
        _2: false
    }
    $scope.progressbar = ngProgressFactory.createInstance(); $scope.progressbar.setColor("#3F92D6");///// set progress bar config
    $scope.lstAdult = ManageFlightPassengerFactory.passengerFactory.lstAdult;
    $scope.lstChild = ManageFlightPassengerFactory.passengerFactory.lstChild;
    $scope.lstInfant = ManageFlightPassengerFactory.passengerFactory.lstInfant;
    $scope.Passenger = new FlightPassengerModelFactory();
    $scope.DomesticFlightInfo = new AllInfoDomesticFlightModelFactory();

    $scope.DomesticFlightInfo.Source = $routeParams.source.split('_')[1] + " ( " + $routeParams.source.split('_')[2] + " ) ";
    $scope.DomesticFlightInfo.Destination = $routeParams.destination.split('_')[1] + " ( " + $routeParams.destination.split('_')[2] + " ) ";
    $scope.DomesticFlightInfo.DepartingDate = $routeParams.departingDate.replace(/\_/g, '/');
    if (!angular.isUndefined($routeParams.returningDate))
        $scope.DomesticFlightInfo.ReturningDate = $routeParams.returningDate.replace(/\_/g, '/');
    $scope.DomesticFlightInfo.Adult = $routeParams.numberPassenger.split('_')[0];
    $scope.DomesticFlightInfo.Child = $routeParams.numberPassenger.split('_')[1];
    $scope.DomesticFlightInfo.Infant = $routeParams.numberPassenger.split('_')[2];

    $scope.DomesticFlightInfo.D_AirLine = $routeParams.d_AirLine;
    $scope.DomesticFlightInfo.D_Name = $routeParams.d_Name.replace(/\_/g, ' ');
    $scope.DomesticFlightInfo.D_PlaneType = $routeParams.d_PlaneType;
    $scope.DomesticFlightInfo.D_FlightNo = $routeParams.d_FlightNo;
    $scope.DomesticFlightInfo.D_DepartureTime = $routeParams.d_DepartureTime.replace(/\_/g, ':');
    $scope.DomesticFlightInfo.D_ArrivalTime = $routeParams.d_ArrivalTime.replace(/\_/g, ':');
    $scope.DomesticFlightInfo.D_FlightClass = $routeParams.d_FlightClass;
    $scope.DomesticFlightInfo.D_AdultFare = $routeParams.d_AdultFare;
    $scope.DomesticFlightInfo.D_ChildFare = $routeParams.d_ChildFare;
    $scope.DomesticFlightInfo.D_InfantFare = $routeParams.d_InfantFare;

    $scope.DomesticFlightInfo.D_AirlineClassPathFeeId = $routeParams.d_AirlineClassPathFeeId;

    $scope.DomesticFlightInfo.D_LogoImg = "http://rrfco.com/AirlinesLogo/" + $routeParams.d_AirLine + ".png";

    if (!angular.isUndefined($routeParams.returningDate)) {
        $scope.DomesticFlightInfo.R_AirLine = $routeParams.r_AirLine;
        $scope.DomesticFlightInfo.R_Name = $routeParams.r_Name.replace(/\_/g, ' ');
        $scope.DomesticFlightInfo.R_PlaneType = $routeParams.r_PlaneType;
        $scope.DomesticFlightInfo.R_FlightNo = $routeParams.r_FlightNo;
        $scope.DomesticFlightInfo.R_DepartureTime = $routeParams.r_DepartureTime.replace(/\_/g, ':');
        $scope.DomesticFlightInfo.R_ArrivalTime = $routeParams.r_ArrivalTime.replace(/\_/g, ':');
        $scope.DomesticFlightInfo.R_FlightClass = $routeParams.r_FlightClass;
        $scope.DomesticFlightInfo.R_AdultFare = $routeParams.r_AdultFare;
        $scope.DomesticFlightInfo.R_ChildFare = $routeParams.r_ChildFare;
        $scope.DomesticFlightInfo.R_InfantFare = $routeParams.r_InfantFare;

        $scope.DomesticFlightInfo.R_AirlineClassPathFeeId = $routeParams.r_AirlineClassPathFeeId;

        $scope.DomesticFlightInfo.R_LogoImg = "http://rrfco.com/AirlinesLogo/" + $routeParams.r_AirLine + ".png";
    }
    //#endregion

    //#region Set item
    $rootScope.$broadcast('unActive-menu', { active: false });
    if ($scope.DomesticFlightInfo.Adult > 0)
        ManageFlightPassengerFactory.passengerFactory.AddPassengerToList('adult', $scope.DomesticFlightInfo.Adult);
    if ($scope.DomesticFlightInfo.Child > 0)
        ManageFlightPassengerFactory.passengerFactory.AddPassengerToList('child', $scope.DomesticFlightInfo.Child);
    if ($scope.DomesticFlightInfo.Infant > 0)
        ManageFlightPassengerFactory.passengerFactory.AddPassengerToList('infant', $scope.DomesticFlightInfo.Infant);
    //#endregion


    //////////////////////////////////////////// اطلاعات زیر به صورت فیک است

    localStorageService.set('ticketsDataFlag', { ticketsData: false });
    localStorageService.set('SendDataTickets', { DomesticFlightInfo: $scope.DomesticFlightInfo });
    $scope.SetHotel = localStorageService.get('ReqHotel');

    ///////////////////////////// End

    //#region Event content

    $scope.AddAdult = function () {
        ManageFlightPassengerFactory.passengerFactory.AddPassengerToList('adult', 0);
    };
    $scope.AddChild = function () {
        ManageFlightPassengerFactory.passengerFactory.AddPassengerToList('child', 0);
    };
    $scope.AddInfant = function () {
        ManageFlightPassengerFactory.passengerFactory.AddPassengerToList('infant', 0);
    };
    $scope.FlightReserve = function () {

        // set reserve obj
        $scope.objReserveFlight = new ReserveFlightModelFactory();
        $scope.objReserveFlight.Source = { Id: $routeParams.source.split('_')[0], CityName: $routeParams.source.split('_')[1], CharCode: $routeParams.source.split('_')[2] };
        $scope.objReserveFlight.Target = { Id: $routeParams.destination.split('_')[0], CityName: $routeParams.destination.split('_')[1], CharCode: $routeParams.destination.split('_')[2] };

        $scope.objReserveFlight.D_Airline = $scope.DomesticFlightInfo.D_AirLine;
        $scope.objReserveFlight.D_FlightClass = $scope.DomesticFlightInfo.D_FlightClass;
        $scope.objReserveFlight.D_FlightNo = $scope.DomesticFlightInfo.D_FlightNo;
        $scope.objReserveFlight.D_AirlineClassPathFeeId = $scope.DomesticFlightInfo.D_AirlineClassPathFeeId;
        $scope.objReserveFlight.D_Day = $routeParams.departingDate.split('_')[2];
        $scope.objReserveFlight.D_Month = $routeParams.departingDate.split('_')[1];
        $scope.objReserveFlight.D_Date = $routeParams.departingDate.replace(/\_/g, '/');
        if ($scope.DomesticFlightInfo.R_AirLine != null) {
            $scope.objReserveFlight.R_Airline = $scope.DomesticFlightInfo.R_AirLine;
            $scope.objReserveFlight.R_FlightClass = $scope.DomesticFlightInfo.R_FlightClass;
            $scope.objReserveFlight.R_FlightNo = $scope.DomesticFlightInfo.R_FlightNo;
            $scope.objReserveFlight.R_AirlineClassPathFeeId = $scope.DomesticFlightInfo.R_AirlineClassPathFeeId;
            $scope.objReserveFlight.R_Day = $routeParams.returningDate.split('_')[2];
            $scope.objReserveFlight.R_Month = $routeParams.returningDate.split('_')[1];
            $scope.objReserveFlight.R_Date = $routeParams.returningDate.replace(/\_/g, '/');
        }

        $scope.objReserveFlight.No = $scope.lstAdult.length + $scope.lstChild.length + $scope.lstInfant.length;

        $scope.objReserveFlight.lstAdult = $scope.lstAdult;
        $scope.objReserveFlight.lstChild = $scope.lstChild;
        $scope.objReserveFlight.lstInfant = $scope.lstInfant;
        ///////// end section
        modalContentFactory.modalContent.open(allContentInModal.allContent.OtherModal, allContentInModal.allContent.WatingFor);
        $rootScope.MsgWating = {
            text: "لطفا منتظر بمانید، اطلاعات شما در حال بررسی است"
        }
        $scope.progressbar.setColor("#6C1B78");
        $scope.progressbar.start();
        ManageFlightPassengerFactory.passengerFactory.SavePassengerList($scope.objReserveFlight.lstAdult, $scope.objReserveFlight.lstChild, $scope.objReserveFlight.lstInfant).then(function (result) {
            $scope.progressbar.complete();
            modalContentFactory.modalContent.close("#othermodal");

            $scope.objReserveFlight.lstAdult = result.data.lstAdult;
            $scope.objReserveFlight.lstChild = result.data.lstChild;
            $scope.objReserveFlight.lstInfant = result.data.lstInfant;

            $scope.Section._1 = false;
            $scope.Section._2 = true;
        });

    };
    this.BackToFillPassengerFlight = function (one, two) {
        $scope.Section._1 = one;
        $scope.Section._2 = two;
    }
    this.FlightReserve = function () {

        modalContentFactory.modalContent.open(allContentInModal.allContent.OtherModal, allContentInModal.allContent.WatingFor);
        $rootScope.MsgWating = {
            text: "لطفا منتظر بمانید، سیسنم در حال صدور بلیط است"
        }
        $scope.progressbar.setColor("#6C1B78");
        $scope.progressbar.start();
        ManageDomesticFlightReserveProcessFactory.DomesticFlightReserveProcessFactory.ReserveFlight($scope.objReserveFlight).then(function (result) {
            $scope.progressbar.complete();
            modalContentFactory.modalContent.close("#othermodal");
            //$location.path('/sbs/profile/reserve-domestic-flight/checkout-ticket/' + result.data.id);
        });
         //fill in rootScope for peyment
        $rootScope.baseData.objReserveFlight = $scope.objReserveFlight;
        $rootScope.baseData.DomesticFlightInfo = $scope.DomesticFlightInfo;
        $location.path('/sbs/profile/sbs-services/flight/request/payment');

        //////////////////////////////////////////// اطلاعات زیر به صورت فیک است

        //var Data = localStorageService.get('ticketsDataFlag');
        //if (Data.ticketsData) {
        //    $location.path('/sbs/profile/sbs-services/print/flight/flgiht-ticket');
        //}
        //else
        //    window.alert("درخواست شما در انتظار تایید مدیریت می باشد.");

        /////////////////////////////// End
    }
    //#endregion

}]);