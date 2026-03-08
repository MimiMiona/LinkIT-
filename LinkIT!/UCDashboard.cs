using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LinkIT_
{
    public partial class UCDashboard : UserControl
    {
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);

        public UCDashboard()
        {
            InitializeComponent();
        }

        private void UCDashboard_Load(object sender, EventArgs e)
        {
            labelSubtitulo.ForeColor = colorGrisTexto;

            // Carga de indicadores numéricos
            CargarTotalEventos();
            CargarEventosActivos();
            CargarEventosFinalizados();
            CargarUsuarios();
            CargarSolicitudes();
            CargarJefesEventos();
            CargarEventoMayorAsistencia();
            CargarTasaOcupacion();

            // Carga de gráficos (Estructura mejorada)
            CargarGraficosDashboard();
        }


        private void CargarTotalEventos()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Evento", con.AbrirConexion());
            labelSubtituloTotalEventos.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarEventosActivos()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Evento WHERE estado = 'Activo'", con.AbrirConexion());
            labelSubtituloEventoActivo.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarEventosFinalizados()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Evento WHERE estado = 'Finalizado'", con.AbrirConexion());
            labelSubtituloEventoFinalizado.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarUsuarios()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Usuario", con.AbrirConexion());
            labelSubtituloTotalUsuarios.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarSolicitudes()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Solicitud WHERE estado = 'Pendiente'", con.AbrirConexion());
            labelSubtituloSolicitudesPendientes.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarJefesEventos()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Usuario WHERE id_rol = 2", con.AbrirConexion());
            labelSubtituloJefesEventos.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarEventoMayorAsistencia()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(@"
                SELECT TOP 1 E.titulo
                FROM Evento E
                JOIN Inscripcion I ON E.id_evento = I.id_evento
                GROUP BY E.titulo
                ORDER BY COUNT(I.id_inscripcion) DESC", con.AbrirConexion());

            object resultado = cmd.ExecuteScalar();
            labelSubtituloEventoMayorAsistencia.Text = resultado != null ? resultado.ToString() : "Sin datos";
            con.CerrarConexion();
        }

        private void CargarTasaOcupacion()
        {
            try
            {
                Conexion con = new Conexion();
                // Cálculo corregido: COUNT en lugar de SUM de IDs
                SqlCommand cmd = new SqlCommand(@"
                    SELECT 
                        ISNULL(CAST(COUNT(I.id_inscripcion) AS FLOAT) * 100 / 
                        NULLIF((SELECT SUM(capacidad_maxima) FROM Evento), 0), 0)
                    FROM Inscripcion I", con.AbrirConexion());

                double tasa = Convert.ToDouble(cmd.ExecuteScalar());
                labelSubtituloTasaOcupacion.Text = Math.Round(tasa, 2) + " %";
                con.CerrarConexion();
            }
            catch { labelSubtituloTasaOcupacion.Text = "0 %"; }
        }

        private void CargarGraficosDashboard()
        {
            if (chartEventosMes == null || chartAsistenciaMensual == null) return;

            try
            {
                // Limpieza segura
                chartEventosMes.Series.Clear();
                chartEventosMes.Legends.Clear();
                chartAsistenciaMensual.Series.Clear();
                chartAsistenciaMensual.Legends.Clear();

                Conexion con = new Conexion();

                // --- GRÁFICO 1: Eventos por Mes ---
                Series serieMes = new Series("Eventos por Mes")
                {
                    ChartType = SeriesChartType.Column,
                    Color = Color.FromArgb(46, 204, 113),
                    ToolTip = "#VAL",
                };

                string sqlMes = @"SELECT 
                    MONTH(fecha_evento) AS MesNumero,
                    COUNT(*) AS Total
                FROM Evento
                GROUP BY MONTH(fecha_evento)
                ORDER BY MesNumero";

                using (SqlCommand cmd = new SqlCommand(sqlMes, con.AbrirConexion()))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        string[] meses = { "Ene", "Feb", "Mar", "Abr", "May", "Jun", "Jul", "Ago", "Sep", "Oct", "Nov", "Dic" };

                        while (dr.Read())
                        {
                            int mes = Convert.ToInt32(dr["MesNumero"]);
                            int total = Convert.ToInt32(dr["Total"]);
                            serieMes.Points.AddXY(mes, total);
                            
                        }
                    }
                }

                chartEventosMes.Series.Add(serieMes);

                // Configuración del eje
                chartEventosMes.ChartAreas[0].AxisX.Title = "Meses";
                chartEventosMes.ChartAreas[0].AxisY.Title = "Cantidad de Eventos";
                chartEventosMes.ChartAreas[0].RecalculateAxesScale();

                // --- GRÁFICO TORTA (NO TOCADO) ---
                Series serieTorta = new Series("EventosTorta")
                {
                    ChartType = SeriesChartType.Pie,
                    ToolTip = "#VAL inscriptos"
                };

                serieTorta["PieLabelStyle"] = "Disabled";

                string sqlTorta = @"
                SELECT TOP 5 e.titulo, COUNT(i.id_inscripcion) AS Total
                FROM Evento e
                LEFT JOIN Inscripcion i ON e.id_evento = i.id_evento
                GROUP BY e.titulo
                ORDER BY Total DESC;";

                using (SqlCommand cmd = new SqlCommand(sqlTorta, con.AbrirConexion()))
                {
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            DataPoint p = new DataPoint();
                            p.SetValueY(Convert.ToInt32(dr["Total"]));
                            p.LegendText = dr["titulo"].ToString();
                            serieTorta.Points.Add(p);
                        }
                    }
                }

                con.CerrarConexion();

                chartAsistenciaMensual.Series.Add(serieTorta);

                Legend leg = new Legend("Legend1");
                leg.Docking = Docking.Right;

                chartAsistenciaMensual.Legends.Add(leg);
                serieTorta.Legend = "Legend1";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


    }
}