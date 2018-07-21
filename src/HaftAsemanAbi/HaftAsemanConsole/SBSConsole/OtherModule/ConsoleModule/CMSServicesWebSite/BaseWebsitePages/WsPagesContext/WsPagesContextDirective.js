
'use strict'
angular.module('WsPagesContextModule').directive('websitepagesContextService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "WsPagesContextCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/BaseWebsitePages/WsPagesContext/WsPagesContextTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])