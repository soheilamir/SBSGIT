
'use strict'
angular.module('RunningServicesModule').controller('runningServicesCtrl', ['$scope', '$rootScope', '$routeParams', '$location', 'orderManagerServices', function ($scope, $rootScope, $routeParams, $location, orderManagerServices) {
    //#region Global variable
    orderManagerServices.objOrderManager.GetOrderListItem($routeParams.orderId).then(function (data) {
        if (data.lstFlightPackage.length > 0)
            $scope.lstFlightPackage = data.lstFlightPackage;
        if (data.lstHotelPackage.length > 0)
            $scope.lstHotelPackage = data.lstHotelPackage;
    });
    //#endregion
    //#region $broadcast content
    $rootScope.$broadcast('changeposition', { val: 'R_S' });
    //#endregion
    //#region Event content
    $scope.AddFlightInOrder = function () {
        orderManagerServices.objOrderManager.GetOrderListItem($routeParams.orderId).then(function (data) {
            if (!data.addedFlightItem) {
                data.addedFlightItem = true;
                $location.path('/sbs/profile/sbs-services/sbs-airplane-service');
                $rootScope.$broadcast('sendOrder', { val: true, order: data });
            };
        });
    };
    $scope.AddHotelInOrder = function () {
        orderManagerServices.objOrderManager.GetOrderListItem($routeParams.orderId).then(function (data) {
            if (!data.addedHotelItem) {
                data.addedHotelItem = true;
                $location.path('/sbs/profile/sbs-services/sbs-hotel-service');
                $rootScope.$broadcast('sendOrder', { val: true, order: data });
            }
        });
    };
    $scope.DeleteOrderOfList = function () {
        orderManagerServices.objOrderManager.GetOrderListItem($routeParams.orderId).then(function (data) {
            orderManagerServices.objOrderManager.DeleteOrder(data.id);
            $rootScope.$broadcast('delete-order-item', { orderId: data.id });
        });
    };
    this.EditFlightInOrder = function (orderFlightItem) {
        orderFlightItem.orderId = $routeParams.orderId;
        orderFlightItem.hidden = false;
        $rootScope.operation.orderItemEdited = true;
        $rootScope.$broadcast('EditOrderFlight', { flightPackage: orderFlightItem });
        $location.path('/sbs/profile/sbs-services/sbs-airplane-service');
    };
    this.EditHotelInOrder = function (orderHotelItem) {
        orderHotelItem.orderId = $routeParams.orderId;
        orderHotelItem.hidden = false;
        $rootScope.operation.orderItemEdited = true;
        $rootScope.$broadcast('EditOrderHotel', { hotelPackage: orderHotelItem });
        $location.path('/sbs/profile/sbs-services/sbs-hotel-service');
    };
    this.DeleteHotelPackageInOrder = function (hotelIndex) {
        orderManagerServices.objOrderManager.DeleteHotelInOrder($routeParams.orderId, hotelIndex);
    };
    this.DeleteFlightPackageInOrder = function (flightIndex) {
        orderManagerServices.objOrderManager.DeleteFlightInOrder($routeParams.orderId, flightIndex);
    };
    //#endregion
}]);