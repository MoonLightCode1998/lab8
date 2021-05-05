using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    
    public partial class Form1 : Form
    {
        public static int mediana(int[,] array)
        {
            LinkedList<int> test = new LinkedList<int>();
            for (int x = 0; x < 3; x++) {
                for (int y = 0; y < 3; y++) {
                    test.AddLast(array[x, y]);
                }
            }




            return test.OrderBy(x => x).ElementAt(4); ;
        }
        private int[] red=new int[256];
        private int[] green = new int[256];
        private int[] blue = new int[256];
        private int[] allRGB = new int[256];
        int[] array = new int[256];

        private int szer;
        private int wys;
        public Form1()
        {

            InitializeComponent();
         

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog file = new OpenFileDialog())
            {
                if (file.ShowDialog() == DialogResult.OK)
                {
                  
                    pictureBox1.Load(file.FileName);
                    szer = pictureBox1.Image.Width;
                    wys = pictureBox1.Image.Height;
                    pictureBox2.Image = new Bitmap(szer, wys);
                    pictureBox1.Invalidate();
                }
            }




        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            /*if (path != String.Empty) {
                g.DrawImage(im,new Point(0,0));
               
            }*/

        }

        private void panel3_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            /* Graphics g = e.Graphics;
             if (path != String.Empty)
             {
                 g.DrawImage(img, new Point(0, 0));

             }*/
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            /* Graphics g = e.Graphics;
             if (path != String.Empty)
             {
                 g.DrawImage(img, new Point(0, 0));

             }*/
        }

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }

        private void trackBar2_ValueChanged(object sender, EventArgs e)
        {
            label2.Text = trackBar2.Value.ToString();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;

            trackBar1.Maximum = 126;
            trackBar1.Minimum = 0;

            trackBar2.Maximum = 0;
            trackBar2.Minimum = -128;

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            trackBar1.Value = 0;
            trackBar2.Value = 0;

            trackBar1.Maximum = 126;
            trackBar1.Minimum = 0;

            trackBar2.Maximum = 0;
            trackBar2.Minimum = -126;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
                this.allRGB[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
            if (radioButton1.Checked)
                {

                    for (int x = 0; x < szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                          

                            Color c = xz.GetPixel(x, y);
                            int red = c.R;
                            int green = c.G;
                            int blue = c.B;
                          
                            

                            red = (127 / (127 - trackBar1.Value)) * (red - trackBar1.Value);
                            green = (127 / (127 - trackBar1.Value)) * (green - trackBar1.Value);
                            blue = (127 / (127 - trackBar1.Value)) * (blue - trackBar1.Value);
                            if (red > 255)
                                red = 255;
                            else if (red < 0)
                                red = 0;
                            if (green > 255)
                                green = 255;
                            else if (green < 0)
                                green = 0;
                            if (blue > 255)
                                blue = 255;
                            else if (blue < 0)
                                blue = 0;

                            Color nowy = Color.FromArgb(red, green, blue);
                            xy.SetPixel(x, y, nowy);
                            this.red[red] += 1;
                            this.green[green] += 1;
                            this.blue[blue] += 1;
                            
                            pictureBox2.Invalidate();

                        }
                    }
                for (int x = 0; x < 256; x++)
                {
                    this.allRGB[x] += this.red[x] + this.blue[x] + this.green[x];
                }

                panel8.Invalidate();
                panel7.Invalidate();
                panel6.Invalidate();
                panel9.Invalidate();
               
            }
                else
                {
                for (int x = 0; x < 256; x++)
                {
                    this.red[x] = 0;
                    this.green[x] = 0;
                    this.blue[x] = 0;
                }
                for (int x = 0; x < szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                            Color c = xz.GetPixel(x, y);
                            int red = c.R;
                            int green = c.G;
                            int blue = c.B;
                           
                        if (red < 127)
                                red = ((127 - trackBar1.Value) / 127) * red;
                            else
                                red = ((127 - trackBar1.Value) / 127) * red + (2 * trackBar1.Value);

                            if (green < 127)
                                green = ((127 - trackBar1.Value) / 127) * green;
                            else
                                green = ((127 - trackBar1.Value) / 127) * green + (2 * trackBar1.Value);


                            if (blue < 127)
                                blue = ((127 - trackBar1.Value) / 127) * blue;
                            else
                                blue = ((127 - trackBar1.Value) / 127) * blue + (2 * trackBar1.Value);
                            if (red > 255)
                                red = 255;
                            else if (red < 0)
                                red = 0;
                            if (green > 255)
                                green = 255;
                            else if (green < 0)
                                green = 0;
                            if (blue > 255)
                                blue = 255;
                            else if (blue < 0)
                                blue = 0;

                            Color nowy = Color.FromArgb(red, green, blue);
                            xy.SetPixel(x, y, nowy);
                        this.red[red] += 1;
                        this.green[green] += 1;
                        this.blue[blue] += 1;
                        pictureBox2.Invalidate();

                        }
                    }

                }


            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
                this.allRGB[x] = 0;
                this.array[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            if (radioButton1.Checked)
                {
               
                for (int x = 0; x <szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                            Color c = xz.GetPixel(x, y);
                            double red = c.R;
                            double green = c.G;
                            double blue = c.B;
                            

                            red = ((127 + (double)trackBar2.Value) / 127) * (red - (double)trackBar2.Value);
                            green = ((127 + (double)trackBar2.Value) / 127) * (green - (double)trackBar2.Value);
                            blue = ((127 + (double)trackBar2.Value) / 127) * (blue - (double)trackBar2.Value);
                   
                        

                            Color nowy = Color.FromArgb((int)red, (int)green, (int)blue);
                            xy.SetPixel(x, y, nowy);
                            this.red[(int)red] += 1;
                            this.green[(int)green] += 1;
                            this.blue[(int)blue] += 1;
                        

                        }

                    }
                pictureBox2.Invalidate();
                panel8.Invalidate();
                panel7.Invalidate();
                panel6.Invalidate();
            }
                else
                {
                for (int x = 0; x < szer; x++)
                    {
                        for (int y = 0; y < wys; y++)
                        {
                            Color c = xz.GetPixel(x, y);
                            int red = c.R;
                            int green = c.G;
                            int blue = c.B;
                            

                        if (red < (127 + trackBar2.Value))
                            {
                                red = (127 / (127 + trackBar2.Value)) * red;
                            }
                            else if (red > (127 - trackBar2.Value))
                            {
                                red = (127 * red + 255 * trackBar2.Value) / (127 + trackBar2.Value);
                            }
                            else
                                red = 127;

                            if (green < (127 + trackBar2.Value))
                            {
                                green = (127 / (127 + trackBar2.Value)) * green;
                            }
                            else if (green > (127 - trackBar2.Value))
                            {
                                green = (127 * green + 255 * trackBar2.Value) / (127 + trackBar2.Value);
                            }
                            else
                                green = 127;

                            if (blue < (127 + trackBar2.Value))
                            {
                                blue = (127 / (127 + trackBar2.Value)) * blue;
                            }
                            else if (blue > (127 - trackBar2.Value))
                            {
                                blue = (127 * blue + 255 * trackBar2.Value) / (127 + trackBar2.Value);
                            }
                            else
                                blue = 127;


                            Color nowy = Color.FromArgb(red, green, blue);
                            xy.SetPixel(x, y, nowy);
                        this.red[red] += 1;
                        this.green[green] += 1;
                        this.blue[blue] += 1;
                        pictureBox2.Invalidate();

                        }
                    }
                }

            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
            panel9.Invalidate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
          
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(blue, green, blue);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[blue] += 1;
                    this.green[green] += 1;
                    this.blue[blue] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            //red
            Graphics g = e.Graphics;
            Color redo = Color.FromArgb(255, 0, 0);
            if (szer != 0) { 
            for (int x = 0; x < this.red.Length; x++)
            {

                g.DrawLine(new Pen(redo), new Point(x, panel8.Height),
                    new Point(x, panel8.Height-((this.red[x])/10)) );
            }
        }
            

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {
            //green
            Graphics g = e.Graphics;
            Color redo = Color.FromArgb(0, 255, 0);
            if (szer != 0)
            {
                for (int x = 0; x < this.red.Length; x++)
                {

                    g.DrawLine(new Pen(redo), new Point(x, panel7.Height), new Point(x, panel7.Height - ((this.green[x]) / 10)));
                }
            }
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
            //blue
            Graphics g = e.Graphics;
            Color redo = Color.FromArgb(0, 0, 255);
            if (szer != 0)
            {
                for (int x = 0; x < this.red.Length; x++)
                {

                    g.DrawLine(new Pen(redo), new Point(x, panel6.Height), new Point(x, panel6.Height - ((this.blue[x]) / 10)));
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(blue, green, red);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[blue] += 1;
                    this.green[green] += 1;
                    this.blue[red] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(green, red, blue);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[green] += 1;
                    this.green[red] += 1;
                    this.blue[blue] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;

                    Color nowy = Color.FromArgb(red, blue, green);
                    xy.SetPixel(x, y, nowy);
                    pictureBox2.Invalidate();
                    this.red[red] += 1;
                    this.green[blue] += 1;
                    this.blue[green] += 1;

                }
            }
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            // kopiuj na lewo
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                   

                  
                    xz.SetPixel(x, y, xy.GetPixel(x,y));
                   
                    

                }
            }
            pictureBox1.Invalidate();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            //monomono
            Cursor = Cursors.WaitCursor;
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
            int a;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    a = (red + green + blue) / 3;

                    Color nowy = Color.FromArgb(a,a,a);
                    xy.SetPixel(x, y, nowy);
                
                   

                }
            }
            pictureBox2.Invalidate();
            Cursor = Cursors.Default;
        }
        //progowanie
        private void button11_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int prog = (int)numericUpDown1.Value;
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
            int a;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    a = (red + green + blue) / 3;

                    if (a < prog)
                    {
                        
                        xy.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else {
                     
                        xy.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                    }



                }
            }
            pictureBox2.Invalidate();
            Cursor = Cursors.Default;
        }
        //podwojne progowanie
        private void button12_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int prog = (int)numericUpDown2.Value;
            int prog2 = (int)numericUpDown3.Value;
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
            int a;
            for (int x = 0; x < szer; x++)
            {
                for (int y = 0; y < wys; y++)
                {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    a = (red + green + blue) / 3;

                    if (a < prog){
                        xy.SetPixel(x, y, Color.FromArgb(0, 0, 0));
                    }
                    else if(a>prog && a<prog2){
                        xy.SetPixel(x, y, Color.Gray);
                    }
                    else
                        xy.SetPixel(x, y, Color.FromArgb(255, 255, 255));
                }
            }
            pictureBox2.Invalidate();
            Cursor = Cursors.Default;
        }
        //kontur
        private void button13_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            int prog = (int)numericUpDown4.Value;
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 1; x < szer-1; x++)
            {
                for (int y = 1; y < wys-1; y++)
                {
                    Color k, k1, k2;
                    
                        k = xz.GetPixel(x, y);
                    k1 = xz.GetPixel(x + 1, y);
                    k2 = xz.GetPixel(x, y + 1);

                    
                        if (Math.Abs(k.R - k1.R) > prog || Math.Abs(k.R - k2.R) > prog ||
                            Math.Abs(k.G - k1.G) > prog || Math.Abs(k.G - k2.G) > prog ||
                            Math.Abs(k.B - k1.B) > prog || Math.Abs(k.B - k2.B) > prog)
                        {

                            xy.SetPixel(x, y, Color.Black);
                        }
                        else
                        {

                            xy.SetPixel(x, y, Color.White);
                        }


                    }
                   

                    
            }
                pictureBox2.Invalidate();
                Cursor = Cursors.Default;
            
        }

        private void panel9_Paint(object sender, PaintEventArgs e)
        {
            //RGB
            Graphics g = e.Graphics;
            Color redo = Color.Gray;
            if (szer != 0)
            {
                for (int x = 0; x < this.red.Length; x++)
                {

                    g.DrawLine(new Pen(redo), new Point(x, panel9.Height),
                        new Point(x, panel9.Height - (int)((((double)this.allRGB[x])/(double)(szer*wys))*1000)));
                }
            }
        }
        //wyrownywanie histogramu
        private void button14_Click(object sender, EventArgs e)
        {
           

            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
                this.allRGB[x] = 0;
                this.array[x] = 0;
            }
            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;
            

                for (int x = 0; x < szer; x++)
                {
                    for (int y = 0; y < wys; y++)
                    {
                        Color c = xz.GetPixel(x, y);
                        int red = c.R;
                        int green = c.G;
                        int blue = c.B;
           

                        this.red[red] += 1;
                        this.green[green] += 1;
                        this.blue[blue] += 1;

                    

                    }
                }
                for (int x = 0; x < 256; x++)
                {
                    this.allRGB[x] += this.red[x] + this.blue[x] + this.green[x];
                }
          
            //histogram kumulacyjny
            array[0] = this.allRGB[0];
            for (int x = 1; x < 256; x++) {
                array[x] = this.allRGB[x] + array[x - 1];
            }
            //nowe wartosci
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
                this.allRGB[x] = 0;
         
            }
            for (int x = 0; x < szer; x++)
                {
                    for (int y = 0; y < wys; y++)
                    {
                    Color c = xz.GetPixel(x, y);
                    int red = c.R;
                    int green = c.G;
                    int blue = c.B;
                    int a = (red + green + blue) / 3;
                    red = (int)((255 / (double)(szer * wys)) * (array[a]/3));
                    green = (int)((255 / (double)(szer * wys)) * (array[a]/3));
                    blue= (int)((255 / (double)(szer * wys)) * (array[a]/3));

                    this.red[red] += 1;
                    this.green[green] += 1;
                    this.blue[blue] += 1;


                    Color z = Color.FromArgb(red, green, blue);
                    xy.SetPixel(x,y,z);

                       

                    }
            }
            for (int x = 0; x < 256; x++)
            {
                this.allRGB[x] += this.red[x] + this.blue[x] + this.green[x];
            }
            pictureBox2.Invalidate();
            panel10.Invalidate();
            panel8.Invalidate();
                panel7.Invalidate();
                panel6.Invalidate();
                panel9.Invalidate();

            }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {
            //RGB
            Graphics g = e.Graphics;
            Color redo = Color.Gray;
            if (szer != 0)
            {
                for (int x = 0; x < this.red.Length; x++)
                {

                    g.DrawLine(new Pen(redo), new Point(x, panel10.Height),
                        new Point(x, panel10.Height - (int)((((double)this.array[x]) / (double)(szer * wys))*30)));
                }
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
          
            int k = 1;
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
                this.allRGB[x] = 0;
                this.array[x] = 0;

            }

            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x =1;x<szer-1;x++) {
                for (int y=1;y<wys-1;y++) {
                    double red = 0;
                    double green = 0;
                    double blue = 0;
                    for (int i = -k; i <= k; i++) {
                        for (int j = -k; j <= k; j++) {

                            Color c = xz.GetPixel(x+i, y+j);
                            red += c.R/9 ;
                            green += c.G/9 ;
                            blue+= c.B/9;

                        }
                    }
                    this.red[(int)red] += 1;
                    this.green[(int)green] += 1;
                    this.blue[(int)blue] += 1;
                    xy.SetPixel(x, y, Color.FromArgb((int)red,(int)green,(int)blue));
                }
            }
            for (int x = 0; x < 256; x++)
            {
                this.allRGB[x] += this.red[x] + this.blue[x] + this.green[x];
            }
            pictureBox2.Invalidate();
            panel10.Invalidate();
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
            panel9.Invalidate();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            int[,] array2=new int[3,3];
            array2[0,0]= 1;
            array2[0,1] = 2;
            array2[0,2] = 1;
            array2[1,0] = 2;
            array2[1,1] = 4;
            array2[1,2] = 2;
            array2[2,0] = 1;
            array2[2,1] = 2;
            array2[2,2] = 1;

            int k = 1;
            for (int x = 0; x < 256; x++)
            {
                this.red[x] = 0;
                this.green[x] = 0;
                this.blue[x] = 0;
                this.allRGB[x] = 0;
                this.array[x] = 0;

            }

            Bitmap xz = (Bitmap)pictureBox1.Image;
            Bitmap xy = (Bitmap)pictureBox2.Image;

            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    double red = 0;
                    double green = 0;
                    double blue = 0;
                    for (int i = -k; i <= k; i++)
                    {
                        for (int j = -k; j <= k; j++)
                        {

                            Color c = xz.GetPixel(x + i, y + j);
                            red += c.R * ((double)array2[i + k,j+k]/16);
                            green += c.G * ((double)array2[i + k, j + k] / 16);
                            blue += c.B * ((double)array2[i + k, j + k] / 16);

                        }
                    }
                    this.red[(int)red] += 1;
                    this.green[(int)green] += 1;
                    this.blue[(int)blue] += 1;
                    xy.SetPixel(x, y, Color.FromArgb((int)red, (int)green, (int)blue));
                }
            }
            for (int x = 0; x < 256; x++)
            {
                this.allRGB[x] += this.red[x] + this.blue[x] + this.green[x];
            }
            pictureBox2.Invalidate();
            panel10.Invalidate();
            panel8.Invalidate();
            panel7.Invalidate();
            panel6.Invalidate();
            panel9.Invalidate();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            switch ((int)listBox1.SelectedIndex)
            {
                case 0:
                    {

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;

                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {

                                int red = Math.Abs(xz.GetPixel(x, y).R - xz.GetPixel(x + 1, y).R);
                                int green = Math.Abs(xz.GetPixel(x, y).G - xz.GetPixel(x + 1, y).G);
                                int blue = Math.Abs(xz.GetPixel(x, y).B - xz.GetPixel(x + 1, y).B);

                                xy.SetPixel(x, y, Color.FromArgb(red, green, blue));


                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 1:
                    {
                        double[,] array2 = new double[3, 3];
                        array2[0, 0] = 1;
                        array2[0, 1] = 1;
                        array2[0, 2] = 1;
                        array2[1, 0] = 0;
                        array2[1, 1] = 0;
                        array2[1, 2] = 0;
                        array2[2, 0] = -1;
                        array2[2, 1] = -1;
                        array2[2, 2] = -1;

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;
                        int k = 1;

                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {


                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i - 1, y + j - 1);
                                        red += c.R * (array2[i, j]);
                                        green += c.G * (array2[i, j]);
                                        blue += c.B * (array2[i, j]);

                                    }
                                }

                                if (red > 255)
                                    red = 255;
                                else if (red < 0)
                                    red = 0;
                                if (green > 255)
                                    green = 255;
                                else if (green < 0)
                                    green = 0;
                                if (blue > 255)
                                    blue = 255;
                                else if (blue < 0)
                                    blue = 0;
                                xy.SetPixel(x, y, Color.FromArgb((int)(red), (int)(green), (int)(blue)));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 2:
                    {
                        double[,] array2 = new double[3, 3];
                        array2[0, 0] = 1;
                        array2[0, 1] = 2;
                        array2[0, 2] = 1;
                        array2[1, 0] = 0;
                        array2[1, 1] = 0;
                        array2[1, 2] = 0;
                        array2[2, 0] = -1;
                        array2[2, 1] = -2;
                        array2[2, 2] = -1;

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;
                        int k = 1;

                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {


                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i - 1, y + j - 1);
                                        red += c.R * (array2[i, j]);
                                        green += c.G * (array2[i, j]);
                                        blue += c.B * (array2[i, j]);

                                    }
                                }

                                if (red > 255)
                                    red = 255;
                                else if (red < 0)
                                    red = 0;
                                if (green > 255)
                                    green = 255;
                                else if (green < 0)
                                    green = 0;
                                if (blue > 255)
                                    blue = 255;
                                else if (blue < 0)
                                    blue = 0;
                                xy.SetPixel(x, y, Color.FromArgb((int)(red), (int)(green), (int)(blue)));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 3:
                    {

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;

                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {

                                int red = Math.Abs(xz.GetPixel(x, y).R - xz.GetPixel(x , y+1).R);
                                int green = Math.Abs(xz.GetPixel(x, y).G - xz.GetPixel(x + 1, y+1).G);
                                int blue = Math.Abs(xz.GetPixel(x, y).B - xz.GetPixel(x + 1, y+1).B);

                                xy.SetPixel(x, y, Color.FromArgb(red, green, blue));


                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 4:
                    {
                        double[,] array2 = new double[3, 3];
                        array2[0, 0] = 1;
                        array2[0, 1] = 0;
                        array2[0, 2] = -1;
                        array2[1, 0] = 1;
                        array2[1, 1] = 0;
                        array2[1, 2] = -1;
                        array2[2, 0] = 1;
                        array2[2, 1] = 0;
                        array2[2, 2] = -1;

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;
                        int k = 1;

                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {


                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i - 1, y + j - 1);
                                        red += c.R * (array2[i, j]);
                                        green += c.G * (array2[i, j]);
                                        blue += c.B * (array2[i, j]);

                                    }
                                }

                                if (red > 255)
                                    red = 255;
                                else if (red < 0)
                                    red = 0;
                                if (green > 255)
                                    green = 255;
                                else if (green < 0)
                                    green = 0;
                                if (blue > 255)
                                    blue = 255;
                                else if (blue < 0)
                                    blue = 0;
                                xy.SetPixel(x, y, Color.FromArgb((int)(red), (int)(green), (int)(blue)));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 5:
                    {
                        double[,] array2 = new double[3, 3];
                        array2[0, 0] = 1;
                        array2[0, 1] = 0;
                        array2[0, 2] =-1;
                        array2[1, 0] = 2;
                        array2[1, 1] = 0;
                        array2[1, 2] = -2;
                        array2[2, 0] = 1;
                        array2[2, 1] = 0;
                        array2[2, 2] = -1;

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;
                        int k = 1;

                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {


                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i - 1, y + j - 1);
                                        red += c.R * (array2[i, j]);
                                        green += c.G * (array2[i, j]);
                                        blue += c.B * (array2[i, j]);

                                    }
                                }

                                if (red > 255)
                                    red = 255;
                                else if (red < 0)
                                    red = 0;
                                if (green > 255)
                                    green = 255;
                                else if (green < 0)
                                    green = 0;
                                if (blue > 255)
                                    blue = 255;
                                else if (blue < 0)
                                    blue = 0;
                                xy.SetPixel(x, y, Color.FromArgb((int)(red), (int)(green), (int)(blue)));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 6:
                    {
                        double[,] array2 = new double[3, 3];
                        array2[0, 0] = -1;
                        array2[0, 1] = -1;
                        array2[0, 2] = -1;
                        array2[1, 0] = -1;
                        array2[1, 1] = 8;
                        array2[1, 2] = -1;
                        array2[2, 0] = -1;
                        array2[2, 1] = -1;
                        array2[2, 2] = -1;

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;
             

                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {


                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i-1, y + j-1);
                                        red += c.R * (array2[i , j ]);
                                        green += c.G * (array2[i , j ]);
                                        blue += c.B * (array2[i , j ]);

                                    }
                                }
                              
                                if (red > 255)
                                    red = 255;
                                else if (red < 0)
                                    red = 0;
                                if (green > 255)
                                    green = 255;
                                else if (green < 0)
                                    green = 0;
                                if (blue > 255)
                                    blue = 255;
                                else if (blue < 0)
                                    blue = 0;
                                xy.SetPixel(x, y, Color.FromArgb((int)(red), (int)(green), (int)(blue)));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 7:
                    {
                        

                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;


                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {


                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i - 1, y + j - 1);
                                        if (red == 0 && green == 0 && blue == 0)
                                        {
                                            red = c.R;
                                            green =c.G;
                                            blue = c.B;
                                        }
                                        else
                                        {
                                            red = Math.Min(red, c.R);
                                            green = Math.Min(green, c.G);
                                            blue = Math.Min(blue, c.B);
                                        }
                                    }
                                }

                                if (red > 255)
                                    red = 255;
                                else if (red < 0)
                                    red = 0;
                                if (green > 255)
                                    green = 255;
                                else if (green < 0)
                                    green = 0;
                                if (blue > 255)
                                    blue = 255;
                                else if (blue < 0)
                                    blue = 0;
                                xy.SetPixel(x, y, Color.FromArgb((int)(red), (int)(green), (int)(blue)));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 8:
                    {


                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;


                        for (int x = 1; x < szer - 1; x++)
                        {
                            for (int y = 1; y < wys - 1; y++)
                            {


                                double red = 0;
                                double green = 0;
                                double blue = 0;
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i - 1, y + j - 1);
                                        if (red == 0 && green == 0 && blue == 0)
                                        {
                                            red = c.R;
                                            green = c.G;
                                            blue = c.B;
                                        }
                                        else
                                        {
                                            red = Math.Max(red, c.R);
                                            green = Math.Max(green, c.G);
                                            blue = Math.Max(blue, c.B);
                                        }
                                    }
                                }

                                if (red > 255)
                                    red = 255;
                                else if (red < 0)
                                    red = 0;
                                if (green > 255)
                                    green = 255;
                                else if (green < 0)
                                    green = 0;
                                if (blue > 255)
                                    blue = 255;
                                else if (blue < 0)
                                    blue = 0;
                                xy.SetPixel(x, y, Color.FromArgb((int)(red), (int)(green), (int)(blue)));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
                case 9:
                    {
                        int[,] reda = new int[3, 3];
                        int[,] greena = new int[3, 3];
                        int[,] bluea = new int[3, 3];
                    



                        Bitmap xz = (Bitmap)pictureBox1.Image;
                        Bitmap xy = (Bitmap)pictureBox2.Image;
                        int red;
                        int green;
                        int blue;

                        for (int x = 1; x < szer-1; x++)
                        {
                            for (int y = 1; y <wys-1; y++)
                            {


                           
                                for (int i = 0; i < 3; i++)
                                {
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Color c = xz.GetPixel(x + i - 1, y + j - 1);
                                        reda[i, j] = c.R;
                                        greena[i, j] = c.G;
                                        bluea[i, j] = c.B;

                                        
                                    }
                                }

                                red = mediana(reda);
                                green = mediana(greena);
                                blue = mediana(bluea);
                              

                                
                                xy.SetPixel(x, y, Color.FromArgb(red,green,blue));
                            }
                        }
                        pictureBox2.Invalidate();
                        break;
                    }
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            Bitmap b1 = (Bitmap)pictureBox1.Image;
            Bitmap b2 = (Bitmap)pictureBox2.Image;
            int[,] maska = new int[3, 3];
            maska[0, 0] = (int)numericUpDown5.Value;
            maska[0, 1] = (int)numericUpDown6.Value;
            maska[0, 2] = (int)numericUpDown7.Value;

            maska[1, 0] = (int)numericUpDown8.Value;
            maska[1, 1] = (int)numericUpDown9.Value;
            maska[1, 2] = (int)numericUpDown10.Value;

            maska[2, 0] = (int)numericUpDown11.Value;
            maska[2, 1] = (int)numericUpDown12.Value;
            maska[2, 2] = (int)numericUpDown13.Value;
            int norm = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    norm += maska[i, j];
                }
            }
                    Color k;
            int R, G, B;
            for (int x = 1; x < szer - 1; x++)
            {
                for (int y = 1; y < wys - 1; y++)
                {
                    R = 0;
                    G = 0;
                    B = 0;
                    for (int i = 0; i < 3; i++)
                                            {
                        for (int j = 0; j < 3; j++) {
                            k = b1.GetPixel(x + i-1, y + j-1);
                            R += k.R * maska[i, j];
                            G += k.G * maska[i, j];
                            B += k.B * maska[i, j];
                          
                }
            }
                    if (norm != 0) {
                        R /= norm;
                        G /= norm;
                        B /= norm;
                    }
                    if (R > 255)
                        R = 255;
                    else if (R < 0)
                        R = 0;
                    if (G > 255)
                        G = 255;
                    else if (G < 0)
                        G = 0;
                    if (B > 255)
                       B = 255;
                    else if (B < 0)
                        B = 0;
                    b2.SetPixel(x, y, Color.FromArgb(R, G, B));







                }



            }
            pictureBox2.Invalidate();
            Cursor = Cursors.Default;
        }

        

           


        
    }

}
