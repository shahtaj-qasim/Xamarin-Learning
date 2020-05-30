using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace gradient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            /* LinearGradientBrush gb = new LinearGradientBrush(new Point(20, 20), new Point(20, 70), Color.Red, Color.Yellow);
             Graphics g = panel1.CreateGraphics();
             g.FillEllipse(gb, 20, 20, 50, 50);*/ //or fill rectangle

            /*LinearGradientBrush gb = new LinearGradientBrush(new Point(20, 20), new Point(20, 70), Color.Black, Color.Red);
            Graphics g = panel1.CreateGraphics();
            ColorBlend cb = new ColorBlend();
            cb.Colors = new Color[] { Color.Black, Color.Blue, Color.SkyBlue, Color.White };
            cb.Positions = new float[] { 0, 0.33F, 0.67F, 1F };
            gb.InterpolationColors = cb;
            g.FillRectangle(gb, 20, 20, 50, 50);*/

            /*GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(20, 20, 100, 100);
            PathGradientBrush p = new PathGradientBrush(gp);
            p.CenterColor = Color.Red;
            p.SurroundColors = new Color[] { Color.Yellow };
            Graphics g = panel1.CreateGraphics();
            g.FillEllipse(p, 20, 20, 100, 100);*/

            /*  GraphicsPath gp = new GraphicsPath();
              Rectangle r = new Rectangle(20, 20, 50, 50);
              gp.AddRectangle(r);
              PathGradientBrush p = new PathGradientBrush(gp);
              p.CenterColor = Color.Black;
              p.SurroundColors = new Color[] { Color.White };
              Graphics g = panel1.CreateGraphics();
              g.FillRectangle(p, r);*/

            GraphicsPath gp = new GraphicsPath();
            Point[] points = { new Point(20, 20), new Point(20, 70), new Point(70, 20), new Point(70, 70)};
            gp.AddPolygon(points);
            
            PathGradientBrush p = new PathGradientBrush(gp);
            p.CenterColor = Color.Black;
            p.SurroundColors = new Color[] { Color.White };
            Graphics g = panel1.CreateGraphics();
            g.FillPolygon(p, points);

        }
    }
}
