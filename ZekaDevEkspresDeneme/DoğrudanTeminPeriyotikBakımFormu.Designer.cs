namespace ZekaDevEkspresDeneme
{
    partial class DoğrudanTeminPeriyodikBakımFormu
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Bakım Yapılacak İş Adı");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Firma Teklif Ekleme");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Firma Seç ve Sözleşme Hazırla");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Evrak Ekleme");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Servis Formu");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Süre Uzatım Tutanağı ");
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.ForeColor = System.Drawing.Color.Black;
            treeNode1.Name = "Node0";
            treeNode1.Text = "Bakım Yapılacak İş Adı";
            treeNode2.ForeColor = System.Drawing.Color.Black;
            treeNode2.Name = "Node2";
            treeNode2.Text = "Firma Teklif Ekleme";
            treeNode3.ForeColor = System.Drawing.Color.Black;
            treeNode3.Name = "Node3";
            treeNode3.Text = "Firma Seç ve Sözleşme Hazırla";
            treeNode4.ForeColor = System.Drawing.Color.Black;
            treeNode4.Name = "Node4";
            treeNode4.Text = "Evrak Ekleme";
            treeNode5.ForeColor = System.Drawing.Color.Black;
            treeNode5.Name = "Node31";
            treeNode5.Text = "Servis Formu";
            treeNode6.ForeColor = System.Drawing.Color.Black;
            treeNode6.Name = "Node5";
            treeNode6.Text = "Süre Uzatım Tutanağı ";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5,
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(176, 748);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TreeView1_AfterSelect);
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TreeView1_NodeMouseClick);
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(176, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1200, 748);
            this.panel1.TabIndex = 1;
            // 
            // DoğrudanTeminPeriyodikBakımFormu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1376, 748);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.treeView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "DoğrudanTeminPeriyodikBakımFormu";
            this.Text = "Doğrudan Temin Periyotik Bakım Formu";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.DoğrudanTeminPeriyotikBakımFormu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Panel panel1;
    }
}