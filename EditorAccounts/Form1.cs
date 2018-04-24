using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Threading.Tasks;

namespace EditorAccounts
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.dataGridView1.Columns[1].HeaderText = "";
            this.dataGridView2.Columns[1].HeaderText = "";
            this.Chars.Text = "Procurar...";
            var pos = this.PointToScreen(labelInventario.Location);
            pos = pictureBox1.PointToClient(pos);
            labelInventario.Parent = pictureBox1;
            labelInventario.Location = pos;
            labelInventario.BackColor = Color.Transparent;
            this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView2.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView2.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView2.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView2.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView2.AllowUserToResizeRows = false;

            //ReadContas();
        }

        //private void ReadContas()
        //{
        //    ClassLocalizador.ReadAccounts();
        //}

        public void UpdateInfo()
        {
            Chars.Items.Clear();

            for (int i = 0; i < 4; i++)
            {
                if (string.IsNullOrEmpty(External.g_pAcccount.Char[i].name))
                    continue;

                Chars.Items.Add(External.g_pAcccount.Char[i].name);
            }
        }

        private void Chars_SelectedIndexChanged(object sender, EventArgs e)
        {
            External.CurrentChar = Chars.SelectedIndex;
            Chars.Text = External.g_pAcccount.Char[External.CurrentChar].name.ToString();

            this.dataGridView1.Rows.Clear();

            string CurImg = @"./imagens/0.png";

            #region Informações TextBox

            txtGuild.Text = Convert.ToString(External.g_pAcccount.Char[External.CurrentChar].Guild);

            txtNome.Text = External.g_pAcccount.Char[External.CurrentChar].name;

            txtLevel.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Level.ToString();

            txtExp.Text = External.g_pAcccount.Char[External.CurrentChar].Exp.ToString();

            txtCoin.Text = External.g_pAcccount.Char[External.CurrentChar].Coin.ToString();

            txtVelo.Text = Convert.ToString(External.g_pAcccount.Char[External.CurrentChar].CurrentScore.AttackRun & 15);

            txtPosX.Text = External.g_pAcccount.Char[External.CurrentChar].SPX.ToString();

            txtPosY.Text = External.g_pAcccount.Char[External.CurrentChar].SPY.ToString();

            txtBaseAtk.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Ataque.ToString();

            txtCurrAtk.Text = External.g_pAcccount.Char[External.CurrentChar].CurrentScore.Ataque.ToString();

            txtBaseDef.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Defesa.ToString();

            txtCurrDef.Text = External.g_pAcccount.Char[External.CurrentChar].CurrentScore.Defesa.ToString();

            txtStr.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Str.ToString();

            txtInt.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Int.ToString();

            txtDex.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Dex.ToString();

            txtCon.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Con.ToString();

            txtMaxHP.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.MaxHP.ToString();

            txtMaxMP.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.MaxMP.ToString();

            txtHPatual.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.HP.ToString();

            txtMPatual.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.MP.ToString();

            txtSpe0.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[0].ToString();

            txtSpe1.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[1].ToString();

            txtSpe2.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[2].ToString();

            txtSpe3.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[3].ToString();

            txtSagrado.Text = External.g_pAcccount.Char[External.CurrentChar].Resist[0].ToString();

            txtTrovao.Text = External.g_pAcccount.Char[External.CurrentChar].Resist[1].ToString();

            txtFogo.Text = External.g_pAcccount.Char[External.CurrentChar].Resist[2].ToString();

            txtGelo.Text = External.g_pAcccount.Char[External.CurrentChar].Resist[3].ToString();

            txtChaos.Text = External.g_pAcccount.Char[External.CurrentChar].BaseScore.ChaosRate.ToString();

            txtPontosSta.Text = External.g_pAcccount.Char[External.CurrentChar].ScoreBonus.ToString();

            txtPontosSpe.Text = External.g_pAcccount.Char[External.CurrentChar].SpecialBonus.ToString();

            txtPontosSkill.Text = External.g_pAcccount.Char[External.CurrentChar].SkillBonus.ToString();

            #endregion

            #region Equipamentos
            //Face
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[0].sIndex + ".png"))
                ID0.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[0].sIndex + ".png");
            else
                ID0.Image = Image.FromFile(CurImg);

            // Helm
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[1].sIndex + ".png"))
                ID1.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[1].sIndex + ".png");
            else
                ID1.Image = Image.FromFile(CurImg);

            // Peito
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[2].sIndex + ".png"))
                ID2.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[2].sIndex + ".png");
            else
                ID2.Image = Image.FromFile(CurImg);

            // Calça
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[3].sIndex + ".png"))
                ID3.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[3].sIndex + ".png");
            else
                ID3.Image = Image.FromFile(CurImg);

            // Luva
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[4].sIndex + ".png"))
                ID4.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[4].sIndex + ".png");
            else
                ID4.Image = Image.FromFile(CurImg);

            // Bota
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[5].sIndex + ".png"))
                ID5.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[5].sIndex + ".png");
            else
                ID5.Image = Image.FromFile(CurImg);

            // Arma 1
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[6].sIndex + ".png"))
                ID6.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[6].sIndex + ".png");
            else
                ID6.Image = Image.FromFile(CurImg);

            // Arma 2
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[7].sIndex + ".png"))
                ID7.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[7].sIndex + ".png");
            else
                ID7.Image = Image.FromFile(CurImg);

            // Brinco
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[8].sIndex + ".png"))
                ID8.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[8].sIndex + ".png");
            else
                ID8.Image = Image.FromFile(CurImg);

            // Arcano
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[9].sIndex + ".png"))
                ID9.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[9].sIndex + ".png");
            else
                ID9.Image = Image.FromFile(CurImg);

            // Pedra ABS ( BAIXO BRINCO )
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[10].sIndex + ".png"))
                ID10.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[10].sIndex + ".png");
            else
                ID10.Image = Image.FromFile(CurImg);

            // Pedra ABS ( BAIXO ARCANO )
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[11].sIndex + ".png"))
                ID11.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[11].sIndex + ".png");
            else
                ID11.Image = Image.FromFile(CurImg);

            //
            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[12].sIndex + ".png"))
                ID12.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[12].sIndex + ".png");
            else
                ID12.Image = Image.FromFile(CurImg);

            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[13].sIndex + ".png"))
                ID13.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[13].sIndex + ".png");
            else
                ID13.Image = Image.FromFile(CurImg);

            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[14].sIndex + ".png"))
                ID14.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[14].sIndex + ".png");
            else
                ID14.Image = Image.FromFile(CurImg);

            if (File.Exists("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[15].sIndex + ".png"))
                ID15.Image = Image.FromFile("./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Equip[15].sIndex + ".png");
            else
                ID15.Image = Image.FromFile(CurImg);
            #endregion

            //int size = System.Runtime.InteropServices.Marshal.SizeOf<Structs.STRUCT_ACCOUNTINFO>();

            //MessageBox.Show(size.ToString());

            for (int i = 0; i < 64; i++)
            {
                int item = External.g_pAcccount.Char[External.CurrentChar].Carry[i].sIndex;

                string szFile = "./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Carry[i].sIndex + ".png";
                if (!File.Exists(szFile))
                {
                    szFile = "./imagens/" + External.g_pAcccount.Char[External.CurrentChar].Carry[i].sIndex + ".jpg";
                    if (!File.Exists(szFile))
                        szFile = CurImg;
                }

                var Imagem = Image.FromFile(szFile);
                this.dataGridView1.Rows.Add(i, Imagem, External.g_pAcccount.Char[External.CurrentChar].Carry[i].sIndex, External.g_pAcccount.Char[External.CurrentChar].Carry[i].sEffect[0].cEfeito, External.g_pAcccount.Char[External.CurrentChar].Carry[i].sEffect[0].cValue, External.g_pAcccount.Char[External.CurrentChar].Carry[i].sEffect[1].cEfeito, External.g_pAcccount.Char[External.CurrentChar].Carry[i].sEffect[1].cValue, External.g_pAcccount.Char[External.CurrentChar].Carry[i].sEffect[2].cEfeito, External.g_pAcccount.Char[External.CurrentChar].Carry[i].sEffect[2].cValue);
            }
        }

        private void abrirContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    txtLogin.Text = "";
                    txtSenha.Text = "";
                    txtNum.Text = "";

                    this.dataGridView1.Rows.Clear();
                    this.dataGridView2.Rows.Clear();
                    Functions.ReadItemList();
                    Functions.LoadAccount(openFileDialog1.FileName);
                    UpdateInfo();
                    this.Chars.Text = "Selecione...";

                    txtLogin.Text = External.g_pAcccount.Info.AccountName.ToString();

                    txtSenha.Text = External.g_pAcccount.Info.AccountPass.ToString();

                    for (int i = 0; i < 6; i++)
                    {
                        if (!string.IsNullOrEmpty(External.g_pAcccount.Info.NumericToken[i].ToString()))
                        {
                            txtNum.Text += External.g_pAcccount.Info.NumericToken[i].ToString() + " ";
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
                        this.dataGridView2.Rows.Add(i, Imagem, External.g_pAcccount.Cargo[i].sIndex, External.g_pAcccount.Cargo[i].sEffect[0].cEfeito, External.g_pAcccount.Cargo[i].sEffect[0].cValue, External.g_pAcccount.Cargo[i].sEffect[1].cEfeito, External.g_pAcccount.Cargo[i].sEffect[1].cValue, External.g_pAcccount.Cargo[i].sEffect[2].cEfeito, External.g_pAcccount.Cargo[i].sEffect[2].cValue);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sobre sobre = new Sobre();
            sobre.Show();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if ((e.ColumnIndex == this.dataGridView1.Columns["Imagem"].Index) && e.Value != null)
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                cell.ToolTipText = External.g_pItemList.item[short.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString())].Name;
            }
        }

        private void localizarItensToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LocalizarItem localizarItem = new LocalizarItem(this);
            localizarItem.Show();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Form4 form4 = new Form4(this);
                //MessageBox.Show(row.Cells[0].Value.ToString());

                if (Application.OpenForms.OfType<Form4>().Count() > 0)
                {
                    MessageBox.Show("A janela de informações já está aberta!");
                }
                else
                {
                    form4.Show();
                    form4.txtSlot.Text = row.Cells[0].Value.ToString();
                    form4.txtItemIndex.Text = row.Cells[2].Value.ToString();
                    form4.labelName.Text = External.g_pItemList.item[Convert.ToInt32(row.Cells[2].Value)].Name;

                    if (File.Exists("./imagens/" + form4.txtItemIndex.Text + ".png"))
                    {
                        form4.Icone.Image = Image.FromFile("./imagens/" + form4.txtItemIndex.Text + ".png");
                    }

                    form4.txtEF1.Text = row.Cells[3].Value.ToString();
                    form4.txtEFv1.Text = row.Cells[4].Value.ToString();
                    form4.txtEF2.Text = row.Cells[5].Value.ToString();
                    form4.txtEFv2.Text = row.Cells[6].Value.ToString();
                    form4.txtEF3.Text = row.Cells[7].Value.ToString();
                    form4.txtEFv3.Text = row.Cells[8].Value.ToString();

                    form4.txtMesh.Text = External.g_pItemList.item[Convert.ToInt16(form4.txtItemIndex.Text)].IndexMesh.ToString();

                    form4.txtPreco.Text = External.g_pItemList.item[Convert.ToInt16(form4.txtItemIndex.Text)].Price.ToString();
                }
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView2.SelectedRows)
            {
                Form5 form5 = new Form5(this);

                if (Application.OpenForms.OfType<Form5>().Count() > 0)
                {
                    MessageBox.Show("A janela de informações já está aberta!");
                }
                else
                {
                    form5.Show();
                    form5.txtSlot.Text = row.Cells[0].Value.ToString();
                    form5.txtItemIndex.Text = row.Cells[2].Value.ToString();
                    form5.labelName.Text = External.g_pItemList.item[Convert.ToInt32(row.Cells[2].Value)].Name;

                    if (File.Exists("./imagens/" + form5.txtItemIndex.Text + ".png"))
                    {
                        form5.Icone.Image = Image.FromFile("./imagens/" + form5.txtItemIndex.Text + ".png");
                    }

                    form5.txtEF1.Text = row.Cells[3].Value.ToString();
                    form5.txtEFv1.Text = row.Cells[4].Value.ToString();
                    form5.txtEF2.Text = row.Cells[5].Value.ToString();
                    form5.txtEFv2.Text = row.Cells[6].Value.ToString();
                    form5.txtEF3.Text = row.Cells[7].Value.ToString();
                    form5.txtEFv3.Text = row.Cells[8].Value.ToString();

                    form5.txtMesh.Text = External.g_pItemList.item[Convert.ToInt16(form5.txtItemIndex.Text)].IndexMesh.ToString();

                    form5.txtPreco.Text = External.g_pItemList.item[Convert.ToInt16(form5.txtItemIndex.Text)].Price.ToString();
                }
            }
        }

        //// Botão salvar informações
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        External.CurrentChar = Chars.SelectedIndex;       

        //        #region Informações TextBox

        //        External.g_pAcccount.Char[External.CurrentChar].name = txtNome.Text;

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Level = Convert.ToInt32(txtLevel.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].Exp = Convert.ToInt64(txtExp.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].Coin = Convert.ToInt32(txtCoin.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].SPX = Convert.ToInt16(txtPosX.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].SPY = Convert.ToInt16(txtPosY.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Ataque = Convert.ToInt32(txtBaseAtk.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].CurrentScore.Ataque = Convert.ToInt32(txtCurrAtk.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Defesa = Convert.ToInt32(txtBaseDef.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].CurrentScore.Defesa = Convert.ToInt32(txtCurrDef.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Str = Convert.ToInt16(txtStr.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Int = Convert.ToInt16(txtInt.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Dex = Convert.ToInt16(txtDex.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Con = Convert.ToInt16(txtCon.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.MaxHP = Convert.ToInt32(txtMaxHP.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.MaxMP = Convert.ToInt32(txtMaxMP.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.HP = Convert.ToInt32(txtHPatual.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.MP = Convert.ToInt32(txtMPatual.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[0] = Convert.ToInt16(txtSpe0.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[1] = Convert.ToInt16(txtSpe1.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[2] = Convert.ToInt16(txtSpe2.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[3] = Convert.ToInt16(txtSpe3.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].Resist[0] = Convert.ToByte(txtSagrado.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].Resist[1] = Convert.ToByte(txtTrovao.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].Resist[2] = Convert.ToByte(txtFogo.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].Resist[3] = Convert.ToByte(txtGelo.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].ScoreBonus = Convert.ToInt16(txtPontosSta.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].SpecialBonus = Convert.ToInt16(txtPontosSpe.Text);

        //        External.g_pAcccount.Char[External.CurrentChar].SkillBonus = Convert.ToInt16(txtPontosSkill.Text);

        //        #endregion               

        //        UpdateInfo();

        //        Functions.SaveAccount(External.g_pAcccount);
        //        labelSave.Text = string.Format("Conta {0} salva com sucesso!", External.g_pAcccount.Info.AccountName);

        //        LimpaLabel();
        //    }
        //    catch(Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        //private async Task LimpaLabel()
        //{
        //    await Task.Delay(5000);
        //    labelSave.Text = "";
        //}

        private void ID0_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "0";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[0].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[0].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[0].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[0].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[0].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[0].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[0].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID1_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "1";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[1].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[1].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[1].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[1].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[1].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[1].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[1].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID2_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "2";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[2].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[2].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[2].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[2].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[2].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[2].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[2].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID3_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "3";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[3].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[3].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[3].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[3].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[3].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[3].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[3].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID4_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "4";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[4].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[4].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[4].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[4].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[4].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[4].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[4].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID5_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "5";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[5].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[5].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[5].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[5].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[5].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[5].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[5].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID6_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "6";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[6].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[6].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[6].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[6].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[6].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[6].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[6].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID7_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "7";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[7].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[7].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[7].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[7].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[7].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[7].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[7].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID8_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "8";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[8].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[8].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[8].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[8].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[8].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[8].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[8].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID9_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "9";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[9].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[9].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[9].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[9].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[9].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[9].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[9].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID10_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "10";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[10].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[10].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[10].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[10].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[10].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[10].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[10].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID11_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "11";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[11].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[11].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[11].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[11].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[11].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[11].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[11].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID12_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "12";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[12].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[12].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[12].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[12].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[12].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[12].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[12].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID13_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "13";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[13].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[13].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[13].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[13].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[13].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[13].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[13].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID14_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "14";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[14].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[14].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[14].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[14].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[14].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[14].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[14].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void ID15_Click(object sender, EventArgs e)
        {
            Form3 Form3 = new Form3(this);

            External.CurrentChar = Chars.SelectedIndex;

            if (External.CurrentChar != -1)
            {
                Form3.txtSlot.Text = "15";
                Form3.txtItemIndex.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[15].sIndex.ToString();
                Form3.txtEF1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[15].sEffect[0].cEfeito.ToString();
                Form3.txtEFv1.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[15].sEffect[0].cValue.ToString();
                Form3.txtEF2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[15].sEffect[1].cEfeito.ToString();
                Form3.txtEFv2.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[15].sEffect[1].cValue.ToString();
                Form3.txtEF3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[15].sEffect[2].cEfeito.ToString();
                Form3.txtEFv3.Text = External.g_pAcccount.Char[External.CurrentChar].Equip[15].sEffect[2].cValue.ToString();
            }
            else
            {
                MessageBox.Show("Selecione um personagem para poder visualizar as informações!");
                return;
            }

            Form3.Show();
        }

        private void txt_Leave(object sender, EventArgs e)
        {
            External.CurrentChar = Chars.SelectedIndex;

            #region Informações TextBox

            External.g_pAcccount.Char[External.CurrentChar].name = txtNome.Text;

            External.g_pAcccount.Info.AccountPass = txtSenha.Text;

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Level = Convert.ToInt32(txtLevel.Text);

            External.g_pAcccount.Char[External.CurrentChar].Exp = Convert.ToInt64(txtExp.Text);

            External.g_pAcccount.Char[External.CurrentChar].Coin = Convert.ToInt32(txtCoin.Text);

            External.g_pAcccount.Char[External.CurrentChar].SPX = Convert.ToInt16(txtPosX.Text);

            External.g_pAcccount.Char[External.CurrentChar].SPY = Convert.ToInt16(txtPosY.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Ataque = Convert.ToInt32(txtBaseAtk.Text);

            External.g_pAcccount.Char[External.CurrentChar].CurrentScore.Ataque = Convert.ToInt32(txtCurrAtk.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Defesa = Convert.ToInt32(txtBaseDef.Text);

            External.g_pAcccount.Char[External.CurrentChar].CurrentScore.Defesa = Convert.ToInt32(txtCurrDef.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Str = Convert.ToInt16(txtStr.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Int = Convert.ToInt16(txtInt.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Dex = Convert.ToInt16(txtDex.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Con = Convert.ToInt16(txtCon.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.MaxHP = Convert.ToInt32(txtMaxHP.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.MaxMP = Convert.ToInt32(txtMaxMP.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.HP = Convert.ToInt32(txtHPatual.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.MP = Convert.ToInt32(txtMPatual.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[0] = Convert.ToInt16(txtSpe0.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[1] = Convert.ToInt16(txtSpe1.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[2] = Convert.ToInt16(txtSpe2.Text);

            External.g_pAcccount.Char[External.CurrentChar].BaseScore.Special[3] = Convert.ToInt16(txtSpe3.Text);

            External.g_pAcccount.Char[External.CurrentChar].Resist[0] = Convert.ToByte(txtSagrado.Text);

            External.g_pAcccount.Char[External.CurrentChar].Resist[1] = Convert.ToByte(txtTrovao.Text);

            External.g_pAcccount.Char[External.CurrentChar].Resist[2] = Convert.ToByte(txtFogo.Text);

            External.g_pAcccount.Char[External.CurrentChar].Resist[3] = Convert.ToByte(txtGelo.Text);

            External.g_pAcccount.Char[External.CurrentChar].ScoreBonus = Convert.ToInt16(txtPontosSta.Text);

            External.g_pAcccount.Char[External.CurrentChar].SpecialBonus = Convert.ToInt16(txtPontosSpe.Text);

            External.g_pAcccount.Char[External.CurrentChar].SkillBonus = Convert.ToInt16(txtPontosSkill.Text);

            #endregion

            UpdateInfo();

            Functions.SaveAccount(External.g_pAcccount);
            labelSave.Text = string.Format("Conta {0} salva com sucesso!", External.g_pAcccount.Info.AccountName);

           // LimpaLabel();
        }

        private void criarContaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CriarConta newAccount = new CriarConta();

            newAccount.Show();
        }

        private void alterarTodasAsSenhasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            W2___Alterador_de_senha_Global ChangePass = new W2___Alterador_de_senha_Global();

            ChangePass.Show();
        }
    }
}
