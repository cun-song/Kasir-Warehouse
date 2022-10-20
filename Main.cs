using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kasir
{
    public partial class Main : Form
    {
        private Form activeForm;
        private Button but;
        public Main()
        {
            InitializeComponent();
            OpenForm(new Forms.Transaction());
            activeBut(Transaction);


        }
        
       private void OpenForm (Form form)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = form;
            form.TopLevel = false;
            form.FormBorderStyle= FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(form);
            this.panel4.Tag = form;
            form.BringToFront();
            form.Show();
        }

        private void activeBut (object btnSender)
        {
            if(btnSender != null)
            {
                if(but != (Button)btnSender)
                {
                    disablebut();
                    but = (Button)btnSender;
                    but.BackColor = Color.Orange;
                }
            }
        }

        private void disablebut()
        {
            foreach (Control previousBtn in panel3.Controls)
            {
                if(previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.Gray;
                }
            }
        }


        private void product_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Product());
            activeBut(sender);
        }

        private void User_Click(object sender, EventArgs e)
        {
            activeBut(sender);
            OpenForm(new Forms.Customer());
        }

        private void Transaction_Click(object sender, EventArgs e)
        {
            OpenForm(new Forms.Transaction());
            activeBut(sender);
        }

        private void About_Click(object sender, EventArgs e)
        {
            activeBut(sender);
            OpenForm(new Forms.About());

        }

        private void History_Click(object sender, EventArgs e)
        {
            activeBut(sender);
            OpenForm(new Forms.History());
        }
    }
}
