
'use strict'
angular.module('ProfileMenuModule').controller('menuProfileCtrl', ['$scope', '$rootScope', function ($scope, $rootScope) {
    $scope.menuItemList = [/// get data menu items from json file or api  
        { name: "نمایش لیست شرکت های عضو", title: "نمایش لیست شرکت های عضو", href: '#/sbs/user-profile/company/acception-company-req' },
        { name: "تغییر اطلاعات کاربری", title: "تغییر اطلاعات کاربری", href: '#' },
        { name: "بخش آپلود عکس ها و مدارک", title: "بخش آپلود عکس ها و مدارک", href: '#/sbs/profile/sbs-services/sbs-upload-file-services' },
        { name: "ورود اطلاعات مسافرین", title: "ورود اطلاعات مسافرین", href: '#/sbs/profile/sbs-services/passenger/show-all-passenger' },
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