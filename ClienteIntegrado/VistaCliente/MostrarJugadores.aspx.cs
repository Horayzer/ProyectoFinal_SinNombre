using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaCliente.ServiceReference;

namespace VistaCliente
{
    public partial class MostrarJugadores : Page
    {
        private ServicioFutbolSoapClient _serviceClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeServiceClient();
                ListarJugadores();
            }
        }

        private void InitializeServiceClient()
        {
            _serviceClient = new ServicioFutbolSoapClient("ServicioFutbolSoap");
        }

        private void ListarJugadores()
        {
            try
            {
                JugadorDTO[] jugadoresArray = _serviceClient.JugadoresLista();
                List<JugadorDTO> jugadores = new List<JugadorDTO>(jugadoresArray);
                dgvJugadores.DataSource = jugadores;
                dgvJugadores.DataBind();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                InitializeServiceClient();
                string nombre = txtNombreBuscar.Text.Trim().ToLower(); // Convertir a minúsculas y quitar espacios

                // Obtener la lista de jugadores y filtrar por nombre insensible a mayúsculas y minúsculas
                JugadorDTO[] jugadoresArray = _serviceClient.JugadoresLista();
                List<JugadorDTO> jugadores = jugadoresArray
                    .Where(j => j.Nombre.ToLower().Contains(nombre))
                    .ToList();

                dgvJugadores.DataSource = jugadores;
                dgvJugadores.DataBind();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void dgvJugadores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvJugadores.EditIndex = e.NewEditIndex;
            ListarJugadores();
        }

        protected void dgvJugadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                InitializeServiceClient();

                if (e.RowIndex >= 0 && e.RowIndex < dgvJugadores.Rows.Count)
                {
                    int id = Convert.ToInt32(dgvJugadores.DataKeys[e.RowIndex].Value);
                    string equipo = dgvJugadores.Rows[e.RowIndex].Cells[4].Text;

                    string result = _serviceClient.JugadoresEliminar(id, equipo);
                    lblResultado.Text = result;

                    ListarJugadores();
                }
                else
                {
                    lblResultado.Text = "Índice de fila inválido.";
                }
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

    }
}
