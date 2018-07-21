'use strict'
angular.module("SBSLinkAllModule", [
    'AthenticationServiceModule',
]).factory('AuthManager', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
    var BaseUrI = 'http://localhost:44075/';
    var objAuth = {
        login: function (loginData) {
            var data = "grant_type=password&username=" + loginData.Username + "&password=" + loginData.Password + "&client_id=099153c2625149bc8ecb3e85e03f0022";

            var deferred = $q.defer();

            $http.post(BaseUrI + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.Username, refreshToken: "", useRefreshTokens: false });
                objAuth.authentication.isAuth = true;
                objAuth.authentication.Username = loginData.Username;
                deferred.resolve(response);

            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        },
        logOut: function () {
            localStorageService.remove('authorizationData');
            this.authentication.isAuth = false;
            this.authentication.Username = "";
            this.authentication.useRefreshTokens = false;
        },
        fillAuthData: function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                this.authentication.isAuth = true;
                this.authentication.Username = authData.Username;
                this.authentication.useRefreshTokens = authData.useRefreshTokens;
            }

        },
    };
    objAuth.authentication = {
        isAuth: false,
        Username: "",
        useRefreshTokens: false
    }

    return { objAuth: objAuth }
}]).factory('authInterceptorService', ['$q', '$injector', '$window', 'localStorageService', function ($q, $injector, $window, localStorageService) {

    var authInterceptorServiceFactory = {};

    var _request = function (config) {

        config.headers = config.headers || {};

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            config.headers.Authorization = 'Bearer ' + authData.token;
        }

        return config;
    }

    var _responseError = function (rejection) {
        if (rejection.status === 401) {
            var authService = $injector.get('AuthManager');
            var authData = localStorageService.get('authorizationData');

            if (authData) {
                if (authData.useRefreshTokens) {
                    return $q.reject(rejection);
                }
            }
            authService.objAuth.logOut();
            $window.location.href = 'http://localhost:24258/default.html#/haft-aseman-abi/travel-agency/sbs-login-authentication';
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]).filter('isImportant', function () {
    return function (input) {
        var out = [];
        for (var i = 0; i < input.length; i++) {
            if (input[i].IsImportant) {
                out.push(input[i]);
            }
        }
        return out;
    }
}).filter('isoCurrency', function () {
    return function (value, iso, decimal, decimalSep, thousSep) {
        return accounting.formatMoney(value, " " || $, parseInt(decimal) || 0, thousSep || ",", decimalSep || ".");
    }
}).filter('range', function () {
    return function (input, total) {
        total = parseInt(total);

        for (var i = 0; i < total; i++) {
            input.push(i);
        }

        return input;
    };
});