<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Document.aspx.cs" Inherits="eShopping.WebForms.FileHandler.Document"
    ValidateRequest="false" EnableViewStateMac="false" ViewStateEncryptionMode="Never"  %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Render Doc file as Html</title>
    <style type="text/css">
        .div100
        {
            width: 100%;
            margin: auto 10px;
        }
        .right
        {
            text-align: left;
        }
        .spanHeading
        {
            font-size: 13px;
            font-family: Verdana;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <CKEditor:CKEditorControl ID="editor" runat="server" Height="500" EnableTheming="true">
    </CKEditor:CKEditorControl>
    <div class="div100 right">
        <span class="spanHeading">Upload document</span>
        <asp:FileUpload ID="flDocument" runat="server" onChange="javascript:document.forms[0].submit();" />
    </div>
    </form>
</body>
</html>
