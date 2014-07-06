<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SepeteEkle.aspx.cs" Inherits="Dükkan_projesi.Yönetim.SepeteEkle" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style2
        {
            font-size: medium;
        }
        .style3
        {
            font-size: large;
        }
    </style>
</head>
<body style="background-color: #2D3E5B">
    <form id="form1" runat="server">
    <div align="center" style="height: 1328px">
    
        <asp:TextBox ID="TextBox1" runat="server" AutoPostBack="True" CssClass="style3" 
            Height="25px" ontextchanged="TextBox1_TextChanged" Width="181px">Ürün İsmini Giriniz.</asp:TextBox>
        <br class="style2" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" 
            BackColor="White" BorderColor="#336666" BorderStyle="Double" BorderWidth="3px" 
            CellPadding="4" AllowPaging="True" 
            AllowSorting="True" style="margin-right: 0px" PageSize="20">
            <Columns>
                <asp:BoundField HeaderText="UrunID" DataField="UrunID"  />
                <asp:BoundField HeaderText="Urun Kodu" DataField="Kodu"/>
                <asp:BoundField HeaderText="Urun İsim" DataField="UrunAd"/>
                <asp:BoundField HeaderText="Malzeme" DataField="Malzeme"/>
                <asp:BoundField HeaderText="Fiyat" DataField="Fiyat"/>
                <asp:BoundField HeaderText="İstanbul Cad Stok" DataField="Stokİstcad"/>
                <asp:BoundField HeaderText="Hasköy Stok" DataField="StokHasköy">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Esenboga Stok" DataField="StokEsenboga">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="True" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Cubuk Stok" DataField="StokCubuk">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:BoundField HeaderText="Toplam Stok" DataField="Stok">
                <FooterStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                </asp:BoundField>
                <asp:TemplateField HeaderText="Adet" ShowHeader="False">
                    <ItemTemplate>
                        <asp:TextBox ID="TextBox_Adet" runat="server" Height="26px" 
                            style="margin-bottom: 0px" Width="34px" Rows="1">0</asp:TextBox>
                        Adet
                        <br />
                        <asp:RegularExpressionValidator ID="validatorAdet" runat="server" 
                            ControlToValidate="TextBox_Adet" ErrorMessage="Bir Tam Sayı Giriniz." 
                            style="color: #FF0000; font-style: italic; font-size: small" 
                            ValidationExpression="\d?\d?\d?\d?\d?\d?\d?"></asp:RegularExpressionValidator>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                Ürün Yok
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
    
        <asp:Label ID="Label_Uyarı" runat="server" ForeColor="Red" 
            style="font-size: large; text-decoration: underline" 
            Text="Negatif Değer Girdiniz!" Visible="False"></asp:Label>
        <br />
        <br />
    
        <asp:Button ID="Button_tamamla" runat="server" onclick="Button_tamamla_Click" 
            Text="Tamamla" />
    
    </div>
    </form>
</body>
</html>
