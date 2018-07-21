
'use strict'
angular.module('aboutServiceModule').controller('aboutServiceCtrl', ['$scope', 'aboutServiceModelFactory', 'aboutServiceFactory', function ($scope, aboutServiceModelFactory, aboutServiceFactory) {
    $scope.initDataPage = new aboutServiceModelFactory();
    aboutServiceFactory.aboutfactory.FillingAboutPage().then(function (data) {
        $scope.initDataPage = data.data;
    });
    // swiper about init

}]);