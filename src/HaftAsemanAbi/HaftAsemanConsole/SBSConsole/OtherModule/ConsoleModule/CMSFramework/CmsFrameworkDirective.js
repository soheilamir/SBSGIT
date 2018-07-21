/// <reference path="D:\Amir Folders\Projects\7BlueSkyProject\SBS(2016_New)\HaftAsemanAbi\HaftAsemanAbi\HaftAsemanAbi\scripts/jquery-2.1.4.min.js" />

'use strict'
angular.module('CmsFrameworkModule').directive('sbsCmsFramefork', [function () {
    return {
        transclude: true,
        scope: {
            altTitle: '@',
            srcUrl: '@',
        },
        controller: "CmsFrameworkCtrl",
        templateUrl: "/HaftAsemanConsole/SBSConsole/OtherModule/ConsoleModule/CMSFramework/CmsFrameworkTmpl.html",
    }

}]).directive('draggableProcessContent', ['$document', function ($document) {
    return {
        link: function (scope, ele, attr) {
            var startY = null, y = null, _pos = null;
            ele.on('mousedown', function (event) {
                event.preventDefault();
                y = 0;
                startY = event.screenY - y;
                _pos = ele.position();
                $document.on('mousemove', mousemove);
                $document.on('mouseup', mouseup);
            });

            function mousemove(event) {
                y = event.screenY - startY;
                if ((y + _pos.top) <= 410 && (y + _pos.top) >= 240)
                    ele.css({
                        bottom: 0,
                        top: y + _pos.top,
                    });
            };
            function mouseup() {
                $document.off('mousemove', mousemove);
                $document.off('mouseup', mouseup);
            };
        }
    };
}]).directive('requsetContent', ['$document', '$interval', function ($document, $interval) {
    return {
        link: function (scope, ele, attr) {
            $interval(function () {
                ele.css({
                    height: (100 - ((($('.process-content').innerHeight() + 15) * 100) / $('.dashboard-content').innerHeight())) + '%',
                });
            }, 10);
        }
    };
}]);