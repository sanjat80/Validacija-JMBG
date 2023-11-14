namespace Validacija_JMBG
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txtIme = new System.Windows.Forms.TextBox();
            this.txtPrezime = new System.Windows.Forms.TextBox();
            this.txtJMBG = new System.Windows.Forms.TextBox();
            this.lblIme = new System.Windows.Forms.Label();
            this.lblPrezime = new System.Windows.Forms.Label();
            this.lblJmbg = new System.Windows.Forms.Label();
            this.btnValidiraj = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtIme
            // 
            this.txtIme.Location = new System.Drawing.Point(79, 81);
            this.txtIme.Name = "txtIme";
            this.txtIme.Size = new System.Drawing.Size(125, 27);
            this.txtIme.TabIndex = 0;
            // 
            // txtPrezime
            // 
            this.txtPrezime.Location = new System.Drawing.Point(80, 167);
            this.txtPrezime.Name = "txtPrezime";
            this.txtPrezime.Size = new System.Drawing.Size(125, 27);
            this.txtPrezime.TabIndex = 1;
            // 
            // txtJMBG
            // 
            this.txtJMBG.Location = new System.Drawing.Point(81, 245);
            this.txtJMBG.Name = "txtJMBG";
            this.txtJMBG.Size = new System.Drawing.Size(125, 27);
            this.txtJMBG.TabIndex = 2;
            // 
            // lblIme
            // 
            this.lblIme.AutoSize = true;
            this.lblIme.Location = new System.Drawing.Point(80, 43);
            this.lblIme.Name = "lblIme";
            this.lblIme.Size = new System.Drawing.Size(34, 20);
            this.lblIme.TabIndex = 4;
            this.lblIme.Text = "Ime";
            // 
            // lblPrezime
            // 
            this.lblPrezime.AutoSize = true;
            this.lblPrezime.Location = new System.Drawing.Point(80, 131);
            this.lblPrezime.Name = "lblPrezime";
            this.lblPrezime.Size = new System.Drawing.Size(62, 20);
            this.lblPrezime.TabIndex = 5;
            this.lblPrezime.Text = "Prezime";
            // 
            // lblJmbg
            // 
            this.lblJmbg.AutoSize = true;
            this.lblJmbg.Location = new System.Drawing.Point(81, 211);
            this.lblJmbg.Name = "lblJmbg";
            this.lblJmbg.Size = new System.Drawing.Size(89, 20);
            this.lblJmbg.TabIndex = 6;
            this.lblJmbg.Text = "Matični broj";
            // 
            // btnValidiraj
            // 
            this.btnValidiraj.Location = new System.Drawing.Point(81, 300);
            this.btnValidiraj.Name = "btnValidiraj";
            this.btnValidiraj.Size = new System.Drawing.Size(94, 29);
            this.btnValidiraj.TabIndex = 7;
            this.btnValidiraj.Text = "Validiraj";
            this.btnValidiraj.UseVisualStyleBackColor = true;
            this.btnValidiraj.Click += new System.EventHandler(this.btnValidiraj_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 450);
            this.Controls.Add(this.btnValidiraj);
            this.Controls.Add(this.lblJmbg);
            this.Controls.Add(this.lblPrezime);
            this.Controls.Add(this.lblIme);
            this.Controls.Add(this.txtJMBG);
            this.Controls.Add(this.txtPrezime);
            this.Controls.Add(this.txtIme);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtIme;
        private TextBox txtPrezime;
        private TextBox txtJMBG;
        private Label lblIme;
        private Label lblPrezime;
        private Label lblJmbg;
        private Button btnValidiraj;
    }
}