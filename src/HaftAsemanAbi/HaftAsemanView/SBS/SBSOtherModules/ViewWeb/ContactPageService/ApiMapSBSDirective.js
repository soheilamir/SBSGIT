
'use strict'
angular.module('contactServiceModule').directive('apiMapSbs', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        require: '^contactService',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/ContactPageService/apiMapSBSTmpl.html",
        link: function (scope, ele, attr, ctrl) {

        },
    };
}])