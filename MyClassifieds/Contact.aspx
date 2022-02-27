<%@ Page Title="Contact" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.vb" Inherits="MyClassifieds.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %></h2>

    <address>
        <strong>MyClassifieds.XYZ</strong><br />
        5615 Richmond Av. Ste 240<br />
        Houston, TX 77057<br />
        <abbr title="Phone">Phone:</abbr>
        713.714.7852
    </address>

    <address>
        <strong>Support: </strong><a href="mailto:Support@myclassifieds.xyz">Support@myclassifieds.xyz</a><br />
        <strong>Marketing: </strong><a href="mailto:Sales@myclassifieds.xyz">Sales@myclassifieds.xyz</a>
    </address>
</asp:Content>
