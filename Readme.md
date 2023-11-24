<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T323591)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->

# File Manager for ASP.NET Web Forms - How to implement custom document management for different document types

This example demonstrates how to open documents of different types in an apropriate component within a pop-up window. 

## Implementation Details

The [ASPxClientFileManager.SelectedFileOpened](https://docs.devexpress.com/AspNet/js-ASPxClientFileManager.SelectedFileOpened) event handler initiates a callback of the [ASPxPopupControl](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPopupControl) component. On the server, the [WindowCallback](https://docs.devexpress.com/AspNet/DevExpress.Web.ASPxPopupControlBase.WindowCallback) event handler dynamically creates a component appropriate for the opened file. Note that once you have modified the control hierarchy, it is necessary to restore the created control with the same settings during the `Page_Init` stage.

## Files to Review

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))

## Online Demos

* [Rich Text Editor - Custom Document Management](https://demos.devexpress.com/ASPxRichEditDemos/DocumentManagement/CustomDocumentManagement.aspx)
* [Spreadsheet - Custom Document Management](https://demos.devexpress.com/ASPxSpreadsheetDemos/ApplicationScenarios/DocumentBrowsing.aspx)

## More Examples

* [File Manager for ASP.NET Web Forms - How to open a selected text or spreadsheet file](https://github.com/DevExpress-Examples/asp-net-web-forms-file-manager-open-office-documents)
* [How to create ASP.NET Web Forms controls dynamically](https://github.com/DevExpress-Examples/asp-net-web-forms-create-controls-dynamically)
