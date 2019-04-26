using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using MiLibreria;


namespace Proyecto_axura
{
    public partial class VentanaLogin : FormBase
    {
        public VentanaLogin()
        {
            InitializeComponent();
        }

        public static string codigo = "";

        private void btnLog_Click(object sender, EventArgs e)
        {
            try
            {
                string CMD = string.Format("SELECT u.id_usuario, u.cuenta, u.password, c.titulo_cargo FROM usuarios as u join empleados as e on e.id_empleado = u.id_empleado join cargo as c on e.id_cargo = c.id_cargo where cuenta='{0}' AND password='{1}'", txtCuenta.Text.Trim(), txtPassword.Text.Trim());

                DataSet ds = Utilidades.Ejecutar(CMD);

                string cuenta = ds.Tables[0].Rows[0]["cuenta"].ToString().Trim();
                string password = ds.Tables[0].Rows[0]["password"].ToString().Trim();

                codigo = ds.Tables[0].Rows[0]["id_usuario"].ToString().Trim();

                if(cuenta==txtCuenta.Text.Trim() && password == txtPassword.Text.Trim())
                {
                    if (ds.Tables[0].Rows[0]["titulo_cargo"].Equals("Administrador"))
                    {
                        VentanaAdmin venAd = new VentanaAdmin();

                        this.Hide();
                        venAd.Show();
                    }
                    else
                    {
                        MessageBox.Show("No eres administrador");
                    }
                } else
                {
                    MessageBox.Show("Usuario o contraseña incorrecta");
                }

            }
            catch (Exception error)
            {
                MessageBox.Show("Usuario o contraseña incorrecta");
                MessageBox.Show("Error: " + error.Message);

            }
        }

        private void ventanaLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
