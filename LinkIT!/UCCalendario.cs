using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCCalendario : UserControl
    {
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);

        // Lista para almacenar los eventos
        private List<UCMisEventos.Evento> listaEventos = new List<UCMisEventos.Evento>();

        private string rolUsuario;
        private int idUsuario;
        private int posicionY = 10;

        // Constructor para inicializar los valores de rol y usuario
        public UCCalendario(string rol, int idUser)
        {
            InitializeComponent();
            rolUsuario = rol;
            idUsuario = idUser;
        }

        // Evento que se dispara cuando el UserControl se carga
        private void UCCalendario_Load(object sender, EventArgs e)
        {
            labelSubtitulo.ForeColor = colorGrisTexto;
            CargarEventosDesdeBD();
            MarcarDiasConEventos();
            MostrarEventosDelDia(DateTime.Today);
        }

        // Método que carga los eventos desde la base de datos
        private void CargarEventosDesdeBD()
        {
            listaEventos.Clear();
            Conexion con = new Conexion();

            using (SqlConnection conexion = con.AbrirConexion())
            {
                SqlCommand cmd;

                // Consulta dependiendo del rol del usuario
                if (rolUsuario == "Jefe de Eventos")
                {
                    cmd = new SqlCommand(@"
                        SELECT 
                           e.id_evento,
                           e.titulo,
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
                        WHERE CAST(e.fecha_evento AS DATE) >= CAST(GETDATE() AS DATE)
                          AND e.estado <> 'Cancelado';", conexion);
                }
                else
                {
                    // Para usuarios regulares, se filtra por inscripciones
                    cmd = new SqlCommand(@"
                        SELECT e.id_evento, e.titulo, e.fecha_evento, e.horario_inicio, e.horario_fin, 
                               e.capacidad_maxima,
                               CASE 
                                    WHEN e.estado = 'Cancelado' THEN 'Cancelado'
                                    WHEN e.fecha_evento < GETDATE() THEN 'Finalizado'
                                    ELSE 'Activo'
                               END AS estado, 
                               (SELECT COUNT(*) 
                                FROM Inscripcion i2 
                                WHERE i2.id_evento = e.id_evento 
                                AND i2.estado = 'inscripto') AS inscriptos

                        FROM Evento e
                        INNER JOIN Inscripcion i ON e.id_evento = i.id_evento

                        WHERE i.id_usuario = @idUsuario
                        AND i.estado = 'inscripto'   
                        AND CAST(e.fecha_evento AS DATE) >= CAST(GETDATE() AS DATE) 
                        AND e.estado <> 'Cancelado';", conexion);

                    cmd.Parameters.AddWithValue("@idUsuario", idUsuario);
                }

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    UCMisEventos.Evento ev = new UCMisEventos.Evento
                    {
                        IdEvento = Convert.ToInt32(reader["id_evento"]),
                        Titulo = reader["titulo"].ToString(),
                        Fecha = Convert.ToDateTime(reader["fecha_evento"]),
                        Capacidad = Convert.ToInt32(reader["capacidad_maxima"]),
                        Inscriptos = Convert.ToInt32(reader["inscriptos"]),
                        HoraInicio = reader["horario_inicio"] != DBNull.Value
                            ? ((DateTime)reader["horario_inicio"]).TimeOfDay
                            : TimeSpan.Zero,
                        HoraFin = reader["horario_fin"] != DBNull.Value
                            ? ((DateTime)reader["horario_fin"]).TimeOfDay
                            : TimeSpan.Zero
                    };

                    listaEventos.Add(ev);
                }
                reader.Close();
            }
        }

        // Método que marca los días en el calendario que tienen eventos
        private void MarcarDiasConEventos()
        {
            DateTime[] fechasEventos = listaEventos
                .Select(ev => ev.Fecha.Date)
                .Distinct()
                .ToArray();

            CalendarioEvento.BoldedDates = fechasEventos;
        }

        // Evento que se dispara cuando el usuario cambia la fecha en el calendario
        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            MostrarEventosDelDia(e.Start);
        }

        // Muestra los eventos del día seleccionado
        private void MostrarEventosDelDia(DateTime fecha)
        {
            labelEventosDia.Text = "Eventos del día: " + fecha.ToString("d 'de' MMMM");
            panelEventos.Controls.Clear();
            posicionY = 10;

            var eventos = listaEventos
                .Where(ev => ev.Fecha.Date == fecha.Date)
                .ToList();

            if (eventos.Count == 0)
            {
                Label lbl = new Label
                {
                    Text = "No hay eventos para este día.",
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(20, 20),
                    Font = new Font("Segoe UI", 10)
                };
                panelEventos.Controls.Add(lbl);
                return;
            }

            foreach (var evento in eventos)
            {
                Panel card = CrearCardEvento(evento);
                card.Location = new Point(10, posicionY);
                posicionY += card.Height + 10;
                panelEventos.Controls.Add(card);
            }
        }

        // Crea una tarjeta (panel) para mostrar la información del evento
        private Panel CrearCardEvento(UCMisEventos.Evento evento)
        {
            Panel card = new Panel
            {
                Width = 385,
                Height = 90,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            Label titulo = new Label
            {
                Text = evento.Titulo,
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(15, 10)
            };

            // Muestra la relación de inscriptos vs capacidad
            Label ocupacion = new Label
            {
                Text = $"👤 {evento.Inscriptos} / {evento.Capacidad} inscriptos",
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(15, 40)
            };

            Label horario = new Label
            {
                Text = "🕒 " + evento.HoraInicio.ToString(@"hh\:mm") + " - " + evento.HoraFin.ToString(@"hh\:mm"),
                Font = new Font("Segoe UI", 9),
                AutoSize = true,
                Location = new Point(15, 60)
            };

            card.Controls.Add(titulo);
            card.Controls.Add(ocupacion);  // Se agrega la nueva etiqueta de ocupación
            card.Controls.Add(horario);

            return card;
        }
    }
}