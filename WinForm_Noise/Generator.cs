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

                    float i0 = smoothstep(dots[0], dots[1], dx);
                    float i1 = smoothstep(dots[2], dots[3], dx);

                    float i2 = smoothstep(i0, i1, dy);

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

        public static float smoothstep(float a0, float a1, float w)
        {
            return (a1 - a0) * (3.0f - w * 2.0f) * w * w + a0;
        }



        public static Bitmap MapFromPerlinNoise(int seed, int[] imageSize, int octaves = 1, float lacunarity = 1.5f, float persistance = 0.5f)
        {
            Debug.Assert(imageSize.Length == 2);
            Vector2[,] gradiants = GenerateGradiants(imageSize[0] / 25, imageSize[1] / 25, seed);

            //Used to store weights from the sampling. Needed because of the implementation of multiple sampling across octaves.
            float[,] weights = new float[imageSize[0], imageSize[1]];

            //Track min and max weights as they're inserted.
            float minWeight = float.PositiveInfinity;
            float maxWeight = float.NegativeInfinity;

            for(int x = 0; x < imageSize[0]; x++)
            {
                for(int y = 0; y < imageSize[1]; y++)
                {
                    float weight = 0;
                    float amp = 1;

                    for (int i = 0; i < octaves; i++)
                    {
                        float fx = x;
                        float fy = y;

                        fx /= imageSize[0];
                        fy /= imageSize[1];

                        fx *= 1 + (i * lacunarity);
                        fy *= 1 + (i * lacunarity);

                        weight += amp * PerlinSample(fx, fy, gradiants);

                        amp *= persistance;
                    }

                    //Update min and max weights.
                    if (weight > maxWeight) maxWeight = weight;
                    if (weight < minWeight) minWeight = weight;

                    weights[x, y] = weight;
                }
            }

            Bitmap bmp = new Bitmap(imageSize[0], imageSize[1]);

            //Loop through again and rescale all of the values to the min and max before adding them to the bmp.
            for (int x = 0; x < imageSize[0]; x++)
            {
                for (int y = 0; y < imageSize[1]; y++)
                {
                    float weight = inverseLerp(minWeight, maxWeight, weights[x, y]);
                    byte bWeight = (byte)(Math.Clamp(weight * 255, 0, 255));

                    Color col = Color.FromArgb(bWeight, bWeight, bWeight);
                    bmp.SetPixel(x, y, col);
                }
            }

            return bmp;
        }

        private static float inverseLerp(float a, float b, float value)
        {
            return (value - a) / (b - a);
        }

        private static Vector2[,] GenerateGradiants(int width, int height, int seed)
        {
            Vector2[,] gradiants = new Vector2[width, height];
            Random rand = new Random(seed);

            for (int gridX = 0; gridX < width; gridX++)
            {
                for (int gridY = 0; gridY < height; gridY++)
                {
                    float angle = (float)rand.NextDouble() * 360;
                    float x = (float)Math.Sin(angle);
                    float y = (float)Math.Cos(angle);

                    gradiants[gridX, gridY] = new Vector2(x, y);
                }
            }

            return gradiants;
        }

        private static float PerlinSample(float x, float y, Vector2[,] gradiants)
        {
            x = x * gradiants.GetLength(0);
            y = y * gradiants.GetLength(1);


            //Use the floor to find the grid corner that is to the top left.
            int gx = (int)Math.Floor(x);
            int gy = (int)Math.Floor(y);

            //Calculate the dot offset for each corner.
            float[] dots = new float[4];
            Vector2 offset;

            //Calculate dot products.
            int i = 0;
            for(int dy = 0; dy < 2; dy++)
            {
                for(int dx = 0; dx < 2; dx++)
                {
                    Vector2 corner = gradiants[(gx + dx) % gradiants.GetLength(0), (gy + dy) % gradiants.GetLength(1)];
                    offset = new Vector2(gx + dx - x, gy + dy - y);

                    dots[i++] = Vector2.Dot(corner, offset);

                }
            }

            //Calculate weights for interpolation
            float wx = x % 1;
            float wy = y % 1;

            //Interpolate along corners with same y value
            float i0 = smoothstep(dots[0], dots[1], wx);
            float i1 = smoothstep(dots[2], dots[3], wx);

            //Interpolate results
            float i2 = smoothstep(i0, i1, wy);

            return i2;
        }
    }
}
