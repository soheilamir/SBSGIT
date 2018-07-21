
'use strict'
angular.module('NewsBlogFactoryModule').factory('BlogModel', [function () {
    var BlogModel = function (model) {
        var _model = this;
        if (!model) {
            _model.Id = null;
            _model.PageName = null;
            _model.Title = null;
            _model.Description = null;
            _model.RoutUrl = null;
            _model.SourceUrl = null;
        }
        else
            _model = model;
    };
    return BlogModel;
}]);
angular.module('NewsBlogFactoryModule').factory('NewsModel', [function () {
    var NewsModel = function (model) {
        var _model = this;
        if (!model) {
            _model.Id = null;
            _model.Title = null;
            _model.WebsiteCategoryItem = {};
            _model.WebPagesItem = {};
        }
        else
            _model = model;
    };
    return NewsModel;
}]);
angular.module('NewsBlogFactoryModule').factory('NewsTagModel', [function () {
    var NewsTagModel = function (model) {
        var _model = this;
        if (!model) {
            _model.Id = null;
            _model.Context = null;
            _model.WebPagesItem = {};
        }
        else
            _model = model;
    };
    return NewsTagModel;
}]);
angular.module('NewsBlogFactoryModule').factory('SbsTagModel', [function () {
    var TagModel = function (model) {
        var _model = this;
        if (!model) {
            _model.Id = null;
            _model.Title = null;
            _model.NewsTagsS = [];
        }
        else
            _model = model;
    };
    return TagModel;
}]);