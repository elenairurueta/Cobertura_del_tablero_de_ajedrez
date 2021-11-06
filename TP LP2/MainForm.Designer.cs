
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
            this.btn20 = new System.Windows.Forms.Button();
            this.btn15 = new System.Windows.Forms.Button();
            this.btn35 = new System.Windows.Forms.Button();
            this.btn30 = new System.Windows.Forms.Button();
            this.btn25 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn1
            // 
            this.btn1.Location = new System.Drawing.Point(187, 216);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(78, 35);
            this.btn1.TabIndex = 0;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btn1_Click);
            // 
            // btn5
            // 
            this.btn5.Location = new System.Drawing.Point(297, 216);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(78, 35);
            this.btn5.TabIndex = 1;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btn5_Click);
            // 
            // btn10
            // 
            this.btn10.Location = new System.Drawing.Point(411, 216);
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
            // btn20
            // 
            this.btn20.Location = new System.Drawing.Point(187, 275);
            this.btn20.Name = "btn20";
            this.btn20.Size = new System.Drawing.Size(78, 35);
            this.btn20.TabIndex = 6;
            this.btn20.Text = "20";
            this.btn20.UseVisualStyleBackColor = true;
            this.btn20.Click += new System.EventHandler(this.btn20_Click);
            // 
            // btn15
            // 
            this.btn15.Location = new System.Drawing.Point(524, 216);
            this.btn15.Name = "btn15";
            this.btn15.Size = new System.Drawing.Size(78, 35);
            this.btn15.TabIndex = 5;
            this.btn15.Text = "15";
            this.btn15.UseVisualStyleBackColor = true;
            this.btn15.Click += new System.EventHandler(this.btn15_Click);
            // 
            // btn35
            // 
            this.btn35.Location = new System.Drawing.Point(524, 275);
            this.btn35.Name = "btn35";
            this.btn35.Size = new System.Drawing.Size(78, 35);
            this.btn35.TabIndex = 9;
            this.btn35.Text = "35";
            this.btn35.UseVisualStyleBackColor = true;
            this.btn35.Click += new System.EventHandler(this.btn35_Click);
            // 
            // btn30
            // 
            this.btn30.Location = new System.Drawing.Point(411, 275);
            this.btn30.Name = "btn30";
            this.btn30.Size = new System.Drawing.Size(78, 35);
            this.btn30.TabIndex = 8;
            this.btn30.Text = "30";
            this.btn30.UseVisualStyleBackColor = true;
            this.btn30.Click += new System.EventHandler(this.btn30_Click);
            // 
            // btn25
            // 
            this.btn25.Location = new System.Drawing.Point(297, 275);
            this.btn25.Name = "btn25";
            this.btn25.Size = new System.Drawing.Size(78, 35);
            this.btn25.TabIndex = 7;
            this.btn25.Text = "25";
            this.btn25.UseVisualStyleBackColor = true;
            this.btn25.Click += new System.EventHandler(this.btn25_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn35);
            this.Controls.Add(this.btn30);
            this.Controls.Add(this.btn25);
            this.Controls.Add(this.btn20);
            this.Controls.Add(this.btn15);
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
        private System.Windows.Forms.Button btn20;
        private System.Windows.Forms.Button btn15;
        private System.Windows.Forms.Button btn35;
        private System.Windows.Forms.Button btn30;
        private System.Windows.Forms.Button btn25;
    }
}

