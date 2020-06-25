namespace IPchanger
{
    partial class StartForm
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

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.TopBar = new System.Windows.Forms.Panel();
            this.labelTitle = new System.Windows.Forms.Label();
            this.pictureBoxLogo = new System.Windows.Forms.PictureBox();
            this.buttonMinimize = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.panelContent = new System.Windows.Forms.Panel();
            this.button_Languages = new System.Windows.Forms.Button();
            this.button_cmd_IPsAll = new System.Windows.Forms.Button();
            this.button_cmd_IPs = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.TopBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).BeginInit();
            this.panelContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // TopBar
            // 
            this.TopBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(155)))), ((int)(((byte)(242)))));
            this.TopBar.Controls.Add(this.labelTitle);
            this.TopBar.Controls.Add(this.pictureBoxLogo);
            this.TopBar.Controls.Add(this.buttonMinimize);
            this.TopBar.Controls.Add(this.buttonClose);
            this.TopBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopBar.Location = new System.Drawing.Point(0, 0);
            this.TopBar.Name = "TopBar";
            this.TopBar.Size = new System.Drawing.Size(522, 45);
            this.TopBar.TabIndex = 0;
            this.TopBar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TopBar_MouseDown);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Consolas", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelTitle.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelTitle.Location = new System.Drawing.Point(55, 7);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(165, 32);
            this.labelTitle.TabIndex = 4;
            this.labelTitle.Text = "IP Changer";
            this.labelTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelTitle_MouseDown);
            // 
            // pictureBoxLogo
            // 
            this.pictureBoxLogo.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxLogo.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogo.BackgroundImage")));
            this.pictureBoxLogo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxLogo.Location = new System.Drawing.Point(1, 1);
            this.pictureBoxLogo.Name = "pictureBoxLogo";
            this.pictureBoxLogo.Size = new System.Drawing.Size(53, 44);
            this.pictureBoxLogo.TabIndex = 0;
            this.pictureBoxLogo.TabStop = false;
            this.pictureBoxLogo.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBoxLogo_MouseDown);
            // 
            // buttonMinimize
            // 
            this.buttonMinimize.BackColor = System.Drawing.Color.Transparent;
            this.buttonMinimize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonMinimize.BackgroundImage")));
            this.buttonMinimize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.buttonMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMinimize.Location = new System.Drawing.Point(449, 3);
            this.buttonMinimize.Name = "buttonMinimize";
            this.buttonMinimize.Size = new System.Drawing.Size(32, 32);
            this.buttonMinimize.TabIndex = 3;
            this.buttonMinimize.UseVisualStyleBackColor = false;
            this.buttonMinimize.Click += new System.EventHandler(this.buttonMinimize_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.BackColor = System.Drawing.Color.Transparent;
            this.buttonClose.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonClose.BackgroundImage")));
            this.buttonClose.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonClose.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonClose.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Red;
            this.buttonClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonClose.Location = new System.Drawing.Point(487, 3);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(32, 32);
            this.buttonClose.TabIndex = 2;
            this.buttonClose.UseVisualStyleBackColor = false;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(155)))), ((int)(((byte)(242)))));
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 45);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(15, 457);
            this.LeftPanel.TabIndex = 1;
            // 
            // panelContent
            // 
            this.panelContent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(72)))), ((int)(((byte)(114)))));
            this.panelContent.Controls.Add(this.button_Languages);
            this.panelContent.Controls.Add(this.button_cmd_IPsAll);
            this.panelContent.Controls.Add(this.button_cmd_IPs);
            this.panelContent.Controls.Add(this.flowLayoutPanel1);
            this.panelContent.Controls.Add(this.button1);
            this.panelContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContent.Location = new System.Drawing.Point(15, 45);
            this.panelContent.Name = "panelContent";
            this.panelContent.Size = new System.Drawing.Size(507, 457);
            this.panelContent.TabIndex = 2;
            // 
            // button_Languages
            // 
            this.button_Languages.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_Languages.BackgroundImage")));
            this.button_Languages.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_Languages.FlatAppearance.BorderSize = 0;
            this.button_Languages.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_Languages.Location = new System.Drawing.Point(456, 8);
            this.button_Languages.Name = "button_Languages";
            this.button_Languages.Size = new System.Drawing.Size(44, 34);
            this.button_Languages.TabIndex = 7;
            this.button_Languages.UseVisualStyleBackColor = true;
            this.button_Languages.Click += new System.EventHandler(this.button_Languages_Click);
            // 
            // button_cmd_IPsAll
            // 
            this.button_cmd_IPsAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.button_cmd_IPsAll.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_cmd_IPsAll.BackgroundImage")));
            this.button_cmd_IPsAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_cmd_IPsAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cmd_IPsAll.Location = new System.Drawing.Point(372, 7);
            this.button_cmd_IPsAll.Name = "button_cmd_IPsAll";
            this.button_cmd_IPsAll.Size = new System.Drawing.Size(48, 34);
            this.button_cmd_IPsAll.TabIndex = 6;
            this.button_cmd_IPsAll.UseVisualStyleBackColor = false;
            this.button_cmd_IPsAll.Click += new System.EventHandler(this.button_cmd_IPsAll_Click);
            // 
            // button_cmd_IPs
            // 
            this.button_cmd_IPs.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(83)))), ((int)(((byte)(172)))), ((int)(((byte)(214)))));
            this.button_cmd_IPs.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button_cmd_IPs.BackgroundImage")));
            this.button_cmd_IPs.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button_cmd_IPs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cmd_IPs.Location = new System.Drawing.Point(318, 7);
            this.button_cmd_IPs.Name = "button_cmd_IPs";
            this.button_cmd_IPs.Size = new System.Drawing.Size(48, 34);
            this.button_cmd_IPs.TabIndex = 6;
            this.button_cmd_IPs.UseVisualStyleBackColor = false;
            this.button_cmd_IPs.Click += new System.EventHandler(this.button_cmd_IPs_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(51, 47);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(415, 398);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.GhostWhite;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(51, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 35);
            this.button1.TabIndex = 0;
            this.button1.Text = "Sprawdź";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonNetworkCheck_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 502);
            this.ControlBox = false;
            this.Controls.Add(this.panelContent);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.TopBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StartForm";
            this.ShowIcon = false;
            this.Text = "mainApp";
            this.TopBar.ResumeLayout(false);
            this.TopBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogo)).EndInit();
            this.panelContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel TopBar;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Button buttonMinimize;
        private System.Windows.Forms.PictureBox pictureBoxLogo;
        private System.Windows.Forms.Label labelTitle;
        public System.Windows.Forms.Panel panelContent;
        public System.Windows.Forms.Button button1;
        public System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        public System.Windows.Forms.Button button_cmd_IPs;
        public System.Windows.Forms.Button button_cmd_IPsAll;
        public System.Windows.Forms.Button button_Languages;
    }
}

