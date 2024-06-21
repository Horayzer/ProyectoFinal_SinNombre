<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BuscarPorEquipo.aspx.cs" Inherits="VistaCliente.BuscarPorEquipo" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Buscar Jugadores por Equipo</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f0f0f0;
        }

        .container {
            display: flex;
            justify-content: space-between;
            padding: 20px;
        }

        .team-container {
            width: 45%;
            background-color: #fff;
            padding: 20px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0,0,0,0.1);
        }

        .team-container select,
        .team-container ul {
            width: 100%;
            margin-bottom: 20px;
        }

        .team-container ul {
            list-style: none;
            padding: 0;
        }

        .team-container ul li {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

        .team-container ul li img {
            width: 40px;
            height: 40px;
            border-radius: 50%;
            margin-right: 10px;
        }

        .center-field {
            width: 10%;
            text-align: center;
            display: flex;
            align-items: center;
            justify-content: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="team-container">
                <asp:Label ID="lblEquipoA" runat="server" Text="Equipo A"></asp:Label>
                <asp:DropDownList ID="ddlEquipoA" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEquipoA_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:Label ID="lblJugadoresA" runat="server" Text="Jugadores"></asp:Label>
                <asp:BulletedList ID="listJugadoresA" runat="server">
                </asp:BulletedList>
            </div>

            <div class="center-field">
                <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" OnClick="btnIngresar_Click" />
            </div>

            <div class="team-container">
                <asp:Label ID="lblEquipoB" runat="server" Text="Equipo B"></asp:Label>
                <asp:DropDownList ID="ddlEquipoB" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlEquipoB_SelectedIndexChanged">
                </asp:DropDownList>

                <asp:Label ID="lblJugadoresB" runat="server" Text="Jugadores"></asp:Label>
                <asp:BulletedList ID="listJugadoresB" runat="server">
                </asp:BulletedList>
            </div>
        </div>
    </form>
</body>
</html>
