
'use strict'
angular.module('AllSecHotelModule').directive('hotelViewSec', [function () {
    return {
        replace: true,
        transclude: false,
        controller: "AllSecHotelCtrl",
        templateUrl: "/HaftAsemanView/SBS/SBSOtherModules/ViewWeb/Hotel_Page_Services/HDirectives/HotelViewSecTmpl.html",
    };
}]);