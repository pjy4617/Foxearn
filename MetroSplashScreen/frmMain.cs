using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MetroSplashScreen
{
    public partial class frmMain : MetroFramework.Forms.MetroForm
    {
        public frmMain()
        {
            Thread th = new Thread(new ThreadStart(Loading));
            th.Start();
            InitializeComponent();
            for (int i = 0; i < 500; i++)
                Thread.Sleep(10);
            th.Abort();
            this.TopMost = true;
        }
        void Loading()
        {
            frmSplashScreen frm = new frmSplashScreen();
            Application.Run(frm);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.TopMost = false;
        }
    }
}
