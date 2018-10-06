
'use strict'
angular.module('AllSecHotelModule').directive('infoHC', [function () {
    return {
        replace: true,
        require: '^hotelViewSec',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Hotel_Page_Services/HDirectives/InfoHotelSecTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    };
}]);