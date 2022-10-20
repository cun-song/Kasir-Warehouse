using System;
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
    public partial class Customer : Form
    {
        private Button but;
        private SqlCommand cmd;
        private DataSet dset;
        private SqlDataReader dr;
        private SqlDataAdapter da;
        Connect conn = new Connect();
        int index = 1;
        public Customer()
        {
            InitializeComponent();
            viewCustomer();
            textBox1.Enabled = false;
        }

        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "0";
            textBox4.Text = "0";
            textBox5.Text = "";
        }

        private void viewCustomer()
        {
            SqlConnection konn = conn.GetConn();
            try
            {
                konn.Open();
                cmd = new SqlCommand("SELECT * FROM Customer", konn);
                dset = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(dset, "Customer");

                dataGridView1.DataSource = dset;
                dataGridView1.DataMember = "Customer";
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

        private void InsertCustomer()
        {
            var previd = "";
            SqlConnection konn2 = conn.GetConn();
            try
            {
                konn2.Open();
                cmd = new SqlCommand("SELECT MAX(CustomerID) CustomerID FROM Customer", konn2);

                dr = cmd.ExecuteReader();
                dr.Read();
                previd = dr["CustomerID"].ToString();
                konn2.Close();

                int idx = int.Parse(previd.Substring(previd.Length - 3)) + 1;

                var ID = "";
                if (idx / 10 == 0)
                {
                    ID = "CU00" + idx;
                }
                else if (idx / 10 > 0 && idx / 10 < 10)
                {
                    ID = "CU0" + idx;
                }
                else
                {
                    ID = "CU" + idx;
                }
                cmd = new SqlCommand("INSERT INTO Customer VALUES ('" + ID + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')", konn2);
                konn2.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data customer telah dimasukkan!");
                viewCustomer();
                clear();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void updateCustomer()
        {
            SqlConnection konn3 = conn.GetConn();
            try
            {
                cmd = new SqlCommand("UPDATE Customer SET CustomerName='" + textBox2.Text + "',Age='" + textBox3.Text + "',PhoneNum='" + textBox4.Text + "',Email='" + textBox5.Text + "' WHERE CustomerID='" + textBox1.Text + "'", konn3);
                konn3.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Customer telah selesai diupdate!");
                viewCustomer();
                clear();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.ToString());
            }
        }

        private void DeleteCustomer()
        {
            SqlConnection konn4 = conn.GetConn();

            cmd = new SqlCommand("DELETE Customer WHERE CustomerID='" + textBox1.Text + "'", konn4);
            konn4.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Product telah selesai dihapus!");
            viewCustomer();
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
            textBox5.Enabled = true;
            index = 1;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            activeBut(sender);
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox4.Enabled = true;
            textBox5.Enabled = true;
            index = 2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            activeBut(sender);
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            index = 3;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (index == 1)
            {
                if (textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Data Customer belum terisi dengan lengkap!");
                }
                else
                {
                    InsertCustomer();
                }
            }
            else if (index == 2)
            {
                if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || textBox4.Text.Trim() == "")
                {
                    MessageBox.Show("Data Customer belum terisi dengan lengkap!");
                }
                else
                {
                    updateCustomer();
                }
            }
            else if (index == 3)
            {
                if (MessageBox.Show("Apakah anda ingin menghapus Data Customer " + textBox2.Text + " ini?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    DeleteCustomer();
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                textBox1.Text = row.Cells["CustomerID"].Value.ToString();
                textBox2.Text = row.Cells["CustomerName"].Value.ToString();
                textBox3.Text = row.Cells["Age"].Value.ToString();
                textBox4.Text = row.Cells["PhoneNum"].Value.ToString();
                textBox5.Text = row.Cells["Email"].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
