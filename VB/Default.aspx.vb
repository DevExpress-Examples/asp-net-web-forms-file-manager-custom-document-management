Imports System
Imports System.IO
Imports DevExpress.Web
Imports DevExpress.Web.ASPxRichEdit
Imports DevExpress.Web.ASPxSpreadsheet

Partial Public Class _Default
	Inherits System.Web.UI.Page

	Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
		If Not IsPostBack Then
			Session("lastOpenedFilePath") = Nothing
		End If

		If Not ASPxPopupControl1.IsCallback Then
			OpenFile()
		End If
	End Sub

	Protected Sub ASPxPopupControl1_WindowCallback(ByVal source As Object, ByVal e As PopupWindowCallbackArgs)
		If ASPxFileManager1.SelectedFile IsNot Nothing Then
			Session("lastOpenedFilePath") = ASPxFileManager1.SelectedFile.FullName
			OpenFile()
		End If
	End Sub

	Private Overloads Sub OpenFile()
		If Session("lastOpenedFilePath") IsNot Nothing Then
			Dim fileRelativePath As String = Session("lastOpenedFilePath").ToString()
			Dim fileExtension As String = Path.GetExtension(fileRelativePath).ToLower()
			Dim fileFullPath As String = Server.MapPath(fileRelativePath)

			Select Case fileExtension
				Case ".docx"
					OpenWordFile(fileFullPath)
				Case ".xlsx"
					OpenExcelFile(fileFullPath)
				Case ".jpg"
					OpenImageFile(fileRelativePath)
				Case ".pdf"
					OpenPdfFile(fileRelativePath)
				Case Else
					DisplayUnknownFileError(fileRelativePath)
			End Select
		End If
	End Sub

	Private Sub OpenWordFile(ByVal fileFullPath As String)
		Dim richEdit As New ASPxRichEdit()
		richEdit.ID = "richEdit"
		ASPxPopupControl1.Controls.Add(richEdit)
		richEdit.Open(fileFullPath)
	End Sub

	Private Sub OpenExcelFile(ByVal fileFullPath As String)
		Dim spreadsheet As New ASPxSpreadsheet()
		spreadsheet.ID = "spreadsheet"
		ASPxPopupControl1.Controls.Add(spreadsheet)
		spreadsheet.Open(fileFullPath)
	End Sub

	Private Sub OpenImageFile(ByVal fileRelativePath As String)
		Dim image As New ASPxImage()
		image.ID = "image"
		ASPxPopupControl1.Controls.Add(image)
		image.ImageUrl = fileRelativePath
	End Sub

	Private Sub OpenPdfFile(ByVal fileRelativePath As String)
		Dim hyperLink As New ASPxHyperLink()
		hyperLink.ID = "hyperLink"
		ASPxPopupControl1.Controls.Add(hyperLink)
		hyperLink.Text = "Download " & Path.GetFileName(fileRelativePath)
		hyperLink.NavigateUrl = fileRelativePath
		hyperLink.Target = "_blank"
	End Sub

	Private Sub DisplayUnknownFileError(ByVal fileFelativePath As String)
		Dim label As New ASPxLabel()
		label.ID = "label"
		ASPxPopupControl1.Controls.Add(label)
		label.Text = "Unknown file type: " & Path.GetExtension(fileFelativePath)
	End Sub
End Class