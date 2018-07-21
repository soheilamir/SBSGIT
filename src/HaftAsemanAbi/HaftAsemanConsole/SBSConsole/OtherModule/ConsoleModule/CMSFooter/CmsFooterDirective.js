
'use strict'
angular.module('CmsFooterModule').directive('cmsFooter', [function () {
    return {
        transclude: true,
        replace: true,
        controller: "CmsFooterCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSFooter/CmsFooterTmpl.html",
    };
}]);