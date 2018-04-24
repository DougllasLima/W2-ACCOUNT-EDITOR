using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EditorAccounts
{
    public class Structs
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct STRUCT_MOB
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string name;
            public byte Clan;
            public byte Merchant;
            public short Guild;
            public sbyte Class;
            public short Rsv;
            public byte Quest;

            public int Coin;

            public long Exp;

            public short SPX;
            public short SPY;

            public STRUCT_SCORE BaseScore;
            public STRUCT_SCORE CurrentScore;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public STRUCT_ITEM[] Equip;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 64)]
            public STRUCT_ITEM[] Carry;

            public long LearnedSkill;

            public short ScoreBonus;
            public short SpecialBonus;
            public short SkillBonus;

            public byte Critical;
            public byte SaveMana;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SkillBar;

            public byte GuildLevel;

            public short Magic;

            public short RegenHP;
            public short RegenMP;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] Resist;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STRUCT_SCORE
        {
            public Int32 Level;
            public Int32 Defesa;
            public Int32 Ataque;

            public byte Merchante;
            public byte AttackRun;
            public byte Direction;
            public byte ChaosRate;

            public Int32 MaxHP;
            public Int32 MaxMP;
            public Int32 HP;
            public Int32 MP;

            public short Str;
            public short Int;
            public short Dex;
            public short Con;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public short[] Special;

        };

        [StructLayout(LayoutKind.Sequential, Pack = 1, Size = 8)]
        public struct STRUCT_ITEM
        {
            public short sIndex;//2
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
            public sItemADD[] sEffect;//8
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct sItemADD//2
        {
            public Byte cEfeito;
            public Byte cValue;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STRUCT_ITEMLIST
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 64)]
            public string Name;
            public short IndexMesh;
            public short IndexTexture;
            public short IndexVisualEffect;
            public short ReqLvl;
            public short ReqStr;
            public short ReqInt;
            public short ReqDex;
            public short ReqCon;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 12)]
            public ItemEffect[] stEffect;

            public int Price;
            public short nUnique;
            public short nPos;
            public short Extra;
            public short Grade;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct sITEMLIST
        {
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6500)]
            public STRUCT_ITEMLIST[] item;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct ItemEffect
        {
            public short sEffect;
            public short sValue;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct STRUCT_ACCOUNTINFO
        {
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public string AccountName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 12)]
            public string AccountPass;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 24)]
            public String RealName;
            public Int32 SSN1;
            public Int32 SSN2;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 48)]
            public String Email;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 16)]
            public String Telephone;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 78)]
            public String Address;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
            public char[] NumericToken;

            public int Year;
            public int YearDay;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STRUCT_ACCOUNTFILE
        {
            public STRUCT_ACCOUNTINFO Info; // 0 - 216

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public STRUCT_MOB[] Char;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 128)]
            public STRUCT_ITEM[] Cargo;

            public int Coin;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ShortSkill1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ShortSkill2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ShortSkill3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] ShortSkill4;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public STRUCT_AFFECT[] affect1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public STRUCT_AFFECT[] affect2;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public STRUCT_AFFECT[] affect3;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
            public STRUCT_AFFECT[] affect4;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public STRUCT_MOBEXTRA[] mobExtra;

            public int Donate;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 52)]
            public byte[] TempKey;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STRUCT_AFFECT
        {
            public byte Type;
            public byte Value;
            public short Level;
            public int Time;
        };

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct STRUCT_MOBEXTRA
        {
            public short ClassMaster;
            public sbyte Citizen;

            public int Fame;

            public byte Soul;

            public short MortalFace;

            public QuestInfo QuestInfo;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
            public SaveCelestial[] SaveCelestial;

            public Int64 LastNT;
            public int NT;

            public int KefraTicket;

            public Int64 DivineEnd;

            public uint Hold;

            public DayLog DayLog;

            public DonateInfo DonateInfo;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
            public int[] EMPTY;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Mortal
        {
            public byte Newbie;//00_01_02_03_04  quest com quatro etapas
            public byte TerraMistica;//0 : não pegou a quest 1: pegou a quest e não concluiu 2: quest completa
            public byte MolarGargula;
            public byte PilulaOrc;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] EMPTY;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Arch
        {
            public byte MortalSlot;
            public byte MortalLevel;

            public byte Level355;
            public byte Level370;

            public byte Cristal;//00_01_02_03_04 quest com quatro etapas

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] EMPTY;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct Celestial
        {
            public short ArchLevel;
            public short CelestialLevel;
            public short SubCelestialLevel;

            public byte Lv40;
            public byte Lv90;

            public byte Add120;
            public byte Add150;
            public byte Add180;
            public byte Add200;

            public byte Arcana;
            public byte Reset;

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] EMPTY;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct QuestInfo
        {
            public Mortal Mortal;

            public Arch Arch;

            public Celestial Celestial;

            public byte Circle;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] EMPTY;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct SaveCelestial
        {
            public int Class;

            public long Exp;            // The ammount of experience the mob has to level up

            public short SPX;           // The Y position saved by the stellar gem, to teleport the mob there when using warp scroll
            public short SPY;           // The Y position saved by the stellar gem, to teleport the mob there when using warp scroll

            public STRUCT_SCORE BaseScore;    // The base score of the mob 

            public long LearnedSkill; // The skills the mob learned, divided into four categories (00 _ 00 _ 00 _ 00)

            public short ScoreBonus;   // The points the mob can use to increase score (Str, Int, Dex, Con)
            public short SpecialBonus; // The points the mob can use to increase special, to increase effect of learned skills (score->Special[4])
            public short SkillBonus;   // The points the mob can use to buy skills

            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
            public byte[] SkillBar1;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
            public byte[] SkillBar2;  // The skills saved on the first 4 slots of the skill bar

            public byte Soul;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
            public byte[] EMPTY;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DayLog
        {
            public ulong Exp;
            public int YearDay;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        public struct DonateInfo
        {
            public Int64 LastTime;
            public int Count;
        }
    }
}
