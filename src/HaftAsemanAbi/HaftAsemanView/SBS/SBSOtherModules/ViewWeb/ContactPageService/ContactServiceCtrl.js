
'use strict'
angular.module('contactServiceModule').controller('contactServiceCtrl', ['$scope', 'contactServiceModelFactory', 'contactServiceFactory', function ($scope, contactServiceModelFactory, contactServiceFactory) {
    $scope.initDataPage = new contactServiceModelFactory();
    contactServiceFactory.contactfactory.FillingContactPage().then(function (data) {
        //$scope.initDataPage = data.data;
    });
    // swiper about init

}]);