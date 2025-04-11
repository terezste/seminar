using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint
{
    public partial class Form1 : Form
    {
        Graphics g;
        Pen myPen = new Pen(Color.Black, 20);
        bool mouseDown = false;
        Point lastPosition;
        string activity = "draw";
        int x1, y1, x2, y2;
        int opacity;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        //CLEAR
        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        //BARVY
            private void button8_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.Red);
            }
            private void button5_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.Orange);
            }
            private void button2_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.Yellow);
            }
            private void button9_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.Green);
            }
            private void button6_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.Blue);
            }
            private void button3_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.Purple);
            }
            private void button10_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.HotPink);
            }
            private void button7_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.SaddleBrown);
            }
            private void button4_Click(object sender, EventArgs e)
            {
                myPen.Color = Color.FromArgb(opacity, Color.Black);
            }

        //VELIKOST PERA
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            myPen.Width = (float)numericUpDown1.Value;
        }

        //GUMA
        private void button11_Click(object sender, EventArgs e)
        {
            activity = "draw";
            myPen.Color = Color.FromArgb(255, Color.White);
        }

        //MALOVANI
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastPosition = e.Location;
            x1 = e.X;
            y1 = e.Y;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown && activity == "draw")
            {
                g.FillEllipse(new SolidBrush(myPen.Color), e.X - (myPen.Width/2), e.Y - (myPen.Width / 2), myPen.Width, myPen.Width);               
                g.DrawLine(myPen, e.Location, lastPosition);
                lastPosition = e.Location;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown= false;
            x2 = e.X;
            y2 = e.Y;

            if (activity == "drawRectangle")
            {
                if (x1 > x2)
                {
                    (x1, x2) = (x2, x1);
                }
                if (y1 > y2)
                {
                    (y1, y2) = (y2, y1);
                }
                g.DrawRectangle(myPen, x1, y1, x2 - x1, y2 - y1);
            }
            else if (activity == "drawEllipse")
            {
                g.DrawEllipse(myPen, x1, y1, x2 - x1, y2 - y1);
            }
            else if (activity == "drawLine")
            {
                g.DrawLine(myPen, x1, y1, x2, y2);
            }
            else if (activity == "fillRectangle")
            {
                if (x1 > x2)
                {
                    (x1, x2) = (x2, x1);
                }
                if (y1 > y2)
                {
                    (y1, y2) = (y2, y1);
                }
                g.FillRectangle(new SolidBrush(myPen.Color), x1, y1, x2 - x1, y2 - y1);
            }
            else if (activity == "fillEllipse")
            {
                g.FillEllipse(new SolidBrush(myPen.Color), x1, y1, x2 - x1, y2 - y1);
            }
            else if (activity == "imageStar")
            {
                g.DrawImage(Properties.Resources.dog, x1, y1, x2, y2);
            }
            else if (activity == "imageHeart")
            {
                g.DrawImage(Properties.Resources.cat, x1, y1, x2, y2);
            }
        }

        //BRUSH
        private void button12_Click(object sender, EventArgs e)
        {
            activity = "draw";
            opacity = 20;
            myPen.Color = Color.FromArgb(opacity, myPen.Color);
        }
        //PEN
        private void button13_Click(object sender, EventArgs e)
        {
            activity = "draw";
            opacity = 255;
            myPen.Color = Color.FromArgb(255, myPen.Color);
        }       

        //TVARY
        private void button14_Click(object sender, EventArgs e)
        {
            activity = "drawRectangle";
        }
        private void button15_Click(object sender, EventArgs e)
        {
            activity = "drawEllipse";
        }
        private void button16_Click(object sender, EventArgs e)
        {
            activity = "drawLine";
        }
        private void button18_Click(object sender, EventArgs e)
        {
            activity = "fillRectangle";
        }
        private void button19_Click(object sender, EventArgs e)
        {
            activity = "fillEllipse";
        }
        private void button20_Click(object sender, EventArgs e)
        {
            activity = "drawB";
        }
        private void button17_Click_1(object sender, EventArgs e)
        {
            activity = "imageDog";
        }
        private void button20_Click_1(object sender, EventArgs e)
        {
            activity = "imageCat";
        }


        //VSECHNO CO JSEM OMYLEM PROKLIKLA
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }
        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
        private void button17_Click(object sender, EventArgs e)
        {

        }
    }
}
