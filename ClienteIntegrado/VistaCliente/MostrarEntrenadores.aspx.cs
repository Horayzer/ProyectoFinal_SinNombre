using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using VistaCliente.ServiceReference;

namespace VistaCliente
{
    public partial class MostrarEntrenadores : Page
    {
        private ServicioFutbolSoapClient _serviceClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeServiceClient();
                ListarEntrenadores();
            }
        }

        private void InitializeServiceClient()
        {
            _serviceClient = new ServicioFutbolSoapClient("ServicioFutbolSoap");
        }

        private void ListarEntrenadores()
        {
            try
            {
                EntrenadorDTO[] entrenadoresArray = _serviceClient.EntrenadoresLista();
                List<EntrenadorDTO> entrenadores = new List<EntrenadorDTO>(entrenadoresArray);
                dgvEntrenadores.DataSource = entrenadores;
                dgvEntrenadores.DataBind();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }

        protected void dgvEntrenadores_RowEditing(object sender, GridViewEditEventArgs e)
        {
            dgvEntrenadores.EditIndex = e.NewEditIndex;
            ListarEntrenadores();
        }

        protected void dgvEntrenadores_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                InitializeServiceClient();

                if (e.RowIndex >= 0 && e.RowIndex < dgvEntrenadores.Rows.Count)
                {
                    int id = Convert.ToInt32(dgvEntrenadores.DataKeys[e.RowIndex].Value);
                    string equipo = dgvEntrenadores.Rows[e.RowIndex].Cells[3].Text;

                    string result = _serviceClient.EntrenadoresEliminar(id, equipo);
                    lblResultado.Text = result;

                    ListarEntrenadores();
                }
                else
                {
                    lblResultado.Text = "Error: Índice de fila inválido.";
                }
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
                string nombre = txtNombreBuscar.Text.Trim().ToLower();

                EntrenadorDTO[] entrenadoresArray = _serviceClient.EntrenadoresLista();
                List<EntrenadorDTO> entrenadores = entrenadoresArray
                    .Where(j => j.Nombre.ToLower().Contains(nombre))
                    .ToList();

                dgvEntrenadores.DataSource = entrenadores;
                dgvEntrenadores.DataBind();
            }
            catch (Exception ex)
            {
                lblResultado.Text = $"Error: {ex.Message}";
            }
        }
    }
}
