using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace agendaContactosS4
{
    public partial class General : Form
    {
        public General()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//Centra la ventana en la pantalla
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//Impide cambiar el tamaño de la ventana
        }
        private void General_Load(object sender, EventArgs e)
        {
            Conexion.Conecto();
            dataGridView1.DataSource = completaTabla();
        }
        public DataTable completaTabla()
        {
            Conexion.Conecto();
            DataTable dtx = new DataTable();
            string consulta = "SELECT * FROM contactos";
            SqlCommand cmd = new SqlCommand(consulta, Conexion.Conecto());
            SqlDataAdapter dax = new SqlDataAdapter(cmd);
            dax.Fill(dtx);
            return dtx;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipal nombreOb = new MenuPrincipal();
            nombreOb.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[e.RowIndex].Selected = true;
                DataGridViewRow filaSeleccionada = dataGridView1.Rows[e.RowIndex];
                textNombre.Text = filaSeleccionada.Cells[1].Value.ToString();
                textApellido.Text = filaSeleccionada.Cells[2].Value.ToString();
                textTelefono.Text = filaSeleccionada.Cells[3].Value.ToString();
                textCorreo.Text = filaSeleccionada.Cells[4].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conecto();
            string eliminar = "DELETE FROM contactos WHERE Nombre=@Nombre";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conecto());
            cmd3.Parameters.AddWithValue("@Nombre", textNombre.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Libro comprado correctamente");
            dataGridView1.DataSource = completaTabla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Conexion.Conecto();
            string eliminar = "DELETE FROM contactos WHERE Nombre=@Nombre";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conecto());
            cmd3.Parameters.AddWithValue("@Nombre", textNombre.Text);
            cmd3.ExecuteNonQuery();
            dataGridView1.DataSource = completaTabla();
        }
    }
}
