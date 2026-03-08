using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCEventoAdministrador : UserControl
    {
        // Colores que usamos en la interfaz
        Color colorVerdePrincipal = Color.MediumSeaGreen;
        Color colorGrisTexto = Color.FromArgb(100, 100, 100);

        public UCEventoAdministrador()
        {
            InitializeComponent();
        }

        // Cuando se carga el UserControl
        private void UCEventoAdministrador_Load(object sender, EventArgs e)
        {
            // Llamamos al método que carga los eventos desde la base
            CargarEventos();
        }

        // Clase que usamos para guardar los datos de cada evento
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
            public string Responsable { get; set; }

            // Calcula el porcentaje de ocupación automáticamente
            public int PorcentajeOcupacion
            {
                get
                {
                    if (Capacidad == 0) return 0;

                    int porcentaje = (Inscriptos * 100) / Capacidad;

                    // Evita que el porcentaje pase de 100
                    if (porcentaje > 100) porcentaje = 100;

                    return porcentaje;
                }
            }
        }

        // Método que carga todos los eventos del sistema
        private void CargarEventos()
        {
            // Limpiamos el panel antes de cargar nuevas cards
            panelEventos.Controls.Clear();

            Conexion con = new Conexion();

            // Consulta SQL para traer eventos
            string query = @"
            SELECT 
                e.id_evento,
                e.titulo,
                e.descripcion,
                e.fecha_evento,
                e.horario_inicio,
                e.horario_fin,
                e.capacidad_maxima,

                -- Calcula el estado automáticamente
                CASE 
                    WHEN e.estado = 'Cancelado' THEN 'Cancelado'
                    WHEN e.fecha_evento < GETDATE() THEN 'Finalizado'
                    ELSE 'Activo'
                END AS estado,

                -- Cuenta inscriptos
                (SELECT COUNT(*) 
                 FROM Inscripcion i 
                 WHERE i.id_evento = e.id_evento AND i.estado = 'Activa') AS inscriptos,

                -- Trae el nombre del responsable
                u.nombre AS responsable

            FROM Evento e
            INNER JOIN Usuario u ON e.id_usuario = u.id_usuario";

            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion());

            SqlDataReader reader = cmd.ExecuteReader();

            // Variables para organizar las cards en columnas
            int x = 10;
            int y = 10;
            int columna = 0;

            int espacioX = 20;
            int espacioY = 20;

            int cardWidth = 350;

            // Recorremos todos los eventos
            while (reader.Read())
            {
                Evento evento = new Evento
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
                    Estado = reader["estado"].ToString(),
                    Responsable = reader["responsable"].ToString()
                };

                // Creamos la card visual
                Panel card = CrearCard(evento);

                // Ubicación en el panel
                card.Location = new Point(x, y);

                panelEventos.Controls.Add(card);

                columna++;

                // Cada 3 cards bajamos una fila
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

        // Método que crea visualmente cada card
        private Panel CrearCard(Evento evento)
        {
            Panel card = new Panel
            {
                Width = 350,
                Height = 210,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Título del evento
            Label lblTitulo = new Label
            {
                Text = evento.Titulo,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Determinamos color según estado
            Color fondoEstado;
            Color textoEstado;

            if (evento.Estado == "Activo")
            {
                fondoEstado = Color.FromArgb(230, 245, 230);
                textoEstado = colorVerdePrincipal;
            }
            else if (evento.Estado == "Finalizado")
            {
                fondoEstado = Color.FromArgb(240, 240, 240);
                textoEstado = Color.Gray;
            }
            else
            {
                fondoEstado = Color.FromArgb(255, 240, 230);
                textoEstado = Color.DarkOrange;
            }

            // Badge del estado
            Label lblEstado = new Label
            {
                Text = evento.Estado,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(6, 3, 6, 3),
                BackColor = fondoEstado,
                ForeColor = textoEstado
            };

            // Descripción
            Label lblDescripcion = new Label
            {
                Text = evento.Descripcion,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(15, 45),
                Size = new Size(310, 40)
            };

            // Fecha
            Label lblFecha = new Label
            {
                Text = $"📅 {evento.Fecha:yyyy-MM-dd}",
                Location = new Point(15, 95),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            // Hora
            Label lblHora = new Label
            {
                Text = $"🕒 {evento.HoraInicio:hh\\:mm}-{evento.HoraFin:hh\\:mm}",
                Location = new Point(15, 115),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            // Cantidad de inscriptos
            Label lblInscriptos = new Label
            {
                Text = $"👥 {evento.Inscriptos}/{evento.Capacidad} inscriptos",
                Location = new Point(15, 135),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            // Barra de ocupación
            ProgressBar progress = new ProgressBar
            {
                Width = 300,
                Height = 10,
                Location = new Point(15, 160),
                Maximum = 100,
                Value = evento.PorcentajeOcupacion
            };

            // Porcentaje
            Label lblPorcentaje = new Label
            {
                Text = $"{evento.PorcentajeOcupacion}%",
                Location = new Point(280, 175),
                AutoSize = true,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = colorVerdePrincipal
            };

            // Responsable del evento
            Label lblResponsable = new Label
            {
                Text = $"Responsable: {evento.Responsable}",
                Location = new Point(15, 180),
                Font = new Font("Segoe UI", 8.5f),
                ForeColor = Color.Gray,
                AutoSize = true
            };

            // Agregamos controles a la card
            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblFecha);
            card.Controls.Add(lblHora);
            card.Controls.Add(lblInscriptos);
            card.Controls.Add(progress);
            card.Controls.Add(lblPorcentaje);
            card.Controls.Add(lblResponsable);

            // Ajustamos posición del estado al lado del título
            card.Layout += (s, e) =>
            {
                lblEstado.Location = new Point(lblTitulo.Right + 10, lblTitulo.Top);
            };

            return card;
        }
    }
}