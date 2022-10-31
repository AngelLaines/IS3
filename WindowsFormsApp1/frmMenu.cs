using RoyLavadoras;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RoyLavadoras
{
    public partial class frmMenu : Form
    {
        int m, mx, my;
        
        public frmMenu()
        {
            InitializeComponent();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        private void pictureBox2_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel5.Visible) {
                panel5.Visible = false;
            } else
            {
                panel5.Visible = true;
            }
        }

        private void frmMenu_MouseClick(object sender, MouseEventArgs e)
        {
            panel5.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInsertar ins = new frmInsertar();
            ins.Visible=true;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEditar edit = new frmEditar();
            edit.Visible = true;
            this.Hide();
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmBorrar borrar = new frmBorrar();
            borrar.Visible = true;
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmBuscar buscar = new frmBuscar("Nombre");
            this.Hide();
            buscar.Show();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmBuscar buscar = new frmBuscar("Fecha");
            this.Hide();
            buscar.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            frmBuscar buscar = new frmBuscar("Numero");
            this.Hide();
            buscar.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            frmBuscar buscar = new frmBuscar("Domicilio");
            this.Hide();
            buscar.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            frmBuscar buscar = new frmBuscar("Electro");
            this.Hide();
            buscar.Show();
        }


        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                SetDesktopLocation(MousePosition.X - mx-182, MousePosition.Y - my);
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
            mx = 0;
            my = 0;
        }

        private void panel3_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel3_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
            mx = 0;
            my = 0;
        }

        
    }
}
