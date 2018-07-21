
'use strict'
angular.module('BaseWebsitePagesFactoryModule').factory('WsPagesModel', [function () {
    var WsPagesModel = function (wsPages) {
        var _wsPages = this;
        if (!wsPages) {
            _wsPages.Id = null;
            _wsPages.PageName = null;
            _wsPages.Title = null;
            _wsPages.Description = null;
            _wsPages.RoutUrl = null;
            _wsPages.SourceUrl = null;
        }
        else
            _wsPages = wsPages;
    };
    return WsPagesModel;
}]);
angular.module('BaseWebsitePagesFactoryModule').factory('WsPagesCatModel', [function () {
    var WsPagesCatModel = function (wsPagesCat) {
        var _wsPagesCat = this;
        if (!wsPagesCat) {
            _wsPagesCat.Id = null;
            _wsPagesCat.Title = null;
            _wsPagesCat.WebsiteCategoryItem = {};
            _wsPagesCat.WebPagesItem = {};
        }
        else
            _wsPagesCat = wsPagesCat;
    };
    return WsPagesCatModel;
}]);
angular.module('BaseWebsitePagesFactoryModule').factory('WsPagesContextModel', [function () {
    var WsPagesContextModel = function (wsPagesContext) {
        var _wsPagesContext = this;
        if (!wsPagesContext) {
            _wsPagesContext.Id = null;
            _wsPagesContext.Context = null;
            _wsPagesContext.WebPagesItem = {};
        }
        else
            _wsPagesContext = wsPagesContext;
    };
    return WsPagesContextModel;
}]);
angular.module('BaseWebsitePagesFactoryModule').factory('WsPagesBannerModel', [function () {
    var WsPagesBannerModel = function (wsPagesBanner) {
        var _wsPagesBanner = this;
        if (!wsPagesBanner) {
            _wsPagesBanner.Id = null;
            _wsPagesBanner.Title = null;
            _wsPagesBanner.Description = null;
            _wsPagesBanner.FilesItem = {};
            _wsPagesBanner.WebPagesItem = {};
        }
        else
            _wsPagesBanner = wsPagesBanner;
    };
    return WsPagesBannerModel;
}]);