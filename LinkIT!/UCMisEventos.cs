using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class UCMisEventos : UserControl
    {
        // Definimos los colores principales para mantener la consistencia
        private Color colorVerdePrincipal = Color.FromArgb(76, 175, 80); // Verde estilo web
        private Color colorGrisTexto = Color.FromArgb(100, 100, 100);
        private Color colorBorde = Color.FromArgb(220, 220, 220);

        public UCMisEventos()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
        }

        private void UCMisEventos_Load(object sender, EventArgs e)
        {
            // Ajustamos el FlowLayoutPanel para que deje espacio arriba para la cabecera
            flowLayoutPanel1.Location = new Point(0, 100);
            flowLayoutPanel1.Size = new Size(this.Width, this.Height - 100);
            flowLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            flowLayoutPanel1.AutoScroll = true;

            ConfigurarCabecera();
            CargarEventos();
        }

        private void ConfigurarCabecera()
        {
            // 1. Creamos el panel que actuará como fondo de la cabecera
            Panel panelCabecera = new Panel();
            panelCabecera.BackColor = Color.White; // ¡Fondo blanco!
            panelCabecera.Location = new Point(0, 0);
            panelCabecera.Size = new Size(this.Width, 100);
            panelCabecera.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // Título principal
            Label lblTituloPrincipal = new Label();
            lblTituloPrincipal.Text = "Mis Eventos";
            lblTituloPrincipal.Font = new Font("Segoe UI", 18, FontStyle.Bold);
            lblTituloPrincipal.Location = new Point(20, 20);
            lblTituloPrincipal.AutoSize = true;

            // Subtítulo
            Label lblSubtitulo = new Label();
            lblSubtitulo.Text = "3 eventos bajo tu responsabilidad";
            lblSubtitulo.Font = new Font("Segoe UI", 10);
            lblSubtitulo.ForeColor = colorGrisTexto;
            lblSubtitulo.Location = new Point(23, 55);
            lblSubtitulo.AutoSize = true;

            // Botón Crear Evento
            Button btnCrearEvento = new Button();
            btnCrearEvento.Text = "+ Crear Evento";
            btnCrearEvento.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnCrearEvento.BackColor = colorVerdePrincipal;
            btnCrearEvento.ForeColor = Color.White;
            btnCrearEvento.FlatStyle = FlatStyle.Flat;
            btnCrearEvento.FlatAppearance.BorderSize = 0;
            btnCrearEvento.Size = new Size(120, 35);
            btnCrearEvento.Cursor = Cursors.Hand;

            // Lo posicionamos basándonos en el ancho del panel
            btnCrearEvento.Location = new Point(panelCabecera.Width - 150, 20);
            btnCrearEvento.Anchor = AnchorStyles.Top | AnchorStyles.Right;

            // 2. Agregamos los textos y el botón AL PANEL (no a 'this')
            panelCabecera.Controls.Add(lblTituloPrincipal);
            panelCabecera.Controls.Add(lblSubtitulo);
            panelCabecera.Controls.Add(btnCrearEvento);

            // 3. Agregamos el panel completo al UserControl
            this.Controls.Add(panelCabecera);
        }
        // Clase auxiliar para manejar mejor los datos del evento
        public class Evento
        {
            public string Titulo { get; set; }
            public string Estado { get; set; }
            public string Descripcion { get; set; }
            public string Fecha { get; set; }
            public string Horario { get; set; }
            public int Inscriptos { get; set; }
            public int Capacidad { get; set; }
            public int PorcentajeOcupacion => Capacidad > 0 ? (Inscriptos * 100) / Capacidad : 0;
        }

        private void CargarEventos()
        {
            flowLayoutPanel1.Controls.Clear();

            // Simulamos los datos que vendrían de la base de datos
            List<Evento> eventos = new List<Evento>
            {
                new Evento { Titulo = "Seminario de Inteligencia Artificial", Estado = "Activo", Descripcion = "Seminario introductorio sobre las bases de la IA y sus aplicaciones en la vida académica.", Fecha = "2026-03-15", Horario = "09:00 - 12:00", Inscriptos = 42, Capacidad = 50 },
                new Evento { Titulo = "Taller de Desarrollo Web", Estado = "Activo", Descripcion = "Taller práctico de desarrollo web con React, Next.js y Tailwind CSS.", Fecha = "2026-03-22", Horario = "14:00 - 18:00", Inscriptos = 28, Capacidad = 30 },
                new Evento { Titulo = "Workshop de UX/UI Design", Estado = "Finalizado", Descripcion = "Taller intensivo de diseño de interfaces y experiencia de usuario.", Fecha = "2026-02-10", Horario = "09:00 - 17:00", Inscriptos = 25, Capacidad = 25 }
            };

            foreach (var evento in eventos)
            {
                Panel card = CrearCard(evento);
                flowLayoutPanel1.Controls.Add(card);
            }
        }

        private Panel CrearCard(Evento evento)
        {
            Panel card = new Panel();
            card.Width = 850; // Más ancho para que entren todos los elementos
            card.Height = 130;
            card.BackColor = Color.White;
            card.Margin = new Padding(20, 10, 20, 10);
            card.BorderStyle = BorderStyle.FixedSingle;

            // --- SECCIÓN IZQUIERDA (Textos) ---

            Label lblTitulo = new Label();
            lblTitulo.Text = evento.Titulo;
            lblTitulo.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblTitulo.Location = new Point(15, 15);
            lblTitulo.AutoSize = true;

            // Badge de Estado (Activo/Finalizado)
            Label lblEstado = new Label();
            lblEstado.Text = evento.Estado;
            lblEstado.Font = new Font("Segoe UI", 8, FontStyle.Bold);
            lblEstado.AutoSize = true;
            lblEstado.Padding = new Padding(5, 2, 5, 2); // Simular "badge"
            if (evento.Estado == "Activo")
            {
                lblEstado.BackColor = Color.FromArgb(230, 245, 230); // Fondo verde claro
                lblEstado.ForeColor = colorVerdePrincipal;
            }
            else
            {
                lblEstado.BackColor = Color.FromArgb(255, 240, 230); // Fondo naranja claro
                lblEstado.ForeColor = Color.DarkOrange;
            }
            card.Controls.Add(lblTitulo);
            // Posicionamos el estado justo después del título
            lblEstado.Location = new Point(lblTitulo.Right + 300, 18); // Ajuste temporal, lo calculamos mejor abajo

            Label lblDescripcion = new Label();
            lblDescripcion.Text = evento.Descripcion;
            lblDescripcion.Font = new Font("Segoe UI", 9.5f);
            lblDescripcion.ForeColor = Color.FromArgb(64, 64, 64);
            lblDescripcion.Location = new Point(15, 45);
            lblDescripcion.AutoSize = true;

            // Fila de información inferior (Fecha, Horario, Inscriptos)
            Label lblInfo = new Label();
            lblInfo.Text = $"📅 {evento.Fecha}    🕒 {evento.Horario}    👥 {evento.Inscriptos} / {evento.Capacidad}";
            lblInfo.Font = new Font("Segoe UI", 9);
            lblInfo.ForeColor = colorGrisTexto;
            lblInfo.Location = new Point(15, 90);
            lblInfo.AutoSize = true;


            // --- SECCIÓN DERECHA (Progreso y Botones) ---

            int panelDerechoX = 600; // Punto de inicio para los elementos de la derecha

            Label lblOcupacion = new Label();
            lblOcupacion.Text = $"Ocupación          {evento.PorcentajeOcupacion}%";
            lblOcupacion.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            lblOcupacion.ForeColor = evento.PorcentajeOcupacion >= 100 ? Color.DarkOrange : colorVerdePrincipal;
            lblOcupacion.AutoSize = true;
            lblOcupacion.Location = new Point(panelDerechoX + 50, 15);

            ProgressBar progress = new ProgressBar();
            progress.Value = evento.PorcentajeOcupacion;
            progress.Width = 220;
            progress.Height = 10;
            progress.Location = new Point(panelDerechoX, 35);

            // Botón Editar (Blanco con borde gris)
            Button btnEditar = new Button();
            btnEditar.Text = "✏️ Editar";
            btnEditar.Font = new Font("Segoe UI", 9);
            btnEditar.FlatStyle = FlatStyle.Flat;
            btnEditar.FlatAppearance.BorderColor = colorBorde;
            btnEditar.BackColor = Color.White;
            btnEditar.Size = new Size(90, 32);
            btnEditar.Location = new Point(panelDerechoX, 65);
            btnEditar.Cursor = Cursors.Hand;

            // Botón Inscriptos (Verde)
            Button btnInscriptos = new Button();
            btnInscriptos.Text = "👁️ Inscriptos";
            btnInscriptos.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            btnInscriptos.FlatStyle = FlatStyle.Flat;
            btnInscriptos.FlatAppearance.BorderSize = 0;
            btnInscriptos.BackColor = colorVerdePrincipal;
            btnInscriptos.ForeColor = Color.White;
            btnInscriptos.Size = new Size(120, 32);
            btnInscriptos.Location = new Point(panelDerechoX + 100, 65);
            btnInscriptos.Cursor = Cursors.Hand;

            // Ajustamos la posición del Badge de estado de manera dinámica al título
            lblTitulo.Tag = lblEstado; // Guardar referencia
            card.Layout += (s, e) => { lblEstado.Location = new Point(lblTitulo.Right + 10, 18); };

            // Añadir todo a la card
            card.Controls.Add(lblTitulo);
            card.Controls.Add(lblEstado);
            card.Controls.Add(lblDescripcion);
            card.Controls.Add(lblInfo);
            card.Controls.Add(lblOcupacion);
            card.Controls.Add(progress);
            card.Controls.Add(btnEditar);
            card.Controls.Add(btnInscriptos);

            return card;
        }
    }
}