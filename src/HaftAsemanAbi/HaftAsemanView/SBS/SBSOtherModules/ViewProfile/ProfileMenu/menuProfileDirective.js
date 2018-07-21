
'use strict'
angular.module('ProfileMenuModule').directive('userProfileMenu', [function () {
    return {
        transclude: true,
        controller: "menuProfileCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/ProfileMenu/menuTmpl.html",
    };
}]);