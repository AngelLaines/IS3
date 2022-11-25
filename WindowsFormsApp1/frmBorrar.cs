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
    public partial class frmBorrar : Form
    {
        private int m, mx, my;
        Connection cn = new Connection();

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
            comboBox6.SelectedText = "Nombre";
            Font fuente = new Font("Arial", 15, GraphicsUnit.Pixel);
            gridBuscar.DefaultCellStyle.Font = fuente;
            gridBuscar.ColumnHeadersDefaultCellStyle.Font = fuente;


            MySqlConnection conn = new MySqlConnection(cn.conn());
            string sql = @"select distinct marca from electrodomesticos";
            try
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader data = cmd.ExecuteReader();
                while (data.Read())
                {
                    cmbMarca.Items.Add(data["marca"].ToString());
                }
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
            string sql = @"select c.idcliente as 'Id Cliente',c.nombre as Nombre,c.apellidoP as 'Apellido Paterno',c.apellidoM as 'Apellido Materno',e.nombre as 'Nombre Electrodomestico',e.marca as Marca,d.ciudad as Ciudad,d.direccion as Direccion,d.numero as Numero,v.precio as Precio,v.garantia as Garantia,v.atiende as Atendio,date_format(v.fecha, '%d-%m-%Y') as 'Fecha de venta' from clientes c join clientes_electrodomesticos ce on c.idcliente=ce.idcliente join clientes_direccion cd on c.idcliente = cd.idcliente join clientes_ventas cv on c.idcliente=cv.idcliente join electrodomesticos e on ce.idelectrodomestico = e.idelectrodomestico join direccion d on d.iddireccion=cd.iddireccion join ventas v on v.idventa = cv.idventa where e.marca='" + cmbMarca.SelectedItem.ToString() + "'";
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

        private void button13_Click(object sender, EventArgs e)
        {
            if (gridBuscar.DataSource == null || gridBuscar.Rows.Count.ToString()=="0")
            {
            }
            else
            {

                DialogResult dialog = MessageBox.Show("Usted esta a punto de borrar los datos de las ventas, esta accion es irreversible.\n\n¿Desea borrar los datos de la venta? \n\n (Si no esta seguro, asegurese de que los datos a borrar sean los correctos)", "Advertencia", MessageBoxButtons.YesNo);
                MySqlConnection conn = new MySqlConnection(cn.conn());
                int idcliente;
                
                string sqlCD;
                string sqlCV;
                string sqlCE;
                string sqlCliente;
                string sqlDireccion;
                string sqlElectro;
                string sqlVenta;
                if (dialog == DialogResult.Yes)
                {
                    
                        try
                        {
                        DataGridViewRow row = gridBuscar.CurrentRow;
                            idcliente = int.Parse(row.Cells["Id Cliente"].Value.ToString());

                            sqlCD = @"delete from clientes_direccion where idcliente=" + idcliente.ToString();
                            sqlCV = @"delete from clientes_ventas where idcliente="+idcliente.ToString();
                            sqlCE = @"delete from clientes_electrodomesticos where idcliente=" + idcliente.ToString();
                            sqlCliente = @"delete from clientes where idcliente=" + idcliente.ToString();
                            sqlDireccion = @"delete from direccion where iddireccion=" + idcliente.ToString();
                            sqlElectro = @"delete from electrodomesticos where idElectrodomestico=" + idcliente.ToString();
                            sqlVenta = @"delete from ventas where idventa=" + idcliente.ToString();

                            //MessageBox.Show(sqlCliente+"\n"+ sqlDireccion + "\n"+sqlElectro + "\n"+ sqlVenta + "\n");
                            conn.Open();
                            MySqlCommand cmd = new MySqlCommand(sqlCV, conn);
                            cmd.ExecuteNonQuery();
                            cmd = new MySqlCommand(sqlCE,conn);
                            cmd.ExecuteNonQuery();
                            cmd = new MySqlCommand(sqlCD, conn);
                            cmd.ExecuteNonQuery();
                            cmd = new MySqlCommand(sqlCliente, conn);
                            cmd.ExecuteNonQuery();
                            cmd = new MySqlCommand(sqlDireccion, conn);
                            cmd.ExecuteNonQuery();
                            cmd = new MySqlCommand(sqlElectro, conn);
                            cmd.ExecuteNonQuery();
                            cmd = new MySqlCommand(sqlVenta, conn);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Datos de la venta borrados correctamente!", "Aviso");

                            gridBuscar.Rows.Remove(gridBuscar.CurrentRow);
                        }
                        catch (MySqlException ex) { MessageBox.Show(ex.ToString()); }
                        finally { conn.Close(); }
                    
                }
            }
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbMarca.ResetText();
            string txt = comboBox6.SelectedItem.ToString();
            switch (txt)
            {
                case "Nombre":
                    panel8.Visible = true;
                    panel11.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    break;
                case "Fecha":
                    panel11.Visible = true;
                    panel8.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    break;
                case "Numero":
                    panel8.Visible = false;
                    panel11.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = true;
                    panel16.Visible = false;
                    break;
                case "Domicilio":
                    panel8.Visible = false;
                    panel11.Visible = false;
                    panel23.Visible = false;
                    panel12.Visible = false;
                    panel16.Visible = true;
                    break;
                case "Marca electrodomestico":
                    panel8.Visible = false;
                    panel11.Visible = false;
                    panel23.Visible = true;
                    panel12.Visible = false;
                    panel16.Visible = false;
                    break;
            }

            gridBuscar.DataSource = null;
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
