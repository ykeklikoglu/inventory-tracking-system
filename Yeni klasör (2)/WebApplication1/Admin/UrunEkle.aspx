<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UrunEkle.aspx.cs" Inherits="WebApplication1.Admin.UrunEkle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="../css/Forms.css" rel="stylesheet" type="text/css" />
    <style type="text/css">

        .style6
        {
            width: 107px;
        }
        .style7
        {
        }
        .style8
        {
            width: 67px;
        }
    </style>
</head>
<body>
    <form id="form2" runat="server">
    <div>
        <asp:MultiView ID="MultiView1" runat="server" ActiveViewIndex="0">

            <asp:View ID="View1" runat="server">
            <table id="mytable" cellspacing="0" 
            summary="The technical specifications of the Apple PowerMac G5 series">
            <caption>
                &nbsp;&nbsp;&nbsp;&nbsp;
            </caption>
            <tr>
                 <th class="style6">
                     URun ADI</th>
                <td class="style8">
                    <asp:TextBox ID="txtUrunAdi" runat="server" Width="220px"></asp:TextBox>
                </td>
                <td class="spec" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                 <th class="style6">
                     Kategori</th>
                <td class="style8">
                    <asp:DropDownList ID="DropDownList1" runat="server"  Width="220px">
                    </asp:DropDownList>
                </td>
                <td class="spec" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                 <th class="style6">
                     fIyat</th>
                <td class="style8">
                    <asp:TextBox ID="txtFiyat" runat="server" Width="220px"></asp:TextBox>
                 </td>
                <td class="spec" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                 <th class="style6">
                     Resim</th>
                <td class="style8">
                    <asp:FileUpload ID="FileUpload1" Width="220px" runat="server" />
                 </td>
                <td class="spec" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                 <th class="style6">
                     stok miktari</th>
                <td class="style8">
                    <asp:TextBox ID="txtStokMiktari" runat="server" Width="220px"></asp:TextBox>
                 </td>
                <td class="spec" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                 <th class="style6" valign="top">
                     açıklama</th>
                <td class="style8">
                    <asp:TextBox ID="txtAciklama" runat="server" Width="220px" Height="110px" 
                        TextMode="MultiLine"></asp:TextBox>
                 </td>
                <td class="spec" colspan="2">
                    &nbsp;</td>
            </tr>
            <tr>
                 <th class="style6">
                     &nbsp;</th>
                <td class="style8">
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Kaydet</asp:LinkButton>
                 </td>
                <td class="spec">
                    &nbsp;</td>
                <td class="spec">
                    &nbsp;</td>
            </tr>
            <tr>
                 
                <td class="style7" colspan="4">
                    <asp:Label ID="lblMesaj" runat="server"></asp:Label>
                </td>
            </tr>
            </table>
            </asp:View>



            <asp:View ID="View2" runat="server">
                Tebrikler&nbsp; Ürün Başarılı bir şekikde eklemiştir.<br /> Tekrar ürün eklemek 
                istiyorsanız.
                <asp:LinkButton ID="LinkButton2" runat="server" onclick="LinkButton2_Click">Ürün Ekle</asp:LinkButton>
            </asp:View>

        </asp:MultiView>
    </div>
    </form>
</body>
</html>
