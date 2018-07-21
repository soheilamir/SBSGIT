angular.module('extraSBSModule').factory('allContentInModal', ['$rootScope', function ($rootScope) {
    var styleContent = { reguser: { width: '900px', height: '500px', background: '#FFF', margin: '8% 0px 0px 18%', }, folder: { "width": "350px", "background": "#FFF", "height": "150px", "margin": "15% 0 0 35%" } };
    var allContent = {
        RegUser: {
            content: '<section class="_w100 _h100 _flex"><div class="_flex modal-user-reg _dir-align-r" ng-style="stylecontent.reguser"><div class="_flex _w90-m5 title-u-r-content _position-r"><div class="_flex asign-bttn-reg-user _cursor _position-a" role="button" ng-show="Isasign==true" ng-click="AsignUserReg();"><i class="_color-w">تخصیص</i></div><i class="_flex sbs-ico-menu"></i><h3>نمایش اعضای شرکت</h3></div><div class="_flex body-u-r-content _w90-pad5" over><reg-user-co show-bottom="showBottom" is-modal="IsModal" accepted-lst="acceptedUserList" is-co="IsCo"></reg-user-co></div></div></section>',
            stylecontent: styleContent
        },
        FlightBooking: {
            content: '<section class="_w100 _h100 booking-flight _trans"><figure class="_w100 _h100 _flex"><div class=" _flex base-mbf _dir-align-l"><img alt="آژانس هواپیمایی هفت آسمان آبی" title="آژانس هواپیمایی هفت آسمان آبی" src="/Image/SBS-Logo_web.png" /><div class="_w100 _h100 _flex _dir-align-r body-loading-flight-content"><div class="_w100 _flex _dir-align-r top-lfc"><h1 class="_flex _dir-align-l"><img alt="" title="" src="/Image/checked-line-content.png" /><i>Flight Online Booking</i></h1><h1>در حال جستجوی تمامی پروازها با مناسب ترین قیمت ها</h1></div><div class="_w100 _flex _dir-align-r bottom-lfc"><ul class="_flex _w100"><li class="_flex _w90-pad5"><h1 class="_flex _w100">بهرمندی از تخفیفات مختلف هفت آسمان آبی</h1></li><li class="_flex _w90-pad5"><h1 class="_flex _w100">درخواست سرویس های آنلاین در هر زمان از شبانه روز</h1></li><li class="_flex _w90-pad5"><h1 class="_flex _w100">بهرمندی از  خدمات مختلف هفت آسمان آبی</h1></li><li class="_flex _w90-pad5"><h1 class="_flex _w100">گارانتی پرداخت های آنلاین</h1></li></ul></div></div></div></figure></section>',
            //stylecontent: styleContent
        },
        WatingFor: {
            content: '<section class="wating-for _flex _position-a"><img alt="آژانس هواپیمایی هفت آسمان آبی" title="آژانس هواپیمایی هفت آسمان آبی" src="/Image/SBS-Logo_web.png" /><h1>{{MsgWating.text}}</h></section>',
            //stylecontent: styleContent
        },
        /// ----> ng-model:folderName
        createfolder: {
            content: '<section class="_flex m-c-sec" ng-style="stylecontent.folder"><h1 class="_flex _w90-pad5 m-txt-t _dir-align-r">ایجاد پوشه جدید</h1><div class="_flex _w90-pad5 m-b-b-c _h100 _dir-align-r"><div class="_w100 _flex split-i-c"><label class="_lbl _lbl-form _dir-align-r lbl-l">عنوان پوشه:</label><input type="text" placeholder="عنوان پوشه" class="_txt-form _fnt-fa" ng-model="folderName" /></div></div><div class="_flex _w90-pad5 op-c _dir-align-l"><div class="_flex _bttn _bttn-form _trans _cursor _dir-align-r" role="button" ng-click="AjxCreateFolder();"><span class="_color-w">ایجاد فایل</span></div><div class="_flex _bttn _bttn-form _ch-bttn-form _trans _cursor _dir-align-r" role="button" ng-click="CloseFrm();"><span class="_color-w">انصراف</span></div></div></section>',
            stylecontent: styleContent
        },
        OtherModal: {
            content: '<section other-modalcontent class="_flex _position-r" id="othermodal" ng-style="modalStyle"></section>',
        },
        CreateInnerModal: {
            content: '<section ch-modalcontent id="innermodal" ng-style="modalStyle"></section>',
        },
    };
    return { allContent: allContent };
}]);
angular.module('extraSBSModule').factory('modalContentFactory', ['allContentInModal', '$compile', '$rootScope', function (allContentInModal, $compile, $rootScope) {
    var modalContent = {
        open: function (modal, cnt) {
            var html = modal.content;
            this.content = angular.element(cnt.content);
            this.elm = angular.element(html);
            angular.element(this.elm).prepend(this.content);
            angular.element(document.body).prepend(this.elm);
            $rootScope.modalStyle = { "display": "block" };
            $rootScope.stylecontent = cnt.stylecontent;
            $compile(this.elm)($rootScope);
        },
        close: function (html) {
            this.elm = $(html);
            if (this.elm) {
                this.elm.remove();
                $rootScope.folderName = null;
            }
        },
    };
    modalContent.elm = null;
    modalContent.content = null;
    return { modalContent: modalContent };
}]);