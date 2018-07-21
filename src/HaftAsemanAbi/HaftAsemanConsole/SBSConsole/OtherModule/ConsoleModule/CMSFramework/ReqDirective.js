
'use strict'
angular.module('CmsFrameworkModule').directive('requestItem', [function () {
    return {
        require: '^sbsCmsFramefork',
        scope: {
            reqItem: '=',
            listReq: '=',
        },
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSFramework/ReqTmpl.html",
        link: function (scope, ele, attr, ctrl) {

        },
    };
}]);