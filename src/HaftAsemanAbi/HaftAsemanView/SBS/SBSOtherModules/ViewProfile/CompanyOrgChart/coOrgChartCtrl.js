
'use strict'
angular.module('coOrgChartModule').controller('coOrgChartCtrl', ['$scope', '$rootScope', 'depModelFactory', 'personelOnDepModelFactory', 'ACLPersonelOnDepModelFactory', 'CompanyOrgManager', '$location', function ($scope, $rootScope, depModelFactory, personelOnDepModelFactory, ACLPersonelOnDepModelFactory, CompanyOrgManager, $location) {
    //#region Global variable
    $scope.index = 1;
    $scope.data = null;
    $rootScope.ModalOrgContent = false;
    $scope.deportmanetOrg = new depModelFactory();
    var options = {};
    var items = [
        new primitives.orgdiagram.ItemConfig({
            id: 0,
            parent: null,
            title: $rootScope.baseData.UserCompanyAccounts[0].CompanyName,
            description: $rootScope.baseData.UserCompanyAccounts[0].Address,
            phone: $rootScope.baseData.UserCompanyAccounts[0].Tel,
            email: $rootScope.baseData.UserCompanyAccounts[0].Fax,
            //image: "demo/images/photos/a.png",
            itemTitleColor: "#4169e1",
            templateName: "defaultContactTemplate"
        }),
    ];

    var buttons = [];
    buttons.push(new primitives.orgdiagram.ButtonConfig("addDep", "ui-icon-document-b", "افزودن بخش"));

    options.items = items;
    options.cursorItem = 0;
    options.highlightItem = 0;
    options.buttons = buttons;
    options.hasButtons = primitives.common.Enabled.Auto;
    options.hasSelectorCheckbox = primitives.common.Enabled.False;
    options.templates = [getContactTemplate(), getDepartmentTitleTemplate()];
    options.normalLevelShift = 20;
    options.dotLevelShift = 20;
    options.lineLevelShift = 10;
    options.normalItemsInterval = 10;
    options.dotItemsInterval = 10;
    options.lineItemsInterval = 4;
    options.minimalVisibility = primitives.common.Visibility.Normal;

    options.onButtonClick = function (e, data) {
        switch (data.name) {
            case "delete":
                if (data.parentItem == null) {
                    alert("شما قادر به حذف این بخش نمی باشید");
                }
                else {
                }
                break;
            case "addDep":
                $rootScope.ModalOrgContent = true;
                $scope.data = data;
                break;
            case "addPersonel":
                $rootScope.DepOrgItem = $scope.deportmanetOrg;
                $location.path('/sbs/company-profile/co/add-company-org-personel-chart');
                break;

        }
    };
    $scope.myOptions = options;
    //#endregion
    //#region Method
    CompanyOrgManager.Methods.GetCoOrgChartData("companyOrgChart/GetCoOrgChartData").then(function (result) {
        angular.forEach(result.data, function (item, index) {
            $scope.myOptions.items.push(new primitives.orgdiagram.ItemConfig({
                //id: deportmanetOrgModel.Id,
                //parent: $scope.data.context.id,
                //templateName: deportmanetOrgModel.templateName,
                //title: deportmanetOrgModel.SectionName
                id: item.Id,
                parent: (item.CompanySectionItem) ? item.CompanySectionItem.Id : 0,
                templateName: "DepartmentTitleTemplate",
                title: item.SectionName
            }));
        });
    });

    $scope.CloseSection = function () {
        $rootScope.ModalOrgContent = false;
    };
    $scope.ChangeViewOrgChart = function () {
    };
    $scope.CreateDepOrg = function (deportmanetOrgModel) {
        deportmanetOrgModel.CompanySectionItem.Id = $scope.data.context.id;
        CompanyOrgManager.Methods.SaveDataJson(deportmanetOrgModel, "companyOrgChart/SaveData").then(function (result) {
            deportmanetOrgModel.Id = $scope.index++;
            $scope.myOptions.items.push(new primitives.orgdiagram.ItemConfig({
                //id: deportmanetOrgModel.Id,
                //parent: $scope.data.context.id,
                //templateName: deportmanetOrgModel.templateName,
                //title: deportmanetOrgModel.SectionName
                id: result.data.Id,
                parent: (result.data.CompanySectionItem) ? result.data.CompanySectionItem.Id : 0,
                templateName: deportmanetOrgModel.templateName,
                title: result.data.SectionName
            }));
            $rootScope.ModalOrgContent = false;
            $scope.deportmanetOrg = new depModelFactory();
            $scope.data = null;
        });

    };
    //#endregion
    //#region Private Method

    function getContactTemplate() {
        var result = new primitives.orgdiagram.TemplateConfig();
        result.name = "defaultContactTemplate";

        result.itemSize = new primitives.common.Size(220, 140);
        result.minimizedItemSize = new primitives.common.Size(5, 5);
        result.minimizedItemCornerRadius = 5;
        result.highlightPadding = new primitives.common.Thickness(2, 2, 2, 2);


        var itemTemplate = jQuery(
            '<div class="_flex _bg-w base-item-org">'
            + '<h1 class="_flex _w95-m25 _dir-align-l" style="background:{{itemConfig.itemTitleColor}};"><i class="_w95-pad25 _fnt-fa">{{itemConfig.title}}</i></h1>'
            + '<div class="_flex _w95-pad25 other-info-org-content _dir-align-l">'
            + '<span class="_w95-pad25 _color-60">{{itemConfig.phone}}</span>'
            + '<span class="_w95-pad25 _color-60">{{itemConfig.email}}</span>'
            + '<span class="_w95-pad25 _color-60">{{itemConfig.description}}</span>'
            + '</div>'
            + '</div>'
        ).css({
            width: result.itemSize.width + "px",
            height: result.itemSize.height + "px"
        });
        result.itemTemplate = itemTemplate.wrap('<div>').parent().html();

        return result;
    }

    function getDepartmentTitleTemplate() {
        var result = new primitives.orgdiagram.TemplateConfig();
        result.name = "DepartmentTitleTemplate";
        result.isActive = true;

        var buttons = [];
        buttons.push(new primitives.orgdiagram.ButtonConfig("delete", "ui-icon-close", "خذف بخش"));
        buttons.push(new primitives.orgdiagram.ButtonConfig("addPersonel", "ui-icon-person", "افزودن پرسنل"));
        buttons.push(new primitives.orgdiagram.ButtonConfig("addDep", "ui-icon-document-b", "افزودن بخش"));

        result.buttons = buttons;

        result.itemSize = new primitives.common.Size(200, 73);
        result.minimizedItemSize = new primitives.common.Size(3, 3);
        result.highlightPadding = new primitives.common.Thickness(2, 2, 2, 2);


        var itemTemplate = jQuery(
          '<div class="bp-item bp-corner-all bt-item-frame">'
            + '<div name="titleBackground" class="bp-item bp-corner-all bp-title-frame _flex base-dep-content" style="top: 2px; left: 2px; width: 196px; height: 100%;">'
                + '<div name="title" class="_w100 _flex title-dep-content _fnt-fa">{{itemConfig.title}}'
                + '</div>'
            + '</div>'
        + '</div>'
        ).css({
            width: result.itemSize.width + "px",
            height: result.itemSize.height + "px"
        }).addClass("bp-item");
        result.itemTemplate = itemTemplate.wrap('<div>').parent().html();

        return result;
    }
    //#endregion

}]).directive('bpOrgDiagram', function ($compile) {
    function link(scope, element, attrs) {
        var itemScopes = [];

        var config = new primitives.orgdiagram.Config();
        angular.extend(config, scope.options);

        config.onItemRender = onTemplateRender;
        config.onCursorChanged = onCursorChanged;
        config.onHighlightChanged = onHighlightChanged;
        var chart = jQuery(element).orgDiagram(config);

        scope.$watch('options.highlightItem', function (newValue, oldValue) {
            var highlightItem = chart.orgDiagram("option", "highlightItem");
            if (highlightItem != newValue) {
                chart.orgDiagram("option", { highlightItem: newValue });
                chart.orgDiagram("update", primitives.orgdiagram.UpdateMode.PositonHighlight);
            }
        });

        scope.$watch('options.cursorItem', function (newValue, oldValue) {
            var cursorItem = chart.orgDiagram("option", "cursorItem");
            if (cursorItem != newValue) {
                chart.orgDiagram("option", { cursorItem: newValue });
                chart.orgDiagram("update", primitives.orgdiagram.UpdateMode.Refresh);
            }
        });
        scope.$watchCollection('options.items', function (items) {
            chart.orgDiagram("option", { items: items });
            chart.orgDiagram("update", primitives.orgdiagram.UpdateMode.Refresh);
        });
        function onTemplateRender(event, data) {
            var itemConfig = data.context;

            switch (data.renderingMode) {
                case primitives.common.RenderingMode.Create:
                    /* Initialize widgets here */
                    var itemScope = scope.$new();
                    itemScope.itemConfig = itemConfig;
                    $compile(data.element.contents())(itemScope);
                    itemScopes.push(itemScope);
                    break;
                case primitives.common.RenderingMode.Update:
                    /* Update widgets here */
                    var itemScope = data.element.contents().scope();
                    itemScope.itemConfig = itemConfig;
                    break;
            }
        }
        function onButtonClick(e, data) {
            scope.onButtonClick();
            scope.$apply();
        }
        function onCursorChanged(e, data) {
            scope.options.cursorItem = data.context ? data.context.id : null;
            scope.onCursorChanged();
            scope.$apply();
        }

        function onHighlightChanged(e, data) {
            scope.options.highlightItem = data.context ? data.context.id : null;
            scope.onHighlightChanged();
            scope.$apply();
        }
    };

    return {
        scope: {
            options: '=options',
            onCursorChanged: '&onCursorChanged',
            onHighlightChanged: '&onHighlightChanged',
        },
        link: link
    };
});