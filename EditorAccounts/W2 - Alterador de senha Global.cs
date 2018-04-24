using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorAccounts
{
    public partial class W2___Alterador_de_senha_Global : Form
    {
        public W2___Alterador_de_senha_Global()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string senhatxt = txtSenha.Text;
                Byte[] senha = Encoding.Default.GetBytes(senhatxt);

                if (Functions.CheckSpecialCaracters(txtSenha.Text))
                {
                    Log.Text = "Senha  não deve ter caracteres especiais";
                    return;
                }

                if (senha.Length < 4 || senha.Length >= 12)
                {
                    Log.Text = "Senha deve ter 4~12 caracteres";
                    return;
                }

                for (int i = 0; i < External.g_pContas.Count(); i++)
                    {
                        var pass = External.g_pContas[i];

                        pass.Info.AccountPass = txtSenha.Text;

                        Functions.SaveAccount(pass);
                    }

                    Log.Text = "Senhas alteradas com sucesso!";
                }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
