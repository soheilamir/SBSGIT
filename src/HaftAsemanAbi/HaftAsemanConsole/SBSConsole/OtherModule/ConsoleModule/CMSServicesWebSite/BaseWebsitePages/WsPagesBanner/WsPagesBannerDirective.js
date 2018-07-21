
'use strict'
angular.module('WsPagesBannerModule').directive('websitepagesBannerService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "WsPagesBannerCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/BaseWebsitePages/WsPagesBanner/WsPagesBannerTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])