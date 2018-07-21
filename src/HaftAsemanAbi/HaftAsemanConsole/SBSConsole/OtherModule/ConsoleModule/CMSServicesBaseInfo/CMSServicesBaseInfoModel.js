
'use strict'
angular.module('CMSServicesBaseInfoModule').factory('AirlineModelFactory', [function () {
    var AirlineModelFactory = function (airline) {
        var _airline = this;
        if (!airline) {
            _airline.Id = null;
            _airline.CountryItem = {};
            _airline.Name = null;
            _airline.FlightStateCode = null;
            _airline.Type = null;
            _airline.IataCode = null;
            _airline.IacoCode = null;
            _airline.Include = false;
        }
        else
            _airline = airline;
    };
    return AirlineModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('CountryModelFactory', [function () {
    var CountryModelFactory = function (country) {
        var _country = this;
        if (!country) {
            _country.Id = null;
            _country.CountryName = null;
            _country.EarthRegionItem = {};
            _country.ContinentItem = {};
            _country.DialingCode = null;
            _country.IsoCode = null;
            _country.UnCode = null;
            _country.UnNum = null;
        }
        else
            _country = country;
    };
    return CountryModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('AirplaneModelFactory', [function () {
    var AirplaneModelFactory = function (airplane) {
        var _airplane = this;
        if (!airplane) {
            _airplane.Id = null;
            _airplane.Company = null;
            _airplane.Name = null;
        }
        else
            _airplane = airplane;
    };
    return AirplaneModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('AirlineClassesModelFactory', [function () {
    var AirlineClassesModelFactory = function (airCls) {
        var _airCls = this;
        if (!airCls) {
            _airCls.Id = null;
            _airCls.AirlineItem = {};
            _airCls.FlightClassName = null;
        }
        else
            _airCls = airCls;
    };
    return AirlineClassesModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('AirlineSubClassesModelFactory', [function () {
    var AirlineSubClassesModelFactory = function (airSubCls) {
        var _airSubCls = this;
        if (!airSubCls) {
            _airSubCls.Id = null;
            _airSubCls.AirlinesItem = {};
            _airSubCls.AirlineClassesItem = {};
            _airSubCls.AirlineSubClassName = null;
            _airSubCls.IsActive = false;
        }
        else
            _airSubCls = airSubCls;
    };
    return AirlineSubClassesModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('FlightPathModelFactory', [function () {
    var FlightPathModelFactory = function (fPath) {
        var _fPath = this;
        if (!fPath) {
            _fPath.Id = null;
            _fPath.SourceCityItem = {};
            _fPath.DestinationCityItem = {};
        }
        else
            _fPath = fPath;
    };
    return FlightPathModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('FlightPathModelFactory', [function () {
    var FlightPathModelFactory = function (fPath) {
        var _fPath = this;
        if (!fPath) {
            _fPath.Id = null;
            _fPath.SourceCityItem = {};
            _fPath.DestinationCityItem = {};
        }
        else
            _fPath = fPath;
    };
    return FlightPathModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('AirlineClassPathModelFactory', [function () {
    var AirlineClassPathModelFactory = function (model) {
        var _model = this;
        if (!model) {
            _model.Id = null;
            _model.AirlineSubClassesItem = {};
            _model.FlightPathItem = {};
            _model.IsActive = true;
            _model.FlightConditionS = [];
            _model.FlightNumbersS = [];
            _model.AirlineClassPathFeeS = [];
        }
        else
            _model = model;
    };
    return AirlineClassPathModelFactory;
}]);
angular.module('CMSServicesBaseInfoModule').factory('AirlineClassPathFeeModelFactory', [function () {
    var AirlineClassPathFeeModelFactory = function (model) {
        var _model = this;
        if (!model) {
            _model.Id = null;
            _model.AirlineClassPathItem = {};
            _model.AdultFee = 0;
            _model.ChildFee = 0;
            _model.InfantFee = 0;
            _model.IsActive = true;
        }
        else
            _model = model;
    };
    return AirlineClassPathFeeModelFactory;
}]);