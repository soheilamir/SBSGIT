
'use strict'
angular.module('NewsBlogFactoryModule').factory('NewsBlogFactory', ['$http', '$rootScope', '$q', function ($http, $rootScope, $q) {
    var FactoryMethod = {
        SaveDataJson: function (_modelObj, url) {
            return LocalMethod.PostMethodJSON(_modelObj, url);
        },
        UpdateDataJson: function (_modelObj, url) {
            return LocalMethod.PostMethodJSON(_modelObj, url);
        },
        DeleteDataJson: function (_modelObj, url) {
            return LocalMethod.PostMethodJSON(_modelObj, url);
        },
        GetData: function (url) {
            return LocalMethod.GetMethod(url);
        },
        GetWebpagesCatData: function (url) {
            return LocalMethod.GetMethod(url);
        },
        GetWebpagesContextData: function (url) {
            return LocalMethod.GetMethod(url);
        },
        GetWebpagesBannerData: function (url) {
            return LocalMethod.GetMethod(url);
        },
    };
    //region Local Method
    var _typePost = $rootScope.baseData.Post;
    var _typeGet = $rootScope.baseData.Get;
    var _url = $rootScope.baseData.New_G_URI_API;
    var LocalMethod = {
        GetMethod: function (url) {
            return $http({
                method: _typeGet,
                url: _url + url,
                headers: { 'Content-Type': 'application/json' },
            });
        },

        PostMethod: function (_data, url) {
            return $http({
                method: _typePost,
                url: _url + url,
                data: _data,
                headers: { 'Content-Type': 'application/json' },
            });
        },
        PostMethodJSON: function (_data, url) {
            return $http({
                method: _typePost,
                url: _url + url,
                data: JSON.stringify(_data),
                headers: { 'Content-Type': 'application/json' },
            });
        },
    };
    //endregion
    return { FactoryMethod: FactoryMethod }

}]);