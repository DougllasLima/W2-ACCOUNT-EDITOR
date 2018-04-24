using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace EditorAccounts
{
    public partial class LocalizarItem : Form
    {
        Form1 Form1;

        public LocalizarItem(Form1 fmr)
        {
            InitializeComponent();
            Form1 = fmr;
        }

        private void Localizar_Click(object sender, EventArgs e)
        {
            lbContas.Items.Clear();
            External.ContasLocalizadas.Clear();

            if (txtLogin.Text != "")
            {
                int encontrados = ClassLocalizarItem2.LocalizarItens(Convert.ToInt32(txtLogin.Text));
            }
            else
            {
                MessageBox.Show("Digite o index do item que deseja localizar!");
                return;
            }

            int index = Convert.ToInt32(txtLogin.Text);
            int count = 0;

            foreach (Structs.STRUCT_ACCOUNTFILE mob in External.ContasLocalizadas)
            {
                lbContas.Items.Add(mob.Info.AccountName);
            }

            for (int i = 0; i < 128; i++)
            {
                if (lbContas.Items.Count > 0)
                {
                    if (External.ContasLocalizadas[lbContas.Items.Count - 1].Cargo[i].sIndex == index)
                    {
                        count++;
                    }
                }
            }

            MessageBox.Show(string.Format("Foram localizados {0} itens!", count));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1.dataGridView1.Rows.Clear();
            Form1.dataGridView2.Rows.Clear();
            Form1.txtLogin.Text = "";
            Form1.txtSenha.Text = "";
            Form1.txtNum.Text = "";
            Form1.Chars.Items.Clear();

            int index = lbContas.SelectedIndex;

            for (int i = 0; i < 4; i++)
            {
                if (string.IsNullOrEmpty(External.ContasLocalizadas[index].Char[i].name))
                    continue;

                Form1.Chars.Items.Add(External.ContasLocalizadas[index].Char[i].name);
            }

            External.g_pAcccount = External.ContasLocalizadas[index];

            Form1.Chars.Text = "Selecione...";

            Functions.ReadItemList();

            Form1.txtLogin.Text = External.g_pAcccount.Info.AccountName.ToString();

            Form1.txtSenha.Text = External.g_pAcccount.Info.AccountPass.ToString();

            for (int i = 0; i < External.g_pAcccount.Info.NumericToken.Count(); i++)
            {
                if (!string.IsNullOrEmpty(External.g_pAcccount.Info.NumericToken[i].ToString()))
                {
                    Form1.txtNum.Text += External.g_pAcccount.Info.NumericToken[i].ToString() + " ";
                }
            }

            string CurImg = @"./imagens/0.png";

            for (int i = 0; i < 128; i++)
            {
                int item = External.g_pAcccount.Cargo[i].sIndex;

                string szFile = "./imagens/" + External.g_pAcccount.Cargo[i].sIndex + ".png";
                if (!File.Exists(szFile))
                {
                    szFile = "./imagens/" + External.g_pAcccount.Cargo[i].sIndex + ".jpg";
                    if (!File.Exists(szFile))
                        szFile = CurImg;
                }

                var Imagem = Image.FromFile(szFile);
                Form1.dataGridView2.Rows.Add(i, Imagem, External.g_pAcccount.Cargo[i].sIndex, External.g_pAcccount.Cargo[i].sEffect[0].cEfeito, External.g_pAcccount.Cargo[i].sEffect[0].cValue, External.g_pAcccount.Cargo[i].sEffect[1].cEfeito, External.g_pAcccount.Cargo[i].sEffect[1].cValue, External.g_pAcccount.Cargo[i].sEffect[2].cEfeito, External.g_pAcccount.Cargo[i].sEffect[2].cValue);
            }

            this.Close();
        }
    }
}

