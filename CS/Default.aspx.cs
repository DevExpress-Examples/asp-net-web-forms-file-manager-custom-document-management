using System;
using System.IO;
using DevExpress.Web;
using DevExpress.Web.ASPxRichEdit;
using DevExpress.Web.ASPxSpreadsheet;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Init(object sender, EventArgs e) {
        if (!IsPostBack)
            Session["lastOpenedFilePath"] = null;
        
        if (!ASPxPopupControl1.IsCallback)
            OpenFile();
    }

    protected void ASPxPopupControl1_WindowCallback(object source, PopupWindowCallbackArgs e) {
        if (ASPxFileManager1.SelectedFile != null) {
            Session["lastOpenedFilePath"] = ASPxFileManager1.SelectedFile.FullName;
            OpenFile();
        }
    }

    private void OpenFile() {
        if (Session["lastOpenedFilePath"] != null) {
            string fileRelativePath = Session["lastOpenedFilePath"].ToString();
            string fileExtension = Path.GetExtension(fileRelativePath).ToLower();
            string fileFullPath = Server.MapPath(fileRelativePath);

            switch (fileExtension) {
                case ".docx":
                    OpenWordFile(fileFullPath);
                    break;
                case ".xlsx":
                    OpenExcelFile(fileFullPath);
                    break;
                case ".jpg":
                    OpenImageFile(fileRelativePath);
                    break;
                case ".pdf":
                    OpenPdfFile(fileRelativePath);
                    break;
                default:
                    DisplayUnknownFileError(fileRelativePath);
                    break;
            }
        }
    }

    private void OpenWordFile(string fileFullPath) {
        ASPxRichEdit richEdit = new ASPxRichEdit();
        richEdit.ID = "richEdit";
        ASPxPopupControl1.Controls.Add(richEdit);
        richEdit.Open(fileFullPath);
    }

    private void OpenExcelFile(string fileFullPath) {
        ASPxSpreadsheet spreadsheet = new ASPxSpreadsheet();
        spreadsheet.ID = "spreadsheet";
        ASPxPopupControl1.Controls.Add(spreadsheet);
        spreadsheet.Open(fileFullPath);
    }

    private void OpenImageFile(string fileRelativePath) {
        ASPxImage image = new ASPxImage();
        image.ID = "image";
        ASPxPopupControl1.Controls.Add(image);
        image.ImageUrl = fileRelativePath;
    }

    private void OpenPdfFile(string fileRelativePath) {
        ASPxHyperLink hyperLink = new ASPxHyperLink();
        hyperLink.ID = "hyperLink";
        ASPxPopupControl1.Controls.Add(hyperLink);
        hyperLink.Text = "Download " + Path.GetFileName(fileRelativePath);
        hyperLink.NavigateUrl = fileRelativePath;
        hyperLink.Target = "_blank";
    }

    private void DisplayUnknownFileError(string fileFelativePath) {
        ASPxLabel label = new ASPxLabel();
        label.ID = "label";
        ASPxPopupControl1.Controls.Add(label);
        label.Text = "Unknown file type: " + Path.GetExtension(fileFelativePath);
    }
}