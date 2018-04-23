<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title>FileManagerOpenEdit</title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<dx:ASPxFileManager ID="ASPxFileManager1" runat="server">
				<Settings RootFolder="~/Files" ThumbnailFolder="~/Thumbnails" AllowedFileExtensions=".xlsx,.docx,.pdf,.jpg,.dat" />
				<ClientSideEvents SelectedFileOpened="function(s, e) { popup.PerformCallback(); }" />
			</dx:ASPxFileManager>

			<dx:ASPxPopupControl ID="ASPxPopupControl1" runat="server" ClientInstanceName="popup" 
				PopupVerticalAlign="WindowCenter" PopupHorizontalAlign="WindowCenter"
				AllowDragging="true" HeaderText="Document" AllowResize="false"
				ShowFooter="true" FooterText="" Modal="True" CloseAction="CloseButton" 
				OnWindowCallback="ASPxPopupControl1_WindowCallback">
				<SettingsLoadingPanel Enabled="false" />
				<ClientSideEvents BeginCallback="function(s, e) { 
					lp.Show(); 
				}" 
				EndCallback="function(s, e) { 
					lp.Hide(); 
					s.Show(); 
				}" />
			</dx:ASPxPopupControl>

			<dx:ASPxLoadingPanel ID="ASPxLoadingPanel1" runat="server" ClientInstanceName="lp" Modal="True" />
		</div>
	</form>
</body>
</html>