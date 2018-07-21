
'use strict'
angular.module('LoginAuthModule').factory('AuthManager', ['$http', '$q', 'localStorageService', function ($http, $q, localStorageService) {
    var BaseUrI = 'http://localhost:44075/';
    var objAuth = {
        login: function (loginData) {
            var data = "grant_type=password&username=" + loginData.userName + "&password=" + loginData.password + "&client_id=099153c2625149bc8ecb3e85e03f0022";

            var deferred = $q.defer();

            $http.post(BaseUrI + 'token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).success(function (response) {
                localStorageService.set('authorizationData', { token: response.access_token, userName: loginData.userName, refreshToken: "", useRefreshTokens: false });
                objAuth.authentication.isAuth = true;
                objAuth.authentication.userName = loginData.userName;
                deferred.resolve(response);

            }).error(function (err, status) {
                deferred.reject(err);
            });

            return deferred.promise;
        },
        logOut: function () {
            localStorageService.remove('authorizationData');
            this.authentication.isAuth = false;
            this.authentication.userName = "";
            this.authentication.useRefreshTokens = false;
        },
        fillAuthData: function () {

            var authData = localStorageService.get('authorizationData');
            if (authData) {
                this.authentication.isAuth = true;
                this.authentication.userName = authData.userName;
                this.authentication.useRefreshTokens = authData.useRefreshTokens;
            }

        },
    };
    objAuth.authentication = {
        isAuth: false,
        userName: "",
        useRefreshTokens: false
    }

    return { objAuth: objAuth }
}]);

angular.module('LoginAuthModule').factory('authInterceptorService', ['$q', '$injector', '$location', 'localStorageService', function ($q, $injector, $location, localStorageService) {

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
                    //$location.path('/refresh');
                    return $q.reject(rejection);
                }
            }
            authService.objAuth.logOut();
            $location.path('/login');
        }
        return $q.reject(rejection);
    }

    authInterceptorServiceFactory.request = _request;
    authInterceptorServiceFactory.responseError = _responseError;

    return authInterceptorServiceFactory;
}]);