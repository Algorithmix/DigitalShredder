using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jagged_line_generator
{
    public partial class Form1 : Form
    {
        Bitmap theLine;
        double xCurrent;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random random = new Random();
            xCurrent = 0;
            theLine = new Bitmap(jagged_line_generator.Properties.Resources.Untitled);

            while (xCurrent <= theLine.Width)
            {
                var ys = new List<double>(new double[] { 250.0, 250.0 });
                double maxDisplacement = theLine.Width * 0.0012;

                while (maxDisplacement >= 1)
                {
                    ys = Split(ys, maxDisplacement, random);
                    maxDisplacement *= 0.5;
                }

                drawLines(ys, theLine, random);
            }
             
            theLine.Save("C:\\Users\\Jacob\\Pictures\\theLine.png");
        }

        private void drawLines(List<double> ys, Bitmap image, Random random)
        {
            using (var graphics = Graphics.FromImage(image))
            {
                Pen blackPen = new Pen(Color.Black, 1);

                double dx = ((random.NextDouble() * 0.004 + 0.001) * (double)image.Width) / (ys.Count - 1);
                graphics.DrawLine(blackPen, (float)xCurrent, (float)250.0, (float)(xCurrent + dx), (float)ys[0]);
                xCurrent += dx;
                for (int i = 1; i < ys.Count - 1; i++)
                {
                    graphics.DrawLine(blackPen, (float)xCurrent, (float)ys[i], (float)(xCurrent + dx), (float)ys[i + 1]);
                    xCurrent += dx;
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

    }
}
