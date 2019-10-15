namespace ZekaDevEkspresDeneme
{
    partial class ParasalLimitler
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.karmaDataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.deleteButton = new System.Windows.Forms.Button();
            this.guncelleButton = new System.Windows.Forms.Button();
            this.ekleButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ufeTextBox = new System.Windows.Forms.TextBox();
            this.yilTextBox = new System.Windows.Forms.TextBox();
            this.ufeDataGridView = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.karmaDataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ufeDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.karmaDataGridView);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1376, 275);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Parasal Limitler Tablosu";
            // 
            // karmaDataGridView
            // 
            this.karmaDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.karmaDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.karmaDataGridView.Location = new System.Drawing.Point(12, 20);
            this.karmaDataGridView.Name = "karmaDataGridView";
            this.karmaDataGridView.ReadOnly = true;
            this.karmaDataGridView.Size = new System.Drawing.Size(1321, 233);
            this.karmaDataGridView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.deleteButton);
            this.groupBox2.Controls.Add(this.guncelleButton);
            this.groupBox2.Controls.Add(this.ekleButton);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.ufeTextBox);
            this.groupBox2.Controls.Add(this.yilTextBox);
            this.groupBox2.Controls.Add(this.ufeDataGridView);
            this.groupBox2.Location = new System.Drawing.Point(12, 281);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(942, 286);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Üfeler Tablosu";
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(830, 177);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 7;
            this.deleteButton.Text = "Sil";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // guncelleButton
            // 
            this.guncelleButton.Enabled = false;
            this.guncelleButton.Location = new System.Drawing.Point(722, 177);
            this.guncelleButton.Name = "guncelleButton";
            this.guncelleButton.Size = new System.Drawing.Size(75, 23);
            this.guncelleButton.TabIndex = 6;
            this.guncelleButton.Text = "Güncelle";
            this.guncelleButton.UseVisualStyleBackColor = true;
            this.guncelleButton.Click += new System.EventHandler(this.GuncelleButton_Click);
            // 
            // ekleButton
            // 
            this.ekleButton.Location = new System.Drawing.Point(614, 177);
            this.ekleButton.Name = "ekleButton";
            this.ekleButton.Size = new System.Drawing.Size(75, 23);
            this.ekleButton.TabIndex = 5;
            this.ekleButton.Text = "Ekle";
            this.ekleButton.UseVisualStyleBackColor = true;
            this.ekleButton.Click += new System.EventHandler(this.EkleButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 14);
            this.label2.TabIndex = 4;
            this.label2.Text = "Üfe Oranı(%) :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(689, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 14);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yıl :";
            // 
            // ufeTextBox
            // 
            this.ufeTextBox.Location = new System.Drawing.Point(722, 106);
            this.ufeTextBox.Name = "ufeTextBox";
            this.ufeTextBox.Size = new System.Drawing.Size(129, 21);
            this.ufeTextBox.TabIndex = 2;
            this.ufeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.UfeTextBox_KeyPress);
            // 
            // yilTextBox
            // 
            this.yilTextBox.Location = new System.Drawing.Point(722, 58);
            this.yilTextBox.MaxLength = 4;
            this.yilTextBox.Name = "yilTextBox";
            this.yilTextBox.Size = new System.Drawing.Size(57, 21);
            this.yilTextBox.TabIndex = 1;
            this.yilTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.YilTextBox_KeyPress);
            // 
            // ufeDataGridView
            // 
            this.ufeDataGridView.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.ufeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ufeDataGridView.Location = new System.Drawing.Point(7, 21);
            this.ufeDataGridView.Name = "ufeDataGridView";
            this.ufeDataGridView.ReadOnly = true;
            this.ufeDataGridView.Size = new System.Drawing.Size(572, 252);
            this.ufeDataGridView.TabIndex = 0;
            this.ufeDataGridView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.UfeDataGridView_CellClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(857, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 14);
            this.label3.TabIndex = 8;
            this.label3.Text = "Örn : 31,52";
            // 
            // ParasalLimitler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1376, 747);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "ParasalLimitler";
            this.Text = "ParasalLimitler";
            this.Load += new System.EventHandler(this.ParasalLimitler_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.karmaDataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ufeDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView karmaDataGridView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button guncelleButton;
        private System.Windows.Forms.Button ekleButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ufeTextBox;
        private System.Windows.Forms.TextBox yilTextBox;
        private System.Windows.Forms.DataGridView ufeDataGridView;
        private System.Windows.Forms.Label label3;
    }
}