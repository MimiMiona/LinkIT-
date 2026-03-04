namespace LinkIT_
{
    partial class MenuPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuPrincipal));
            bUsuarios = new Button();
            bOrganizadores = new Button();
            bInscripciones = new Button();
            bReportes = new Button();
            bEventos = new Button();
            SuspendLayout();
            // 
            // bUsuarios
            // 
            bUsuarios.BackColor = Color.PaleGoldenrod;
            bUsuarios.FlatStyle = FlatStyle.Popup;
            bUsuarios.Location = new Point(156, 69);
            bUsuarios.Name = "bUsuarios";
            bUsuarios.Size = new Size(148, 54);
            bUsuarios.TabIndex = 0;
            bUsuarios.Text = "Usuarios";
            bUsuarios.UseVisualStyleBackColor = false;
            // 
            // bOrganizadores
            // 
            bOrganizadores.BackColor = Color.PaleGoldenrod;
            bOrganizadores.FlatStyle = FlatStyle.Popup;
            bOrganizadores.Location = new Point(81, 129);
            bOrganizadores.Name = "bOrganizadores";
            bOrganizadores.Size = new Size(148, 54);
            bOrganizadores.TabIndex = 1;
            bOrganizadores.Text = "Organizadores";
            bOrganizadores.UseVisualStyleBackColor = false;
            bOrganizadores.Click += bOrganizadores_Click;
            // 
            // bInscripciones
            // 
            bInscripciones.BackColor = Color.PaleGoldenrod;
            bInscripciones.FlatStyle = FlatStyle.Popup;
            bInscripciones.Location = new Point(235, 129);
            bInscripciones.Name = "bInscripciones";
            bInscripciones.Size = new Size(149, 55);
            bInscripciones.TabIndex = 2;
            bInscripciones.Text = "Inscripciones";
            bInscripciones.UseVisualStyleBackColor = false;
            // 
            // bReportes
            // 
            bReportes.BackColor = Color.PaleGoldenrod;
            bReportes.FlatStyle = FlatStyle.Popup;
            bReportes.Location = new Point(235, 189);
            bReportes.Name = "bReportes";
            bReportes.Size = new Size(149, 54);
            bReportes.TabIndex = 3;
            bReportes.Text = "Reportes";
            bReportes.UseVisualStyleBackColor = false;
            // 
            // bEventos
            // 
            bEventos.BackColor = Color.PaleGoldenrod;
            bEventos.FlatStyle = FlatStyle.Popup;
            bEventos.Location = new Point(81, 189);
            bEventos.Name = "bEventos";
            bEventos.Size = new Size(148, 54);
            bEventos.TabIndex = 4;
            bEventos.Text = "Eventos";
            bEventos.UseVisualStyleBackColor = false;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Ivory;
            ClientSize = new Size(468, 316);
            Controls.Add(bEventos);
            Controls.Add(bReportes);
            Controls.Add(bInscripciones);
            Controls.Add(bOrganizadores);
            Controls.Add(bUsuarios);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MenuPrincipal";
            Text = "Menu";
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button bUsuarios;
        private Button bOrganizadores;
        private Button bInscripciones;
        private Button bReportes;
        private Button bEventos;
    }
}