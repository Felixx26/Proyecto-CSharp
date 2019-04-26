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
    public partial class AgregarLibro : Agregar
    {

        public int paginas;
        public String isbn, titulo, editorial, pais, tipo, fecha, edicion, idioma;

        public AgregarLibro()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public override void Guardar()
        {
            isbn = txtISBN.Text;
            titulo = txtTitulo.Text;
            editorial = txtEditorial.Text;
            pais = txtPais.Text;
            tipo = txtTipo.Text;
            fecha = txtFecha.Text;
            edicion = txtEdicion.Text;
            idioma = txtIdioma.Text;
            paginas = Convert.ToInt32(txtPaginas.Text);
            try
            {
                String cmd = String.Format("EXEC ActualizaLibro {0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}", -1, isbn, titulo, editorial, pais, tipo, fecha, edicion, idioma, paginas);
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Libro Añadido correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }
    }
}
