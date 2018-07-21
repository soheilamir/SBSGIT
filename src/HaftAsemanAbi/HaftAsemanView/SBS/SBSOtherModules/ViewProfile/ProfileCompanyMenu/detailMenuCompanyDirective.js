
'use strict'
angular.module('ProfileMenuCompanyModule').directive('detailMenuItems', [function () {
    return {
        require: '^companyProfileMenu',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/ProfileCompanyMenu/menuItemCompanyTmpl.html",
        link: function (scope, ele, attr, ctrl) {
            scope.lstMenuItems = ctrl.SendMenuItems();
            scope.ActiveMenu = function (item) {
                ctrl.IsActiveMenu();
                ctrl.setActiveMenu(item);
            };
            scope.IsSelectMenu = function (item) {
                return item === ctrl.getActiveMenu();
            };
        },
    };
}]);