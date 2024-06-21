using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaCliente.ServiceReference;

namespace NombreDeTuProyecto
{
    public partial class InsertJugadores : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarEquipos(); // Método para cargar los equipos disponibles en el DropDownList
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            // Obtener los valores del formulario
            string nombre = txtNombre.Text.Trim();
            string posicion = txtPosicion.Text.Trim();
            int edad = Convert.ToInt32(txtEdad.Text.Trim());
            string equipo = ddlEquipo.SelectedValue; // Obtener el equipo seleccionado
            string foto = txtFoto.Text.Trim();

            // Crear el objeto JugadorDTO
            JugadorDTO jugador = new JugadorDTO
            {
                Nombre = nombre,
                Posicion = posicion,
                Edad = edad,
                Equipo = equipo,
                foto = foto
            };

            // Llamar al servicio web para insertar el jugador
            string resultado = InsertarJugador(jugador);

            // Mostrar el resultado
            lblResultado.Text = resultado;
        }

        private void CargarEquipos()
        {
            // Llamar al método del servicio web para obtener la lista de equipos disponibles
            ServicioFutbolSoapClient clienteSOAP = new ServicioFutbolSoapClient();
            List<string> equipos = clienteSOAP.ListarEquipos();

            // Agregar los equipos al DropDownList
            foreach (var equipo in equipos)
            {
                ddlEquipo.Items.Add(new ListItem(equipo, equipo));
            }
        }

        private string InsertarJugador(JugadorDTO jugador)
        {
            try
            {
                // Llamar al método del servicio web para insertar el jugador
                ServicioFutbolSoapClient clienteSOAP = new ServicioFutbolSoapClient();
                string resultado = clienteSOAP.JugadoresAgregar(jugador);

                return resultado;
            }
            catch (Exception ex)
            {
                return $"Error al insertar jugador: {ex.Message}";
            }
        }
    }
}
