<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Dükkan_projesi.Yönetim.Giriş.Login" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 44%;
            height: 219px;
        }
        .style2
        {
            font-size: large;
            color: #FFFFFF;
            width: 249px;
        }
        .style3
        {
            font-size: medium;
        }
        .style4
        {
            font-size: x-large;
        }
    </style>
</head>
<body style="background-color: #2D3E5C">
    <form id="form1" runat="server">
    <div align="center" 
        
        style="height: 646px; width: 1259px; margin-right: 1px; margin-top: 0px; background-color: #2D3E5B; color: #FF3300; font-size: xx-large; font-family: 'Times New Roman', Times, serif;">
    
        <br />
        <br />
        <br />
        <br />
        <br />
        <em>Hake </em><span class="style4">Giriş Sistemi</span><br />
        <br />
        <table class="style1">
            <tr>
                <td class="style2">
                    Kullanıcı Adı:</td>
                <td>
                    <asp:TextBox ID="kulanıcıadı" runat="server" MaxLength="16"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Şifre</td>
                <td>
                    <asp:TextBox ID="şifre" runat="server" MaxLength="16" TextMode="Password"></asp:TextBox>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Button ID="Button1" runat="server" Text="Tamam" onclick="Button1_Click" />
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;</td>
                <td>
                    <asp:Label ID="uyarı" runat="server" 
                        style="font-size: large; font-weight: 700; text-decoration: underline" 
                        Text="Kullanıcı adı veya Şifre hatalı!" Visible="False"></asp:Label>
                    <br />
                    <span class="style3">Ziyaret Sayısı:<asp:Label ID="Label_visits" runat="server" 
                        Text="Label"></asp:Label>
                    </span></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
