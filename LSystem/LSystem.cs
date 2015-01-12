using System;
using System.Drawing;

namespace LSystem
{
    public class LSystem
    {
        public string Axiom { get; set; }
        public int Iterations { get; set; }
        public double Theta { get; set; }
        public string Pattern { get; set; }

        public void GeneratePattern()
        {
            var count = 0;
            Pattern = Generate(Axiom, ref count);
        }

        private string Generate(string seed,ref int count)
        {
            if (count >= Iterations)
                return seed;

            var now = "";

            foreach (var t in seed)
            {
                switch (t)
                {
                    case 'A':
                        now += "B-A-B";
                        break;
                    case 'B':
                        now += "A+B+A";
                        break;
                    default:
                        now += t;
                        break;
                }
            }
            seed = now;
            count++;

            return Generate(seed, ref count);
        }

        public void Render(string fileName)
        {
            var start = new Point(10, 10);
            var bmp = new Bitmap(6200,6000);
            
            var o = start;
            foreach (var c in Pattern)
            {
                if (c == 'A' || c == 'B')
                {
                    var p = Helper.Forward(o, Theta, 6);
                    Helper.DrawLine(bmp, o, p);
                    o = p;
                }
                else if (c == '+')
                {
                    Theta -= 60;
                }
                else if (c == '-')
                {
                    Theta += 60;
                }
            }

            bmp.Save(fileName);
        }
    }

    public class Helper
    {
        public static Point Forward(Point origin, double theta, float distance)
        {
            var rad = theta * Math.PI / 180;

            var x = origin.X + distance * (float)Math.Cos(rad);
            var y = origin.Y + distance * (float)Math.Sin(rad);

            return new Point((int)(x+0.5), (int)(y+0.5));
        }

        public static void DrawLine(Bitmap bmp, Point from, Point to)
        {
            var blackPen = new Pen(Color.Black, 2);

            using (var graphics = Graphics.FromImage(bmp))
            {
                graphics.DrawLine(blackPen, from,to );
            }
        }
    }
}
