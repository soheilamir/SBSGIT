
'use strict'
angular.module('WsPagesModule').directive('websitepagesService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "WsPagesCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/BaseWebsitePages/WsPages/WsPagesTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])