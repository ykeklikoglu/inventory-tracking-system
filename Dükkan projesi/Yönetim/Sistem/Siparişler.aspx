<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Siparişler.aspx.cs" Inherits="Dükkan_projesi.Yönetim.Sistem.Siparişler" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
     
    <asp:gridview id="GridView1" runat="server" showfooter="True" onrowcommand="GridView1_RowCommand" onrowcreated="GridView1_RowCreated">
        <Columns>
            <asp:CommandField ShowSelectButton="True" />
        </Columns>
        <EmptyDataTemplate>
            boş
        </EmptyDataTemplate>
    </asp:gridview></form>  
    
    </div>
    </form>
</body>
</html>
