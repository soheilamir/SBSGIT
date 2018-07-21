
'use strict'
angular.module('CompanyProfileModule').controller('CompanyProfileCtrl', ['$scope', '$rootScope', '$routeParams', 'localStorageService', '$http', function ($scope, $rootScope, $routeParams, localStorageService, $http) {
    // get all regUser of Company in server
    $scope.baseData = $rootScope.baseData;
    $scope.RegUserOfCompanyList = [
        {
            Id: 0,
            Name: "Sei-Wook Kim",
            urlImg: "https://www.barrelny.com/wp-content/uploads/Team_Sei-Wook-2.jpg",
        },
        {
            Id: 0,
            Name: "Boram Kim",
            urlImg: "https://www.barrelny.com/wp-content/uploads/team_zack1.jpg",
        },
        {
            Id: 0,
            Name: "Wesley Turner-Harris",
            urlImg: "https://www.barrelny.com/wp-content/uploads/angela-teamphoto.jpg",
        },
        {
            Id: 0,
            Name: "Peter Kang",
            urlImg: "https://www.barrelny.com/wp-content/uploads/Team_Crystal.jpg",
        },
        {
            Id: 0,
            Name: "Eric Bailey",
            urlImg: "https://www.barrelny.com/wp-content/uploads/team_wesley1.jpg",
        },
        {
            Id: 0,
            Name: "Lucas Ballasy",
            urlImg: "https://www.barrelny.com/wp-content/uploads/team-boram.jpg",
        },
        {
            Id: 0,
            Name: "Crystal Ellis",
            urlImg: "https://www.barrelny.com/wp-content/uploads/team_peter1.jpg",
        },
        {
            Id: 0,
            Name: "Andres Maza",
            urlImg: "https://www.barrelny.com/wp-content/uploads/andres_2.jpg",
        },
        {
            Id: 0,
            Name: "Yvonne Weng",
            urlImg: "https://www.barrelny.com/wp-content/uploads/team_yvonne1.jpg",
        },
        {
            Id: 0,
            Name: "Max Rolon",
            urlImg: "https://www.barrelny.com/wp-content/uploads/max_2.jpg",
        },
        {
            Id: 0,
            Name: "Sean Murphy",
            urlImg: "https://www.barrelny.com/wp-content/uploads/Team-Sean.jpg",
        },
        {
            Id: 0,
            Name: "Angela Hum",
            urlImg: "https://www.barrelny.com/wp-content/uploads/angela-teamphoto.jpg",
        },
    ];
    $http({
        method: $scope.baseData.Get,
        url: $scope.baseData.G_URI_SBS_Services + 'api/V1/GetUserCompanyAccounts',
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $rootScope.baseData.UserCompanyAccounts = data;
    });
}]);