using System;
using System.Web.UI;

namespace YourNamespace
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            if (username == "admin" && password == "admin")
            {
                // Login exitoso, redirigir a MostrarJugadores.aspx
                Response.Redirect("MostrarJugadores.aspx");
            }
            else
            {
                // Credenciales incorrectas, mostrar mensaje de error
                lblMessage.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}
