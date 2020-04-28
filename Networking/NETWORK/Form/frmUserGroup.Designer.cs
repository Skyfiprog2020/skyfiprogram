namespace NETWORK
{
    partial class frmUserGroup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtgroupcode = new System.Windows.Forms.TextBox();
            this.txtclose = new System.Windows.Forms.Button();
            this.txtsave = new System.Windows.Forms.Button();
            this.txtgroupname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(37, 72);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 23);
            this.label1.TabIndex = 9;
            this.label1.Text = "Group Name:";
            // 
            // txtgroupcode
            // 
            this.txtgroupcode.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgroupcode.Location = new System.Drawing.Point(395, 28);
            this.txtgroupcode.Name = "txtgroupcode";
            this.txtgroupcode.ReadOnly = true;
            this.txtgroupcode.Size = new System.Drawing.Size(78, 32);
            this.txtgroupcode.TabIndex = 8;
            this.txtgroupcode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtclose
            // 
            this.txtclose.Location = new System.Drawing.Point(398, 165);
            this.txtclose.Name = "txtclose";
            this.txtclose.Size = new System.Drawing.Size(75, 32);
            this.txtclose.TabIndex = 7;
            this.txtclose.Text = "&Close";
            this.txtclose.UseVisualStyleBackColor = true;
            this.txtclose.Click += new System.EventHandler(this.txtclose_Click);
            // 
            // txtsave
            // 
            this.txtsave.Location = new System.Drawing.Point(317, 165);
            this.txtsave.Name = "txtsave";
            this.txtsave.Size = new System.Drawing.Size(75, 32);
            this.txtsave.TabIndex = 6;
            this.txtsave.Text = "&Save";
            this.txtsave.UseVisualStyleBackColor = true;
            this.txtsave.Click += new System.EventHandler(this.txtsave_Click);
            // 
            // txtgroupname
            // 
            this.txtgroupname.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtgroupname.Location = new System.Drawing.Point(41, 98);
            this.txtgroupname.Name = "txtgroupname";
            this.txtgroupname.Size = new System.Drawing.Size(432, 32);
            this.txtgroupname.TabIndex = 5;
            // 
            // frmUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(510, 220);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtgroupcode);
            this.Controls.Add(this.txtclose);
            this.Controls.Add(this.txtsave);
            this.Controls.Add(this.txtgroupname);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(526, 259);
            this.MinimumSize = new System.Drawing.Size(526, 259);
            this.Name = "frmUserGroup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User Group";
            this.Load += new System.EventHandler(this.frmUserGroup_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtgroupcode;
        private System.Windows.Forms.Button txtclose;
        private System.Windows.Forms.Button txtsave;
        private System.Windows.Forms.TextBox txtgroupname;
    }
}