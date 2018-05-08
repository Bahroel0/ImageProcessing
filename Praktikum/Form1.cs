using System;
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

        

        

    
    }
}
