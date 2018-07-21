
'use strict'
angular.module('UserProfileModule').controller('UserProfileCtrl', ['$scope', '$rootScope', '$routeParams', '$http', function ($scope, $rootScope, $routeParams, $http) {
    $scope.baseData = $rootScope.baseData;
    $scope.acceptedCompanyList = [
            {
                Id: 1,
                IsAccepted: true,
                coName: "شرکت ارژنگ فرین",
                Email: "software@rrfco.com",
                urlImg: "http://khabareiran.ir/FileCenter/News/1424_oonlwyc.jpg",
            },
           {
               Id: 2,
               IsAccepted: true,
               coName: "شرکت راژان",
               Email: "software@rrfco.com",
               urlImg: "http://www.poolnews.ir/files/fa/news/1395/11/5/261403_381.png",
           },
         {
             Id: 3,
             IsAccepted: true,
             coName: "شرکت فرتاک",
             Email: "software@rrfco.com",
             urlImg: "http://akhbarrasmi.com/Content/files/c380844e41c844949bea010d0cf1e467/e4eddc8f62ed462f82becc3c1ac40fa7.jpeg",
         },
         {
             Id: 4,
             IsAccepted: true,
             coName: "شرکت کوبل دارو",
             Email: "software@rrfco.com",
             urlImg: "https://upload.wikimedia.org/wikipedia/en/f/f6/Economic_Cooperation_Organization_logo.png",
         },
    ];


    $http({
        method: $scope.baseData.Get,
        url: $scope.baseData.G_URI_SBS_Services + 'api/V1/GetUserCompanyAccounts',
        headers: { 'Content-Type': 'application/json' }
    }).success(function (data) {
        $scope.baseData.UserCompanyAccounts = data;
    });

}]);