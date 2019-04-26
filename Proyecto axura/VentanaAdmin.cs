using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MiLibreria;

namespace Proyecto_axura
{
    public partial class VentanaAdmin : FormBase
    {
        public VentanaAdmin()
        {
            InitializeComponent();
        }

        private void ventanaAdmin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void ventanaAdmin_Load(object sender, EventArgs e)
        {
            string CMD = string.Format("Select e.nombre, u.cuenta, u.id_usuario, u.foto from empleados as e join usuarios as u on e.id_empleado=u.id_empleado where id_usuario={0}",VentanaLogin.codigo);

            DataSet DS = Utilidades.Ejecutar(CMD);

            lblNomAd.Text = DS.Tables[0].Rows[0]["nombre"].ToString();
            lblUsAdmin.Text = DS.Tables[0].Rows[0]["cuenta"].ToString();
            lblCodigo.Text = DS.Tables[0].Rows[0]["id_usuario"].ToString();

            string url = DS.Tables[0].Rows[0]["foto"].ToString();

            pictureBox1.Image = Image.FromFile(url);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            ContenedorPrincipal CP = new ContenedorPrincipal();

            CP.Show();
        }
    }
}


