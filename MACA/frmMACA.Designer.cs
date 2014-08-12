namespace MACA
{
    partial class frmMACA
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMACA));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tbTime = new System.Windows.Forms.TextBox();
            this.lbtime = new System.Windows.Forms.Label();
            this.serviceController1 = new System.ServiceProcess.ServiceController();
            this.btStart = new System.Windows.Forms.Button();
            this.btStop = new System.Windows.Forms.Button();
            this.pictBoxu = new System.Windows.Forms.PictureBox();
            this.lbtestu = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbtestv = new System.Windows.Forms.Label();
            this.btNext = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictBoxv = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.rbFast = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbSlow = new System.Windows.Forms.RadioButton();
            this.groupBoxSpeed = new System.Windows.Forms.GroupBox();
            this.btJump = new System.Windows.Forms.Button();
            this.tbJump = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.progbar = new System.Windows.Forms.ProgressBar();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbDiffu = new System.Windows.Forms.TextBox();
            this.tbDiffv = new System.Windows.Forms.TextBox();
            this.btSaveu = new System.Windows.Forms.Button();
            this.btSavev = new System.Windows.Forms.Button();
            this.cbSave = new System.Windows.Forms.CheckBox();
            this.lbSave = new System.Windows.Forms.Label();
            this.tbSave = new System.Windows.Forms.TextBox();
            this.lbS = new System.Windows.Forms.Label();
            this.lbSave2 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxv)).BeginInit();
            this.groupBoxSpeed.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.parametersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1372, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showGraphToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // showGraphToolStripMenuItem
            // 
            this.showGraphToolStripMenuItem.Enabled = false;
            this.showGraphToolStripMenuItem.Name = "showGraphToolStripMenuItem";
            this.showGraphToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.showGraphToolStripMenuItem.Text = "Show Graph";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // parametersToolStripMenuItem
            // 
            this.parametersToolStripMenuItem.Name = "parametersToolStripMenuItem";
            this.parametersToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.parametersToolStripMenuItem.Text = "Parameters";
            this.parametersToolStripMenuItem.Click += new System.EventHandler(this.parametersToolStripMenuItem_Click);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.frm_Tick);
            // 
            // tbTime
            // 
            this.tbTime.Location = new System.Drawing.Point(56, 280);
            this.tbTime.Name = "tbTime";
            this.tbTime.Size = new System.Drawing.Size(80, 20);
            this.tbTime.TabIndex = 1;
            // 
            // lbtime
            // 
            this.lbtime.AutoSize = true;
            this.lbtime.Location = new System.Drawing.Point(16, 280);
            this.lbtime.Name = "lbtime";
            this.lbtime.Size = new System.Drawing.Size(33, 13);
            this.lbtime.TabIndex = 2;
            this.lbtime.Text = "Time:";
            // 
            // btStart
            // 
            this.btStart.Location = new System.Drawing.Point(16, 320);
            this.btStart.Name = "btStart";
            this.btStart.Size = new System.Drawing.Size(75, 23);
            this.btStart.TabIndex = 4;
            this.btStart.Tag = "";
            this.btStart.Text = "Start";
            this.btStart.UseVisualStyleBackColor = true;
            this.btStart.Click += new System.EventHandler(this.btStart_Click);
            // 
            // btStop
            // 
            this.btStop.Location = new System.Drawing.Point(104, 320);
            this.btStop.Name = "btStop";
            this.btStop.Size = new System.Drawing.Size(75, 23);
            this.btStop.TabIndex = 5;
            this.btStop.Tag = "";
            this.btStop.Text = "Stop";
            this.btStop.UseVisualStyleBackColor = true;
            this.btStop.Click += new System.EventHandler(this.btStop_Click);
            // 
            // pictBoxu
            // 
            this.pictBoxu.Location = new System.Drawing.Point(288, 112);
            this.pictBoxu.Name = "pictBoxu";
            this.pictBoxu.Size = new System.Drawing.Size(500, 500);
            this.pictBoxu.TabIndex = 6;
            this.pictBoxu.TabStop = false;
            // 
            // lbtestu
            // 
            this.lbtestu.AutoSize = true;
            this.lbtestu.Location = new System.Drawing.Point(160, 32);
            this.lbtestu.Name = "lbtestu";
            this.lbtestu.Size = new System.Drawing.Size(30, 13);
            this.lbtestu.TabIndex = 7;
            this.lbtestu.Text = "testu";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Species u:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Species v:";
            // 
            // lbtestv
            // 
            this.lbtestv.AutoSize = true;
            this.lbtestv.Location = new System.Drawing.Point(160, 128);
            this.lbtestv.Name = "lbtestv";
            this.lbtestv.Size = new System.Drawing.Size(30, 13);
            this.lbtestv.TabIndex = 10;
            this.lbtestv.Text = "testv";
            // 
            // btNext
            // 
            this.btNext.Location = new System.Drawing.Point(16, 352);
            this.btNext.Name = "btNext";
            this.btNext.Size = new System.Drawing.Size(75, 23);
            this.btNext.TabIndex = 11;
            this.btNext.Text = "Next Step";
            this.btNext.UseVisualStyleBackColor = true;
            this.btNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "(top left corner)";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 152);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "(top left corner)";
            // 
            // pictBoxv
            // 
            this.pictBoxv.Location = new System.Drawing.Point(816, 112);
            this.pictBoxv.Name = "pictBoxv";
            this.pictBoxv.Size = new System.Drawing.Size(500, 500);
            this.pictBoxv.TabIndex = 15;
            this.pictBoxv.TabStop = false;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "SPECIES U";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(816, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 17;
            this.label6.Text = "SPECIES V";
            // 
            // rbFast
            // 
            this.rbFast.AutoSize = true;
            this.rbFast.Location = new System.Drawing.Point(8, 24);
            this.rbFast.Name = "rbFast";
            this.rbFast.Size = new System.Drawing.Size(45, 17);
            this.rbFast.TabIndex = 20;
            this.rbFast.TabStop = true;
            this.rbFast.Text = "Fast";
            this.rbFast.UseVisualStyleBackColor = true;
            this.rbFast.CheckedChanged += new System.EventHandler(this.rbFast_CheckedChanged);
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(56, 24);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(58, 17);
            this.rbNormal.TabIndex = 21;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal";
            this.rbNormal.UseVisualStyleBackColor = true;
            this.rbNormal.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbSlow
            // 
            this.rbSlow.AutoSize = true;
            this.rbSlow.Location = new System.Drawing.Point(120, 24);
            this.rbSlow.Name = "rbSlow";
            this.rbSlow.Size = new System.Drawing.Size(48, 17);
            this.rbSlow.TabIndex = 22;
            this.rbSlow.TabStop = true;
            this.rbSlow.Text = "Slow";
            this.rbSlow.UseVisualStyleBackColor = true;
            this.rbSlow.CheckedChanged += new System.EventHandler(this.rbSlow_CheckedChanged);
            // 
            // groupBoxSpeed
            // 
            this.groupBoxSpeed.Controls.Add(this.rbSlow);
            this.groupBoxSpeed.Controls.Add(this.rbFast);
            this.groupBoxSpeed.Controls.Add(this.rbNormal);
            this.groupBoxSpeed.Location = new System.Drawing.Point(16, 200);
            this.groupBoxSpeed.Name = "groupBoxSpeed";
            this.groupBoxSpeed.Size = new System.Drawing.Size(176, 56);
            this.groupBoxSpeed.TabIndex = 23;
            this.groupBoxSpeed.TabStop = false;
            this.groupBoxSpeed.Text = "Speed";
            // 
            // btJump
            // 
            this.btJump.Location = new System.Drawing.Point(16, 424);
            this.btJump.Name = "btJump";
            this.btJump.Size = new System.Drawing.Size(104, 23);
            this.btJump.TabIndex = 24;
            this.btJump.Text = "Jump to Timestep:";
            this.btJump.UseVisualStyleBackColor = true;
            this.btJump.Click += new System.EventHandler(this.btJump_Click);
            // 
            // tbJump
            // 
            this.tbJump.Location = new System.Drawing.Point(128, 424);
            this.tbJump.Name = "tbJump";
            this.tbJump.Size = new System.Drawing.Size(80, 20);
            this.tbJump.TabIndex = 25;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(16, 464);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 13);
            this.lbStatus.TabIndex = 26;
            // 
            // progbar
            // 
            this.progbar.Location = new System.Drawing.Point(16, 456);
            this.progbar.Name = "progbar";
            this.progbar.Size = new System.Drawing.Size(192, 23);
            this.progbar.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(568, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 13);
            this.label7.TabIndex = 29;
            this.label7.Text = "Diffusion Coefficient: ";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(1104, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 13);
            this.label8.TabIndex = 30;
            this.label8.Text = "Diffusion Coefficient: ";
            // 
            // tbDiffu
            // 
            this.tbDiffu.Location = new System.Drawing.Point(680, 80);
            this.tbDiffu.Name = "tbDiffu";
            this.tbDiffu.Size = new System.Drawing.Size(100, 20);
            this.tbDiffu.TabIndex = 31;
            // 
            // tbDiffv
            // 
            this.tbDiffv.Location = new System.Drawing.Point(1216, 80);
            this.tbDiffv.Name = "tbDiffv";
            this.tbDiffv.Size = new System.Drawing.Size(100, 20);
            this.tbDiffv.TabIndex = 32;
            // 
            // btSaveu
            // 
            this.btSaveu.Location = new System.Drawing.Point(192, 320);
            this.btSaveu.Name = "btSaveu";
            this.btSaveu.Size = new System.Drawing.Size(75, 23);
            this.btSaveu.TabIndex = 33;
            this.btSaveu.Text = "Save u";
            this.btSaveu.UseVisualStyleBackColor = true;
            this.btSaveu.Click += new System.EventHandler(this.btSaveu_Click);
            // 
            // btSavev
            // 
            this.btSavev.Location = new System.Drawing.Point(192, 352);
            this.btSavev.Name = "btSavev";
            this.btSavev.Size = new System.Drawing.Size(75, 23);
            this.btSavev.TabIndex = 34;
            this.btSavev.Text = "Save v";
            this.btSavev.UseVisualStyleBackColor = true;
            this.btSavev.Click += new System.EventHandler(this.btSavev_Click);
            // 
            // cbSave
            // 
            this.cbSave.AutoSize = true;
            this.cbSave.Location = new System.Drawing.Point(184, 536);
            this.cbSave.Name = "cbSave";
            this.cbSave.Size = new System.Drawing.Size(15, 14);
            this.cbSave.TabIndex = 35;
            this.cbSave.UseVisualStyleBackColor = true;
            // 
            // lbSave
            // 
            this.lbSave.AutoSize = true;
            this.lbSave.Location = new System.Drawing.Point(8, 536);
            this.lbSave.Name = "lbSave";
            this.lbSave.Size = new System.Drawing.Size(61, 13);
            this.lbSave.TabIndex = 36;
            this.lbSave.Text = "Save every";
            // 
            // tbSave
            // 
            this.tbSave.Location = new System.Drawing.Point(72, 536);
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(48, 20);
            this.tbSave.TabIndex = 37;
            this.tbSave.TextChanged += new System.EventHandler(this.tbSave_TextChanged);
            // 
            // lbS
            // 
            this.lbS.AutoSize = true;
            this.lbS.Location = new System.Drawing.Point(128, 536);
            this.lbS.Name = "lbS";
            this.lbS.Size = new System.Drawing.Size(47, 13);
            this.lbS.TabIndex = 38;
            this.lbS.Text = "seconds";
            // 
            // lbSave2
            // 
            this.lbSave2.AutoSize = true;
            this.lbSave2.Location = new System.Drawing.Point(40, 568);
            this.lbSave2.Name = "lbSave2";
            this.lbSave2.Size = new System.Drawing.Size(105, 13);
            this.lbSave2.TabIndex = 39;
            this.lbSave2.Text = "Minimum value is 1.0";
            // 
            // frmMACA
            // 
            this.AcceptButton = this.btStart;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1372, 731);
            this.Controls.Add(this.lbSave2);
            this.Controls.Add(this.lbS);
            this.Controls.Add(this.tbSave);
            this.Controls.Add(this.lbSave);
            this.Controls.Add(this.cbSave);
            this.Controls.Add(this.btSavev);
            this.Controls.Add(this.btSaveu);
            this.Controls.Add(this.tbDiffv);
            this.Controls.Add(this.tbDiffu);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.progbar);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.tbJump);
            this.Controls.Add(this.btJump);
            this.Controls.Add(this.groupBoxSpeed);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.pictBoxv);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btNext);
            this.Controls.Add(this.lbtestv);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbtestu);
            this.Controls.Add(this.pictBoxu);
            this.Controls.Add(this.btStop);
            this.Controls.Add(this.btStart);
            this.Controls.Add(this.lbtime);
            this.Controls.Add(this.tbTime);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMACA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "test";
            this.Text = "MACA";
            this.Activated += new System.EventHandler(this.frmMACA_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMACA_FormClosing);
            this.Load += new System.EventHandler(this.MACA_Load);
            this.Resize += new System.EventHandler(this.MACA_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictBoxv)).EndInit();
            this.groupBoxSpeed.ResumeLayout(false);
            this.groupBoxSpeed.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ToolStripMenuItem parametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.TextBox tbTime;
        private System.Windows.Forms.Label lbtime;
        private System.Windows.Forms.ToolStripMenuItem showGraphToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.ServiceProcess.ServiceController serviceController1;
        private System.Windows.Forms.Button btStart;
        private System.Windows.Forms.Button btStop;
        private System.Windows.Forms.PictureBox pictBoxu;
        private System.Windows.Forms.Label lbtestu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbtestv;
        private System.Windows.Forms.Button btNext;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictBoxv;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.RadioButton rbFast;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbSlow;
        private System.Windows.Forms.GroupBox groupBoxSpeed;
        private System.Windows.Forms.Button btJump;
        private System.Windows.Forms.TextBox tbJump;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.ProgressBar progbar;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbDiffu;
        private System.Windows.Forms.TextBox tbDiffv;
        private System.Windows.Forms.Button btSaveu;
        private System.Windows.Forms.Button btSavev;
        private System.Windows.Forms.CheckBox cbSave;
        private System.Windows.Forms.Label lbSave;
        private System.Windows.Forms.TextBox tbSave;
        private System.Windows.Forms.Label lbS;
        private System.Windows.Forms.Label lbSave2;
    }
}

