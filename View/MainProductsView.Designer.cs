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
            this.label8 = new System.Windows.Forms.Label();
            this.FindProduct = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ExitProfile = new System.Windows.Forms.Button();
            this.Admin = new System.Windows.Forms.Button();
            this.Cart = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(5, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 37);
            this.label8.TabIndex = 20;
            this.label8.Text = "Все товары";
            // 
            // FindProduct
            // 
            this.FindProduct.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.FindProduct.Location = new System.Drawing.Point(975, 93);
            this.FindProduct.Name = "FindProduct";
            this.FindProduct.Size = new System.Drawing.Size(181, 38);
            this.FindProduct.TabIndex = 22;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(608, 92);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(361, 37);
            this.label9.TabIndex = 21;
            this.label9.Text = "Поиск по индентификатору";
            // 
            // ExitProfile
            // 
            this.ExitProfile.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.ExitProfile.Location = new System.Drawing.Point(1230, 12);
            this.ExitProfile.Name = "ExitProfile";
            this.ExitProfile.Size = new System.Drawing.Size(240, 39);
            this.ExitProfile.TabIndex = 23;
            this.ExitProfile.Text = "Выйти из профиля";
            this.ExitProfile.UseVisualStyleBackColor = true;
            this.ExitProfile.Click += new System.EventHandler(this.ExitProfile_Click);
            // 
            // Admin
            // 
            this.Admin.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Admin.Location = new System.Drawing.Point(970, 12);
            this.Admin.Name = "Admin";
            this.Admin.Size = new System.Drawing.Size(117, 39);
            this.Admin.TabIndex = 24;
            this.Admin.Text = "Админ";
            this.Admin.UseVisualStyleBackColor = true;
            this.Admin.Click += new System.EventHandler(this.Admin_Click);
            // 
            // Cart
            // 
            this.Cart.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Cart.Location = new System.Drawing.Point(1093, 12);
            this.Cart.Name = "Cart";
            this.Cart.Size = new System.Drawing.Size(131, 39);
            this.Cart.TabIndex = 25;
            this.Cart.Text = "Корзина";
            this.Cart.UseVisualStyleBackColor = true;
            this.Cart.Click += new System.EventHandler(this.Cart_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 49);
            this.label1.TabIndex = 26;
            this.label1.Text = "Тут типа будет логотип и название магазина";
            // 
            // flowLayoutPanelProduct
            // 
            this.flowLayoutPanelProduct.AutoScroll = true;
            this.flowLayoutPanelProduct.Location = new System.Drawing.Point(12, 137);
            this.flowLayoutPanelProduct.Name = "flowLayoutPanelProduct";
            this.flowLayoutPanelProduct.Size = new System.Drawing.Size(1458, 604);
            this.flowLayoutPanelProduct.TabIndex = 27;
            // 
            // MainProductsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1482, 753);
            this.Controls.Add(this.flowLayoutPanelProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cart);
            this.Controls.Add(this.Admin);
            this.Controls.Add(this.ExitProfile);
            this.Controls.Add(this.FindProduct);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Name = "MainProductsView";
            this.Text = "Главная";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox FindProduct;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ExitProfile;
        private System.Windows.Forms.Button Admin;
        private System.Windows.Forms.Button Cart;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProduct;
    }
}