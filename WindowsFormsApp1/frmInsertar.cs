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
using RoyLavadoras;

namespace RoyLavadoras
{
    public partial class frmInsertar : Form
    {
        private int id = 0;

        public frmInsertar()
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

        private void frmInsertar_MouseClick(object sender, MouseEventArgs e)
        {
            panel5.Visible = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            frmEditar edit = new frmEditar();
            edit.Visible = true;
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmBorrar borrar = new frmBorrar();
            borrar.Visible = true;
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (txtNombre.Text == "") { txtNombre.Text = "Nombre"; } else { label4.Visible = false; }
        }

        private void label4_Click(object sender, EventArgs e)
        {
            txtNombre.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text=="" ||
                txtAP.Text == "" ||
                txtAM.Text == "" ||
                txtCiudad.Text == "" ||
                txtDomicilio.Text == "" ||
                txtTelefono.Text == "" ||
                txtMarca.Text == "" ||
                txtElectro.Text == "" ||
                txtGarantia.Text == "" ||
                txtImporte.Text == "") {
                MessageBox.Show("Faltan datos por escribir!","Advertencia",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            } else
            {
                DialogResult dialogResult = MessageBox.Show("Usted esta a punto de añadir un articulo vendido con los siguientes datos:\n" +
                "Nombre del cliente: " + txtNombre.Text + " " + txtAP.Text + " " + txtAM.Text + "\n\n" +
                "Datos del domicilio del cliente: \n" +
                "  Ciudad: " + txtCiudad.Text + "\n" +
                "  Domicilio: " + txtDomicilio.Text + "\n" +
                "  Numero: " + txtTelefono.Text + "\n\n" +
                "Electrodomestico: \n" +
                "  Nombre: " + txtElectro.Text + "\n" +
                "  Marca: " + txtMarca.Text + "\n" +
                "  Garantia: " + txtGarantia.Text + "\n" +
                "  Importe: " + txtImporte.Text + "\n\n" +
                "¿Desea añadir los datos de la venta?", "Advertencia", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    DateTime date = DateTime.Now;
                    MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=root;database=roy_lavadoras");
                    string fecha = date.ToString("yyyy-MM-dd");
                    string sql1 = @"insert into clientes(idCliente,nombre,apellidoP,apellidoM) values(" + id.ToString() + ",'" + txtNombre.Text + "','" + txtAP.Text + "','" + txtAM.Text + "')";
                    string sql2 = @"insert into direccion(idDireccion,ciudad,direccion,numero) values(" + id.ToString() + ",'" + txtCiudad.Text + "','" + txtDomicilio.Text + "'," + txtTelefono.Text + ")";
                    string sql3 = @"insert into electrodomesticos(idElectrodomestico,nombre, marca) values(" + id.ToString() + ",'" + txtElectro.Text + "','" + txtMarca.Text + "')";
                    string sql4 = @"insert into ventas(idVenta,precio,garantia,fecha) values(" + id.ToString() + ",'" + txtImporte.Text + "','" + txtGarantia.Text + "','" + fecha + "')";
                    string sql5 = @"insert into clientes_direccion values(" + id.ToString() + "," + id.ToString() + ")";
                    string sql6 = @"insert into clientes_electrodomesticos values(" + id.ToString() + "," + id.ToString() + ")";
                    string sql7 = @"insert into clientes_ventas values(" + id.ToString() + "," + id.ToString() + ")";
                    try
                    {
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sql1, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sql2, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sql3, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sql4, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sql5, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sql6, conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sql7, conn);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Venta registrada con exito!", "Venta");
                        conn.Close();
                        getId();
                    }
                    catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
                }
            }
            
        }

        private void frmInsertar_Load(object sender, EventArgs e)
        {
            getId();
        }
        private void getId() {
            MySqlConnection conn = new MySqlConnection(@"server=localhost;user id=angel;database=roy_lavadoras");
            string sql = @"select max(idCliente) as idCliente from clientes";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader data = cmd.ExecuteReader();
                data.Read();
                if (data["idCliente"].ToString()=="")
                {
                    id = 1;
                }
                else
                {
                    id = 1 + int.Parse(data["idCliente"].ToString());
                }
                conn.Close();
            }
            catch (MySqlException xe) { MessageBox.Show(xe.ToString()); }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click_1(object sender, EventArgs e)
        {

        }

        private void txtAM_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtAP_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
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

        private void txtImporte_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }
    }
}
