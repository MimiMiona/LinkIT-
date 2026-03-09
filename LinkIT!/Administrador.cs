using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LinkIT_
{
    public partial class Administrador : Form
    {
        // Constructor del formulario
        public Administrador()
        {
            InitializeComponent();  // Inicializa los componentes del formulario
        }

        // Carga un UserControl dentro del panel
        private void LoadUserControl(UserControl uc)
        {
            panelAdministrador.Controls.Clear();  // Limpia el panel antes de agregar un nuevo control
            uc.Dock = DockStyle.Fill;  // Ajusta el control al tamaño del panel
            panelAdministrador.Controls.Add(uc);  // Agrega el control al panel
        }

        // Evento que ocurre cuando se carga el formulario
        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;  // Ajusta el modo de imagen del PictureBox
            lblUsuario.Text = "Usuario: " + Login.Sesion.Nombre;  // Muestra el nombre del usuario en el label
            LoadUserControl(new UCDashboard());  // Carga el control UCDashboard como pantalla inicial
        }

        // Carga el control de Dashboard cuando el botón es clickeado
        private void bDashboard_Click(object sender, EventArgs e)
        {
            UCDashboard uc = new UCDashboard();  // Crea una nueva instancia del control UCDashboard
            LoadUserControl(uc);  // Carga el control en el panel
        }

        // Carga el control de Eventos cuando el botón es clickeado
        private void bEventos_Click(object sender, EventArgs e)
        {
            UCEventoAdministrador uc = new UCEventoAdministrador();  // Crea una nueva instancia de UCEventoAdministrador
            LoadUserControl(uc);  // Carga el control en el panel
        }

        // Carga el control de Usuarios Totales cuando el botón es clickeado
        private void bUsuarioTotales_Click(object sender, EventArgs e)
        {
            UCUsuarios uc = new UCUsuarios("Todos");  // Crea una nueva instancia del control UCUsuarios con el parámetro "Todos"
            LoadUserControl(uc);  // Carga el control en el panel
        }

        // Carga el control de Jefe de Eventos cuando el botón es clickeado
        private void bJefeEventos_Click(object sender, EventArgs e)
        {
            UCUsuarios uc = new UCUsuarios("Jefe de Eventos");  // Crea una nueva instancia de UCUsuarios con el parámetro "Jefe de Eventos"
            LoadUserControl(uc);  // Carga el control en el panel
        }

        // Crea una copia de seguridad de la base de datos
        private void bBackup_Click(object sender, EventArgs e)
        {
            // Pide confirmación al usuario para crear un backup
            DialogResult confirm = MessageBox.Show(
                "¿Está seguro que quiere crear una copia de seguridad?",
                "Confirmar copia de seguridad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Si el usuario confirma, se procede a crear el backup
            if (confirm == DialogResult.Yes)
            {
                string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");  // Obtiene la fecha y hora actual
                string ruta = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\Linkit_{fechaHora}.bak";  // Define la ruta para el archivo de backup

                try
                {
                    Conexion con = new Conexion();  // Crea una nueva instancia de la clase Conexion
                    con.HacerBackup(ruta);  // Realiza el backup
                    MessageBox.Show("Copia de seguridad creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Muestra mensaje de éxito
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra mensaje de error
                }
            }
        }

        // Cierra la sesión del usuario
        private void bCerrarSesion_Click(object sender, EventArgs e)
        {
            // Pide confirmación al usuario para cerrar sesión
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea cerrar sesión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Si el usuario confirma, se cierra el formulario
            if (result == DialogResult.Yes)
            {
                this.Close();  // Cierra la aplicación
            }
        }

        // Restaura un archivo de backup de la base de datos
        private void bRestaurarBackup_Click(object sender, EventArgs e)
        {
            Backup formPass = new Backup();  // Crea una instancia del formulario de Backup para validar la contraseña
            if (formPass.ShowDialog() == DialogResult.OK && formPass.ContraseñaValida)  // Verifica si la contraseña es válida
            {
                // Pide confirmación al usuario para restaurar el backup
                DialogResult confirm = MessageBox.Show(
                    "¿Está seguro que quiere cargar una copia de seguridad?\n\n⚠️ Se pisarán los datos actuales.",
                    "Confirmar restauración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                // Si el usuario confirma, se procede a seleccionar y restaurar el backup
                if (confirm == DialogResult.Yes)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();  // Crea el cuadro de diálogo para seleccionar un archivo
                    openFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak";  // Solo permite seleccionar archivos .bak
                    openFileDialog.Title = "Seleccionar archivo de backup";  // Establece el título del cuadro de diálogo

                    if (openFileDialog.ShowDialog() == DialogResult.OK)  // Si el usuario selecciona un archivo
                    {
                        string rutaBackup = openFileDialog.FileName;  // Obtiene la ruta del archivo seleccionado

                        try
                        {
                            Conexion con = new Conexion();  // Crea una nueva instancia de la clase Conexion
                            con.RestoreBackup(rutaBackup);  // Restaura el backup desde el archivo seleccionado
                            MessageBox.Show("Backup restaurado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);  // Muestra mensaje de éxito
                            LoadUserControl(new UCDashboard());  // Recarga el control UCDashboard
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al restaurar el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);  // Muestra mensaje de error
                        }
                    }
                }
            }
        }
    }
}