
'use strict'
angular.module('BlogModule').directive('blogService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "BlogCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/NewsBlog/Blog/BlogTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])