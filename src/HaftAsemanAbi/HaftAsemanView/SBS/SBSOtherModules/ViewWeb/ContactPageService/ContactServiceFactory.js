
'use strict'
angular.module('contactServiceModule').factory('contactServiceModelFactory', [function () {
    var contactServiceModelFactory = function (contactpage) {
        var _contactpage = this;
        if (!contactpage) {
            _contactpage.banner = null;
        }
        else
            _contactpage = contactpage;
    };
    return contactServiceModelFactory;
}]);
angular.module('contactServiceModule').factory('contactServiceFactory', ['$http', '$rootScope', function ($http, $rootScope) {
    var contactfactory = {
        FillingContactPage: function () {
            return GetContactData();
        },
    };
    //#region Private Event
    var GetContactData = function () {
        return $http({
            method: 'GET',
            url: $rootScope.baseData.G_URI_SBS_Services + 'GetPageInfo/ContactPage',
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
        });
    };
    //#rendegion

    return { contactfactory: contactfactory }
}]);