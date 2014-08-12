using System;
using System.Drawing.Imaging;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/* Note: It is necessary to ensure that the debugger is set to allow the use of "unsafe code"
 * be run in order for this code to work. This is due to the use of pointers, whose misuse
 * can cause problems and are discouraged in C#.
 */ 
namespace MACA
{
    unsafe class FastBitmapAccess
    {
        private Bitmap b = null;
        private State su, sv;

        public FastBitmapAccess(Bitmap b, Parameters p)
        {
            this.b = b;
            
            // Set up states
            su = new State(p);
            sv = new State(p);
        }

        public void InitialiseStates(State su, State sv)
        {  
            this.su = su;
            this.sv = sv;
        }

        public void ManipulateImage(State s, int scale)
        {            
            int k,l,m;
            int shades = 3; // Number of colour shades desired
            
            //Lock Image
            BitmapData data = b.LockBits(new Rectangle(Point.Empty, b.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            byte* ptr = (byte*)(data.Scan0); //access the bits of the bitmap

            for (int i = 0; i < data.Height; i++)
            {
                for (int j = 0; j < data.Width; j++)
                {
                    // The scale variable just designates how many pixels in a bitmap
                    // correspond to one element in the state array 
                    k = (int)(double)(i / scale);
                    l = (int)(double)(j / scale);
                    
                    // Code if different shades are desired                    
                    for (m = 0; m < 11; m++)
                    {
                        if ((int)s.U[k, l] == m)
                        {
                            // Two different colouring schemes
                            // This one in use, not commented, basically assigns 
                            // black to state = 0 and white to state = 10
                            // then scales using the number of shades desired by the "shades" variable
                            // 255-255-255  = white
                            // 0-0-0        = black
                            ptr[0] = (byte)((m * 255) / shades); // Blue
                            ptr[1] = (byte)((m * 255) / shades); // Green
                            ptr[2] = (byte)((m * 255) / shades); // Red
                            //ptr[0] = (byte)(255 - ((m * 255) / shades)); // Blue
                            //ptr[1] = (byte)(255 - ((m * 255) / shades)); // Green
                            //ptr[2] = (byte)(255 - ((m * 255) / shades)); // Red
                        }
                    }                                      

                    ptr += 3;//move pointer on 3 bytes as each pixel = 24 bits = 3 bytes
                }
                //after we go through a row move on the extra piece
                ptr += data.Stride - data.Width * 3;
            }
            b.UnlockBits(data);
        }
    }
}
