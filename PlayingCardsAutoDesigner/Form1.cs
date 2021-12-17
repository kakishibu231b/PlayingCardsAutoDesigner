using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace PlayingCardsAutoDesigner
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();

            switch (result)
            {
                case DialogResult.OK:
                    string strFilePath = openFileDialog1.FileName;
                    textBox1.Text = strFilePath;

                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                    pictureBox1.Image = System.Drawing.Image.FromFile(strFilePath);
                    pictureBox1.Refresh();
                    break;

                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();

            string strSavePath = saveFileDialog1.FileName;

            string strValue = ConfigurationManager.AppSettings["key1"];

            if (result == DialogResult.OK)
            {
                string logoImagePath = textBox1.Text;

                Bitmap newImage = new Bitmap(5800, 8900);
                Graphics graphics = Graphics.FromImage(newImage);
                graphics.FillRectangle(Brushes.White, graphics.VisibleClipBounds);
                graphics.DrawRectangle(Pens.Black, 0, 0, 5800, 8900);

                Bitmap logoImage1 = new Bitmap(logoImagePath);

                int scale1 = 2;
                int width1 = logoImage1.Width * scale1;
                int height1 = logoImage1.Height * scale1;

                int scale2 = 4;
                int width2 = logoImage1.Width * scale2;
                int height2 = logoImage1.Height * scale2;

                Font fnt = new Font("MS UI Gothic", 500);

                graphics.DrawString("10", fnt, Brushes.Black, 80, 100);
                graphics.DrawImage(logoImage1, 150, 750, width1, height1);

                int image1_w = width1 / 2 + 100;
                int image1_h = height1 / 2;

                int image2_w = newImage.Width - image1_w - width2;
                int image2_h = height1 / 2;

                graphics.DrawImage(logoImage1, image1_w, image1_h, width2, height2);
                graphics.DrawImage(logoImage1, image2_w, image2_h, width2, height2);

                graphics.DrawImage(logoImage1, image1_w, image1_h + height2, width2, height2);
                graphics.DrawImage(logoImage1, image2_w, image2_h + height2, width2, height2);

                graphics.DrawImage(logoImage1, newImage.Width / 2 - width2 / 2 , image2_h + height2/2, width2, height2);

                newImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                newImage.RotateFlip(RotateFlipType.Rotate180FlipX);

                graphics.DrawString("10", fnt, Brushes.Black, 100, 100);
                graphics.DrawImage(logoImage1, 150, 750, width1, height1);

                graphics.DrawImage(logoImage1, image1_w, image1_h, width2, height2);
                graphics.DrawImage(logoImage1, image2_w, image2_h, width2, height2);

                graphics.DrawImage(logoImage1, image1_w, image1_h + height2, width2, height2);
                graphics.DrawImage(logoImage1, image2_w, image2_h + height2, width2, height2);

                graphics.DrawImage(logoImage1, newImage.Width / 2 - width2 / 2, image2_h + height2 / 2, width2, height2);

                newImage.Save(strSavePath, System.Drawing.Imaging.ImageFormat.Png);

                fnt.Dispose();
                logoImage1.Dispose();
                graphics.Dispose();
                newImage.Dispose();
            }
        }
    }
}
