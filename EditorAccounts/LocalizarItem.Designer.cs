namespace EditorAccounts
{
    partial class LocalizarItem
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LocalizarItem));
            this.button1 = new System.Windows.Forms.Button();
            this.Localizar = new System.Windows.Forms.Button();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.lbContas = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(13, 397);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(274, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Visualizar dados da conta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Localizar
            // 
            this.Localizar.Location = new System.Drawing.Point(212, 26);
            this.Localizar.Name = "Localizar";
            this.Localizar.Size = new System.Drawing.Size(75, 23);
            this.Localizar.TabIndex = 6;
            this.Localizar.Text = "Localizar";
            this.Localizar.UseVisualStyleBackColor = true;
            this.Localizar.Click += new System.EventHandler(this.Localizar_Click);
            // 
            // txtLogin
            // 
            this.txtLogin.Location = new System.Drawing.Point(49, 28);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(157, 20);
            this.txtLogin.TabIndex = 5;
            // 
            // lbContas
            // 
            this.lbContas.FormattingEnabled = true;
            this.lbContas.Location = new System.Drawing.Point(12, 68);
            this.lbContas.Name = "lbContas";
            this.lbContas.Size = new System.Drawing.Size(275, 316);
            this.lbContas.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Index :";
            // 
            // LocalizarItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(299, 431);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Localizar);
            this.Controls.Add(this.txtLogin);
            this.Controls.Add(this.lbContas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LocalizarItem";
            this.Text = "W2 - Localizar Item";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button Localizar;
        public System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.ListBox lbContas;
        private System.Windows.Forms.Label label1;
    }
}