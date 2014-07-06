<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControl.ascx.cs" Inherits="WebApplication1.UserControl" %>
<asp:MultiView ID="MultiView1" runat="server">
    <asp:View ID="View1" runat="server">
        <asp:LinkButton ID="LinkButton1" runat="server" PostBackUrl="~/Giris.aspx">Giriş</asp:LinkButton>
    </asp:View>
    <asp:View ID="View2" runat="server">
        Merhaba &quot;<asp:Label ID="Label1" runat="server" style="color: #CC3300"></asp:Label>
        &quot;
        <br />
        <asp:LinkButton ID="LinkButton2" runat="server" PostBackUrl="~/Sepetim.aspx">Sepetim</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton3" runat="server">Siparişlerim</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton4" runat="server" onclick="LinkButton4_Click">Çıkış</asp:LinkButton>
    </asp:View>
    <asp:View ID="View3" runat="server">
        Merhaba &quot;<asp:Label ID="Label2" runat="server" style="color: #CC3300"></asp:Label>
        &quot;
        <br />
        <asp:LinkButton ID="LinkButton6" runat="server" 
            PostBackUrl="~/Admin/UrunEkle.aspx">Yönetim Paneli</asp:LinkButton>
        <br />
        <asp:LinkButton ID="LinkButton5" runat="server" onclick="LinkButton4_Click">Çıkış</asp:LinkButton>
    </asp:View>
    <br />
</asp:MultiView>

