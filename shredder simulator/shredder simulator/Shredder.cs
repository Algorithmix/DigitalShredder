using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace shredder_simulator
{
    class Shredder
    {

        private Bitmap input, sliceMap, sliceMap2;
        private int vertSlice, horSlice, maxDimension;
        private double maxDisplacement;
        private string folderDest;
        bool isChecked;


        public Shredder(shredsimForm Form)
        {
            isChecked = Form.getCheckBox();
            input = new Bitmap(Form.getImageLocation());
            vertSlice = Form.getVertSlice();
            horSlice = Form.getHorSlice();
            maxDimension = Math.Max(input.Width, input.Height);
            folderDest = Form.getFolderDest();
        }

        public void makeSliceMap()
        {
            sliceMap = new Bitmap(input.Width, input.Height);
            sliceMap2 = new Bitmap(sliceMap);

            using (var graphics = Graphics.FromImage(sliceMap))
            {
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(0, 0, 0, 0)), 0, 0, input.Width, input.Height);
            }
            using (var graphics = Graphics.FromImage(sliceMap2))
            {
                graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 0, 0, 0)), 0, 0, input.Width, input.Height);
            }

            //make vertical slices
            double vertDistance = input.Width / (vertSlice + 1);
            Random random;

            for (int i = 1; i <= vertSlice; i++)
            {
                double MidX = i * vertDistance;
                random = new Random();
                double yCurrent = 0;
                while (yCurrent <= sliceMap.Height)
                {
                    var xs = new List<double>(new double[] { MidX, MidX });
                    double maxDisplacement = maxDimension * 0.0012;

                    while (maxDisplacement >= 1)
                    {
                        xs = Split(xs, maxDisplacement, random);
                        maxDisplacement *= 0.5;
                    }

                    using (var graphics = Graphics.FromImage(sliceMap))
                    {
                        Pen vertPen = new Pen(Color.FromArgb(1, 0, 0, 0), 1);

                        double dy = ((random.NextDouble() * 0.004 + 0.001) * (double)maxDimension) / (xs.Count - 1);
                        graphics.DrawLine(vertPen, (float)MidX, (float)yCurrent, (float)xs[0], (float)(yCurrent + dy));
                        yCurrent += dy;
                        for (int j = 1; j < xs.Count - 1; j++)
                        {
                            graphics.DrawLine(vertPen, (float)xs[j], (float)yCurrent, (float)xs[j + 1], (float)(yCurrent + dy));
                            yCurrent += dy;
                        }
                    }
                }
            }

            //code to mark sections of vertical slices

            int[] prevHit = new int[vertSlice + 1];
            for (int ii = 0; ii <= vertSlice; ii++)
                prevHit[ii] = 99999;

            for (int j = 0; j < sliceMap.Height; j++)
            {
                int sectionIndex = 0;
                int isInLine = 0;

                for (int i = 0; i < sliceMap.Width; i++)
                {
                    Color color = sliceMap.GetPixel(i, j);
                    sliceMap.SetPixel(i, j, Color.FromArgb(color.A, color.R, sectionIndex, color.B));

                    if (color.A == 1 && isInLine == 0)
                    {
                        prevHit[sectionIndex] = i;
                        sectionIndex++;
                        isInLine++;
                    }
                    else if (isInLine > 0)
                    {
                        if (isInLine > (4 * maxDimension * 0.0012 + 1))
                            isInLine = 0;
                        else
                            isInLine++;
                    }
                    else if (i > prevHit[sectionIndex] + 4 * maxDimension * 0.0012 + 1)
                    {
                        i = prevHit[sectionIndex];
                        sectionIndex++;
                        isInLine++;
                    }
                }

            }

            //make horizontal slices
            double horDistance = input.Height / (horSlice + 1);

            for (int i = 1; i <= horSlice; i++)
            {
                double MidY = i * horDistance;
                random = new Random();
                double xCurrent = 0;
                while (xCurrent <= sliceMap.Width)
                {
                    var ys = new List<double>(new double[] { MidY, MidY });
                    double maxDisplacement = maxDimension * 0.0012;

                    while (maxDisplacement >= 1)
                    {
                        ys = Split(ys, maxDisplacement, random);
                        maxDisplacement *= 0.5;
                    }

                    using (var graphics = Graphics.FromImage(sliceMap2))
                    {
                        Pen redPen = new Pen(Color.FromArgb(255, 1, 0, 0), 1);

                        double dx = ((random.NextDouble() * 0.004 + 0.001) * (double)maxDimension) / (ys.Count - 1);
                        graphics.DrawLine(redPen, (float)xCurrent, (float)MidY, (float)(xCurrent + dx), (float)ys[0]);
                        xCurrent += dx;
                        for (int j = 1; j < ys.Count - 1; j++)
                        {
                            graphics.DrawLine(redPen, (float)xCurrent, (float)ys[j], (float)(xCurrent + dx), (float)ys[j + 1]);
                            xCurrent += dx;
                        }
                    }

                }
            }

            //code to mark sections of horizontal slices
            int[] prevHit2 = new int[horSlice + 1];
            for (int ii = 0; ii <= horSlice; ii++)
                prevHit2[ii] = 99999;

            for (int i = 0; i < sliceMap.Width; i++)
            {
                int sectionIndex = 0;
                int isInLine = 0;


                for (int j = 0; j < sliceMap.Height; j++)
                {
                    Color color = sliceMap2.GetPixel(i, j);
                    sliceMap2.SetPixel(i, j, Color.FromArgb(color.A, color.R, color.G, sectionIndex));

                    if (color.R == 1 && isInLine == 0)
                    {
                        prevHit2[sectionIndex] = j;
                        sectionIndex++;
                        isInLine++;
                    }
                    else if (isInLine > 0)
                    {
                        if (isInLine > (4 * maxDimension * 0.0012 + 1))
                            isInLine = 0;
                        else
                            isInLine++;
                    }
                    else if (j > prevHit2[sectionIndex] + 4 * maxDimension * 0.0012 + 1)
                    {
                        j = prevHit2[sectionIndex];
                        sectionIndex++;
                        isInLine++;
                    }
                }
            }
        }

        static List<double> Split(List<double> ys, double displacement, Random random)
        {
            var r = new List<double>();
            for (int i = 0; i < ys.Count - 1; i++)
            {
                int sign = random.Next(2);
                if (sign == 0)
                    sign--;
                double dy = (ys[i + 1] - ys[i]) / 2.0;
                double d = sign * random.NextDouble() * displacement;
                r.Add(ys[i]);
                r.Add(ys[i] + dy + d);
            }
            r.Add(ys.Last());
            return r;
        }

        public void separateSliceMap()
        {
            Bitmap[,] shreds = new Bitmap[vertSlice + 1, horSlice + 1];

            int shredWidth = (int)((input.Width / (vertSlice + 1)) + maxDimension * 0.06);
            int shredHeight = (int)((input.Height / (horSlice + 1)) + maxDimension * 0.06);
            int[] vertSliceMeans = new int[vertSlice + 1];
            int[] horSliceMeans = new int[horSlice + 1];
            vertSliceMeans[0] = 0;
            horSliceMeans[0] = 0;

            for (int i = 1; i <= vertSlice; i++)
            {
                vertSliceMeans[i] = i * (input.Width / (vertSlice + 1));
            }

            for (int i = 1; i <= horSlice; i++)
            {
                horSliceMeans[i] = i * (input.Height / (horSlice + 1));
            }

            for (int i = 0; i < vertSlice + 1; i++)
            {
                for (int j = 0; j < horSlice + 1; j++)
                {
                    Bitmap shred = new Bitmap(shredWidth, shredHeight);
                    shreds[i, j] = shred;
                }
            }

            for (int j = 0; j < input.Height; j++)
            {
                for (int i = 0; i < input.Width; i++)
                {
                    //determine which horizontal shred this belongs to
                    int thisHor;
                    Color color = sliceMap.GetPixel(i, j);
                    thisHor = color.G;

                    //determine which vertical shred this belongs to
                    int thisVert;
                    color = sliceMap2.GetPixel(i, j);
                    thisVert = color.B;

                    //find location of this pixel in shred
                    int horizontalOffset = (int)(maxDimension * 0.03) + i - vertSliceMeans[thisHor];
                    int verticalOffset = (int)(maxDimension * 0.03) + j - horSliceMeans[thisVert];

                    shreds[thisHor, thisVert].SetPixel(horizontalOffset, verticalOffset, input.GetPixel(i, j));
                }
            }


            //overlay slices onto pink background
            int horSpacing = (int)(1.2 * shredWidth);
            int vertSpacing = (int)(1.2 * shredHeight);
            Bitmap pinkTile = new Bitmap(shredder_simulator.Properties.Resources.pink_tile);
            Bitmap background = new Bitmap((int)(horSpacing * (vertSlice + 3)), (int)(vertSpacing * (horSlice + 1) + horSpacing * 2));

            using (var graphics = Graphics.FromImage(background))
            {
                //tile the genuine pink paper image over background
                for (int i = 0; i < background.Width; i += pinkTile.Width)
                {
                    for (int j = 0; j < background.Height; j += pinkTile.Height)
                    {
                        graphics.DrawImage(pinkTile, new Point(i, j));
                    }
                }

                if (isChecked)
                {
                    Shuffle(shreds, vertSlice + 1, horSlice + 1);
                }

                //draw shreds onto background
                for (int i = horSpacing; i <= horSpacing * (vertSlice + 1); i += horSpacing)
                {
                    int horIndex = (int)(i / horSpacing) - 1;

                    for (int j = horSpacing; j <= horSpacing + vertSpacing * (horSlice); j += vertSpacing)
                    {
                        int vertIndex = (int)((j - horSpacing) / vertSpacing);

                        graphics.DrawImage(shreds[horIndex, vertIndex], i, j);
                    }
                }
            }

            background.Save(folderDest + "\\shredder_output.png");
        }

        private void Shuffle(Bitmap[,] array, int width, int height)
        {
            Bitmap[] oneDim = new Bitmap[width * height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    oneDim[i * height + j] = array[i, j];
                }
            }
            
            Random rng = new Random();  
            int n = oneDim.Count();
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                Bitmap value = oneDim[k];
                oneDim[k] = oneDim[n];
                oneDim[n] = value;
            }

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    array[i, j] = oneDim[i * height + j];
                }
            }
        }
    }
}
