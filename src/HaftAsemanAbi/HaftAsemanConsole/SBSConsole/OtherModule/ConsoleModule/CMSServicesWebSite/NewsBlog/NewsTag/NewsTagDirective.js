
'use strict'
angular.module('NewsTagModule').directive('newstagService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "NewsTagCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/NewsBlog/NewsTag/NewsTagTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])