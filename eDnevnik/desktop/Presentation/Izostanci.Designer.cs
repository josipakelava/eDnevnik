namespace Desktop
{
    partial class Izostanci
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Izostanci));
            this.dgvIzostanci = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNaslovnica = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzostanci)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvIzostanci
            // 
            this.dgvIzostanci.AllowUserToAddRows = false;
            this.dgvIzostanci.AllowUserToDeleteRows = false;
            this.dgvIzostanci.AllowUserToResizeColumns = false;
            this.dgvIzostanci.AllowUserToResizeRows = false;
            this.dgvIzostanci.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvIzostanci.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvIzostanci.BackgroundColor = System.Drawing.Color.White;
            this.dgvIzostanci.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIzostanci.Location = new System.Drawing.Point(12, 49);
            this.dgvIzostanci.Name = "dgvIzostanci";
            this.dgvIzostanci.RowTemplate.Height = 24;
            this.dgvIzostanci.Size = new System.Drawing.Size(828, 305);
            this.dgvIzostanci.TabIndex = 0;
            this.dgvIzostanci.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.HandleChange);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(828, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "Izostanci";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNaslovnica
            // 
            this.btnNaslovnica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202)))));
            this.btnNaslovnica.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNaslovnica.ForeColor = System.Drawing.Color.White;
            this.btnNaslovnica.Location = new System.Drawing.Point(12, 371);
            this.btnNaslovnica.Name = "btnNaslovnica";
            this.btnNaslovnica.Size = new System.Drawing.Size(169, 42);
            this.btnNaslovnica.TabIndex = 2;
            this.btnNaslovnica.Text = "Naslovnica";
            this.btnNaslovnica.UseVisualStyleBackColor = false;
            this.btnNaslovnica.Click += new System.EventHandler(this.btnNaslovnica_Click);
            // 
            // Izostanci
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(852, 427);
            this.Controls.Add(this.btnNaslovnica);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dgvIzostanci);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Izostanci";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Izostanci";
            ((System.ComponentModel.ISupportInitialize)(this.dgvIzostanci)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvIzostanci;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNaslovnica;
    }
}