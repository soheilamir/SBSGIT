
'use strict'
angular.module('AthenticationServiceModule').factory('NewUserModelFactory', [function () {
    var NewUserModelFactory = function (nUser) {
        var _nUser = this;
        if (!nUser) {
            _nUser.FaName = null;
            _nUser.FaFamily = null;
            _nUser.Tel = null;
            _nUser.Email = null;
            _nUser.Password = null;
        }
        else
            _nUser = nUser;
    };
    return NewUserModelFactory;
}]);
angular.module('AthenticationServiceModule').factory('LoginModelFactory', [function () {
    var LoginModelFactory = function (login) {
        var _login = this;
        if (!login) {
            _login.Username = null;
            _login.Password = null;
            _login.isAuth = false;
            _login.useRefreshTokens = false;
        }
        else
            _login = login;
    };
    return LoginModelFactory;
}]);
angular.module('AthenticationServiceModule').factory('Reg_Login_ServiceManagerFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var _Reg_log_Manager = {
        SaveNewUser: function (newUser) {
            return PostNewUserData(newUser);
        },
    };
    _Reg_log_Manager.BaseUrI = "http://localhost:9983/";
    _Reg_log_Manager.methodGET = 'GET';
    _Reg_log_Manager.methodPOST = 'POST';
    //#region Private Event
    var PostNewUserData = function (newUser) {
        return $http({
            method: _Reg_log_Manager.methodPOST,
            url: _Reg_log_Manager.BaseUrI + 'api/v1/AddUser',
            data: JSON.stringify(newUser),
            headers: { 'Content-Type': 'application/json' }
        });
    };
    //#rendegion

    return { _Reg_log_Manager: _Reg_log_Manager }
}]);