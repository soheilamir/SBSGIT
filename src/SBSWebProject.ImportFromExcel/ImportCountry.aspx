<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImportCountry.aspx.cs" Inherits="SBSWebProject.ImportFromExcel.ImportCountry" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FileUpload ID="FileUpload1" runat="server" />
        <asp:Button ID="bttnImportCountry" runat="server" Text="Button" />
    </div>
    </form>
</body>
</html>
