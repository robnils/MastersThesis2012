namespace MACA
{
    partial class frmParameterBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmParameterBox));
            this.lbRu = new System.Windows.Forms.Label();
            this.tbRu = new System.Windows.Forms.TextBox();
            this.btOk = new System.Windows.Forms.Button();
            this.btCancel = new System.Windows.Forms.Button();
            this.lbu0 = new System.Windows.Forms.Label();
            this.lbv0 = new System.Windows.Forms.Label();
            this.lbRv = new System.Windows.Forms.Label();
            this.tbv0 = new System.Windows.Forms.TextBox();
            this.tbRv = new System.Windows.Forms.TextBox();
            this.tbu0 = new System.Windows.Forms.TextBox();
            this.lbstep = new System.Windows.Forms.Label();
            this.tbstep = new System.Windows.Forms.TextBox();
            this.lba = new System.Windows.Forms.Label();
            this.lbb = new System.Windows.Forms.Label();
            this.tba = new System.Windows.Forms.TextBox();
            this.tbb = new System.Windows.Forms.TextBox();
            this.lbgrid = new System.Windows.Forms.Label();
            this.tbgrid = new System.Windows.Forms.TextBox();
            this.tbmaxtime = new System.Windows.Forms.TextBox();
            this.lbmaxtime = new System.Windows.Forms.Label();
            this.comboxPar = new System.Windows.Forms.ComboBox();
            this.btSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbRu
            // 
            this.lbRu.AutoSize = true;
            this.lbRu.Location = new System.Drawing.Point(88, 64);
            this.lbRu.Name = "lbRu";
            this.lbRu.Size = new System.Drawing.Size(30, 13);
            this.lbRu.TabIndex = 0;
            this.lbRu.Text = "R_u:";
            // 
            // tbRu
            // 
            this.tbRu.Location = new System.Drawing.Point(120, 64);
            this.tbRu.Name = "tbRu";
            this.tbRu.Size = new System.Drawing.Size(72, 20);
            this.tbRu.TabIndex = 1;
            // 
            // btOk
            // 
            this.btOk.Location = new System.Drawing.Point(96, 240);
            this.btOk.Name = "btOk";
            this.btOk.Size = new System.Drawing.Size(96, 32);
            this.btOk.TabIndex = 10;
            this.btOk.Text = "OK";
            this.btOk.UseVisualStyleBackColor = true;
            this.btOk.Click += new System.EventHandler(this.btOk_Click);
            // 
            // btCancel
            // 
            this.btCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btCancel.Location = new System.Drawing.Point(224, 240);
            this.btCancel.Name = "btCancel";
            this.btCancel.Size = new System.Drawing.Size(112, 32);
            this.btCancel.TabIndex = 11;
            this.btCancel.Text = "Cancel";
            this.btCancel.UseVisualStyleBackColor = true;
            this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
            // 
            // lbu0
            // 
            this.lbu0.AutoSize = true;
            this.lbu0.Location = new System.Drawing.Point(240, 64);
            this.lbu0.Name = "lbu0";
            this.lbu0.Size = new System.Drawing.Size(67, 13);
            this.lbu0.TabIndex = 4;
            this.lbu0.Text = "Initial u (u0): ";
            // 
            // lbv0
            // 
            this.lbv0.AutoSize = true;
            this.lbv0.Location = new System.Drawing.Point(240, 96);
            this.lbv0.Name = "lbv0";
            this.lbv0.Size = new System.Drawing.Size(67, 13);
            this.lbv0.TabIndex = 5;
            this.lbv0.Text = "Initial v (v0): ";
            // 
            // lbRv
            // 
            this.lbRv.AutoSize = true;
            this.lbRv.Location = new System.Drawing.Point(88, 96);
            this.lbRv.Name = "lbRv";
            this.lbRv.Size = new System.Drawing.Size(30, 13);
            this.lbRv.TabIndex = 6;
            this.lbRv.Text = "R_v:";
            // 
            // tbv0
            // 
            this.tbv0.Location = new System.Drawing.Point(312, 96);
            this.tbv0.Name = "tbv0";
            this.tbv0.Size = new System.Drawing.Size(72, 20);
            this.tbv0.TabIndex = 4;
            // 
            // tbRv
            // 
            this.tbRv.Location = new System.Drawing.Point(120, 96);
            this.tbRv.Name = "tbRv";
            this.tbRv.Size = new System.Drawing.Size(72, 20);
            this.tbRv.TabIndex = 3;
            // 
            // tbu0
            // 
            this.tbu0.Location = new System.Drawing.Point(312, 64);
            this.tbu0.Name = "tbu0";
            this.tbu0.Size = new System.Drawing.Size(72, 20);
            this.tbu0.TabIndex = 2;
            // 
            // lbstep
            // 
            this.lbstep.AutoSize = true;
            this.lbstep.Location = new System.Drawing.Point(56, 160);
            this.lbstep.Name = "lbstep";
            this.lbstep.Size = new System.Drawing.Size(61, 13);
            this.lbstep.TabIndex = 10;
            this.lbstep.Text = "Time Step: ";
            // 
            // tbstep
            // 
            this.tbstep.Location = new System.Drawing.Point(120, 160);
            this.tbstep.Name = "tbstep";
            this.tbstep.Size = new System.Drawing.Size(72, 20);
            this.tbstep.TabIndex = 7;
            // 
            // lba
            // 
            this.lba.AutoSize = true;
            this.lba.Location = new System.Drawing.Point(96, 128);
            this.lba.Name = "lba";
            this.lba.Size = new System.Drawing.Size(16, 13);
            this.lba.TabIndex = 12;
            this.lba.Text = "a:";
            // 
            // lbb
            // 
            this.lbb.AutoSize = true;
            this.lbb.Location = new System.Drawing.Point(288, 128);
            this.lbb.Name = "lbb";
            this.lbb.Size = new System.Drawing.Size(16, 13);
            this.lbb.TabIndex = 13;
            this.lbb.Text = "b:";
            // 
            // tba
            // 
            this.tba.Location = new System.Drawing.Point(120, 128);
            this.tba.Name = "tba";
            this.tba.Size = new System.Drawing.Size(72, 20);
            this.tba.TabIndex = 5;
            // 
            // tbb
            // 
            this.tbb.Location = new System.Drawing.Point(312, 128);
            this.tbb.Name = "tbb";
            this.tbb.Size = new System.Drawing.Size(72, 20);
            this.tbb.TabIndex = 6;
            // 
            // lbgrid
            // 
            this.lbgrid.AutoSize = true;
            this.lbgrid.Location = new System.Drawing.Point(216, 168);
            this.lbgrid.Name = "lbgrid";
            this.lbgrid.Size = new System.Drawing.Size(82, 13);
            this.lbgrid.TabIndex = 16;
            this.lbgrid.Text = "Grid Size (NxN):";
            // 
            // tbgrid
            // 
            this.tbgrid.Location = new System.Drawing.Point(312, 160);
            this.tbgrid.Name = "tbgrid";
            this.tbgrid.Size = new System.Drawing.Size(72, 20);
            this.tbgrid.TabIndex = 8;
            // 
            // tbmaxtime
            // 
            this.tbmaxtime.Location = new System.Drawing.Point(120, 192);
            this.tbmaxtime.Name = "tbmaxtime";
            this.tbmaxtime.Size = new System.Drawing.Size(72, 20);
            this.tbmaxtime.TabIndex = 9;
            // 
            // lbmaxtime
            // 
            this.lbmaxtime.AutoSize = true;
            this.lbmaxtime.Location = new System.Drawing.Point(56, 192);
            this.lbmaxtime.Name = "lbmaxtime";
            this.lbmaxtime.Size = new System.Drawing.Size(56, 13);
            this.lbmaxtime.TabIndex = 19;
            this.lbmaxtime.Text = "Max Time:";
            // 
            // comboxPar
            // 
            this.comboxPar.FormattingEnabled = true;
            this.comboxPar.Location = new System.Drawing.Point(8, 8);
            this.comboxPar.Name = "comboxPar";
            this.comboxPar.Size = new System.Drawing.Size(192, 21);
            this.comboxPar.TabIndex = 0;
            this.comboxPar.Text = "Choose parameters";           
            // 
            // btSave
            // 
            this.btSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btSave.Location = new System.Drawing.Point(368, 240);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(112, 32);
            this.btSave.TabIndex = 20;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // frmParameterBox
            // 
            this.AcceptButton = this.btOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btCancel;
            this.ClientSize = new System.Drawing.Size(522, 306);
            this.Controls.Add(this.btSave);
            this.Controls.Add(this.comboxPar);
            this.Controls.Add(this.lbmaxtime);
            this.Controls.Add(this.tbmaxtime);
            this.Controls.Add(this.tbgrid);
            this.Controls.Add(this.lbgrid);
            this.Controls.Add(this.tbb);
            this.Controls.Add(this.tba);
            this.Controls.Add(this.lbb);
            this.Controls.Add(this.lba);
            this.Controls.Add(this.tbstep);
            this.Controls.Add(this.lbstep);
            this.Controls.Add(this.tbu0);
            this.Controls.Add(this.tbRv);
            this.Controls.Add(this.tbv0);
            this.Controls.Add(this.lbRv);
            this.Controls.Add(this.lbv0);
            this.Controls.Add(this.lbu0);
            this.Controls.Add(this.btCancel);
            this.Controls.Add(this.btOk);
            this.Controls.Add(this.tbRu);
            this.Controls.Add(this.lbRu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmParameterBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ParameterBox";
            this.Load += new System.EventHandler(this.frmParameterBox_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbRu;
        private System.Windows.Forms.TextBox tbRu;
        private System.Windows.Forms.Button btOk;
        private System.Windows.Forms.Button btCancel;
        private System.Windows.Forms.Label lbu0;
        private System.Windows.Forms.Label lbv0;
        private System.Windows.Forms.Label lbRv;
        private System.Windows.Forms.TextBox tbv0;
        private System.Windows.Forms.TextBox tbRv;
        private System.Windows.Forms.TextBox tbu0;
        private System.Windows.Forms.Label lbstep;
        private System.Windows.Forms.TextBox tbstep;
        private System.Windows.Forms.Label lba;
        private System.Windows.Forms.Label lbb;
        private System.Windows.Forms.TextBox tba;
        private System.Windows.Forms.TextBox tbb;
        private System.Windows.Forms.Label lbgrid;
        private System.Windows.Forms.TextBox tbgrid;
        private System.Windows.Forms.TextBox tbmaxtime;
        private System.Windows.Forms.Label lbmaxtime;
        private System.Windows.Forms.ComboBox comboxPar;
        private System.Windows.Forms.Button btSave;
    }
}