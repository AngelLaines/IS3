﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmBorrar : Form
    {
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
    }
}
