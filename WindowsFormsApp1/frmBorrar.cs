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
    public partial class frmBorrar : Form
    {
        private int m, mx, my;

        public frmBorrar()
        {
            InitializeComponent();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInsertar ins = new frmInsertar();
            ins.Visible = true;
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmEditar edit = new frmEditar();
            edit.Visible = true;
            Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Visible = true;
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (panel5.Visible)
            {
                panel5.Visible = false;
            }
            else
            {
                panel5.Visible = true;
            }
        }

        private void frmBorrar_MouseClick(object sender, MouseEventArgs e)
        {
            panel5.Visible = false;
        }

        private void frmBorrar_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            frmBuscar buscar = new frmBuscar("Nombre");
            this.Hide();
            buscar.Show();
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

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel32_MouseDown(object sender, MouseEventArgs e)
        {
            m = 1;
            mx = e.X;
            my = e.Y;
        }

        private void panel32_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                SetDesktopLocation(MousePosition.X - mx, MousePosition.Y - my);
            }
        }

        private void panel32_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
            mx = 0;
            my = 0;
        }

        private void panel4_MouseMove(object sender, MouseEventArgs e)
        {
            if (m == 1)
            {
                SetDesktopLocation(MousePosition.X - mx - 182, MousePosition.Y - my);
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
            mx = 0;
            my = 0;
        }
    }
}
