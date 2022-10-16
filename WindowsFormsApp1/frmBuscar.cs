using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace RoyLavadoras
{
    public partial class frmBuscar : Form
    {
        private String search;
        public frmBuscar(String search)
        {
            this.search = search;
            InitializeComponent();
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

        private void frmBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            panel5.Visible = false;
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            Font fuente = new Font("Arial", 15, GraphicsUnit.Pixel);
            gridBuscar.DefaultCellStyle.Font = fuente;
            gridBuscar.ColumnHeadersDefaultCellStyle.Font = fuente;
            switch (search) {
                case "Nombre":
                    lblNombre.Visible = true;
                    lblAM.Visible = true;
                    lblAP.Visible = true;
                    txtNombre.Visible = true;
                    txtAP.Visible = true;
                    txtAM.Visible = true;
                    btnBuscarN.Visible = true;
                    panN1.Visible = true;
                    panN2.Visible = true;
                    panN3.Visible = true;
                    break;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=roy_lavadoras");
            string sql = @"select c.idcliente,e.idelectrodomestico,v.idVenta,d.iddireccion from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where c.nombre='"+txtNombre.Text+"' and c.apellidop='"+txtAP.Text+"' and c.apellidom='"+txtAM.Text+"'";
            try
            {

                conn.Open();


                MySqlDataAdapter dataAdapter = new MySqlDataAdapter();
                dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
                DataTable table = new DataTable();

                dataAdapter.Fill(table);

                BindingSource bSource = new BindingSource();
                bSource.DataSource = table;

                gridBuscar.DataSource = bSource;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInsertar ins = new frmInsertar();
            Close();
            ins.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEditar ed = new frmEditar();
            Close();ed.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmBorrar del = new frmBorrar();
            Close();del.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            Close(); menu.Show();
        }
    }
}
