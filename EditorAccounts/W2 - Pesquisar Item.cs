using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EditorAccounts
{
    public partial class W2___Pesquisar_Item : Form
    {
        Form4 Form4;

        public W2___Pesquisar_Item(Form4 fmr)
        {
            InitializeComponent();
            Form4 = fmr;
            this.dataGridView1.AdvancedCellBorderStyle.Left = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AdvancedCellBorderStyle.Right = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AdvancedCellBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AdvancedCellBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            this.dataGridView1.AllowUserToResizeRows = false;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            string item = txtIndex.Text;
            dataGridView1.Rows.Clear();

            if (e.KeyChar == 13)
            {
                for(int i = 0; i < 6500; i++)
                {
                    if (item == i.ToString() || External.g_pItemList.item[i].Name.Replace('_', ' ').ToLower().Contains(item) || External.g_pItemList.item[i].Name.Replace('_', ' ').ToUpper().Contains(item))
                    {
                        dataGridView1.Rows.Add(i, External.g_pItemList.item[i].Name);
                    }
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                Form4.txtItemIndex.Text = row.Cells[0].Value.ToString();
                Form4.txtPreco.Text = External.g_pItemList.item[Convert.ToInt32(row.Cells[0].Value)].Price.ToString();
                Form4.txtMesh.Text = External.g_pItemList.item[Convert.ToInt32(row.Cells[0].Value)].IndexMesh.ToString();
            }

            this.Close();
        }
    }
}
