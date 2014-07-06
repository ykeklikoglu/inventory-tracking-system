<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Satıs.aspx.cs" Inherits="Dükkan_projesi.Yönetim.Sistem.Satıs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 82%;
            height: 321px;
        }
        .style2
        {
            color: #A76CFF;
            width: 310px;
        }
        .style3
        {
            color: #936CFF;
            width: 310px;
        }
        .style4
        {
        }
        .style6
        {
            width: 310px;
        }
        .style7
        {
            width: 782px;
        }
        .style8
        {
            color: #FF3300;
        }
        .style9
        {
            text-align: center;
        }
        .style10
        {
            width: 782px;
            text-align: center;
        }
        </style>
</head>
<body style="height: 1209px; background-color: #F0F0F0" bgcolor="#374e73">
    <form id="form1" runat="server">
    <div style="text-align: center; font-size: large">
    
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" ForeColor="Red" 
            style="font-size: xx-large" Text="------SATIŞ------"></asp:Label>
        <br />
    <asp:LinkButton ID="LinkButton4" runat="server" 
        style="color: #3333CC" onclick="LinkButton4_Click">&lt;&lt; Anasayfaya Dön</asp:LinkButton>
        <br />
        <table align="center" class="style1">
            <tr>
                <td class="style6" style="color: #FF3300">
                    Müşteri Seç:</td>
                <td align="center" class="style7" valign="middle">
                    <br />
     
    <asp:gridview id="GridView3" runat="server" showfooter="True" DataKeyNames="ID" 
                        BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
                        CellPadding="4" ForeColor="Black" GridLines="None" 
                        onselectedindexchanged="GridView3_SelectedIndexChanged" Height="16px" 
                        Visible="False" Width="647px">
        <AlternatingRowStyle BackColor="White" />
        <Columns>
            <asp:TemplateField ShowHeader="False">
                <ItemTemplate>
                    <asp:ImageButton ID="ImageButton1" runat="server" CausesValidation="False" 
                        CommandName="Select" Height="26px" ImageUrl="~/İmages/Check.png" 
                        style="text-align: right" Text="Select" Width="32px" />
                </ItemTemplate>
                <FooterStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <HeaderStyle HorizontalAlign="Left" VerticalAlign="Middle" />
                <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" />
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            Müşteri yok
        </EmptyDataTemplate>
        <FooterStyle BackColor="#CCCC99" />
        <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
        <RowStyle BackColor="#F7F7DE" />
        <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#FBFBF2" />
        <SortedAscendingHeaderStyle BackColor="#848384" />
        <SortedDescendingCellStyle BackColor="#EAEAD3" />
        <SortedDescendingHeaderStyle BackColor="#575357" />
    </asp:gridview>
                    <br />
                </td>
            </tr>
            <tr>
                <td class="style6" style="color: #FF3300">
                    Müşteri ID:</td>
                <td align="center" class="style7" valign="middle">
                    <asp:TextBox ID="TextBox_ID" runat="server" Width="60px" BackColor="#2D3E5B" 
                        BorderStyle="Solid" Font-Bold="True" Font-Names="Harlow Solid Italic" 
                        ForeColor="White" Height="25px" ReadOnly="True" 
                        
                        style="font-size: large; text-align: center; color: #FF0000; background-color: #FFFFFF;" 
                        BorderColor="Red"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6" style="color: #FF3300">
                    Müşteri İsim Soyisim:</td>
                <td align="center" class="style7" valign="middle">
                    <asp:TextBox ID="TextBox_isim" runat="server" Width="181px" MaxLength="40" 
                        AutoPostBack="True" ontextchanged="TextBox_isim_TextChanged"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6" style="color: #FF3300">
                    Müşteri TcNo</td>
                <td align="center" class="style7" valign="middle">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox_TcNo" runat="server" MaxLength="11"></asp:TextBox>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator1" 
                        runat="server" ControlToValidate="TextBox_TcNo" 
                        ErrorMessage="Tc no 11 haneli bir rakam olmalıdır." 
                        style="color: #FF0000; font-size: medium; text-decoration: underline" 
                        ValidationExpression="\d\d\d\d\d\d\d\d\d\d\d"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style6" style="color: #FF3300">
                    Müşteri Telefon Numarası:</td>
                <td align="center" class="style7" valign="middle">
                    &nbsp;<asp:TextBox ID="TextBox_TelNo" runat="server" 
                        Height="22px" Width="128px" MaxLength="19"></asp:TextBox>
                &nbsp;</td>
            </tr>
            <tr>
                <td class="style6" style="color: #FF3300">
                    Müşteri Adresi:</td>
                <td align="center" class="style7" valign="middle">
                    <asp:TextBox ID="TextBox_adres" runat="server" TextMode="MultiLine" 
                        MaxLength="120" Height="54px" Width="336px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6" style="color: #FF3300">
                    Vergi Dairesi</td>
                <td align="center" class="style7" valign="middle">
                    <asp:TextBox ID="TextBox_VergiAdrs" runat="server" MaxLength="15"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style6" style="color: #FF3300">
                    Vergi No:</td>
                <td align="center" class="style7" valign="middle">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:TextBox ID="TextBox_VergiNo" runat="server" MaxLength="11"></asp:TextBox>
                &nbsp;<asp:RegularExpressionValidator ID="RegularExpressionValidator3" 
                        runat="server" ControlToValidate="TextBox_VergiNo" 
                        ErrorMessage="Bu kutu rakamlala doldurulmalıdır." 
                        style="color: #FF0000; font-size: medium; text-decoration: underline" 
                        ValidationExpression="\d?\d?\d?\d?\d?\d?\d?\d?\d?\d?\d?"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Personel :</td>
                <td align="center" class="style7" valign="middle">
                    &nbsp;<asp:Button ID="Button_Sıfırla" runat="server" BorderStyle="None" 
                        onclick="Button_Sıfırla_Click" 
                        style="color: #FFFFFF; font-style: italic; text-decoration: underline; background-color: #2D3E5B" 
                        Text="Bilgileri Sıfırla" Visible="False" Width="187px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True">
                    </asp:DropDownList>
                &nbsp;&nbsp;&nbsp;<asp:Button ID="Button_güncelle" runat="server" BorderStyle="None" 
                        onclick="Button2_Click" 
                        style="color: #FFFFFF; font-style: italic; text-decoration: underline; background-color: #2D3E5B" 
                        Text="Müşteri Bilgileri Güncelle" Visible="False" Width="171px" />
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Teslim Tarihi:</td>
                <td align="center" class="style7" valign="middle">
                    <asp:Calendar ID="Calendar1" runat="server" BackColor="#2D3E5B" 
                        BorderColor="White" BorderWidth="1px" Font-Names="SimSun" Font-Size="9pt" 
                        ForeColor="White" Height="107px" NextPrevFormat="FullMonth" Width="145px" 
                        SelectedDate="07/18/2012 11:18:56" 
                        onselectionchanged="Calendar1_SelectionChanged">
                        <DayHeaderStyle Font-Bold="True" Font-Size="8pt" />
                        <NextPrevStyle Font-Bold="True" Font-Size="8pt" ForeColor="#333333" 
                            VerticalAlign="Bottom" />
                        <OtherMonthDayStyle ForeColor="#999999" />
                        <SelectedDayStyle BackColor="#333399" ForeColor="White" />
                        <TitleStyle BackColor="White" BorderColor="Black" BorderWidth="4px" 
                            Font-Bold="True" Font-Size="12pt" ForeColor="#333399" />
                        <TodayDayStyle BackColor="#CCCCCC" />
                    </asp:Calendar>
                    <asp:Label ID="Label_takvim" runat="server" 
                        style="color: #FF6600; font-style: italic; font-size: large; text-decoration: underline; background-color: #F0F0F0" 
                        Text="Lütfen ileri bir tarih seçiniz." 
                        Visible="False"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    Alışveriş Sepeti:</td>
                <td class="style10" valign="middle">
                    <br />
                    <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
                        style="color: #FFFFFF; font-weight: 700; font-size: medium; background-color: #2D3E5B" 
                        Text="Sepete Git" />
                    <br />
                    <asp:GridView 
                        ID="GridView1" runat="server" AutoGenerateColumns="False" 
                        AllowPaging="True" AllowSorting="True" Font-Size="X-Small" 
                        PageSize="6">
                        <Columns>
                            <asp:TemplateField HeaderText="Urun ID">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("UrunID") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("UrunID") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                  
                            <asp:BoundField HeaderText="Urun Ad" DataField="UrunAd" />
                      
                            <asp:BoundField HeaderText="Talep Miktarı" DataField="TalepMiktar" />
                   
                            <asp:BoundField HeaderText="Cubuk Stok" DataField="StokCubuk" >
                    
                            <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                            </asp:BoundField>
                    
                            <asp:TemplateField HeaderText="-">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("CubukStok") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("CubukStok") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                      
                            <asp:BoundField HeaderText="İstanbulCad Stok" DataField="Stokİstcad">
                     
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                     
                            <asp:TemplateField HeaderText="-">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("IstanbulcadStok") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("IstanbulcadStok") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                    
                            <asp:BoundField HeaderText="Hasköy Stok" DataField="StokHasköy" >
                      
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="-">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("HasköyStok") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("HasköyStok") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                     
                            <asp:BoundField HeaderText="Esenboğa Stok" DataField="StokEsenboga">
                       
                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                            </asp:BoundField>
                            <asp:TemplateField HeaderText="-">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("EsenbogaStok") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("EsenbogaStok") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                       
                            <asp:BoundField HeaderText="Birim Fiyat" DataField="Fiyat">
                         
                            </asp:BoundField>
                         
                            <asp:BoundField HeaderText="Toplam" DataField="Toplam" />
                            
                            <asp:TemplateField HeaderText="SipariseKalan">
                                <EditItemTemplate>
                                    <asp:TextBox ID="TextBox6" runat="server" Text='<%# Bind("SipariseGecen") %>'></asp:TextBox>
                                </EditItemTemplate>
                                <ItemTemplate>
                                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("SipariseGecen") %>' 
                                        style="color: #CC0000; font-weight: 700; font-size: small; background-color: #FFFFFF"></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                        </Columns>
                    </asp:GridView>
                    <div class="style9">
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Label ID="Label2" runat="server" style="color: #FF3300" Text="Toplam"></asp:Label>
                        :<asp:Label ID="Label3" runat="server" style="color: #FF3300; font-weight: 700" 
                            Text="0"></asp:Label>
&nbsp;<span class="style8">TL</span><br />
                    </div>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Not:</td>
                <td align="center" class="style7" valign="middle">
                    <asp:TextBox ID="TextBox5" runat="server" TextMode="MultiLine" MaxLength="100"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style3">
                    Satış durumu:</td>
                <td align="center" class="style7" valign="middle">
                    <asp:DropDownList ID="DropDownList2" runat="server">
                        <asp:ListItem Selected="True">Nakit</asp:ListItem>
                        <asp:ListItem>KrediKartı</asp:ListItem>
                        <asp:ListItem>Çek</asp:ListItem>
                        <asp:ListItem>Senet</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td align="center" class="style4" colspan="2" valign="middle">
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:LinkButton ID="LinkButton1" runat="server" BackColor="#2D3E5B" 
                        BorderColor="Black" BorderStyle="Double" onclick="LinkButton1_Click" 
                        onclientclick="return confirm('Stok Bilgileri Güncellenecek!Onaylamak istiyormusun?')" 
                        style="color: #FFFFFF">Tamamla</asp:LinkButton>
                &nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Label ID="Label7" runat="server" 
                        style="color: #FF6600; font-style: italic; font-size: large; text-decoration: underline; background-color: #F0F0F0" 
                        Text="Lütfen Müşteri tanmlanması için Ad Soyad ve TC No giriniz." 
                        Visible="False"></asp:Label>
                </td>
            </tr>
        </table>
        <br />
    
    </div>
    </form>
</body>
</html>
