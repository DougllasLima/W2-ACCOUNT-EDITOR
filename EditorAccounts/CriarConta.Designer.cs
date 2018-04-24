namespace EditorAccounts
{
    partial class CriarConta
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CriarConta));
            this.Log = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.Login = new System.Windows.Forms.TextBox();
            this.Senha = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Log
            // 
            this.Log.AutoSize = true;
            this.Log.Location = new System.Drawing.Point(16, 73);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(0, 13);
            this.Log.TabIndex = 13;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(16, 92);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 32);
            this.button2.TabIndex = 3;
            this.button2.Text = "Limpar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Login
            // 
            this.Login.Location = new System.Drawing.Point(60, 12);
            this.Login.Name = "Login";
            this.Login.Size = new System.Drawing.Size(146, 20);
            this.Login.TabIndex = 0;
            // 
            // Senha
            // 
            this.Senha.Location = new System.Drawing.Point(60, 46);
            this.Senha.Name = "Senha";
            this.Senha.PasswordChar = '*';
            this.Senha.Size = new System.Drawing.Size(146, 20);
            this.Senha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Senha";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Login:";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(131, 92);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 32);
            this.button1.TabIndex = 2;
            this.button1.Text = "Confirmar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CriarConta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(220, 131);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Login);
            this.Controls.Add(this.Senha);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CriarConta";
            this.Text = "W2 - Criador de Contas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Log;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox Login;
        private System.Windows.Forms.TextBox Senha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}