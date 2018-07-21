/**
 * @license Copyright (c) 2003-2016, CKSource - Frederico Knabben. All rights reserved.
 * For licensing, see LICENSE.md or http://ckeditor.com/license
 */

CKEDITOR.editorConfig = function (config) {
    // Define changes to default configuration here. For example:
    // config.language = 'fr';
    // config.uiColor = '#AADC6E';
    config.filebrowserBrowseUrl = 'http://localhost:24258/ckEditorFileManager.html';
    //config.filebrowserBrowseUrl = 'http://panel.sharestan.com/ckEditorFileManager.html';
    config.filebrowserUploadUrl = '/ckEditorFileManager.html';
    //config.filebrowserImageBrowseUrl = 'http://panel.sharestan.com/ckEditorFileManager.html';
    config.filebrowserImageBrowseUrl = 'http://localhost:24258/ckEditorFileManager.html';
    config.baseHref = 'http://localhost:24258';
    //config.baseHref = 'http://panel.sharestan.com';
    config.contentsLangDirection = 'rtl';
};
