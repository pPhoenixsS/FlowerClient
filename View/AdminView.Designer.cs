namespace FlowerClient.View
{
    partial class AdminView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminView));
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.AddPicture = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.Forward = new System.Windows.Forms.Button();
            this.DeletePicture = new System.Windows.Forms.Button();
            this.NameProduct = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Kind = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Description = new System.Windows.Forms.RichTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.Price = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Count = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.GoMain = new System.Windows.Forms.Button();
            this.flowLayoutPanelProduct = new System.Windows.Forms.FlowLayoutPanel();
            this.AddProduct = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(288, 49);
            this.label1.TabIndex = 0;
            this.label1.Text = "Администратор";
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.Pink;
            this.pictureBox.Location = new System.Drawing.Point(12, 73);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 250);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // AddPicture
            // 
            this.AddPicture.BackColor = System.Drawing.Color.LightPink;
            this.AddPicture.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.AddPicture.Location = new System.Drawing.Point(12, 372);
            this.AddPicture.Name = "AddPicture";
            this.AddPicture.Size = new System.Drawing.Size(400, 39);
            this.AddPicture.TabIndex = 3;
            this.AddPicture.Text = "Добавить фотографию";
            this.AddPicture.UseVisualStyleBackColor = false;
            this.AddPicture.Click += new System.EventHandler(this.AddPicture_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.LightPink;
            this.Back.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Back.Location = new System.Drawing.Point(12, 327);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(98, 39);
            this.Back.TabIndex = 4;
            this.Back.Text = "Назад";
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // Forward
            // 
            this.Forward.BackColor = System.Drawing.Color.LightPink;
            this.Forward.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Forward.Location = new System.Drawing.Point(314, 327);
            this.Forward.Name = "Forward";
            this.Forward.Size = new System.Drawing.Size(98, 39);
            this.Forward.TabIndex = 5;
            this.Forward.Text = "Вперед";
            this.Forward.UseVisualStyleBackColor = false;
            this.Forward.Click += new System.EventHandler(this.Next_Click);
            // 
            // DeletePicture
            // 
            this.DeletePicture.BackColor = System.Drawing.Color.LightPink;
            this.DeletePicture.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.DeletePicture.Location = new System.Drawing.Point(12, 417);
            this.DeletePicture.Name = "DeletePicture";
            this.DeletePicture.Size = new System.Drawing.Size(400, 39);
            this.DeletePicture.TabIndex = 6;
            this.DeletePicture.Text = "Удалить фотографию";
            this.DeletePicture.UseVisualStyleBackColor = false;
            this.DeletePicture.Click += new System.EventHandler(this.DeletePicture_Click);
            // 
            // NameProduct
            // 
            this.NameProduct.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.NameProduct.Location = new System.Drawing.Point(203, 472);
            this.NameProduct.Name = "NameProduct";
            this.NameProduct.Size = new System.Drawing.Size(209, 38);
            this.NameProduct.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(50, 472);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 34);
            this.label3.TabIndex = 8;
            this.label3.Text = "Название";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(72, 519);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 34);
            this.label4.TabIndex = 10;
            this.label4.Text = "Сорт";
            // 
            // Kind
            // 
            this.Kind.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Kind.Location = new System.Drawing.Point(203, 516);
            this.Kind.Name = "Kind";
            this.Kind.Size = new System.Drawing.Size(209, 38);
            this.Kind.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(147, 654);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 34);
            this.label5.TabIndex = 11;
            this.label5.Text = "Описание";
            // 
            // Description
            // 
            this.Description.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Description.Location = new System.Drawing.Point(12, 691);
            this.Description.Name = "Description";
            this.Description.Size = new System.Drawing.Size(400, 81);
            this.Description.TabIndex = 12;
            this.Description.Text = "";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(50, 564);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 34);
            this.label6.TabIndex = 14;
            this.label6.Text = "Цена, руб";
            // 
            // Price
            // 
            this.Price.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Price.Location = new System.Drawing.Point(204, 560);
            this.Price.Name = "Price";
            this.Price.Size = new System.Drawing.Size(209, 38);
            this.Price.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(11, 608);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(186, 34);
            this.label7.TabIndex = 16;
            this.label7.Text = "Количество, шт";
            // 
            // Count
            // 
            this.Count.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.Count.Location = new System.Drawing.Point(203, 604);
            this.Count.Name = "Count";
            this.Count.Size = new System.Drawing.Size(209, 38);
            this.Count.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Monotype Corsiva", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(418, 62);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(158, 37);
            this.label8.TabIndex = 18;
            this.label8.Text = "Все товары";
            // 
            // GoMain
            // 
            this.GoMain.BackColor = System.Drawing.Color.LightPink;
            this.GoMain.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.GoMain.Location = new System.Drawing.Point(1294, 9);
            this.GoMain.Name = "GoMain";
            this.GoMain.Size = new System.Drawing.Size(176, 39);
            this.GoMain.TabIndex = 21;
            this.GoMain.Text = "На главную";
            this.GoMain.UseVisualStyleBackColor = false;
            this.GoMain.Click += new System.EventHandler(this.GoMain_Click);
            // 
            // flowLayoutPanelProduct
            // 
            this.flowLayoutPanelProduct.AutoScroll = true;
            this.flowLayoutPanelProduct.BackColor = System.Drawing.Color.White;
            this.flowLayoutPanelProduct.Location = new System.Drawing.Point(425, 102);
            this.flowLayoutPanelProduct.Name = "flowLayoutPanelProduct";
            this.flowLayoutPanelProduct.Size = new System.Drawing.Size(1045, 715);
            this.flowLayoutPanelProduct.TabIndex = 22;
            // 
            // AddProduct
            // 
            this.AddProduct.BackColor = System.Drawing.Color.LightPink;
            this.AddProduct.Font = new System.Drawing.Font("Monotype Corsiva", 16.2F, System.Drawing.FontStyle.Italic);
            this.AddProduct.Location = new System.Drawing.Point(12, 778);
            this.AddProduct.Name = "AddProduct";
            this.AddProduct.Size = new System.Drawing.Size(400, 39);
            this.AddProduct.TabIndex = 23;
            this.AddProduct.Text = "Добавить товар";
            this.AddProduct.UseVisualStyleBackColor = false;
            this.AddProduct.Click += new System.EventHandler(this.AddProduct_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1179, 9);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 95);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 24;
            this.pictureBox1.TabStop = false;
            // 
            // AdminView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1486, 829);
            this.Controls.Add(this.AddProduct);
            this.Controls.Add(this.flowLayoutPanelProduct);
            this.Controls.Add(this.GoMain);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Count);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Price);
            this.Controls.Add(this.Description);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Kind);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.NameProduct);
            this.Controls.Add(this.DeletePicture);
            this.Controls.Add(this.Forward);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.AddPicture);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AdminView";
            this.Text = "Администратор";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button AddPicture;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Button Forward;
        private System.Windows.Forms.Button DeletePicture;
        private System.Windows.Forms.TextBox NameProduct;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Kind;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox Description;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox Price;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Count;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button GoMain;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProduct;
        private System.Windows.Forms.Button AddProduct;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}