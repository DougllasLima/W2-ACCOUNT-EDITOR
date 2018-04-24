using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EditorAccounts
{
    class Functions : Structs
    {
        public static StructName LoadFile<StructName>(byte[] rawData) where StructName : struct
        {
            var getAlloc = GCHandle.Alloc(rawData, GCHandleType.Pinned);
            try
            {
                var Pointer = getAlloc.AddrOfPinnedObject();
                return (StructName)Marshal.PtrToStructure(Pointer, typeof(StructName));
            }
            finally
            {
                getAlloc.Free();
            }
        }
        public static void ReadItemList()
        {
            try
            {
                Byte[] data = File.ReadAllBytes("./Itemlist.bin");

                for (int i = 0; i < data.Length; i++)
                {
                    data[i] ^= 0x5A;
                }

                External.g_pItemList = LoadFile<sITEMLIST>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void LoadAccount(string Patch)
        {
            try
            {
                Byte[] data = File.ReadAllBytes(Patch);
                External.g_pAcccount = LoadFile<STRUCT_ACCOUNTFILE>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void SaveAccount(STRUCT_ACCOUNTFILE Account)
        {
            try
            {
                string DirAccount = Directory.GetCurrentDirectory() + "./account/" + Account.Info.AccountName[0].ToString();

                byte[] data = new byte[Marshal.SizeOf(Account)];

                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(Account));
                Marshal.StructureToPtr(Account, ptr, false);
                Marshal.Copy(ptr, data, 0, Marshal.SizeOf(Account));
                Marshal.FreeHGlobal(ptr);

                bool folderExists = Directory.Exists(DirAccount);
                if (!folderExists)
                    Directory.CreateDirectory(DirAccount);

                DirAccount = DirAccount + "/" + Account.Info.AccountName;

                File.WriteAllBytes(DirAccount, data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static void ChangePassword(STRUCT_ACCOUNTFILE Account, string newPass)
        {
            try
            {
                string DirAccount = Directory.GetCurrentDirectory() + "./account/" + Account.Info.AccountName[0].ToString();

                byte[] data = new byte[Marshal.SizeOf(Account)];

                IntPtr ptr = Marshal.AllocHGlobal(Marshal.SizeOf(Account));
                Marshal.StructureToPtr(Account, ptr, false);
                Marshal.Copy(ptr, data, 0, Marshal.SizeOf(Account));
                Marshal.FreeHGlobal(ptr);

                bool folderExists = Directory.Exists(DirAccount.ToLower());
                if (!folderExists)
                    Directory.CreateDirectory(DirAccount.ToLower());

                DirAccount = DirAccount + "/" + Account.Info.AccountName.ToLower();              

                File.WriteAllBytes(DirAccount.ToLower(), data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static bool CheckSpecialCaracters(string Text)
        {
            string specialChar = @"\|!#$%&/()=?»«@£§€{}.-;'<>_,";
            foreach (var item in specialChar)
            {
                if (Text.Contains(item))
                    return true;
            }
            return false;
        }
    }
}
