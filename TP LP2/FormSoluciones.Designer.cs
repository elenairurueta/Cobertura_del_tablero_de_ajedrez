
namespace TP_LP2
{
    partial class FormSoluciones
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
            this.btnVolverMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVolverMain
            // 
            this.btnVolverMain.Location = new System.Drawing.Point(629, 359);
            this.btnVolverMain.Name = "btnVolverMain";
            this.btnVolverMain.Size = new System.Drawing.Size(116, 23);
            this.btnVolverMain.TabIndex = 0;
            this.btnVolverMain.Text = "Menú Principal";
            this.btnVolverMain.UseVisualStyleBackColor = true;
            this.btnVolverMain.Click += new System.EventHandler(this.btnVolverMain_Click);
            // 
            // FormSoluciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVolverMain);
            this.Name = "FormSoluciones";
            this.Text = "FormSoluciones";
            this.Load += new System.EventHandler(this.FormSoluciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVolverMain;
    }
}