
'use strict'
angular.module('ProfileMenuModule').directive('detailMenuItems', [function () {
    return {
        require: '^userProfileMenu',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewProfile/ProfileMenu/menuItemTmpl.html",
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