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
    public partial class FrmMainRm : Form
    {
        public FrmMainRm()
        {
            InitializeComponent();
        }

      

        private void pbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPoDownload_Click(object sender, EventArgs e)
        {
            using (var pds = new RmPoDownload())
            {
                pds.ShowDialog();
            }
        }

        private void btnPoSelect_Click(object sender, EventArgs e)
        {
            using (var pds = new RmPoSelect())
            {
                pds.ShowDialog();
            }
        }

        private void btnProduceDownload_Click(object sender, EventArgs e)
        {
            using (var pds = new RmProduceDownLoad())
            {
                pds.ShowDialog();
            }
        }

        private void btnProduceSelect_Click(object sender, EventArgs e)
        {
            using (var pds = new RmProduceSelect())
            {
                pds.ShowDialog();
            }
        }
    }
}