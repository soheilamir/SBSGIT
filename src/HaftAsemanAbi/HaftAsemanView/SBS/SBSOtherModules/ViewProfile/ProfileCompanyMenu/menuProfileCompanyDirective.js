
'use strict'
angular.module('ProfileMenuCompanyModule').directive('companyProfileMenu', [function () {
    return {
        transclude: true,
        controller: "menuProfileCompanyCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/ProfileCompanyMenu/menuCompanyTmpl.html",
    };
}]);