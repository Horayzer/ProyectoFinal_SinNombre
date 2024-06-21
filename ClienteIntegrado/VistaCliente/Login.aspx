<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="YourNamespace.Login" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Login</title>
    <style>
        body {
            background-image: url('https://img.freepik.com/free-vector/gradient-abstract-football-background_23-2148995844.jpg'); /* Reemplaza con la ruta de tu imagen */
            background-size: cover; /* Ajusta la imagen para cubrir toda el área del fondo */
            background-repeat: no-repeat; /* Evita que la imagen se repita */
            background-position: center; /* Centra la imagen en el fondo */
            display: flex;
            justify-content: center;
            align-items: center;
            height: 100vh;
            margin: 0;
        }

        .login-container {
            background: linear-gradient(to right, #8e2de2, #4a00e0);
            padding: 40px;
            border-radius: 10px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.2);
            text-align: center;
            width: 300px;
        }

        .login-container h2 {
            color: white;
            margin-bottom: 20px;
        }

        .login-container label {
            display: block;
            color: white;
            margin: 10px 0 5px;
        }

        .login-container input[type="text"],
        .login-container input[type="password"] {
            width: 100%;
            padding: 10px;
            border: none;
            border-radius: 5px;
            margin-bottom: 10px;
        }

        .login-container input[type="submit"] {
            width: 100%;
            padding: 10px;
            background-color: #4a00e0;
            border: none;
            border-radius: 5px;
            color: white;
            cursor: pointer;
        }

        .login-container input[type="submit"]:hover {
            background-color: #8e2de2;
        }

        .login-container .link {
            display: block;
            margin-top: 10px;
            color: white;
        }

        .login-container .link a {
            color: #00c3ff;
            text-decoration: none;
        }

        .login-container .link a:hover {
            text-decoration: underline;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="login-container">
            <h2>Login</h2>
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
            <asp:Label ID="lblUsername" runat="server" Text="Usuario/Cédula:" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server" CssClass="textbox"></asp:TextBox>
            <asp:Label ID="lblPassword" runat="server" Text="Clave/Código:" CssClass="label"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="textbox"></asp:TextBox>
            <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="button" OnClick="btnLogin_Click" />
            <div class="link">
                <a href="Register.aspx">Regístrate aquí</a> | <a href="ForgotPassword.aspx">Olvidaste tu contraseña</a>
            </div>
        </div>
    </form>
</body>
</html>
