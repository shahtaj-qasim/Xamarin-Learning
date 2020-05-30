using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Collections.Generic;

namespace captcha
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<string> strings = new List<string>();

        private void button2_Click(object sender, EventArgs e)
        {
            generateCap(0);
        }
        Image [] generateCap(int amount)
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            Random ram = new Random();
            SolidBrush b = new SolidBrush(Color.FromArgb(0xFF, ram.Next(0,255), ram.Next(0, 255), ram.Next(0, 255)));
            Pen p= new Pen(Color.FromArgb(0xFF, ram.Next(0, 255), ram.Next(0, 255), ram.Next(0, 255))); //random colors
            char[] chars = "quteipwnlksndkmsdhslkdhsnmaxn1761863".ToCharArray();
            string ranString = "";
            for(int i=0; i<6; i++)
            {
                ranString += chars[ram.Next(0, 35)];
            }
            byte[] buffer = new byte[ranString.Length];
            int y = 0;
            foreach(char c in ranString.ToCharArray())
            {
                buffer[y] = (byte)c;
                y++;
            }
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            string md5string = BitConverter.ToString(md5.ComputeHash(buffer)).Replace("-","");
            strings.Add(md5string);
            FontFamily ff = new FontFamily("Arial");
            Font f = new System.Drawing.Font(ff,14);
            g.DrawString(ranString, f, b, 20, 50);
            for(int i=0; i<6; i++)
            {
                int j = ram.Next(0, 2);
                if (j == 0)
                {
                    g.DrawRectangle(p, ram.Next(0, 111), ram.Next(0, 60), ram.Next(0, 111), ram.Next(0, 60));

                }
                else if (j == 1)
                {
                    g.DrawEllipse(p, ram.Next(0, 111), ram.Next(0, 60), ram.Next(0, 111), ram.Next(0, 60));

                }
                p.Color= Color.FromArgb(0xFF, ram.Next(0, 255), ram.Next(0, 255), ram.Next(0, 255));
        }
            return null;
        }
    }
}
