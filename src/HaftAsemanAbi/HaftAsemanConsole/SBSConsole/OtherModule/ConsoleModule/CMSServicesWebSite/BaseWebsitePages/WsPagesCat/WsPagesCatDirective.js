
'use strict'
angular.module('WsPagesCatModule').directive('websitepagesCatService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "WsPagesCatCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/BaseWebsitePages/WsPagesCat/WsPagesCatTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])