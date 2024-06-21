<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MostrarJugadores.aspx.cs" Inherits="VistaCliente.MostrarJugadores" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Gestión de Jugadores</title>
    <style>
        body {
            background-image: url('https://static.vecteezy.com/system/resources/previews/002/870/046/non_2x/soccer-stadium-background-free-vector.jpg'); /* Reemplaza con la ruta de tu imagen */
            background-size: cover; /* Ajusta la imagen para cubrir toda el área del fondo */
            background-repeat: no-repeat; /* Evita que la imagen se repita */
            background-position: center; /* Centra la imagen en el fondo */
            font-family: Arial, sans-serif;
            background-color: #4CAF50;
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
                    margin-right: 10px;
                }

                    .menu-navigation ul li a {
                        color: white;
                        text-decoration: none;
                        padding: 10px 20px;
                        display: inline-block;
                    }

                        .menu-navigation ul li a:hover {
                            background-color: #575757;
                            border-radius: 5px;
                        }

        .form-container {
            margin: 20px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 10px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 400px;
            text-align: center;
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
                margin: 5px 0;
                border-radius: 5px;
                border: 1px solid #ccc;
                font-size: 16px;
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

        .gridview-container {
            margin: 20px auto;
            background-color: #fff;
            padding: 10px;
            border-radius: 5px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
            width: 80%;
            max-width: 1200px;
        }

            .gridview-container table {
                width: 100%;
                border-collapse: collapse;
            }

            .gridview-container th,
            .gridview-container td {
                padding: 10px;
                border: 1px solid #ddd;
                text-align: center;
            }

            .gridview-container th {
                background-color: #f4f4f4;
            }

            .gridview-container img {
                width: 100px;
                height: auto;
                border-radius: 5px;
            }

        .gridview-buttons {
            display: flex;
            justify-content: center;
            gap: 5px;
        }

            .gridview-buttons .btn-edit,
            .gridview-buttons .btn-delete {
                padding: 5px 10px;
                background-color: #007bff;
                color: white;
                border: none;
                cursor: pointer;
                border-radius: 3px;
                text-decoration: none;
            }

            .gridview-buttons .btn-delete {
                background-color: red;
            }

                .gridview-buttons .btn-edit:hover,
                .gridview-buttons .btn-delete:hover {
                    opacity: 0.8;
                }

        .result-label {
            margin: 20px 0;
            color: red;
            font-weight: bold;
        }
    </style>
    <script>
        function openModal() {
            document.getElementById('editModal').style.display = 'block';
        }

        function closeModal() {
            document.getElementById('editModal').style.display = 'none';
        }
    </script>
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
            <h2>Buscar Jugador</h2>

            <asp:TextBox ID="txtNombreBuscar" runat="server"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            <asp:Label ID="lblResultado" runat="server" CssClass="result-label"></asp:Label>
        </div>

        <div class="gridview-container">
            <asp:GridView ID="dgvJugadores" runat="server" AutoGenerateColumns="false"
                OnRowEditing="dgvJugadores_RowEditing" OnRowDeleting="dgvJugadores_RowDeleting"
                DataKeyNames="Id">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="ID" />
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                    <asp:BoundField DataField="Posicion" HeaderText="Posición" />
                    <asp:BoundField DataField="Edad" HeaderText="Edad" />
                    <asp:BoundField DataField="Equipo" HeaderText="Equipo" />
                    <asp:TemplateField HeaderText="Foto">
                        <ItemTemplate>
                            <img src='<%# Eval("Foto") %>' alt='<%# Eval("Nombre") %>' />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Acciones">
                        <ItemTemplate>
                            <div class="gridview-buttons">
                                <asp:Button ID="btnEdit" runat="server" Text="Editar" CssClass="btn-edit" CommandName="Edit" />
                                <asp:Button ID="btnDelete" runat="server" Text="Eliminar" CssClass="btn-delete" CommandName="Delete" />
                            </div>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
