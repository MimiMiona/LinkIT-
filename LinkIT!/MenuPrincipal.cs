using System;
using System.Windows.Forms;

namespace LinkIT_
{
    public partial class MenuPrincipal : Form
    {
        private string perfilUsuario;

        public MenuPrincipal(string perfil)
        {
            InitializeComponent();
            perfilUsuario = perfil;
            ConfigurarPermisos();
        }
        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
        }
        private void ConfigurarPermisos()
        {
            if (perfilUsuario == "Consulta")
            {
                bOrganizadores.Enabled = false;
                bEventos.Enabled = false;
                bInscripciones.Enabled = false;
            }

            if (perfilUsuario == "Organizador")
            {
                bUsuarios.Enabled = false;
            }
        }

        private void bOrganizadores_Click(object sender, EventArgs e)
        {
            Organizadores f = new Organizadores();
            f.ShowDialog();
        }
    }
}
