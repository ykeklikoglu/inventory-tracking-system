<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sepetim.aspx.cs" Inherits="Dükkan_projesi.Yönetim.Sepetim" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="css/Forms.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style7
        {
            width: 100%;
            border: 1px solid #c0c0c0;
        }
        .style9
        {
            width: 24px;
            height: 17px;
        }
        .style10
        {
            width: 25px;
            height: 31px;
        }
        .style12
        {
            width: 51px;
            height: 27px;
        }
        .style13
        {
            width: 301px;
            height: 65px;
        }
        .style14
        {
            height: 65px;
            font-size: x-large;
            color: #FF0000;
        }
        #form1
        {
            text-align: center;
        }
        .style15
        {
            width: 100%;
        }
        .style16
        {
            width: 169px;
        }
        .style17
        {
            color: #FFFFFF;
        }
        .style11
        {
            color: #FF3300;
            font-size: x-large;
        }
        .style18
        {
            width: 261px;
        }
        .style19
        {
            width: 412px;
        }
        .style20
        {
            font-size: medium;
        }
        .style21
        {
            color: #FFFFFF;
            font-size: medium;
        }
        .style22
        {
            width: 301px;
        }
    </style>
</head>
<body style="background-color: #2D3E5B">
    <form id="form1" runat="server">
    <br />
    <asp:LinkButton ID="LinkButton4" runat="server" PostBackUrl="/Yönetim/Sistem/Masaüstü.aspx" 
        style="color: #FFFFFF" onclick="LinkButton4_Click1">&lt;&lt; Anasayfaya Dön</asp:LinkButton>
    <br />
    <table class="style15">
        <tr>
            <td class="style16">
                &nbsp;</td>
            <td>
    <asp:GridView ID="GridView1"  runat="server" AutoGenerateColumns="False" onrowdeleting="GridView1_RowDeleting" 
        onrowupdating="GridView1_RowUpdating" Width="841px" BackColor="White" 
        BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" CellPadding="4" 
                    style="text-align: left">
        <Columns>
            <asp:TemplateField HeaderText="Urun ID">
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("UrunID") %>'></asp:Label>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("UrunID") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Adet">
                <ItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Width="40px" 
                        Text='<%# Eval("TalepMiktar") %>'></asp:TextBox>
                    <asp:LinkButton ID="LinkButton1" runat="server" CommandName="Update" 
                        style="color: #000000">Güncelle</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="UrunAdı" DataField="UrunAd" />
            <asp:BoundField HeaderText="Malzeme" DataField="Malzeme"/>
<asp:TemplateField HeaderText="Fiyat">
<ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Fiyat") %>'></asp:Label>
                
</ItemTemplate>

    <EditItemTemplate>
        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("Fiyat") %>'></asp:TextBox>
    </EditItemTemplate>
</asp:TemplateField>
            <asp:TemplateField HeaderText="Hasköy Stok">
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("StokHasköy") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("StokHasköy") %>'></asp:Label>
                    <asp:ListBox ID="ListBox1" runat="server">
                        <asp:ListItem Selected="True">0</asp:ListItem>
                    </asp:ListBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="istanbulcad Stok">
            <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Stokİstcad") %>'></asp:Label>
                    <asp:ListBox ID="ListBox2" runat="server" Height="70px" Width="34px">
                        <asp:ListItem Selected="True">0</asp:ListItem>
                    </asp:ListBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("Stokİstcad") %>'></asp:TextBox>
                </EditItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Cubuk Stok">
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("StokCubuk") %>'></asp:Label>
                    <asp:ListBox ID="ListBox3" runat="server">
                        <asp:ListItem Selected="True">0</asp:ListItem>
                    </asp:ListBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("StokCubuk") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Esenboga Stok">
                
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("StokEsenboga") %>'></asp:Label>
                    <asp:ListBox ID="ListBox4" runat="server" Height="70px" Width="34px">
                        <asp:ListItem Selected="True">0</asp:ListItem>
                    </asp:ListBox>
                </ItemTemplate>
                <EditItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("StokEsenboga") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
            <asp:BoundField HeaderText="Toplam Stok" DataField="Stok" >
            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" ForeColor="Red" />
            </asp:BoundField>
            <asp:TemplateField HeaderText="Kaldır">
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton3" runat="server" CommandName="Delete" 
                        style="color: #000000">Kaldır</asp:LinkButton>
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
            SEPET BOŞ&nbsp;<br /> 
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="White" 
                NavigateUrl="~/Yönetim/SepeteEkle.aspx" 
                style="font-size: x-large; color: #FF0000; font-style: italic;">Sepete Ekle</asp:HyperLink>
        </EmptyDataTemplate>
        <FooterStyle BackColor="White" ForeColor="#333333" />
        <HeaderStyle BackColor="#336666" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#336666" ForeColor="White" HorizontalAlign="Center" />
        <RowStyle BackColor="White" ForeColor="#333333" />
        <SelectedRowStyle BackColor="#339966" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F7F7F7" />
        <SortedAscendingHeaderStyle BackColor="#487575" />
        <SortedDescendingCellStyle BackColor="#E5E5E5" />
        <SortedDescendingHeaderStyle BackColor="#275353" />
    </asp:GridView>
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="Label_not" runat="server" 
        style="font-size: x-large; font-style: italic; color: #FF3300; font-weight: 700; background-color: #2D3E5B" 
        Text="Bilgilerinizi Kontrol Ediniz." Visible="False"></asp:Label>
    <br />
    <table class="style7">
        <tr>
            <td class="style13">
                &nbsp;</td>
            <td class="style14">
                <table class="style15">
                    <tr>
                        <td class="style18">
                            &nbsp;</td>
                        <td align="left" class="style19">
                <span class="style11">Toplam Fiyat : 
                                </span> 
                <asp:Label ID="Label1" runat="server" Text="0" CssClass="style11"></asp:Label>
            &nbsp;TL<br />
                            <span class="style21">İskonto :%</span><asp:TextBox ID="TextBoxİskonto" 
                                runat="server" BorderStyle="Double" CssClass="style21" Font-Size="Small" 
                                ForeColor="Red" Height="21px" MaxLength="5" Width="31px" 
                                AutoPostBack="True" ontextchanged="TextBoxİskonto_TextChanged">0</asp:TextBox>
                            <span class="style17">
                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                                ControlToValidate="TextBoxİskonto" CssClass="style20" 
                                ErrorMessage="Lütfen 0-100 arası bir değer giriniz." 
                                style="font-weight: 700; font-style: italic" 
                                ValidationExpression="\d?\d?(,\d?\d?)?"></asp:RegularExpressionValidator>
                            <br class="style20" />
                            <span class="style20">İskonto Tutarı:<asp:Label ID="Labelİskonto" runat="server" 
                                Text="0"></asp:Label>
&nbsp;TL</span><br />
                            </span>İskontolu Fiyatı:<asp:Label ID="LabelTotal" runat="server" Text="0"></asp:Label>
&nbsp;TL</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="style22">
                <img alt="" class="style10" src="../İmages/Check.png" /><asp:LinkButton 
                    ID="LinkButton5" runat="server" onclick="LinkButton5_Click" 
                    onclientclick="return confirm('Onaylamak istiyormusun?')" 
                    style="color: #FFFFFF; font-size: xx-large; font-weight: 700;">Sepeti Onayla</asp:LinkButton>
                <img alt="" class="style12" src="../İmages/Shopping.png" /></td>
            <td>
                <img alt="" class="style9" src="../İmages/document.png" /><asp:LinkButton 
                    ID="LinkButton2" runat="server" onclick="LinkButton2_Click" 
                    style="color: #FFFFFF">Temizle</asp:LinkButton>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>
