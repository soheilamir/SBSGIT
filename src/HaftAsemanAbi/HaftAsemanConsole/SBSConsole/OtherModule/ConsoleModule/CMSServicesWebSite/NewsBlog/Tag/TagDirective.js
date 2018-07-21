
'use strict'
angular.module('TagModule').directive('tagService', ['$rootScope', function ($rootScope) {
    return {
        replace: true,
        scope: {
        },
        controller: "TagCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSServicesWebSite/NewsBlog/Tag/TagTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    }

}])