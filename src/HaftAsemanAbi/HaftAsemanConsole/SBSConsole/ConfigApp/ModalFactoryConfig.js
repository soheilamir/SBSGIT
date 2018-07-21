
'use strict'
angular.module('CMSModule').factory('allContentInModal', ['$rootScope', function ($rootScope) {
    var styleContent = { msg: { "width": "280px", "background": "#FFF", "height": "150px", "margin": "18% 0px 0px 40%" }, folder: { "width": "350px", "background": "#FFF", "height": "150px", "margin": "15% 0 0 35%" } };
    var allContent = {
        createMsgContent: {
            content: '<section class="_flex m-c-sec" ng-style="stylecontent.msg"><h1 class="_flex _w90-pad5 m-txt-t _dir-align-r">{{Msg.title}}</h1><div class="_flex _w90-pad5 m-b-b-c _h100 _dir-align-r" overflow><div class="_w100 _flex split-i-c ch-split-i-c">{{Msg.context}}</div><div class="_w100 _flex split-i-c ch-split-i-c _color-r _dir-align-r">{{Msg.data}}</div></div><div class="_flex _w90-pad5 op-c _dir-align-l"><div class="_flex _bttn _bttn-form _cursor _dir-align-r" role="button" ng-click="YesBttn(fn);"><span class="_color-w">{{Msg.bttnText}}</span></div><div class="_flex _bttn _bttn-form _ch-bttn-form _trans _cursor _dir-align-r" role="button" ng-click="CloseMsg();"><span class="_color-w">انصراف</span></div></div></section>',
            stylecontent: styleContent,
            fun: function () { },
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
        createFileManager: {
            content: '<file-manager-container show-assign="true" show-ck-assign="false"></file-manager-container>',
        },
        CreateModal: {
            content: '<section modalcontent id="basemodal" ng-style="modalStyle"><div class="_flex bttn-fm ch-bttn-fm _position-a close-base-modal _cursor _trans_1" role="button" ng-click="CloseBaseModal();"><i class="ico-bttn-fm fm-icocross2"></i></div></section>',
        },
        CreateMsgModal: {
            content: '<section msg-modalcontent id="msgmodal" ng-style="modalStyle"></section>',
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
angular.module('CMSModule').factory('modalContentFactory', ['allContentInModal', '$compile', '$rootScope', function (allContentInModal, $compile, $rootScope) {
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