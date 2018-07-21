
'use strict'
angular.module('profileCompanyFrameworkModule').directive('sbsProfileCompanyFramework', [function () {
    return {
        transclude: true,
        scope: {
            altTitle: '@',
            srcUrl: '@',
        },
        controller: "ProfileCompanyFrameworkCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/ProfileCompanyFramework/profileCompanyFrameworkTmpl.html",
    }

}]);