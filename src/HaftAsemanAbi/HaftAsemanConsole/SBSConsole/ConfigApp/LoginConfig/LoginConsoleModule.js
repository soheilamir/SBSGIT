
'use strict'
var LoginConsoleModule = angular.module("LoginConsoleModule", [
    'ngRoute',
    'LoginAuthModule',
]);
bootstrapApplication();
function bootstrapApplication() {
    angular.element(document).ready(function () {
        angular.bootstrap(document, ["LoginConsoleModule"]);
    });
}