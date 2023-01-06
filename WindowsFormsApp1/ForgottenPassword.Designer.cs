
namespace WindowsFormsApp1
{
    partial class ForgottenPassword
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.reset_password = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(245, 150);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(276, 22);
            this.textBox1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(170, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Email:";
            // 
            // reset_password
            // 
            this.reset_password.Location = new System.Drawing.Point(254, 222);
            this.reset_password.Name = "reset_password";
            this.reset_password.Size = new System.Drawing.Size(203, 53);
            this.reset_password.TabIndex = 2;
            this.reset_password.Text = "Reset Password";
            this.reset_password.UseVisualStyleBackColor = true;
            this.reset_password.Click += new System.EventHandler(this.reset_password_Click);
            // 
            // ForgottenPassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 396);
            this.Controls.Add(this.reset_password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Name = "ForgottenPassword";
            this.Text = "ForgottenPassword";
            this.Load += new System.EventHandler(this.ForgottenPassword_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button reset_password;
    }
}