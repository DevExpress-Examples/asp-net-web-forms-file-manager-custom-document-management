<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128554485/15.1.8%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T323591)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxFileManager - How to implement a custom document management for different document types


<p>This example is a combination of the <a href="http://demos.devexpress.com/ASPxRichEditDemos/DocumentManagement/CustomDocumentManagement.aspx">Custom Document Management in Rich Text Editor</a> and <a href="http://demos.devexpress.com/ASPxSpreadsheetDemos/ApplicationScenarios/DocumentBrowsing.aspx">Custom Document Management in Spreadsheet</a> demo modules. In addition, some extra file formats are supported (.jpg, .pdf). You can easily add additional file formats support if necessary. Note that we use the <a href="https://documentation.devexpress.com/#AspNet/clsDevExpressWebASPxPopupControltopic">ASPxPopupControl</a> container and load the require controls to it dynamically based on the selected file path and extension. We need to restore the dynamically generated controls hierarchy in the Page_Init event handler (see <a href="https://www.devexpress.com/Support/Center/p/KA18606">KA18606 - How to create controls dynamically</a>).<br><br>We handle the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebScriptsASPxClientFileManager_SelectedFileOpenedtopic">ASPxClientFileManager.SelectedFileOpened</a> event to trigger file open operation. Thus, you need to double-click the required file item or press the Enter key to initiate this operation.<br><br><strong>See Also:</strong><br><a href="https://www.devexpress.com/Support/Center/p/T318308">T318308 - How to open documents using ASPxFileManager</a><a href="https://www.devexpress.com/Support/Center/p/T298675"> <br>T298675 - How to show files preview as a thumbnail in ASPxFileManager</a> </p>

<br/>


