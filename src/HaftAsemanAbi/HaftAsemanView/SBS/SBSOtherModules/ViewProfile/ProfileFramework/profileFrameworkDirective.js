
'use strict'
angular.module('profileFrameworkModule').directive('sbsProfileFramework', [function () {
    return {
        transclude: true,
        scope: {
            altTitle: '@',
            srcUrl: '@',
        },
        controller: "profileFrameworkCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/ProfileFramework/profileFrameworkTmpl.html",
    }

}]);