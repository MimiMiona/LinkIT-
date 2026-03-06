using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace LinkIT_
{
    public partial class Backup : Form
    {
        public bool ContraseñaValida { get; private set; } = false;

        public Backup()
        {
            InitializeComponent();
        }

        // Mismo método de hash que en el login
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();

                foreach (byte b in bytes)
                    builder.Append(b.ToString("X2"));

                return builder.ToString();
            }
        }

        private void bCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bAceptar_Click(object sender, EventArgs e)
        {
            string contraseñaIngresada = txtClave.Text.Trim();

            if (string.IsNullOrEmpty(contraseñaIngresada))
            {
                MessageBox.Show("Ingrese su contraseña.", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                Conexion con = new Conexion();

                SqlCommand cmd = new SqlCommand(
                "SELECT contraseña FROM Usuario WHERE id_usuario = @id",
                con.AbrirConexion());

                cmd.Parameters.AddWithValue("@id", Login.Sesion.IdUsuario);

                object result = cmd.ExecuteScalar();

                if (result != null)
                {
                    string contraseñaHashBDD = result.ToString();
                    string contraseñaHashIngresada = HashPassword(contraseñaIngresada);

                    if (contraseñaHashBDD == contraseñaHashIngresada)
                    {
                        ContraseñaValida = true;
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Contraseña incorrecta.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtClave.Clear();
                        txtClave.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("No se encontró el usuario actual.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                con.CerrarConexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al verificar la contraseña: " + ex.Message);
            }
        }
    }


}
