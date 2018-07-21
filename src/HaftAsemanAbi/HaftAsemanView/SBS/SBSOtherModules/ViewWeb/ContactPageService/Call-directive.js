
'use strict'
angular.module('contactServiceModule').directive('callContent', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        require: '^contactService',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/ContactPageService/callContentTmpl.html",
        link: function (scope, ele, attr, ctrl) {

        },
    };
}])