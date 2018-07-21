﻿
'use strict'
angular.module('coEmployeeModule').controller('coEmployeeCtrl', ['$scope', '$rootScope', 'allContentInModal', 'modalContentFactory', function ($scope, $rootScope, allContentInModal, modalContentFactory) {
    //#region properties
    $rootScope.showBottom = false;
    $rootScope.IsModal = true;
    $rootScope.IsCo = false;
    $rootScope.acceptedUserList = [
      {
          Id: 1,
          IsAccepted: true,
          FullName: "Boram Kim",
          Tel: "021 22940463",
          Mobile: "0936 3329873",
          NationalCode: "0097765961",
          Email: "software@rrfco.com",
          selected: false,
          urlImg: "https://www.barrelny.com/wp-content/uploads/team_zack1.jpg",
      },
      {
          Id: 2,
          IsAccepted: true,
          FullName: "Wesley Turner-Harris",
          Tel: "021 22940463",
          Mobile: "0936 3329873",
          NationalCode: "0097765961",
          Email: "software@rrfco.com",
          selected: false,
          urlImg: "https://www.barrelny.com/wp-content/uploads/angela-teamphoto.jpg",
      },
      {
          Id: 3,
          IsAccepted: true,
          FullName: "Peter Kang",
          Tel: "021 22940463",
          Mobile: "0936 3329873",
          NationalCode: "0097765961",
          Email: "software@rrfco.com",
          selected: false,
          urlImg: "https://www.barrelny.com/wp-content/uploads/Team_Crystal.jpg",
      },
      {
          Id: 4,
          IsAccepted: true,
          FullName: "Eric Bailey",
          Tel: "021 22940463",
          Mobile: "0936 3329873",
          NationalCode: "0097765961",
          Email: "software@rrfco.com",
          selected: false,
          urlImg: "https://www.barrelny.com/wp-content/uploads/team_wesley1.jpg",
      },
     {
         Id: 5,
         IsAccepted: true,
         FullName: "Lucas Ballasy",
         Tel: "021 22940463",
         Mobile: "0936 3329873",
         NationalCode: "0097765961",
         Email: "software@rrfco.com",
         selected: false,
         urlImg: "https://www.barrelny.com/wp-content/uploads/team-boram.jpg",
     },
    {
        Id: 6,
        IsAccepted: true,
        FullName: "Crystal Ellis",
        Tel: "021 22940463",
        Mobile: "0936 3329873",
        NationalCode: "0097765961",
        Email: "software@rrfco.com",
        selected: false,
        urlImg: "https://www.barrelny.com/wp-content/uploads/team_peter1.jpg",
    },
     {
         Id: 7,
         IsAccepted: true,
         FullName: "Andres Maza",
         Tel: "021 22940463",
         Mobile: "0936 3329873",
         NationalCode: "0097765961",
         Email: "software@rrfco.com",
         selected: false,
         urlImg: "https://www.barrelny.com/wp-content/uploads/andres_2.jpg",
     },
     {
         Id: 8,
         IsAccepted: true,
         FullName: "Yvonne Weng",
         Tel: "021 22940463",
         Mobile: "0936 3329873",
         NationalCode: "0097765961",
         Email: "software@rrfco.com",
         selected: false,
         urlImg: "https://www.barrelny.com/wp-content/uploads/team_yvonne1.jpg",
     },
    {
        Id: 9,
        FullName: "Max Rolon",
        Tel: "021 22940463",
        Mobile: "0936 3329873",
        NationalCode: "0097765961",
        Email: "software@rrfco.com",
        selected: false,
        urlImg: "https://www.barrelny.com/wp-content/uploads/max_2.jpg",
    },
    {
        Id: 10,
        IsAccepted: true,
        FullName: "Sean Murphy",
        Tel: "021 22940463",
        Mobile: "0936 3329873",
        NationalCode: "0097765961",
        Email: "software@rrfco.com",
        selected: false,
        urlImg: "https://www.barrelny.com/wp-content/uploads/Team-Sean.jpg",
    },
    ];
    $scope.UserAsign = null;
    //#endregion
    $scope.$on('userasign', function (e, data) {
        $scope.UserAsign = data.UserAsign;
    });
    //#region Method
    $scope.ShowEmployeeAsign = function () {
        modalContentFactory.modalContent.open(allContentInModal.allContent.CreateInnerModal, allContentInModal.allContent.RegUser);
    };
    //#endregion
}]);