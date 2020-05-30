using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace hangman
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }
        string word = " ";
        List<Label> labels = new List<Label>();
        int amount = 0;
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        enum bodyParts
        {
            head, //0
            left_eye, //1
            right_eye, //2 and so on
            mouth,
            body,
            right_arm,
            left_arm,
            right_leg,
            left_leg
        }
    
        void drawHangPost()
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Brown, 10);
            g.DrawLine(p, new Point(130, 318), new Point(130, 50));// |
            g.DrawLine(p, new Point(135, 50), new Point(65, 50));// -
            g.DrawLine(p, new Point(60, 100), new Point(60, 50));
          /*  drawBodyParts(bodyParts.head);
            drawBodyParts(bodyParts.left_eye);
            drawBodyParts(bodyParts.right_eye);
            drawBodyParts(bodyParts.mouth);
            drawBodyParts(bodyParts.body);
            drawBodyParts(bodyParts.left_arm);
            drawBodyParts(bodyParts.right_arm);
            drawBodyParts(bodyParts.left_leg);
            drawBodyParts(bodyParts.right_leg);
            //MessageBox.Show(getRandomWord());*/
            
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            drawHangPost();
            makeLabels();
        }
        void drawBodyParts(bodyParts bp)
        {
            Graphics g = panel1.CreateGraphics();
            Pen p = new Pen(Color.Blue, 2);
            if (bp == bodyParts.head)
            {
                g.DrawEllipse(p, 40, 100, 40, 40);
            }
            else if (bp == bodyParts.left_eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 50, 110, 5, 5);
            }
            else if (bp == bodyParts.right_eye)
            {
                SolidBrush s = new SolidBrush(Color.Black);
                g.FillEllipse(s, 68, 110, 5, 5);
            }
            else if (bp == bodyParts.mouth)
            {
                g.DrawArc(p, 50, 110, 20, 20, 45, 90);
            }
            else if (bp == bodyParts.body)
            {
                g.DrawLine(p, new Point(60, 140), new Point(60, 225));
            }
            else if (bp == bodyParts.left_arm)
            {
                g.DrawLine(p, new Point(60, 170), new Point(20, 140));
            }
            else if (bp == bodyParts.right_arm)
            {
                g.DrawLine(p, new Point(60, 166), new Point(90, 140));
            }
            else if (bp == bodyParts.left_leg)
            {
                g.DrawLine(p, new Point(60, 225), new Point(30, 240));
            }
            else if (bp == bodyParts.right_leg)
            {
                g.DrawLine(p, new Point(60, 225), new Point(90, 245));
            }
        }
            string getRandomWord()
            {
                WebClient wc = new WebClient();
                string wordsList = wc.DownloadString("https://raw.githubusercontent.com/Tom25/Hangman/master/wordlist.txt");
                string[] words = wordsList.Split('\n');
                Random ram = new Random();
                return words[(ram.Next(0, words.Length - 1))];
            }
        void makeLabels()
        {
           word= getRandomWord();
            char[] chars = word.ToCharArray();
            int between = 330 / chars.Length - 1;
            for(int i=0; i<chars.Length-1; i++)
            {
                labels.Add(new Label());
                labels[i].Location = new Point((i * between) + 10, 120);
                labels[i].Text = "_";
                labels[i].Parent = groupBox2;
                labels[i].BringToFront();
                labels[i].CreateControl();
            }
            label1.Text = "Word Length: " + (chars.Length - 1).ToString();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            char letter = textBox1.Text.ToLower().ToCharArray()[0];
            if (!char.IsLetter(letter))
            {
                MessageBox.Show("You can only submit letters","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            if (word.Contains(letter))
            {
                char[] letters = word.ToCharArray();
                for (int i = 0; i < letters.Length; i++)
                {
                    if (letters[i] == letter)
                    {
                        labels[i].Text = letter.ToString();
                    }
                }
                    foreach (Label l in labels)
                    {
                        if (l.Text == "_") return;
                    }
                      
                   MessageBox.Show("You won, genius!", "Genius Alert!");

                   // resetGame();         
            }
            else
            {
                MessageBox.Show("You guessed incorrect letter", "Sorry!");
                label2.Text += "" + letter.ToString();
                drawBodyParts((bodyParts)amount);
                amount++;
                if (amount == 8)
                {
                    MessageBox.Show("You lost, the word was: "+word, "Loser");
                   resetGame();
                }
                
            }
        }
        void resetGame()
        {
            Graphics g = panel1.CreateGraphics();
            g.Clear(panel1.BackColor);
            getRandomWord();
            makeLabels();
            drawHangPost();
            label2.Text = "Missed: ";
            textBox1.Text = "";
        }
    }
}
