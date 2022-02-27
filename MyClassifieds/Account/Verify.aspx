<%@ Page Title="Account verification process" Language="vb" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Verify.aspx.vb" Inherits="MyClassifieds.Verify" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">

    <h2><%: Title %></h2>

    <asp:PlaceHolder runat="server" ID="IntroMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="Intro" />
        </p>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
        <p class="text-danger">
            <asp:Literal runat="server" ID="FailureText" />
        </p>
    </asp:PlaceHolder>

    <asp:PlaceHolder runat="server" ID="DisplayEmail" Visible="false">
        <p class="text-info">Please check your e-mail inbox to verify your account.</p>
    </asp:PlaceHolder>

    <div class="row">
        <div class="col-md-8">
            <asp:PlaceHolder id="loginForm" runat="server" Visible="true">

                <div class="form-horizontal">

                    <div class="form-group">
                        <asp:Label runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Email</asp:Label>
                        <div class="col-md-10">
                            <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" />
                            <asp:RequiredFieldValidator runat="server" ControlToValidate="Email"
                                CssClass="text-danger" ErrorMessage="The email field is required." />
                        </div>
                    </div>
                    <div class="form-group">
                        <div class="col-md-offset-2 col-md-10">
                            <asp:Button runat="server" OnClick="VerifyAccount" Text="Email Link" CssClass="btn btn-default" />
                        </div>
                    </div>
                </div>
            </asp:PlaceHolder>
        </div>
    </div>

</asp:Content>
