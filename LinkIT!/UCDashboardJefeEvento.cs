using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace LinkIT_
{
    public partial class UCDashboardJefeEvento : UserControl
    {
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);
        private int idJefeEvento;

        public UCDashboardJefeEvento(int idUsuario)
        {
            InitializeComponent();
            idJefeEvento = idUsuario;
            this.Load += UCDashboardJefeEvento_Load;
        }

        private void UCDashboardJefeEvento_Load(object sender, EventArgs e)
        {
            labelSubtitulo.ForeColor = colorGrisTexto;

            // Cargar indicadores
            CargarTotalEventos();
            CargarEventosActivos();
            CargarSolicitudesPendientes();
            CargarEventoMayorAsistencia();

            // Cargar gráficos
            CargarGraficoEventosMes();
            CargarGraficoEstados();
        }

        private void CargarTotalEventos()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Evento WHERE id_Usuario = @id", con.AbrirConexion());
            cmd.Parameters.AddWithValue("@id", idJefeEvento);
            labelSubtituloTotalEventos.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarEventosActivos()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Evento WHERE id_Usuario = @id AND estado = 'Activo'", con.AbrirConexion());
            cmd.Parameters.AddWithValue("@id", idJefeEvento);
            labelSubtituloEventoActivo.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarSolicitudesPendientes()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Solicitud 
            WHERE estado = 'pendiente'", con.AbrirConexion());
            cmd.Parameters.AddWithValue("@id", idJefeEvento);
            labelSubtituloSolicitudesPendientes.Text = cmd.ExecuteScalar().ToString();
            con.CerrarConexion();
        }

        private void CargarEventoMayorAsistencia()
        {
            Conexion con = new Conexion();
            SqlCommand cmd = new SqlCommand(@"
                    SELECT TOP 1 E.titulo
                    FROM Evento E
                    JOIN Inscripcion I ON E.id_evento = I.id_evento
                    WHERE E.id_Usuario = @id
                    GROUP BY E.titulo
                    ORDER BY COUNT(I.id_inscripcion) DESC", con.AbrirConexion());
            cmd.Parameters.AddWithValue("@id", idJefeEvento);
            object resultado = cmd.ExecuteScalar();
            labelSubtituloEventoMayorAsistencia.Text = resultado != null ? resultado.ToString() : "Sin datos";
            con.CerrarConexion();
        }

        private void CargarGraficoEventosMes()
        {
            if (chartEventosMes == null) return;
            chartEventosMes.Series.Clear();
            chartEventosMes.Legends.Clear();

            Conexion con = new Conexion();
            // Consulta: contamos eventos por mes, filtrando solo los que son hoy o futuro
            string sql = @"
        SELECT MONTH(fecha_evento) AS MesNumero, COUNT(*) AS Total
        FROM Evento
        WHERE id_Usuario = @id 
        AND fecha_evento >= CAST(GETDATE() AS DATE)
        AND estado = 'Activo'
        GROUP BY MONTH(fecha_evento)
        ORDER BY MesNumero;";

            SqlCommand cmd = new SqlCommand(sql, con.AbrirConexion());
            cmd.Parameters.AddWithValue("@id", idJefeEvento);

            Series serieMes = new Series("Eventos")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(46, 204, 113),
                ToolTip = "#VAL eventos"
            };

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                // Inicializamos los 12 meses en 0
                int[] totales = new int[12];
                while (dr.Read())
                {
                    int mes = Convert.ToInt32(dr["MesNumero"]);
                    int total = Convert.ToInt32(dr["Total"]);
                    serieMes.Points.AddXY(mes, total);
                }
            }
            chartEventosMes.Series.Add(serieMes);
            chartEventosMes.ChartAreas[0].AxisX.Interval = 1;
            con.CerrarConexion();
        }

        private void CargarGraficoEstados()
        {
            if (chartAsistenciaMensual == null) return;
            chartAsistenciaMensual.Series.Clear();
            chartAsistenciaMensual.Legends.Clear();

            Conexion con = new Conexion();
            // Lógica dinámica: clasificar en tiempo real en la consulta
            string sql = @"
        SELECT 
            CASE 
                WHEN estado = 'Cancelado' THEN 'Cancelado'
                WHEN fecha_evento < CAST(GETDATE() AS DATE) THEN 'Finalizado'
                ELSE 'Activo'
            END AS estado_calculado,
            COUNT(*) AS Total
        FROM Evento
        WHERE id_Usuario = @id
        GROUP BY 
            CASE 
                WHEN estado = 'Cancelado' THEN 'Cancelado'
                WHEN fecha_evento < CAST(GETDATE() AS DATE) THEN 'Finalizado'
                ELSE 'Activo'
            END";

            SqlCommand cmd = new SqlCommand(sql, con.AbrirConexion());
            cmd.Parameters.AddWithValue("@id", idJefeEvento);

            Series serieTorta = new Series("Estados") { ChartType = SeriesChartType.Pie, ToolTip = "#VAL" };
            serieTorta["PieLabelStyle"] = "Disabled";

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                while (dr.Read())
                {
                    DataPoint p = new DataPoint();
                    p.SetValueY(Convert.ToInt32(dr["Total"]));
                    p.LegendText = dr["estado_calculado"].ToString();
                    serieTorta.Points.Add(p);
                }
            }

            chartAsistenciaMensual.Series.Add(serieTorta);
            Legend leg = new Legend("Legend1") { Docking = Docking.Right };
            chartAsistenciaMensual.Legends.Add(leg);
            con.CerrarConexion();
        }
    }
}