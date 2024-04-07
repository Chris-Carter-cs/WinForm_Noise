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
            int gridHeight = 16;
            int gridWidth = 20;

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

                    //Use that to translate to be in terms of the grid
                    fx *= gridWidth;
                    fy *= gridHeight;

                    //Use the floor to find the grid corner that is to the top left.
                    int gx = (int)Math.Floor(fx);
                    int gy = (int)Math.Floor(fy);

                    //Calculate the dot offset for each corner.
                    float[] dots = new float[4];
                    Vector2 offset = new Vector2(gx - fx, gy - fy);
                    dots[0] = Vector2.Dot(offset, gradiants[gx, gy]);

                    offset = new Vector2((gx + 1) - fx, gy - fy);
                    dots[1] = Vector2.Dot(offset, gradiants[(gx + 1) % gridWidth, gy]);

                    offset = new Vector2(gx - fx, (gy + 1) - fy);
                    dots[2] = Vector2.Dot(offset, gradiants[gx, (gy + 1) % gridHeight]);

                    offset = new Vector2((gx + 1) - fx, (gy + 1) - fy);
                    dots[3] = Vector2.Dot(offset, gradiants[(gx + 1) % gridWidth, (gy + 1) % gridHeight]);

                    float dx = fx % 1.0f;
                    float dy = fy % 1.0f;

                    float i0 = lerp(dots[0], dots[1], dx);
                    float i1 = lerp(dots[2], dots[3], dx);

                    float i2 = lerp(i0, i1, dy);

                    i2 = i2 * 0.5f + 0.5f;

                    //Interpolate dot product between 0 and 255.
                    byte iDot = (byte)((i2 * 255) % 255);

                    //Set the pixel on the map.
                    Color c = Color.FromArgb(iDot, iDot, iDot);
                    bmp.SetPixel(x, y, c);
                }
            }
           

            
            return bmp;
        }

        public static float lerp(float a0, float a1, float w)
        {
            return (a1 - a0) * (3.0f - w * 2.0f) * w * w + a0;
        }

    }
}
