using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Examen2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int a = 0;
        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (txtUser.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Necesita ingresar sus datos");
            }
            else
            {
                if (txtUser.Text == "FullAdmin" && txtPassword.Text == "password*123")
                {
                    MessageBox.Show("Datos correctos");
                    this.Hide();
                    Form2 f0 = new Form2();
                    f0.Show();

                }
                else
                {
                    a = a + 1;
                    MessageBox.Show("Datos no encontrado, solo puede intentar 3 veces, lleva " + a + " intentos");
                    txtUser.Clear();
                    txtPassword.Clear();
                    if (a == 3)
                    {
                        MessageBox.Show("Error, no se han encontrado sus datos, saldra del programa");
                        a = 0;
                        Application.Exit();

                    }
                }

            }
        }
    }
}
