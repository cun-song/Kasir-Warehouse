using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasir.Forms
{
    public partial class Product : Form
    {
        private Button but;
        private SqlCommand cmd;
        private DataSet dset;
        private SqlDataReader dr;
        private SqlDataAdapter da;
        Connect conn = new Connect();

        int index = 1;
        public Product()
        {
            InitializeComponent();
            viewProduct();
            textBox1.Enabled = false;
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
        }

        private void viewProduct()
        {
            SqlConnection konn = conn.GetConn();
            try
            {
                konn.Open();
                cmd = new SqlCommand("SELECT * FROM Product", konn);
                dset = new DataSet();
                da = new SqlDataAdapter(cmd);                
                da.Fill(dset, "Product");
              
                dataGridView1.DataSource = dset;
                dataGridView1.DataMember = "Product";
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
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

        private void InsertProduct()
        {
            SqlConnection konn2 = conn.GetConn();
            var previd = "";
            try
            {
                konn2.Open();
                cmd = new SqlCommand("SELECT MAX(ProductID) ProductID FROM Product", konn2);

                dr = cmd.ExecuteReader();
                dr.Read();
                previd = dr["ProductID"].ToString();
                konn2.Close();

                int idx = int.Parse(previd.Substring(previd.Length - 3)) + 1;

                var ID = "";
                if (idx / 10 == 0)
                {
                    ID = "PO00" + idx;
                }
                else if (idx / 10 > 0 && idx / 10 < 10)
                {
                    ID = "PO0" + idx;
                }
                else
                {
                    ID = "PO" + idx;
                }
                cmd = new SqlCommand("INSERT INTO Product VALUES ('" + ID + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "')", konn2);
                konn2.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product sudah dimasukkan!");
                viewProduct();
                clear();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void updateProduct()
        {
            SqlConnection konn3 = conn.GetConn();
            try
            {
                cmd = new SqlCommand("UPDATE Product SET ProductName='" + textBox2.Text + "',ProductQty='" + textBox3.Text + "',Price='" + textBox4.Text + "' WHERE ProductID='" + textBox1.Text + "'", konn3);
                konn3.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Product sudah selesai diupdate!");
                viewProduct();
                clear();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void DeleteProduct()
        {
            SqlConnection konn4 = conn.GetConn();

            cmd = new SqlCommand("DELETE Product WHERE ProductID='" + textBox1.Text + "'", konn4);
            konn4.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product sudah selesai dihapus!");
            viewProduct();
            clear();
        }

        private void activeBut(object btnSender)
        {
            if (btnSender != null)
            {
                if (but != (Button)btnSender)
                {
                    disablebut();
                    but = (Button)btnSender;
                    but.BackColor = Color.DarkGray;
          
                }
            }
        }

        private void disablebut()
        {
            foreach (Control previousBtn in panel1.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.White;
 
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            activeBut(sender);
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            index = 1;
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            activeBut(sender);
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            index = 2;
         
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activeBut(sender);
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            index = 3;
         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(index == 1)
            {
                if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Product belum terisi dengan lengkap!");
                }
                else
                {
                    InsertProduct();
                }
            }else if (index == 2)
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Product belum terisi dengan lengkap!");
                }
                else
                {
                    updateProduct();
                }
            }
            else if (index == 3)
            {
                if (MessageBox.Show("Apakah anda ingin menghapus Product " + textBox2.Text + " ini?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteProduct();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["ProductID"].Value.ToString();
                textBox2.Text = row.Cells["ProductName"].Value.ToString();
                textBox3.Text = row.Cells["ProductQty"].Value.ToString();
                textBox4.Text = row.Cells["Price"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
