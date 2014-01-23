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
        [DllImport("..\\..\\..\\..\\PKMDS-Win32-DLL\\Debug\\PKMDS-Win32-DLL.dll", CallingConvention = CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.BStr)]
        private static extern string GetPKMName(int speciesid, int langid, string dbfilename);

        public frmMain()
        {
            InitializeComponent();
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            lblTest.Text = GetPKMName((int)(numSpecies.Value), 9, dbfile);
        }
    }
}
