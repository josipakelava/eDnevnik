namespace Desktop
{
    partial class UcenikNaslovna
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcenikNaslovna));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.izostanciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjavaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRazrednik = new System.Windows.Forms.TextBox();
            this.txtUcenik = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbPredmeti = new System.Windows.Forms.ListBox();
            this.btnDetalji = new System.Windows.Forms.Button();
            this.txtRazred = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvOcjene = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvBiljeske = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcjene)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiljeske)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilToolStripMenuItem,
            this.izostanciToolStripMenuItem,
            this.odjavaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1105, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.profilToolStripMenuItem.Text = "Profil";
            this.profilToolStripMenuItem.Click += new System.EventHandler(this.profilToolStripMenuItem_Click);
            // 
            // izostanciToolStripMenuItem
            // 
            this.izostanciToolStripMenuItem.Name = "izostanciToolStripMenuItem";
            this.izostanciToolStripMenuItem.Size = new System.Drawing.Size(79, 24);
            this.izostanciToolStripMenuItem.Text = "Izostanci";
            this.izostanciToolStripMenuItem.Click += new System.EventHandler(this.izostanciToolStripMenuItem_Click);
            // 
            // odjavaToolStripMenuItem
            // 
            this.odjavaToolStripMenuItem.Name = "odjavaToolStripMenuItem";
            this.odjavaToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.odjavaToolStripMenuItem.Text = "Odjava";
            this.odjavaToolStripMenuItem.Click += new System.EventHandler(this.odjavaToolStripMenuItem_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(16, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Razrednik:";
            // 
            // txtRazrednik
            // 
            this.txtRazrednik.Enabled = false;
            this.txtRazrednik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRazrednik.Location = new System.Drawing.Point(121, 107);
            this.txtRazrednik.Name = "txtRazrednik";
            this.txtRazrednik.Size = new System.Drawing.Size(182, 26);
            this.txtRazrednik.TabIndex = 2;
            // 
            // txtUcenik
            // 
            this.txtUcenik.Enabled = false;
            this.txtUcenik.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtUcenik.Location = new System.Drawing.Point(121, 43);
            this.txtUcenik.Name = "txtUcenik";
            this.txtUcenik.Size = new System.Drawing.Size(182, 26);
            this.txtUcenik.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(16, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Učenik:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.label3.Location = new System.Drawing.Point(77, 177);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(141, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Moji predmeti";
            // 
            // lbPredmeti
            // 
            this.lbPredmeti.FormattingEnabled = true;
            this.lbPredmeti.ItemHeight = 16;
            this.lbPredmeti.Location = new System.Drawing.Point(32, 217);
            this.lbPredmeti.Name = "lbPredmeti";
            this.lbPredmeti.Size = new System.Drawing.Size(248, 196);
            this.lbPredmeti.TabIndex = 8;
            // 
            // btnDetalji
            // 
            this.btnDetalji.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.btnDetalji.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDetalji.ForeColor = System.Drawing.Color.White;
            this.btnDetalji.Location = new System.Drawing.Point(82, 431);
            this.btnDetalji.Name = "btnDetalji";
            this.btnDetalji.Size = new System.Drawing.Size(136, 43);
            this.btnDetalji.TabIndex = 9;
            this.btnDetalji.Text = "Detalji";
            this.btnDetalji.UseVisualStyleBackColor = false;
            this.btnDetalji.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // txtRazred
            // 
            this.txtRazred.Enabled = false;
            this.txtRazred.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtRazred.Location = new System.Drawing.Point(121, 75);
            this.txtRazred.Name = "txtRazred";
            this.txtRazred.Size = new System.Drawing.Size(182, 26);
            this.txtRazred.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(16, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Razred:";
            // 
            // dgvOcjene
            // 
            this.dgvOcjene.AllowUserToAddRows = false;
            this.dgvOcjene.AllowUserToDeleteRows = false;
            this.dgvOcjene.AllowUserToResizeColumns = false;
            this.dgvOcjene.AllowUserToResizeRows = false;
            this.dgvOcjene.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvOcjene.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvOcjene.BackgroundColor = System.Drawing.Color.White;
            this.dgvOcjene.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvOcjene.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvOcjene.GridColor = System.Drawing.Color.Black;
            this.dgvOcjene.Location = new System.Drawing.Point(10, 44);
            this.dgvOcjene.Name = "dgvOcjene";
            this.dgvOcjene.ReadOnly = true;
            this.dgvOcjene.RowTemplate.Height = 24;
            this.dgvOcjene.Size = new System.Drawing.Size(731, 150);
            this.dgvOcjene.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.label5.Location = new System.Drawing.Point(5, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(308, 25);
            this.label5.TabIndex = 13;
            this.label5.Text = "Ocjene iz odabranog predmeta";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightGray;
            this.panel1.Controls.Add(this.dgvOcjene);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.dgvBiljeske);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(342, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(751, 428);
            this.panel1.TabIndex = 14;
            // 
            // dgvBiljeske
            // 
            this.dgvBiljeske.AllowUserToAddRows = false;
            this.dgvBiljeske.AllowUserToDeleteRows = false;
            this.dgvBiljeske.AllowUserToResizeColumns = false;
            this.dgvBiljeske.AllowUserToResizeRows = false;
            this.dgvBiljeske.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBiljeske.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvBiljeske.BackgroundColor = System.Drawing.Color.White;
            this.dgvBiljeske.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBiljeske.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvBiljeske.GridColor = System.Drawing.Color.Black;
            this.dgvBiljeske.Location = new System.Drawing.Point(10, 262);
            this.dgvBiljeske.Name = "dgvBiljeske";
            this.dgvBiljeske.ReadOnly = true;
            this.dgvBiljeske.RowTemplate.Height = 24;
            this.dgvBiljeske.Size = new System.Drawing.Size(731, 153);
            this.dgvBiljeske.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.label6.Location = new System.Drawing.Point(5, 221);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(314, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Bilješke iz odabranog predmeta";
            // 
            // UcenikNaslovna
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 491);
            this.Controls.Add(this.txtRazred);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnDetalji);
            this.Controls.Add(this.lbPredmeti);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtUcenik);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtRazrednik);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UcenikNaslovna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ucenik - Naslovna";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcjene)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiljeske)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem izostanciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odjavaToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRazrednik;
        private System.Windows.Forms.TextBox txtUcenik;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbPredmeti;
        private System.Windows.Forms.Button btnDetalji;
        private System.Windows.Forms.TextBox txtRazred;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvOcjene;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBiljeske;
    }
}