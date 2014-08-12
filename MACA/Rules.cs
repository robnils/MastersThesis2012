using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MACA
{
    // This class contains the three rulesets: Diffusion, Reaction and Truncation rules
    public class Rules
    {
        private Parameters p; // Instance of the parameter class
        private Random rand; // Random number generator   
        private double[,] f; // Reaction term for u
        private double[,] g; // Reaction term for v
        private double normu; // Normalisation coefficient for u   
        private double normv; // Normalisation coefficient for v 
        private int i, j, k; // Counter variables

        private int ru; // Neighbourhood of state u
        public int Ru
        {
            get { return ru; }
            set { ru = value; }
        }

        private int rv; // Neighbourhood of state v
        public int Rv
        {
            get { return rv; }
            set { rv = value; }
        }       

        public Rules()
        {
            rand = new Random((int)DateTime.Now.Ticks);
            p = new Parameters();            
        }

        // Initialise parameters
        public void Initialise(Parameters p)
        {
            i = j = k = 0;
            this.p = p;
            Ru = p.Ru;
            Rv = p.Rv;
            normu = 1.0 / ((2 * Ru + 1) * (2 * Ru + 1));
            normv = 1.0 / ((2 * Rv + 1) * (2 * Rv + 1));          
        } 
   
        // Diffusion process
        private void Diffusion(State s, int R)
        {
            // Initialise to zero
            for (i = 0; i < p.N; i++)   
                for (j = 0; j < p.N; j++)         
                    s.Hsum[i, j] = s.Vsum[i, j] = 0.0;

            // Diffusion along horizontal direction
            for (i = 0; i < p.N; i++)
            {
                // Needed to count the centre cell
                s.Hsum[i, R] = s.U[i, R];

                // Horizontal local average of cells (R, R +/- j)
                for (j = 1; j <= R; j++)
                    s.Hsum[i, R] += s.U[i, R + j] + s.U[i, R - j];

                // Horizontal sum with periodic BCs applied by modulus operator
                for (k = R; k < p.N; k++)
                    s.Hsum[i, (k + 1) % p.N] = s.Hsum[i, k] + s.U[i, (k + (R + 1)) % p.N] - s.U[i, (k - R) % p.N];                
            }

            // Needed because the above horizontal code sum doesn't "wrap around" for species v
            // This doesn't affect species u. It only corrects species v for Rv = 2.
            for (i = 0; i < p.N; i++)
                s.Hsum[i, 1] = s.Hsum[i, 0] + s.U[i, (p.N + (R + 1)) % p.N] - s.U[i, (p.N - R) % p.N];                

            // Diffusion along vertical direction
            for (i = 0; i < p.N; i++)
            {
                // Needed to count the centre cell
                s.Vsum[R, i] = s.Hsum[R, i]; 

                // Vertical local average of cells (R, R +/- j)
                for (j = 1; j <= R; j++)
                    s.Vsum[R, i] += s.Hsum[R + j, i] + s.Hsum[R - j, i];

                // Vertical sum with periodic BCs applied by modulus operator
                for (k = R; k < p.N; k++)
                    s.Vsum[(k + 1) % p.N, i] = s.Vsum[k, i] + s.Hsum[(k + (R + 1)) % p.N, i] - s.Hsum[(k - R) % p.N, i];
            }

            // Needed because the above vertical code sum doesn't "wrap around" for species v
            // This doesn't affect species u. It only corrects species v for Rv = 2.
            for (i = 0; i < p.N; i++)
                s.Vsum[1, i] = s.Vsum[0, i] + s.Hsum[(p.N + (R + 1)) % p.N, i] - s.Hsum[(p.N - R) % p.N, i]; 
        }

        // Reaction rule       
        private void Reaction(State su, State sv)
        {
            f = new double[p.N, p.N];
            g = new double[p.N, p.N];

            // Calculate f[i,j], g[i,j]
            // and u,v before truncation
            for (i = 0; i < p.N; i++)
            {
                for (j = 0; j < p.N; j++)
                {
                    f[i, j] = p.A - ((p.B + 1) * su.U[i, j]) + (su.U[i, j] * su.U[i, j] * sv.U[i, j]);
                    g[i, j] = p.B * su.U[i, j] - (su.U[i, j] * su.U[i, j] * sv.U[i, j]);

                    su.Utemp[i, j] = (float)(normu * su.Vsum[i, j] + p.Step * f[i, j]);
                    sv.Utemp[i, j] = (float)(normv * sv.Vsum[i, j] + p.Step * g[i, j]);
                }
            } 
        }

        // Truncate the results using a probablistic rule
        private void Truncate(State s)
        {
            float prob = 0; // Probability
            int trunc = 0; // Truncated result

            for (i = 0; i < p.N; i++)
            {
                for (j = 0; j < p.N; j++)
                {
                    trunc = (int)(Math.Floor(s.Utemp[i, j]));
                    prob = (float)(s.Utemp[i, j]) - trunc;

                    if (rand.NextDouble() <= prob)
                        s.U[i, j] = trunc + 1;
                    else
                        s.U[i, j] = trunc;
                    
                }
            }
        }

        // Truncate a passed in state (for initial random configurations)
        public void TruncateGeneral(State s)
        {
            float prob = 0;
            int trunc = 0;

            for (i = 0; i < p.N; i++)
            {
                for (j = 0; j < p.N; j++)
                {                    
                    trunc = (int)(Math.Floor(s.U[i, j]));
                    prob = (float)(s.U[i, j]) - trunc;

                    if (rand.NextDouble() <= prob)
                        s.U[i, j] = trunc + 1;
                    else
                        s.U[i, j] = trunc;                    
                }
            }
        }

        // Calculate average of states u and v
        public double[] Average(State su, State sv)
        {            
            double[] avgs = new double[2];
            double sumu = 0.0;
            double sumv = 0.0;

            for (int i = 0; i < p.N; i++)
            {
                for (int j = 0; j < p.N; j++)
                {
                    sumu += su.U[i, j];
                    sumv += sv.U[i, j];
                }
            }

            avgs[0] = sumu / (p.N * p.N);
            avgs[1] = sumv / (p.N * p.N);

            return avgs;
        }

        // Perform one iteration        
        public double[] Iterate(State su, State sv)
        {
            Diffusion(su, Ru);
            Diffusion(sv, Rv);
            Reaction(su, sv);
            Truncate(su);
            Truncate(sv);
            return Average(su, sv);
        }       
    }
}

