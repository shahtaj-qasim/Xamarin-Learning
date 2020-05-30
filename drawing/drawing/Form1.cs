using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drawing
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_Click(object sender, EventArgs e)
        {
            //drawing using brush class
            /* SolidBrush sb = new SolidBrush(Color.Green);
             Graphics g = panel1.CreateGraphics();
             g.FillRectangle(sb, 20, 20, 50, 50);
             g.FillEllipse(sb, 60, 60, 50, 50);
             g.FillPie(sb, 100, 20, 60, 60,0,270);
             Point[] points = { new Point(0, 20), new Point(0, 0), new Point(20, 0) };
             g.FillPolygon(sb, points);*/

            //drawing using pen class
            /*  Pen pen = new Pen(Color.Red, 3); //3px lines
              Graphics g = panel1.CreateGraphics();
              g.DrawRectangle(pen, 20, 20, 50, 50);
              g.DrawEllipse(pen, 70, 60, 60, 50);
              Point[] points = { new Point(0, 20), new Point(0, 0), new Point(20, 0) };
              g.DrawPolygon(pen, points);
              g.DrawArc(pen, 120, 80, 100, 100,0,90);
              g.DrawBezier(pen, new Point(20, 20), new Point(30, 60), new Point(70, 40), new Point(80, 90));
              g.DrawLine(pen, new Point(40, 100), new Point(20, 80));*/

            SolidBrush sb = new SolidBrush(Color.Blue);
            Graphics g = panel1.CreateGraphics();
            FontFamily ff = new FontFamily("Arial");
            Font font = new Font(ff,20,FontStyle.Bold);
            g.DrawString("Shahtaj", font, sb, new Point(20, 20));

        }
    }
}
