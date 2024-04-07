using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace WinForm_Noise
{
    internal class Generator
    {

        public static Bitmap DummyMap()
        {
            Bitmap bmp = new Bitmap(500, 400);
            for (int x = 0; x < bmp.Width; x++)
            {
                for(int y = 0; y < bmp.Height; y++)
                {

                    bmp.SetPixel(x, y, Color.DarkKhaki);

                }
            }
            return bmp;
        }

        public static Bitmap SimpleNoise()
        {
            Bitmap bmp = new Bitmap(500, 400);
            Random random = new Random();

            for (int x = 0; x < bmp.Width; x++)
            {
                for (int y = 0; y < bmp.Height; y++)
                {
                    byte sample = (byte)random.Next(255);
                    Color c = Color.FromArgb(sample, sample, sample);
                    bmp.SetPixel(x, y, c);

                }
            }
            return bmp;
        }

        public static Bitmap PerlinNoise()
        {
            Bitmap bmp = new Bitmap(500, 400);
            Random random = new Random();
            int imageHeight = 400;
            int imageWidth = 500;
            int gridHeight = 8;
            int gridWidth = 10;

            //Generate gradiant vectors.
            Vector2[,] gradiants = new Vector2[gridWidth, gridHeight];
            for (int gridX = 0; gridX < gridWidth; gridX++)
            {
                for(int gridY = 0; gridY < gridHeight; gridY++)
                {
                    float angle = (float)random.NextDouble() * 360;
                    float x = (float)Math.Sin(angle);
                    float y = (float)Math.Cos(angle);

                    gradiants[gridX, gridY] = new Vector2(x, y);
                }
            }

            //Calculate the offset vectors for each point
            for(int x = 0; x < imageWidth; x++)
            {
                for(int y = 0; y < imageHeight; y++)
                {
                    //Find ratio of x/y pixel position to total image size
                    float fx = x;
                    fx = fx / imageWidth;
                    float fy = y;
                    fy = fy / imageHeight;

                    if (false && y == 25 && x % 100 == 25)
                    {
                        Debug.Write(string.Format("Pixel ({0}, {1}) goes to ({2}, {3})", x, y, fx, fy));
                    }

                    //Use that to translate to be in terms of the grid
                    fx *= gridWidth;
                    fy *= gridHeight;

                    //Round to the nearest integer to index grid array
                    int gx = (int)Math.Round(fx);
                    int gy = (int)Math.Round(fy);

                    //Find offset vector in terms of the grid space.
                    Vector2 offset = new Vector2(gx - fx, gy - fy);

                    //Take the dot product of the offset vector and the gradiant vector.
                    float dot;
                    
                    //Make sure that the gx and gy coordinates are valid. If not, use a dummy value for the dot (for now).
                    if(gx >= 0 && gx < gridWidth && gy >= 0 && gy < gridHeight)
                    {
                         dot = Vector2.Dot(gradiants[gx, gy], offset) * 0.5f + 0.5f;
                    } else
                    {
                        dot = 0.0f;
                    }

                    //Interpolate dot product between 0 and 255.
                    byte iDot = (byte)((dot * 255) % 255);

                    //Set the pixel on the map.
                    Color c = Color.FromArgb(iDot, iDot, iDot);
                    bmp.SetPixel(x, y, c);
                }
            }
           

            
            return bmp;
        }

    }
}
