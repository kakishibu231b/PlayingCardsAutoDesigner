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
       Brush m_fontBrush;

        public Form1()
        {
            InitializeComponent();

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            m_fontBrush = Brushes.Black;
        }

        private string getMarkFileName()
        {
            string strMarkFileName = "";
            if (radioButton1.Checked)
            {
                strMarkFileName = ConfigurationManager.AppSettings["MarkC"];
            }
            else if (radioButton2.Checked)
            {
                strMarkFileName = ConfigurationManager.AppSettings["MarkD"];
            }
            else if (radioButton3.Checked)
            {
                strMarkFileName = ConfigurationManager.AppSettings["MarkH"];
            }
            else if (radioButton4.Checked)
            {
                strMarkFileName = ConfigurationManager.AppSettings["MarkS"];
            }
            return strMarkFileName;
        }

        private string getCardNumber()
        {
            string strCardNumber = "";
            if (radioButton7.Checked)
            {
                strCardNumber = "A";
            }
            else if (radioButton8.Checked)
            {
                strCardNumber = "2";
            }
            else if (radioButton9.Checked)
            {
                strCardNumber = "3";
            }
            else if (radioButton10.Checked)
            {
                strCardNumber = "4";
            }
            else if (radioButton11.Checked)
            {
                strCardNumber = "5";
            }
            else if (radioButton12.Checked)
            {
                strCardNumber = "6";
            }
            else if (radioButton13.Checked)
            {
                strCardNumber = "7";
            }
            else if (radioButton14.Checked)
            {
                strCardNumber = "8";
            }
            else if (radioButton15.Checked)
            {
                strCardNumber = "9";
            }
            else if (radioButton16.Checked)
            {
                strCardNumber = "10";
            }
            else if (radioButton17.Checked)
            {
                strCardNumber = "J";
            }
            else if (radioButton18.Checked)
            {
                strCardNumber = "Q";
            }
            else if (radioButton19.Checked)
            {
                strCardNumber = "K";
            }
            return strCardNumber;
        }


        private Bitmap getImage(int mode)
        {
            Bitmap newImage = null;
            Bitmap logoImage1 = null;
            Bitmap logoImage2 = null;
            Bitmap logoImage3 = null;
            Graphics graphics = null;
            Font fnt = null;

            int intModeScale = 1;
            int intFontSize = (int)numericUpDown2.Value * 10;

            try
            {
                if (mode == 0 )
                {
                    intModeScale = 10;
                }

                // ロゴ取得
                string strLogoImagePath = textBox1.Text;
                if (!string.IsNullOrEmpty(strLogoImagePath))
                {
                    logoImage1 = new Bitmap(strLogoImagePath);
                }

                // マーク取得
                string strMarkFileName = getMarkFileName();
                if (!string.IsNullOrEmpty(strMarkFileName))
                {
                    logoImage2 = new Bitmap(strMarkFileName);
                }

                // カード番号取得
                string strCardNumber = getCardNumber();
                if (!string.IsNullOrEmpty(strCardNumber))
                {
                    string strFontName = textBox2.Text;
                    fnt = new Font(strFontName, intFontSize / intModeScale);
                }

                // キャンバス作成
                string strCardWidth = ConfigurationManager.AppSettings["CardWidth"];
                string strCardHeight = ConfigurationManager.AppSettings["CardHeight"];
                int intCardWidth = Int32.Parse(strCardWidth);
                int intCardHeight = Int32.Parse(strCardHeight);
                if( mode == 0 )
                {
                    intCardWidth = intCardWidth / intModeScale;
                    intCardHeight = intCardHeight / intModeScale;
                }

                newImage = new Bitmap(intCardWidth, intCardHeight);

                graphics = Graphics.FromImage(newImage);
                graphics.FillRectangle(Brushes.White, graphics.VisibleClipBounds);
                graphics.DrawRectangle(Pens.Black, 0, 0, intCardWidth, intCardHeight);

                // 背景取得
                string strBackGroundImagePath = textBox3.Text;
                if (!string.IsNullOrEmpty(strBackGroundImagePath))
                {
                    logoImage3 = new Bitmap(strBackGroundImagePath);
                    // 背景描画
                    if (logoImage3 != null)
                    {
                        int intBackGroundWidth = logoImage3.Width / intModeScale;
                        int intBackGroundHeight = logoImage3.Height / intModeScale;
                        graphics.DrawImage(logoImage3, 0, 0, intCardWidth, intCardHeight);
                    }
                }

                // ロゴ描画
                double intMarkScale = (double)numericUpDown1.Value;
                intMarkScale = intMarkScale / intModeScale;

                int intMarkWidth = 0;
                int intMarkHeight = 0;
                if (logoImage2 != null)
                {
                    intMarkWidth = (int)(logoImage2.Width * intMarkScale);
                    intMarkHeight = (int)(logoImage2.Height * intMarkScale);
                }

                double intLogoScale = 0;
                switch (strCardNumber)
                {
                    case "A":
                        intLogoScale = (double)numericUpDown9.Value;
                        break;

                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                        intLogoScale = (double)numericUpDown10.Value;
                        break;

                    case "J":
                    case "Q":
                    case "K":
                        intLogoScale = (double)numericUpDown11.Value;
                        break;

                    default:
                        break;
                }

                if (mode == 0)
                {
                    intLogoScale = intLogoScale / intModeScale;
                }
                int intLogoWidth = 0;
                int intLogoHeight = 0;
                if (logoImage1 != null)
                {
                    intLogoWidth = (int)(logoImage1.Width * intLogoScale);
                    intLogoHeight = (int)(logoImage1.Height * intLogoScale);
                }

                for (int ii = 0; ii < 2; ++ii)
                {
                    // カードマーク描画
                    if (!string.IsNullOrEmpty(strMarkFileName))
                    {
                        int intMarkOffsetX = (int)numericUpDown3.Value * 10;
                        int intMarkOffsetY = (int)numericUpDown4.Value * 10;
                        graphics.DrawImage(logoImage2, intMarkOffsetX / intModeScale, intMarkOffsetY / intModeScale, intMarkWidth, intMarkHeight);
                    }

                    // カード番号描画
                    if (!string.IsNullOrEmpty(strCardNumber))
                    {
                        int intCardNumberOffsetX1 = (int)numericUpDown5.Value * 10;
                        int intCardNumberOffsetX2 = (int)numericUpDown6.Value * 10;
                        int intCardNumberOffsetX3 = (int)numericUpDown7.Value * 10;
                        int intCardNumberOffsetY = (int)numericUpDown8.Value * 10;

                        switch (strCardNumber)
                        {
                            case "2":
                            case "3":
                            case "4":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                            case "9":
                                graphics.DrawString(strCardNumber, fnt, m_fontBrush, intCardNumberOffsetX1 / intModeScale, intCardNumberOffsetY / intModeScale);
                                break;
                            case "10":
                                graphics.DrawString(strCardNumber, fnt, m_fontBrush, intCardNumberOffsetX2 / intModeScale, intCardNumberOffsetY / intModeScale);
                                break;
                            default:
                                graphics.DrawString(strCardNumber, fnt, m_fontBrush, intCardNumberOffsetX3 / intModeScale, intCardNumberOffsetY / intModeScale);
                                break;
                        }
                    }

                    // ロゴ描画
                    if (!string.IsNullOrEmpty(strLogoImagePath))
                    {
                        int intMarkOffsetX1 = (int)numericUpDown15.Value * 10;
                        int intMarkOffsetX2 = (int)numericUpDown17.Value * 10;
                        int intMarkOffsetY = (int)numericUpDown16.Value * 10;
                        if (mode == 0)
                        {
                            intMarkOffsetX1 = intMarkOffsetX1 / intModeScale;
                            intMarkOffsetX2 = intMarkOffsetX2 / intModeScale;
                            intMarkOffsetY = intMarkOffsetY / intModeScale;
                        }

                        int image1_w = 0;
                        int image1_h = 0;
                        int image2_w = 0;
                        int image2_h = 0;

                        // 左上座標
                        image1_w = newImage.Width / 5;
                        image1_h = newImage.Height / 6;

                        // 右上座標
                        image2_w = newImage.Width - image1_w - intLogoWidth;
                        image2_h = newImage.Height / 6;

                        // 左右中央上部
                        switch (strCardNumber)
                        {
                            case "2":
                            case "3":
                                graphics.DrawImage(logoImage1,
                                    newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                    image1_h + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                break;

                            default:
                                break;
                        }

                        // 左右上部
                        switch (strCardNumber)
                        {
                            case "4":
                            case "5":
                            case "6":
                            case "7":
                            case "8":
                                // 左上部
                                graphics.DrawImage(logoImage1,
                                    image1_w + intMarkOffsetX1 - intMarkOffsetX2,
                                    image1_h + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                // 右上部
                                graphics.DrawImage(logoImage1,
                                    image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                    image2_h + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                break;

                            default:
                                break;
                        }

                        // 中央上部
                        switch (strCardNumber)
                        {
                            case "8":
                                graphics.DrawImage(logoImage1,
                                    newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                    image2_h + image2_h / 2 + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                break;

                            default:
                                break;
                        }

                        // 左右上部2連
                        switch (strCardNumber)
                        {
                            case "9":
                            case "10":
                                graphics.DrawImage(logoImage1,
                                    image1_w + intMarkOffsetX1 - intMarkOffsetX2,
                                    image1_h + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                graphics.DrawImage(logoImage1,
                                    image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                    image2_h + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                graphics.DrawImage(logoImage1,
                                    image1_w + intMarkOffsetX1 - intMarkOffsetX2,
                                    image1_h + image1_h + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                graphics.DrawImage(logoImage1,
                                    image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                    image2_h + image2_h + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                break;

                            default:
                                break;
                        }

                        // 左右中央やや上部
                        switch (strCardNumber)
                        {
                            case "10":
                                graphics.DrawImage(logoImage1,
                                    newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                    image2_h + intLogoHeight / 2 + intMarkOffsetY,
                                    intLogoWidth,
                                    intLogoHeight);
                                break;

                            default:
                                break;
                        }

                        if (ii == 0)
                        {
                            // 上下左右中央
                            switch (strCardNumber)
                            {
                                case "A":
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        newImage.Height / 2 - intLogoHeight / 2 + intMarkOffsetY,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;

                                case "J":
                                case "Q":
                                case "K":
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        newImage.Height / 2 - intLogoHeight / 2 + intMarkOffsetY,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;

                                case "3":
                                case "5":
                                case "9":
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        newImage.Height / 2 - intLogoHeight / 2 + intMarkOffsetY,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;
                                default:
                                    break;
                            }

                            // 上下中央左右配置
                            switch (strCardNumber)
                            {
                                case "6":
                                case "7":
                                case "8":
                                    graphics.DrawImage(logoImage1,
                                        image1_w + intMarkOffsetX1 - intMarkOffsetX2,
                                        newImage.Height / 2 - intLogoHeight / 2 + intMarkOffsetY, 
                                        intLogoWidth, 
                                        intLogoHeight);
                                    graphics.DrawImage(logoImage1,
                                        image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                        newImage.Height / 2 - intLogoHeight / 2 + intMarkOffsetY, 
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;
                                default:
                                    break;
                            }

                            // 左右中央やや上部
                            switch (strCardNumber)
                            {
                                case "7":
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        image2_h + image2_h / 2 + intMarkOffsetY,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    newImage.RotateFlip(RotateFlipType.Rotate180FlipY);
                    newImage.RotateFlip(RotateFlipType.Rotate180FlipX);

                } // end of for
            }
            catch
            {

            }
            finally
            {
                if (fnt != null)
                {
                    fnt.Dispose();
                }
                if (logoImage1 != null)
                {
                    logoImage1.Dispose();
                }
                if (logoImage2 != null)
                {
                    logoImage2.Dispose();
                }
                if (logoImage3 != null)
                {
                    logoImage3.Dispose();
                }
                if (graphics != null)
                {
                    graphics.Dispose();
                }
            }
            return newImage;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    string strFilePath = openFileDialog1.FileName;
                    textBox1.Text = strFilePath;
                    pictureBox1.Image = getImage(0);
                    pictureBox1.Refresh();
                    break;

                default:
                    break;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    string strFilePath = openFileDialog1.FileName;
                    textBox3.Text = strFilePath;
                    pictureBox1.Image = getImage(0);
                    pictureBox1.Refresh();
                    break;

                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string strSavePath = saveFileDialog1.FileName;
                Bitmap newImage = getImage(1);
                newImage.Save(strSavePath, System.Drawing.Imaging.ImageFormat.Png);
                newImage.Dispose();
            }
        }
 
        private void radioButtonMark_CheckedChanged(object sender, EventArgs e)
        {
            if ( sender.GetType() == typeof(RadioButton) )
            {
                RadioButton radioButton = (RadioButton)sender;
                if ( radioButton.Checked == false )
                {
                    return;
                }
            }

            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = getImage(0);
            pictureBox1.Refresh();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = new Font(textBox2.Text, (int)numericUpDown2.Value);
            fontDialog1.MaxSize = 1000;

            DialogResult result = fontDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    textBox2.Text = fontDialog1.Font.Name;
                    radioButtonMark_CheckedChanged(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:
                    numericUpDown12.Value = colorDialog1.Color.R;
                    numericUpDown13.Value = colorDialog1.Color.G;
                    numericUpDown14.Value = colorDialog1.Color.B;

                    m_fontBrush.Dispose();
                    m_fontBrush = new SolidBrush(colorDialog1.Color);

                    radioButtonMark_CheckedChanged(sender, e);
                    break;
                default:
                    break;
            }
        }

        private void numericUpDown12_ValueChanged(object sender, EventArgs e)
        {
            Color color = Color.FromArgb((int)numericUpDown12.Value, (int)numericUpDown13.Value, (int)numericUpDown14.Value);
            m_fontBrush.Dispose();
            m_fontBrush = new SolidBrush(color);

            radioButtonMark_CheckedChanged(sender, e);
        }
    }
}
