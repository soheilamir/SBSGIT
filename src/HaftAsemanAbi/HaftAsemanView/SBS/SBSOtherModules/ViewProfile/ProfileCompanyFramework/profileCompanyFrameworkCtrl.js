
'use strict'
angular.module('profileCompanyFrameworkModule').controller('ProfileCompanyFrameworkCtrl', ['$scope', '$rootScope', '$location', 'HotelPackageManagerFactory', 'flightPackageManagerFactory', 'orderManagerServices', 'orderServicesModel', function ($scope, $rootScope, $location, HotelPackageManagerFactory, flightPackageManagerFactory, orderManagerServices, orderServicesModel) {
    //#region Global variable
    /// signalr variable
    var hub = $.connection.onlineVisitorsHub;
    $scope.Usercount = 0;
    ////////////////////////
    $scope.flightPackageItem = {}, $scope.hotelPackageItem = {};
    $scope.flightList = flightPackageManagerFactory.objFlightPackage.SendListPackage(), $scope.lstFlightLength = $scope.flightList.length;
    $scope.hotelList = HotelPackageManagerFactory.objHotelPackage.SendListPackage(), $scope.lstHotelLength = $scope.hotelList.length;
    $scope.orderList = orderManagerServices.objOrderManager.SendListPackage();
    $scope.$on('lstflight', function (e, data) {
        angular.forEach(data.flightlist, function (item, index) {
            item.hidden = true;
            item.status = "در انتظار بررسی";
        });
        $scope.orderEdited = false;
        $scope.flightList = data.flightlist;
        $scope.lstFlightLength = data.flightlist.length;
    });
    $scope.$on('ClearFlightList', function (e, data) {
        $scope.flightList = data.flightlist;
        $scope.lstFlightLength = data.flightlist.length;
    });
    $scope.$on('lsthotel', function (e, data) {
        angular.forEach(data.hotellist, function (item, index) {
            item.hidden = true;
            item.selected = false;
            item.status = "در انتظار بررسی";
        });
        $scope.orderEdited = false;
        $scope.hotelList = data.hotellist;
        $scope.lstHotelLength = data.hotellist.length;
    });
    $scope.$on('ClearHotelList', function (e, data) {
        $scope.hotelList = data.hotellist;
        $scope.lstHotelLength = data.hotellist.length;
    });
    $scope.$on('order-f-edited', function (e, data) {
        $scope.orderEdited = data.val;
        $scope.flightPackageItem = data.flightPackageItem;
    });
    $scope.$on('order-h-edited', function (e, data) {
        $scope.orderEdited = data.val;
        $scope.hotelPackageItem = data.hotelPackageItem;
    });
    $scope.$on('sendOrder', function (e, data) {
        $scope.orderItem = data.order;
        $scope.addPackageInOrder = data.val;
    });
    $scope.$on('delete-order-item', function (e, data) {
        angular.forEach($scope.RunServicesMenuListItem.item, function (itemMenu, index) {
            if (itemMenu.orderId === data.orderId) {
                $scope.RunServicesMenuListItem.item.splice(index, 1);
                if ($scope.RunServicesMenuListItem.item.length > 0) {
                    $location.path('/sbs/profile/sbs-services/' + $scope.RunServicesMenuListItem.item[0].orderId + '/sbs-running-services');
                    $scope.OtherActiveMenu($scope.RunServicesMenuListItem.item[0], $scope.RunServicesMenuListItem.n);
                }
                else {
                    $location.path('/sbs/profile/sbs-services/sbs-airplane-service');
                    $scope.OtherActiveMenu($scope.ServicesMenuListItem.item[0], $scope.ServicesMenuListItem.n);
                    $scope.showRunningServices = false;
                }
            };
        });
    });
    var location = {
        selected: false,
    }, currency = {
        selected: false,
    }, feedback = {
        selected: false,
    };
    $scope.menuObj = {
        show: true,
        active: true,
    }
    $scope.menuHomeItemList = {
        item: [/// get data menu items from json file or api  
        { name: "اطلاعات کلی", title: "اطلاعات کلی", href: '#/sbs/company-profile/company-page' },
        { name: "درخواست اعتبار", title: "درخواست اعتبار", href: '#/sbs/company-profile/company/info/credit' },
        ],
        n: "h",
    };
    $scope.ServicesMenuListItem = {
        item: [/// get data menu items from json file or api  
        { name: "هواپیما", ico: "sbs-ico-airplane", href: '#/sbs/profile/sbs-services/sbs-airplane-service' },
        { name: "هتل", ico: "sbs-ico-bed", href: '#/sbs/profile/sbs-services/sbs-hotel-service' },
        { name: "ترانسفر", ico: "sbs-ico-transfer", href: '#' },
        { name: "تشریفات", ico: "sbs-ico-car", href: '#' },
        { name: "بیمه نامه", ico: "sbs-ico-document-fill", href: '#' },
        ],
        n: "s",
    };
    // get from API Ajax
    $scope.RunServicesMenuListItem = {
        title: "درخواست شماره",
        lstico: ["sbs-ico-airplane", "sbs-ico-bed"],
        item: [/// get data menu items from json file or api  
        ///* sample --->*/ { name: "درخواست شماره 1", ico: ["sbs-ico-airplane"], href: '#/sbs/profile/sbs-services/1/sbs-running-services' },
        ],
        n: "rs",
    };
    $scope.activedMenu = $scope.menuHomeItemList.item[0];
    $scope.activedServicesMenu = null;
    $scope.activedRunServicesMenu = null;
    $scope.$on('active-menu', function () {
        $scope.menuObj.show = $scope.menuObj.show;
        $scope.menuObj.active = $scope.menuObj.active;
    });
    $scope.$on('unActive-menu', function (e, data) {
        $scope.menuObj.show = data.active;
        $scope.menuObj.active = data.active;
    });
    $scope.$on("documentClicked", _close);
    $scope.$on("escapePressed", _close);
    $scope.$on('changeposition', function (e, data) {
        if (data.val === '_S') {
            $scope.moveTriggerService = true;
            $scope.otherMoveRunningTrigger = false;
        }
        else if (data.val === 'R_S') {
            $scope.moveTriggerService = false;
            $scope.otherMoveRunningTrigger = true;
        }

    });
    $scope.lastSelectedHeaderItem = null;
    $scope.locationInfo = $rootScope.baseData.locationInfo;
    $scope.currencyInfo = $rootScope.baseData.currencyInfo;
    $scope.headerItemList = [location, currency, feedback];
    //#endregion
    //#region Event content
    /////////// top menu content
    $scope.toggelMenu = function () {
        $scope.menuObj.show = !$scope.menuObj.show;
        $scope.menuObj.active = !$scope.menuObj.active;
    };
    /////////// other menu content
    $scope.OtherActiveMenu = function (item, name) {
        if (name === "h") {
            $scope.activedMenu = item;
            // change location of bttn
            $scope.moveTriggerService = false;
            $scope.otherMoveRunningTrigger = false;
        }
        else if (name === "s") {
            $scope.activedServicesMenu = item;
            // change location of bttn
            $scope.moveTriggerService = true;
            $scope.otherMoveRunningTrigger = false;
        }
        else {
            $scope.activedRunServicesMenu = item;
            // change location of bttn
            $scope.moveTriggerService = false;
            $scope.otherMoveRunningTrigger = true;
        }
    };
    $scope.IsSelectOtherMenu = function (item, name) {
        if (name === "h")
            return item === $scope.activedMenu;
        else if (name === "s")
            return item === $scope.activedServicesMenu;
        else
            return item === $scope.activedRunServicesMenu;
    };
    function _close() {
        $scope.$apply(function () {
            angular.forEach($scope.headerItemList, function (item, index) {
                item.selected = false;
                $scope.lastSelectedHeaderItem = null;
            });
        });
    };
    $scope.ISActiveHeaderItem = function (itemContent, e) {
        if ($scope.lastSelectedHeaderItem == null) {
            $scope.lastSelectedHeaderItem = itemContent;
            itemContent.selected = true;
        }
        else {
            if (itemContent === $scope.lastSelectedHeaderItem) {
                itemContent.selected = false;
                $scope.lastSelectedHeaderItem = null;
            }
            else {
                $scope.lastSelectedHeaderItem.selected = false;
                itemContent.selected = true;
                $scope.lastSelectedHeaderItem = itemContent;
            }
        }
        e.stopPropagation();
    };
    //////////////// ordering event content ///////////////
    $scope.FinalReg = function () {
        $scope.newOrderModel = new orderServicesModel();
        if ($scope.flightList.length > 0)
            $scope.newOrderModel.lstFlightPackage = $scope.flightList;
        if ($scope.hotelList.length > 0)
            $scope.newOrderModel.lstHotelPackage = $scope.hotelList;
        orderManagerServices.objOrderManager.SaveOrder($scope.newOrderModel);
        $scope.orderList = orderManagerServices.objOrderManager.SendListPackage();
        angular.forEach($scope.orderList, function (item, index) {
            var lstIco = [], obj = {}; if (index === 0) $scope.RunServicesMenuListItem.item = [];
            if (item.lstFlightPackage.length > 0)
                lstIco.push($scope.RunServicesMenuListItem.lstico[0]);
            if (item.lstHotelPackage.length > 0)
                lstIco.push($scope.RunServicesMenuListItem.lstico[1]);
            obj = { orderId: item.id, name: $scope.RunServicesMenuListItem.title + " " + (index + 1), ico: lstIco, href: '#/sbs/profile/sbs-services/' + item.id + '/sbs-running-services', pathLocation: '/sbs/profile/sbs-services/' + item.id + '/sbs-running-services' };
            $scope.RunServicesMenuListItem.item.push(obj);
        });
        if ($scope.flightList.length > 0)
            $rootScope.$broadcast('clear-f-services', { clear: true });
        if ($scope.hotelList.length > 0)
            $rootScope.$broadcast('clear-h-services', { clear: true });
        $location.path($scope.RunServicesMenuListItem.item[$scope.RunServicesMenuListItem.item.length - 1].pathLocation);

    };
    $scope.EditOrderItem = function () {
        orderManagerServices.objOrderManager.UpdateOrderItems($scope.flightPackageItem, $scope.hotelPackageItem);
        if ($scope.flightPackageItem.orderId != null) {
            $location.path('/sbs/profile/sbs-services/' + $scope.flightPackageItem.orderId + '/sbs-running-services');
            $scope.OtherActiveMenu($scope.RunServicesMenuListItem.item[0], $scope.RunServicesMenuListItem.n);
        }
        else {
            $location.path('/sbs/profile/sbs-services/' + $scope.hotelPackageItem.orderId + '/sbs-running-services');
            $scope.OtherActiveMenu($scope.RunServicesMenuListItem.item[0], $scope.RunServicesMenuListItem.n);
        }
        $scope.orderEdited = false;
    };
    $scope.AddPackageInOrderItem = function () {
        orderManagerServices.objOrderManager.AddPackageToOrderList($scope.orderItem, $scope.flightList, $scope.hotelList);
        $scope.addPackageInOrder = false;
        $location.path('/sbs/profile/sbs-services/' + $scope.orderItem.id + '/sbs-running-services');

    };
    //////////////// ordering event content ///////////////
    //#endregion
    //#region signalr client
    hub.client.usersConnected = function (numUsers) { //this instanciate the usersConnected function receiving the numUsers parameter which is the number of users connected
        $scope.Usercount = numUsers; //show the number of users connected inside a div
        $scope.$apply();
    };
    $.connection.hub.start().done(function () {
    });
    //#endregion

}]);