
'use strict'
angular.module('NewsModule').directive('newsService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "NewsCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/NewsBlog/News/NewsTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])