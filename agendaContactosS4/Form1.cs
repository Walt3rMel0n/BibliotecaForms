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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//Centra la ventana en la pantalla
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//Impide cambiar el tamaño de la ventana
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Conexion.Conecto();
            //MessageBox.Show("Conexión realizada con éxito");
            dataGridView1.DataSource = completaTabla();
        }
        public DataTable completaTabla()
        {
            Conexion.Conecto();
            DataTable dtx = new DataTable();
            string consulta = "SELECT * FROM contactos";
            SqlCommand cmd = new SqlCommand(consulta,Conexion.Conecto());
            SqlDataAdapter dax = new SqlDataAdapter(cmd);
            dax.Fill(dtx);
            return dtx;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textNombre.Text))
            {
                MessageBox.Show("No se puede dejar el espacio nombre en blanco, por favor asigne un nombre.");
                return;
            }
            if (string.IsNullOrWhiteSpace(textTelefono.Text))
            {
                MessageBox.Show("No se puede dejar el espacio teléfono en blanco, por favor asigne un nombre.");
                return;
            }

            Conexion.Conecto();
            string insertar = "INSERT INTO contactos(Nombre,Apellido,Telefono,Correo)VALUES(@Nombre,@Apellido,@Telefono,@Correo)";
            SqlCommand cmd1 = new SqlCommand(insertar, Conexion.Conecto());
            cmd1.Parameters.AddWithValue("@Nombre", textNombre.Text);
            cmd1.Parameters.AddWithValue("@Apellido", textApellido.Text);
            cmd1.Parameters.AddWithValue("@Telefono", textTelefono.Text);
            cmd1.Parameters.AddWithValue("@Correo", textTelefono.Text);
            cmd1.ExecuteNonQuery();
            MessageBox.Show("Datos guardados correctamente");
            dataGridView1.DataSource = completaTabla();
            textNombre.Text = "";
            textApellido.Text = "";
            textTelefono.Text = "";
            textCorreo.Text = "";

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int idSeleccionado = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Id"].Value);

                Conexion.Conecto();
                string actualizar = "UPDATE contactos SET Nombre=@Nombre, Apellido=@Apellido, Telefono=@Telefono, Correo=@Correo WHERE Id=@Id";
                SqlCommand cmd2 = new SqlCommand(actualizar, Conexion.Conecto());
                cmd2.Parameters.AddWithValue("@Id", idSeleccionado);
                cmd2.Parameters.AddWithValue("@Nombre", textNombre.Text);
                cmd2.Parameters.AddWithValue("@Apellido", textApellido.Text);
                cmd2.Parameters.AddWithValue("@Telefono", textTelefono.Text);
                cmd2.Parameters.AddWithValue("@Correo", textCorreo.Text);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Información actualizada correctamente");
                dataGridView1.DataSource = completaTabla();
                textNombre.Text = "";
                textApellido.Text = "";
                textTelefono.Text = "";
                textCorreo.Text = "";
            }
            else
            {
                MessageBox.Show("Por favor, selecciona una fila para actualizar.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Conexion.Conecto();
            string eliminar = "DELETE FROM contactos WHERE Nombre=@Nombre";
            SqlCommand cmd3 = new SqlCommand(eliminar, Conexion.Conecto());
            cmd3.Parameters.AddWithValue("@Nombre", textNombre.Text);
            cmd3.ExecuteNonQuery();
            MessageBox.Show("Contacto borrado correctamente");
            dataGridView1.DataSource = completaTabla();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textNombre.Clear();
            textApellido.Clear();
            textTelefono.Clear();
            textCorreo.Clear();
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

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            MenuPrincipal forn1 = new MenuPrincipal();
            forn1.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
