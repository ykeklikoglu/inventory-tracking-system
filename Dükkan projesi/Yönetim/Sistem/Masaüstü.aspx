<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Train.Master" AutoEventWireup="true" CodeBehind="Masaüstü.aspx.cs" Inherits="Dükkan_projesi.Yönetim.Sistem.Masaüstü" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style6
        {
            width: 261px;
        }
        .style8
        {
            width: 290px;
            font-weight: 700;
            font-size: x-large;
            color: #FFFFFF;
            font-style: italic;
            background-color: #FF5151;
        height: 114px;
    }
        .style9
        {
            color: #FFFFFF;
            width: 260px;
            font-style: italic;
        height: 114px;
    }
        .style10
        {
            width: 260px;
        height: 82px;
    }
        .style11
        {
            color: #FFFFFF;
            font-style: italic;
        height: 114px;
            background-color: #008C8C;
        }
        .style12
        {
            width: 290px;
            font-family: Arial;
        height: 78px;
    }
        .style13
        {
            width: 261px;
            font-style: italic;
        height: 114px;
    }
    .style14
    {
        width: 222px;
        font-size: x-large;
        font-weight: 700;
        color: #FFFFFF;
        font-family: Arial;
        height: 78px;
        background-color: #3366FF;
    }
    .style15
    {
        width: 260px;
        height: 78px;
    }
    .style16
    {
        height: 78px;
    }
    .style17
    {
        width: 261px;
        height: 82px;
        background-color: #014051;
    }
    .style18
    {
        height: 82px;
    }
    .style19
    {
        width: 290px;
        height: 101px;
        font-size: x-large;
        color: #FFFFFF;
        background-color: #7C00EC;
    }
    .style20
    {
        width: 290px;
        height: 82px;
    }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p></p>
    <asp:Label ID="Label1" runat="server" BorderStyle="Dotted" 
        style="font-weight: 700; font-size: x-large; color: #FFFFFF" Text="Label" 
        Visible="False"></asp:Label>
    <p></p><br />
        <table class="style2" style="height: 386px">
            <tr>
                <td class="style14">
                    <asp:HyperLink ID="Satışyap" runat="server" Font-Underline="False" 
                        NavigateUrl="~/Yönetim/Sistem/Satıs.aspx" style="color: #FFFFFF">Satış yap</asp:HyperLink>
                </td>
                <td class="style12" 
                    
                    
                    style="color: #FFFFFF; font-size: x-large; font-weight: 700; background-color: #FF7A22" 
                    align="center" valign="middle">
                    <asp:HyperLink ID="HyperLink1" runat="server">Siparişler</asp:HyperLink>
                </td>
                <td class="style12" 
                    
                    
                    style="color: #FFFFFF; font-size: x-large; font-weight: 700; background-color: #E78E8C" 
                    align="center" valign="middle">
                    <asp:HyperLink ID="HyperLink8" runat="server">Ürünler</asp:HyperLink>
                </td>
                <td class="style16">
                    </td>
            </tr>
            <tr>
                <td class="style13" 
                    
                    
                    style="color: #FFFFFF; font-weight: 700; font-size: x-large; background-color: #FF4415">
                    <asp:HyperLink ID="İstanbulCaddesi" runat="server">İstanbul Caddesi</asp:HyperLink>
                </td>
                <td class="style8" align="center" valign="middle">
                    <asp:HyperLink ID="Esenboğa" runat="server">Esenboğa</asp:HyperLink>
                </td>
                <td class="style9" style="font-size: x-large; background-color: #669900">
                    <strong>
                    <asp:HyperLink ID="HyperLink4" runat="server">Çubuk</asp:HyperLink>
                    </strong></td>
                <td class="style11" style="font-size: x-large; background-color: #666699">
                    <strong>
                    <asp:HyperLink ID="HyperLink5" runat="server">Hasköy</asp:HyperLink>
                    </strong></td>
            </tr>
            <tr>
                <td class="style17">
                    </td>
                <td class="style19" align="center" valign="middle">
                    &nbsp;<asp:HyperLink ID="HyperLink6" runat="server">Toplam Stoklar</asp:HyperLink>
                </td>
                <td class="style11">
                    <asp:HyperLink ID="HyperLink7" runat="server" Font-Italic="False" 
                        style="font-size: x-large; font-weight: 700; color: #FFFFFF;" 
                        Font-Underline="False" NavigateUrl="~/Yönetim/Giriş/Login.aspx">Çıkış</asp:HyperLink>
                </td>
                <td class="style18">
                    </td>
            </tr>
            <tr>
                <td class="style10">
                    &nbsp;</td>
                <td class="style20" align="center" valign="middle">
                    &nbsp;</td>
                <td class="style10">
                    &nbsp;</td>
                <td class="style18">
                    &nbsp;</td>
            </tr>
        </table>
</p>
</asp:Content>
