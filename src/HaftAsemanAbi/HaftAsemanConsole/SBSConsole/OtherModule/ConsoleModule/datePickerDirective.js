

'use strict'
angular.module('extraCMSModule').directive('persiandatepickersFrom', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            $(function () {
                element.datepicker({
                    numberOfMonths: 2,
                    //dateFormat: '(DD)-yy/mm/dd',
                    dateFormat: 'yy/mm/dd',
                    onSelect: function (dateText, inst) {
                        if (scope._f)
                            scope.newFlight.departingDate = dateText;
                        if (scope._h)
                            scope.newHotel.checkIn = dateText;
                        else
                            scope.searchFlight.DepartingDate = dateText;
                        $('.dpTo').datepicker('option', 'minDate', new JalaliDate(inst['selectedYear'], inst['selectedMonth'], inst['selectedDay']));
                    }
                });
            });
        }
    }
}).directive('persiandatepickersTo', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            $(function () {
                element.datepicker({
                    numberOfMonths: 2,
                    dateFormat: 'yy/mm/dd',

                });
            });
        }
    }
}).directive('persiandatepickersBd', function () {
    return {
        restrict: 'A',
        require: 'ngModel',
        link: function (scope, element, attrs, ngModelCtrl) {
            $(function () {
                element.datepicker({
                    numberOfMonths: 1,
                    yearRange: '1300:1400',
                    changeYear: true,
                    changeMonth: true,
                    dateFormat: 'yy/mm/dd',
                });
            });
        }
    }
});