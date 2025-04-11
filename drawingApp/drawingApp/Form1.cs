using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace drawingApp
{
    public partial class Form1 : Form
    {
        Graphics g;
        bool mouseDown;
        bool dragDown;
        Point lastPosition;
        bool penOn = true;
        bool eraser;
        bool square;
        bool elipse;
        bool rect;
        bool fillIn = true;
        int widthA = 100;
        int heightA;
        int colour = 10;
        int penWidth = 4;
        bool circlePen;
        bool squarePen;
        bool texturedPen;
        bool rainbowPen;
        bool callPen;
        double lastX;
        double lastY;
        

        public Form1()
        {
            InitializeComponent();
            g = panel1.CreateGraphics();
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random rng = new Random();
            int x = rng.Next(0, 800);
            int y = rng.Next(0, 400);
            if (colour == 1) { g.FillRectangle(Brushes.Crimson, x, y, widthA, widthA); }
            if (colour == 2) { g.FillRectangle(Brushes.DarkOrange, x, y, widthA, widthA); }
            if (colour == 3) { g.FillRectangle(Brushes.Yellow, x, y, widthA, widthA); }
            if (colour == 4) { g.FillRectangle(Brushes.Green, x, y, widthA, widthA); }
            if (colour == 5) { g.FillRectangle(Brushes.RoyalBlue, x, y, widthA, widthA); }
            if (colour == 6) { g.FillRectangle(Brushes.DarkViolet, x, y, widthA, widthA); }
            if (colour == 7) { g.FillRectangle(Brushes.PaleVioletRed, x, y, widthA, widthA); }
            if (colour == 8) { g.FillRectangle(Brushes.Chocolate, x, y, widthA, widthA); }
            if (colour == 9) { g.FillRectangle(Brushes.Gray, x, y, widthA, widthA); }
            if (colour == 10) { g.FillRectangle(Brushes.Black, x, y, widthA, widthA); }
            
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            lastPosition = e.Location;
            if(fillIn == true)
            {
                if (square == true)
                {
                    if (colour == 1) { g.FillRectangle(Brushes.Crimson, e.X, e.Y, widthA, widthA); }
                    if (colour == 2) { g.FillRectangle(Brushes.DarkOrange, e.X, e.Y, widthA, widthA); }
                    if (colour == 3) { g.FillRectangle(Brushes.Yellow, e.X, e.Y, widthA, widthA); }
                    if (colour == 4) { g.FillRectangle(Brushes.Green, e.X, e.Y, widthA, widthA); }
                    if (colour == 5) { g.FillRectangle(Brushes.RoyalBlue, e.X, e.Y, widthA, widthA); }
                    if (colour == 6) { g.FillRectangle(Brushes.DarkViolet, e.X, e.Y, widthA, widthA); }
                    if (colour == 7) { g.FillRectangle(Brushes.PaleVioletRed, e.X, e.Y, widthA, widthA); }
                    if (colour == 8) { g.FillRectangle(Brushes.Chocolate, e.X, e.Y, widthA, widthA); }
                    if (colour == 9) { g.FillRectangle(Brushes.Gray, e.X, e.Y, widthA, widthA); }
                    if (colour == 10) { g.FillRectangle(Brushes.Black, e.X, e.Y, widthA, widthA); }
                    square = false;
                }
                if (elipse == true)
                {
                    if (colour == 1) { g.FillEllipse(Brushes.Crimson, e.X, e.Y, widthA, widthA); }
                    if (colour == 2) { g.FillEllipse(Brushes.DarkOrange, e.X, e.Y, widthA, widthA); }
                    if (colour == 3) { g.FillEllipse(Brushes.Yellow, e.X, e.Y, widthA, widthA); }
                    if (colour == 4) { g.FillEllipse(Brushes.Green, e.X, e.Y, widthA, widthA); }
                    if (colour == 5) { g.FillEllipse(Brushes.RoyalBlue, e.X, e.Y, widthA, widthA); }
                    if (colour == 6) { g.FillEllipse(Brushes.DarkViolet, e.X, e.Y, widthA, widthA); }
                    if (colour == 7) { g.FillEllipse(Brushes.PaleVioletRed, e.X, e.Y, widthA, widthA); }
                    if (colour == 8) { g.FillEllipse(Brushes.Chocolate, e.X, e.Y, widthA, widthA); }
                    if (colour == 9) { g.FillEllipse(Brushes.Gray, e.X, e.Y, widthA, widthA); }
                    if (colour == 10) { g.FillEllipse(Brushes.Black, e.X, e.Y, widthA, widthA); }
                    elipse = false;
                }
                if (rect == true)
                {
                    heightA = widthA / 2;
                    if (colour == 1) { g.FillRectangle(Brushes.Crimson, e.X, e.Y, widthA, heightA); }
                    if (colour == 2) { g.FillRectangle(Brushes.DarkOrange, e.X, e.Y, widthA, heightA); }
                    if (colour == 3) { g.FillRectangle(Brushes.Yellow, e.X, e.Y, widthA, heightA); }
                    if (colour == 4) { g.FillRectangle(Brushes.Green, e.X, e.Y, widthA, heightA); }
                    if (colour == 5) { g.FillRectangle(Brushes.RoyalBlue, e.X, e.Y, widthA, heightA); }
                    if (colour == 6) { g.FillRectangle(Brushes.DarkViolet, e.X, e.Y, widthA, heightA); }
                    if (colour == 7) { g.FillRectangle(Brushes.PaleVioletRed, e.X, e.Y, widthA, heightA); }
                    if (colour == 8) { g.FillRectangle(Brushes.Chocolate, e.X, e.Y, widthA, heightA); }
                    if (colour == 9) { g.FillRectangle(Brushes.Gray, e.X, e.Y, widthA, heightA); }
                    if (colour == 10) { g.FillRectangle(Brushes.Black, e.X, e.Y, widthA, heightA); }
                    rect = false;
                }
            }
            else
            {
                if (square == true)
                {
                    if (colour == 1) { g.DrawRectangle(Pens.Crimson, e.X, e.Y, widthA, widthA); }
                    if (colour == 2) { g.DrawRectangle(Pens.DarkOrange, e.X, e.Y, widthA, widthA); }
                    if (colour == 3) { g.DrawRectangle(Pens.Yellow, e.X, e.Y, widthA, widthA); }
                    if (colour == 4) { g.DrawRectangle(Pens.Green, e.X, e.Y, widthA, widthA); }
                    if (colour == 5) { g.DrawRectangle(Pens.RoyalBlue, e.X, e.Y, widthA, widthA); }
                    if (colour == 6) { g.DrawRectangle(Pens.DarkViolet, e.X, e.Y, widthA, widthA); }
                    if (colour == 7) { g.DrawRectangle(Pens.PaleVioletRed, e.X, e.Y, widthA, widthA); }
                    if (colour == 8) { g.DrawRectangle(Pens.Chocolate, e.X, e.Y, widthA, widthA); }
                    if (colour == 9) { g.DrawRectangle(Pens.Gray, e.X, e.Y, widthA, widthA); }
                    if (colour == 10) { g.DrawRectangle(Pens.Black, e.X, e.Y, widthA, widthA); }
                    square = false;
                }
                if (elipse == true)
                {
                    if (colour == 1) { g.DrawEllipse(Pens.Crimson, e.X, e.Y, widthA, widthA); }
                    if (colour == 2) { g.DrawEllipse(Pens.DarkOrange, e.X, e.Y, widthA, widthA); }
                    if (colour == 3) { g.DrawEllipse(Pens.Yellow, e.X, e.Y, widthA, widthA); }
                    if (colour == 4) { g.DrawEllipse(Pens.Green, e.X, e.Y, widthA, widthA); }
                    if (colour == 5) { g.DrawEllipse(Pens.RoyalBlue, e.X, e.Y, widthA, widthA); }
                    if (colour == 6) { g.DrawEllipse(Pens.DarkViolet, e.X, e.Y, widthA, widthA); }
                    if (colour == 7) { g.DrawEllipse(Pens.PaleVioletRed, e.X, e.Y, widthA, widthA); }
                    if (colour == 8) { g.DrawEllipse(Pens.Chocolate, e.X, e.Y, widthA, widthA); }
                    if (colour == 9) { g.DrawEllipse(Pens.Gray, e.X, e.Y, widthA, widthA); }
                    if (colour == 10) { g.DrawEllipse(Pens.Black, e.X, e.Y, widthA, widthA); }
                    elipse = false;
                }
                if (rect == true)
                {
                    heightA = widthA / 2;
                    if (colour == 1) { g.DrawRectangle(Pens.Crimson, e.X, e.Y, widthA, heightA); }
                    if (colour == 2) { g.DrawRectangle(Pens.DarkOrange, e.X, e.Y, widthA, heightA); }
                    if (colour == 3) { g.DrawRectangle(Pens.Yellow, e.X, e.Y, widthA, heightA); }
                    if (colour == 4) { g.DrawRectangle(Pens.Green, e.X, e.Y, widthA, heightA); }
                    if (colour == 5) { g.DrawRectangle(Pens.RoyalBlue, e.X, e.Y, widthA, heightA); }
                    if (colour == 6) { g.DrawRectangle(Pens.DarkViolet, e.X, e.Y, widthA, heightA); }
                    if (colour == 7) { g.DrawRectangle(Pens.PaleVioletRed, e.X, e.Y, widthA, heightA); }
                    if (colour == 8) { g.DrawRectangle(Pens.Chocolate, e.X, e.Y, widthA, heightA); }
                    if (colour == 9) { g.DrawRectangle(Pens.Gray, e.X, e.Y, widthA, heightA); }
                    if (colour == 10) { g.DrawRectangle(Pens.Black, e.X, e.Y, widthA, heightA); }
                    rect = false;
                }
            }
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown == true)
            {
                if(penOn == true)
                {
                    Pen myNPen = new Pen(Brushes.Black);
                    Brush myBrush = Brushes.Black;
                    myNPen.Width = trackBar1.Value;
                    widthA = trackBar1.Value;
                    if (colour == 1) { myNPen.Color = Color.Crimson; }
                    if (colour == 2) { myNPen.Color = Color.DarkOrange; }
                    if (colour == 3) { myNPen.Color = Color.Yellow; }
                    if (colour == 4) { myNPen.Color = Color.Green; }
                    if (colour == 5) { myNPen.Color = Color.RoyalBlue; }
                    if (colour == 6) { myNPen.Color = Color.DarkViolet; }
                    if (colour == 7) { myNPen.Color = Color.PaleVioletRed; }
                    if (colour == 8) { myNPen.Color = Color.Chocolate; }
                    if (colour == 9) { myNPen.Color = Color.Gray; }
                    if (colour == 10) { myNPen.Color = Color.Black; }
                    if (colour == 1) { myBrush = Brushes.Crimson; }
                    if (colour == 2) { myBrush = Brushes.DarkOrange; }
                    if (colour == 3) { myBrush = Brushes.Yellow; }
                    if (colour == 4) { myBrush = Brushes.Green; }
                    if (colour == 5) { myBrush = Brushes.RoyalBlue; }
                    if (colour == 6) { myBrush = Brushes.DarkViolet; }
                    if (colour == 7) { myBrush = Brushes.PaleVioletRed; }
                    if (colour == 8) { myBrush = Brushes.Chocolate; }
                    if (colour == 9) { myBrush = Brushes.Gray; }
                    if (colour == 10) { myBrush = Brushes.Black; }
                    g.DrawLine(myNPen, e.Location, lastPosition);
                    int ex = e.X - (widthA / 2);
                    int ey = e.Y - (widthA / 2);
                    g.FillEllipse(myBrush, ex, ey, widthA, widthA);
                    lastPosition = e.Location;
                }
                if(eraser == true)
                {
                    Pen eraser = new Pen(Brushes.White);
                    eraser.Width = 10.0F;
                    g.DrawLine(eraser, e.Location, lastPosition);
                    int ex = e.X - (widthA / 2);
                    int ey = e.Y - (widthA / 2);
                    g.FillEllipse(Brushes.White, ex, ey, widthA, widthA);
                    lastPosition = e.Location;
                }
                if(circlePen == true)
                {
                    widthA = trackBar1.Value * 2;
                    if (colour == 1) { g.DrawEllipse(Pens.Crimson, e.X, e.Y, widthA, widthA); }
                    if (colour == 2) { g.DrawEllipse(Pens.DarkOrange, e.X, e.Y, widthA, widthA); }
                    if (colour == 3) { g.DrawEllipse(Pens.Yellow, e.X, e.Y, widthA, widthA); }
                    if (colour == 4) { g.DrawEllipse(Pens.Green, e.X, e.Y, widthA, widthA); }
                    if (colour == 5) { g.DrawEllipse(Pens.RoyalBlue, e.X, e.Y, widthA, widthA); }
                    if (colour == 6) { g.DrawEllipse(Pens.DarkViolet, e.X, e.Y, widthA, widthA); }
                    if (colour == 7) { g.DrawEllipse(Pens.PaleVioletRed, e.X, e.Y, widthA, widthA); }
                    if (colour == 8) { g.DrawEllipse(Pens.Chocolate, e.X, e.Y, widthA, widthA); }
                    if (colour == 9) { g.DrawEllipse(Pens.Gray, e.X, e.Y, widthA, widthA); }
                    if (colour == 10) { g.DrawEllipse(Pens.Black, e.X, e.Y, widthA, widthA); }
                }
                if (squarePen == true)
                {
                    if (colour == 1) { g.DrawRectangle(Pens.Crimson, e.X, e.Y, widthA, widthA); }
                    if (colour == 2) { g.DrawRectangle(Pens.DarkOrange, e.X, e.Y, widthA, widthA); }
                    if (colour == 3) { g.DrawRectangle(Pens.Yellow, e.X, e.Y, widthA, widthA); }
                    if (colour == 4) { g.DrawRectangle(Pens.Green, e.X, e.Y, widthA, widthA); }
                    if (colour == 5) { g.DrawRectangle(Pens.RoyalBlue, e.X, e.Y, widthA, widthA); }
                    if (colour == 6) { g.DrawRectangle(Pens.DarkViolet, e.X, e.Y, widthA, widthA); }
                    if (colour == 7) { g.DrawRectangle(Pens.PaleVioletRed, e.X, e.Y, widthA, widthA); }
                    if (colour == 8) { g.DrawRectangle(Pens.Chocolate, e.X, e.Y, widthA, widthA); }
                    if (colour == 9) { g.DrawRectangle(Pens.Gray, e.X, e.Y, widthA, widthA); }
                    if (colour == 10) { g.DrawRectangle(Pens.Black, e.X, e.Y, widthA, widthA); }
                }
                if (texturedPen == true)
                {
                    Pen myTPen = new Pen(Brushes.Black);
                    Brush myBrush = Brushes.Black;
                    myTPen.Width = trackBar1.Value;
                    if (colour == 1) { myTPen.Color = Color.Crimson; }
                    if (colour == 2) { myTPen.Color = Color.DarkOrange; }
                    if (colour == 3) { myTPen.Color = Color.Yellow; }
                    if (colour == 4) { myTPen.Color = Color.Green; }
                    if (colour == 5) { myTPen.Color = Color.RoyalBlue; }
                    if (colour == 6) { myTPen.Color = Color.DarkViolet; }
                    if (colour == 7) { myTPen.Color = Color.PaleVioletRed; }
                    if (colour == 8) { myTPen.Color = Color.Chocolate; }
                    if (colour == 9) { myTPen.Color = Color.Gray; }
                    if (colour == 10) { myTPen.Color = Color.Black; }
                    g.DrawLine(myTPen, e.Location, lastPosition);
                    lastPosition = e.Location;
                }
                if (rainbowPen == true)
                {
                    Pen myRPen = new Pen(Brushes.White);
                    Brush myBrush = Brushes.Black;
                    myRPen.Width = trackBar1.Value;
                    widthA = trackBar1.Value * 2;
                    g.DrawLine(myRPen, e.Location, lastPosition);
                    while (true)
                    {
                        Random rng = new Random();
                        int colourR = rng.Next(1, 8);
                        if (colourR == 1) { myBrush = Brushes.Crimson; }
                        if (colourR == 2) { myBrush = Brushes.DarkOrange; }
                        if (colourR == 3) { myBrush = Brushes.Yellow; }
                        if (colourR == 4) { myBrush = Brushes.Green; }
                        if (colourR == 5) { myBrush = Brushes.RoyalBlue; }
                        if (colourR == 6) { myBrush = Brushes.DarkViolet; }
                        if (colourR == 7) { myBrush = Brushes.PaleVioletRed; }
                        int ex = e.X - (widthA / 2);
                        int ey = e.Y - (widthA / 2);
                        g.FillEllipse(myBrush, ex, ey, widthA, widthA);
                        break;
                    }
                    lastPosition = e.Location;
                }
                
                if(callPen == true)
                {
                    Pen myPen = new Pen(Brushes.Black);
                    Brush myBrush = Brushes.Black;      
                    if (colour == 1) { myPen.Color = Color.Crimson; }
                    if (colour == 2) { myPen.Color = Color.DarkOrange; }
                    if (colour == 3) { myPen.Color = Color.Yellow; }
                    if (colour == 4) { myPen.Color = Color.Green; }
                    if (colour == 5) { myPen.Color = Color.RoyalBlue; }
                    if (colour == 6) { myPen.Color = Color.DarkViolet; }
                    if (colour == 7) { myPen.Color = Color.PaleVioletRed; }
                    if (colour == 8) { myPen.Color = Color.Chocolate; }
                    if (colour == 9) { myPen.Color = Color.Gray; }
                    if (colour == 10) { myPen.Color = Color.Black; }

                    if (colour == 1) { myBrush = Brushes.Crimson; }
                    if (colour == 2) { myBrush = Brushes.DarkOrange; }
                    if (colour == 3) { myBrush = Brushes.Yellow; }
                    if (colour == 4) { myBrush = Brushes.Green; }
                    if (colour == 5) { myBrush = Brushes.RoyalBlue; }
                    if (colour == 6) { myBrush = Brushes.DarkViolet; }
                    if (colour == 7) { myBrush = Brushes.PaleVioletRed; }
                    if (colour == 8) { myBrush = Brushes.Chocolate; }
                    if (colour == 9) { myBrush = Brushes.Gray; }
                    if (colour == 10) { myBrush = Brushes.Black; }

                    int ex = e.X - (widthA / 2);
                    int ey = e.Y - (widthA / 2);  

                    g.FillEllipse(myBrush, ex, ey, widthA, widthA);

                    double vector = (lastX - e.X)/(lastY - e.Y);
                    if(vector < 0)
                    {
                        myPen.Width = trackBar1.Value / 2;
                        widthA /= 2;
                    }
                    else
                    {
                        myPen.Width = trackBar1.Value * 3/2;
                        widthA = widthA * 3 / 2;
                    }

                    g.DrawLine(myPen, e.Location, lastPosition);                                   
                    

                    lastPosition = e.Location;
                    lastX = e.X;
                    lastY = e.Y;
                    
                    
                    
                }
            }            
        }

        private void button15_Click(object sender, EventArgs e)
        {
            square = true;
        }
        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            colour = 10;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            colour = 4;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            colour = 1;
        }

        private void panel1_DragEnter(object sender, DragEventArgs e)
        {
            
        }

        private void panel1_DragDrop(object sender, DragEventArgs e)
        {
            
        }

        private void panel1_DragOver(object sender, DragEventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            eraser = true;
            penOn = false;
            circlePen = false;
            squarePen = false;
            texturedPen = false;
            rainbowPen = false; 
            callPen = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            eraser = false;
            penOn = true;
            circlePen = false;
            squarePen = false;
            texturedPen = false;
            rainbowPen = false;
            callPen = false;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            colour = 2;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            colour = 3;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            colour = 5;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            colour = 6;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            colour = 7;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            colour = 8;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            colour = 9;
        }


        private void WidthChangeValue(object sender, EventArgs e)
        {
        }

        private void button16_Click(object sender, EventArgs e)
        {
            elipse = true;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            rect = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string text = textBox1.Text;
            if(int.TryParse(text, out _))
            {
                widthA = Convert.ToInt32(text);
            }
            else { widthA = 100; }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            fillIn = true;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            fillIn = false;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            circlePen = true;
            eraser = false;
            penOn = false;
            squarePen = false;
            texturedPen = false;
            rainbowPen = false;
            callPen = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button21_Click(object sender, EventArgs e)
        {
            squarePen = true;
            circlePen = false;
            eraser = false;
            penOn = false;
            texturedPen = false;
            rainbowPen = false;
            callPen = false;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            texturedPen = true;
            squarePen = false;
            circlePen = false;
            eraser = false;
            penOn = false;
            rainbowPen = false;
            callPen = false;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            rainbowPen = true;
            texturedPen = false;
            squarePen = false;
            circlePen = false;
            eraser = false;
            penOn = false;
            callPen = false;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            callPen = true;
            rainbowPen = false;
            texturedPen = false;
            squarePen = false;
            circlePen = false;
            eraser = false;
            penOn = false;
        }
    }
}
