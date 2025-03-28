using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Pen myPen = new Pen(Color.Black, 1);
        bool mouseDown = false;
        Point lastPosition;

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        //BARVY

        private void button8_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.Red;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.Orange;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.Yellow;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.Green;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.Blue;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.Purple;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.HotPink;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.SaddleBrown;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.Black;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //VELIKOST PERA
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            myPen.Width = (float)numericUpDown1.Value;
        }

        //GUMA
        private void button11_Click(object sender, EventArgs e)
        {
            myPen.Color = Color.White;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            //g.DrawEllipse(MousePosition, myPen.width, myPen.width);
            mouseDown = true;
            lastPosition = e.Location;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                //g.DrawEllipse(myPen, e.X, e.Y, 1, 1);
                g.DrawLine(myPen, e.Location, lastPosition);
                lastPosition = e.Location;
            }
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown= false;
        }
    }
}
