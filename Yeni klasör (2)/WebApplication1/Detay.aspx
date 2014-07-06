<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Detay.aspx.cs" Inherits="WebApplication1.Detay" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="css/Forms.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .txt
        {
            font-size: 15px;
        }
        .style6
        {
            width: 90px;
        }
        .style7
        {
            width: 104px;
        }
        .style8
        {
            width: 23px;
        }
        .style9
        {
            width: 100px;
            border: 0px solid #c0c0c0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <table id="mytable" cellspacing="0" summary="The technical specifications of the Apple PowerMac G5 series">
        <caption>
            &nbsp;&nbsp;&nbsp;&nbsp;
        </caption>
        <tr>
            <th class="style8" style="background-color: White;" rowspan="5">
                <asp:Image ID="Image1" runat="server" Height="134px" Width="156px" />
            </th>
            <th class="style6">
                Urun Adi
            </th>
            <td class="spec">
                <asp:Label ID="lblUrunAdi" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th class="style6">
                Kategori
            </th>
            <td class="spec">
                <asp:Label ID="lblKategori" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th class="style6">
                Fiyat
            </th>
            <td class="spec">
                <asp:Label ID="lblFiyat" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th class="style6">
                Stok Miktari
            </th>
            <td class="spec">
                <asp:Label ID="lblStokMiktari" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <th class="style6">
                Acıklama
            </th>
            <td class="spec" valign="top">
                <asp:Label ID="lblAciklama" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1" colspan="2" rowspan="3">
                <marquee direction="up" style="height: 86px">
Hi There! 
</marquee>
            </td>
            <td class="spec">
                <table class="style9">
                    <tr>
                        <td>
                            <asp:TextBox CssClass="txt" Height="39px" Width="50px" ID="TextBox1" runat="server" Font-Size="Larger">1</asp:TextBox>
                        </td>
                        <td>
                            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/ButtonSale.jpg"
                                OnClick="ImageButton1_Click" Height="39px" Width="137px" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="spec">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="spec">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="style7" colspan="3">
                &nbsp;
            </td>
        </tr>
    </table>
    <div>
    </div>
    </form>
</body>
</html>
