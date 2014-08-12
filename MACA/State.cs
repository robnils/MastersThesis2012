using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MACA
{
    // State of cells 
    // This is only programmed for one species (called u here) but
    // creating different objects allows the use of multiple species
    public class State
    {
        //Parameters p;
        private double[,] u;
        public double[,] U
        {
            get { return u; }
            set { u = value; }
        }

        private double[,] utemp;
        public double[,] Utemp
        {
            get { return utemp; }
            set { utemp = value; }
        }

        private double[,] vsum;
        public double[,] Vsum
        {
            get { return vsum; }
            set { vsum = value; }
        }

        private double[,] hsum;
        public double[,] Hsum
        {
            get { return hsum; }
            set { hsum = value; }
        }

        private double t; // Current time
        public double T
        {
            get { return t; }
            set { t = value; }
        }

        private int n; // Number of cells in grid
        public int N
        {
            get { return n; }
            set { n = value; }
        }

        public State(Parameters p)
        {
            t = 0.0;
            N = p.N;

            // Four arrays are need to describe the state u
            // using the moving average method
            u = new double[p.N, p.N];
            utemp = new double[p.N, p.N];
            hsum = new double[p.N, p.N];
            vsum = new double[p.N, p.N];            
        }

        // Initialise the states with user-defined initial u0,v0
        public void Initialise(State s, Parameters p, int a)
        {
            // a = 0 refers to species u
            // a = 1 refers to species v
            if (a == 0)            
                for (int i = 0; i < p.N; i++)                
                    for (int j = 0; j < p.N; j++)                    
                        s.U[i, j] = p.U0;

            else if (a == 1)            
                for (int i = 0; i < p.N; i++)                
                    for (int j = 0; j < p.N; j++)                    
                        s.U[i, j] = p.V0;
        }

    }
}
