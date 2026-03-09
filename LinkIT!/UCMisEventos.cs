using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCMisEventos : UserControl
    {
        private string rolVista;
        private Color colorVerdePrincipal = Color.MediumSeaGreen;
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);
        private List<Evento> eventosLista;
        public UCMisEventos(string rol)
        {
            InitializeComponent();
            rolVista = rol;
        }

        private void UCMisEventos_Load(object sender, EventArgs e)
        {
            ConfigurarCabecera();
            CargarEventos();
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (eventosLista == null)
                return;

            string filtro = textBoxBuscar.Text.Trim().ToLower();

            panelEventos.Controls.Clear();

            int y = 10;
            bool hayEventosFiltrados = false;

            foreach (var evento in eventosLista)
            {
                if (evento.Titulo.ToLower().Contains(filtro) || evento.Descripcion.ToLower().Contains(filtro))
                {
                    Panel card = CrearCard(evento);
                    card.Location = new Point(10, y);
                    panelEventos.Controls.Add(card);
                    y += card.Height + 10;
                    hayEventosFiltrados = true;
                }
            }

            if (!hayEventosFiltrados)
                MostrarMensajeSinEventos();
        }

        private void ConfigurarCabecera()
        {
            if (rolVista == "Usuario")
            {
                labelSubtitulo.Text = "Eventos en los que estás inscripto";
                BotonCrearEvento.Visible = false;
            }
            else
            {
                labelSubtitulo.Text = "Eventos bajo tu responsabilidad";
                BotonCrearEvento.Visible = true;
            }
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
            public int PorcentajeOcupacion => Capacidad > 0 ? (Inscriptos * 100) / Capacidad : 0;
        }

        private void CargarEventos()
        {
            eventosLista = new List<Evento>();


            panelEventos.Controls.Clear();
            int y = 10;

            Conexion con = new Conexion();
            string query = rolVista == "Jefe de Eventos"
        ? @"SELECT 
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
               ELSE 'Activo'
           END AS estado,

           (SELECT COUNT(*) 
            FROM Inscripcion i 
            WHERE i.id_evento = e.id_evento 
            AND i.estado = 'inscripto') AS inscriptos

        FROM Evento e
        WHERE e.id_usuario = @id"

        : @"SELECT 
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
                ELSE 'Activo'
            END AS estado,

            (SELECT COUNT(*) 
             FROM Inscripcion i 
             WHERE i.id_evento = e.id_evento 
             AND i.estado = 'inscripto') AS inscriptos

        FROM Evento e
        INNER JOIN Inscripcion ins ON e.id_evento = ins.id_evento

        WHERE ins.id_usuario = @id 
        AND ins.estado = 'inscripto'
        AND e.fecha_evento >= CAST(GETDATE() AS DATE)";

            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion());
            cmd.Parameters.AddWithValue("@id", Login.Sesion.IdUsuario);
            SqlDataReader reader = cmd.ExecuteReader();

            bool hayEventos = false;

            while (reader.Read())
            {
                hayEventos = true;
                Evento evento = MapearEvento(reader);

                eventosLista.Add(evento);

                Panel card = CrearCard(evento);
                card.Location = new Point(10, y);
                panelEventos.Controls.Add(card);

                y += card.Height + 10;
            }

            reader.Close();
            con.CerrarConexion();

            if (!hayEventos)
                MostrarMensajeSinEventos();
        }

        private Evento MapearEvento(SqlDataReader reader)
        {

            return new Evento
            {
                IdEvento = Convert.ToInt32(reader["id_evento"]),
                Titulo = reader["titulo"].ToString(),
                Descripcion = reader["descripcion"].ToString(),
                Fecha = Convert.ToDateTime(reader["fecha_evento"]),
                HoraInicio = reader["horario_inicio"] != DBNull.Value
                     ? ((DateTime)reader["horario_inicio"]).TimeOfDay
                     : TimeSpan.Zero,
                HoraFin = reader["horario_fin"] != DBNull.Value
                      ? ((DateTime)reader["horario_fin"]).TimeOfDay
                      : TimeSpan.Zero,
                Capacidad = Convert.ToInt32(reader["capacidad_maxima"]),
                Inscriptos = Convert.ToInt32(reader["inscriptos"]),
                Estado = reader["estado"].ToString()
            };
        }

       

        private void MostrarMensajeSinEventos()
        {
            Panel panelMensaje = new Panel
            {
                Width = panelEventos.Width - 20,
                Height = 200,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(10, 10)
            };

            Label titulo = new Label
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = false,
                Width = panelMensaje.Width,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 50),
                Text = rolVista == "Usuario" ? "No estás inscripto a ningún evento" : "No hay eventos creados"
            };

            Label subtitulo = new Label
            {
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Gray,
                AutoSize = false,
                Width = panelMensaje.Width,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 90),
                Text = rolVista == "Usuario" ? "Explora eventos disponibles para participar." : "Crea tu primer evento para comenzar."
            };


            panelMensaje.Controls.Add(titulo);
            panelMensaje.Controls.Add(subtitulo);

            panelEventos.Controls.Add(panelMensaje);
        }

        private Panel CrearCard(Evento evento)
        {
            Panel card = new Panel
            {
                Width = 1126,
                Height = 130,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Margin = new Padding(20, 10, 20, 10)
            };

            // --- Título ---
            Label lblTitulo = new Label
            {
                Text = evento.Titulo,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true,
                MaximumSize = new Size(500, 30),
                AutoEllipsis = true
            };

            // --- Badge de Estado ---
            Label lblEstado = new Label
            {
                Text = evento.Estado,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(5, 2, 5, 2),
                BackColor = evento.Estado == "Activo" ? Color.FromArgb(230, 245, 230) : Color.FromArgb(255, 240, 230),
                ForeColor = evento.Estado == "Activo" ? colorVerdePrincipal :
                            evento.Estado == "Finalizado" ? Color.Gray :
                            Color.DarkOrange,

            };

            // --- Descripción ---
            Label lblDescripcion = new Label
            {
                Text = evento.Descripcion,
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(15, 45),
                AutoSize = true
            };

            // --- Información inferior (fecha, hora, inscritos) ---
            Label lblInfo = new Label
            {
                Text = $"📅 {evento.Fecha:dd/MM/yyyy}    🕒 {evento.HoraInicio:hh\\:mm}-{evento.HoraFin:hh\\:mm}    👥 {evento.Inscriptos}/{evento.Capacidad}",
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                Location = new Point(15, 90),
                AutoSize = true
            };

            // --- Sección derecha (ocupación y botones) ---
            int derechaX = card.Width - 240; // margen dinámico

            if (rolVista == "Usuario")
            {
                // --- Botón Dar de baja ---
                Button btnDarBaja = new Button
                {
                    Text = "❌ Dar de baja",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = Color.IndianRed,
                    ForeColor = Color.White,
                    Size = new Size(120, 32),
                    Location = new Point(derechaX + 70, 50),
                    Cursor = Cursors.Hand
                };

                btnDarBaja.Click += (s, e) =>
                {
                    DialogResult result = MessageBox.Show(
                        "¿Deseás darte de baja de este evento?",
                        "Confirmar",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning
                    );

                    if (result == DialogResult.Yes)
                    {
                        Conexion con = new Conexion();

                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Inscripcion SET estado = 'Cancelado' WHERE id_evento = @idEvento AND id_usuario = @idUsuario",
                            con.AbrirConexion()
                        );

                        cmd.Parameters.AddWithValue("@idEvento", evento.IdEvento);
                        cmd.Parameters.AddWithValue("@idUsuario", Login.Sesion.IdUsuario);

                        cmd.ExecuteNonQuery();
                        con.CerrarConexion();

                        MessageBox.Show(
                            "Te has dado de baja del evento.",
                            "Éxito",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        CargarEventos(); // recargar lista
                    }
                };

                card.Controls.Add(btnDarBaja);
            }
            else
            {
                // --- Solo para roles distintos a Usuario: Editar e Inscriptos + ocupación ---
                Label lblOcupacion = new Label
                {
                    Text = $"Ocupación {evento.PorcentajeOcupacion}%",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    ForeColor = evento.PorcentajeOcupacion >= 100 ? Color.DarkOrange : colorVerdePrincipal,
                    AutoSize = true,
                    Location = new Point(derechaX + 50, 15)
                };

                ProgressBar progress = new ProgressBar
                {
                    Value = evento.PorcentajeOcupacion,
                    Width = 180,
                    Height = 10,
                    Location = new Point(derechaX, 35)
                };

                Button btnEditar = new Button
                {
                    Text = "✏️ Editar",
                    Font = new Font("Segoe UI", 9),
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderColor = colorGrisTexto },
                    BackColor = Color.White,
                    Size = new Size(90, 32),
                    Location = new Point(derechaX, 65),
                    Cursor = Cursors.Hand
                };

                btnEditar.Click += (s, e) =>
                {
                    FormularioEvento formEvento = new FormularioEvento(evento);
                    formEvento.ShowDialog();
                    CargarEventos();
                };

                Button btnInscriptos = new Button
                {
                    Text = "👁️ Inscriptos",
                    Font = new Font("Segoe UI", 9, FontStyle.Bold),
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderSize = 0 },
                    BackColor = colorVerdePrincipal,
                    ForeColor = Color.White,
                    Size = new Size(120, 32),
                    Location = new Point(derechaX + 100, 65),
                    Cursor = Cursors.Hand
                };


                // Cuando se hace click, abrimos el UCInscripto
                btnInscriptos.Click += (s, e) =>
                {
                    JefeEventos form = (JefeEventos)this.FindForm();
                    form.LoadUserControl(new UCInscriptos(evento));
                };

                card.Controls.Add(lblOcupacion);
                card.Controls.Add(progress);
                card.Controls.Add(btnEditar);
                card.Controls.Add(btnInscriptos);
            }

            // --- Ajuste dinámico del badge de estado ---
            card.Layout += (s, e) =>
            {
                lblEstado.Location = new Point(lblTitulo.Right + 10, lblTitulo.Top + (lblTitulo.Height - lblEstado.Height) / 2);
            };

            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblInfo);

            return card;
        }



        private void BotonCrearEvento_Click(object sender, EventArgs e)
        {
            FormularioEvento formEvento = new FormularioEvento(); // formulario vacío
            formEvento.ShowDialog(); // Modal
            CargarEventos();
        }
    }
}