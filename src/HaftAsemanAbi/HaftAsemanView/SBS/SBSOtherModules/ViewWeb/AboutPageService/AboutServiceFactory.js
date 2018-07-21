
'use strict'
angular.module('aboutServiceModule').factory('aboutServiceModelFactory', [function () {
    var aboutServiceModelFactory = function (aboutpage) {
        var _aboutpage = this;
        if (!aboutpage) {
            _aboutpage.Banner = null;
            _aboutpage.TextBanner = null;
            _aboutpage.DescriptionTextBanner = null;
            _aboutpage.AboutUsText = [];
            _aboutpage.lstLocationImage = [];
        }
        else
            _aboutpage = aboutpage;
    };
    return aboutServiceModelFactory;
}]);
angular.module('aboutServiceModule').factory('aboutServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var aboutfactory = {
        FillingAboutPage: function () {
            return GetAboutData();
        },
    };
    //#region Private Event
    var GetAboutData = function () {
        return $http({
            method: 'GET',
            url: $rootScope.baseData.G_URI_SBS_Services + 'GetPageInfo/AboutPage',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
        });
    };
    //#rendegion
    return { aboutfactory: aboutfactory }
}]);