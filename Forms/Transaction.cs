using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasir.Forms
{
    public partial class Transaction : Form
    {
        private SqlCommand cmd;
        private DataSet dset;
        private SqlDataAdapter da;
        private SqlDataReader dr;
        DataTable table = new DataTable("table");
        Connect conn = new Connect();
        int total = 0;
        int[] sisa = new int[20];
       

        public Transaction()
        {
            InitializeComponent();
            viewProduct();
            insertcombo();
            viewlist();
        }

        private void viewProduct()
        {
            SqlConnection konn = conn.GetConn();
            try
            {
                konn.Open();
                cmd = new SqlCommand("SELECT ProductID,ProductName FROM Product", konn);
                dset = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(dset, "Product");
                dataGridView2.DataSource = dset;
                dataGridView2.DataMember = "Product";
                dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            finally
            {
                konn.Close();
            }
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";

        }

        private void viewlist()
        {
            table.Columns.Add("Product ID", typeof(String));
            table.Columns.Add("Product Name", typeof(String));
            table.Columns.Add("Product Qty", typeof(int));
            table.Columns.Add("Product Price", typeof(int));

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

        }

        private void add()
        {
            var price = 0;
            var qty = 0;
  

            SqlConnection koneksi = conn.GetConn();
            try
            {

                koneksi.Open();
                cmd = new SqlCommand("SELECT Price,ProductQty FROM Product WHERE ProductID ='" + textBox1.Text + "'", koneksi);


                dr = cmd.ExecuteReader();
                dr.Read();
   
                price = (int)dr["Price"];
                qty = (int)dr["ProductQty"];

                if(qty>= int.Parse(textBox3.Text))
                {
                    sisa[table.Rows.Count] = qty - int.Parse(textBox3.Text);
                    table.Rows.Add(textBox1.Text, textBox2.Text, int.Parse(textBox3.Text), price);     
                    total += price * int.Parse(textBox3.Text);
                    label7.Text = total.ToString();
                  
                }
                else
                {
                    MessageBox.Show("Stok tidak mencukupi");
                }

          
                
            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }

           
        }

        private void checkout()
        {
            SqlConnection konn2 = conn.GetConn();
            var previd = "";
            try
            {

                konn2.Open();
                cmd = new SqlCommand("SELECT MAX(TransactionID) TransactionID FROM TransactionHeader", konn2);

                dr = cmd.ExecuteReader();
                dr.Read();
                previd = dr["TransactionID"].ToString();
                konn2.Close();
 
                int idx = int.Parse(previd.Substring(previd.Length - 3)) + 1;
              
                var ID = "";
                if(idx / 10 == 0)
                {
                    ID = "TR00" + idx;
                }else if (idx/ 10 > 0 && idx / 10 < 10)
                {
                    ID = "TR0" + idx;
                }
                else
                {
                    ID = "TR" + idx;
                }
                konn2.Open();
                cmd = new SqlCommand("INSERT INTO TransactionHeader VALUES ('" + ID + "','" + comboBox1.Text + "',getdate())", konn2);
                cmd.ExecuteNonQuery();
                konn2.Close();
              

               
                
                for ( int i = 0; i < table.Rows.Count; i++)
                {
                    konn2.Open();
                    cmd = new SqlCommand("INSERT INTO TransactionDetail VALUES ('" + ID + "','" + table.Rows[i][0].ToString() + "','" + table.Rows[i][2].ToString() + "')" + "UPDATE Product SET ProductQty=" + sisa[i] + " WHERE ProductID='" + table.Rows[i][0].ToString() + "'", konn2);
                    cmd.ExecuteNonQuery();
                    konn2.Close();

                }

                MessageBox.Show("Transaksi Berhasil!");
                

            }
            catch (Exception a)
            {
                MessageBox.Show(a.ToString());
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "")
            {
                MessageBox.Show("Product belum terisi dengan lengkap!");
            }
            else if (int.Parse(textBox3.Text)==0)
            {
                MessageBox.Show("Kuantitas tidak boleh nol!");
            }
            else
            {
                add();
                clear();       
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
                {
                   DataGridViewRow row = this.dataGridView2.Rows[e.RowIndex];
                   textBox1.Text = row.Cells["ProductID"].Value.ToString();
                   textBox2.Text = row.Cells["ProductName"].Value.ToString();  
                   }
                   catch (Exception ex)
                {
                   MessageBox.Show(ex.ToString());
                   }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (table.Rows.Count == 0)
            {
                MessageBox.Show("Silahkan input Product! ");
            }else if(comboBox1.Text.Trim() == "") 
            {
                MessageBox.Show("Silahkan input User ID! ");
            }
            else
            {
                checkout();
                table.Rows.Clear();

            }
        }
        private void insertcombo()
        {
            var previd = "";
            int idx = 0;
            
            SqlConnection konn3 = conn.GetConn();
            try
            {
                konn3.Open();
                cmd = new SqlCommand("SELECT MAX(CustomerID) CustomerID FROM Customer", konn3);
                dr = cmd.ExecuteReader();
                dr.Read();
                previd = dr["CustomerID"].ToString();
                konn3.Close();

                idx = int.Parse(previd.Substring(previd.Length - 3));
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
            }
            var cu = "";
            for (int i = 1; i <= idx; i++)
            {
                
                if (i / 10 == 0)
                {
                    cu = "CU00" + i;
                }
                else if (i / 10 > 0 && i / 10 < 10)
                {
                    cu = "CU0" + i;
                }
                else
                {
                    cu = "CU" + i;
                }
                comboBox1.Items.Add(cu);
            }
            
            
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
