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
    public partial class Form3 : Form
    {
        Form1 Form1;

        public Form3(Form1 fmr)
        {
            InitializeComponent();
            Form1 = fmr;
        }

        private void txtItemIndex_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtItemIndex.Text != "")
                {
                    if (File.Exists("./imagens/" + this.txtItemIndex.Text + ".png"))
                    {
                        this.Icone.Image = Image.FromFile("./imagens/" + this.txtItemIndex.Text + ".png");
                    }

                    this.labelName.Text = External.g_pItemList.item[Convert.ToInt32(this.txtItemIndex.Text)].Name;
                    this.txtMesh.Text = External.g_pItemList.item[Convert.ToInt16(this.txtItemIndex.Text)].IndexMesh.ToString();
                    this.txtPreco.Text = External.g_pItemList.item[Convert.ToInt16(this.txtItemIndex.Text)].Price.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void TextChanged2(object sender, EventArgs e)
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();

            #region Item Effect
            dict.Add("2", "EF_DAMAGE");
            dict.Add("3", "EF_AC");
            dict.Add("4", "EF_HP");
            dict.Add("5", "EF_MP");
            dict.Add("6", "EF_EXP");
            dict.Add("7", "EF_STR");
            dict.Add("8", "EF_INT");
            dict.Add("9", "EF_DEX");
            dict.Add("10", "EF_CON");
            dict.Add("11", "EF_SPECIAL1");
            dict.Add("12", "EF_SPECIAL2");
            dict.Add("13", "EF_SPECIAL3");
            dict.Add("14", "EF_SPECIAL4");
            dict.Add("15", "EF_SCORE14");
            dict.Add("16", "EF_SCORE15");
            dict.Add("17", "EF_POS");
            dict.Add("18", "EF_CLASS");
            dict.Add("19", "EF_R1SIDC");
            dict.Add("20", "EF_R2SIDC");
            dict.Add("21", "EF_WTYPE");
            dict.Add("22", "EF_REQ_STR");
            dict.Add("23", "EF_REQ_INT");
            dict.Add("24", "EF_REQ_DEX");
            dict.Add("25", "EF_REQ_CON");
            dict.Add("26", "EF_ATTSPEED");
            dict.Add("27", "EF_RANGE");
            dict.Add("29", "EF_RUNSPEED");
            dict.Add("30", "EF_SPELL");
            dict.Add("31", "EF_DURATION");
            dict.Add("32", "EF_PARM2");
            dict.Add("33", "EF_GRID");
            dict.Add("34", "EF_GROUND");
            dict.Add("35", "EF_CLAN");
            dict.Add("36", "EF_HWORDCOIN");
            dict.Add("37", "EF_LWORDCOIN");
            dict.Add("38", "EF_VOLATILE");
            dict.Add("39", "EF_KEYID");
            dict.Add("40", "EF_PARRY");
            dict.Add("41", "EF_HITRATE");
            dict.Add("42", "EF_CRITICAL");
            dict.Add("43", "EF_SANC");
            dict.Add("44", "EF_SAVEMANA");//1 -> 99%
            dict.Add("45", "EF_HPADD");//1 -> 101%   MAX_HP 
            dict.Add("46", "EF_MPADD"); //1-> 101 % MAX_MP
            dict.Add("47", "EF_REGENHP");
            dict.Add("48", "EF_REGENMP");
            dict.Add("49", "EF_RESIST1");
            dict.Add("50", "EF_RESIST2");
            dict.Add("51", "EF_RESIST3");
            dict.Add("52", "EF_RESIST4");
            dict.Add("53", "EF_ACADD");
            dict.Add("54", "EF_RESISTALL");
            dict.Add("55", "EF_BONUS");
            dict.Add("56", "EF_HWORDGUILD");// Ataque PvP
            dict.Add("57", "EF_LWORDGUILD");// Defesa PvP
            dict.Add("58", "EF_QUEST");
            dict.Add("59", "EF_UNIQUE");
            dict.Add("60", "EF_MAGIC");
            dict.Add("61", "EF_AMOUNT");
            dict.Add("62", "EF_HWORDINDEX");
            dict.Add("63", "EF_LWORDINDEX");
            dict.Add("64", "EF_INIT1");
            dict.Add("65", "EF_INIT2");
            dict.Add("66", "EF_INIT3");
            dict.Add("67", "EF_DAMAGEADD");
            dict.Add("68", "EF_MAGICADD");
            dict.Add("69", "EF_HPADD2");
            dict.Add("70", "EF_MPADD2");
            dict.Add("71", "EF_CRITICAL2");
            dict.Add("72", "EF_ACADD2");
            dict.Add("73", "EF_DAMAGE2");
            dict.Add("74", "EF_SPECIALALL");
            dict.Add("75", "EF_CURKILL");// not used
            dict.Add("76", "EF_LTOTKILL");// not used
            dict.Add("77", "EF_HTOTKILL");// not used
            dict.Add("78", "EF_INCUBATE");
            dict.Add("79", "EF_MOUNTLIFE");
            dict.Add("80", "EF_MOUNTHP");
            dict.Add("81", "EF_MOUNTSANC");
            dict.Add("82", "EF_MOUNTFEED");
            dict.Add("83", "EF_MOUNTKILL");
            dict.Add("84", "EF_INCUDELAY");
            dict.Add("85", "EF_SUBGUILD");
            dict.Add("87", "EF_ITEMLEVEL");
            dict.Add("91", "EF_DONATE");
            dict.Add("100", "EF_GRADE0");// A    
            dict.Add("101", "EF_GRADE1");// B
            dict.Add("102", "EF_GRADE2");// C
            dict.Add("103", "EF_GRADE3");// D
            dict.Add("104", "EF_GRADE4");// E
            dict.Add("105", "EF_GRADE5");// E Arch
            dict.Add("106", "EF_WDAY");
            dict.Add("107", "EF_HOUR");
            dict.Add("108", "EF_MIN");
            dict.Add("109", "EF_YEAR");
            dict.Add("110", "EF_WMONTH");
            dict.Add("112", "EF_MOBTYPE");
            dict.Add("113", "EF_ITEMTYPE");
            dict.Add("126", "EF_NOSANC");
            dict.Add("127", "EF_NOTRADE");
            #endregion

            if (dict.ContainsKey(txtEF1.Text))
            {
                labelEF1.Text = dict[txtEF1.Text];
            }
            else
            {
                labelEF1.Text = "";
            }

            if (dict.ContainsKey(txtEF2.Text))
            {
                labelEF2.Text = dict[txtEF2.Text];
            }
            else
            {
                labelEF2.Text = "";
            }

            if (dict.ContainsKey(txtEF3.Text))
            {
                labelEF3.Text = dict[txtEF3.Text];
            }
            else
            {
                labelEF3.Text = "";
            }
        }

        // Salvar Item Button
        private void button2_Click(object sender, EventArgs e)
        {
            External.CurrentChar = Form1.Chars.SelectedIndex;

            try
            {
                int index = Convert.ToInt32(txtSlot.Text);

                PictureBox pic = Form1.Controls.Find(String.Format("ID{0}", index), true).FirstOrDefault() as PictureBox;

                pic.Image = Image.FromFile("./imagens/" + this.txtItemIndex.Text + ".png");

                External.g_pAcccount.Char[External.CurrentChar].Equip[index].sIndex = Convert.ToInt16(txtItemIndex.Text);
                External.g_pAcccount.Char[External.CurrentChar].Equip[index].sEffect[0].cEfeito = Convert.ToByte(txtEF1.Text);
                External.g_pAcccount.Char[External.CurrentChar].Equip[index].sEffect[0].cValue = Convert.ToByte(txtEFv1.Text);
                External.g_pAcccount.Char[External.CurrentChar].Equip[index].sEffect[1].cEfeito = Convert.ToByte(txtEF2.Text);
                External.g_pAcccount.Char[External.CurrentChar].Equip[index].sEffect[1].cValue = Convert.ToByte(txtEFv2.Text);
                External.g_pAcccount.Char[External.CurrentChar].Equip[index].sEffect[2].cEfeito = Convert.ToByte(txtEF3.Text);
                External.g_pAcccount.Char[External.CurrentChar].Equip[index].sEffect[2].cValue = Convert.ToByte(txtEFv3.Text);
                Functions.SaveAccount(External.g_pAcccount);
                Form1.UpdateInfo();
                this.Close();

                MessageBox.Show("Selecione o personagem novamente para atualizar os dados!");
                Form1.Chars.Text = "Selecione...";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
