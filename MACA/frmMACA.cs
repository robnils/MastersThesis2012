using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace MACA
{
    /// <summary>
    /// This program was created by Robert Nils Hilliard, 2012. 
    /// </summary>
    
    public partial class frmMACA : Form
    {
        private SaveFileDialog sfd;
        private Parameters p; // Contains all parameters
        private State su; // State of species u
        private State sv; // State of species v
        private Rules rules; // CA ruleset
        private Bitmap bu; // For graphing species u
        private Bitmap bv; // For graphing species v
        private FastBitmapAccess fu;   // For graphing species u
        private FastBitmapAccess fv;   // For graphing species v
        private BindingSource bs; // Binding source for display parameters        
        private Timer time; // Time used in timer
        private double diffu, diffv; // Diffusion coefficients
        private double jump; // Represents the "jump" time
        private double tsave; // The time in the tbSave textback
        private double t; // Time
        private int bitmapsize; // Size of the bitmap - corresponds to the pictureboxes
        private int i, j; // Counters   
        private string str, str2; // Used for display   
        private double[] average; // Average of state u and v
        private string path = Directory.GetCurrentDirectory(); // Current working directory
        private string pathpics; // Directory of images (including average data)
        private string[] pathpset; // Path to parameter set created folders
        private TextWriter twu; // Used in creating outputed data of averages
        private TextWriter twv;

        public frmMACA()
        {
            InitializeComponent();

            // Initialises variables, buttons, text boxes, etc
            Initialisations();
        }

        // This just groups the different initialisations 
        private void Initialisations()
        {

            // Variable initialisations
            t = 0.0;
            i = j = 0;
            bitmapsize = pictBoxu.Size.Width; // Bitmap size equals the size of the picturebox
            jump = 1.0;
            str = str2 = null;

            // For testing purposes
            lbtestu.Text = null;
            lbtestv.Text = null;

            // Initialise objects
            p = new Parameters();
            bs = new BindingSource();
            rules = new Rules();
            average = new double[2];
            sfd = new SaveFileDialog();
            pathpset = new string[2];

            // Create a subfolder within working directory called Images
            // Set this to be the initial directory
            pathpics = string.Format("{0}", path) + "\\Images\\";
            Directory.CreateDirectory(pathpics);
            sfd.InitialDirectory = pathpics;
            
            // Initialize the timer
            time = new Timer();
            time.Interval = 100;
            time.Tick += frm_Tick;

            // *** Initialisations ***
            diffu = p.Ru * (p.Ru + 1) * p.Step;
            diffu /= 6;
            diffv = p.Rv * (p.Rv + 1) * p.Step;
            diffv /= 6;
            tbDiffu.Text = Convert.ToString(diffu);
            tbDiffv.Text = Convert.ToString(diffv);

            rbFast.Checked = true;
            tbTime.Text = "0.00";
            tbTime.Enabled = false;
            tbJump.Text = Convert.ToString(jump);
            btJump.Enabled = true;
            tbDiffu.Enabled = false;
            tbDiffv.Enabled = false;
            btStop.Enabled = false;
            progbar.Visible = false;
            lbSave2.Visible = false;
            tbSave.Text = "1.0";
            cbSave.Checked = true;         
        }

        private void MACA_Load(object sender, EventArgs e)
        {
            frmParameterBox frmp = new frmParameterBox();            
            DialogResult d = frmp.ShowDialog();

            if (d == DialogResult.OK)
            {
                // Assign user-defined parameters         
                p.Psetname = frmp.Pdata.Psetname;
                p.Ru = frmp.Pdata.Ru;
                p.Rv = frmp.Pdata.Rv;
                p.U0 = frmp.Pdata.U0;
                p.V0 = frmp.Pdata.V0;
                p.A = frmp.Pdata.A;
                p.B = frmp.Pdata.B;
                p.Step = frmp.Pdata.Step;
                p.N = frmp.Pdata.N;
                p.Maxtime = frmp.Pdata.Maxtime;
            }

            // Maximise the main window as default
            this.WindowState = FormWindowState.Maximized;

            // Initialise states u, v with parameters p and display them
            su = new State(p);
            sv = new State(p);     
            su.Initialise(su, p, 0);
            sv.Initialise(sv, p, 1);

            // Truncatate states probabilistically if using random initial conditions
            rules.Initialise(p);
            rules.TruncateGeneral(su);
            rules.TruncateGeneral(sv);

            Display(su, sv);

            // Initial imaging              
            bu = new Bitmap(bitmapsize, bitmapsize); // New image of desired size (user specified) 
            bv = new Bitmap(bitmapsize, bitmapsize); // It's scaled acording to the size of p.N
            pictBoxu.Image = bu; // Assign image to picturebox
            pictBoxv.Image = bv;
            fu = new FastBitmapAccess(bu, p);
            fv = new FastBitmapAccess(bv, p);

            try
            {
                // Update display
                DisplayFull(fu, su);
                DisplayFull(fv, sv);
                pictBoxu.Refresh();
                pictBoxv.Refresh();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();                
            }

            // Update and display diffusion coefficients
            diffu = p.Ru * (p.Ru + 1) * p.Step;
            diffu /= 6;
            diffv = p.Rv * (p.Rv + 1) * p.Step;
            diffv /= 6;
            tbDiffu.Text = Convert.ToString(diffu);
            tbDiffv.Text = Convert.ToString(diffv);

            // Create directories for images
            //  if (p.Psetname == null) 
            //    p.Psetname = "Basic Configuration"; // if user hits "cancel" upon opening

            // Create the directory \p.Psetname\ & add the average_u,v.csv files to ti
            pathpset[0] = pathpics + "\\" + p.Psetname;
            pathpset[1] = pathpics + "\\" + p.Psetname;
            Directory.CreateDirectory(pathpset[0]);
            Directory.CreateDirectory(pathpset[1]);
            twu = File.CreateText(string.Format("{0}\\Average_u.csv", pathpset[0]));
            twv = File.CreateText(string.Format("{0}\\Average_v.csv", pathpset[1]));

            pathpset[0] += "\\species_u\\";
            pathpset[1] += "\\species_v\\";
            Directory.CreateDirectory(pathpset[0]);
            Directory.CreateDirectory(pathpset[1]);
        }
          
        private void MACA_Resize(object sender, EventArgs e)
        {
            pictBoxu.Refresh();
            pictBoxv.Refresh();
            this.Refresh();
        }

        // Display a bitmap of given state s
        private void DisplayFull(FastBitmapAccess f, State s)
        {
            f.ManipulateImage(s, (int)(bitmapsize / p.N)); // Draw           
        }

        private void frm_Tick(object sender, EventArgs e)
        {
            if (t >= p.Maxtime)
            {
                timer.Stop();
                btStop_Click(sender, e);
                return;
            }

            t = Convert.ToDouble(tbTime.Text); // Current time
            t += p.Step; // Add the step
            tbTime.Text = Convert.ToString(t); // Display it
            su.T = t; // Store time in state objects
            sv.T = t;

            // Iterate simulation and save to file            
            average = rules.Iterate(su, sv);
            twu.WriteLine("{0},{1}", t, average[0]);
            twv.WriteLine("{0},{1}", t, average[1]);

            Display(su, sv);
            DisplayFull(fu, su);
            DisplayFull(fv, sv);
            pictBoxu.Refresh();
            pictBoxv.Refresh();   // Refresh picture box

            // Save images regularly            
            if (cbSave.Checked == true)
            {
                if ((t % tsave) == 0)
                {
                    SavePNG(bu, t, 0);
                    SavePNG(bv, t, 1);
                }
            }

            this.Refresh();
        }

        private void parametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btStop_Click(sender, e); // Stop everything when user opens parameter window
            frmParameterBox frmp = new frmParameterBox();
            
            // Save current parameter values
            frmp.Pdata.Psetname = p.Psetname;
            frmp.Pdata.Ru = p.Ru;
            frmp.Pdata.Rv = p.Rv;
            frmp.Pdata.A = p.A;
            frmp.Pdata.B = p.B;
            frmp.Pdata.U0 = p.U0;
            frmp.Pdata.V0 = p.V0;
            frmp.Pdata.Step = p.Step;
            frmp.Pdata.N = p.N;
            frmp.Pdata.Maxtime = p.Maxtime;
                        
            // Save changed values 
            // This updates quite a lot of things 
            DialogResult d = frmp.ShowDialog();
            if (d == DialogResult.OK)
            {
                // Assign user-defined parameters
                p.Psetname = frmp.Pdata.Psetname;
                p.Ru = frmp.Pdata.Ru;
                p.Rv = frmp.Pdata.Rv;
                p.U0 = frmp.Pdata.U0;
                p.V0 = frmp.Pdata.V0;
                p.A = frmp.Pdata.A;
                p.B = frmp.Pdata.B;
                p.Step = frmp.Pdata.Step;
                p.N = frmp.Pdata.N;
                p.Maxtime = frmp.Pdata.Maxtime;                
                
                tbTime.Text = "0.00";
                btJump.Enabled = true;

                // Create new state objects
                su = new State(p);
                sv = new State(p);                

                // If user changes parameters, update the states & display
                su.Initialise(su, p, 0);
                sv.Initialise(sv, p, 1);

                // Truncatate states probabilistically if using random initial conditions
                rules.Initialise(p);
                rules.TruncateGeneral(su);
                rules.TruncateGeneral(sv);

                Display(su, sv);
                
                // Reinitialise imaging if parameters are changed
                bu = new Bitmap(bitmapsize, bitmapsize);
                bv = new Bitmap(bitmapsize, bitmapsize);
                pictBoxu.Image = bu;
                pictBoxv.Image = bv;
                fu = new FastBitmapAccess(bu, p);
                fv = new FastBitmapAccess(bv, p);

                DisplayFull(fu, su);
                DisplayFull(fv, sv);
                pictBoxu.Refresh();
                pictBoxv.Refresh();   // Refresh picture box

                // Update and display diffusion coefficients
                diffu = p.Ru * (p.Ru + 1) * p.Step;
                diffu /= 6;
                diffv = p.Rv * (p.Rv + 1) * p.Step;
                diffv /= 6;
                tbDiffu.Text = Convert.ToString(diffu);
                tbDiffv.Text = Convert.ToString(diffv);

                twu.Close();
                twv.Close();

                // Create directories for averages
                pathpset[0] = pathpics + "\\" + p.Psetname;
                pathpset[1] = pathpics + "\\" + p.Psetname;
                Directory.CreateDirectory(pathpset[0]);
                Directory.CreateDirectory(pathpset[1]);
                twu = File.CreateText(string.Format("{0}\\Average_u.csv", pathpset[0]));
                twv = File.CreateText(string.Format("{0}\\Average_v.csv", pathpset[1]));

                // Create directories for images
                pathpset[0] += "\\species_u\\";
                pathpset[1] += "\\species_v\\";
                Directory.CreateDirectory(pathpset[0]);
                Directory.CreateDirectory(pathpset[1]);
            }

            else if (d == DialogResult.Cancel)
            {
                frmp.Close();                
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        // Basic display
        private void Display(State su, State sv)
        {
            str = null;
            str2 = null;

            // Only display top left corner
            if (p.N < 6)
            {
                for (i = 0; i < p.N; i++)
                {
                    for (j = 0; j < p.N; j++)
                    {
                        str += Convert.ToString(Math.Round(su.U[i, j], 2)) + " ";
                        str2 += Convert.ToString(Math.Round(sv.U[i, j], 2)) + " ";
                    }
                    str += "\n";
                    str2 += "\n";
                }
            }

            else
            {
                for (i = 0; i < 5; i++)
                {
                    for (j = 0; j < 5; j++)
                    {
                        str += Convert.ToString(Math.Round(su.U[i, j], 2)) + " ";
                        str2 += Convert.ToString(Math.Round(sv.U[i, j], 2)) + " ";
                    }
                    str += "\n";
                    str2 += "\n";
                }
            }
            lbtestu.Text = str;
            lbtestv.Text = str2;
        }          

        private void btStart_Click(object sender, EventArgs e)
        {           
            rules.Initialise(p);

            timer.Start();
            btStart.Enabled = false;
            btStop.Enabled = true;
            btNext.Enabled = false;
            btSaveu.Enabled = false;
            btSavev.Enabled = false;
            tbSave.Enabled = false;

            tsave = Convert.ToDouble(tbSave.Text);
        }

        private void btStop_Click(object sender, EventArgs e)
        {
            timer.Stop();
            btStop.Enabled = false;
            btStart.Enabled = true;
            btNext.Enabled = true;
            btSaveu.Enabled = true;
            btSavev.Enabled = true;
            tbSave.Enabled = true;
        }

        // Proceed one iteration at a time
        private void btNext_Click(object sender, EventArgs e)
        {
            frm_Tick(sender, e);            
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            timer.Interval = 350;
        }

        private void rbFast_CheckedChanged(object sender, EventArgs e)
        {
            timer.Interval = 1;
        }

        private void rbSlow_CheckedChanged(object sender, EventArgs e)
        {
            timer.Interval = 1000;
        }  

        private void btJump_Click(object sender, EventArgs e)
        {
            jump = Convert.ToDouble(tbJump.Text);
            p.Maxtime += jump; // So that the iteration can run after jump
            int nsteps = (int)(jump / p.Step); // Number of steps
            int i = 0; // Counter
            TimeSpan t;
            string timetaken;

            // Initialise progressbar
            progbar.Visible = true;
            progbar.Value = 1;
            progbar.Minimum = 1;
            progbar.Maximum = nsteps;              

            // Calculate time taken for one iteration by averaging 10
            rules.Initialise(p);
            var beginTime = DateTime.Now;
            for (i = 1; i <= 10; i++)
                rules.Iterate(su, sv);                     
            var endTime = DateTime.Now;
            var elaspedTime = (endTime - beginTime).TotalSeconds;
            elaspedTime /= 10;

            t = TimeSpan.FromSeconds(elaspedTime * nsteps);            
            timetaken = string.Format("{0:D2}h:{1:D2}m:{2:D2}s:{3:D3}ms",
                                    t.Hours, t.Minutes, t.Seconds, t.Milliseconds);

            MessageBox.Show(string.Format("This will aproximately {0}", timetaken), 
                "Time to complete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Reinitialise states
            su.Initialise(su, p, 0);
            sv.Initialise(sv, p, 1);

            // Truncatate states probabilistically if using random initial conditions
            rules.Initialise(p);
            rules.TruncateGeneral(su);
            rules.TruncateGeneral(sv);

            while (i <= nsteps)
            {
                // Iterate simulation
                average = rules.Iterate(su, sv);

                // Display
                DisplayFull(fu, su);
                DisplayFull(fv, sv);
                pictBoxu.Refresh();
                pictBoxv.Refresh();

                // Save data to file
                twu.WriteLine("{0},{1}", (i * p.Step), average[0]);
                twv.WriteLine("{0},{1}", (i * p.Step), average[1]);

                // Save images regularly            
                if (cbSave.Checked == true)
                {
                    if (((i * p.Step) % tsave) == 0)
                    {
                        SavePNG(bu, (i * p.Step), 0);
                        SavePNG(bv, (i * p.Step), 1);
                    }
                }

                tbTime.Text = Convert.ToString(i * p.Step); // Display current time                 
                progbar.Value = i; // Increment progressbar

                this.Refresh(); // tbTime doesn't update otherwise
                i++;
            }
            btJump.Enabled = true;
        }

        private void frmMACA_Activated(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void frmMACA_FormClosing(object sender, FormClosingEventArgs e)
        {
            twu.Close();
            twv.Close();
        }

        // Saves a chosen state (given by the appropriate bitmap) 
        // to an image file chosen by user
        private void SaveImage(Bitmap b)       
        {
            FileStream fs;
   
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg|Bitmap Image|*.bmp|GIF Image|*.gif|All files|*.*";
            sfd.FileName = "State";
            sfd.Title = "Save State";
            sfd.RestoreDirectory = true;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                fs = (FileStream)sfd.OpenFile(); 
                try
                {
                    // Saves the image in the appropriate image format taken from user
                    switch (sfd.FilterIndex)
                    {
                        case 1:
                            b.Save(fs, System.Drawing.Imaging.ImageFormat.Png);
                            break;

                        case 2:
                            b.Save(fs, System.Drawing.Imaging.ImageFormat.Jpeg);
                            break;

                        case 3:
                            b.Save(fs, System.Drawing.Imaging.ImageFormat.Bmp);
                            break;

                        case 4:
                            b.Save(fs, System.Drawing.Imaging.ImageFormat.Gif);
                            break;
                        case 5:
                            MessageBox.Show("You must choose an image format in order to save the file correctly.");
                            break;
                    }
                }

                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }                
                fs.Close();
            }
        }

        // Saves image to png in a predefined directory
        // Used for saving many images regularly 
        private void SavePNG(Bitmap b, double t, int i)
        {
            string path;
            // If state u
            if (i == 0)            
                path = pathpset[0] + p.Psetname + "_u_t_" + Convert.ToString(t) + ".png";
            
            else           
                path = pathpset[1] + p.Psetname + "_v_t_" + Convert.ToString(t) + ".png";
            
            try
            {                 
                b.Save(path,System.Drawing.Imaging.ImageFormat.Png);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
            }
        }
        
        private void btSaveu_Click(object sender, System.EventArgs e)
        {
            SaveImage(bu);
        }

        private void btSavev_Click(object sender, EventArgs e)
        {
            SaveImage(bv);
        }

        private void tbSave_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (Convert.ToDouble(tbSave.Text) < 1.0)
                {
                    tbSave.Text = "";
                    lbSave2.Visible = true;
                }
            }

            // Stop user from entering bad things
            catch (Exception ex)
            {                
                tbSave.Text = "";
                lbSave2.Visible = true;
                lbSave2.Text = ex.Message;
            }
        }
    }
}
