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
    /// <summary>
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        /// <summary>
        /// 絵柄ファイルフルパス
        /// </summary>
        private string m_strPicturePath;

        /// <summary>
        /// 背景ファイルフルパス
        /// </summary>
        private string m_strBackgroundPath;

        /// <summary>
        /// 文字用ブラシ
        /// </summary>
        private Brush m_fontBrush;

        /// <summary>
        /// 絵柄サイズ(A)
        /// </summary>
        private Decimal decPicutureSizeA;

        /// <summary>
        /// 絵柄サイズ(2～10)
        /// </summary>
        private Decimal decPicutureSizeN;

        /// <summary>
        /// 絵柄サイズ(J,Q,K)
        /// </summary>
        private Decimal decPicutureSizeX;

        /// <summary>
        /// 絵柄位置調整(左右全体)
        /// </summary>
        private Decimal decPicutureOffsetX1;

        /// <summary>
        /// 絵柄位置調整(左右外側)
        /// </summary>
        private Decimal decPicutureOffsetX2;

        /// <summary>
        /// 絵柄位置調整(上下全体)
        /// </summary>
        private Decimal decPicutureOffsetY;

        /// <summary>
        /// マーク
        /// </summary>
        public class Suit
        {
            /// <summary>
            /// マークコンストラクタ
            /// </summary>
            public Suit()
            {
                m_strSuitViewName = "";
                m_intSuitType = 0;
            }

            /// <summary>
            /// マークコンストラクタ(初期値あり)
            /// </summary>
            /// <param name="strSuitViewName">マーク表示名称</param>
            /// <param name="strSuitFileName">マークファイル名</param>
            /// <param name="intSuitType">マーク種類</param>
            public Suit(string strSuitViewName, string strSuitFileName, Form1.ENUM_SUIT_TYPE intSuitType)
            {
                m_strSuitViewName = strSuitViewName;
                m_strSuitFileName = strSuitFileName;
                m_intSuitType = intSuitType;
            }

            /// <summary>
            /// マーク表示名称
            /// </summary>
            private string m_strSuitViewName;

            /// <summary>
            /// マーク表示名称取得/設定
            /// </summary>
            public string ViewName
            {
                get { return m_strSuitViewName; }
                set { m_strSuitViewName = value; }
            }

            /// <summary>
            /// マークファイル名
            /// </summary>
            private string m_strSuitFileName;

            /// <summary>
            /// マーク表示名称取得/設定
            /// </summary>
            public string FileName
            {
                get { return m_strSuitFileName; }
                set { m_strSuitFileName = value; }
            }

            /// <summary>
            /// マーク種類
            /// </summary>
            private Form1.ENUM_SUIT_TYPE m_intSuitType;

            /// <summary>
            /// マーク表示名称取得/設定
            /// </summary>
            public Form1.ENUM_SUIT_TYPE Value
            {
                get { return m_intSuitType; }
                set { m_intSuitType = value; }
            }
        }

        /// <summary>
        /// マーク種類
        /// </summary>
        private ENUM_SUIT_TYPE intSuitType;

        public enum ENUM_SUIT_TYPE
        {
            ENUM_SUIT_TYPE_START = 0,
            ENUM_SUIT_TYPE_CLUB,
            ENUM_SUIT_TYPE_DIAMOND,
            ENUM_SUIT_TYPE_HEART,
            ENUM_SUIT_TYPE_SPADE,
            ENUM_SUIT_TYPE_JOKER,
            ENUM_SUIT_TYPE_END
        }

        /// <summary>
        /// マークサイズ
        /// </summary>
        private Decimal decSuitSize;

        /// <summary>
        /// マーク左余白
        /// </summary>
        private Decimal decSuitLeftSpace;

        /// <summary>
        /// マーク上余白
        /// </summary>
        private Decimal decSuitTopSpace;

        /// <summary>
        /// 番号
        /// </summary>
        public class Rank
        {
            /// <summary>
            /// 番号コンストラクタ
            /// </summary>
            public Rank()
            {
                m_strRankViewName = "";
                m_intRankType = 0;
            }

            /// <summary>
            /// 番号コンストラクタ(初期値あり)
            /// </summary>
            /// <param name="strRankViewName">番号表示名称</param>
            /// <param name="intRankType">番号種類</param>
            public Rank(string strRankViewName, Form1.ENUM_RANK_TYPE intRankType)
            {
                m_strRankViewName = strRankViewName;
                m_intRankType = intRankType;
            }

            /// <summary>
            /// 番号表示名称
            /// </summary>
            private string m_strRankViewName;

            /// <summary>
            /// 番号表示名称取得/設定
            /// </summary>
            public string Name
            {
                get { return m_strRankViewName; }
                set { m_strRankViewName = value; }
            }

            /// <summary>
            /// 番号種類
            /// </summary>
            private Form1.ENUM_RANK_TYPE m_intRankType;

            /// <summary>
            /// 番号表示名称取得/設定
            /// </summary>
            public Form1.ENUM_RANK_TYPE Value
            {
                get { return m_intRankType; }
                set { m_intRankType = value; }
            }
        }

        /// <summary>
        /// カード番号
        /// </summary>
        private ENUM_RANK_TYPE intRankType;

        public enum ENUM_RANK_TYPE
        {
            ENUM_RANK_TYPE_START = 0,
            ENUM_RANK_TYPE_ACE,
            ENUM_RANK_TYPE_R2,
            ENUM_RANK_TYPE_R3,
            ENUM_RANK_TYPE_R4,
            ENUM_RANK_TYPE_R5,
            ENUM_RANK_TYPE_R6,
            ENUM_RANK_TYPE_R7,
            ENUM_RANK_TYPE_R8,
            ENUM_RANK_TYPE_R9,
            ENUM_RANK_TYPE_R10,
            ENUM_RANK_TYPE_JACK,
            ENUM_RANK_TYPE_QUEEN,
            ENUM_RANK_TYPE_KING,
            ENUM_RANK_TYPE_JOKER,
            ENUM_RANK_TYPE_END
        }

        /// <summary>
        /// カード番号文字サイズ
        /// </summary>
        private Decimal decRankCharSize;

        /// <summary>
        /// カード番号左余白(数字1桁)
        /// </summary>
        private Decimal decRankLeftSpace1;

        /// <summary>
        /// カード番号左余白(数字2桁)
        /// </summary>
        private Decimal decRankLeftSpace2;

        /// <summary>
        /// カード番号左余白(文字)
        /// </summary>
        private Decimal decRankLeftSpace3;

        /// <summary>
        /// カード番号上余白(共通)
        /// </summary>
        private Decimal decRankTopSpace;

        /// <summary>
        /// カード番号フォント名
        /// </summary>
        private string strRankFontName;

        /// <summary>
        /// カード番号文字色赤
        /// </summary>
        private int intRankFontColorRed;

        /// <summary>
        /// カード番号文字色緑
        /// </summary>
        private int intRankFontColorGreen;

        /// <summary>
        /// カード番号文字色青
        /// </summary>
        private int intRankFontColorBlue;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public Form1()
        {
            InitializeComponent();

            //------------------------------
            // ツールバー初期設定
            //------------------------------
            // マークコンボボックス初期設定処理
            initSuitComboBox();
            // 番号コンボボックス初期設定処理
            initRankComboBox();

            // 画像表示領域初期設定
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        /// <summary>
        /// メイン画面起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            m_fontBrush = Brushes.Black;
            pictureBox1.Image = getImage(0);
            pictureBox1.Refresh();
        }

        /// <summary>
        /// マークコンボボックス初期設定処理
        /// </summary>
        private void initSuitComboBox()
        {
            string strSuitKey1 = "";
            string strSuitKey2 = "";
            string strSuitViewName = "";
            string strSuitFileName = "";
            for (ENUM_SUIT_TYPE ii = ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_START; ii < ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_END; ++ii )
            {
                switch (ii)
                {
                    case ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_CLUB:
                        strSuitKey1 = "SuitViewNameClub";
                        strSuitKey2 = "SuitFileNameClub";
                        break;
                    case ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_DIAMOND:
                        strSuitKey1 = "SuitViewNameDiamond";
                        strSuitKey2 = "SuitFileNameDiamond";
                        break;
                    case ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_HEART:
                        strSuitKey1 = "SuitViewNameHeart";
                        strSuitKey2 = "SuitFileNameHeart";
                        break;
                    case ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_SPADE:
                        strSuitKey1 = "SuitViewNameSpade";
                        strSuitKey2 = "SuitFileNameSpade";
                        break;
                    case ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_JOKER:
                        strSuitKey1 = "SuitViewNameJoker";
                        strSuitKey2 = "";
                        break;
                    default:
                        strSuitKey1 = "SuitViewNameNone";
                        strSuitKey2 = "";
                        break;
                }
                if (!string.IsNullOrEmpty (strSuitKey1))
                {
                    strSuitViewName = ConfigurationManager.AppSettings[strSuitKey1];
                }
                else
                {
                    strSuitViewName = "";
                }

                if (!string.IsNullOrEmpty(strSuitKey2))
                {
                    strSuitFileName = ConfigurationManager.AppSettings[strSuitKey2];
                }
                else
                {
                    strSuitFileName = "";
                }

                comboBoxSuite.Items.Add(new Suit(strSuitViewName, strSuitFileName, ii));
            }
            comboBoxSuite.DisplayMember = "ViewName";
        }

        /// <summary>
        /// マークファイル名取得
        /// </summary>
        /// <returns>マークファイル名</returns>
        private string getSuitFileName()
        {
            Suit suit = (Suit)comboBoxSuite.SelectedItem;
            if (suit == null)
            {
                return "";
            }
            return suit.FileName;
        }

        /// <summary>
        /// 番号コンボボックス初期設定処理
        /// </summary>
        private void initRankComboBox()
        {
            string strRankKey = "";
            string strRankName = "";
            for (ENUM_RANK_TYPE ii = ENUM_RANK_TYPE.ENUM_RANK_TYPE_START; ii < ENUM_RANK_TYPE.ENUM_RANK_TYPE_END; ++ii)
            {
                switch (ii)
                {
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_ACE:
                        strRankKey = "RankNameAce";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R2:
                        strRankKey = "RankNameR2";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R3:
                        strRankKey = "RankNameR3";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R4:
                        strRankKey = "RankNameR4";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R5:
                        strRankKey = "RankNameR5";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R6:
                        strRankKey = "RankNameR6";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R7:
                        strRankKey = "RankNameR7";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R8:
                        strRankKey = "RankNameR8";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R9:
                        strRankKey = "RankNameR9";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_R10:
                        strRankKey = "RankNameR10";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_JACK:
                        strRankKey = "RankNameJack";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_QUEEN:
                        strRankKey = "RankNameQueen";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_KING:
                        strRankKey = "RankNameKing";
                        break;
                    case ENUM_RANK_TYPE.ENUM_RANK_TYPE_JOKER:
                        strRankKey = "RankNameJoker";
                        break;
                    default:
                        strRankKey = "RankNameNone";
                        break;
                }
                if (!string.IsNullOrEmpty(strRankKey))
                {
                    strRankName = ConfigurationManager.AppSettings[strRankKey];
                }
                comboBoxRank.Items.Add(new Rank(strRankName, ii));
            }
            comboBoxRank.DisplayMember = "Name";
        }

        /// <summary>
        /// カード番号取得
        /// </summary>
        /// <returns>カード番号</returns>
        private string getCardRank()
        {
            Rank rank = (Rank)comboBoxRank.SelectedItem;
            if (rank == null)
            {
                return "";
            }
            return rank.Name;
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
                string strLogoImagePath = m_strPicturePath;
                if (!string.IsNullOrEmpty(strLogoImagePath))
                {
                    logoImage1 = new Bitmap(strLogoImagePath);
                }

                // マーク取得
                string strMarkFileName = getSuitFileName();
                if (!string.IsNullOrEmpty(strMarkFileName))
                {
                    logoImage2 = new Bitmap(strMarkFileName);
                }

                // カード番号取得
                string strCardNumber = getCardRank();
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
                graphics.DrawRectangle(Pens.Black, 0, 0, intCardWidth-1, intCardHeight-1);

                // 背景取得
                string strBackGroundImagePath = m_strBackgroundPath;
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
                    m_strPicturePath = strFilePath;
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
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
                    m_strBackgroundPath = strFilePath;
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
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
                if (pictureBox1.Image != null)
                {
                    pictureBox1.Image.Dispose();
                }
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

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void toolStripComboBoxSuiteName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = getImage(0);
            pictureBox1.Refresh();
        }

        private void toolStripComboBoxRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = getImage(0);
            pictureBox1.Refresh();
        }
    }
}
