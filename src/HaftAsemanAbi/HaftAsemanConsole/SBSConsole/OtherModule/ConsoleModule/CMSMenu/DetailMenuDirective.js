
'use strict'
angular.module('CmsMenuModule').directive('detailMenuItems', [function () {
    return {
        replace: true,
        require: '^cmsMenu',
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSMenu/DetailMenuTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    };
}]);