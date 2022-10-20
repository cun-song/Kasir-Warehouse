namespace Kasir
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel3 = new System.Windows.Forms.Panel();
            this.History = new System.Windows.Forms.Button();
            this.About = new System.Windows.Forms.Button();
            this.Customer = new System.Windows.Forms.Button();
            this.Transaction = new System.Windows.Forms.Button();
            this.product = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel3.Controls.Add(this.History);
            this.panel3.Controls.Add(this.About);
            this.panel3.Controls.Add(this.Customer);
            this.panel3.Controls.Add(this.Transaction);
            this.panel3.Controls.Add(this.product);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(200, 509);
            this.panel3.TabIndex = 0;
            // 
            // History
            // 
            this.History.BackColor = System.Drawing.Color.Gray;
            this.History.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.History.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.History.Location = new System.Drawing.Point(14, 322);
            this.History.Name = "History";
            this.History.Size = new System.Drawing.Size(173, 67);
            this.History.TabIndex = 6;
            this.History.Text = "History";
            this.History.UseVisualStyleBackColor = false;
            this.History.Click += new System.EventHandler(this.History_Click);
            // 
            // About
            // 
            this.About.BackColor = System.Drawing.Color.Gray;
            this.About.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.About.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.About.Location = new System.Drawing.Point(14, 416);
            this.About.Name = "About";
            this.About.Size = new System.Drawing.Size(173, 67);
            this.About.TabIndex = 5;
            this.About.Text = "About";
            this.About.UseVisualStyleBackColor = false;
            this.About.Click += new System.EventHandler(this.About_Click);
            // 
            // Customer
            // 
            this.Customer.BackColor = System.Drawing.Color.Gray;
            this.Customer.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Customer.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Customer.Location = new System.Drawing.Point(14, 230);
            this.Customer.Name = "Customer";
            this.Customer.Size = new System.Drawing.Size(173, 67);
            this.Customer.TabIndex = 3;
            this.Customer.Text = "Customer";
            this.Customer.UseVisualStyleBackColor = false;
            this.Customer.Click += new System.EventHandler(this.User_Click);
            // 
            // Transaction
            // 
            this.Transaction.BackColor = System.Drawing.Color.Gray;
            this.Transaction.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Transaction.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Transaction.Location = new System.Drawing.Point(14, 40);
            this.Transaction.Name = "Transaction";
            this.Transaction.Size = new System.Drawing.Size(173, 67);
            this.Transaction.TabIndex = 1;
            this.Transaction.Text = "Transactions";
            this.Transaction.UseVisualStyleBackColor = false;
            this.Transaction.Click += new System.EventHandler(this.Transaction_Click);
            // 
            // product
            // 
            this.product.BackColor = System.Drawing.Color.Gray;
            this.product.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.product.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.product.Location = new System.Drawing.Point(14, 134);
            this.product.Name = "product";
            this.product.Size = new System.Drawing.Size(173, 67);
            this.product.TabIndex = 2;
            this.product.Text = "Products";
            this.product.UseVisualStyleBackColor = false;
            this.product.Click += new System.EventHandler(this.product_Click);
            // 
            // panel4
            // 
            this.panel4.Location = new System.Drawing.Point(206, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(713, 485);
            this.panel4.TabIndex = 1;
            // 
            // Main
            // 
            this.ClientSize = new System.Drawing.Size(923, 509);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "Main";
            this.Text = "Kasir 123";
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Products;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button product;
        private System.Windows.Forms.Button About;
        private System.Windows.Forms.Button Customer;
        private System.Windows.Forms.Button Transaction;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button History;
    }
}

