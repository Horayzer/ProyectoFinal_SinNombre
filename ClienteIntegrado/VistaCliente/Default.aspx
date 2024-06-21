<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Form1.aspx.cs" Inherits="VistaCliente.Form1" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Jugadores</title>
    <style>
        body {
            font-family: Arial, sans-serif;
        }
        .form-container {
            margin: 20px;
        }
        .form-container label, .form-container input {
            display: block;
            margin: 5px 0;
        }
        .form-container button {
            margin: 5px 0;
        }
        .gridview-container {
            margin: 20px 0;
        }
        .gridview-container img {
            width: 100px;
            height: auto;
        }
        .gridview-container th, .gridview-container td {
            padding: 10px;
            border: 1px solid #ddd;
        }
        .gridview-container th {
            background-color: #f4f4f4;
        }
        .result-label {
            margin: 20px 0;
            color: red;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="form-container">
            <div class="gridview-container">
                <asp:GridView ID="dgvJugadores" runat="server" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="Id" HeaderText="ID" />
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                        <asp:BoundField DataField="Posicion" HeaderText="Posición" />
                        <asp:BoundField DataField="Equipo" HeaderText="Equipo" />
                        <asp:TemplateField HeaderText="Imagen">
                            <ItemTemplate>
                                <img src='<%# Eval("Imagen") %>' alt="Imagen del jugador" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <asp:Label ID="lblId" runat="server" Text="ID:"></asp:Label>
            <asp:TextBox ID="txtId" runat="server"></asp:TextBox>
            <asp:Label ID="lblNombre" runat="server" Text="Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Label ID="lblPosicion" runat="server" Text="Posición:"></asp:Label>
            <asp:TextBox ID="txtPosicion" runat="server"></asp:TextBox>
            <asp:Label ID="lblEquipo" runat="server" Text="Equipo:"></asp:Label>
            <asp:TextBox ID="txtEquipo" runat="server"></asp:TextBox>
            <asp:Button ID="btnListar" runat="server" Text="Listar" OnClick="btnListar_Click" />
            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" />
            <asp:Button ID="btnActualizar" runat="server" Text="Actualizar" OnClick="btnActualizar_Click" />
            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />
            <asp:Label ID="lblResultado" runat="server" Text="" CssClass="result-label"></asp:Label>
            <asp:Label ID="lblNombreBuscar" runat="server" Text="Buscar por Nombre:"></asp:Label>
            <asp:TextBox ID="txtNombreBuscar" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
        </div>
    </form>
</body>
</html>
