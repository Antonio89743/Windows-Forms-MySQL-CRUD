
namespace WindowsFormsApp1
{
    partial class register_form
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
            this.register = new System.Windows.Forms.Button();
            this.username = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.return_to_login = new System.Windows.Forms.Button();
            this.confirm_password = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.show = new System.Windows.Forms.Button();
            this.email = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // register
            // 
            this.register.Location = new System.Drawing.Point(254, 444);
            this.register.Name = "register";
            this.register.Size = new System.Drawing.Size(128, 58);
            this.register.TabIndex = 0;
            this.register.Text = "Register";
            this.register.UseVisualStyleBackColor = true;
            this.register.Click += new System.EventHandler(this.register_Click);
            // 
            // username
            // 
            this.username.Location = new System.Drawing.Point(254, 136);
            this.username.Name = "username";
            this.username.Size = new System.Drawing.Size(263, 22);
            this.username.TabIndex = 1;
            // 
            // password
            // 
            this.password.Location = new System.Drawing.Point(254, 208);
            this.password.Name = "password";
            this.password.Size = new System.Drawing.Size(263, 22);
            this.password.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(114, 136);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Username: ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(114, 208);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // return_to_login
            // 
            this.return_to_login.Location = new System.Drawing.Point(13, 13);
            this.return_to_login.Name = "return_to_login";
            this.return_to_login.Size = new System.Drawing.Size(140, 38);
            this.return_to_login.TabIndex = 5;
            this.return_to_login.Text = "Return To Login";
            this.return_to_login.UseVisualStyleBackColor = true;
            this.return_to_login.Click += new System.EventHandler(this.return_to_login_Click);
            // 
            // confirm_password
            // 
            this.confirm_password.Location = new System.Drawing.Point(254, 279);
            this.confirm_password.Name = "confirm_password";
            this.confirm_password.Size = new System.Drawing.Size(263, 22);
            this.confirm_password.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(114, 279);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Confirm Password:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // show
            // 
            this.show.Location = new System.Drawing.Point(548, 239);
            this.show.Name = "show";
            this.show.Size = new System.Drawing.Size(75, 36);
            this.show.TabIndex = 8;
            this.show.Text = "Show";
            this.show.UseVisualStyleBackColor = true;
            this.show.MouseEnter += new System.EventHandler(this.show_MouseEnter);
            this.show.MouseLeave += new System.EventHandler(this.show_MouseLeave);
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(254, 346);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(263, 22);
            this.email.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(114, 349);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Email:";
            // 
            // register_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 534);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.email);
            this.Controls.Add(this.show);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.confirm_password);
            this.Controls.Add(this.return_to_login);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password);
            this.Controls.Add(this.username);
            this.Controls.Add(this.register);
            this.Name = "register_form";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.register_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button register;
        private System.Windows.Forms.TextBox username;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button return_to_login;
        private System.Windows.Forms.TextBox confirm_password;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button show;
        private System.Windows.Forms.TextBox email;
        private System.Windows.Forms.Label label4;
    }
}