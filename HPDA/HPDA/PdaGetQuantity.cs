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
    public partial class PdaGetQuantity : Form
    {
        public decimal IQuantity;

        public PdaGetQuantity(string cInvCode,string cInvName,string cLotNo)
        {
            InitializeComponent();
            lblcInvCode.Text = cInvCode;
            lblcInvName.Text = cInvName;
            lblcLotNo.Text = cLotNo;
        }

        public PdaGetQuantity(string cInvCode, string cInvName, string cLotNo,string ciQuantity)
        {
            InitializeComponent();
            lblcInvCode.Text = cInvCode;
            lblcInvName.Text = cInvName;
            lblcLotNo.Text = cLotNo;
            txtiNum.Text = ciQuantity;
        }


        private void PdaGetQuantity_Load(object sender, EventArgs e)
        {
            txtiNum.Focus();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtiNum.Text))
                return;
            try
            {
                IQuantity = decimal.Parse(txtiNum.Text);
                DialogResult = DialogResult.Yes;
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的数值");
            }
        }

        private void txtiNum_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
                return;

            if (string.IsNullOrEmpty(txtiNum.Text))
                return;
            try
            {
                IQuantity = decimal.Parse(txtiNum.Text);
                DialogResult = DialogResult.Yes;
            }
            catch (Exception)
            {
                MessageBox.Show("请输入正确的数值");
            }
        }
    }
}