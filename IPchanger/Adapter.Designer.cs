using System.Drawing;
using System.Drawing.Design;

namespace IPchanger
{
    partial class Adapter
    {
        /// <summary> 
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod wygenerowany przez Projektanta składników

        /// <summary> 
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować 
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Adapter));
            this.panelBack = new System.Windows.Forms.Panel();
            this.pictureWifi = new System.Windows.Forms.PictureBox();
            this.control_Active = new System.Windows.Forms.Button();
            this.label_maska = new System.Windows.Forms.Label();
            this.label_ipv4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_opis = new System.Windows.Forms.Label();
            this.label_nazwa = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox_NetworkIcon = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panelBack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWifi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NetworkIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // panelBack
            // 
            this.panelBack.Controls.Add(this.pictureWifi);
            this.panelBack.Controls.Add(this.control_Active);
            this.panelBack.Controls.Add(this.label_maska);
            this.panelBack.Controls.Add(this.label_ipv4);
            this.panelBack.Controls.Add(this.label3);
            this.panelBack.Controls.Add(this.label_opis);
            this.panelBack.Controls.Add(this.label_nazwa);
            this.panelBack.Controls.Add(this.label1);
            this.panelBack.Controls.Add(this.pictureBox_NetworkIcon);
            this.panelBack.Controls.Add(this.label2);
            this.panelBack.Controls.Add(this.label4);
            this.panelBack.Cursor = System.Windows.Forms.Cursors.Hand;
            this.panelBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelBack.Location = new System.Drawing.Point(0, 0);
            this.panelBack.Name = "panelBack";
            this.panelBack.Size = new System.Drawing.Size(380, 67);
            this.panelBack.TabIndex = 0;
            this.panelBack.Click += new System.EventHandler(this.panelBack_Click);
            this.panelBack.MouseLeave += new System.EventHandler(this.panelBack_MouseLeave);
            this.panelBack.MouseHover += new System.EventHandler(this.panelBack_MouseHover);
            // 
            // pictureWifi
            // 
            this.pictureWifi.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureWifi.BackgroundImage")));
            this.pictureWifi.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureWifi.Location = new System.Drawing.Point(337, 23);
            this.pictureWifi.Name = "pictureWifi";
            this.pictureWifi.Size = new System.Drawing.Size(39, 41);
            this.pictureWifi.TabIndex = 13;
            this.pictureWifi.TabStop = false;
            // 
            // control_Active
            // 
            this.control_Active.Enabled = false;
            this.control_Active.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.control_Active.Location = new System.Drawing.Point(49, 48);
            this.control_Active.Name = "control_Active";
            this.control_Active.Size = new System.Drawing.Size(16, 16);
            this.control_Active.TabIndex = 12;
            this.control_Active.UseVisualStyleBackColor = true;
            this.control_Active.Click += new System.EventHandler(this.control_Active_Click);
            // 
            // label_maska
            // 
            this.label_maska.AutoSize = true;
            this.label_maska.Location = new System.Drawing.Point(147, 46);
            this.label_maska.Name = "label_maska";
            this.label_maska.Size = new System.Drawing.Size(16, 13);
            this.label_maska.TabIndex = 4;
            this.label_maska.Text = "M";
            this.label_maska.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_maska.Click += new System.EventHandler(this.label_maska_Click);
            // 
            // label_ipv4
            // 
            this.label_ipv4.AutoSize = true;
            this.label_ipv4.Location = new System.Drawing.Point(147, 32);
            this.label_ipv4.Name = "label_ipv4";
            this.label_ipv4.Size = new System.Drawing.Size(17, 13);
            this.label_ipv4.TabIndex = 6;
            this.label_ipv4.Text = "IP";
            this.label_ipv4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_ipv4.Click += new System.EventHandler(this.label_ipv4_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(115, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "IPv4:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label_opis
            // 
            this.label_opis.AutoSize = true;
            this.label_opis.Location = new System.Drawing.Point(147, 18);
            this.label_opis.Name = "label_opis";
            this.label_opis.Size = new System.Drawing.Size(15, 13);
            this.label_opis.TabIndex = 8;
            this.label_opis.Text = "O";
            this.label_opis.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_opis.Click += new System.EventHandler(this.label_opis_Click);
            // 
            // label_nazwa
            // 
            this.label_nazwa.AutoSize = true;
            this.label_nazwa.Location = new System.Drawing.Point(147, 4);
            this.label_nazwa.Name = "label_nazwa";
            this.label_nazwa.Size = new System.Drawing.Size(15, 13);
            this.label_nazwa.TabIndex = 10;
            this.label_nazwa.Text = "N";
            this.label_nazwa.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_nazwa.Click += new System.EventHandler(this.label_nazwa_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(88, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nazwa:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox_NetworkIcon
            // 
            this.pictureBox_NetworkIcon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(224)))), ((int)(((byte)(251)))));
            this.pictureBox_NetworkIcon.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_NetworkIcon.BackgroundImage")));
            this.pictureBox_NetworkIcon.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox_NetworkIcon.Location = new System.Drawing.Point(3, 4);
            this.pictureBox_NetworkIcon.Name = "pictureBox_NetworkIcon";
            this.pictureBox_NetworkIcon.Size = new System.Drawing.Size(62, 60);
            this.pictureBox_NetworkIcon.TabIndex = 3;
            this.pictureBox_NetworkIcon.TabStop = false;
            this.pictureBox_NetworkIcon.Click += new System.EventHandler(this.pictureBox_NetworkIcon_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(72, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Opis:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(63, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Maska:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Adapter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(164)))), ((int)(((byte)(193)))), ((int)(((byte)(249)))));
            this.Controls.Add(this.panelBack);
            this.Name = "Adapter";
            this.Size = new System.Drawing.Size(380, 67);
            this.panelBack.ResumeLayout(false);
            this.panelBack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureWifi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_NetworkIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelBack;
        private System.Windows.Forms.Button control_Active;
        private System.Windows.Forms.Label label_maska;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label_ipv4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_opis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_nazwa;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox_NetworkIcon;
        private System.Windows.Forms.PictureBox pictureWifi;
    }
}
