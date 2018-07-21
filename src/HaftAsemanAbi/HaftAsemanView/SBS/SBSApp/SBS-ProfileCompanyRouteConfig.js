angular.module("SBSProfileCompanyApp").config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        {
            url: '/sbs/company-profile/company-page',
            config:
                {
                    template: '<wwa-company-profile-page-service></wwa-company-profile-page-service>'
                },
        },
        {
            url: '/sbs/company-profile/user/acception-user',
            config:
                {
                    template: '<wwa-user-acception-company-service></wwa-user-acception-company-service>'
                },
        },
        {
            url: '/sbs/company-profile/co/company-org-chart',
            config:
                {
                    template: '<wwa-company-org-chart-service></wwa-company-org-chart-service>'
                },
        },
        {
            url: '/sbs/company-profile/co/add-company-org-personel-chart',
            config:
                {
                    template: '<wwa-add-company-personel-org-chart-service></wwa-add-company-personel-org-chart-service>'
                },
        },
        //{
        //    url: '/sbs/company-profile/employee/company-employee',
        //    config:
        //        {
        //            template: '<wwa-company-employee-service></wwa-company-employee-service>'
        //        },
        //},
        {
            url: '/sbs/company-profile/company/info/change-info-co',
            config:
                {
                    template: '<wwa-company-info-service></wwa-company-info-service>'
                },
        },
        {
            url: '/sbs/company-profile/company/info/credit',
            config:
                {
                    template: '<wwa-co-credit-service></wwa-co-credit-service>'
                },
        },
    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
    $routeProvider.otherwise({ redirectTo: '/sbs/company-profile/company-page' });
}]);