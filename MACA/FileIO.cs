using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;

namespace MACA
{
    class FileIO
    {
        public FileIO()
        {

        }

        public List<Parameters> Load(string path)
        {
            List<string[]> parsedData = new List<string[]>();
            List<Parameters> plist = new List<Parameters>();

            try
            {
                using (StreamReader readFile = new StreamReader(path))
                {
                    string line;
                    string[] row;

                    while ((line = readFile.ReadLine()) != null)
                    {
                        row = line.Split(',');
                        parsedData.Add(row);
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            for (int j = 0; j < parsedData.Count; j++)
            { 
                plist.Add(new Parameters
                (
                (string)((parsedData[j])[0]),Convert.ToInt32(((parsedData[j])[1])),
                Convert.ToInt32(((parsedData[j])[2])),Convert.ToDouble(((parsedData[j])[3])),
                Convert.ToDouble(((parsedData[j])[4])),Convert.ToDouble(((parsedData[j])[5])),
                Convert.ToDouble(((parsedData[j])[6])),Convert.ToDouble(((parsedData[j])[7])),
                Convert.ToInt32(((parsedData[j])[8])),Convert.ToDouble((parsedData[j])[9])                
                ));
                
            }

            return plist;
        }

        // Adds new parameter p to list settings and updates the settings.csv file
        public void Save(List<Parameters> settings, string path, Parameters p)
        {
            TextWriter tw = File.CreateText(path+"\\settings.csv");

            settings.Add(p);
            
            // Save settings to settings.csv
            for (int j = 0; j < settings.Count(); j++)
            {
                //Save parameters
                tw.Write("{0},", settings[j].Psetname);
                tw.Write("{0},", settings[j].Ru);
                tw.Write("{0},", settings[j].Rv);
                tw.Write("{0},", settings[j].A);
                tw.Write("{0},", settings[j].B);
                tw.Write("{0},", settings[j].U0);
                tw.Write("{0},", settings[j].V0);
                tw.Write("{0},", settings[j].Step);
                tw.Write("{0},", settings[j].N);
                tw.WriteLine("{0}", settings[j].Maxtime);                
            }

            tw.Close();
        }

        // Creates initial settings file
        public void CreateCsv(List<Parameters> settings, string path)
        {            
            TextWriter tw = File.CreateText(path);
            
            // Save settings to settings.csv
            for (int j = 0; j < settings.Count(); j++)
            {
                //Save parameters
                tw.Write("{0},", settings[j].Psetname);
                tw.Write("{0},", settings[j].Ru);
                tw.Write("{0},", settings[j].Rv);
                tw.Write("{0},", settings[j].A);
                tw.Write("{0},", settings[j].B);
                tw.Write("{0},", settings[j].U0);
                tw.Write("{0},", settings[j].V0);
                tw.Write("{0},", settings[j].Step);
                tw.Write("{0},", settings[j].N);
                tw.WriteLine("{0}", settings[j].Maxtime);
            }

            tw.Close();
        }
    }
}
