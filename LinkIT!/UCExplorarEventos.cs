using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    // Control de usuario para explorar eventos
    public partial class UCExplorarEventos : UserControl
    {
        // Colores para la interfaz
        Color colorVerde = Color.FromArgb(76, 175, 80); // Verde para estado "Disponible"
        Color colorGrisTexto = Color.FromArgb(100, 100, 100); // Gris para texto

        public UCExplorarEventos()
        {
            InitializeComponent(); // Inicializa los componentes del control de usuario
        }

        // Evento que se ejecuta cuando se carga el control
        private void UCExplorarEventos_Load(object sender, EventArgs e)
        {
            CargarEventos(); // Carga los eventos cuando se carga el control
        }

        // Definición de la clase Evento que representa los eventos
        public class Evento
        {
            public int IdEvento { get; set; } // ID único del evento
            public string Titulo { get; set; } // Título del evento
            public string Descripcion { get; set; } // Descripción del evento
            public DateTime Fecha { get; set; } // Fecha del evento
            public TimeSpan HoraInicio { get; set; } // Hora de inicio del evento
            public TimeSpan HoraFin { get; set; } // Hora de fin del evento
            public int Capacidad { get; set; } // Capacidad máxima de participantes
            public int Inscriptos { get; set; } // Número de inscriptos en el evento
            public string Estado { get; set; } // Estado del evento (Disponible, Finalizado, Cancelado)

            // Propiedad que calcula el porcentaje de ocupación del evento
            public int PorcentajeOcupacion
            {
                get
                {
                    if (Capacidad == 0) return 0; // Si la capacidad es 0, el porcentaje es 0

                    int porcentaje = (Inscriptos * 100) / Capacidad; // Calcula el porcentaje de ocupación

                    // Si el porcentaje supera 100, se establece en 100
                    if (porcentaje > 100) porcentaje = 100;

                    return porcentaje;
                }
            }
        }

        // Método que carga los eventos y los muestra en el panel
        private void CargarEventos(string filtro = "")
        {
            panelEventos.Controls.Clear(); // Limpia los eventos previos

            Conexion con = new Conexion(); // Crea una nueva conexión a la base de datos

            // Consulta SQL para obtener eventos, filtrados por el título
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
            WHERE e.estado = 'Activo' AND fecha_evento > GETDATE()
            AND e.titulo LIKE @filtro
            ORDER BY e.fecha_evento";

            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion()); // Ejecuta la consulta
            cmd.Parameters.AddWithValue("@filtro", "%" + filtro + "%"); // Agrega el parámetro de búsqueda
            SqlDataReader reader = cmd.ExecuteReader(); // Ejecuta la consulta y obtiene los resultados

            int x = 10; // Posición X inicial para la primera card
            int y = 10; // Posición Y inicial para la primera card
            int columna = 0; // Número de columnas para el diseño de las cards

            int espacioX = 20; // Espacio entre las cards en el eje X
            int espacioY = 20; // Espacio entre las cards en el eje Y
            int cardWidth = 350; // Ancho de cada card

            // Recorre los resultados y crea una card para cada evento
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

                // Crea la card para el evento
                Panel card = CrearCard(evento);
                card.Location = new Point(x, y); // Posiciona la card en el panel

                panelEventos.Controls.Add(card); // Añade la card al panel

                columna++; // Incrementa el contador de columnas

                // Organiza las cards en filas de 3
                if (columna == 3)
                {
                    columna = 0; // Reinicia el contador de columnas
                    x = 10; // Reinicia la posición X
                    y += card.Height + espacioY; // Baja a la siguiente fila
                }
                else
                {
                    x += cardWidth + espacioX; // Pone la siguiente card en la misma fila
                }
            }

            reader.Close(); // Cierra el lector
            con.CerrarConexion(); // Cierra la conexión a la base de datos
        }

        // Método que crea una card visualmente para mostrar los detalles del evento
        private Panel CrearCard(Evento evento)
        {
            Panel card = new Panel
            {
                Width = 350, // Ancho de la card
                Height = 240, // Alto de la card
                BackColor = Color.White, // Color de fondo blanco
                BorderStyle = BorderStyle.FixedSingle // Borde simple
            };

            // Título del evento
            Label lblTitulo = new Label
            {
                Text = evento.Titulo,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Estado del evento (Disponible, Finalizado, Cancelado)
            Label lblEstado = new Label
            {
                Text = evento.Estado,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                AutoSize = true,
                Padding = new Padding(6, 3, 6, 3),
                BackColor = Color.FromArgb(232, 245, 233),
                ForeColor = colorVerde
            };

            // Descripción del evento
            Label lblDescripcion = new Label
            {
                Text = evento.Descripcion,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(70, 70, 70),
                Location = new Point(15, 45),
                Size = new Size(310, 40)
            };

            // Fecha del evento
            Label lblFecha = new Label
            {
                Text = $"📅 {evento.Fecha:yyyy-MM-dd}",
                Location = new Point(15, 95),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            // Hora de inicio y fin del evento
            Label lblHora = new Label
            {
                Text = $"🕒 {evento.HoraInicio:hh\\:mm}-{evento.HoraFin:hh\\:mm}",
                Location = new Point(15, 115),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            // Inscripción actual
            Label lblInscriptos = new Label
            {
                Text = $"👥 {evento.Inscriptos}/{evento.Capacidad}",
                Location = new Point(15, 135),
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                AutoSize = true
            };

            // Barra de progreso de ocupación
            ProgressBar progress = new ProgressBar
            {
                Width = 300,
                Height = 10,
                Location = new Point(15, 160),
                Maximum = 100,
                Value = evento.PorcentajeOcupacion
            };

            // Botón para inscribirse al evento
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

            // Verificar si el usuario ya está inscrito
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

            // Si el usuario ya está inscrito, desactivar el botón
            if (existe > 0)
            {
                btnUnirme.Enabled = false;
                btnUnirme.Visible = false;
            }

            // Acción para inscribirse al evento
            btnUnirme.Click += (s, e) =>
            {
                Conexion con2 = new Conexion();

                SqlCommand cmd = new SqlCommand(@"
                INSERT INTO Inscripcion (id_usuario,id_evento,estado)
                VALUES (@usuario,@evento,'Inscripto')",
                con2.AbrirConexion());

                cmd.Parameters.AddWithValue("@usuario", Login.Sesion.IdUsuario);
                cmd.Parameters.AddWithValue("@evento", evento.IdEvento);

                cmd.ExecuteNonQuery(); // Ejecuta la inscripción

                con2.CerrarConexion();

                MessageBox.Show("Te inscribiste al evento");

                CargarEventos(); // Recarga los eventos
            };

            // Añadir los controles a la card
            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblFecha);
            card.Controls.Add(lblHora);
            card.Controls.Add(lblInscriptos);
            card.Controls.Add(progress);
            card.Controls.Add(btnUnirme);

            return card; // Retorna la card
        }

        // Evento que maneja el texto del buscador
        private void bBuscador_TextChanged(object sender, EventArgs e)
        {
            CargarEventos(textBoxBucar.Text); // Filtra los eventos según el texto ingresado
        }
    }
}