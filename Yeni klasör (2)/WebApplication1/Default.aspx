<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<%@ Register src="UserControl.ascx" tagname="UserControl" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Forms.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
    
        .style1
        {
            width: 36px;
        }
        .style2
        {
            width: 8px;
        }
        .style3
        {
            width: 257px;
        }
        .style4
        {
            width: 317px;
        }
        .style5
        {
            width: 458px;
        }
        .style6
        {
            width: 29px;
            height: 22px;
        }
        .style7
        {
            width: 100%;
            border: 1px solid #c0c0c0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="height: 456px; width: 712px">
        <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
            <caption>
                    <img alt="" class="style6" src="images/Shopping.png" /><asp:LinkButton 
                        ID="LinkButton2" runat="server" PostBackUrl="~/Sepetim.aspx">Sepetim</asp:LinkButton>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Ara</asp:LinkButton>
                    &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox1" runat="server" Width="197px"></asp:TextBox>
            </caption>
            <uc1:UserControl ID="UserControl1" runat="server" />
            <tr>
                <th class="style2">
                </th>
                <th class="style5">
                    Urun AdI
                </th>
                <th class="style4">
                    Fiyat
                </th>
                <th class="style3">
                    Kategori
                </th>
                <th>
                    &nbsp;
                </th>
            </tr>
            <asp:Repeater ID="Repeater1" runat="server" 
                onitemcommand="Repeater1_ItemCommand">
                <ItemTemplate>
                    <tr>
                        <th scope="row" abbr="G5 Processor" class="specalt" style="width: 8px">
                            <img alt="" class="style1" src='<%# "/InputFiles/images/"+ Eval("Resim") %>' />
                        </th>
                        <td class="alt" style="width: 458px">
                            <%# Eval("UrunAdi") %>
                        </td>
                        <td class="alt" style="width: 317px">
                            <%# Convert.ToDecimal(Eval("Fiyat")).ToString("C") %>
                        </td>
                        <td class="alt" style="width: 257px">
                            <%# Eval("Kategori") %>
                        </td>
                        <td class="alt">
                            <asp:LinkButton ID="lnkDetay" CommandArgument='<%# Eval("UrunID") %>' runat="server">Detay</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </table>
    </div>
    </form>
</body>
</html>
