<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sepetim.aspx.cs" Inherits="WebApplication1.Sepetim" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Forms.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style7
        {
            width: 100%;
            border: 1px solid #c0c0c0;
        }
        .style8
        {
            width: 272px;
        }
        .style9
        {
            width: 24px;
            height: 17px;
        }
        .style10
        {
            width: 25px;
            height: 25px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <br />
    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="~/Default.aspx">&lt;&lt; Anasayfaya Dön</asp:LinkButton>
    <br />
    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" 
        EnableModelValidation="True" onrowdeleting="GridView1_RowDeleting" 
        onrowupdating="GridView1_RowUpdating">
        <Columns>
            <asp:TemplateField>
                <ItemTemplate>
                    <img alt="" width="30" height="30" src='<%# "/InputFiles/images/"+ Eval("Resim") %>' />
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Adet">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Width="40px" 
                        Text='<%# Eval("TalepMiktar") %>'></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update">Güncelle</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="UrunAdi" DataField="UrunAdi" />
            <asp:BoundField HeaderText="Fiyat" DataField="Fiyat" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Delete">Kaldır</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <table class="style7">
        <tr>
            <td class="style8">
                &nbsp;</td>
            <td>
                Toplam Fiyat : 
                <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style8">
                <img alt="" class="style10" src="images/Check.png" /><asp:LinkButton 
                    ID="LinkButton5" runat="server" onclick="LinkButton5_Click" 
                    onclientclick="return confirm('Onaylamak istiyormusun?')">Sepeti Onayla</asp:LinkButton>
            </td>
            <td>
                <img alt="" class="style9" src="images/document.png" /><asp:LinkButton 
                    ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Temizle</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
