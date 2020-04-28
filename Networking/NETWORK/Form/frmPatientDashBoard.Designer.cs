namespace NETWORK
{
    partial class frmPatientDashBoard
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
            this.TCDashBoard1 = new System.Windows.Forms.TabControl();
            this.TPPatientRecords = new System.Windows.Forms.TabPage();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.dgv1Record = new System.Windows.Forms.DataGridView();
            this.TPDiagnose = new System.Windows.Forms.TabPage();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.txtDiagnose = new System.Windows.Forms.TextBox();
            this.txtTDate = new System.Windows.Forms.MaskedTextBox();
            this.txtDocNum = new System.Windows.Forms.TextBox();
            this.TCDashBoard1.SuspendLayout();
            this.TPPatientRecords.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1Record)).BeginInit();
            this.TPDiagnose.SuspendLayout();
            this.SuspendLayout();
            // 
            // TCDashBoard1
            // 
            this.TCDashBoard1.Controls.Add(this.TPPatientRecords);
            this.TCDashBoard1.Controls.Add(this.TPDiagnose);
            this.TCDashBoard1.Location = new System.Drawing.Point(12, 12);
            this.TCDashBoard1.Name = "TCDashBoard1";
            this.TCDashBoard1.SelectedIndex = 0;
            this.TCDashBoard1.Size = new System.Drawing.Size(964, 450);
            this.TCDashBoard1.TabIndex = 0;
            // 
            // TPPatientRecords
            // 
            this.TPPatientRecords.Controls.Add(this.txtControlNo);
            this.TPPatientRecords.Controls.Add(this.dgv1Record);
            this.TPPatientRecords.Location = new System.Drawing.Point(4, 22);
            this.TPPatientRecords.Name = "TPPatientRecords";
            this.TPPatientRecords.Padding = new System.Windows.Forms.Padding(3);
            this.TPPatientRecords.Size = new System.Drawing.Size(956, 424);
            this.TPPatientRecords.TabIndex = 0;
            this.TPPatientRecords.Text = "Record";
            this.TPPatientRecords.UseVisualStyleBackColor = true;
            // 
            // txtControlNo
            // 
            this.txtControlNo.Location = new System.Drawing.Point(523, 34);
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.Size = new System.Drawing.Size(100, 20);
            this.txtControlNo.TabIndex = 89;
            this.txtControlNo.Visible = false;
            // 
            // dgv1Record
            // 
            this.dgv1Record.AllowUserToAddRows = false;
            this.dgv1Record.AllowUserToDeleteRows = false;
            this.dgv1Record.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv1Record.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv1Record.Location = new System.Drawing.Point(3, 3);
            this.dgv1Record.Name = "dgv1Record";
            this.dgv1Record.ReadOnly = true;
            this.dgv1Record.Size = new System.Drawing.Size(950, 418);
            this.dgv1Record.TabIndex = 88;
            // 
            // TPDiagnose
            // 
            this.TPDiagnose.Controls.Add(this.btnSave);
            this.TPDiagnose.Controls.Add(this.label6);
            this.TPDiagnose.Controls.Add(this.label5);
            this.TPDiagnose.Controls.Add(this.label4);
            this.TPDiagnose.Controls.Add(this.label8);
            this.TPDiagnose.Controls.Add(this.txtRemarks);
            this.TPDiagnose.Controls.Add(this.txtDiagnose);
            this.TPDiagnose.Controls.Add(this.txtTDate);
            this.TPDiagnose.Controls.Add(this.txtDocNum);
            this.TPDiagnose.Location = new System.Drawing.Point(4, 22);
            this.TPDiagnose.Name = "TPDiagnose";
            this.TPDiagnose.Padding = new System.Windows.Forms.Padding(3);
            this.TPDiagnose.Size = new System.Drawing.Size(956, 424);
            this.TPDiagnose.TabIndex = 1;
            this.TPDiagnose.Text = "Diagnose";
            this.TPDiagnose.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(733, 359);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 103;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(18, 212);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 19);
            this.label6.TabIndex = 102;
            this.label6.Text = "Remarks:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(18, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 19);
            this.label5.TabIndex = 101;
            this.label5.Text = "Diagnose:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(676, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 19);
            this.label4.TabIndex = 100;
            this.label4.Text = "Date:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(655, 36);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 19);
            this.label8.TabIndex = 99;
            this.label8.Text = "Number:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRemarks.Location = new System.Drawing.Point(22, 234);
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(786, 26);
            this.txtRemarks.TabIndex = 96;
            this.txtRemarks.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // txtDiagnose
            // 
            this.txtDiagnose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDiagnose.Location = new System.Drawing.Point(22, 153);
            this.txtDiagnose.Name = "txtDiagnose";
            this.txtDiagnose.Size = new System.Drawing.Size(786, 26);
            this.txtDiagnose.TabIndex = 95;
            this.txtDiagnose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.nextfieldenter);
            // 
            // txtTDate
            // 
            this.txtTDate.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTDate.Location = new System.Drawing.Point(726, 65);
            this.txtTDate.Mask = "00/00/0000";
            this.txtTDate.Name = "txtTDate";
            this.txtTDate.ReadOnly = true;
            this.txtTDate.Size = new System.Drawing.Size(82, 26);
            this.txtTDate.TabIndex = 98;
            this.txtTDate.ValidatingType = typeof(System.DateTime);
            // 
            // txtDocNum
            // 
            this.txtDocNum.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDocNum.Location = new System.Drawing.Point(726, 33);
            this.txtDocNum.Name = "txtDocNum";
            this.txtDocNum.ReadOnly = true;
            this.txtDocNum.Size = new System.Drawing.Size(82, 26);
            this.txtDocNum.TabIndex = 97;
            this.txtDocNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // frmPatientDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 474);
            this.Controls.Add(this.TCDashBoard1);
            this.Name = "frmPatientDashBoard";
            this.Text = "Patient Dashboard";
            this.Load += new System.EventHandler(this.frmPatientDashBoard_Load);
            this.TCDashBoard1.ResumeLayout(false);
            this.TPPatientRecords.ResumeLayout(false);
            this.TPPatientRecords.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv1Record)).EndInit();
            this.TPDiagnose.ResumeLayout(false);
            this.TPDiagnose.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl TCDashBoard1;
        private System.Windows.Forms.TabPage TPPatientRecords;
        private System.Windows.Forms.TabPage TPDiagnose;
        private System.Windows.Forms.DataGridView dgv1Record;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.TextBox txtDiagnose;
        private System.Windows.Forms.MaskedTextBox txtTDate;
        private System.Windows.Forms.TextBox txtDocNum;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtControlNo;
    }
}