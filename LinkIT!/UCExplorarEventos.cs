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
            public string Titulo { get; set; }
            public string Estado { get; set; }
            public string Descripcion { get; set; }
            public string Fecha { get; set; }
            public string Horario { get; set; }
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

            List<Evento> eventos = new List<Evento>
            {
                new Evento {
                    Titulo = "Seminario de Inteligencia Artificial",
                    Estado = "Disponible",
                    Descripcion = "Seminario introductorio sobre las bases de la IA.",
                    Fecha = "15/03/2026",
                    Horario = "09:00 - 12:00",
                    Inscriptos = 42,
                    Capacidad = 50
                },
                new Evento {
                    Titulo = "Taller de Desarrollo Web",
                    Estado = "Disponible",
                    Descripcion = "Taller práctico con React y Tailwind.",
                    Fecha = "22/03/2026",
                    Horario = "14:00 - 18:00",
                    Inscriptos = 28,
                    Capacidad = 30
                },
                new Evento {
                    Titulo = "Conferencia de Ciberseguridad",
                    Estado = "Disponible",
                    Descripcion = "Conferencia magistral sobre seguridad digital.",
                    Fecha = "05/04/2026",
                    Horario = "10:00 - 13:00",
                    Inscriptos = 65,
                    Capacidad = 80
                }
            };

            foreach (var evento in eventos)
            {
                flowEventos.Controls.Add(CrearCard(evento));
            }

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
            lblInfo.Text = $"{evento.Fecha}   |   {evento.Horario}   |   {evento.Inscriptos}/{evento.Capacidad}";
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