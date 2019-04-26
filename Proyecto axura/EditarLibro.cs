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
    public partial class EditarLibro : Agregar
    {
        public int id, paginas;
        public String isbn, titulo, editorial, pais, tipo, fecha, edicion, idioma;

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditarLibro_Load(object sender, EventArgs e)
        {
            txtID.Text = Convert.ToString(id);
            txtISBN.Text = isbn;
            txtTitulo.Text = titulo;
            txtEditorial.Text = editorial;
            txtPais.Text = pais;
            txtTipo.Text = tipo;
            txtFecha.Text = fecha;
            txtEdicion.Text = edicion;
            txtIdioma.Text = idioma;
            txtPaginas.Text = Convert.ToString(paginas);
        }

        public EditarLibro()
        {
            InitializeComponent();
        }

        public EditarLibro(int id, String isbn, String titulo, String editorial, String pais, String tipo, String fecha, String edicion, String idioma, int paginas)
        {
            InitializeComponent();
            this.id = id;
            this.isbn = isbn;
            this.titulo = titulo;
            this.editorial = editorial;
            this.pais = pais;
            this.tipo = tipo;
            this.fecha = fecha;
            this.edicion = edicion;
            this.idioma = idioma;
            this.paginas = paginas;
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
                String cmd = String.Format("EXEC ActualizaLibro {0}, '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', {9}", id, isbn, titulo, editorial, pais, tipo, fecha, edicion, idioma, paginas);
                Utilidades.Ejecutar(cmd);
                MessageBox.Show("Libro actualizado correctamente");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex);
            }
        }

    }
}
