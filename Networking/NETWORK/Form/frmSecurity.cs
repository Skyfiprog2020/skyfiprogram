using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NETWORK
{
    public partial class frmSecurity : Form
    {
        public frmSecurity()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmUserAdd frmUserAdd1 = new frmUserAdd();
            frmUserAdd1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            frmUserGroup frmUserGroup1 = new frmUserGroup();
            frmUserGroup1.Show();
        }

        private void btnMembership_Click(object sender, EventArgs e)
        {
            frmUserMembership frmUserMembership1 = new frmUserMembership();
            frmUserMembership1.Show();
        }

        private void btnPermission_Click(object sender, EventArgs e)
        {
            frmUserPermission frmUserPermission1 = new frmUserPermission();
            frmUserPermission1.Show();
        }
    }
}
