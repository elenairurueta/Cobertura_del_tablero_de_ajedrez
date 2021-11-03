
namespace TP_LP2
{
    partial class MainForm
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
            this.btn1 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn10 = new System.Windows.Forms.Button();
            this.instMain = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(209, 223);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(78, 35);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(347, 223);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(78, 35);
            this.btn5.TabIndex = 1;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn10
            // 
            this.btn10.Location = new System.Drawing.Point(478, 223);
            this.btn10.Name = "btn10";
            this.btn10.Size = new System.Drawing.Size(78, 35);
            this.btn10.TabIndex = 2;
            this.btn10.Text = "10";
            this.btn10.UseVisualStyleBackColor = true;
            this.btn10.Click += new System.EventHandler(this.btn10_Click);
            // 
            // instMain
            // 
            this.instMain.AutoSize = true;
            this.instMain.Location = new System.Drawing.Point(271, 179);
            this.instMain.Name = "instMain";
            this.instMain.Size = new System.Drawing.Size(234, 13);
            this.instMain.TabIndex = 4;
            this.instMain.Text = "Seleccione la cantidad de soluciones a generar:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.instMain);
            this.Controls.Add(this.btn10);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn1);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn1;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn10;
        private System.Windows.Forms.Label instMain;
    }
}

