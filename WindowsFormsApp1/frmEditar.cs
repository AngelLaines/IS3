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
    public partial class frmEditar : Form
    {
        Connection cn;
        private int m, mx, my;
        public frmEditar()
        {
            cn = new Connection();
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmMenu menu = new frmMenu();
            menu.Visible = true;
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmInsertar ins = new frmInsertar();
            ins.Visible = true;
            Close();
        }

        private void frmEditar_MouseClick(object sender, MouseEventArgs e)
        {
            panel5.Visible = false;
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmBorrar borrar = new frmBorrar();
            borrar.Visible = true;
            this.Close();
        }

        private void frmEditar_Load(object sender, EventArgs e)
        {
            comboBox5.SelectedText = "Nombre";
            Font fuente = new Font("Arial", 15, GraphicsUnit.Pixel);
            gridBuscar.DefaultCellStyle.Font = fuente;
            gridBuscar.ColumnHeadersDefaultCellStyle.Font = fuente;
            
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

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = comboBox5.SelectedItem.ToString();
            switch (txt) {
                case "Fecha":
                    panel8.Visible = true;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox4.ResetText();
                    comboBox4.SelectedText = "Fecha";
                    break;
                case "Numero":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = true;
                    panel16.Visible = false;
                    comboBox3.ResetText();
                    comboBox3.SelectedText = "Numero";
                    break;
                case "Domicilio":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = true;
                    comboBox2.ResetText();
                    comboBox2.SelectedText = "Domicilio";
                    break;
                case "Marca electrodomestico":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = true;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox1.ResetText();
                    comboBox1.SelectedText = "Marca electrodomestico";
                    break;
            }

            gridBuscar.DataSource = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = comboBox1.SelectedItem.ToString();
            switch (txt)
            {
                case "Fecha":
                    panel8.Visible = true;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox4.ResetText();
                    comboBox4.SelectedText = "Fecha";
                    break;
                case "Numero":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = true;
                    panel16.Visible = false;
                    comboBox3.ResetText();
                    comboBox3.SelectedText = "Numero";
                    break;
                case "Domicilio":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = true;
                    comboBox2.ResetText();
                    comboBox2.SelectedText = "Domicilio";
                    break;
                case "Nombre":
                    panel8.Visible = false;
                    panel6.Visible = true;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox5.ResetText();
                    comboBox5.SelectedText = "Nombre";
                    break;
            }
            gridBuscar.DataSource = null;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = comboBox2.SelectedItem.ToString();
            switch (txt)
            {
                case "Fecha":
                    panel8.Visible = true;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox4.ResetText();
                    comboBox4.SelectedText = "Fecha";
                    break;
                case "Numero":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = true;
                    panel16.Visible = false;
                    comboBox3.ResetText();
                    comboBox3.SelectedText = "Numero";
                    break;
                case "Nombre":
                    panel8.Visible = false;
                    panel6.Visible = true;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox5.ResetText();
                    comboBox5.SelectedText = "Nombre";
                    break;
                case "Marca electrodomestico":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = true;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox1.ResetText();
                    comboBox1.SelectedText = "Marca electrodomestico";
                    break;
            }
            gridBuscar.DataSource = null;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = comboBox3.SelectedItem.ToString();
            switch (txt)
            {
                case "Fecha":
                    panel8.Visible = true;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox4.ResetText();
                    comboBox4.SelectedText = "Fecha";
                    break;
                case "Nombre":
                    panel8.Visible = false;
                    panel6.Visible = true;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox5.ResetText();
                    comboBox5.SelectedText = "Nombre";
                    break;
                case "Domicilio":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = true;
                    comboBox2.ResetText();
                    comboBox2.SelectedText = "Domicilio";
                    break;
                case "Marca electrodomestico":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = true;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox1.ResetText();
                    comboBox1.SelectedText = "Marca electrodomestico";
                    break;
            }
            gridBuscar.DataSource = null;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string txt = comboBox4.SelectedItem.ToString();
            switch (txt)
            {
                case "Nombre":
                    panel8.Visible = false;
                    panel6.Visible = true;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox5.ResetText();
                    comboBox5.SelectedText = "Nombre";
                    break;
                case "Numero":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = true;
                    panel16.Visible = false;
                    comboBox3.ResetText();
                    comboBox3.SelectedText = "Numero";
                    break;
                case "Domicilio":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = true;
                    comboBox2.ResetText();
                    comboBox2.SelectedText = "Domicilio";
                    break;
                case "Marca electrodomestico":
                    panel8.Visible = false;
                    panel6.Visible = false;
                    panel23.Visible = true;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    comboBox1.ResetText();
                    comboBox1.SelectedText = "Marca electrodomestico";
                    break;
            }
            gridBuscar.DataSource = null;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string fecha = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select c.idcliente as 'Id Cliente',c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where v.fecha='" + fecha + "'";
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

            gridBuscar.Columns[0].ReadOnly = true;
            gridBuscar.Columns[12].ReadOnly = true;
        }

        private void btnBuscarN_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select c.idcliente as 'Id Cliente',c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where c.nombre='" + txtNombre.Text + "'";
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

            gridBuscar.Columns[0].ReadOnly = true;
            gridBuscar.Columns[12].ReadOnly = true;
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

            gridBuscar.Columns[0].ReadOnly = true;
            gridBuscar.Columns[12].ReadOnly = true;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select c.idcliente as 'Id Cliente', c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where d.direccion='" + txtDireccion.Text + "'";
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

            gridBuscar.Columns[0].ReadOnly = true;
            gridBuscar.Columns[12].ReadOnly = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(cn.conn());
            string numero = txtNumero.Text;
            if (numero == "")
            {
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

            gridBuscar.Columns[0].ReadOnly = true;
            gridBuscar.Columns[12].ReadOnly = true;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            /* foreach (DataGridViewRow row in dtaPagos.Rows)
             {
                 MessageBox.Show(row.Cells["Pago"].Value.ToString());
                 MessageBox.Show(row.Cells["Cantidad"].Value.ToString());
                 MessageBox.Show(row.Cells["Observaciones"].Value.ToString());
             }*/
            if (gridBuscar.DataSource == null || gridBuscar.Rows.Count.ToString() == "0")
            {
            }
            else { 
            
            DialogResult dialog = MessageBox.Show("Usted esta a punto de editar los datos de las ventas, esta accion es irreversible.\n\n¿Desea editar los datos de la venta? \n\n (Si no esta seguro, asegurese de que los datos a editar sean correctos)","Advertencia",MessageBoxButtons.YesNo) ;
            MySqlConnection conn = new MySqlConnection(cn.conn());
            int idcliente, precio;
            string nombre, apellidoP, apellidoM, nombreE, marca, ciudad, direccion, numero, garantia, atendio, fecha;
            string sqlCliente;
            string sqlDireccion;
            string sqlElectro;
            string sqlVenta;
            if (dialog == DialogResult.Yes) { 
                foreach(DataGridViewRow row in gridBuscar.Rows) {
                    try {
                        idcliente = int.Parse(row.Cells["Id Cliente"].Value.ToString());
                        nombre = row.Cells["Nombre"].Value.ToString();
                        apellidoP = row.Cells["Apellido Paterno"].Value.ToString();
                        apellidoM = row.Cells["Apellido Materno"].Value.ToString();
                        nombreE = row.Cells["Nombre Electrodomestico"].Value.ToString();
                        marca = row.Cells["Marca"].Value.ToString();
                        precio = int.Parse(row.Cells["Precio"].Value.ToString());
                        ciudad = row.Cells["Ciudad"].Value.ToString();
                        direccion = row.Cells["Direccion"].Value.ToString();
                        numero = row.Cells["Numero"].Value.ToString();
                        garantia = row.Cells["Garantia"].Value.ToString();
                        atendio = row.Cells["Atendio"].Value.ToString();
                        //fecha = row.Cells["Fecha de venta"].Value.ToString();

                        sqlCliente = @"update clientes set nombre='"+nombre+"', apellidoP='"+apellidoP+"', apellidoM='"+apellidoM+"' where idcliente="+idcliente;
                        sqlDireccion = @"update direccion set ciudad='"+ciudad+"', direccion='"+direccion+"', numero="+numero+" where idDireccion="+idcliente;
                        sqlElectro = @"update electrodomesticos set nombre='"+nombreE+"', marca='"+marca+"' where idElectrodomestico="+idcliente;
                        sqlVenta = @"update ventas set precio="+precio+", garantia='"+garantia+"', atiende='"+atendio+"' where idVenta="+idcliente;

                        //MessageBox.Show(sqlCliente+"\n"+ sqlDireccion + "\n"+sqlElectro + "\n"+ sqlVenta + "\n");
                        conn.Open();
                        MySqlCommand cmd = new MySqlCommand(sqlCliente,conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sqlDireccion,conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sqlElectro,conn);
                        cmd.ExecuteNonQuery();
                        cmd = new MySqlCommand(sqlVenta,conn);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Datos de la venta editados correctamente!","Aviso");

                    } catch (MySqlException ex) { MessageBox.Show(ex.ToString()); } finally { conn.Close(); }
                    //MessageBox.Show(row.Cells["Nombre"].Value.ToString());
                }
            }
            }

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
