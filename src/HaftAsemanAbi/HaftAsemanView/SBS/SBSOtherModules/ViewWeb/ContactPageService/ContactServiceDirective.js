
'use strict'
angular.module('contactServiceModule').directive('contactService', ['$rootScope', function ($rootScope) {
    return {
        scope: {
        },
        controller: "contactServiceCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/ContactPageService/contactServiceTmpl.html",
        link: function (scope, element, attrs) {

        },
    };
}])