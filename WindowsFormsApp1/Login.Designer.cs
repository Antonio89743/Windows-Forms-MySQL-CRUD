
namespace WindowsFormsApp1
{
    partial class Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.log_in = new System.Windows.Forms.Button();
            this.register_button = new System.Windows.Forms.Button();
            this.show_password = new System.Windows.Forms.Button();
            this.remember_me = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(332, 161);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(192, 22);
            this.username.TabIndex = 0;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(332, 259);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(192, 22);
            this.password.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 161);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username or Email: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 264);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "Password:";
            // 
            // log_in
            // 
            this.log_in.Location = new System.Drawing.Point(204, 404);
            this.log_in.Name = "log_in";
            this.log_in.Size = new System.Drawing.Size(109, 44);
            this.log_in.TabIndex = 4;
            this.log_in.Text = "Log In";
            this.log_in.UseVisualStyleBackColor = true;
            this.log_in.Click += new System.EventHandler(this.log_in_Click);
            // 
            // register_button
            // 
            this.register_button.Location = new System.Drawing.Point(415, 403);
            this.register_button.Name = "register_button";
            this.register_button.Size = new System.Drawing.Size(109, 45);
            this.register_button.TabIndex = 5;
            this.register_button.Text = "Register";
            this.register_button.UseVisualStyleBackColor = true;
            this.register_button.Click += new System.EventHandler(this.register_button_Click);
            // 
            // show_password
            // 
            this.show_password.Location = new System.Drawing.Point(586, 250);
            this.show_password.Name = "show_password";
            this.show_password.Size = new System.Drawing.Size(75, 31);
            this.show_password.TabIndex = 6;
            this.show_password.Text = "Show";
            this.show_password.UseVisualStyleBackColor = true;
            this.show_password.MouseEnter += new System.EventHandler(this.show_password_MouseEnter);
            this.show_password.MouseLeave += new System.EventHandler(this.show_password_MouseLeave);
            // 
            // remember_me
            // 
            this.remember_me.AutoSize = true;
            this.remember_me.Location = new System.Drawing.Point(204, 340);
            this.remember_me.Name = "remember_me";
            this.remember_me.Size = new System.Drawing.Size(122, 21);
            this.remember_me.TabIndex = 7;
            this.remember_me.Text = "Remember Me";
            this.remember_me.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(399, 340);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(142, 17);
            this.linkLabel1.TabIndex = 8;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Forgotten Password?";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(765, 571);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.remember_me);
            this.Controls.Add(this.show_password);
            this.Controls.Add(this.register_button);
            this.Controls.Add(this.log_in);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(783, 618);
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button log_in;
        private System.Windows.Forms.Button register_button;
        private System.Windows.Forms.Button show_password;
        private System.Windows.Forms.CheckBox remember_me;
        private System.Windows.Forms.LinkLabel linkLabel1;
    }
}

