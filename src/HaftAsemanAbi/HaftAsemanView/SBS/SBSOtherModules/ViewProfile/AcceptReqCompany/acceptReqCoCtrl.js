
'use strict'
angular.module('acceptReqCoModule').controller('acceptReqCoCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    $scope.showBottom = false;
    $scope.IsModal = false;
    $scope.IsCo = true;
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
    ]
    $scope.unAcceptCompanyList = [
       {
           Id: 1,
           IsAccepted: false,
           coName: "شرکت کوبل دارو",
       },
       {
           Id: 2,
           IsAccepted: false,
           coName: "شرکت فرتاک",
       },
    ]
}]);