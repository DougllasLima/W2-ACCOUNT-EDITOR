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
    public partial class CriarConta : Form
    {
        public CriarConta()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[7800];

            string logintxt = Login.Text;
            string senhatxt = Senha.Text;

            Byte[] login = Encoding.Default.GetBytes(logintxt);
            Byte[] senha = Encoding.Default.GetBytes(senhatxt);
            Byte[] senha2 = new byte[] { 255, 255, 255, 255, 255, 255 };

            if (login.Length < 4 || login.Length >= 16)
            {
                Log.Text = "Login deve ter 4~15 caracteres";
                return;
            }

            if (Functions.CheckSpecialCaracters(Login.Text))
            {
                Log.Text = "Login  não deve ter caracteres especiais";
                return;
            }
            for (int i = 0; i < login.Length; i++)
                data[i] = login[i];
            if (senha.Length < 4 || senha.Length >= 12)
            {
                Log.Text = "Senha deve ter 4~12 caracteres";
                return;
            }
            if (Functions.CheckSpecialCaracters(Senha.Text))
            {
                Log.Text = "Senha  não deve ter caracteres especiais";
                return;
            }
            for (int i = 0; i < senha.Length; i++)
                data[i + 16] = senha[i];

            for (int i = 0; i < senha2.Length; i++)
                data[i + 202] = senha2[i];


            string dir = "./account/etc";
            var isAlpha = char.IsLetter(Login.Text[0]);
            if (isAlpha)
                dir = "./account/" + Login.Text[0].ToString();

            bool folderExists = Directory.Exists(dir);
            if (!folderExists)
                Directory.CreateDirectory(dir);

            dir = dir + "/" + Login.Text;
            File.WriteAllBytes(dir, data);

            Log.Text = "Conta criada com Sucesso!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login.Text = "";
            Senha.Text = "";
            Log.Text = "";
        }
    }
}
