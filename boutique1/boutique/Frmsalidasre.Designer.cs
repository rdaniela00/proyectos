namespace boutique
{
    partial class Frmsalidasre
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
            this.dgvreportesalidas = new System.Windows.Forms.DataGridView();
            this.btnimprimir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvreportesalidas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvreportesalidas
            // 
            this.dgvreportesalidas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvreportesalidas.Location = new System.Drawing.Point(50, 102);
            this.dgvreportesalidas.Name = "dgvreportesalidas";
            this.dgvreportesalidas.Size = new System.Drawing.Size(398, 241);
            this.dgvreportesalidas.TabIndex = 3;
            this.dgvreportesalidas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvreportesalidas_CellContentClick);
            // 
            // btnimprimir
            // 
            this.btnimprimir.Location = new System.Drawing.Point(397, 52);
            this.btnimprimir.Name = "btnimprimir";
            this.btnimprimir.Size = new System.Drawing.Size(75, 23);
            this.btnimprimir.TabIndex = 2;
            this.btnimprimir.Text = "imprimir";
            this.btnimprimir.UseVisualStyleBackColor = true;
            this.btnimprimir.Click += new System.EventHandler(this.btnimprimir_Click);
            // 
            // Frmsalidasre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 395);
            this.Controls.Add(this.dgvreportesalidas);
            this.Controls.Add(this.btnimprimir);
            this.Name = "Frmsalidasre";
            this.Text = "Frmsalidasre";
            this.Load += new System.EventHandler(this.Frmsalidasre_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvreportesalidas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvreportesalidas;
        private System.Windows.Forms.Button btnimprimir;
    }
}