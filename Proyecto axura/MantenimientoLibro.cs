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

    public partial class MantenimientoLibro : Mantenimiento
    {
        DataSet DS = new DataSet();
        String cmd ="";
        Boolean elimina = false;

        public MantenimientoLibro()
        {
            InitializeComponent();
        }

        private void MantenimientoLibro_Load(object sender, EventArgs e)
        {
            llenaTabla();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            String fil = txtBuscar.Text;
            if (String.IsNullOrEmpty(txtBuscar.Text) == false)
            {
                String op = cmbColumna.Text.Trim();
                switch (op)
                {
                    case "ID":
                        filtraTabla("l.id_libro", fil);
                        break;

                    case "ISBN":
                        filtraTabla("l.ISBN", fil);
                        break;

                    case "Título":
                        filtraTabla("l.titulo", fil);
                        break;

                    case "Editorial":
                        filtraTabla("e.editorial", fil);
                        break;

                    case "País":
                        filtraTabla("p.pais", fil);
                        break;

                    case "Tipo":
                        filtraTabla("t.tipo", fil);
                        break;

                    case "Fecha de lanzamiento":
                        filtraTabla("l.fecha_lanzamiento", fil);
                        break;

                    case "Edición":
                        filtraTabla("l.edicion", fil);
                        break;

                    case "Idioma":
                        filtraTabla("l.idioma", fil);
                        break;

                    case "Páginas":
                        filtraTabla("l.paginas", fil);
                        break;

                    default:
                        MessageBox.Show("Selecciona una columna existente");
                        break;

                }
            }
        }

        private void btnBuscarTodos_Click(object sender, EventArgs e)
        {
            llenaTabla();
        }

        public void llenaTabla()
        {
            cmd = String.Format("select l.id_libro, l.ISBN, l.titulo, e.editorial, p.pais, t.tipo, fecha_lanzamiento, edicion, idioma, paginas" +
                " from Libro as l inner join Editorial as e on l.id_editorial = e.id_editorial inner join Pais as p on l.id_pais = p.id_pais " +
                "inner join Tipo_libro as t on l.id_tipo_libro = t.id_tipo_libro");
            DS = Utilidades.Ejecutar(cmd);
            dataGridView1.DataSource = DS.Tables[0];
        }

        public void filtraTabla(String columna, String filtro)
        {
            cmd = String.Format("select l.id_libro, l.ISBN, l.titulo, e.editorial, p.pais, t.tipo, l.fecha_lanzamiento, l.edicion, l.idioma, l." +
                "paginas from Libro as l inner join Editorial as e on l.id_editorial = e.id_editorial inner join Pais as p on l.id_pais = p.id_pais"+
                " inner join Tipo_libro as t on l.id_tipo_libro = t.id_tipo_libro where {0} like '%{1}%'", columna, filtro);
            DS = Utilidades.Ejecutar(cmd);
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt16(dataGridView1.CurrentRow.Cells["id_libro"].Value);
            String isbn = Convert.ToString(dataGridView1.CurrentRow.Cells["isbn"].Value);
            String titulo = Convert.ToString(dataGridView1.CurrentRow.Cells["titulo"].Value);
            String editorial = Convert.ToString(dataGridView1.CurrentRow.Cells["editorial"].Value);
            String pais= Convert.ToString(dataGridView1.CurrentRow.Cells["pais"].Value);
            String tipo = Convert.ToString(dataGridView1.CurrentRow.Cells["tipo"].Value);
            String fecha = Convert.ToString(dataGridView1.CurrentRow.Cells["fecha_lanzamiento"].Value);
            String edicion = Convert.ToString(dataGridView1.CurrentRow.Cells["edicion"].Value);
            String idioma = Convert.ToString(dataGridView1.CurrentRow.Cells["idioma"].Value);
            int paginas = Convert.ToInt16(dataGridView1.CurrentRow.Cells["paginas"].Value);
            EditarLibro EL = new EditarLibro(id, isbn, titulo, editorial, pais, tipo, fecha, edicion, idioma, paginas);
            EL.Show();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            AgregarLibro AL = new AgregarLibro();
            AL.Show();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            String titulo = Convert.ToString(dataGridView1.CurrentRow.Cells["titulo"].Value);
            if (MessageBox.Show("Estás seguro que deseas eliminar: '" + titulo + "'?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
            {
                elimina = true;
                Eliminar();
            }
        }

        public override void Eliminar()
        {
            if (elimina)
            {
                try
                {
                    elimina = false;
                    String cmd = String.Format("Exec Eliminalibro {0}", Convert.ToInt16(dataGridView1.CurrentRow.Cells["id_libro"].Value));
                    Utilidades.Ejecutar(cmd);
                    MessageBox.Show("Registro eliminado con éxito");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);

                }

            }
        }

    }
}
