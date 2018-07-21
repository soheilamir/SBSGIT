
'use strict'
angular.module('LoginModule').directive('cmsLoginService', [function () {
    return {
        replace: true,
        controller: 'CMSLoginCtrl',
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/LoginModule/loginTmpl.html",
    };
}]);