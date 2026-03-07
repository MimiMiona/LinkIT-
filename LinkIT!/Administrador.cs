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
        public Administrador()
        {
            InitializeComponent();
        }

        private void LoadUserControl(UserControl uc)
        {
            panelAdministrador.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelAdministrador.Controls.Add(uc);

        }


        private void FormAdministrador_Load(object sender, EventArgs e)
        {
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            lblUsuario.Text = "Usuario: " + Login.Sesion.Nombre;
            LoadUserControl(new UCDashboard());
        }

        private void bDashboard_Click(object sender, EventArgs e)
        {
            UCDashboard uc = new UCDashboard();
            LoadUserControl(uc);
        }

        private void bEventos_Click(object sender, EventArgs e)
        {
            UCMisEventos uc = new UCMisEventos();
            LoadUserControl(uc);
        }

        private void bUsuarios_Click(object sender, EventArgs e)
        {
            UCInscriptos uc = new UCInscriptos();
            LoadUserControl(uc);
        }

        private void bUsuarioTotales_Click(object sender, EventArgs e)
        {
            UCUsuarios uc = new UCUsuarios("Todos");
            LoadUserControl(uc);
        }

        private void bJefeEventos_Click(object sender, EventArgs e)
        {
            UCUsuarios uc = new UCUsuarios("Jefe de Eventos");
            LoadUserControl(uc);
        }

        private void bBackup_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "¿Está seguro que quiere crear una copia de seguridad?",
                "Confirmar copia de seguridad",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (confirm == DialogResult.Yes)
            {
                string fechaHora = DateTime.Now.ToString("yyyyMMdd_HHmmss");
                string ruta = $@"C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\Backup\Linkit_{fechaHora}.bak";

                try
                {
                    Conexion con = new Conexion();
                    con.HacerBackup(ruta);
                    MessageBox.Show("Copia de seguridad creada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al crear el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void bCerrarSesion_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "¿Seguro que desea cerrar sesión?",
                "Confirmación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void bRestaurarBackup_Click(object sender, EventArgs e)
        {

            Backup formPass = new Backup();
            if (formPass.ShowDialog() == DialogResult.OK && formPass.ContraseñaValida)
            {
                DialogResult confirm = MessageBox.Show(
                    "¿Está seguro que quiere cargar una copia de seguridad?\n\n⚠️ Se pisarán los datos actuales.",
                    "Confirmar restauración",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (confirm == DialogResult.Yes)
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "Archivos de Backup (*.bak)|*.bak";
                    openFileDialog.Title = "Seleccionar archivo de backup";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string rutaBackup = openFileDialog.FileName;

                        try
                        {
                            Conexion con = new Conexion();
                            con.RestoreBackup(rutaBackup);
                            MessageBox.Show("Backup restaurado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadUserControl(new UCDashboard());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error al restaurar el backup: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        
    }
}
