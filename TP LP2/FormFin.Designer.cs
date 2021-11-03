
namespace TP_LP2
{
    partial class FormFin
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
            this.instFin = new System.Windows.Forms.Label();
            this.btnSi = new System.Windows.Forms.RadioButton();
            this.btnNo = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // instFin
            // 
            this.instFin.AutoSize = true;
            this.instFin.Location = new System.Drawing.Point(288, 187);
            this.instFin.Name = "instFin";
            this.instFin.Size = new System.Drawing.Size(219, 13);
            this.instFin.TabIndex = 5;
            this.instFin.Text = "¿Desea ver todas las soluciones generadas?";
            // 
            // btnSi
            // 
            this.btnSi.AutoSize = true;
            this.btnSi.Location = new System.Drawing.Point(344, 221);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(34, 17);
            this.btnSi.TabIndex = 6;
            this.btnSi.TabStop = true;
            this.btnSi.Text = "Si";
            this.btnSi.UseVisualStyleBackColor = true;
            this.btnSi.CheckedChanged += new System.EventHandler(this.btnSi_CheckedChanged);
            // 
            // btnNo
            // 
            this.btnNo.AutoSize = true;
            this.btnNo.Location = new System.Drawing.Point(416, 221);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(39, 17);
            this.btnNo.TabIndex = 7;
            this.btnNo.TabStop = true;
            this.btnNo.Text = "No";
            this.btnNo.UseVisualStyleBackColor = true;
            this.btnNo.CheckedChanged += new System.EventHandler(this.btnNo_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(380, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "FIN";
            // 
            // FormFin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnSi);
            this.Controls.Add(this.instFin);
            this.Name = "FormFin";
            this.Text = "FormFin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label instFin;
        private System.Windows.Forms.RadioButton btnSi;
        private System.Windows.Forms.RadioButton btnNo;
        private System.Windows.Forms.Label label1;
    }
}