namespace FlowerClient.View
{
    partial class MainProductsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainProductsView));
            this.label8 = new System.Windows.Forms.Label();
            this.ExitProfile = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.Button();
            this.Cart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(87, 94);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 37);
            this.label8.TabIndex = 20;
            this.label8.Text = "Все товары";
            // 
            // ExitProfile
            // 
            this.ExitProfile.BackColor = System.Drawing.Color.LightPink;
            this.ExitProfile.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.ExitProfile.Location = new System.Drawing.Point(1079, 57);
            this.ExitProfile.Name = "ExitProfile";
            this.ExitProfile.Size = new System.Drawing.Size(254, 39);
            this.ExitProfile.TabIndex = 23;
            this.ExitProfile.Text = "Выйти из профиля";
            this.ExitProfile.UseVisualStyleBackColor = false;
            this.ExitProfile.Click += new System.EventHandler(this.ExitProfile_Click);
            // 
            // Admin
            // 
            this.Admin.BackColor = System.Drawing.Color.LightPink;
            this.Admin.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Admin.Location = new System.Drawing.Point(1079, 12);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(117, 39);
            this.Admin.TabIndex = 24;
            this.Admin.Text = "Админ";
            this.Admin.UseVisualStyleBackColor = false;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // Cart
            // 
            this.Cart.BackColor = System.Drawing.Color.LightPink;
            this.Cart.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Cart.Location = new System.Drawing.Point(1202, 12);
            this.Cart.Name = "Cart";
            this.Cart.Size = new System.Drawing.Size(131, 39);
            this.Cart.TabIndex = 25;
            this.Cart.Text = "Корзина";
            this.Cart.UseVisualStyleBackColor = false;
            this.Cart.Click += new System.EventHandler(this.Cart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(78, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 49);
            this.label1.TabIndex = 26;
            this.label1.Text = "Flowerics";
            // 
            // flowLayoutPanelProduct
            // 
            this.flowLayoutPanelProduct.AutoScroll = true;
            this.flowLayoutPanelProduct.Location = new System.Drawing.Point(94, 137);
            this.flowLayoutPanelProduct.Name = "flowLayoutPanelProduct";
            this.flowLayoutPanelProduct.Size = new System.Drawing.Size(1296, 604);
            this.flowLayoutPanelProduct.TabIndex = 27;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1339, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(131, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(12, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 29;
            this.pictureBox2.TabStop = false;
            // 
            // MainProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.flowLayoutPanelProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cart);
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.ExitProfile);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainProductsView";
            this.Text = "Главная";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button ExitProfile;
        private System.Windows.Forms.Button Admin;
        private System.Windows.Forms.Button Cart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProduct;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}