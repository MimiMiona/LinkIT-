using Microsoft.Data.SqlClient;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCMisEventos : UserControl
    {
        private string rolVista; // Variable para almacenar el rol del usuario (Usuario o Jefe de Eventos)
        private Color colorVerdePrincipal = Color.MediumSeaGreen; // Color verde principal
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100); // Color gris para el texto
        private List<Evento> eventosLista; // Lista para almacenar los eventos

        // Constructor del UserControl, recibe el rol del usuario
        public UCMisEventos(string rol)
        {
            InitializeComponent();
            rolVista = rol; // Asigna el rol al atributo de la clase
        }

        // Evento que se dispara cuando el UserControl se carga
        private void UCMisEventos_Load(object sender, EventArgs e)
        {
            ConfigurarCabecera(); // Configura la cabecera según el rol
            CargarEventos(); // Carga los eventos desde la base de datos
        }

        // Evento que se dispara cada vez que el texto en el cuadro de búsqueda cambia
        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            if (eventosLista == null) // Si no hay eventos cargados, no hacer nada
                return;

            string filtro = textBoxBuscar.Text.Trim().ToLower(); // Obtiene el texto de búsqueda y lo convierte en minúsculas

            panelEventos.Controls.Clear(); // Limpia el panel de eventos

            int y = 10; // Posición vertical para los eventos
            bool hayEventosFiltrados = false; // Variable para saber si se han encontrado eventos con el filtro

            // Recorre todos los eventos en la lista
            foreach (var evento in eventosLista)
            {
                // Si el título o la descripción del evento contiene el texto de búsqueda
                if (evento.Titulo.ToLower().Contains(filtro) || evento.Descripcion.ToLower().Contains(filtro))
                {
                    Panel card = CrearCard(evento); // Crea una tarjeta para el evento
                    card.Location = new Point(10, y); // Ajusta la posición de la tarjeta
                    panelEventos.Controls.Add(card); // Agrega la tarjeta al panel
                    y += card.Height + 10; // Actualiza la posición para el siguiente evento
                    hayEventosFiltrados = true; // Se han encontrado eventos filtrados
                }
            }

            // Si no se encuentran eventos con el filtro
            if (!hayEventosFiltrados)
                MostrarMensajeSinEventos(); // Muestra un mensaje indicando que no hay eventos
        }

        // Configura la cabecera según el rol de usuario
        private void ConfigurarCabecera()
        {
            if (rolVista == "Usuario") // Si el rol es "Usuario"
            {
                labelSubtitulo.Text = "Eventos en los que estás inscripto"; // Título para el usuario
                BotonCrearEvento.Visible = false; // Oculta el botón de crear evento
            }
            else // Si el rol es "Jefe de Eventos"
            {
                labelSubtitulo.Text = "Eventos bajo tu responsabilidad"; // Título para el jefe de eventos
                BotonCrearEvento.Visible = true; // Muestra el botón de crear evento
            }
        }

        // Clase interna para representar un Evento
        public class Evento
        {
            public int IdEvento { get; set; } // ID del evento
            public string Titulo { get; set; } // Título del evento
            public string Descripcion { get; set; } // Descripción del evento
            public DateTime Fecha { get; set; } // Fecha del evento
            public TimeSpan HoraInicio { get; set; } // Hora de inicio
            public TimeSpan HoraFin { get; set; } // Hora de fin
            public int Capacidad { get; set; } // Capacidad máxima del evento
            public int Inscriptos { get; set; } // Número de inscritos
            public string Estado { get; set; } // Estado del evento (Activo, Finalizado, Cancelado)
            // Calcula el porcentaje de ocupación
            public int PorcentajeOcupacion => Capacidad > 0 ? (Inscriptos * 100) / Capacidad : 0;
        }

        // Carga los eventos desde la base de datos
        private void CargarEventos()
        {
            eventosLista = new List<Evento>(); // Inicializa la lista de eventos

            panelEventos.Controls.Clear(); // Limpia el panel de eventos
            int y = 10; // Posición inicial para los eventos

            Conexion con = new Conexion(); // Crea una nueva conexión a la base de datos
            // Define la consulta SQL dependiendo del rol
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

            SqlCommand cmd = new SqlCommand(query, con.AbrirConexion()); // Crea el comando SQL
            cmd.Parameters.AddWithValue("@id", Login.Sesion.IdUsuario); // Agrega el parámetro de usuario
            SqlDataReader reader = cmd.ExecuteReader(); // Ejecuta la consulta

            bool hayEventos = false; // Variable para verificar si hay eventos

            // Lee los resultados de la consulta
            while (reader.Read())
            {
                hayEventos = true; // Se encontró al menos un evento
                Evento evento = MapearEvento(reader); // Mapea el evento desde el lector

                eventosLista.Add(evento); // Agrega el evento a la lista

                Panel card = CrearCard(evento); // Crea la tarjeta para el evento
                card.Location = new Point(10, y); // Ajusta la ubicación de la tarjeta
                panelEventos.Controls.Add(card); // Agrega la tarjeta al panel

                y += card.Height + 10; // Ajusta la posición para el siguiente evento
            }

            reader.Close(); // Cierra el lector de la base de datos
            con.CerrarConexion(); // Cierra la conexión a la base de datos

            // Si no hay eventos, muestra el mensaje correspondiente
            if (!hayEventos)
                MostrarMensajeSinEventos();
        }

        // Mapea los datos del SqlDataReader a un objeto Evento
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

        // Muestra un mensaje si no hay eventos
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

            // Crea un título de mensaje
            Label titulo = new Label
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                AutoSize = false,
                Width = panelMensaje.Width,
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point(0, 50),
                Text = rolVista == "Usuario" ? "No estás inscripto a ningún evento" : "No hay eventos creados"
            };

            // Crea un subtítulo de mensaje
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

            panelMensaje.Controls.Add(titulo); // Agrega el título al panel
            panelMensaje.Controls.Add(subtitulo); // Agrega el subtítulo al panel

            panelEventos.Controls.Add(panelMensaje); // Agrega el panel de mensaje al panel principal
        }

        // Crea una tarjeta (card) para mostrar un evento
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

            // --- Título del evento ---
            Label lblTitulo = new Label
            {
                Text = evento.Titulo,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Location = new Point(15, 15),
                AutoSize = true,
                MaximumSize = new Size(500, 30),
                AutoEllipsis = true
            };

            // --- Estado del evento ---
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

            // --- Descripción del evento ---
            Label lblDescripcion = new Label
            {
                Text = evento.Descripcion,
                Font = new Font("Segoe UI", 9.5f),
                ForeColor = Color.FromArgb(64, 64, 64),
                Location = new Point(15, 45),
                AutoSize = true
            };

            // --- Información adicional ---
            Label lblInfo = new Label
            {
                Text = $"📅 {evento.Fecha:dd/MM/yyyy}    🕒 {evento.HoraInicio:hh\\:mm}-{evento.HoraFin:hh\\:mm}    👥 {evento.Inscriptos}/{evento.Capacidad}",
                Font = new Font("Segoe UI", 9),
                ForeColor = colorGrisTexto,
                Location = new Point(15, 90),
                AutoSize = true
            };

            // --- Sección derecha (ocupación y botones) ---
            int derechaX = card.Width - 240; // Margen dinámico para la sección derecha

            if (rolVista == "Usuario") // Si el rol es "Usuario"
            {
                // --- Botón para dar de baja ---
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

                // Acción al hacer clic en el botón "Dar de baja"
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

                        cmd.ExecuteNonQuery(); // Ejecuta la actualización
                        con.CerrarConexion(); // Cierra la conexión

                        MessageBox.Show("Te has dado de baja del evento.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEventos(); // Recarga los eventos después de la baja
                    }
                };

                card.Controls.Add(btnDarBaja); // Agrega el botón al card
            }
            else // Si el rol es "Jefe de Eventos"
            {
                // --- Ocupación del evento ---
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
                    Value = evento.PorcentajeOcupacion, // Muestra el porcentaje de ocupación
                    Width = 180,
                    Height = 10,
                    Location = new Point(derechaX, 35)
                };

                // --- Botón para editar el evento ---
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
                    FormularioEvento formEvento = new FormularioEvento(evento); // Abre el formulario para editar el evento
                    formEvento.ShowDialog(); // Muestra el formulario en forma modal
                    CargarEventos(); // Recarga la lista de eventos
                };

                // --- Botón para ver inscriptos ---
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

                // Al hacer clic, abre el control de inscriptos
                btnInscriptos.Click += (s, e) =>
                {
                    JefeEventos form = (JefeEventos)this.FindForm();
                    form.LoadUserControl(new UCInscriptos(evento));
                };

                card.Controls.Add(lblOcupacion); // Agrega la ocupación al card
                card.Controls.Add(progress); // Agrega el progress bar al card
                card.Controls.Add(btnEditar); // Agrega el botón de editar al card
                card.Controls.Add(btnInscriptos); // Agrega el botón de inscriptos al card
            }

            // Ajuste dinámico del badge de estado
            card.Layout += (s, e) =>
            {
                lblEstado.Location = new Point(lblTitulo.Right + 10, lblTitulo.Top + (lblTitulo.Height - lblEstado.Height) / 2);
            };

            // Agrega los elementos al card
            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblInfo);

            return card; // Devuelve el card creado
        }

        // Evento para crear un nuevo evento
        private void BotonCrearEvento_Click(object sender, EventArgs e)
        {
            FormularioEvento formEvento = new FormularioEvento(); // Abre el formulario para crear un nuevo evento
            formEvento.ShowDialog(); // Muestra el formulario en forma modal
            CargarEventos(); // Recarga la lista de eventos
        }
    }
}