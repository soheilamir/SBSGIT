
'use strict'
angular.module('CMSModule').config(['$routeProvider', function ($routeProvider) {

    // ajax from api or JSON file and gets all prams route
    var routes = [
        /// base url config
        {
            url: '/haft-aseman-abi/CMS-Console/website-sec/websitepages',
            config:
                {
                    template: '<wwa-websitepages-config-service class="_w100 _h100"></wwa-websitepages-config-service>'
                },
        },
         {
             url: '/haft-aseman-abi/CMS-Console/website-sec/websitepages-cat',
             config:
                 {
                     template: '<wwa-websitepages-cat-config-service class="_w100 _h100"></wwa-websitepages-cat-config-service>'
                 },
         },
         {
             url: '/haft-aseman-abi/CMS-Console/website-sec/websitepages-context',
             config:
                 {
                     template: '<wwa-websitepages-context-config-service class="_w100 _h100"></wwa-websitepages-context-config-service>'
                 },
         },
         {
             url: '/haft-aseman-abi/CMS-Console/website-sec/websitepages-banner',
             config:
                 {
                     template: '<wwa-websitepages-banner-config-service class="_w100 _h100"></wwa-websitepages-banner-config-service>'
                 },
         },
         {
             url: '/haft-aseman-abi/CMS-Console/website-sec/tag-config',
             config:
                 {
                     template: '<wwa-tag-config-service class="_w100 _h100"></wwa-tag-config-service>'
                 },
         },
         {
             url: '/haft-aseman-abi/CMS-Console/website-sec/newstag-config',
             config:
                 {
                     template: '<wwa-newstag-config-service class="_w100 _h100"></wwa-newstag-config-service>'
                 },
         },
         {
             url: '/haft-aseman-abi/CMS-Console/website-sec/news-config',
             config:
                 {
                     template: '<wwa-news-config-service class="_w100 _h100"></wwa-news-config-service>'
                 },
         },
         {
             url: '/haft-aseman-abi/CMS-Console/website-sec/blog-config',
             config:
                 {
                     template: '<wwa-blog-config-service class="_w100 _h100"></wwa-blog-config-service>'
                 },
         },
        //#region Panel website URL Config

        //#endregion

    ];
    routes.forEach(function (route) {
        $routeProvider.when(route.url, route.config);
    });
}]);