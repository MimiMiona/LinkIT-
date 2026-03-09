using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCExplorarEventos : UserControl
    {
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);
        private Color colorVerde = Color.FromArgb(76, 175, 80);

        public UCExplorarEventos()
        {
            InitializeComponent();
            InicializarFlowLayout();
            CargarEventos();

            flowEventos.Resize += (s, e) => CentrarCards();
        }

        private void UCExplorarEventos_Load(object sender, EventArgs e)
        {
            labelSubtitulo.ForeColor = colorGrisTexto;
        }

        // ================================
        // CONFIGURAR FLOWLAYOUT
        // ================================
        private void InicializarFlowLayout()
        {
            flowEventos.FlowDirection = FlowDirection.LeftToRight;
            flowEventos.WrapContents = true;
            flowEventos.AutoScroll = true;
            flowEventos.Padding = new Padding(60, 30, 60, 30);
            flowEventos.AutoSize = false;
            flowEventos.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowEventos.BackColor = Color.FromArgb(245, 247, 250);
        }

        // ================================
        // CENTRAR CARDS DINÁMICAMENTE
        // ================================
        private void CentrarCards()
        {
            if (flowEventos.Controls.Count == 0) return;

            int totalAnchoCards = 0;

            foreach (Control c in flowEventos.Controls)
            {
                totalAnchoCards += c.Width + c.Margin.Left + c.Margin.Right;
            }

            int espacioDisponible = flowEventos.ClientSize.Width - totalAnchoCards;

            if (espacioDisponible > 0)
                flowEventos.Padding = new Padding(espacioDisponible / 2, 30, 0, 30);
            else
                flowEventos.Padding = new Padding(60, 30, 60, 30);
        }

        // ================================
        // MODELO EVENTO
        // ================================
        public class Evento
        {
            public int IdEvento { get; set; }
            public string Titulo { get; set; }
            public string Estado { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public TimeSpan HoraInicio { get; set; }
            public TimeSpan HoraFin { get; set; }
            public int Inscriptos { get; set; }
            public int Capacidad { get; set; }

            public int PorcentajeOcupacion =>
                Capacidad > 0 ? (Inscriptos * 100) / Capacidad : 0;
        }

        // ================================
        // CARGAR EVENTOS
        // ================================
        private void CargarEventos()
        {
            flowEventos.Controls.Clear();

            Conexion con = new Conexion();

            string query = @"
    SELECT 
    e.id_evento,
    e.titulo,
    e.descripcion,
    e.fecha_evento,
    e.horario_inicio,
    e.horario_fin,
    e.capacidad_maxima,

    CASE 
        WHEN e.estado = 'Cancelado' THEN 'Cancelado'
        WHEN CAST(e.fecha_evento AS DATETIME) + CAST(e.horario_fin AS DATETIME) < GETDATE() THEN 'Finalizado'
        ELSE 'Disponible'
    END AS estado,

    (SELECT COUNT(*) 
     FROM Inscripcion i 
     WHERE i.id_evento = e.id_evento 
     AND i.estado = 'Inscripto') AS inscriptos

FROM Evento e
WHERE e.estado <> 'Cancelado'
ORDER BY e.fecha_evento";

            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion());

            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Evento evento = new Evento
                {
                    IdEvento = Convert.ToInt32(reader["id_evento"]),
                    Titulo = reader["titulo"].ToString(),
                    Descripcion = reader["descripcion"].ToString(),
                    Fecha = Convert.ToDateTime(reader["fecha_evento"]),
                    HoraInicio = ((DateTime)reader["horario_inicio"]).TimeOfDay,
                    HoraFin = ((DateTime)reader["horario_fin"]).TimeOfDay,
                    Capacidad = Convert.ToInt32(reader["capacidad_maxima"]),
                    Inscriptos = Convert.ToInt32(reader["inscriptos"]),
                    Estado = reader["estado"].ToString()
                };

                flowEventos.Controls.Add(CrearCard(evento));
            }

            reader.Close();
            con.CerrarConexion();

            CentrarCards();
        }

        // ================================
        // CREAR CARD
        // ================================
        private Panel CrearCard(Evento evento)
        {
            Panel card = new Panel();
            card.Width = 420;
            card.Height = 230;
            card.BackColor = Color.White;
            card.Margin = new Padding(20);
            card.Padding = new Padding(20);

            card.Paint += (s, e) =>
            {
                using (Pen pen = new Pen(Color.FromArgb(230, 230, 230)))
                {
                    e.Graphics.DrawRectangle(pen, 0, 0, card.Width - 1, card.Height - 1);
                }
            };

            Label lblTitulo = new Label();
            lblTitulo.Text = evento.Titulo;
            lblTitulo.Font = new Font("Segoe UI", 10.5f, FontStyle.Bold);
            lblTitulo.AutoSize = true;
            lblTitulo.Location = new Point(10, 10);

            Label lblEstado = new Label();
            lblEstado.Text = evento.Estado;
            lblEstado.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblEstado.AutoSize = true;
            lblEstado.Padding = new Padding(6, 3, 6, 3);
            lblEstado.BackColor = Color.FromArgb(232, 245, 233);
            lblEstado.ForeColor = colorVerde;
            lblEstado.Location = new Point(card.Width - 110, 10);

            Label lblDescripcion = new Label();
            lblDescripcion.Text = evento.Descripcion;
            lblDescripcion.Font = new Font("Segoe UI", 9);
            lblDescripcion.ForeColor = Color.FromArgb(90, 90, 90);
            lblDescripcion.Size = new Size(340, 40);
            lblDescripcion.Location = new Point(10, 30);

            Label lblInfo = new Label();
            lblInfo.Text = $"{evento.Fecha:dd/MM/yyyy} | {evento.HoraInicio:hh\\:mm}-{evento.HoraFin:hh\\:mm} | {evento.Inscriptos}/{evento.Capacidad}";
            lblInfo.Font = new Font("Segoe UI", 8.5f);
            lblInfo.ForeColor = Color.Gray;
            lblInfo.AutoSize = true;
            lblInfo.Location = new Point(10, 75);

            Label lblOcupacion = new Label();
            lblOcupacion.Text = $"Ocupación {evento.PorcentajeOcupacion}%";
            lblOcupacion.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblOcupacion.ForeColor = colorVerde;
            lblOcupacion.AutoSize = true;
            lblOcupacion.Location = new Point(10, 100);

            Panel barraFondo = new Panel();
            barraFondo.BackColor = Color.FromArgb(230, 230, 230);
            barraFondo.Size = new Size(340, 8);
            barraFondo.Location = new Point(10, 120);

            Panel barraProgreso = new Panel();
            barraProgreso.BackColor = colorVerde;
            barraProgreso.Height = 8;
            barraProgreso.Width = (340 * evento.PorcentajeOcupacion) / 100;

            barraFondo.Controls.Add(barraProgreso);

            Button btnUnirme = new Button();
            btnUnirme.Text = "Unirme al Evento";
            btnUnirme.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnUnirme.BackColor = colorVerde;
            btnUnirme.ForeColor = Color.White;
            btnUnirme.FlatStyle = FlatStyle.Flat;
            btnUnirme.FlatAppearance.BorderSize = 0;
            btnUnirme.Size = new Size(150, 32);
            btnUnirme.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            btnUnirme.Location = new Point(card.Width - btnUnirme.Width - 20,
                                           card.Height - btnUnirme.Height - 20);
            btnUnirme.Cursor = Cursors.Hand;

            btnUnirme.MouseEnter += (s, e) =>
                btnUnirme.BackColor = Color.FromArgb(56, 142, 60);

            btnUnirme.MouseLeave += (s, e) =>
                btnUnirme.BackColor = colorVerde;
            btnUnirme.Click += (s, e) =>
            {
                Conexion con = new Conexion();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO Inscripcion (id_usuario, id_evento, estado)
                    VALUES (@usuario, @evento, 'Inscripto')",
                con.AbrirConexion());

                cmd.Parameters.AddWithValue("@usuario", Login.Sesion.IdUsuario);
                cmd.Parameters.AddWithValue("@evento", evento.IdEvento);

                cmd.ExecuteNonQuery();
                con.CerrarConexion();

                MessageBox.Show("Te inscribiste al evento");

                CargarEventos();
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblInfo);
            card.Controls.Add(lblOcupacion);
            card.Controls.Add(barraFondo);
            card.Controls.Add(btnUnirme);

            return card;
        }
    }
}