
'use strict'
angular.module('SBSWebApp').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        {
            url: '/haft-aseman-abi/travel-agency',
            config:
                {
                    template: '<wwa-home-service></wwa-home-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/about',
            config:
                {
                    template: '<wwa-about-service></wwa-about-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/contact-us',
            config:
                {
                    template: '<wwa-contact-service></wwa-contact-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/teams',
            config:
                {
                    template: '<wwa-teams-service></wwa-teams-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/detail-teams',
            config:
                {
                    template: '<wwa-detail-teams-service></wwa-detail-teams-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/blog',
            config:
                {
                    template: '<wwa-blog-service></wwa-blog-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/detail-blog',
            config:
                {
                    template: '<wwa-detail-blog-service></wwa-detail-blog-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/news',
            config:
                {
                    template: '<wwa-news-service></wwa-news-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/detail-news',
            config:
                {
                    template: '<wwa-detail-news-service></wwa-detail-news-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/sbs-login-authentication',
            config:
                {
                    template: '<wwa-login-service></wwa-login-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/sbs-register',
            config:
                {
                    template: '<wwa-reg-service></wwa-reg-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/company/sbs-register-company',
            config:
                {
                    template: '<wwa-reg-co-service></wwa-reg-co-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/booking/domestic/domestic-flight-booking-service',
            config:
                {
                    template: '<wwa-dfb-service></wwa-dfb-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/booking/domestic/domestic-hotels-booking-service',
            config:
                {
                    template: '<wwa-dhb-service></wwa-dhb-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/booking/domestic/detail-hotels-service',
            config:
                {
                    template: '<wwa-detail-hotels-service></wwa-detail-hotels-service>'
                }
        },
        {
            url: '/haft-aseman-abi/travel-agency/booking/domestic/hotel/passenger-of-rooms',
            config:
                {
                    template: '<wwa-set-passenger-rooms-service></wwa-set-passenger-rooms-service>'
                }
        },

    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
    $routeProvider.otherwise({ redirectTo: '/haft-aseman-abi/travel-agency' });
}]);