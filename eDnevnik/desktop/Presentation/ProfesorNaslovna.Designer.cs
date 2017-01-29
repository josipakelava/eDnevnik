namespace Desktop
{
    partial class ProfesorNaslovna
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProfesorNaslovna));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.profilToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mojRazredToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.odjavaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRazred = new System.Windows.Forms.ComboBox();
            this.cbPredmet = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOdabir = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvOcjene = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.dgvBiljeske = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.lbUcenici = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnNijePrisutan = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcjene)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiljeske)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilToolStripMenuItem,
            this.mojRazredToolStripMenuItem,
            this.odjavaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1044, 28);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // profilToolStripMenuItem
            // 
            this.profilToolStripMenuItem.Name = "profilToolStripMenuItem";
            this.profilToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.profilToolStripMenuItem.Text = "Profil";
            this.profilToolStripMenuItem.Click += new System.EventHandler(this.profilToolStripMenuItem_Click);
            // 
            // mojRazredToolStripMenuItem
            // 
            this.mojRazredToolStripMenuItem.Name = "mojRazredToolStripMenuItem";
            this.mojRazredToolStripMenuItem.Size = new System.Drawing.Size(97, 24);
            this.mojRazredToolStripMenuItem.Text = "Moj Razred";
            this.mojRazredToolStripMenuItem.Click += new System.EventHandler(this.mojRazredToolStripMenuItem_Click);
            // 
            // odjavaToolStripMenuItem
            // 
            this.odjavaToolStripMenuItem.Name = "odjavaToolStripMenuItem";
            this.odjavaToolStripMenuItem.Size = new System.Drawing.Size(68, 24);
            this.odjavaToolStripMenuItem.Text = "Odjava";
            this.odjavaToolStripMenuItem.Click += new System.EventHandler(this.odjavaToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbRazred);
            this.panel1.Controls.Add(this.cbPredmet);
            this.panel1.Location = new System.Drawing.Point(13, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1002, 92);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(14, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Odaberite predmet:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(14, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Odaberite razred:";
            // 
            // cbRazred
            // 
            this.cbRazred.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbRazred.FormattingEnabled = true;
            this.cbRazred.Location = new System.Drawing.Point(251, 47);
            this.cbRazred.Name = "cbRazred";
            this.cbRazred.Size = new System.Drawing.Size(741, 28);
            this.cbRazred.TabIndex = 1;
            this.cbRazred.TextChanged += new System.EventHandler(this.HandleRazredChange);
            // 
            // cbPredmet
            // 
            this.cbPredmet.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cbPredmet.FormattingEnabled = true;
            this.cbPredmet.Location = new System.Drawing.Point(251, 13);
            this.cbPredmet.Name = "cbPredmet";
            this.cbPredmet.Size = new System.Drawing.Size(741, 28);
            this.cbPredmet.TabIndex = 0;
            this.cbPredmet.TextChanged += new System.EventHandler(this.HandlePredmetChange);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.label3.Location = new System.Drawing.Point(31, 189);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "Učenici";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOdabir
            // 
            this.btnOdabir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.btnOdabir.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnOdabir.ForeColor = System.Drawing.Color.White;
            this.btnOdabir.Location = new System.Drawing.Point(31, 144);
            this.btnOdabir.Name = "btnOdabir";
            this.btnOdabir.Size = new System.Drawing.Size(182, 42);
            this.btnOdabir.TabIndex = 1;
            this.btnOdabir.Text = "Slučajan odabir";
            this.btnOdabir.UseVisualStyleBackColor = false;
            this.btnOdabir.Click += new System.EventHandler(this.btnOdabir_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LightGray;
            this.panel2.Controls.Add(this.dgvOcjene);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.dgvBiljeske);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(264, 144);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(751, 381);
            this.panel2.TabIndex = 5;
            // 
            // dgvOcjene
            // 
            this.dgvOcjene.AllowUserToAddRows = false;
            this.dgvOcjene.AllowUserToDeleteRows = false;
            this.dgvOcjene.AllowUserToResizeColumns = false;
            this.dgvOcjene.AllowUserToResizeRows = false;
            this.dgvOcjene.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
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
            this.dgvOcjene.Location = new System.Drawing.Point(10, 37);
            this.dgvOcjene.Name = "dgvOcjene";
            this.dgvOcjene.RowTemplate.Height = 24;
            this.dgvOcjene.Size = new System.Drawing.Size(731, 130);
            this.dgvOcjene.TabIndex = 0;
            this.dgvOcjene.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.saveChange);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.label5.Location = new System.Drawing.Point(5, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 25);
            this.label5.TabIndex = 2;
            this.label5.Text = "Ocjene";
            // 
            // dgvBiljeske
            // 
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
            this.dgvBiljeske.Location = new System.Drawing.Point(10, 217);
            this.dgvBiljeske.Name = "dgvBiljeske";
            this.dgvBiljeske.RowTemplate.Height = 24;
            this.dgvBiljeske.Size = new System.Drawing.Size(731, 152);
            this.dgvBiljeske.TabIndex = 1;
            this.dgvBiljeske.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.HandleBiljeska);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.label6.Location = new System.Drawing.Point(5, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 25);
            this.label6.TabIndex = 3;
            this.label6.Text = "Bilješke ";
            // 
            // lbUcenici
            // 
            this.lbUcenici.FormattingEnabled = true;
            this.lbUcenici.ItemHeight = 16;
            this.lbUcenici.Location = new System.Drawing.Point(31, 222);
            this.lbUcenici.Name = "lbUcenici";
            this.lbUcenici.Size = new System.Drawing.Size(182, 180);
            this.lbUcenici.TabIndex = 2;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(67, 408);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(110, 42);
            this.button1.TabIndex = 3;
            this.button1.Text = "Detalji";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnDetalji_Click);
            // 
            // btnNijePrisutan
            // 
            this.btnNijePrisutan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnNijePrisutan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNijePrisutan.ForeColor = System.Drawing.Color.White;
            this.btnNijePrisutan.Location = new System.Drawing.Point(31, 483);
            this.btnNijePrisutan.Name = "btnNijePrisutan";
            this.btnNijePrisutan.Size = new System.Drawing.Size(182, 42);
            this.btnNijePrisutan.TabIndex = 4;
            this.btnNijePrisutan.Text = "Nije prisutan";
            this.btnNijePrisutan.UseVisualStyleBackColor = false;
            this.btnNijePrisutan.Click += new System.EventHandler(this.btnNijePrisutan_Click);
            // 
            // ProfesorNaslovna
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1044, 537);
            this.Controls.Add(this.btnNijePrisutan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbUcenici);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnOdabir);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProfesorNaslovna";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " ";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOcjene)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBiljeske)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem profilToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mojRazredToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem odjavaToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRazred;
        private System.Windows.Forms.ComboBox cbPredmet;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnOdabir;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvOcjene;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgvBiljeske;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox lbUcenici;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnNijePrisutan;
    }
}