
'use strict'
angular.module('AllSecHotelModule').directive('titleHC', [function () {
    return {
        replace: true,
        require: '^hotelViewSec',
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Hotel_Page_Services/HDirectives/TitlehotelSecTmpl.html",
        link: function (scope, ele, attr, ctrl) {
        },
    };
}]);