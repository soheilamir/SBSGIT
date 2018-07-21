
'use strict'
angular.module('coOrgChartModule').factory('depModelFactory', [function () {
    var depModelFactory = function (dep) {
        var _dep = this;
        if (!dep) {
            _dep.Id = null,
            _dep.SectionName = null,
            _dep.templateName = "DepartmentTitleTemplate",
            _dep.CompanyItem = {},
            _dep.CompanySectionItem = {},
            //_dep.personelLst = [],
            _dep.checkedBttn = false
        }
        else
            _dep = dep;
    };
    return depModelFactory;
}]);
angular.module('coOrgChartModule').factory('personelOnDepModelFactory', [function () {
    var personelOnDepModelFactory = function (personelOnDep) {
        var _personelOnDep = this;
        if (!personelOnDep) {
            _personelOnDep.templateName = "personelContactTemplate",
            _personelOnDep.Id = null,
            _personelOnDep.Name = null,
            _personelOnDep.Position = null,
            _personelOnDep.ACLLst = [],
            _personelOnDep.active = true
        }
        else
            _personelOnDep = personelOnDep;
    };
    return personelOnDepModelFactory;
}]);
angular.module('coOrgChartModule').factory('ACLPersonelOnDepModelFactory', [function () {
    var ACLPersonelOnDepModelFactory = function (ACLPersonelOnDep) {
        var _ACLPersonelOnDep = this;
        if (!ACLPersonelOnDep) {
            _ACLPersonelOnDep.Id = null,
            _ACLPersonelOnDep.Name = null
        }
        else
            _ACLPersonelOnDep = ACLPersonelOnDep;
    };
    return ACLPersonelOnDepModelFactory;
}]);

angular.module('coOrgChartModule').factory('CompanyOrgManager', ['$http', '$rootScope', '$q', function ($http, $rootScope, $q) {
    var Methods = {
        SaveDataJson: function (_modelObj, url) {
            return LocalMethod.PostMethodJSON(_modelObj, url);
        },
        UpdateDataJson: function (_modelObj, url) {
        },
        DeleteDataJson: function (_modelObj, url) {
        },
        GetCoOrgChartData: function (url) {
            return LocalMethod.GetMethod(url);
        },
    };
    //region Local Method
    var _typePost = $rootScope.baseData.Post;
    var _typeGet = $rootScope.baseData.Get;
    var _url = $rootScope.baseData.G_URI_New_API;
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
    return { Methods: Methods }

}]);