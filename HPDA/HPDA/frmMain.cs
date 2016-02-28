using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HPDA
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

       

        private void btnProduct_Click(object sender, EventArgs e)
        {
            using (var pq = new ProductQuery())
            {
                pq.ShowDialog();
            }
        }

        private void btnRmMain_Click(object sender, EventArgs e)
        {
            using (var rm = new FrmMainRm())
            {
                rm.ShowDialog();
            }
        }

        private void btnRaw_Click(object sender, EventArgs e)
        {
            using (var rm = new RawMaterial())
            {
                rm.ShowDialog();
            }
        }

        private void btnProMain_Click(object sender, EventArgs e)
        {
            using (var rm = new FrmMainPro())
            {
                rm.ShowDialog();
            }
        }

        
    }
}