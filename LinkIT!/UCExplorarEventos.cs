using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCExplorarEventos : UserControl
    {
        Color colorVerde = Color.FromArgb(76, 175, 80);
        Color colorGrisTexto = Color.FromArgb(100, 100, 100);

        public UCExplorarEventos()
        {
            InitializeComponent();
        }

        private void UCExplorarEventos_Load(object sender, EventArgs e)
        {
            CargarEventos();
        }

        public class Evento
        {
            public int IdEvento { get; set; }
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime Fecha { get; set; }
            public TimeSpan HoraInicio { get; set; }
            public TimeSpan HoraFin { get; set; }
            public int Capacidad { get; set; }
            public int Inscriptos { get; set; }
            public string Estado { get; set; }

            public int PorcentajeOcupacion
            {
                get
                {
                    if (Capacidad == 0) return 0;

                    int porcentaje = (Inscriptos * 100) / Capacidad;
                    if (porcentaje > 100) porcentaje = 100;

                    return porcentaje;
                }
            }
        }

        private void CargarEventos(string filtro = "")
        {
            panelEventos.Controls.Clear();

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
                    WHEN e.fecha_evento < GETDATE() THEN 'Finalizado'
                    ELSE 'Disponible'
                END AS estado,

                (SELECT COUNT(*) 
                 FROM Inscripcion i 
                 WHERE i.id_evento = e.id_evento 
                 AND i.estado = 'Inscripto') AS inscriptos

            FROM Evento e
            WHERE e.estado <> 'Cancelado'
            AND e.titulo LIKE @filtro
            ORDER BY e.fecha_evento";

            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion());
            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%");
            SqlDataReader reader = cmd.ExecuteReader();

            int x = 10;
            int y = 10;
            int columna = 0;

            int espacioX = 20;
            int espacioY = 20;

            int cardWidth = 350;

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

                Panel card = CrearCard(evento);

                card.Location = new Point(x, y);

                panelEventos.Controls.Add(card);

                columna++;

                if (columna == 3)
                {
                    columna = 0;
                    x = 10;
                    y += card.Height + espacioY;
                }
                else
                {
                    x += cardWidth + espacioX;
                }
            }

            reader.Close();
            con.CerrarConexion();
        }

        private Panel CrearCard(Evento evento)
        {
            Panel card = new Panel
            {
                Width = 350,
                Height = 240,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label lblTitulo = new Label
            {
                Text = evento.Titulo,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };

            Label lblEstado = new Label
            {
                Text = evento.Estado,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(6, 3, 6, 3),
                BackColor = Color.FromArgb(232, 245, 233),
                ForeColor = colorVerde
            };

            Label lblDescripcion = new Label
            {
                Text = evento.Descripcion,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(15, 45),
                Size = new Size(310, 40)
            };

            Label lblFecha = new Label
            {
                Text = $"📅 {evento.Fecha:yyyy-MM-dd}",
                Location = new Point(15, 95),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            Label lblHora = new Label
            {
                Text = $"🕒 {evento.HoraInicio:hh\\:mm}-{evento.HoraFin:hh\\:mm}",
                Location = new Point(15, 115),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            Label lblInscriptos = new Label
            {
                Text = $"👥 {evento.Inscriptos}/{evento.Capacidad}",
                Location = new Point(15, 135),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            ProgressBar progress = new ProgressBar
            {
                Width = 300,
                Height = 10,
                Location = new Point(15, 160),
                Maximum = 100,
                Value = evento.PorcentajeOcupacion
            };

            Button btnUnirme = new Button
            {
                Text = "Inscribirme",
                Width = 120,
                Height = 30,
                Location = new Point(200, 185),
                BackColor = colorVerde,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // verificar si ya está inscripto
            Conexion con = new Conexion();
            SqlCommand check = new SqlCommand(@"
            SELECT COUNT(*) 
            FROM Inscripcion
            WHERE id_usuario=@usuario AND id_evento=@evento
            AND estado='Inscripto'", con.AbrirConexion());

            check.Parameters.AddWithValue("@usuario", Login.Sesion.IdUsuario);
            check.Parameters.AddWithValue("@evento", evento.IdEvento);

            int existe = (int)check.ExecuteScalar();

            con.CerrarConexion();

            if (existe > 0)
            {
                btnUnirme.Enabled = false;
                btnUnirme.Visible = false;
                
            }

            btnUnirme.Click += (s, e) =>
            {
                Conexion con2 = new Conexion();

                SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Inscripcion (id_usuario,id_evento,estado)
                VALUES (@usuario,@evento,'Inscripto')",
                con2.AbrirConexion());

                cmd.Parameters.AddWithValue("@usuario", Login.Sesion.IdUsuario);
                cmd.Parameters.AddWithValue("@evento", evento.IdEvento);

                cmd.ExecuteNonQuery();

                con2.CerrarConexion();

                MessageBox.Show("Te inscribiste al evento");

                CargarEventos();
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblFecha);
            card.Controls.Add(lblHora);
            card.Controls.Add(lblInscriptos);
            card.Controls.Add(progress);
            card.Controls.Add(btnUnirme);

            card.Layout += (s, e) =>
            {
                lblEstado.Location = new Point(lblTitulo.Right + 10, lblTitulo.Top);
            };

            return card;
        }

        private void bBuscador_TextChanged(object sender, EventArgs e)
        {
            CargarEventos(textBoxBucar.Text);
        }
    }
}