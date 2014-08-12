using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MACA
{
    public class Parameters
    {      
        private string psetname; // Name of parameter set
        public string Psetname
        {
            get { return psetname; }
            set { psetname = value; }
        }

        // The constraints on the following parameters without extra comments
        // are just that they're greater than or equal to zero
        private int ru;
        public int Ru
        {
            get { return ru; }
            set { if (ru >= 0)ru = value; }
        }

        private int rv;
        public int Rv
        {
            get { return rv; }
            set { if (rv >= 0) rv = value; }
        }

        private double u0;
        public double U0
        {
            get { return u0; }
            set { if (u0 >= 0) u0 = value; }
        }

        private double v0;
        public double V0
        {
            get { return v0; }
            set { if (v0 >= 0) v0 = value; }
        }

        private double a;
        public double A
        {
            get { return a; }
            set { if(a >= 0) a = value; }
        }

        private double b;
        public double B
        {
            get { return b; }
            set { if (b >= 0) b = value; }
        }

        // Step must be greater than 0 and less than or equal to 0.01
        // or the reaction contribution gets out of hand
        private double step;
        public double Step
        {
            get { return step; }
            set { if ((step > 0) && (step <= 0.01))step = value; }
        }

        // n must be odd and a multiple of 5 is a good choice
        private int n;
        public int N
        {
            get { return n; }
            set { if ((n % 5 == 0)) n = value; }
        }

        // Greater than zero and to ensure p.Step
        // divides in nicely, I've just floored the maxtime
        private double maxtime;
        public double Maxtime
        {
            get { return maxtime; }
            set 
            {
                maxtime = Math.Floor(maxtime);                
                if (maxtime > 0)
                    maxtime = value; 
            }
        }

        public Parameters()
        {
            // Default values
            ru = 1;
            rv = 2;
            a = 3;
            b = 9;
            u0 = 2;
            v0 = 1;
            step = 0.01;
            n = 5;
            maxtime = 5;
        }

        // Constructor to create your own parameter set
        public Parameters(string pset, int ru, int rv, double a, double b, double u0, 
            double v0, double step, int n, double maxtime)
        {
            this.psetname = pset;
            this.ru = ru;
            this.rv = rv;
            this.a = a;
            this.b = b;
            this.u0 = u0;
            this.v0 = v0;
            this.step = step;
            this.n = n;
            this.maxtime = maxtime;
        }     
    }
}
