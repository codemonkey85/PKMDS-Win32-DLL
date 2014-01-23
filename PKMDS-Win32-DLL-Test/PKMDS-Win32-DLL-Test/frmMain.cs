using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace PKMDS_Win32_DLL_Test
{
    public partial class frmMain : Form
    {
        public string dbfile = "C:\\Users\\michaelbond\\Dropbox\\PKMDS Databases\\veekun-pokedex.sqlite";
        public string savefile = "C:\\Users\\michaelbond\\Dropbox\\Saves\\Mike B2 Sav.sav";

        [DllImport("..\\..\\..\\..\\PKMDS-Win32-DLL\\Debug\\PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetPKMName(int speciesid, int langid, string dbfilename);

        [DllImport("..\\..\\..\\..\\PKMDS-Win32-DLL\\Debug\\PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetPKMName_FromSav(string savefile, int box, int slot, string dbfilename);

        [DllImport("..\\..\\..\\..\\PKMDS-Win32-DLL\\Debug\\PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetBoxName(string savefile, int box);

        public frmMain()
        {
            InitializeComponent();
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            //lblTest.Text = GetPKMName_FromSav(savefile, 0, 0, dbfile); // GetPKMName((int)(numSpecies.Value), 9, dbfile);
            cbBox.Items.Clear();
            for (int box = 0; box < 24; box++)
            {
                cbBox.Items.Add(GetBoxName(savefile, box));
            }
        }
        private void btnTest2_Click(object sender, EventArgs e)
        {
            if (cbBox.Items.Count > 0)
            {
                lblTest.Text = GetPKMName_FromSav(savefile, cbBox.SelectedIndex, (int)(numSlot.Value - 1), dbfile);
            }
        }
    }
}
