
'use strict'
angular.module('ProfileMenuCompanyModule').controller('menuProfileCompanyCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    $scope.menuItemList = [/// get data menu items from json file or api  
        { name: "لیست اعضا و درخواست به کاربران", title: "لیست اعضا و درخواست به کاربران", href: '#/sbs/company-profile/user/acception-user' },
        { name: "بخش چارت سازمانی شرکت", title: "بخش چارت سازمانی شرکت", href: '#/sbs/company-profile/co/company-org-chart' },
        { name: "بخش آپلود عکس ها و مدارک", title: "بخش آپلود عکس ها و مدارک", href: '#/sbs/profile/sbs-services/sbs-upload-file-services' },
        { name: "تغییر اطلاعات شرکت", title: "تغییر اطلاعات شرکت", href: '#/sbs/company-profile/company/info/change-info-co' },
        { name: "نمایش خرید بلیط های آنلاین", title: "نمایش خرید بلیط های آنلاین", href: '#/sbs/profile/sbs-services/history/flight/booking-online-history' },
        { name: "نمایش درخواست سرویس های آنلاین", title: "نمایش درخواست سرویس های آنلاین", href: '#/sbs/profile/sbs-services/history/serach-all-history-of-services' },
        { name: "بخش اطلاعات مالی", title: "بخش اطلاعات مالی", href: '#' },
        { name: "بخش گزارشات", title: "بخش گزارشات", href: '#' },
    ];
    this.SendMenuItems = function () {
        return $scope.menuItemList;
    };
    this.IsActiveMenu = function () {
        $rootScope.$broadcast('active-menu', {});
    };
    this.getActiveMenu = function () {
        return $scope.activeMenu;
    };
    this.setActiveMenu = function (item) {
        $scope.activeMenu = item;
    };
}]);