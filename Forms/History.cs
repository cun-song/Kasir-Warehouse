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
    public partial class History : Form
    {
        private SqlCommand cmd;
        private DataSet dset;
        private SqlDataAdapter da;
        Connect conn = new Connect();
        public History()
        {
            InitializeComponent();
            viewCustomer();
        }
        void viewCustomer()
        {
            SqlConnection konn = conn.GetConn();
            try
            {
                konn.Open();
                cmd = new SqlCommand("SELECT th.TransactionID,CustomerID,TransactionDate,SUM(Price*Qty) AS 'Total' FROM TransactionHeader th JOIN TransactionDetail td ON Td.TransactionID = th.TransactionID JOIN Product p ON P.ProductID = td.ProductID GROUP BY th.TransactionID, CustomerID, TransactionDate", konn);
                dset = new DataSet();
                da = new SqlDataAdapter(cmd);
                da.Fill(dset, "TransactionHeader");

                dataGridView1.DataSource = dset;
                dataGridView1.DataMember = "TransactionHeader";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
