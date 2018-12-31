namespace SalesApp.Pages
{
    partial class LoginPage
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
            this.textBoxX1 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.textBoxX2 = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.btnLogin = new DevComponents.DotNetBar.ButtonX();
            this.pHeader = new System.Windows.Forms.Panel();
            this.lnkForgetPassword = new System.Windows.Forms.LinkLabel();
            this.line1 = new DevComponents.DotNetBar.Controls.Line();
            this.line2 = new DevComponents.DotNetBar.Controls.Line();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxX1
            // 
            this.textBoxX1.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX1.Border.BorderBottomColor = System.Drawing.SystemColors.ActiveCaption;
            this.textBoxX1.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.textBoxX1.Border.Class = "TextBoxBorder";
            this.textBoxX1.Border.CornerDiameter = 10;
            this.textBoxX1.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.textBoxX1.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX1.Font = new System.Drawing.Font("IRANSans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxX1.ForeColor = System.Drawing.Color.Black;
            this.textBoxX1.Location = new System.Drawing.Point(30, 154);
            this.textBoxX1.Name = "textBoxX1";
            this.textBoxX1.PreventEnterBeep = true;
            this.textBoxX1.Size = new System.Drawing.Size(334, 58);
            this.textBoxX1.TabIndex = 2;
            this.textBoxX1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxX1.WatermarkText = "نام کاربری";
            // 
            // textBoxX2
            // 
            this.textBoxX2.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.textBoxX2.Border.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.textBoxX2.Border.Class = "TextBoxBorder";
            this.textBoxX2.Border.CornerDiameter = 10;
            this.textBoxX2.Border.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.textBoxX2.DisabledBackColor = System.Drawing.Color.White;
            this.textBoxX2.Font = new System.Drawing.Font("IRANSans", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.textBoxX2.ForeColor = System.Drawing.Color.Black;
            this.textBoxX2.Location = new System.Drawing.Point(30, 223);
            this.textBoxX2.Name = "textBoxX2";
            this.textBoxX2.PreventEnterBeep = true;
            this.textBoxX2.Size = new System.Drawing.Size(334, 58);
            this.textBoxX2.TabIndex = 3;
            this.textBoxX2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBoxX2.UseSystemPasswordChar = true;
            this.textBoxX2.WatermarkText = "کلمه عبور";
            // 
            // btnLogin
            // 
            this.btnLogin.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogin.ColorTable = DevComponents.DotNetBar.eButtonColor.Office2007WithBackground;
            this.btnLogin.Font = new System.Drawing.Font("IRANSans", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnLogin.ImagePosition = DevComponents.DotNetBar.eImagePosition.Right;
            this.btnLogin.ImageTextSpacing = 120;
            this.btnLogin.Location = new System.Drawing.Point(30, 366);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Shape = new DevComponents.DotNetBar.RoundRectangleShapeDescriptor(10);
            this.btnLogin.Size = new System.Drawing.Size(334, 54);
            this.btnLogin.Style = DevComponents.DotNetBar.eDotNetBarStyle.Windows7;
            this.btnLogin.SymbolSize = 30F;
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = " ورود               ";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // pHeader
            // 
            this.pHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.pHeader.Controls.Add(this.pictureBox1);
            this.pHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pHeader.ForeColor = System.Drawing.Color.Black;
            this.pHeader.Location = new System.Drawing.Point(0, 0);
            this.pHeader.Name = "pHeader";
            this.pHeader.Size = new System.Drawing.Size(396, 120);
            this.pHeader.TabIndex = 6;
            // 
            // lnkForgetPassword
            // 
            this.lnkForgetPassword.AutoSize = true;
            this.lnkForgetPassword.Font = new System.Drawing.Font("IRANSans", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.lnkForgetPassword.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
            this.lnkForgetPassword.Location = new System.Drawing.Point(113, 441);
            this.lnkForgetPassword.Name = "lnkForgetPassword";
            this.lnkForgetPassword.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lnkForgetPassword.Size = new System.Drawing.Size(169, 24);
            this.lnkForgetPassword.TabIndex = 7;
            this.lnkForgetPassword.TabStop = true;
            this.lnkForgetPassword.Text = "رمز عبور خود را فراموش کردم!";
            // 
            // line1
            // 
            this.line1.AutoSize = true;
            this.line1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.line1.LineAlignment = DevComponents.DotNetBar.eItemAlignment.Near;
            this.line1.Location = new System.Drawing.Point(395, 100);
            this.line1.Name = "line1";
            this.line1.Size = new System.Drawing.Size(2, 397);
            this.line1.TabIndex = 8;
            this.line1.Thickness = 2;
            this.line1.VerticalLine = true;
            // 
            // line2
            // 
            this.line2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(133)))), ((int)(((byte)(227)))), ((int)(((byte)(252)))));
            this.line2.LineAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.line2.Location = new System.Drawing.Point(0, 497);
            this.line2.Name = "line2";
            this.line2.Size = new System.Drawing.Size(400, 2);
            this.line2.TabIndex = 9;
            this.line2.Thickness = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SalesApp.Properties.Resources.LoginIconPng;
            this.pictureBox1.Location = new System.Drawing.Point(136, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(128, 119);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoginPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(396, 498);
            this.ControlBox = false;
            this.Controls.Add(this.line2);
            this.Controls.Add(this.line1);
            this.Controls.Add(this.lnkForgetPassword);
            this.Controls.Add(this.pHeader);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.textBoxX2);
            this.Controls.Add(this.textBoxX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("IRANSans", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginPage";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.LoginPage_Load);
            this.pHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX1;
        private DevComponents.DotNetBar.Controls.TextBoxX textBoxX2;
        private DevComponents.DotNetBar.ButtonX btnLogin;
        private System.Windows.Forms.Panel pHeader;
        private System.Windows.Forms.LinkLabel lnkForgetPassword;
        private DevComponents.DotNetBar.Controls.Line line1;
        private DevComponents.DotNetBar.Controls.Line line2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}