using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EditorAccounts
{
    public class ClassLocalizarItem2
    {
        public static int LocalizarItens(int index)
        {
            int encontrados = 0;

            try
            {
                External.ContasLocalizadas.Clear();

                DirectoryInfo diretorio = new DirectoryInfo(Environment.CurrentDirectory + @"/account/");
                FileInfo[] files = diretorio.GetFiles(".", SearchOption.AllDirectories);

                foreach (FileInfo fileinfo in files)
                {
                    Byte[] data = File.ReadAllBytes(fileinfo.FullName);
                    Structs.STRUCT_ACCOUNTFILE contas = (Structs.STRUCT_ACCOUNTFILE)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), typeof(Structs.STRUCT_ACCOUNTFILE));

                    for (int i = 0; i < 128; i++)
                    {
                        if (contas.Cargo[i].sIndex == index)
                        {
                            External.ContasLocalizadas.Add(contas);
                            encontrados++;
                            break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return encontrados;
        }
    }
}
