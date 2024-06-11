<%@ Page Title="Contact" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="Estudiante.UI.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/5.15.4/css/all.min.css">

    <asp:Label ID="title" runat="server" CssClass="fs-4 fw-bold"></asp:Label>


    <div class="row">
        <div class="col-md-6">
            <div class="input-group mb-3">
                <span class="input-group-text"><i class="fas fa-address-card"></i></span>
                <asp:TextBox ID="txtCedula" runat="server" CssClass="form-control" PlaceHolder="Cedula"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="message">
                <asp:RequiredFieldValidator ID="rfvCedula" runat="server" ControlToValidate="txtCedula" ErrorMessage="La cédula es obligatoria." ValidationGroup="FormValidation" />
                <asp:RegularExpressionValidator ID="revCedula" runat="server" ControlToValidate="txtCedula" ErrorMessage="La cédula debe tener entre 9 y 15 dígitos." ValidationExpression="^\d{9,15}$" ValidationGroup="FormValidation" />
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-6">
            <div class="input-group mb-3">
                <span class="input-group-text"><i class="fas fa-user"></i></span>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" PlaceHolder="Nombre"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="message">
                <asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre es obligatorio." ValidationGroup="FormValidation" />
                <asp:RegularExpressionValidator ID="revNombre" runat="server" ControlToValidate="txtNombre" ErrorMessage="El nombre debe tener al menos 3 caracteres." ValidationExpression="^.{3,}$" ValidationGroup="FormValidation" />
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="input-group mb-3">
                <span class="input-group-text"><i class="fas fa-user"></i></span>
                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" PlaceHolder="Apellidos"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="message">
                <asp:RequiredFieldValidator ID="rfvApellidos" runat="server" ControlToValidate="txtApellidos" ErrorMessage="Los apellidos son obligatorios." ValidationGroup="FormValidation" />
                <asp:RegularExpressionValidator ID="revApellidos" runat="server" ControlToValidate="txtApellidos" ErrorMessage="Los apellidos deben tener al menos 3 caracteres." ValidationExpression="^.{3,}$" ValidationGroup="FormValidation" />
            </div>
        </div>
    </div>

    <div class="input-group mb-3">
        <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
        <asp:TextBox ID="txtFechaNacimiento" runat="server" CssClass="form-control" PlaceHolder="Fecha Nacimiento" TextMode="Date" required="true"></asp:TextBox>
    </div>
    <div class="input-group mb-3">
        <span class="input-group-text"><i class="fas fa-envelope"></i></span>
        <asp:TextBox ID="txtCorreo" runat="server" CssClass="form-control" PlaceHolder="Correo" TextMode="Email" required="true"></asp:TextBox>
    </div>

    <div class="row">
        <div class="col-md-6">
            <div class="input-group mb-3">
                <span class="input-group-text"><i class="fas fa-phone"></i></span>
                <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control" PlaceHolder="Telefono" TextMode="Number"></asp:TextBox>
            </div>
        </div>
        <div class="col-md-6">
            <div class="message">
                <asp:RequiredFieldValidator ID="rfvTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El teléfono es obligatorio." ValidationGroup="FormValidation" />
                <asp:RegularExpressionValidator ID="revTelefono" runat="server" ControlToValidate="txtTelefono" ErrorMessage="El teléfono debe tener exactamente 8 dígitos." ValidationExpression="^\d{8}$" ValidationGroup="FormValidation" />
            </div>
        </div>
    </div>

    <asp:Button ID="btnSubmit" runat="server" Text="Enviar" CssClass="btn btn-success btn-sm" ValidationGroup="FormValidation" OnClick="btnSubmit_Clk" />
    <asp:LinkButton ID="btnCancelar" runat="server" PostBackUrl="~/Default.aspx" CssClass="btn btn-danger btn-sm">Cancelar</asp:LinkButton>
</asp:Content>
