using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Restaurant_System
{
    public partial class Form1 : Form
    {
        bool drag = false;
        Point start_point = new Point(0, 0);
        public Form1()
        {
            InitializeComponent();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (SubPanel.Width == 230)
            {
                SubPanel.Width = 50;
            }
            else
            {
                SubPanel.Width = 230;
            }
        }

        private void icMaximize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            icMaximize.Visible = false;
            icNormal.Visible = true;
        }

        private void icNormal_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            icNormal.Visible = false;
            icMaximize.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void icMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void ToolPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (drag)
            {
                Point p = PointToScreen(e.Location);
                this.Location = new Point(p.X - start_point.X, p.Y - start_point.Y);
            }
        }

        private void ToolPanel_MouseUp(object sender, MouseEventArgs e)
        {
            drag = false;
        }

        private void ToolPanel_MouseDown(object sender, MouseEventArgs e)
        {
            drag = true;
            start_point = new Point(e.X, e.Y);
        }
    }
}
