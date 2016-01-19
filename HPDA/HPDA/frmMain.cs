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

        private void btnProStore_Click(object sender, EventArgs e)
        {
            
        }

        private void btnPutBox_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            
        }

        private void btnProDelivery_Click(object sender, EventArgs e)
        {
           
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSync_Click(object sender, EventArgs e)
        {
            using (var rm = new RawMaterial())
            {
                rm.ShowDialog();
            }
        }

        private void btnCheckOne_Click(object sender, EventArgs e)
        {
            
        }

        private void btnCheckTwo_Click(object sender, EventArgs e)
        {
            
        }

        private void frmMain_Load(object sender, EventArgs e)
        {

        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            using (var pq = new ProductQuery())
            {
                pq.ShowDialog();
            }
        }

        
    }
}