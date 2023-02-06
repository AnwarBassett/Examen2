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
        
        
        int n=0;
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            
            
            String nom, ape, puesto, cargo, act, gen, sCod="", sCed="", nf="";
            int ced, codemp;
            
            n++;
            nom = txtName.Text;
            ape = txtLastN.Text;
            ced =int.Parse(txtIP.Text);
            codemp = int.Parse(txtIPEMP.Text);
            puesto = CBPuesto.Text;
            cargo = txtWork.Text;
            gen= CBGen.Text;
            act = comboBox1.Text;
            if (nom=="" || ape=="" || puesto=="" || cargo=="" || gen == "" || ced<=0 || codemp<=0)
            {
                MessageBox.Show("No puede ingresar valores negativos, ceros o repetidos");
            }
            else
            {
                
                nf = String.Format("{0}", n);
                sCod = string.Format("{0}", ced);
                sCod = string.Format("{0}", codemp);
            }

            String[] datos = new string[9];
            datos[0] = nf;
            datos[1] = nom;
            datos[2] = ape;
            datos[3] = sCed;
            datos[4] = puesto;
            datos[5] = sCod;
            datos[6] = gen;
            datos[7] = cargo;
            datos[8] = act;
            if (nom == "" || ape == "" || puesto == "" || cargo == "" || gen == "" || sCod=="" || sCed=="") 
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
                                int nm = Convert.ToInt32(row.Cells["N"].Value);
                                MessageBox.Show("El empleado esta activo");

                                //int fila = this.TablaEmpleado.CurrentRow.Index;
                                int f;
                                f = TablaEmpleado.RowCount;
                                for (int i = f - 1; i >= 0; i--)
                                {
                                    if (i == nm)
                                    {
                                        this.TablaEmpleado.CurrentCell = null;
                                        this.TablaEmpleado.Rows[i].Visible = true;
                                    }
                                    else
                                    {
                                        this.TablaEmpleado.CurrentCell = null;
                                        this.TablaEmpleado.Rows[i].Visible = false;
                                    }
                                }
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

                        string busqueda="";

                            busqueda = Convert.ToString(row.Cells["Nombre"].Value);
                        
                        
                        string activo = Convert.ToString(row.Cells["Estado"].Value);
                        if (busq.Text == busqueda)
                        {
                            MessageBox.Show("usuario encontrado");
                            
                            if (activo == "Activo")
                            {
                                
                                MessageBox.Show("El empleado esta activo");
                                TablaEmpleado.CurrentCell = null;

                                
                                int f;
                                f = TablaEmpleado.RowCount;
                                for (int i = f - 1; i >= 0; i--)
                                {
                                    this.TablaEmpleado.CurrentCell = null;
                                    this.TablaEmpleado.Rows[i].Visible = false;
                                }
                                int fila = this.TablaEmpleado.CurrentRow.Index;

                                this.TablaEmpleado.CurrentCell = null;

                                this.TablaEmpleado.Rows[fila].Visible = true;

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
                foreach (DataGridViewRow row in TablaEmpleado.Rows)
                {

                    string tabla = Convert.ToString(row.Cells["Estado"].Value);

                    if (this.busq.Text == tabla)
                    {
                        MessageBox.Show("usuario encontrado");
                        int fila = this.TablaEmpleado.CurrentRow.Index;

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
                int fila = this.TablaEmpleado.CurrentRow.Index;
                int f;
                f = TablaEmpleado.RowCount;
                for (int i = f - 1; i >= 0; i--)
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            TablaEmpleado.Rows.Clear();
        }
    }
}
