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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;//Centra la ventana en la pantalla
            this.FormBorderStyle = FormBorderStyle.FixedDialog;//Impide cambiar el tamaño de la ventana

        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Establece la conexión a la base de datos
            using (SqlConnection cnx = Conexion.Conecto())
            {
                // Crea una consulta SQL para buscar el usuario y la contraseña en la tabla Usuarios
                string query = "SELECT COUNT(*) FROM Usuarios WHERE Nusuario = @usuario AND Contrasena = @contrasena";

                // Crea un comando SQL para ejecutar la consulta
                using (SqlCommand cmd = new SqlCommand(query, cnx))
                {
                    // Añade los parámetros de usuario y contraseña a la consulta
                    cmd.Parameters.AddWithValue("@usuario", textBox1.Text);
                    cmd.Parameters.AddWithValue("@contrasena", textBox2.Text);

                    // Ejecuta la consulta y obtiene el resultado
                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    // Verifica si se encontró un usuario con las credenciales proporcionadas
                    if (count > 0)
                    {
                        // Si las credenciales son correctas, se busca el rol del usuario
                        string rolQuery = "SELECT Rol FROM Usuarios WHERE Nusuario = @usuario";
                        using (SqlCommand rolCmd = new SqlCommand(rolQuery, cnx))
                        {
                            rolCmd.Parameters.AddWithValue("@usuario", textBox1.Text);
                            string rol = rolCmd.ExecuteScalar().ToString(); // Se obtiene el rol del usuario

                            // Verifica el rol del usuario y redirige al formulario correspondiente
                            if (rol == "admin")
                            {
                                // Si el rol es "admin", abre el Form1 y cierra el formulario actual
                                Form1 form1 = new Form1();
                                form1.Show();
                                this.Hide(); // Opcional: oculta el formulario actual
                            }
                            else if (rol == "user")
                            {
                                // Si el rol es "user", abre el formulario "General" y cierra el formulario actual
                                General generalForm = new General();
                                generalForm.Show();
                                this.Hide(); // Opcional: oculta el formulario actual
                            }
                            else
                            {
                                // Si el rol no es ni "admin" ni "user", muestra un mensaje de error
                                MessageBox.Show("Rol no válido para el usuario", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        // Si no se encuentra ningún usuario con las credenciales proporcionadas, muestra un mensaje de error
                        MessageBox.Show("Nombre de usuario o contraseña incorrectos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

