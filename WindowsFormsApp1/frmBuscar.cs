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
        private string buscar="";
        private int m, mx, my;
        private String search;
        Connection cn;
        public frmBuscar(String search)
        {
            cn = new Connection();
            this.search = search;
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            switch (buscar) {
                case "nombre":
                    if (panel5.Visible)
                    {
                        panel5.Visible = false;
                    }
                    else
                    {
                        panel5.Visible = true;
                    }
                    break;
                case "fecha":
                    if (panel19.Visible)
                    {
                        panel19.Visible = false;
                    }
                    else
                    {
                        panel19.Visible = true;
                    }
                    break;
                case "numero":
                    if (panel20.Visible)
                    {
                        panel20.Visible = false;
                    }
                    else
                    {
                        panel20.Visible = true;
                    }
                    break;
                case "domi":
                    if (panel21.Visible)
                    {
                        panel21.Visible = false;
                    }
                    else
                    {
                        panel21.Visible = true;
                    }
                    break;
                case "electro":
                    if (panel22.Visible)
                    {
                        panel22.Visible = false;
                    }
                    else
                    {
                        panel22.Visible = true;
                    }
                    break;
            }
            
        }

        private void frmBuscar_MouseClick(object sender, MouseEventArgs e)
        {
            switch (buscar) {
                case "nombre":
                    panel5.Visible = false;
                    break;
                case "fecha":
                    panel19.Visible = false;
                    break;
                case "numero":
                    panel20.Visible = false;
                    break;
                case "domi":
                    panel21.Visible = false;
                    break;
                case "electro":
                    panel22.Visible = false;
                    break;
            }
            
        }

        private void frmBuscar_Load(object sender, EventArgs e)
        {
            Font fuente = new Font("Arial", 15, GraphicsUnit.Pixel);
            gridBuscar.DefaultCellStyle.Font = fuente;
            gridBuscar.ColumnHeadersDefaultCellStyle.Font = fuente;
            
            switch (search) {
                case "Nombre":
                    panel6.Visible = true;
                    buscar = "nombre";
                    gridBuscar.Location = new Point(182, 161);
                    gridBuscar.Height = 393;
                    break;
                case "Fecha":
                    buscar = "fecha";
                    panel8.Visible = true;
                    gridBuscar.Location = new Point(182,161);
                    gridBuscar.Height = 393;
                    break;
                case "Numero":
                    buscar = "numero";
                    panel12.Visible = true;
                    gridBuscar.Location = new Point(182, 161);
                    gridBuscar.Height = 393;
                    break;
                case "Domicilio":
                    buscar = "domi";
                    panel16.Visible = true;
                    gridBuscar.Location = new Point(182, 161);
                    gridBuscar.Height = 393;
                    break;
                case "Electro":
                    buscar = "electro";
                    panel23.Visible = true;
                    gridBuscar.Location = new Point(182, 161);
                    gridBuscar.Height = 393;
                    break;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select c.idcliente as 'Id Cliente',c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where c.nombre='" + txtNombre.Text+"'";
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

        private void setVisiblePanels() {
            panel6.Visible = false;
            panel8.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string fecha =dateTimePicker1.Value.ToString("yyyy-MM-dd");
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select c.idcliente as 'Id Cliente',c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where v.fecha='" + fecha +"'";
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

        private void button7_Click(object sender, EventArgs e)
        {
            porFecha();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            porNumero();
        }

        private void button11_Click_1(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string numero = txtNumero.Text;
            if (numero =="") {
                numero = "0";
            }
            string sql = @"select c.idcliente as 'Id Cliente',c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where d.numero=" + numero;
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

        private void txtNumero_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= 32 && e.KeyChar <= 47) || (e.KeyChar >= 58 && e.KeyChar <= 255))
            {
                e.Handled = true;
                return;
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select c.idcliente as 'Id Cliente', c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where d.direccion='" + txtDireccion.Text+ "'";
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

        private void button8_Click(object sender, EventArgs e)
        {
            porDomi();
        }
        private void porNombre() {
            panel5.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;

            panel6.Visible = true;
            panel16.Visible = false;
            panel23.Visible = false;
            panel12.Visible = false;
            panel8.Visible = false;
            buscar = "nombre";
            gridBuscar.DataSource = null;
           
        }
        private void porFecha()
        {
            panel5.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;

            panel6.Visible = false;
            panel16.Visible = false;
            panel12.Visible = false;
            panel23.Visible = false;
            panel8.Visible = true;
            buscar = "fecha";
            gridBuscar.DataSource = null;
      
        }
        private void porNumero()
        {
            panel5.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;

            panel6.Visible = false;
            panel16.Visible = false;
            panel12.Visible = true;
            panel8.Visible = false;
            panel23.Visible = false;
            buscar = "numero";
            gridBuscar.DataSource = null;
    
        }
        private void porDomi()
        {
            panel5.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;

            panel6.Visible = false;
            panel16.Visible = true;
            panel12.Visible = false;
            panel8.Visible = false;
            panel23.Visible = false;
            buscar = "domi";
            gridBuscar.DataSource = null;
        }
        private void porElectro()
        {
            panel5.Visible = false;
            panel19.Visible = false;
            panel20.Visible = false;
            panel21.Visible = false;
            panel22.Visible = false;

            panel6.Visible = false;
            panel16.Visible = false;
            panel12.Visible = false;
            panel8.Visible = false;
            panel23.Visible = true;
            buscar = "electro";
            gridBuscar.DataSource = null;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            porNombre();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            porNumero();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            porDomi();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            porNombre();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            porFecha();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            porDomi();
        }

        private void button24_Click(object sender, EventArgs e)
        {
            porNombre();
        }

        private void button23_Click(object sender, EventArgs e)
        {
            porFecha();
        }

        private void button22_Click(object sender, EventArgs e)
        {
            porNumero();
        }

        private void button28_Click(object sender, EventArgs e)
        {
            porFecha();
        }

        private void button27_Click(object sender, EventArgs e)
        {
            porNumero();
        }

        private void button26_Click(object sender, EventArgs e)
        {
            porDomi();
        }

        private void button29_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select c.idcliente as 'Id Cliente',c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where e.marca='" + txtMarca.Text + "'";
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

        private void button25_Click(object sender, EventArgs e)
        {
            porNombre();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            porElectro();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            porElectro();
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
                SetDesktopLocation(MousePosition.X - mx - 182, MousePosition.Y - my);
            }
        }

        private void panel4_MouseUp(object sender, MouseEventArgs e)
        {
            m = 0;
            mx = 0;
            my = 0;
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

        private void button13_Click(object sender, EventArgs e)
        {
            porElectro();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            porElectro();
        }
    }
}