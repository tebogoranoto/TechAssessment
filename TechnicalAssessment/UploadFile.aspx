<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadFile.aspx.cs" Inherits="TechnicalAssessment.UploadFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" />
</head>
<body>
    
    <form id="form1" runat="server">
        <div class="Box">
            <h2>Calculate the value of answer</h2>
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:FileUpload ID="FileUpload1" runat="server" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Upload File" />
            <br />
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
        
        <p>
            <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="View Data" />
        </p>
        <asp:GridView ID="GridView1" runat="server">
        </asp:GridView>
        </div>
    </form>
</body>
</html>
