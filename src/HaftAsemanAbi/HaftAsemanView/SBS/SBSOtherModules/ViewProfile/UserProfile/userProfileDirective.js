
'use strict'
angular.module('UserProfileModule').directive('userProfileService', [function () {
    return {
        replace: true,
        controller: 'UserProfileCtrl',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/UserProfile/userProfileTmpl.html",
    };
}]);