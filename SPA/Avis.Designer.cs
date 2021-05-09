
namespace SPA
{
    partial class Avis
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonAnnuler = new System.Windows.Forms.Button();
            this.buttonEnregistrer = new System.Windows.Forms.Button();
            this.labelErrorAvis = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(161, 77);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(575, 277);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(66, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(235, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Merci d\'écrire votre avis sur cette enquête : ";
            // 
            // buttonAnnuler
            // 
            this.buttonAnnuler.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.buttonAnnuler.Location = new System.Drawing.Point(243, 405);
            this.buttonAnnuler.Name = "buttonAnnuler";
            this.buttonAnnuler.Size = new System.Drawing.Size(148, 53);
            this.buttonAnnuler.TabIndex = 2;
            this.buttonAnnuler.Text = "Annuler";
            this.buttonAnnuler.UseVisualStyleBackColor = false;
            this.buttonAnnuler.Click += new System.EventHandler(this.buttonAnnuler_Click);
            // 
            // buttonEnregistrer
            // 
            this.buttonEnregistrer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonEnregistrer.Location = new System.Drawing.Point(540, 405);
            this.buttonEnregistrer.Name = "buttonEnregistrer";
            this.buttonEnregistrer.Size = new System.Drawing.Size(136, 53);
            this.buttonEnregistrer.TabIndex = 3;
            this.buttonEnregistrer.Text = "Enregistrer et clôturer l\'enquête";
            this.buttonEnregistrer.UseVisualStyleBackColor = false;
            this.buttonEnregistrer.Click += new System.EventHandler(this.buttonEnregistrer_Click);
            // 
            // labelErrorAvis
            // 
            this.labelErrorAvis.AutoSize = true;
            this.labelErrorAvis.ForeColor = System.Drawing.Color.Red;
            this.labelErrorAvis.Location = new System.Drawing.Point(401, 369);
            this.labelErrorAvis.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.labelErrorAvis.Name = "labelErrorAvis";
            this.labelErrorAvis.Size = new System.Drawing.Size(156, 15);
            this.labelErrorAvis.TabIndex = 63;
            this.labelErrorAvis.Text = "* Votre avis ne peut être vide";
            this.labelErrorAvis.Visible = false;
            // 
            // Avis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 529);
            this.Controls.Add(this.labelErrorAvis);
            this.Controls.Add(this.buttonEnregistrer);
            this.Controls.Add(this.buttonAnnuler);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Avis";
            this.Text = "Avis";
            this.Load += new System.EventHandler(this.Avis_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAnnuler;
        private System.Windows.Forms.Button buttonEnregistrer;
        private System.Windows.Forms.Label labelErrorAvis;
    }
}