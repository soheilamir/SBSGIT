
'use strict'
angular.module('CmsMenuModule').directive('cmsMenu', [function () {
    return {
        replace: true,
        transclude: true,
        controller: "CmsMenuCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSMenu/CmsMenuTmpl.html",
    };
}]);