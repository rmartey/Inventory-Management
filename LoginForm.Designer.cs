namespace Inventory_Management
{
    partial class LoginForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.ClearTxt = new System.Windows.Forms.Label();
            this.checkBoxPass = new System.Windows.Forms.CheckBox();
            this.signInButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.PassText = new System.Windows.Forms.TextBox();
            this.EmailText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.ClearTxt);
            this.panel1.Controls.Add(this.checkBoxPass);
            this.panel1.Controls.Add(this.signInButton);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.PassText);
            this.panel1.Controls.Add(this.EmailText);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(45, 98);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.panel1.Size = new System.Drawing.Size(368, 372);
            this.panel1.TabIndex = 0;
            // 
            // ClearTxt
            // 
            this.ClearTxt.AutoSize = true;
            this.ClearTxt.ForeColor = System.Drawing.Color.Red;
            this.ClearTxt.Location = new System.Drawing.Point(33, 263);
            this.ClearTxt.Name = "ClearTxt";
            this.ClearTxt.Size = new System.Drawing.Size(31, 13);
            this.ClearTxt.TabIndex = 8;
            this.ClearTxt.Text = "Clear";
            this.ClearTxt.Click += new System.EventHandler(this.ClearTxt_Click);
            // 
            // checkBoxPass
            // 
            this.checkBoxPass.AutoSize = true;
            this.checkBoxPass.Location = new System.Drawing.Point(251, 263);
            this.checkBoxPass.Name = "checkBoxPass";
            this.checkBoxPass.Size = new System.Drawing.Size(101, 17);
            this.checkBoxPass.TabIndex = 7;
            this.checkBoxPass.Text = "Show password";
            this.checkBoxPass.UseVisualStyleBackColor = true;
            this.checkBoxPass.CheckedChanged += new System.EventHandler(this.checkBoxPass_CheckedChanged);
            // 
            // signInButton
            // 
            this.signInButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.signInButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(84)))), ((int)(((byte)(100)))), ((int)(((byte)(169)))));
            this.signInButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.signInButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.signInButton.Font = new System.Drawing.Font("MV Boli", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signInButton.ForeColor = System.Drawing.Color.Snow;
            this.signInButton.Location = new System.Drawing.Point(23, 311);
            this.signInButton.Name = "signInButton";
            this.signInButton.Size = new System.Drawing.Size(329, 40);
            this.signInButton.TabIndex = 6;
            this.signInButton.Text = "Sign In";
            this.signInButton.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(20, 187);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 21);
            this.label4.TabIndex = 5;
            this.label4.Text = "Password";
            // 
            // PassText
            // 
            this.PassText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PassText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PassText.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PassText.Location = new System.Drawing.Point(23, 214);
            this.PassText.Name = "PassText";
            this.PassText.Size = new System.Drawing.Size(329, 34);
            this.PassText.TabIndex = 4;
            this.PassText.UseSystemPasswordChar = true;
            // 
            // EmailText
            // 
            this.EmailText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailText.Font = new System.Drawing.Font("MV Boli", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailText.Location = new System.Drawing.Point(23, 129);
            this.EmailText.Name = "EmailText";
            this.EmailText.Size = new System.Drawing.Size(329, 34);
            this.EmailText.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("MV Boli", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(19, 105);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("MV Boli", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Welcome back, please enter your details";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Cooper Black", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(20, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(272, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome back";
            // 
            // LoginForm
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(461, 571);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button signInButton;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox PassText;
        private System.Windows.Forms.TextBox EmailText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBoxPass;
        private System.Windows.Forms.Label ClearTxt;
    }
}

