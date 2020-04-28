using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;
using System.IO.Ports;

namespace NETWORK
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            SidePanel.Height = btnMachine.Height;
            SidePanel.Top = btnMachine.Top;
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            SidePanel.Height = btnMachine.Height;
            SidePanel.Top = btnMachine.Top;
        }
      private void newForm(object Formnew)
      {
          if (pnlHome.Controls.Count > 0)
              this.pnlHome.Controls.RemoveAt(0);
          Form fn = Formnew as Form;
          fn.TopLevel = false;
          fn.Dock = DockStyle.Fill;
          this.pnlHome.Controls.Add(fn);
          this.pnlHome.Tag = fn;
          fn.Show();
      }

      private void nextfieldenter(object sender, KeyEventArgs e)
      {
          if (e.KeyCode.Equals(Keys.Enter))
          {
              SendKeys.Send("{TAB}");
          }

      }
      private void btnMachine_Click(object sender, EventArgs e)
      {
          SidePanel.Height = btnMachine.Height;
          SidePanel.Top = btnMachine.Top;
          newForm(new frmNewMember());
      }

      private void btnNC_Click(object sender, EventArgs e)
      {
          SidePanel.Height = btnNC.Height;
          SidePanel.Top = btnNC.Top;
          newForm(new frmSecurity());
      }
      private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
      {
          Application.Exit();
      }
    }
}
