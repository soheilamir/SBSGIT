
'use strict'
//#region Model Content
angular.module('AllServicesModule').factory('orderServicesModel', function () {
    var orderServicesModel = function (order) {
        var _order = this;
        if (!order) {
            _order.addedFlightItem = false;
            _order.addedHotelItem = false;
            _order.id = null;
            _order.UserItem = {};
            _order.CompanyItem = {};
            _order.OrderStatusItem = {};
            _order.SubmitDateTime = null;
            _order.CompletionDateTime = null;
            _order.lstFlightPackage = [];
            _order.lstHotelPackage = [];
        }
        else
            _order = order;
    };
    return orderServicesModel;
});
//#endregion
//#region manager Factory content
angular.module('AllServicesModule').factory('orderManagerServices', ['GeneratId', '$q', '$rootScope', 'flightPackageManagerFactory', 'HotelPackageManagerFactory', function (GeneratId, $q, $rootScope, flightPackageManagerFactory, HotelPackageManagerFactory) {
    var objOrderManager = {
        SaveOrder: function (orderModel) {
            var orderEntity = orderModel;
            if (orderEntity.id == null) {
                orderEntity.id = 'order-trackID' + GeneratId.G_randId();
                this.lstOrder.push(orderEntity);
            };
        },
        UpdateOrderItems: function (flightPackage, hotelPackage) {
            if (Object.keys(flightPackage).length > 0) {
                angular.forEach(this.lstOrder, function (orderItem, index) {
                    if (orderItem.id === flightPackage.orderId) {
                        angular.forEach(orderItem.lstFlightPackage, function (flightOrderItem, index) {
                            if (flightOrderItem.id === flightPackage.id) {
                                flightOrderItem = flightPackage;
                                $rootScope.operation.orderItemEdited = false;
                                flightOrderItem.selected = false;
                                $rootScope.$broadcast('clear-f-services', { clear: true });
                            };

                        });
                    };
                });
            }
            if (Object.keys(hotelPackage).length > 0) {
                angular.forEach(this.lstOrder, function (orderItem, index) {
                    if (orderItem.id === hotelPackage.orderId) {
                        angular.forEach(orderItem.lstHotelPackage, function (hotelOrderItem, index) {
                            if (hotelOrderItem.id === hotelPackage.id) {
                                angular.copy(hotelPackage, hotelOrderItem);
                                $rootScope.operation.orderItemEdited = false;
                                hotelOrderItem.selected = false;
                                $rootScope.$broadcast('clear-h-services', { clear: true });
                            };
                        });
                    };
                });
            };
        },
        AddPackageToOrderList: function (orderItem, flightList, hotelList) {
            if (flightList.length > 0) {
                angular.forEach(flightList, function (item, index) {
                    item.addInOrder = true;
                    item.selected = false;
                    orderItem.lstFlightPackage.push(item);
                });
                $rootScope.$broadcast('clear-f-services', { clear: true });
            }
            if (hotelList.length > 0) {
                angular.forEach(hotelList, function (item, index) {
                    item.addInOrder = true;
                    item.selected = false;
                    orderItem.lstHotelPackage.push(item);
                });
                $rootScope.$broadcast('clear-h-services', { clear: true });
            }
            orderItem.addedFlightItem = false;
            orderItem.addedHotelItem = false;
        },
        DeleteOrder: function (orderId) {
            angular.forEach(this.lstOrder, function (item, index) {
                if (item.id === orderId)
                    objOrderManager.lstOrder.splice(index, 1);
            });
        },
        DeleteFlightInOrder: function (orderId, flightIndex) {
            this.GetOrderListItem(orderId).then(function (data) {
                var order = data;
                if (order.lstFlightPackage.length >= 1)
                    order.lstFlightPackage.splice(flightIndex, 1);
                if (order.lstFlightPackage.length === 0) {
                    objOrderManager.DeleteOrder(order.id);
                    $rootScope.$broadcast('delete-order-item', { orderId: order.id });
                };
            });
        },
        DeleteHotelInOrder: function (orderId, hotelIndex) {
            this.GetOrderListItem(orderId).then(function (data) {
                var order = data;
                if (order.lstHotelPackage.length > 0)
                    order.lstHotelPackage.splice(hotelIndex, 1);
                if (order.lstFlightPackage.length === 0) {
                    objOrderManager.DeleteOrder(order.id);
                    $rootScope.$broadcast('delete-order-item', { orderId: order.id });
                };
            });

        },
        SendListPackage: function () {
            return this.lstOrder;
        },
        OrderPackageLength: function () {
            return this.lstOrder.length;
        },
        GetOrderListItem: function (orderId) {
            var deferred = $q.defer();
            angular.forEach(this.lstOrder, function (item, index) {
                if (item.id === orderId)
                    deferred.resolve(item);
            })
            return deferred.promise;
        }
    };
    objOrderManager.lstOrder = [];
    return { objOrderManager: objOrderManager }

}]);
//#endregion
angular.module('AllServicesModule').factory('GeneratId', function () {

    //#region Global Variable
    var Generator = {};
    var charSet = 'abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789',
    charSetSize = charSet.length,
    charCount = 20,
    idCount = 1;

    //#endregion

    //#region Generate id Method
    Generator.G_randId = function (_charCount) {
        var generatedIds = [];
        while (generatedIds.length < idCount) {
            var id = Generator.GenerateRandomId(_charCount);
            if ($.inArray(id, generatedIds) == -1) generatedIds.push(id);
        }
        return generatedIds;
    };
    Generator.GenerateRandomId = function (_charCount) {
        var id = '';
        if (_charCount != null)
            for (var i = 1; i <= _charCount; i++) {
                var randPos = Math.floor(Math.random() * charSetSize);
                id += charSet[randPos];
            }
        else
            for (var i = 1; i <= charCount; i++) {
                var randPos = Math.floor(Math.random() * charSetSize);
                id += charSet[randPos];
            }
        return id;
    };
    //#endregion
    return Generator;
});