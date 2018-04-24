using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//namespace EditorAccounts
//{
//   public class ClassLocalizador
//    {
//        public static void ReadAccounts()
//        {
//            try
//            {
//                DirectoryInfo diretorio = new DirectoryInfo(Environment.CurrentDirectory + @"/account/");
//                FileInfo[] files = diretorio.GetFiles(".", SearchOption.AllDirectories);

//                foreach (FileInfo fileinfo in files)
//                {
//                    Byte[] data = File.ReadAllBytes(fileinfo.FullName);
//                    Structs.STRUCT_ACCOUNTFILE contas = (Structs.STRUCT_ACCOUNTFILE)Marshal.PtrToStructure(Marshal.UnsafeAddrOfPinnedArrayElement(data, 0), typeof(Structs.STRUCT_ACCOUNTFILE));
//                    External.g_pContas.Add(contas);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show(ex.Message);
//            }
//        }
//    }
//}
