using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using DataGrabber;

namespace ptdb
{
    public partial class main_form : Form
    {
        public main_form()
        {
            InitializeComponent();
        }

        private void gbIzd_Enter(object sender, EventArgs e)
        {

        }

        private void main_form_Load(object sender, EventArgs e)
        {
            
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            if (rbPT6A.Checked==true)
            {
                frmData FrmData = new frmData
                {
                    type = "6A"
                };
                FrmData.Show();
            }
            else if (rbPT4.Checked == true)
            {
                frmData FrmData = new frmData
                {
                    type = "4"
                };
                FrmData.Show();
            }
            else if (rbPT4M.Checked == true)
            {
                frmData FrmData = new frmData
                {
                    type = "4M"
                };
                FrmData.Show();
            }
            else if (rbPT6B.Checked == true)
            {
                frmData FrmData = new frmData
                {
                    type = "6B"
                };
                FrmData.Show();
            }
            else if(rbMR.Checked==true)
            {
                frmData FrmData = new frmData
                {
                    type = "MR"
                };
                FrmData.Show();
            }
            else if(rbRep600.Checked==true)
            {
                frmData FrmData = new frmData
                {
                    type = "rep600"
                };
                FrmData.Show();
            }
            else
            {
                MessageBox.Show("Выберите изделие!","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string txtPrint = "";
            int amount = Convert.ToInt32(amountNud.Value);

            for(int i=1;i<amount+1;i++)
            {
                txtPrint += $"p8s{i},p1s{i},p6s{i},p3s{i},p2s{i},p7s{i},p4s{i},p5s{i},";
            }
            textBox1.Text = txtPrint;
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            frmHelp FrmHelp = new frmHelp();
            FrmHelp.Show();

        }

        private void aboutBtn_Click(object sender, EventArgs e)
        {
            AboutBox1 aboutBox1 = new AboutBox1();
            aboutBox1.ShowDialog();
        }
    }
}
