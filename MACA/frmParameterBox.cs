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
    public partial class frmParameterBox : Form
    {        
        private BindingNavigator bsnav;
        private List<Parameters> plist = new List<Parameters>();
        private BindingSource bs;
        private Random r;

        private Parameters pdata;
        public Parameters Pdata
        {
            get { return pdata; }
        }

        public frmParameterBox()
        {
            InitializeComponent();

            btSave.Enabled = false; // The button is buggy

            bs = new BindingSource();
            bsnav = new BindingNavigator();
            r = new Random((int)DateTime.Now.Ticks);
            pdata = new Parameters(); // The chosen parameter set sent to main program       
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            pdata = (Parameters)bs.Current;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void frmParameterBox_Load(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory();
            FileIO fio = new FileIO();

            path = String.Format("{0}", path) + "\\settings.csv";

            /* Issues with this code, it can be unpredictable
            // If the file exists, open it, else create it
            if (File.Exists(path))
                plist = fio.Load(path);
            
            else
            {
                DefaultPSets();         
                fio.CreateCsv(plist, path);  
            }*/

            DefaultPSets();
            fio.CreateCsv(plist, path); 

            // Set up combobox with binding source 
            bs.DataSource = plist;
            bsnav.BindingSource = bs;
            tbRu.DataBindings.Add("Text", bs, "Ru");
            tbRv.DataBindings.Add("Text", bs, "Rv");
            tbu0.DataBindings.Add("Text", bs, "U0");
            tbv0.DataBindings.Add("Text", bs, "V0");
            tba.DataBindings.Add("Text", bs, "A");
            tbb.DataBindings.Add("Text", bs, "B");
            tbstep.DataBindings.Add("Text", bs, "Step");
            tbgrid.DataBindings.Add("Text", bs, "N");
            tbmaxtime.DataBindings.Add("Text", bs, "Maxtime");

            comboxPar.DataBindings.Add("Text", bs, "Psetname");
            comboxPar.DisplayMember = "Psetname";
            comboxPar.DataSource = bs;
            comboxPar.Refresh();
        }

        // Default set of parameter sets
        private void DefaultPSets()
        {
            // *** Set up default parameter sets ***
            // This set is for finding the Hopf bifurcation
            plist.Add(new Parameters("Hopf in Region A (a_1.1, b_1)", 1, 2, 1.1, 1.0, 1.1 + (0.1) * (1.1), (1.0 / 1.1) + (0.1) * (1.0 / 1.1), 0.01, 500, 100));
            plist.Add(new Parameters("Hopf in Region B (a_1.1, b_3)", 1, 2, 1.1, 3.0, 1.1 + (0.1) * (1.1), (3.0 / 1.1) + (0.1) * (3.0 / 1.1), 0.01, 500, 100));
            plist.Add(new Parameters("Hopf in Region C (a_1.1, b_5)", 1, 2, 1.1, 5.0, 1.1 + (0.1) * (1.1), (5.0 / 1.1) + (0.1) * (5.0 / 1.1), 0.01, 500, 100));
            plist.Add(new Parameters("Hopf in Region C (a_1.1, b_9)", 1, 2, 1.1, 9.0, 1.1 + (0.1) * (1.1), (9.0 / 1.1) + (0.1) * (9.0 / 1.1), 0.01, 500, 100));
            plist.Add(new Parameters("Hopf in Region C (a_1.1, b_10)", 1, 2, 1.1, 10.0, 1.1 + (0.1) * (1.1), (10.0 / 1.1) + (0.1) * (10.0 / 1.1), 0.01, 500, 100));
            
            // This set is for finding the Turing instability    
            plist.Add(new Parameters("Turing Pattern in Region C (a_1.1, b_5)", 1, 2, 1.1, 5, 1.1 + (0.1) * r.NextDouble(), (5.0 / 1.1) + (0.1) * r.NextDouble(), 0.01, 500, 100));
            plist.Add(new Parameters("Turing Pattern in Region C (a_1.1, b_9)", 1, 2, 1.1, 5, 1.1 + (0.1) * r.NextDouble(), (5.0 / 1.1) + (0.1) * r.NextDouble(), 0.01, 500, 100));           
            plist.Add(new Parameters("Turing Pattern in Region D (a_3, b_4)", 1, 2, 3, 4, 3 + (0.1) * r.NextDouble(), (4.0 / 3.0) + (0.1) * r.NextDouble(), 0.01, 500, 100));
            plist.Add(new Parameters("Turing Pattern in Region E (a_3, b_9)", 1, 2, 3, 9, 3 + (0.1) * r.NextDouble(), 3.0 + (0.1) * r.NextDouble(), 0.01, 500, 100));
            plist.Add(new Parameters("Turing Pattern in Region F (a_3, b_12)", 1, 2, 3, 12, 3 + (0.1) * r.NextDouble(), 4.0 + (0.1) * r.NextDouble(), 0.01, 500, 100));
            plist.Add(new Parameters("Turing Pattern in Region F (a_3, b_18)", 1, 2, 3, 18, 3 + (0.1) * r.NextDouble(), 6.0 + (0.1) * r.NextDouble(), 0.01, 500, 100));           
   
            // Other parameter sets            
            plist.Add(new Parameters("Basic Configuration", 1, 2, 3, 9, 2, 1, 0.01, 500, 100));
            plist.Add(new Parameters("Custom...", 0, 0, 0, 0, 0, 0, 0.01, 25, 5));  
        }

        private void btSave_Click(object sender, EventArgs e)
        {
            string path = Directory.GetCurrentDirectory(); // Directory of settings file
            FileIO fio = new FileIO();

            fio.Save(plist, path, (Parameters)bs.Current);    
        }
    }
}
