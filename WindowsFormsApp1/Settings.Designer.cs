
namespace WindowsFormsApp1
{
    partial class Settings
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
            this.change_email = new System.Windows.Forms.Button();
            this.change_password = new System.Windows.Forms.Button();
            this.change_username = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // change_email
            // 
            this.change_email.Location = new System.Drawing.Point(141, 192);
            this.change_email.Name = "change_email";
            this.change_email.Size = new System.Drawing.Size(323, 66);
            this.change_email.TabIndex = 4;
            this.change_email.Text = "Change Email";
            this.change_email.UseVisualStyleBackColor = true;
            this.change_email.Click += new System.EventHandler(this.change_email_Click);
            // 
            // change_password
            // 
            this.change_password.Location = new System.Drawing.Point(141, 315);
            this.change_password.Name = "change_password";
            this.change_password.Size = new System.Drawing.Size(323, 66);
            this.change_password.TabIndex = 5;
            this.change_password.Text = "Change Password";
            this.change_password.UseVisualStyleBackColor = true;
            this.change_password.Click += new System.EventHandler(this.change_password_Click);
            // 
            // change_username
            // 
            this.change_username.Location = new System.Drawing.Point(141, 65);
            this.change_username.Name = "change_username";
            this.change_username.Size = new System.Drawing.Size(323, 66);
            this.change_username.TabIndex = 6;
            this.change_username.Text = "Change Username";
            this.change_username.UseVisualStyleBackColor = true;
            this.change_username.Click += new System.EventHandler(this.change_username_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 438);
            this.Controls.Add(this.change_username);
            this.Controls.Add(this.change_password);
            this.Controls.Add(this.change_email);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button change_email;
        private System.Windows.Forms.Button change_password;
        private System.Windows.Forms.Button change_username;
    }
}