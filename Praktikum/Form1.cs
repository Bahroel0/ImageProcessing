using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Praktikum
{
    public partial class Form1 : Form
    {
        Image File;
        int r, g, b;
        Bitmap objBitmap, objBitmapCopy, obj;
        public Form1()
        {
            InitializeComponent();
            CreateBendera();
        }

        public void CreateBendera()
        {
            Bitmap flag = new Bitmap(400, 200);
            for(int x=0; x<flag.Width; x++)
                for (int y = 0; y < flag.Height; y++)
                {
                    if (y < flag.Height / 2)
                    {
                        Color red = Color.FromArgb(255, 0, 0);
                        flag.SetPixel(x, y, red);
                    }
                    else
                    {
                        Color white = Color.FromArgb(255, 255, 255);
                        flag.SetPixel(x, y, white);
                    }
                }
            pictureBoxBendera.Image = flag;
        }

        private void ChangeColor()
        {
            r = redSlider.Value;
            g = greenSlider.Value;
            b = blueSlider.Value;

            pictureBoxRed.BackColor = Color.FromArgb(r, 0, 0);
            pictureBoxGreen.BackColor = Color.FromArgb(0, g, 0);
            pictureBoxBlue.BackColor = Color.FromArgb(0, 0, b);
            pictureBoxMix.BackColor = Color.FromArgb(r, g, b);
        }



        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                File = Image.FromFile(openFileDialog1.FileName);
                pictureBox1.Image = File;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "jpg (*.jpg)|*.jpg|bmp (*.bmp)|*.bmp";
            if (sfd.ShowDialog() == DialogResult.OK && sfd.FileName.Length > 0)
            {
                pictureBox1.Image.Save(sfd.FileName);
            }
        }

        private void redSlider_Scroll(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void greenSlider_Scroll(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void blueSlider_Scroll(object sender, EventArgs e)
        {
            ChangeColor();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureCopy.Image = objBitmap;
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            // objBitmap adalah objek dari picture yang di load (Picture Source)
            objBitmapCopy = new Bitmap(objBitmap);
            for(int x=0; x<objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    // setiap nilai pixel dari image asal diambil
                    Color w = objBitmap.GetPixel(x, y);
                    // pixel yang sudah diambil disalin ke image baru
                    objBitmapCopy.SetPixel(x, y, w);
                }
            pictureCopy2.Image = objBitmapCopy;
        }


        private void btnLoadFlip_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox2.Image = objBitmap;
            }
        }

        private void btnFH_Click(object sender, EventArgs e)
        {
            // objBitmap adalah objek dari picture yang di load (Picture Source)
            obj = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    // pixel dari image asal disalin ke korndinat x yang berlawanan
                    obj.SetPixel(objBitmap.Width - 1 - x, y, w);
                }
            // meampilkan obj sebagai picture hasil dari proses flip horizontal
            pictureBox3.Image = obj;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // objBitmap adalah objek dari picture yang di load (Picture Source)
            obj = new Bitmap(objBitmap);
            for (int x = 0; x < objBitmap.Width; x++)
                for (int y = 0; y < objBitmap.Height; y++)
                {
                    Color w = objBitmap.GetPixel(x, y);
                    // pixel dari image asal disalin ke korndinat y yang berlawanan
                    obj.SetPixel(x, objBitmap.Height - 1 - y, w);
                }
            // meampilkan obj sebagai picture hasil dari proses flip vertical
            pictureBox4.Image = obj;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //object rotate dibuat dengan penambahan pixel agar proses set pixel tidak error.
            Bitmap rotate = new Bitmap(pictureBox2.Height + 300, pictureBox2.Width + 500);
            Bitmap ImageSource = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < ImageSource.Width; x++)
                for (int y = 0; y < ImageSource.Height; y++)
                {
                    Color color = ImageSource.GetPixel(x, y);
                    // pixel pada kordinat 0,0 akan berubah pada x terbesar dan y terbesar
                    rotate.SetPixel(ImageSource.Width - x - 1, ImageSource.Height -y -1, color);
                }

            // menampilkan obj sebagai picture hasil dari proses rotate 90 degrees
            pictureBox7.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox7.Image = rotate;
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            //object rotate dibuat dengan penambahan pixel agar proses set pixel tidak error.
            Bitmap rotate = new Bitmap(pictureBox2.Height+300, pictureBox2.Width+300);
            Bitmap ImageSource = (Bitmap)pictureBox2.Image;

            for (int x = 0; x < ImageSource.Width; x++)
                for (int y = 0; y < ImageSource.Height; y++ )
                {
                    Color color = ImageSource.GetPixel(x, y);
                    // korninat y berpindah urutan menjadi kordinat x pada iamage hasil
                    rotate.SetPixel(ImageSource.Height - y - 1, x, color);
                }

            pictureRotate.SizeMode = PictureBoxSizeMode.Zoom;
            // menampilkan obj sebagai picture hasil dari proses rotate 90 degrees
            pictureRotate.Image = rotate;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap greyscale = new Bitmap(ob.Width, ob.Height);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // nilai gray didapat dari rata2  nilai rgb dari suatu titik pixel
                    int gray = (red + green + blue) / 3;
                    greyscale.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pictureBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox5.Image = greyscale;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBox6.Image = objBitmap;
            }
        }

        private void btnBiner_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap biner = new Bitmap(ob.Width, ob.Height);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int grey = (red + green + blue) / 3;
                    /* nilai biner hanya memiliki 2 nilai yaitu 0 atau 1
                     nilai 0-127 dijadikan nilai 0(gelap) sedangkan 128-255 dijadikan nilai 1(terang)
                    */
                    if (grey < 128)
                    {
                        grey = 0;
                    }
                    else
                    {
                        grey = 255;
                    }
                    biner.SetPixel(x, y, Color.FromArgb(grey, grey, grey));
                }
            pictureBoxBiner.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBiner.Image = biner;
        }

        private void btnk16_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap k16 = new Bitmap(ob.Width, ob.Height);
            // variabel kuan sebagai nilai dari setiap area.
            int kuan = 256 / 16;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray = (red + green + blue) / 3;
                    // variabel th digunakan untuk menentukan nilai dari range kuantisasi yang akan digunakan untuk pewarnaan
                    int th = gray/kuan;
                    int xgray = kuan * th;
                    k16.SetPixel(x,y,Color.FromArgb(xgray,xgray,xgray));
                }
            pictureBoxk16.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxk16.Image = k16;
        }

        private void btnk4_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap k4 = new Bitmap(ob.Width, ob.Height);
            // variabel kuan sebagai nilai dari setiap area.
            int kuan = 256 / 4;
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray = (red + green + blue) / 3;
                    // variabel th digunakan untuk menentukan nilai dari range kuantisasi yang akan digunakan untuk pewarnaan
                    int th = gray / kuan;
                    int xgray = kuan * th;
                    k4.SetPixel(x, y, Color.FromArgb(xgray, xgray, xgray));
                }
            pictureBoxk4.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxk4.Image = k4;
        }

        private void btnk2_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap k2 = new Bitmap(ob.Width, ob.Height);
            // variabel kuan sebagai nilai dari setiap area.
            int kuan = 256 / 2;
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray = (red + green + blue) / 3;
                    // variabel th digunakan untuk menentukan nilai dari range kuantisasi yang akan digunakan untuk pewarnaan
                    int th = gray / kuan;
                    int xgray = kuan * th;
                    k2.SetPixel(x, y, Color.FromArgb(xgray, xgray, xgray));
                }
            pictureBoxk2.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxk2.Image = k2;
        }

        private void btnBrig_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxLoadEnh.Image;
            Color color;
            // nilai k diambil dari nilai yang diinputkan pada texbox
            int k = int.Parse(textBoxBrig.Text);

            Bitmap brigness = new Bitmap(ob.Width, ob.Height);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray = (red + green + blue) / 3;
                    // formulasi dari brigness yaitu nilai rata2 rgb ditambah dengan k
                    gray = gray + k;
                    if (gray < 0)
                    {
                        gray = 0;
                    }if(gray > 255)
                    {
                        gray = 255;
                    }
                    brigness.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pictureBoxBrig.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxBrig.Image = brigness;
        }

        private void btnLoadEnh_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBoxLoadEnh.Image = objBitmap;
            }
        }

        private void btnContr_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxLoadEnh.Image;
            Color color;
            // nilai k diambil dari nilai yang diinputkan pada texbox
            int k = int.Parse(textBoxContr.Text);
            Bitmap contras = new Bitmap(ob.Width, ob.Height);
            for (int x=0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++){
                    color = ob.GetPixel(x,y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray;
                    gray = (int)(red+green+blue) / 3;
                    // formulasi dari brigness yaitu nilai rata2 rgb dikali dengan k
                    gray = (int)gray * k;
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    contras.SetPixel(x, y, Color.FromArgb(gray,gray, gray));
                }
            pictureBoxContr.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxContr.Image = contras;
        }

        private void btnAuto_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxLoadEnh.Image;
            Color color;
            Bitmap auto = new Bitmap(ob.Width, ob.Height);
            int xmax = 300, xmin = 0;
            // looping untuk menentukan nilai xmin dan xmax dari sebuah image
            for (int x=0; x<ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray = (int)(red + green + blue) / 3;
                    if (gray < xmax)
                    {
                        xmax = gray;
                    }
                    if (gray > xmin)
                    {
                        xmin = gray;
                    }
                }
            // nilai xmin - xmax
            int d = xmin - xmax;
            
            for (int x=0; x<ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray = (int)(red + green + blue) / 3;

                    // rumus autolevel
                    gray = (int) ((float)255/d * (gray-xmax));

                    auto.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pictureBoxAuto.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAuto.Image = auto;
        } 
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        // kuantisasi 16 non grayscale image
        private void button10_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap k2 = new Bitmap(ob.Width, ob.Height);
            // variabel kuan sebagai nilai dari setiap area.
            int kuan = 256 / 16;
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // variabel th digunakan untuk menentukan nilai dari range kuantisasi yang akan digunakan untuk pewarnaan
                    int thR = red / kuan;
                    int thG = green / kuan;
                    int thB = blue / kuan;
                    int xR = kuan * thR;
                    int xG = kuan * thG;
                    int xB = kuan * thB;
                    k2.SetPixel(x, y, Color.FromArgb(xR, xG, xB));
                }
            pictureBox15.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox15.Image = k2;
        }

        //kuantisasi 4 non grayscale image
        private void button11_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap k2 = new Bitmap(ob.Width, ob.Height);
            // variabel kuan sebagai nilai dari setiap area.
            int kuan = 256 / 4;
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // variabel th digunakan untuk menentukan nilai dari range kuantisasi yang akan digunakan untuk pewarnaan
                    int thR = red / kuan;
                    int thG = green / kuan;
                    int thB = blue / kuan;
                    int xR = kuan * thR;
                    int xG = kuan * thG;
                    int xB = kuan * thB;
                    k2.SetPixel(x, y, Color.FromArgb(xR, xG, xB));
                }
            pictureBox16.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox16.Image = k2;
        }

        //kuantisasi 2 non grayscale image
        private void button12_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBox6.Image;
            Color color;
            Bitmap k2 = new Bitmap(ob.Width, ob.Height);
            // variabel kuan sebagai nilai dari setiap area.
            int kuan = 256 / 2;
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;

                    // variabel th digunakan untuk menentukan nilai dari range kuantisasi yang akan digunakan untuk pewarnaan
                    int thR = red / kuan;
                    int thG = green / kuan;
                    int thB = blue / kuan;
                    int xR = kuan * thR;
                    int xG = kuan * thG;
                    int xB = kuan * thB;
                    k2.SetPixel(x, y, Color.FromArgb(xR, xG, xB));
                }
            pictureBox17.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox17.Image = k2;
        }


        // Praktikum 6
        private void btnPicSourceTr_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBoxSourceTr.Image = objBitmap;
            }
        }

        private void btnNegative_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceTr.Image;
            Color color;
            
            for(int x=0; x<ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color       = ob.GetPixel(x,y);

                    int red     = color.R;
                    int green   = color.G;
                    int blue    = color.B;
                    // merubah dari gambar rgb ke grayscale
                    int gray = (int)(red + green + blue) / 3;
                    // rumus Matematika (hitam jadi putih dan sebaliknya)
                    gray = 255 - gray;
                    ob.SetPixel(x,y,Color.FromArgb(gray,gray,gray));
                }
            pictureBoxResult.Image = new Bitmap(pictureBoxResult.Width, pictureBoxResult.Height);
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxResult.Image = ob;
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceTr.Image;
            Color color;
            int c = int.Parse(textBoxC.Text);
            for(int x=0; x<ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // merubah dari gambar rgb ke grayscale
                    int gray = (int)(red + green + blue) / 3;
                    // rumus matematika
                    gray = (int)(c * Math.Log(10,gray+1));
                    // error handling value dari pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    ob.SetPixel(x, y, Color.FromArgb(gray,gray,gray));
                }
            pictureBoxResult.Image = new Bitmap(pictureBoxResult.Width, pictureBoxResult.Height);
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxResult.Image = ob;
        }

        private void btnInversiLog_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceTr.Image;
            Color color;
            // didapat dari slider yang diatur maksimal valuenya
            int max = valueSlider.Value;
            int c = int.Parse(textBoxC.Text);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // merubah dari gambar rgb ke grayscale
                    int gray = (int)(red + green + blue) / 3;
                    // rumus matematika
                    gray = (int)(c * Math.Log(10, max - (gray+1)));
                    // error handling value dari pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    ob.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pictureBoxResult.Image = new Bitmap(pictureBoxResult.Width, pictureBoxResult.Height);
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxResult.Image = ob;
        }

        private void btnPower_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceTr.Image;
            Color color;
            float c = float.Parse(textBoxC.Text);
            float c2 = float.Parse(textBoxY.Text);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // merubah dari gambar rgb ke grayscale
                    int gray = (int)(red + green + blue) / 3;
                    // rumus matematika
                    gray = (int)(c * gray * Math.Exp(c2));
                    // error handling value dari pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    ob.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pictureBoxResult.Image = new Bitmap(pictureBoxResult.Width, pictureBoxResult.Height);
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxResult.Image = ob;
        }

        private void btnRootPower_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceTr.Image;
            Color color;
            float c = float.Parse(textBoxC.Text);
            float c2 = float.Parse(textBoxY.Text);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // merubah dari gambar rgb ke grayscale
                    int gray = (int)(red + green + blue) / 3;
                    // rumus matematika
                    gray = (int)(c * gray * Math.Exp(1/c2));
                    // error handling value dari pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    ob.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pictureBoxResult.Image = new Bitmap(pictureBoxResult.Width, pictureBoxResult.Height);
            pictureBoxResult.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxResult.Image = ob;
        }


        // Praktikum Reduce Noise
        //  Load Image Source
        private void btnSourceRN_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pictureBoxSourceRN.Image = objBitmap;
            }

        }


        // Noise Uniform
        private void btnNG_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceRN.Image;
            Color color;
            int value = int.Parse(textBoxPercentaceNoise.Text);
            double percentace = (double)value / 100;
            // rn is object to create integer random value 
            Random rn = new Random();
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // change image from rgb to grayscale image
                    int gray = (int)(red + green + blue) / 3;
                    // set the random value between 0 and 255
                    int number = rn.Next(0, 255);
                    number = Convert.ToInt32(percentace*number);
                    // the formula of uniform noise is add an value to the source pixel
                    gray = gray + number;
                    
                    // error handling value for pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    // set the pixel of new Image
                    ob.SetPixel(x, y, Color.FromArgb(255, gray, gray, gray));
                }
            
            pictureBox8.Image = new Bitmap(pictureBoxSourceRN.Width, pictureBoxSourceRN.Height);
            pictureBox8.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox8.Image = ob;
        }

        // Noise Gaussian
        private void btnNS_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceRN.Image;
            Color color;
            int sw, j, k,number;
            int value = int.Parse(textBoxPercentaceNoise.Text);
            double percentace = (double)value / 100;
            // rn is object tp create integer random value 
            Random rn = new Random();
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // change image from rgb to grayscale image
                    int gray = (int)(red + green + blue) / 3;
                    sw = 0;
                    while (sw == 0)
                    {
                        // set the random value between 0 and 255 for j variable
                        j = rn.Next(0, 255);
                        // set the random value of k variable
                        k = rn.Next();
                        // the formula of gaussian noise
                        if (k < Math.Exp(Math.Pow(-j,2)))
                        {
                            sw = j;
                        }
                    }
                    number = sw;
                    number = Convert.ToInt32(percentace * number);
                    gray = gray + number;
                    // error handling value for pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    // set the pixel of new Image
                    ob.SetPixel(x, y, Color.FromArgb(255, gray, gray, gray));
                }
            pictureBox9.Image = new Bitmap(pictureBoxSourceRN.Width, pictureBoxSourceRN.Height);
            pictureBox9.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox9.Image = ob;
        }

        // Noise Salt & Pepper
        private void btnSP_Click(object sender, EventArgs e)
        {
             Bitmap ob = (Bitmap)pictureBoxSourceRN.Image;
            Color color;
            float number;
            int value = int.Parse(textBoxPercentaceNoise.Text);
            double percentace = (double)value / 100;
            
            Random rn = new Random();
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // merubah dari gambar rgb ke grayscale
                    int gray = (int)(red + green + blue) / 3;
                    number = (float)rn.Next(0, 255) / 100;
                    if (number < percentace)
                    {
                        gray = 255;
                    }
                    // error handling value dari pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    ob.SetPixel(x, y, Color.FromArgb(255, gray, gray, gray));
                }
            pictureBox11.Image = new Bitmap(pictureBoxSourceRN.Width, pictureBoxSourceRN.Height);
            pictureBox11.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox11.Image = ob;
        }

        // Noise  Specle
        private void btnMF_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pictureBoxSourceRN.Image;
            Color color;
            float number;
            int value = int.Parse(textBoxPercentaceNoise.Text);
            double percentace = (double)value / 100;

            Random rn = new Random();
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // merubah dari gambar rgb ke grayscale
                    int gray = (int)(red + green + blue) / 3;
                    number = (float)rn.Next(0, 255) / 100;
                    if (number < percentace)
                    {
                        gray = 0;
                    }
                    // error handling value dari pixel
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    if (gray < 0)
                    {
                        gray = 0;
                    }
                    ob.SetPixel(x, y, Color.FromArgb(255, gray, gray, gray));
                }
            pictureBox10.Image = new Bitmap(pictureBoxSourceRN.Width, pictureBoxSourceRN.Height);
            pictureBox10.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox10.Image = ob;
        }

        // Filter Rata-rata
        private void button7_Click(object sender, EventArgs e)
        {
            // Image yang akan direduksi merupakan image dengan noise Specle
            Bitmap ob = (Bitmap)pictureBox10.Image;
            Color[,] color = new Color[9,9];
            int i, j, resultr, resultg, resultb;
            int[,] mat = new int[3, 3];
            float[,] h = new float[3, 3];
            float hr, hg, hb;

            int nh = 3;
            for (i = 0; i < nh; i++)
                for (j = 0; j < nh; j++)
                {
                    h[i,j] = (float)1 / 9;
                }
            
            for (int x = 1; x < ob.Width-1; x++)
                for (int y = 1; y < ob.Height-1; y++)
                {
                    // get nilai pixel dari tetangga 
                    color[0, 0] = ob.GetPixel(x-1 ,y-1);
                    color[0, 1] = ob.GetPixel(x-1 ,y);
                    color[0, 2] = ob.GetPixel(x-1 ,y+1);
                    color[1, 0] = ob.GetPixel(x ,y-1);
                    color[1, 1] = ob.GetPixel(x ,y);
                    color[1, 2] = ob.GetPixel(x ,y+1);
                    color[2, 0] = ob.GetPixel(x+1 ,y-1);
                    color[2, 1] = ob.GetPixel(x+1 ,y);
                    color[2, 2] = ob.GetPixel(x+1 , y+1);

                    hr = 0; hg = 0; hb = 0;

                    for(int u=0; u<nh; u++)
                        for (int v = 0; v < nh; v++)
                        {
                            // get nilai dari red, green, dan blue dari setiap pixel tetangga
                            int red = color[u, v].R;
                            int green = color[u, v].G;
                            int blue = color[u, v].B;
                            // hr, hg, hb merupakan rata-rata dari pixel tetangga
                            hr += (float)red * h[u, v];
                            hg += (float)green * h[u, v];
                            hb += (float)blue * h[u, v]; 
                        }
                    resultr = (int)hr;
                    resultg = (int)hg;
                    resultb = (int)hb;
                    if (resultr > 255)
                    {
                        resultr = 255;
                    }
                    if (resultg > 255)
                    {
                        resultg = 255;
                    }
                    if (resultb > 255)
                    {
                        resultb = 255;
                    }

                    ob.SetPixel(x, y, Color.FromArgb(resultr,resultg, resultb));

                }
            pictureBox12.Image = new Bitmap(pictureBoxSourceRN.Width, pictureBoxSourceRN.Height);
            pictureBox12.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox12.Image = ob;
        }

        // Filter Gaussian
        private void button8_Click(object sender, EventArgs e)
        {
            // Image yang akan direduksi merupakan image dengan noise Specle
            Bitmap ob = (Bitmap)pictureBox10.Image;
            for(int x =1; x< ob.Width-1; x++)
                for (int y = 1; y < ob.Height - 1; y++)
                {
                    Color w1 = ob.GetPixel(x - 1, y - 1);
                    Color w2 = ob.GetPixel(x - 1, y);
                    Color w3 = ob.GetPixel(x - 1, y + 1);
                    Color w4 = ob.GetPixel(x , y - 1);
                    Color w5 = ob.GetPixel(x , y);
                    Color w6 = ob.GetPixel(x , y + 1);
                    Color w7 = ob.GetPixel(x + 1, y - 1);
                    Color w8 = ob.GetPixel(x + 1, y);
                    Color w9 = ob.GetPixel(x + 1, y + 1);

                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;

                    // Filter dengan matrix distribusi gaussian
                    int xb = (int)((x1 + x2 + x3 + x4 + (4 * x5) + x6 + x7 + x8 + x9) / 13);
                    if (xb < 0)
                    {
                        xb = 0;
                    }
                    if (xb > 255)
                    {
                        xb = 255;
                    }
                    ob.SetPixel(x, y, Color.FromArgb(xb,xb,xb));
                }
            pictureBox13.Image = new Bitmap(pictureBoxSourceRN.Width, pictureBoxSourceRN.Height);
            pictureBox13.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox13.Image = ob;

        }

        // Filter Median
        private void button9_Click(object sender, EventArgs e)
        {
            int[] xt = new int[9];
            // Image yang akan direduksi merupakan image dengan noise Specle
            Bitmap ob = (Bitmap)pictureBox10.Image;
            for(int x =1; x< ob.Width-1; x++)
                for (int y = 1; y < ob.Height - 1; y++)
                {
                    Color w1 = ob.GetPixel(x - 1, y - 1);
                    Color w2 = ob.GetPixel(x - 1, y);
                    Color w3 = ob.GetPixel(x - 1, y + 1);
                    Color w4 = ob.GetPixel(x, y - 1);
                    Color w5 = ob.GetPixel(x, y);
                    Color w6 = ob.GetPixel(x, y + 1);
                    Color w7 = ob.GetPixel(x + 1, y - 1);
                    Color w8 = ob.GetPixel(x + 1, y);
                    Color w9 = ob.GetPixel(x + 1, y + 1);

                    xt[0] = w1.R;
                    xt[1] = w2.R;
                    xt[2] = w3.R;
                    xt[3] = w4.R;
                    xt[4] = w5.R;
                    xt[5] = w6.R;
                    xt[6] = w7.R;
                    xt[7] = w8.R;
                    xt[8] = w9.R;

                    // proses mendapatkan nilai median dari matrix tetangga
                    for (int i=0; i<8; i++)
                        for (int j = 0; j < 8; j++)
                        {
                            if (xt[j] > xt[j + 1])
                            {
                                int temp = xt[j];
                                xt[j] = xt[j + 1];
                                xt[j + 1] = temp;
                            }
                        }
                    int xb = xt[5];
                    ob.SetPixel(x,y,Color.FromArgb(xb,xb,xb));
                }
            pictureBox14.Image = new Bitmap(pictureBoxSourceRN.Width, pictureBoxSourceRN.Height);
            pictureBox14.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox14.Image = ob;
        }



        // Praktikum Histogram
        // Load an Image
        private void btnL1_Click(object sender, EventArgs e)
        {

            Color color;
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pbH1.Image = new Bitmap(pbH1.Width, pbH1.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pbH1.SizeMode = PictureBoxSizeMode.StretchImage;
                pbH1.Image = objBitmap;
            }
        }

        // Button Brigness clicked
        private void btnL2_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbH1.Image;
            Color color;
            // nilai k diambil dari nilai yang diinputkan pada texbox
            int k = int.Parse(tbBrig.Text);
            Bitmap brigness = new Bitmap(ob.Width, ob.Height);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray = (red + green + blue) / 3;
                    // formulasi dari brigness yaitu nilai rata2 rgb ditambah dengan k
                    gray = gray + k;
                    if (gray < 0)
                    {
                        gray = 0;
                    } if (gray > 255)
                    {
                        gray = 255;
                    }
                    brigness.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pbH2.SizeMode = PictureBoxSizeMode.StretchImage;
            pbH2.Image = brigness;
        }

        // Button Contrast clicked
        private void btnL3_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbH1.Image;
            Color color;
            // nilai k diambil dari nilai yang diinputkan pada texbox
            int k = int.Parse(tbBrig.Text);
            Bitmap contras = new Bitmap(ob.Width, ob.Height);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    int gray;
                    gray = (int)(red + green + blue) / 3;
                    // formulasi dari brigness yaitu nilai rata2 rgb dikali dengan k
                    gray = (int)gray * k;
                    if (gray > 255)
                    {
                        gray = 255;
                    }
                    contras.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pbH3.SizeMode = PictureBoxSizeMode.StretchImage;
            pbH3.Image = contras;
        }

        // Change image to grayscale
        private void btnGray_Click(object sender, EventArgs e)
        {
                Bitmap ob = (Bitmap)pbH1.Image;
                Color color;
                for (int x = 0; x < ob.Width; x++)
                    for (int y = 0; y < ob.Height; y++)
                    {
                        color = ob.GetPixel(x, y);
                        int red = color.R;
                        int green = color.G;
                        int blue = color.B;

                        int gray = (red + green + blue) / 3;
                        ob.SetPixel(x,y, Color.FromArgb(gray,gray,gray));
                    }
                
                pbGray.Image = ob;
                pbGray.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        //generate histogram of original Image
        private void btnHI_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbH1.Image;
            int[] binRed   = new int[256];
            int[] binGreen = new int[256];
            int[] binBlue  = new int[256];
            int red, green, blue;
            Color color;

            for(int x=0; x<ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color   = ob.GetPixel(x, y);
                    red     = color.R;
                    green   = color.G;
                    blue    = color.B;
                    binRed[red]++;
                    binGreen[green]++;
                    binBlue[blue]++;
                }

            // set the histogram chart
            for (int i = 0; i < 256; i++)
            {
                this.chart1.Series["Red"].Points.AddXY(i, binRed[i]);
                this.chart1.Series["Green"].Points.AddXY(i, binGreen[i]);
                this.chart1.Series["Blue"].Points.AddXY(i, binBlue[i]);
            }
        }

        //generate histogram of grayscale Image
        private void btnHG_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbGray.Image;
            int[] binGray = new int[256];
            int gray;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    gray = color.R;
                    binGray[gray]++;
                }
            // set the histogram chart
            for (int i = 0; i < 256; i++)
            {
                this.chart2.Series["Gray"].Points.AddXY(i, binGray[i]);
            }
        }

        private void btnL4_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbH1.Image;
            int gray,red, green, blue;
            Color color;
            float[] h = new float[256];
            //inisialisasi matrix h dengan setiap nilainya 0
            for (int i = 0; i < 256; i++)
            {
                h[i] = 0;
            }

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color   = ob.GetPixel(x, y);
                    red     = color.R;
                    green   = color.G;
                    blue    = color.B;
                    gray = (int)(red + green + blue) / 3;
                    h[gray]++;
                }

            float[] c = new float[256];
            c[0] = h[0];

            for (int i = 1; i < 256; i++)
            {
                c[i] = c[i - 1] + h[i];
                for (int j = 0; j < 256; j++)
                {
                    c[j] = c[j] / ob.Height / ob.Width;
                }
                for (int k = 0; k < 256; k++)
                {
                    h[k] = 0;
                }
                for (int x = 0; x < ob.Width; x++)
                    for (int y = 0; y < ob.Height; y++)
                    {
                        color = ob.GetPixel(x, y);
                        red = color.R;
                        green = color.G;
                        blue = color.B;
                        gray = (int)(red + green + blue) / 3;
                        gray = (int)c[gray] * 255;
                        h[gray]++;
                        ob.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                    }
                pbH4.Image = ob;
                pbH4.SizeMode = PictureBoxSizeMode.StretchImage;
            }


        }

        //generate histogram of image that add the brigness
        private void btnHB_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbH2.Image;
            int[] binGray = new int[256];
            int gray;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    gray = color.R;
                    binGray[gray]++;
                }

            // set the histogram chart
            for (int i = 0; i < 256; i++)
            {
                this.chart4.Series["Gray"].Points.AddXY(i, binGray[i]);
            }
        }

        //generate histogram of contrass Image
        private void btnHC_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbH3.Image;
            int[] binGray = new int[256];
            int gray;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    gray = color.R;
                    binGray[gray]++;
                }
            // set the histogram of contrass
            for (int i = 0; i < 256; i++)
            {
                this.chart3.Series["Gray"].Points.AddXY(i, binGray[i]);
            }
        }

        

        // praktikum deteksi tepi
        public static ArrayList resultSobelX = new ArrayList();
        public static ArrayList resultSobelY = new ArrayList();
        public static ArrayList resultPrewitX = new ArrayList();
        public static ArrayList resultPrewitY = new ArrayList();
        public static ArrayList gradientMagnitude = new ArrayList();
        public static ArrayList gradientDirection = new ArrayList();

        private ArrayList getNeighboursList(int xPos, int yPos, Bitmap bitmap)
        {
            // inisialisasi variabel untuk menampung nilai 
            ArrayList neighboursList = new ArrayList();

            int xStart, xFinish, yStart, yFinish;

            int pixel;

            // menentukan posisi awal dan akhir koordinat dalam
            // ukuran mask 3 x 3
            xStart = xPos - 1;
            xFinish = xPos + 1;

            yStart = yPos - 1;
            yFinish = yPos + 1;

            // loop sejumlah 3 x 3 perluasan pixel tetangga
            for (int y = yStart; y <= yFinish; y++)
            {
                for (int x = xStart; x <= xFinish; x++)
                {
                    // kondisi IF.. ELSE.. untuk mendaftarkan anggota tetangga
                    // bila posisi x dan y tidak valid maka isi list dengan 0
                    // tidak valid : nilai negatif atau lebih dari batas citra
                    if (x < 0 || y < 0 || x > (bitmap.Width - 1) || y > (bitmap.Height - 1))
                    {
                        // menambahkan data ke list dengan nilai 0
                        // 0D : artinya nilai 0 dengan tipe double (D)
                        neighboursList.Add(0);
                    }
                    else
                    {
                        // menampung nilai pixel pada titik (x,y) pada variabel pixel
                        pixel = bitmap.GetPixel(x, y).R;

                        // menambahkan data ke list dengan nilai pixel
                        neighboursList.Add(pixel);
                    }
                }
            }

            // nilai kembalian berupa array list
            return neighboursList;
        }

        private int getSobelValue(ArrayList neighboursList, String maskType)
        {
            // inisialisasi variabel
            // sobel X : mask dari sobel X
            // sobel Y : mask dari sobel Y
            int result = 0;

            int[,] sobelX = { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] sobelY = { { 1, 2, 1 }, { 0, 0, 0 }, { -1, -2, -1 } };
            int[,] prewitX = { { -1, 0, 1 }, { -1, 0, 1 }, { -1, 0, 1 } };
            int[,] prewitY = { { -1, -1, -1 }, { 0, 0, 0 }, { 1, 1, 1 } };
            int[,] laplacian = { { 1, -2, -1 }, { -2, 4, -2 }, { 1, -2, 1 } };


            // count : digunakan untuk menunjukkan index pada list
            int count = 0;

            // kondisi untuk mask type, bila X maka lakukan sobel X
            // tetapi jika Y maka lakukan sobel Y
            if (maskType.Equals("sobelX"))
            {
                // looping untuk menghitung nilai sobel X pada titik (x,y)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        // perhitungan sobel X
                        result = result + (sobelX[x, y] * Convert.ToInt16(neighboursList[count]));

                        // increment count yang digunakan untuk index neighboursList
                        count++;
                    }
                }
            }
            else if (maskType.Equals("sobelY"))
            {
                // looping untuk menghitung nilai sobel Y pada titik (x,y)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        // perhitungan sobel Y
                        result = result + (sobelY[x, y] * Convert.ToInt16(neighboursList[count]));

                        // increment count yang digunakan untuk index neighboursList
                        count++;
                    }
                }
            }
            else if (maskType.Equals("prewitX"))
            {
                // looping untuk menghitung nilai sobel Y pada titik (x,y)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        // perhitungan sobel Y
                        result = result + (prewitX[x, y] * Convert.ToInt16(neighboursList[count]));

                        // increment count yang digunakan untuk index neighboursList
                        count++;
                    }
                }
            }
            else if (maskType.Equals("prewitY"))
            {
                // looping untuk menghitung nilai sobel Y pada titik (x,y)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        // perhitungan sobel Y
                        result = result + (prewitY[x, y] * Convert.ToInt16(neighboursList[count]));

                        // increment count yang digunakan untuk index neighboursList
                        count++;
                    }
                }
            }
            else if (maskType.Equals("laplacian"))
            {
                // looping untuk menghitung nilai sobel Y pada titik (x,y)
                for (int y = 0; y < 3; y++)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        // perhitungan sobel Y
                        result = result + (laplacian[x, y] * Convert.ToInt16(neighboursList[count]));

                        // increment count yang digunakan untuk index neighboursList
                        count++;
                    }
                }
            }

            // nilai kembalian hasil sobel X atau sobel Y pada titik (x,y) pada citra
            return result;
        }

        // btn_load clicked
        private void button13_Click(object sender, EventArgs e)
        {
            Color color;
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pbH1.Image = new Bitmap(pbH1.Width, pbH1.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pbDTsrc.SizeMode = PictureBoxSizeMode.StretchImage;
                pbDTsrc.Image = objBitmap;
            }
        }

        // btn_grayscale clicked
        private void button14_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pbDTsrc.Image;
            Color color;
            Bitmap greyscale = new Bitmap(ob.Width, ob.Height);
            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    int red = color.R;
                    int green = color.G;
                    int blue = color.B;
                    // nilai gray didapat dari rata2  nilai rgb dari suatu titik pixel
                    int gray = (red + green + blue) / 3;
                    greyscale.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            pbDTsrc.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTsrc.Image = greyscale;
        }

        // btn sobel_X clicked
        private void button16_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbDTsrc.Image);
            Bitmap sobelX = new Bitmap(pbDTsrc.Image);

            int result;

            // set nilai min dan max dari progress bar
            progressBar.Minimum = 0;
            progressBar.Maximum = bitmap.Height - 1;

            progressBar.Value = 0;

            // inisialisasi array list untuk menampung pixel tetangga
            ArrayList neighboursList = new ArrayList();

            // mengosongkan list sobel X
            resultSobelX.Clear();

            // nested looping untuk scanline citra secara horizontal
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // mengosongkan list
                    neighboursList.Clear();

                    // menampung list tetangga dengan perluasan 3 x 3
                    neighboursList = getNeighboursList(x, y, bitmap);

                    // menampung nilai setelah menerapkan sobel mask X
                    // pada titik (x,y)
                    result = getSobelValue(neighboursList, "sobelX");

                    // memasukkan hasil sobel X di titik (x,y) dalam list
                    resultSobelX.Add(result);

                    // kondisi untuk filter nilai harus dalam range 0 - 255
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result > 255)
                    {
                        result = 255;
                    }

                    // set nilai pixel baru setelah dikenakan sobel mask X pada titik (x,y)
                    sobelX.SetPixel(x, y, Color.FromArgb(result, result, result));
                }

                // set nilai progress bar
                progressBar.Value = y;
            }

            // menampilkan gambar hasil sobel X dalam picture box
            pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTDes.Image = sobelX;
        }

        // btn sobel_Y clicked
        private void button15_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbDTsrc.Image);
            Bitmap sobelY = new Bitmap(pbDTsrc.Image);

            int result;

            // set nilai min dan max dari progress bar
            progressBar.Minimum = 0;
            progressBar.Maximum = bitmap.Height - 1;

            progressBar.Value = 0;

            // inisialisasi array list untuk menampung pixel tetangga
            ArrayList neighboursList = new ArrayList();

            resultSobelY.Clear();

            // nested looping untuk scanline citra secara horizontal
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // mengosongkan list
                    neighboursList.Clear();

                    // menampung list tetangga dengan perluasan 3 x 3
                    neighboursList = getNeighboursList(x, y, bitmap);

                    // menampung nilai setelah menerapkan sobel mask Y
                    // pada titik (x,y)
                    result = getSobelValue(neighboursList, "sobelY");

                    // memasukkan hasil sobel Y ke dalam list
                    resultSobelY.Add(result);

                    // kondisi untuk filter nilai harus dalam range 0 - 255
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result > 255)
                    {
                        result = 255;
                    }

                    // set nilai pixel baru setelah dikenakan sobel mask Y pada titik (x,y)
                    sobelY.SetPixel(x, y, Color.FromArgb(result, result, result));
                }

                // set nilai progress bar
                progressBar.Value = y;
            }

            // menampilkan gambar hasil sobel Y dalam picture box
            pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTDes.Image = sobelY;
        }

        // btn_magnitude clicked
        private void button18_Click(object sender, EventArgs e)
        {
            if (resultSobelX.Count != 0 && resultSobelY.Count != 0)
            {
                // inisialisasi variabel
                // bitmap : untuk diambil properties width dan height
                // magnitude : untuk menampung citra hasil magnitude
                Bitmap bitmap = new Bitmap(pbDTsrc.Image);
                Bitmap magnitude = new Bitmap(pbDTsrc.Image);

                int result;

                // count digunakan untuk looping list
                int count = 0;

                int sobelX, sobelY;

                // set nilai min dan max dari progress bar
                progressBar.Minimum = 0;
                progressBar.Maximum = bitmap.Height - 1;

                progressBar.Value = 0;

                // nested looping untuk scanline citra secara horizontal
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        // menampung nilai sobel X dan sobel Y 
                        // dan konversi dalam bentuk integer
                        sobelX = Convert.ToInt16(resultSobelX[count]);
                        sobelY = Convert.ToInt16(resultSobelY[count]);

                        // perhitungan magnitude sobel
                        result = Convert.ToInt16(Math.Sqrt(Math.Pow(sobelX, 2) + Math.Pow(sobelY, 2)));

                        // memasukkan gradient magnitude ke dalam list
                        gradientMagnitude.Add(result);

                        // kondisi jika nilai melebih 255, maka nilai di set menjadi 255
                        if (result > 255)
                        {
                            result = 255;
                        }

                        // set nilai pixel baru setelah perhitungan magnitude pada titik (x,y)
                        magnitude.SetPixel(x, y, Color.FromArgb(result, result, result));

                        // increment loop list
                        count++;
                    }

                    // set nilai progress bar
                    progressBar.Value = y;
                }

                // menampilkan gambar hasil gradient magnitude dalam picture box
                pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
                pbDTDes.Image = magnitude;
            }
            // pesan jika sobel X dan sobel Y belum dilakukan
            else
            {
                MessageBox.Show("Fill Sobel X and Sobel Y first to compute gradient magnitude!");
            }
        }

        // btn_direction clicked
        private void button17_Click(object sender, EventArgs e)
        {
            if (resultSobelX.Count != 0 && resultSobelY.Count != 0)
            {
                // inisialisasi variabel
                // bitmap : untuk diambil properties width dan height
                // magnitude : untuk menampung citra hasil magnitude
                Bitmap bitmap = new Bitmap(pbDTsrc.Image);
                Bitmap magnitude = new Bitmap(pbDTsrc.Image);

                // result digunakan untuk menampung hasil theta
                // bertipe double karena hasil dapat berupa bilangan desimal
                double result;

                // count digunakan untuk looping list
                int count = 0;

                double sobelX, sobelY;

                // set nilai min dan max dari progress bar
                progressBar.Minimum = 0;
                progressBar.Maximum = bitmap.Height - 1;

                progressBar.Value = 0;

                // inisialisasi array list untuk menampung pixel tetangga
                ArrayList neighboursList = new ArrayList();

                // nested looping untuk scanline citra secara horizontal
                for (int y = 0; y < bitmap.Height; y++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        // menampung nilai sobel X dan sobel Y
                        // dan konversi dalam bentuk double
                        sobelX = Convert.ToDouble(resultSobelX[count]);
                        sobelY = Convert.ToDouble(resultSobelY[count]);

                        // kondisi bila sobel X = 0, maka hasil akan menjadi tak hingga
                        // arc tan tak hingga = 90 derajat
                        if (sobelX == 0D)
                        {
                            result = 90;
                        }
                        // selain itu lakukan perhitungan gradient direction
                        else
                        {
                            result = Math.Atan(sobelY / sobelX) * (180 / Math.PI);
                        }

                        // tambahkan dengan 180 karena 135 derajat = -45 derajat
                        // maka gunakan perhitungan kuadran sudut
                        result = result + 180;

                        // kondisi jika nilai di dalam range +- 22.5 akan dibulatkan ke arah
                        // sudut 0, 45, 90, 135 derajat untuk keperluan non maximum suppresion
                        if ((result >= -22.5 && result <= 22.5) || (result > 157.5 && result <= 202.5))
                        {
                            result = 0;

                        }
                        else if ((result > 22.5 && result <= 67.5) || (result > 202.5 && result <= 247.5))
                        {
                            result = 45;
                        }
                        else if ((result > 67.5 && result <= 112.5) || (result > 247.5 && result <= 292.5))
                        {
                            result = 90;
                        }
                        else if ((result > 112.5 && result <= 157.5) || (result > 292.5 && result <= 337.5))
                        {
                            result = 135;
                        }

                        // masukkan hasil gradient direction pada list
                        gradientDirection.Add(result);

                        // increment loop list
                        count++;
                    }

                    // set nilai progress bar
                    progressBar.Value = y;
                }

                MessageBox.Show("Done");
            }
            // pesan yang muncul bila sobel X dan sobel Y belum dilakukan
            else
            {
                MessageBox.Show("Fill Sobel X and Sobel Y first to compute gradient direction!");
            }
        }

        //btn_robert clicked
        private void button19_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbDTsrc.Image);
            Bitmap result = new Bitmap(bitmap.Width,bitmap.Height);
            progressBar.Minimum = 0;
            progressBar.Maximum = bitmap.Width - 1;

            progressBar.Value = 0;

            for (int x = 1; x < bitmap.Width; x++)
            {
                for (int y = 1; y < bitmap.Height; y++)
                {
                    Color w1 = bitmap.GetPixel(x - 1, y);
                    Color w2 = bitmap.GetPixel(x, y);
                    Color w3 = bitmap.GetPixel(x, y - 1);
                    Color w4 = bitmap.GetPixel(x, y);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int xb = (int)((x2 - x1) + (x4 - x3));
                    if (xb < 0) xb = -xb;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    result.SetPixel(x, y, wb);
                }
                progressBar.Value = x;
            }
            //progressBar.Value = 0;
            pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTDes.Image = result;

        }

        // btn_prewitX
        private void button20_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbDTsrc.Image);
            Bitmap prewitX = new Bitmap(pbDTsrc.Image);

            int result;

            // set nilai min dan max dari progress bar
            progressBar.Minimum = 0;
            progressBar.Maximum = bitmap.Height - 1;

            progressBar.Value = 0;

            // inisialisasi array list untuk menampung pixel tetangga
            ArrayList neighboursList = new ArrayList();

            // mengosongkan list sobel X
            resultSobelX.Clear();

            // nested looping untuk scanline citra secara horizontal
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // mengosongkan list
                    neighboursList.Clear();

                    // menampung list tetangga dengan perluasan 3 x 3
                    neighboursList = getNeighboursList(x, y, bitmap);

                    // menampung nilai setelah menerapkan sobel mask X
                    // pada titik (x,y)
                    result = getSobelValue(neighboursList, "prewitX");

                    // memasukkan hasil sobel X di titik (x,y) dalam list
                    resultSobelX.Add(result);

                    // kondisi untuk filter nilai harus dalam range 0 - 255
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result > 255)
                    {
                        result = 255;
                    }

                    // set nilai pixel baru setelah dikenakan sobel mask X pada titik (x,y)
                    prewitX.SetPixel(x, y, Color.FromArgb(result, result, result));
                }

                // set nilai progress bar
                progressBar.Value = y;
            }

            // menampilkan gambar hasil sobel X dalam picture box
            pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTDes.Image = prewitX;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbDTsrc.Image);
            Bitmap prewitY = new Bitmap(pbDTsrc.Image);

            int result;

            // set nilai min dan max dari progress bar
            progressBar.Minimum = 0;
            progressBar.Maximum = bitmap.Height - 1;

            progressBar.Value = 0;

            // inisialisasi array list untuk menampung pixel tetangga
            ArrayList neighboursList = new ArrayList();

            // mengosongkan list sobel X
            resultSobelX.Clear();

            // nested looping untuk scanline citra secara horizontal
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // mengosongkan list
                    neighboursList.Clear();

                    // menampung list tetangga dengan perluasan 3 x 3
                    neighboursList = getNeighboursList(x, y, bitmap);

                    // menampung nilai setelah menerapkan sobel mask X
                    // pada titik (x,y)
                    result = getSobelValue(neighboursList, "prewitY");

                    // memasukkan hasil sobel X di titik (x,y) dalam list
                    resultSobelX.Add(result);

                    // kondisi untuk filter nilai harus dalam range 0 - 255
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result > 255)
                    {
                        result = 255;
                    }

                    // set nilai pixel baru setelah dikenakan sobel mask X pada titik (x,y)
                    prewitY.SetPixel(x, y, Color.FromArgb(result, result, result));
                }

                // set nilai progress bar
                progressBar.Value = y;
            }

            // menampilkan gambar hasil sobel X dalam picture box
            pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTDes.Image = prewitY;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbDTsrc.Image);
            Bitmap laplacian = new Bitmap(pbDTsrc.Image);

            int result;

            // set nilai min dan max dari progress bar
            progressBar.Minimum = 0;
            progressBar.Maximum = bitmap.Height - 1;

            progressBar.Value = 0;

            // inisialisasi array list untuk menampung pixel tetangga
            ArrayList neighboursList = new ArrayList();

            // mengosongkan list sobel X
            resultSobelX.Clear();

            // nested looping untuk scanline citra secara horizontal
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    // mengosongkan list
                    neighboursList.Clear();

                    // menampung list tetangga dengan perluasan 3 x 3
                    neighboursList = getNeighboursList(x, y, bitmap);

                    // menampung nilai setelah menerapkan sobel mask X
                    // pada titik (x,y)
                    result = getSobelValue(neighboursList, "laplacian");

                    // memasukkan hasil sobel X di titik (x,y) dalam list
                    resultSobelX.Add(result);

                    // kondisi untuk filter nilai harus dalam range 0 - 255
                    if (result < 0)
                    {
                        result = 0;
                    }
                    else if (result > 255)
                    {
                        result = 255;
                    }

                    // set nilai pixel baru setelah dikenakan sobel mask X pada titik (x,y)
                    laplacian.SetPixel(x, y, Color.FromArgb(result, result, result));
                }

                // set nilai progress bar
                progressBar.Value = y;
            }

            // menampilkan gambar hasil sobel X dalam picture box
            pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTDes.Image = laplacian;
        }

        // sharpness
        private void button23_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = new Bitmap(pbDTsrc.Image);
            Bitmap result = new Bitmap(bitmap.Width,bitmap.Height);
            progressBar.Minimum = 0;
            progressBar.Maximum = bitmap.Width - 1;

            progressBar.Value = 0;
            for (int x = 1; x < bitmap.Width - 1; x++)
            {
                for (int y = 1; y < bitmap.Height - 1; y++)
                {
                    Color w = bitmap.GetPixel(x, y);
                    int xg = w.R;
                    Color w1 = bitmap.GetPixel(x - 1, y - 1);
                    Color w2 = bitmap.GetPixel(x - 1, y);
                    Color w3 = bitmap.GetPixel(x - 1, y + 1);
                    Color w4 = bitmap.GetPixel(x, y - 1);
                    Color w5 = bitmap.GetPixel(x, y);
                    Color w6 = bitmap.GetPixel(x, y + 1);
                    Color w7 = bitmap.GetPixel(x + 1, y - 1);
                    Color w8 = bitmap.GetPixel(x + 1, y);
                    Color w9 = bitmap.GetPixel(x + 1, y + 1);
                    int x1 = w1.R;
                    int x2 = w2.R;
                    int x3 = w3.R;
                    int x4 = w4.R;
                    int x5 = w5.R;
                    int x6 = w6.R;
                    int x7 = w7.R;
                    int x8 = w8.R;
                    int x9 = w9.R;
                    int xt1 = (int)((x1 + x2 + x3 + x4 + x5 + x6 + x7 + x8 + x9) / 9);
                    int xt2 = (int)(-x1 - 2 * x2 - x3 + x7 + 2 * x8 + x9);
                    int xt3 = (int)(-x1 - 2 * x4 - x7 + x3 + 2 * x6
                   + x9);
                    int xb = (int)(xt1 + xt2 + xt3);
                    if (xb < 0) xb = -xb;
                    if (xb > 255) xb = 255;
                    Color wb = Color.FromArgb(xb, xb, xb);
                    result.SetPixel(x, y, wb);
                }
                progressBar.Value = x;
            }
                
            pbDTDes.SizeMode = PictureBoxSizeMode.StretchImage;
            pbDTDes.Image = result;

        }




        // EKSTRAKSI WARNA
        int[] avRedimg1 = new int[16];
        int[] avGreenimg1 = new int[16];
        int[] avBlueimg1 = new int[16];
        int[] avRedimg2 = new int[16];
        int[] avGreenimg2 = new int[16];
        int[] avBlueimg2 = new int[16];
        int[] avRedimg3 = new int[16];
        int[] avGreenimg3 = new int[16];
        int[] avBlueimg3 = new int[16];
        int[] avRedimg4 = new int[16];
        int[] avGreenimg4 = new int[16];
        int[] avBlueimg4 = new int[16];
        private void btn_load_img1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img1.Image = new Bitmap(pb_img1.Width, pb_img1.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img1.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img1.Image = objBitmap;
            }
        }

        private void btn_his_img1_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img1.Image;
            int[] binRed = new int[256];
            int[] binGreen = new int[256];
            int[] binBlue = new int[256];
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    binRed[red]++;
                    binGreen[green]++;
                    binBlue[blue]++;
                }

            int a = -1;
            int count = 0;
            int sumRed = 0;
            int sumGreen = 0;
            int sumBlue = 0;
            for (int b = 0; b < 255; b++)
            {

                if (b % 16 == 0)
                {
                    a++;
                    sumRed = 0; sumGreen = 0; sumBlue = 0;
                }
                sumRed += binRed[b];
                sumGreen += binGreen[b];
                sumBlue += binBlue[b];
                if (b % 15 == 0)
                {
                    avRedimg1[a] = sumRed / 16;
                    avGreenimg1[a] = sumGreen / 16;
                    avBlueimg1[a] = sumBlue / 16;
                    
                }
                
            }

                // unset the histogram chart
                for (int i = 0; i < 16; i++)
                {
                    this.ch_img1_red.Series["R"].Points.Clear();
                    this.ch_img1_green.Series["G"].Points.Clear();
                    this.ch_img1_blue.Series["B"].Points.Clear();
                }

                label_hr_img1.Text = "|  " +avRedimg1[0] + "  |  " + avRedimg1[1] + "  |  " + avRedimg1[2] + "  |  " + avRedimg1[3] + "  |  " + avRedimg1[4] + "  |  " +
                    avRedimg1[5] + "  |  " + avRedimg1[6] + "  |  " + avRedimg1[7] + "  |  " + avRedimg1[8] + "  |  " + avRedimg1[9] + "  |  " + avRedimg1[10] + "  |  " +
                    avRedimg1[11] + "  |  " + avRedimg1[12] + "  |  " + avRedimg1[13] + "  |  " + avRedimg1[14] + "  |  " + avRedimg1[15] + "  |";

                label_hg_img1.Text = "|  " + avGreenimg1[0] + "  |  " + avGreenimg1[1] + "  |  " + avGreenimg1[2] + "  |  " + avGreenimg1[3] + "  |  " + avGreenimg1[4] + "  |  " +
                        avGreenimg1[5] + "  |  " + avGreenimg1[6] + "  |  " + avGreenimg1[7] + "  |  " + avGreenimg1[8] + "  |  " + avGreenimg1[9] + "  |  " + avGreenimg1[10] + "  |  " +
                        avGreenimg1[11] + "  |  " + avGreenimg1[12] + "  |  " + avGreenimg1[13] + "  |  " + avGreenimg1[14] + "  |  " + avGreenimg1[15] + "  |";

                label_hb_img1.Text = "|  " + avBlueimg1[0] + "  |  " + avBlueimg1[1] + "  |  " + avBlueimg1[2] + "  |  " + avBlueimg1[3] + "  |  " + avBlueimg1[4] + "  |  " +
                        avBlueimg1[5] + "  |  " + avBlueimg1[6] + "  |  " + avBlueimg1[7] + "  |  " + avBlueimg1[8] + "  |  " + avBlueimg1[9] + "  |  " + avBlueimg1[10] + "  |  " +
                        avBlueimg1[11] + "  |  " + avBlueimg1[12] + "  |  " + avBlueimg1[13] + "  |  " + avBlueimg1[14] + "  |  " + avBlueimg1[15] + "  |";

            // set the histogram chart
            for (int i = 0; i < 16; i++)
            {
                this.ch_img1_red.Series["R"].Points.AddXY(i, avRedimg1[i]);
                this.ch_img1_green.Series["G"].Points.AddXY(i, avGreenimg1[i]);
                this.ch_img1_blue.Series["B"].Points.AddXY(i, avBlueimg1[i]);
            }
        }

        private void btn_load_img2_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img2.Image = new Bitmap(pb_img2.Width, pb_img2.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img2.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img2.Image = objBitmap;
            }
        }

        private void btn_his_img2_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img2.Image;

            int[] binRed = new int[256];
            int[] binGreen = new int[256];
            int[] binBlue = new int[256];
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    binRed[red]++;
                    binGreen[green]++;
                    binBlue[blue]++;
                }

            int a = -1;
            int count = 0;
            int sumRed = 0;
            int sumGreen = 0;
            int sumBlue = 0;
            for (int b = 0; b < 255; b++)
            {

                if (b % 16 == 0)
                {
                    a++;
                    sumRed = 0; sumGreen = 0; sumBlue = 0;
                }
                sumRed += binRed[b];
                sumGreen += binGreen[b];
                sumBlue += binBlue[b];
                if (b % 15 == 0)
                {
                    avRedimg2[a] = sumRed / 16;
                    avGreenimg2[a] = sumGreen / 16;
                    avBlueimg2[a] = sumBlue / 16;

                }

            }

            // unset the histogram chart
            for (int i = 0; i < 16; i++)
            {
                this.ch_img2_red.Series["R"].Points.Clear();
                this.ch_img2_green.Series["G"].Points.Clear();
                this.ch_img2_blue.Series["B"].Points.Clear();
            }

            label_hr_img2.Text = "|  " + avRedimg2[0] + "  |  " + avRedimg2[1] + "  |  " + avRedimg2[2] + "  |  " + avRedimg2[3] + "  |  " + avRedimg2[4] + "  |  " +
                    avRedimg2[5] + "  |  " + avRedimg2[6] + "  |  " + avRedimg2[7] + "  |  " + avRedimg2[8] + "  |  " + avRedimg2[9] + "  |  " + avRedimg2[10] + "  |  " +
                    avRedimg2[11] + "  |  " + avRedimg2[12] + "  |  " + avRedimg2[13] + "  |  " + avRedimg2[14] + "  |  " + avRedimg2[15] + "  |";

            label_hg_img2.Text = "|  " + avGreenimg2[0] + "  |  " + avGreenimg2[1] + "  |  " + avGreenimg2[2] + "  |  " + avGreenimg2[3] + "  |  " + avGreenimg2[4] + "  |  " +
                    avGreenimg2[5] + "  |  " + avGreenimg2[6] + "  |  " + avGreenimg2[7] + "  |  " + avGreenimg2[8] + "  |  " + avGreenimg2[9] + "  |  " + avGreenimg2[10] + "  |  " +
                    avGreenimg2[11] + "  |  " + avGreenimg2[12] + "  |  " + avGreenimg2[13] + "  |  " + avGreenimg2[14] + "  |  " + avGreenimg2[15] + "  |";

            label_hb_img2.Text = "|  " + avBlueimg2[0] + "  |  " + avBlueimg2[1] + "  |  " + avBlueimg2[2] + "  |  " + avBlueimg2[3] + "  |  " + avBlueimg2[4] + "  |  " +
                    avBlueimg2[5] + "  |  " + avBlueimg2[6] + "  |  " + avBlueimg2[7] + "  |  " + avBlueimg2[8] + "  |  " + avBlueimg2[9] + "  |  " + avBlueimg2[10] + "  |  " +
                    avBlueimg2[11] + "  |  " + avBlueimg2[12] + "  |  " + avBlueimg2[13] + "  |  " + avBlueimg2[14] + "  |  " + avBlueimg2[15] + "  |";


            // set the histogram chart
            for (int i = 0; i < 16; i++)
            {
                this.ch_img2_red.Series["R"].Points.AddXY(i, avRedimg2[i]);
                this.ch_img2_green.Series["G"].Points.AddXY(i, avGreenimg2[i]);
                this.ch_img2_blue.Series["B"].Points.AddXY(i, avBlueimg2[i]);
            }
        }

        private void btn_load_img3_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img3.Image = new Bitmap(pb_img3.Width, pb_img3.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img3.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img3.Image = objBitmap;
            }
        }

        private void btn_his_img3_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img3.Image;

            int[] binRed = new int[256];
            int[] binGreen = new int[256];
            int[] binBlue = new int[256];
            
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    binRed[red]++;
                    binGreen[green]++;
                    binBlue[blue]++;
                }

            int a = -1;
            int count = 0;
            int sumRed = 0;
            int sumGreen = 0;
            int sumBlue = 0;
            for (int b = 0; b < 255; b++)
            {

                if (b % 16 == 0)
                {
                    a++;
                    sumRed = 0; sumGreen = 0; sumBlue = 0;
                }
                sumRed += binRed[b];
                sumGreen += binGreen[b];
                sumBlue += binBlue[b];
                if (b % 15 == 0)
                {
                    avRedimg3[a] = sumRed / 16;
                    avGreenimg3[a] = sumGreen / 16;
                    avBlueimg3[a] = sumBlue / 16;

                }

            }

            // unset the histogram chart
            for (int i = 0; i < 16; i++)
            {
                this.ch_img3_red.Series["R"].Points.Clear();
                this.ch_img3_green.Series["G"].Points.Clear();
                this.ch_img3_blue.Series["B"].Points.Clear();
            }


            label_hr_img3.Text = "|  " + avRedimg3[0] + "  |  " + avRedimg3[1] + "  |  " + avRedimg3[2] + "  |  " + avRedimg3[3] + "  |  " + avRedimg3[4] + "  |  " +
                    avRedimg3[5] + "  |  " + avRedimg3[6] + "  |  " + avRedimg3[7] + "  |  " + avRedimg3[8] + "  |  " + avRedimg3[9] + "  |  " + avRedimg3[10] + "  |  " +
                    avRedimg3[11] + "  |  " + avRedimg3[12] + "  |  " + avRedimg3[13] + "  |  " + avRedimg3[14] + "  |  " + avRedimg3[15] + "  |";

            label_hg_img3.Text = "|  " + avGreenimg3[0] + "  |  " + avGreenimg3[1] + "  |  " + avGreenimg3[2] + "  |  " + avGreenimg3[3] + "  |  " + avGreenimg3[4] + "  |  " +
                    avGreenimg3[5] + "  |  " + avGreenimg3[6] + "  |  " + avGreenimg3[7] + "  |  " + avGreenimg3[8] + "  |  " + avGreenimg3[9] + "  |  " + avGreenimg3[10] + "  |  " +
                    avGreenimg3[11] + "  |  " + avGreenimg3[12] + "  |  " + avGreenimg3[13] + "  |  " + avGreenimg3[14] + "  |  " + avGreenimg3[15] + "  |";

            label_hb_img3.Text = "|  " + avBlueimg3[0] + "  |  " + avBlueimg3[1] + "  |  " + avBlueimg3[2] + "  |  " + avBlueimg3[3] + "  |  " + avBlueimg3[4] + "  |  " +
                    avBlueimg3[5] + "  |  " + avBlueimg3[6] + "  |  " + avBlueimg3[7] + "  |  " + avBlueimg3[8] + "  |  " + avBlueimg3[9] + "  |  " + avBlueimg3[10] + "  |  " +
                    avBlueimg3[11] + "  |  " + avBlueimg3[12] + "  |  " + avBlueimg3[13] + "  |  " + avBlueimg3[14] + "  |  " + avBlueimg3[15] + "  |";

            // set the histogram chart
            for (int i = 0; i < 16; i++)
            {
                this.ch_img3_red.Series["R"].Points.AddXY(i, avRedimg3[i]);
                this.ch_img3_green.Series["G"].Points.AddXY(i, avGreenimg3[i]);
                this.ch_img3_blue.Series["B"].Points.AddXY(i, avBlueimg3[i]);
            }
        }

        private void btn_load_img4_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img4.Image = new Bitmap(pb_img4.Width, pb_img4.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img4.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img4.Image = objBitmap;
            }
        }

        private void btn_his_img4_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img4.Image;

            int[] binRed = new int[256];
            int[] binGreen = new int[256];
            int[] binBlue = new int[256];
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    binRed[red]++;
                    binGreen[green]++;
                    binBlue[blue]++;
                }

            int a = -1;
            int count = 0;
            int sumRed = 0;
            int sumGreen = 0;
            int sumBlue = 0;
            for (int b = 0; b < 255; b++)
            {

                if (b % 16 == 0)
                {
                    a++;
                    sumRed = 0; sumGreen = 0; sumBlue = 0;
                }
                sumRed += binRed[b];
                sumGreen += binGreen[b];
                sumBlue += binBlue[b];
                if (b % 15 == 0)
                {
                    avRedimg4[a] = sumRed / 16;
                    avGreenimg4[a] = sumGreen / 16;
                    avBlueimg4[a] = sumBlue / 16;

                }

            }

            // unset the histogram chart
            for (int i = 0; i < 16; i++)
            {
                this.ch_img4_red.Series["R"].Points.Clear();
                this.ch_img4_green.Series["G"].Points.Clear();
                this.ch_img4_blue.Series["B"].Points.Clear();
            }

            label_hr_img4.Text = "|  " + avRedimg4[0] + "  |  " + avRedimg4[1] + "  |  " + avRedimg4[2] + "  |  " + avRedimg4[3] + "  |  " + avRedimg4[4] + "  |  " +
                    avRedimg4[5] + "  |  " + avRedimg4[6] + "  |  " + avRedimg4[7] + "  |  " + avRedimg4[8] + "  |  " + avRedimg4[9] + "  |  " + avRedimg4[10] + "  |  " +
                    avRedimg4[11] + "  |  " + avRedimg4[12] + "  |  " + avRedimg4[13] + "  |  " + avRedimg4[14] + "  |  " + avRedimg4[15] + "  |";

            label_hg_img4.Text = "|  " + avGreenimg4[0] + "  |  " + avGreenimg4[1] + "  |  " + avGreenimg4[2] + "  |  " + avGreenimg4[3] + "  |  " + avGreenimg4[4] + "  |  " +
                    avGreenimg4[5] + "  |  " + avGreenimg4[6] + "  |  " + avGreenimg4[7] + "  |  " + avGreenimg4[8] + "  |  " + avGreenimg4[9] + "  |  " + avGreenimg4[10] + "  |  " +
                    avGreenimg4[11] + "  |  " + avGreenimg4[12] + "  |  " + avGreenimg4[13] + "  |  " + avGreenimg4[14] + "  |  " + avGreenimg4[15] + "  |";

            label_hb_img4.Text = "|  " + avBlueimg4[0] + "  |  " + avBlueimg4[1] + "  |  " + avBlueimg4[2] + "  |  " + avBlueimg4[3] + "  |  " + avBlueimg4[4] + "  |  " +
                    avBlueimg4[5] + "  |  " + avBlueimg4[6] + "  |  " + avBlueimg4[7] + "  |  " + avBlueimg4[8] + "  |  " + avBlueimg4[9] + "  |  " + avBlueimg4[10] + "  |  " +
                    avBlueimg4[11] + "  |  " + avBlueimg4[12] + "  |  " + avBlueimg4[13] + "  |  " + avBlueimg4[14] + "  |  " + avBlueimg4[15] + "  |";

            // set the histogram chart
            for (int i = 0; i < 16; i++)
            {
                this.ch_img4_red.Series["R"].Points.AddXY(i, avRedimg4[i]);
                this.ch_img4_green.Series["G"].Points.AddXY(i, avGreenimg4[i]);
                this.ch_img4_blue.Series["B"].Points.AddXY(i, avBlueimg4[i]);
            }
        }

        //btn compare clicked
        private void btn_compare_Click(object sender, EventArgs e)
        {
            int selisih41 = Compare(avRedimg1, avRedimg4, avGreenimg1,avGreenimg4,avBlueimg1,avBlueimg4);
            int selisih42 = Compare(avRedimg2, avRedimg4, avGreenimg2, avGreenimg4, avBlueimg2, avBlueimg4);
            int selisih43 = Compare(avRedimg3, avRedimg4, avGreenimg3, avGreenimg4, avBlueimg3, avBlueimg4);

            label_jarak14.Text = selisih41+"";
            label_jarak24.Text = selisih42+"";
            label_jarak34.Text = selisih43+"";

            if (selisih41 < selisih42 && selisih41 < selisih43)
            {
                MessageBox.Show("Image 1 paling mirip");
                pb_image_hasil_ekstraksi.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_image_hasil_ekstraksi.Image = pb_img1.Image;
   
            }
            else if (selisih42 < selisih41 && selisih42 < selisih43)
            {
                MessageBox.Show("Image 2 paling mirip");
                pb_image_hasil_ekstraksi.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_image_hasil_ekstraksi.Image = pb_img2.Image;
            }
            else if (selisih43 < selisih41 && selisih43 < selisih42)
            {
                MessageBox.Show("Image 3 paling mirip");
                pb_image_hasil_ekstraksi.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_image_hasil_ekstraksi.Image = pb_img3.Image;
            }

            

        }


        private int Compare(int[] rx, int[] r4,int[] gx, int[] g4,int[] bx, int[] b4)
        {
            int value = 0;
            int sumr=0, sumg=0, sumb=0;
            for (int i = 0; i < 16; i++)
            {
                sumr += Math.Abs(rx[i] - r4[i]);
                sumg += Math.Abs(gx[i] - g4[i]); 
                sumb += Math.Abs(bx[i] - b4[i]);
            }

            value = (sumr + sumg + sumb) / 3;
            return value;
        }

        // ekstraksi bentuk
        int[,] constant = new int[,] { 
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 },
        { 1,1,1,1,1,1,1,1,1,1 }
        };
       
        
        int[] avValueimg1 = new int[16];
        int[] avValueimg2 = new int[16];
        int[] avValueimg3 = new int[16];
        int[] avValueimg4 = new int[16];

        int[,] binValueimg1;
        int[,] binValueimg2;
        int[,] binValueimg3;
        int[,] binValueimg4;
        private void btn_load_img_1_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img_1.Image = new Bitmap(pb_img_1.Width, pb_img_1.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img_1.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img_1.Image = objBitmap;
            }
        }

        private void btn_load_img_2_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img_2.Image = new Bitmap(pb_img_2.Width, pb_img_2.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img_2.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img_2.Image = objBitmap;
            }
        }

        private void btn_load_img_3_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img_3.Image = new Bitmap(pb_img_3.Width, pb_img_3.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img_3.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img_3.Image = objBitmap;
            }
        }

        private void btn_load_img_4_Click(object sender, EventArgs e)
        {
            DialogResult d = openFileDialog1.ShowDialog();
            if (d == DialogResult.OK)
            {
                pb_img_4.Image = new Bitmap(pb_img_4.Width, pb_img_4.Height);
                objBitmap = new Bitmap(openFileDialog1.FileName);
                pb_img_4.SizeMode = PictureBoxSizeMode.StretchImage;
                pb_img_4.Image = objBitmap;
            }
        }

        private void btn_his_img_1_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img_1.Image;
            
            binValueimg1 = new int[pb_img_1.Width, pb_img_1.Height];
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    if (red == 255 && green == 255 && blue == 255)
                    {
                        binValueimg1[x, y] = 0;
                    }
                    else
                    {
                        binValueimg1[x, y] = 1;
                    }
                }

            int[,] vektor = new int[10,10];
            int sum = 0;
            int x1=0,y1=0;
            Bitmap objHasil = new Bitmap(10,10);
            
            for (int x = 0; x < binValueimg1.GetLength(0); x++)
            {
                sum = 0;
                for (int y = 0; y < binValueimg1.GetLength(1); y++)
                {
                    if (y % 10 == 9)
                    {
                        sum += binValueimg1[x, y];
                        vektor[x1,y1] += sum;
                        y1++;
                        sum = 0;
                    }
                    else
                    {
                        sum += binValueimg1[x, y];
                    }
                }
                if (x % 10 == 9)
                {
                    x1++;
                    sum = 0;
                }
                sum = 0;
                y1 = 0;
            }

            for (int x = 0; x < vektor.GetLength(0); x++)
                for (int y = 0; y < vektor.GetLength(1); y++)
                {
                    Color w;
                    if(vektor[x,y] < 40){
                        w = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        w = Color.FromArgb(0, 0, 0);
                    }
                    // pixel yang sudah diambil disalin ke image baru
                    objHasil.SetPixel(x, y, w);
                }

            pb_img_1_hasil.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_img_1_hasil.Image = objHasil;
        }

        private void btn_his_img_2_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img_2.Image;

            binValueimg2 = new int[pb_img_2.Width, pb_img_2.Height];
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    if (red == 255 && green == 255 && blue == 255)
                    {
                        binValueimg2[x, y] = 0;
                    }
                    else
                    {
                        binValueimg2[x, y] = 1;
                    }
                }

            int[,] vektor = new int[10, 10];
            int sum = 0;
            int x1 = 0, y1 = 0;
            Bitmap objHasil = new Bitmap(10, 10);

            for (int x = 0; x < binValueimg2.GetLength(0); x++)
            {
                sum = 0;
                for (int y = 0; y < binValueimg2.GetLength(1); y++)
                {
                    if (y % 10 == 9)
                    {
                        sum += binValueimg2[x, y];
                        vektor[x1, y1] += sum;
                        y1++;
                        sum = 0;
                    }
                    else
                    {
                        sum += binValueimg2[x, y];
                    }
                }
                if (x % 10 == 9)
                {
                    x1++;
                    sum = 0;
                }
                sum = 0;
                y1 = 0;
            }

            for (int x = 0; x < vektor.GetLength(0); x++)
                for (int y = 0; y < vektor.GetLength(1); y++)
                {
                    Color w;
                    if (vektor[x, y] < 40)
                    {
                        w = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        w = Color.FromArgb(0, 0, 0);
                    }
                    // pixel yang sudah diambil disalin ke image baru
                    objHasil.SetPixel(x, y, w);
                }

            pb_img_2_hasil.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_img_2_hasil.Image = objHasil;

            
        }

        private void btn_his_img_3_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img_3.Image;

            binValueimg3 = new int[pb_img_3.Width, pb_img_3.Height];
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    if (red == 255 && green == 255 && blue == 255)
                    {
                        binValueimg3[x, y] = 0;
                    }
                    else
                    {
                        binValueimg3[x, y] = 1;
                    }
                }

            int[,] vektor = new int[10, 10];
            int sum = 0;
            int x1 = 0, y1 = 0;
            Bitmap objHasil = new Bitmap(10, 10);

            for (int x = 0; x < binValueimg3.GetLength(0); x++)
            {
                sum = 0;
                for (int y = 0; y < binValueimg3.GetLength(1); y++)
                {
                    if (y % 10 == 9)
                    {
                        sum += binValueimg3[x, y];
                        vektor[x1, y1] += sum;
                        y1++;
                        sum = 0;
                    }
                    else
                    {
                        sum += binValueimg3[x, y];
                    }
                }
                if (x % 10 == 9)
                {
                    x1++;
                    sum = 0;
                }
                sum = 0;
                y1 = 0;
            }

            for (int x = 0; x < vektor.GetLength(0); x++)
                for (int y = 0; y < vektor.GetLength(1); y++)
                {
                    Color w;
                    if (vektor[x, y] < 40)
                    {
                        w = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        w = Color.FromArgb(0, 0, 0);
                    }
                    // pixel yang sudah diambil disalin ke image baru
                    objHasil.SetPixel(x, y, w);
                }

            pb_img_3_hasil.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_img_3_hasil.Image = objHasil;
        }

        private void btn_his_img_4_Click(object sender, EventArgs e)
        {
            Bitmap ob = (Bitmap)pb_img_4.Image;

            binValueimg4 = new int[pb_img_4.Width, pb_img_4.Height];
            int red, green, blue;
            Color color;

            for (int x = 0; x < ob.Width; x++)
                for (int y = 0; y < ob.Height; y++)
                {
                    color = ob.GetPixel(x, y);
                    red = color.R;
                    green = color.G;
                    blue = color.B;
                    if (red == 255 && green == 255 && blue == 255)
                    {
                        binValueimg4[x, y] = 0;
                    }
                    else
                    {
                        binValueimg4[x, y] = 1;
                    }
                }

            int[,] vektor = new int[10, 10];
            int sum = 0;
            int x1 = 0, y1 = 0;
            Bitmap objHasil = new Bitmap(10, 10);

            for (int x = 0; x < binValueimg4.GetLength(0); x++)
            {
                sum = 0;
                for (int y = 0; y < binValueimg4.GetLength(1); y++)
                {
                    if (y % 10 == 9)
                    {
                        sum += binValueimg4[x, y];
                        vektor[x1, y1] += sum;
                        y1++;
                        sum = 0;
                    }
                    else
                    {
                        sum += binValueimg4[x, y];
                    }
                }
                if (x % 10 == 9)
                {
                    x1++;
                    sum = 0;
                }
                sum = 0;
                y1 = 0;
            }

            for (int x = 0; x < vektor.GetLength(0); x++)
                for (int y = 0; y < vektor.GetLength(1); y++)
                {
                    Color w;
                    if (vektor[x, y] < 40)
                    {
                        w = Color.FromArgb(255, 255, 255);
                    }
                    else
                    {
                        w = Color.FromArgb(0, 0, 0);
                    }
                    // pixel yang sudah diambil disalin ke image baru
                    objHasil.SetPixel(x, y, w);
                }

            pb_img_4_hasil.SizeMode = PictureBoxSizeMode.StretchImage;
            pb_img_4_hasil.Image = objHasil;    
        }

        private void btn_compare_bentuk_Click(object sender, EventArgs e)
        {
            int selisih41 = CompareBentuk(binValueimg4,binValueimg1);
            int selisih42 = CompareBentuk(binValueimg4, binValueimg2);
            int selisih43 = CompareBentuk(binValueimg4, binValueimg3);

            label_jarak_img14.Text = selisih41 + "";
            label_jarak_img24.Text = selisih42 + "";
            label_jarak_img34.Text = selisih43 + "";


            if (selisih41 < selisih42 && selisih41 < selisih43)
            {
                MessageBox.Show("Image 1 paling mirip");
                pictureBox22.Image = pb_img_1.Image;
            }
            else if (selisih42 < selisih41 && selisih42 < selisih43)
            {
                pictureBox22.Image = pb_img_2.Image;
                MessageBox.Show("Image 2 paling mirip");
            }
            else if (selisih43 < selisih41 && selisih43 < selisih42)
            {
                pictureBox22.Image = pb_img_3.Image;
                MessageBox.Show("Image 3 paling mirip");
            }
        }

        private int CompareBentuk(int[,] a, int[,] b)
        {

            int value = 0;
            int sum = 0;
            for (int x = 0; x < a.GetLength(0); x++)
            {
                for (int y = 0; y < a.GetLength(1); y++)
                {
                    sum += Math.Abs(a[x,y] - b[x,y]);
                }
                    
            }

            value = sum;
            return value;
        }
    }
}
