<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertJugadores.aspx.cs" Inherits="NombreDeTuProyecto.InsertJugadores" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Insertar Jugadores</title>
    <style>
        body {
            background-image: url('https://img.freepik.com/vector-premium/fondo-futbol-soccer_64749-274.jpg?size=626&ext=jpg'); /* Reemplaza con la ruta de tu imagen */
            background-size: cover; /* Ajusta la imagen para cubrir toda el área del fondo */
            background-repeat: no-repeat; /* Evita que la imagen se repita */
            background-position: center; /* Centra la imagen en el fondo */
            font-family: Arial, sans-serif;
            background-color: mediumseagreen; /* Color de fondo opcional */
            margin: 0;
            padding: 0;
        }

        .menu-navigation {
            background-color: #333;
            padding: 10px;
            text-align: center;
            width: 100%;
        }

        .menu-navigation ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
            display: flex;
            justify-content: center;
        }

        .menu-navigation ul li {
            display: inline;
            margin-right: 10px;
        }

        .menu-navigation ul li a {
            color: white;
            text-decoration: none;
            padding: 5px 10px;
        }

        .menu-navigation ul li a:hover {
            background-color: #555;
        }

        .form-container {
            background-color: #fff;
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            text-align: center;
            width: 400px;
            margin: 20px auto;
        }

        .form-container h2 {
            margin-bottom: 20px;
        }

        .form-container label {
            display: block;
            font-size: 16px;
            margin-bottom: 10px;
        }

        .form-container input,
        .form-container select,
        .form-container button {
            width: calc(100% - 20px);
            padding: 10px;
            margin: 5px 10px;
            border-radius: 5px;
            border: 1px solid #ccc;
            font-size: 16px;
        }

        .form-container input[type="text"],
        .form-container input[type="number"],
        .form-container select {
            display: block;
            margin-bottom: 15px;
        }

        .form-container button {
            background-color: #333;
            color: white;
            border: none;
            cursor: pointer;
        }

        .form-container button:hover {
            background-color: #555;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="menu-navigation">
            <asp:Menu ID="Menu1" runat="server" Orientation="Horizontal">
                <Items>
                    <asp:MenuItem Text="Jugadores" NavigateUrl="~/MostrarJugadores.aspx" />
                    <asp:MenuItem Text="Entrenadores" NavigateUrl="~/MostrarEntrenadores.aspx" />
                    <asp:MenuItem Text="Agregar Jugador" NavigateUrl="~/InsertJugadores.aspx" />
                    <asp:MenuItem Text="Agregar Entrenador" NavigateUrl="~/InsertEntrenadores.aspx" />
                    <asp:MenuItem Text="Actualizar Jugador" NavigateUrl="~/updateJugadores.aspx" />
                    <asp:MenuItem Text="Actualizar Entrenador" NavigateUrl="~/updateEntrenadores.aspx" />
                </Items>
            </asp:Menu>
        </div>

        <div class="form-container">
            <h2>Insertar Jugador</h2>
            <div>
                <label for="txtNombre">Nombre:</label>
                <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtPosicion">Posición:</label>
                <asp:TextBox ID="txtPosicion" runat="server"></asp:TextBox>
            </div>
            <div>
                <label for="txtEdad">Edad:</label>
                <asp:TextBox ID="txtEdad" runat="server" TextMode="Number"></asp:TextBox>
            </div>
            <div>
                <label for="ddlEquipo">Equipo:</label>
                <asp:DropDownList ID="ddlEquipo" runat="server"></asp:DropDownList>
            </div>
            <div>
                <label for="txtFoto">URL de Foto:</label>
                <asp:TextBox ID="txtFoto" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Button ID="btnInsertar" runat="server" Text="Insertar Jugador" OnClick="btnInsertar_Click" />
            </div>
            <div>
                <asp:Label ID="lblResultado" runat="server" ForeColor="Red"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
