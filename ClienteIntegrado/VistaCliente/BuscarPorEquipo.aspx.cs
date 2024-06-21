using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using VistaCliente.ServiceReference;

namespace VistaCliente
{
    public partial class BuscarPorEquipo : System.Web.UI.Page
    {
        private ServicioFutbolSoapClient _serviceClient;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitializeServiceClient();
                LoadEquipos();
            }
        }

        private void InitializeServiceClient()
        {
            // Asegúrate de que el cliente del servicio esté correctamente inicializado
            if (_serviceClient == null)
            {
                _serviceClient = new ServicioFutbolSoapClient("ServicioFutbolSoap");
            }
        }

        private void LoadEquipos()
        {
            try
            {
                List<string> equipos = _serviceClient.ListarEquipos();

                ddlEquipoA.DataSource = equipos;
                ddlEquipoA.DataBind();
                ddlEquipoA.Items.Insert(0, new ListItem("Seleccione un equipo", ""));

                ddlEquipoB.DataSource = equipos;
                ddlEquipoB.DataBind();
                ddlEquipoB.Items.Insert(0, new ListItem("Seleccione un equipo", ""));
            }
            catch (Exception ex)
            {
                lblEquipoA.Text = "Error al cargar los equipos: " + ex.Message;
                lblEquipoB.Text = "Error al cargar los equipos: " + ex.Message;
            }
        }

        protected void ddlEquipoA_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJugadores(ddlEquipoA.SelectedValue, listJugadoresA);
        }

        protected void ddlEquipoB_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadJugadores(ddlEquipoB.SelectedValue, listJugadoresB);
        }

        private void LoadJugadores(string equipo, BulletedList listJugadores)
        {
            try
            {
                if (!string.IsNullOrEmpty(equipo))
                {
                    JugadorDTO[] jugadores = _serviceClient.JugadoresListaPorEquipo(equipo);
                    listJugadores.Items.Clear();
                    if (jugadores != null)
                    {
                        foreach (var jugador in jugadores)
                        {
                            listJugadores.Items.Add(new ListItem($"{jugador.Nombre} ({jugador.Posicion}, {jugador.Edad} años)"));
                        }
                    }
                    else
                    {
                        listJugadores.Items.Add(new ListItem("No se encontraron jugadores para el equipo seleccionado."));
                    }
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción
                listJugadores.Items.Add(new ListItem("Error al cargar los jugadores: " + ex.Message));
            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            // Acción del botón Ingresar
        }
    }
}
