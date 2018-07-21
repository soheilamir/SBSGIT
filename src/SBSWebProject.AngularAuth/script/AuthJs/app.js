
'use strict'
var app = angular.module('LoginAuthModule', [
    'ngRoute',
    'LocalStorageModule'
]);
app.config(function ($routeProvider) {

    $routeProvider.when("/login", {
        controller: "loginAuthCtrl",
        templateUrl: "/AngularLoginAuth.html"
    });

    $routeProvider.when("/success", {
        controller: "SuccessCtrl",
        templateUrl: "/SuccessPageAuth.html"
    });

    $routeProvider.otherwise({ redirectTo: "/login" });

});
app.config(function ($httpProvider) {
    $httpProvider.interceptors.push('authInterceptorService');
});
app.run(['AuthManager', function (AuthManager) {
    AuthManager.objAuth.fillAuthData();
}]);