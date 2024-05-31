namespace FlowerClient.View
{
    partial class CartView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CartView));
            this.GoMain = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.flowLayoutPanelProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.Bonuses = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.UseBonuses = new System.Windows.Forms.TextBox();
            this.Buy = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Sum = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // GoMain
            // 
            this.GoMain.BackColor = System.Drawing.Color.LightPink;
            this.GoMain.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.GoMain.Location = new System.Drawing.Point(1287, 12);
            this.GoMain.Name = "GoMain";
            this.GoMain.Size = new System.Drawing.Size(176, 39);
            this.GoMain.TabIndex = 25;
            this.GoMain.Text = "На главную";
            this.GoMain.UseVisualStyleBackColor = false;
            this.GoMain.Click += new System.EventHandler(this.GoMain_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1287, 660);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(243, 206);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 26;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(18, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(60, 60);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 27;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(84, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(231, 49);
            this.label1.TabIndex = 28;
            this.label1.Text = "Моя корзина";
            // 
            // flowLayoutPanelProduct
            // 
            this.flowLayoutPanelProduct.AutoScroll = true;
            this.flowLayoutPanelProduct.Location = new System.Drawing.Point(22, 78);
            this.flowLayoutPanelProduct.Name = "flowLayoutPanelProduct";
            this.flowLayoutPanelProduct.Size = new System.Drawing.Size(1441, 579);
            this.flowLayoutPanelProduct.TabIndex = 29;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 670);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(99, 34);
            this.label8.TabIndex = 21;
            this.label8.Text = "Бонусы:";
            // 
            // Bonuses
            // 
            this.Bonuses.AutoSize = true;
            this.Bonuses.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Bonuses.Location = new System.Drawing.Point(117, 670);
            this.Bonuses.Name = "Bonuses";
            this.Bonuses.Size = new System.Drawing.Size(97, 34);
            this.Bonuses.TabIndex = 30;
            this.Bonuses.Text = "Bonuses";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.label2.Location = new System.Drawing.Point(12, 719);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 34);
            this.label2.TabIndex = 31;
            this.label2.Text = "Использовать бонусы:";
            // 
            // UseBonuses
            // 
            this.UseBonuses.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.UseBonuses.Location = new System.Drawing.Point(266, 716);
            this.UseBonuses.Name = "UseBonuses";
            this.UseBonuses.Size = new System.Drawing.Size(123, 38);
            this.UseBonuses.TabIndex = 32;
            // 
            // Buy
            // 
            this.Buy.BackColor = System.Drawing.Color.LightPink;
            this.Buy.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Buy.Location = new System.Drawing.Point(971, 770);
            this.Buy.Name = "Buy";
            this.Buy.Size = new System.Drawing.Size(176, 47);
            this.Buy.TabIndex = 33;
            this.Buy.Text = "Купить";
            this.Buy.UseVisualStyleBackColor = false;
            this.Buy.Click += new System.EventHandler(this.Buy_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(820, 719);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(198, 34);
            this.label4.TabIndex = 34;
            this.label4.Text = "Итоговая сумма:";
            // 
            // Sum
            // 
            this.Sum.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Sum.Location = new System.Drawing.Point(1024, 715);
            this.Sum.Name = "Sum";
            this.Sum.ReadOnly = true;
            this.Sum.Size = new System.Drawing.Size(123, 38);
            this.Sum.TabIndex = 36;
            // 
            // CartView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1486, 829);
            this.Controls.Add(this.Sum);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Buy);
            this.Controls.Add(this.UseBonuses);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Bonuses);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.flowLayoutPanelProduct);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.GoMain);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CartView";
            this.Text = "Корзина";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button GoMain;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProduct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox UseBonuses;
        private System.Windows.Forms.Button Buy;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label Bonuses;
        public System.Windows.Forms.TextBox Sum;
    }
}