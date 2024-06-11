<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Estudiante.UI._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-12">
            <asp:Button runat="server" OnClick="Nuevo_Clk" class="btn btn-sm btn-success" Text="Nuevo" />
        </div>
    </div>
    <br />
    <div class="row">

        <div class="col-12">

            <asp:GridView ID="GVEstudiantes" runat="server" class="table table-bordered" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="Cedula" HeaderText="Cedula" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                    <asp:BoundField DataField="FechaNacimiento" HeaderText="Fecha de nacimiento" DataFormatString="{0:yyyy-MM-dd}" />
                    <asp:BoundField DataField="Correo" HeaderText="Correo" />
                    <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                    <asp:TemplateField>
                        <ItemTemplate>
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("Cedula") %>'
                                OnClick="Editar_Clk" CssClass="btn btn-sm btn-primary">Editar</asp:LinkButton>
                            <asp:LinkButton runat="server" CommandArgument='<%#Eval("Cedula") %>'
                                OnClick="Eliminar_Clk" CssClass="btn btn-sm btn-danger"
                                OnClientClick="return confirm('Esta seguro de eliminar este estudiante?')">Eliminar</asp:LinkButton>

                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>

        </div>
    </div>
</asp:Content>
