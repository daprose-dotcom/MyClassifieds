<%@ Page Title="Home" Language="VB" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.vb" Inherits="MyClassifieds._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2 align="center">This site now under reconstruction. Not ready to serve any audiences.<br />Please comeback some other time!</h2>
    <br />
    <asp:dropdownlist runat="Server" autopostback="true" id="ddlpaises" Visible="True" />
    <asp:dropdownlist runat="Server" autopostback="true" id="ddlestado" Visible="False" />
    <asp:dropdownlist runat="Server" autopostback="true" id="ddlciudad" Visible="False" />
    <asp:dropdownlist runat="Server" autopostback="true" id="ddlcat" Visible="False" />
    <asp:dropdownlist runat="server" autopostback="true" id="ddlsubcat" Visible="False" />
    <input type="submit" id="btnSubmit" name="btnSubmit" value="Search" class="btn btn-primary btn-lg" runat="server" visible="false" />
    <asp:label id="labelListResults" runat="Server" Visible="false" Text="Search Results" /><br />
    <asp:GridView ID="GridViewTitle" runat="server" Visible="false" EditRowStyle-BorderWidth="1" EditRowStyle-BackColor="#FFFFCC" EditRowStyle-ForeColor="#993300" CellSpacing="1" EditRowStyle-Wrap="False" AutoGenerateSelectButton="True" AllowSorting="True"></asp:GridView>
    <asp:label id="labelDetailResults" runat="Server" Visible="false" Text="SearchResults" /><br />
    <asp:GridView ID="GridViewResults" runat="server" Visible="false" EditRowStyle-BorderWidth="1" EditRowStyle-BackColor="#FFFFCC" EditRowStyle-ForeColor="#993300" CellSpacing="1" EditRowStyle-Wrap="False"></asp:GridView>
         
    <div class="jumbotron">
        <h2><strong>MyClasifieds.XYZ</strong></h2>
        <p class="lead">MyClasifieds is a FREE multi-user, multi-national <strong>Classified Ads Platform</strong> with a built-in <strong>Bulletin Board System</strong> and full support for HTML, CSS, JavaScript and photo albums support!</p>
        <p><a  runat="server" href="~/Help" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting Started</h2>
            <p>
                We let you build dynamic ads using a familiar drag-and-drop, event-driven model.
            A superb design surface with familiar controls and components that let you build sophisticated, powerful and beatifull ads with images and galleries support.
            </p>
            <p>
                <a  runat="server" class="btn btn-default" href="~/Help">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                We use Nugets. A NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in all Visual Studio projects like this ...
            </p>
            <p>
                <a  runat="server" class="btn btn-default" href="~/">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting Service</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of plans, features and prices for your Windows and Linux applications ...
            </p>
            <p>
                <a class="btn btn-default" target="_blank" href="http://mywebhosting.xyz">Learn more &raquo;</a>
            </p>
        </div>
    </div>

</asp:Content>
