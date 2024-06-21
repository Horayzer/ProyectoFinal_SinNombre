using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaCliente.ServiceReference;

namespace NombreDeTuProyecto
{
    public partial class InsertEntrenadores : Page
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
            string nacionalidad = txtNacionalidad.Text.Trim();
            string equipo = ddlEquipo.SelectedValue; // Obtener el equipo seleccionado
            string foto = txtFoto.Text.Trim();

            // Crear el objeto EntrenadorDTO
            EntrenadorDTO entrenador = new EntrenadorDTO
            {
                Nombre = nombre,
                Nacionalidad = nacionalidad,
                Equipo = equipo,
                Foto = foto
            };

            // Llamar al servicio web para insertar el entrenador
            string resultado = InsertarEntrenador(entrenador);

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

        private string InsertarEntrenador(EntrenadorDTO entrenador)
        {
            try
            {
                // Llamar al método del servicio web para insertar el entrenador
                ServicioFutbolSoapClient clienteSOAP = new ServicioFutbolSoapClient();
                string resultado = clienteSOAP.EntrenadorAgregar(entrenador);

                return resultado;
            }
            catch (Exception ex)
            {
                return $"Error al insertar entrenador: {ex.Message}";
            }
        }
    }
}
