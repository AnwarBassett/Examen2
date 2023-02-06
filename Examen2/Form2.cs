using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace Examen2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Random aleatorio = new Random();
        //var hash = new HashSet<int>();
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            
            String nom, ape, puesto, cargo, act, gen, sCod="", sCed="";
            String ced, codemp;
            nom = txtName.Text;
            ape = txtLastN.Text;
            ced = txtIP.Text;
            codemp = txtIPEMP.Text;
            puesto = CBPuesto.Text;
            cargo = txtWork.Text;
            gen= CBGen.Text;
            act = comboBox1.Text;
            if (nom=="" || ape=="" || puesto=="" || cargo=="" || gen == "" || ced=="" || codemp=="")
            {
                MessageBox.Show("No puede ingresar valores negativos o superiores a 100");
            }

            String[] datos = new string[8];
            datos[0] = nom;
            datos[1] = ape;
            datos[2] = ced;
            datos[3] = puesto;
            datos[4] = codemp;
            datos[5] = gen;
            datos[6] = cargo;
            datos[7] = act;
            if (nom == "" || ape == "" || puesto == "" || cargo == "" || gen == "" || codemp=="" || ced=="") 
            {
                MessageBox.Show("No hay datos para agregar");
            }
            else
            {
                TablaEmpleado.Rows.Add(datos);
                CleanFild();
            }
        }
        public void CleanFild()
        {
            txtName.Text = String.Empty;
            txtLastN.Text = String.Empty;
            txtIP.Text = String.Empty;
            txtIPEMP.Text = String.Empty;
            txtWork.Text = String.Empty;
            CBGen.SelectedIndex = 0;
            CBPuesto.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
            txtName.Focus();


        }
        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void Buscar_Click(object sender, EventArgs e)
        {
            if(busq.Text != "")
            {
                if (BCod.Checked)
                {
                    foreach (DataGridViewRow row in TablaEmpleado.Rows)
                    {

                        string busqueda = Convert.ToString(row.Cells["Codigo_Empleado"].Value);

                        if (this.busq.Text == busqueda)
                        {
                            MessageBox.Show("usuario encontrado");
                            string activo = Convert.ToString(row.Cells["Estado"].Value);
                            if (activo == "Activo")
                            {

                                MessageBox.Show("El empleado esta activo");

                                int fila = this.TablaEmpleado.CurrentRow.Index;

                                this.TablaEmpleado.CurrentCell = null;


                                this.TablaEmpleado.Rows[fila].Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("El empleado esta dado de baja");
                            }

                        }
                        else
                        {
                            MessageBox.Show("usuario no encontrado");

                        }

                    }
                }
                if (Bname.Checked)
                {
                    foreach (DataGridViewRow row in TablaEmpleado.Rows)
                    {

                        string busqueda = Convert.ToString(row.Cells["Nombre"].Value);

                        if (this.busq.Text == busqueda)
                        {
                            MessageBox.Show("usuario encontrado");
                            string activo = Convert.ToString(row.Cells["Estado"].Value);
                            if (activo == "Activo")
                            {
                                MessageBox.Show("El empleado esta activo");

                                int fila = this.TablaEmpleado.CurrentRow.Index;

                                this.TablaEmpleado.CurrentCell = null;

                                this.TablaEmpleado.Rows[fila].Visible = false;
                            }
                            else
                            {
                                MessageBox.Show("El empleado esta dado de baja");
                            }

                        }
                        else
                        {
                            MessageBox.Show("usuario no encontrado");

                        }

                    }
                }
            }
            if (chkEstado.Checked)
            {
                if (busq.Text != "")
                {

                    foreach (DataGridViewRow row in TablaEmpleado.Rows)
                    {

                        string tabla = Convert.ToString(row.Cells["Estado"].Value);

                        if (this.busq.Text == tabla)
                        {
                            MessageBox.Show("usuario encontrado");
                            int fila =this.TablaEmpleado.CurrentRow.Index;

                            this.TablaEmpleado.CurrentCell = null;

                            this.TablaEmpleado.Rows[fila].Visible = false;
                            
                            return;

                        }
                        else
                        {
                            MessageBox.Show("No encontrado");
                        }

                    }
                }
                else
                {
                    MessageBox.Show("Favor digite un valor");
                    int f;
                    f = TablaEmpleado.RowCount;
                    for (int i = f - 1; i >= 0; i--)
                    {
                        this.TablaEmpleado.CurrentCell = null;

                        this.TablaEmpleado.Rows[i].Visible = true;
                    }
                }

            }
            else
            {
                //int fila = this.TablaEmpleado.CurrentRow.Index;
                int f;
                f = TablaEmpleado.RowCount;
                for(int i=f-1; i >= 0; i--)
                {
                    this.TablaEmpleado.CurrentCell = null;

                    this.TablaEmpleado.Rows[i].Visible = true;
                }
                
            }
            
        }
        
        private void Form2_Load(object sender, EventArgs e)
        {
            TablaEmpleado.AllowUserToAddRows= false;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {

        }
    }
}
