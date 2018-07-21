
'use strict'
angular.module('CmsFooterModule').directive('detailFooter', [function () {
    return {
        require: '^cmsFooter',
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSFooter/DetailFooterTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    };
}]);