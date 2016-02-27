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
    public partial class FrmMainPro : Form
    {
        public FrmMainPro()
        {
            InitializeComponent();
        }

        

        private void pbExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadDelivery_Click(object sender, EventArgs e)
        {
            using (var pd = new ProDeliveryDownload())
            {
                pd.ShowDialog();
            }
        }

        private void btnDeliverySelect_Click(object sender, EventArgs e)
        {
            using (var pds = new ProDeliverySelect())
            {
                pds.ShowDialog();
            }
        }

        private void btnTransferDownload_Click(object sender, EventArgs e)
        {
            using (var pds = new ProTransferDownload())
            {
                pds.ShowDialog();
            }
        }

        private void btnTransferSelect_Click(object sender, EventArgs e)
        {
            using (var pds = new ProTransferSelect())
            {
                pds.ShowDialog();
            }
        }

        private void btnCheckDownLoad_Click(object sender, EventArgs e)
        {
            using (var pds = new ProCheckDownload())
            {
                pds.ShowDialog();
            }
        }

        private void btnCheckSelect_Click(object sender, EventArgs e)
        {
            using (var pds = new ProCheckSelect())
            {
                pds.ShowDialog();
            }
        }
    }
}