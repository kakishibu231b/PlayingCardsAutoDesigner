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
    public partial class PlayingCardsAutoDesignerForm : Form
    {
        /// <summary>
        /// 文字用ブラシ
        /// </summary>
        private Brush m_fontBrush;

        /// <summary>
        /// 背景用ブラシ
        /// </summary>
        private Brush m_backgroundBrush;

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
            /// マークタイプ
            /// </summary>
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
            /// マークコンストラクタ(初期値あり)
            /// </summary>
            /// <param name="strSuitViewName">マーク表示名称</param>
            /// <param name="strSuitFileName">マークファイル名</param>
            /// <param name="intSuitType">マーク種類</param>
            public Suit(string strSuitViewName, string strSuitFileName, int intSuitType)
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
            public string SuitViewName
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
            public string SuitFileName
            {
                get { return m_strSuitFileName; }
                set { m_strSuitFileName = value; }
            }

            /// <summary>
            /// マーク種類
            /// </summary>
            private int m_intSuitType;

            /// <summary>
            /// マーク表示名称取得/設定
            /// </summary>
            public int SuitType
            {
                get { return m_intSuitType; }
                set { m_intSuitType = value; }
            }

            /// <summary>
            /// マークサイズ
            /// </summary>
            private Decimal m_decSuitSize;

            /// <summary>
            /// マークサイズ取得/設定
            /// </summary>
            public Decimal SuitSize
            {
                get { return m_decSuitSize; }
                set { m_decSuitSize = value; }
            }

            /// <summary>
            /// マーク左余白
            /// </summary>
            private Decimal m_decSuitLeftSpace;

            /// <summary>
            /// マーク左余白取得/設定
            /// </summary>
            public Decimal SuitLeftSpace
            {
                get { return m_decSuitLeftSpace; }
                set { m_decSuitLeftSpace = value; }
            }

            /// <summary>
            /// マーク上余白
            /// </summary>
            private Decimal m_decSuitTopSpace;

            /// <summary>
            /// マークサイズ取得/設定
            /// </summary>
            public Decimal SuitTopSpace
            {
                get { return m_decSuitTopSpace; }
                set { m_decSuitTopSpace = value; }
            }
        }

        /// <summary>
        /// 絵柄
        /// </summary>
        public class Picture
        {
             /// <summary>
             /// コンストラクタ
             /// </summary>
            public Picture()
            {

            }

            /// <summary>
            /// 絵柄ファイルフルパス
            /// </summary>
            private string m_strPicturePath;

            /// <summary>
            /// 絵柄ファイルフルパス取得/設定
            /// </summary>
            public string PicturePath
            {
                get { return m_strPicturePath; }
                set { m_strPicturePath = value; }
            }

            /// <summary>
            /// 絵柄サイズ(A)
            /// </summary>
            private Decimal m_decPictureSizeA;

            /// <summary>
            /// 絵柄サイズ(A)取得/設定
            /// </summary>
            public Decimal PictureSizeA
            {
                get { return m_decPictureSizeA; }
                set { m_decPictureSizeA = value; }
            }

            /// <summary>
            /// 絵柄サイズ(2～10)
            /// </summary>
            private Decimal m_decPictureSizeN;

            /// <summary>
            /// 絵柄サイズ(2～10)取得/設定
            /// </summary>
            public Decimal PictureSizeN
            {
                get { return m_decPictureSizeN; }
                set { m_decPictureSizeN = value; }
            }

            /// <summary>
            /// 絵柄サイズ(J,Q,K)
            /// </summary>
            private Decimal m_decPictureSizeX;

            /// <summary>
            /// 絵柄サイズ(J,Q,K)取得/設定
            /// </summary>
            public Decimal PictureSizeX
            {
                get { return m_decPictureSizeX; }
                set { m_decPictureSizeX = value; }
            }

            /// <summary>
            /// 絵柄位置調整(左右全体)
            /// </summary>
            private Decimal m_decPictureOffsetX1;

            /// <summary>
            /// 絵柄位置調整(左右全体)取得/設定
            /// </summary>
            public Decimal PictureOffsetX1
            {
                get { return m_decPictureOffsetX1; }
                set { m_decPictureOffsetX1 = value; }
            }

            /// <summary>
            /// 絵柄位置調整(左右外側)
            /// </summary>
            private Decimal m_decPictureOffsetX2;

            /// <summary>
            /// 絵柄位置調整(左右外側)取得/設定
            /// </summary>
            public Decimal PictureOffsetX2
            {
                get { return m_decPictureOffsetX2; }
                set { m_decPictureOffsetX2 = value; }
            }

            /// <summary>
            /// 絵柄位置調整(上下全体)
            /// </summary>
            private Decimal m_decPictureOffsetY1;

            /// <summary>
            /// 絵柄位置調整(上下全体)取得/設定
            /// </summary>
            public Decimal PictureOffsetY1
            {
                get { return m_decPictureOffsetY1; }
                set { m_decPictureOffsetY1 = value; }
            }

            /// <summary>
            /// 絵柄位置調整(上下外側)
            /// </summary>
            private Decimal m_decPictureOffsetY2;

            /// <summary>
            /// 絵柄位置調整(上下外側)取得/設定
            /// </summary>
            public Decimal PictureOffsetY2
            {
                get { return m_decPictureOffsetY2; }
                set { m_decPictureOffsetY2 = value; }
            }

            /// <summary>
            /// 絵柄位置調整(上下内側)
            /// </summary>
            private Decimal m_decPictureOffsetY3;

            /// <summary>
            /// 絵柄位置調整(上下内側)取得/設定
            /// </summary>
            public Decimal PictureOffsetY3
            {
                get { return m_decPictureOffsetY3; }
                set { m_decPictureOffsetY3 = value; }
            }

            /// <summary>
            /// 絵柄位置調整(上下中央)
            /// </summary>
            private Decimal m_decPictureOffsetY4;

            /// <summary>
            /// 絵柄位置調整(上下中央)取得/設定
            /// </summary>
            public Decimal PictureOffsetY4
            {
                get { return m_decPictureOffsetY4; }
                set { m_decPictureOffsetY4 = value; }
            }
        }

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
            /// ランクタイプ
            /// </summary>
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
            /// 番号コンストラクタ(初期値あり)
            /// </summary>
            /// <param name="strRankViewName">番号表示名称</param>
            /// <param name="intRankType">番号種類</param>
            public Rank(string strRankViewName, int intRankType)
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
            public string RankViewName
            {
                get { return m_strRankViewName; }
                set { m_strRankViewName = value; }
            }

            /// <summary>
            /// 番号種類
            /// </summary>
            private int m_intRankType;

            /// <summary>
            /// 番号表示名称取得/設定
            /// </summary>
            public int RankType
            {
                get { return m_intRankType; }
                set { m_intRankType = value; }
            }

            /// <summary>
            /// カード番号文字サイズ
            /// </summary>
            private Decimal decRankFontSize;

            /// <summary>
            /// カード番号文字サイズ取得/設定
            /// </summary>
            public Decimal RankFontSize
            {
                get { return decRankFontSize; }
                set { decRankFontSize = value; }
            }

            /// <summary>
            /// カード番号左余白(数字1桁)
            /// </summary>
            private Decimal decRankLeftSpace1;

            /// <summary>
            /// カード番号左余白(数字1桁)取得/設定
            /// </summary>
            public Decimal RankLeftSpace1
            {
                get { return decRankLeftSpace1; }
                set { decRankLeftSpace1 = value; }
            }

            /// <summary>
            /// カード番号左余白(数字2桁)
            /// </summary>
            private Decimal decRankLeftSpace2;

            /// <summary>
            /// カード番号左余白(数字2桁)取得/設定
            /// </summary>
            public Decimal RankLeftSpace2
            {
                get { return decRankLeftSpace2; }
                set { decRankLeftSpace2 = value; }
            }

            /// <summary>
            /// カード番号左余白(文字)
            /// </summary>
            private Decimal decRankLeftSpace3;

            /// <summary>
            /// カード番号左余白(文字)取得/設定
            /// </summary>
            public Decimal RankLeftSpace3
            {
                get { return decRankLeftSpace3; }
                set { decRankLeftSpace3 = value; }
            }

            /// <summary>
            /// カード番号上余白(共通)
            /// </summary>
            private Decimal decRankTopSpace;

            /// <summary>
            /// カード番号上余白(共通)取得/設定
            /// </summary>
            public Decimal RankTopSpace
            {
                get { return decRankTopSpace; }
                set { decRankTopSpace = value; }
            }

            /// <summary>
            /// カード番号フォント名
            /// </summary>
            private string strRankFontName;

            /// <summary>
            /// カード番号フォント名取得/設定
            /// </summary>
            public string RankFontName
            {
                get { return strRankFontName; }
                set { strRankFontName = value; }
            }

            /// <summary>
            /// カード番号文字色赤
            /// </summary>
            private int intRankFontColorRed;

            /// <summary>
            /// カード番号文字色赤取得/設定
            /// </summary>
            public int RankFontColorRed
            {
                get { return intRankFontColorRed; }
                set { intRankFontColorRed = value; }
            }

            /// <summary>
            /// カード番号文字色緑
            /// </summary>
            private int intRankFontColorGreen;

            /// <summary>
            /// カード番号文字色緑取得/設定
            /// </summary>
            public int RankFontColorGreen
            {
                get { return intRankFontColorGreen; }
                set { intRankFontColorGreen = value; }
            }

            /// <summary>
            /// カード番号文字色青
            /// </summary>
            private int intRankFontColorBlue;

            /// <summary>
            /// カード番号文字色青取得/設定
            /// </summary>
            public int RankFontColorBlue
            {
                get { return intRankFontColorBlue; }
                set { intRankFontColorBlue = value; }
            }
        }

        public class BackGround
        {
            /// <summary>
            /// コンストラクタ
            /// </summary>
            public BackGround()
            {

            }

            /// <summary>
            /// 背景ファイルフルパス
            /// </summary>
            private string m_strBackgroundPath;

            /// <summary>
            /// 背景色文字色赤取得/設定
            /// </summary>
            public string BackgroundPath
            {
                get { return m_strBackgroundPath; }
                set { m_strBackgroundPath = value; }
            }

            /// <summary>
            /// 背景色文字色赤
            /// </summary>
            private int intBackGroundColorRed;

            /// <summary>
            /// 背景色文字色赤取得/設定
            /// </summary>
            public int BackGroundColorRed
            {
                get { return intBackGroundColorRed; }
                set { intBackGroundColorRed = value; }
            }

            /// <summary>
            /// 背景色文字色緑
            /// </summary>
            private int intBackGroundColorGreen;

            /// <summary>
            /// 背景色文字色緑取得/設定
            /// </summary>
            public int BackGroundColorGreen
            {
                get { return intBackGroundColorGreen; }
                set { intBackGroundColorGreen = value; }
            }

            /// <summary>
            /// 背景色文字色青
            /// </summary>
            private int intBackGroundColorBlue;

            /// <summary>
            /// 背景色文字色青取得/設定
            /// </summary>
            public int BackGroundColorBlue
            {
                get { return intBackGroundColorBlue; }
                set { intBackGroundColorBlue = value; }
            }
        }

        /// <summary>
        /// Suitクラスオブジェクト
        /// </summary>
        Suit m_suit;

        /// <summary>
        /// Pictureクラスオブジェクト
        /// </summary>
        Picture m_picture;

        /// <summary>
        /// Rankクラスオブジェクト
        /// </summary>
        Rank m_rank;

        /// <summary>
        /// BackGroundクラスオブジェクト
        /// </summary>
        BackGround m_background;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public PlayingCardsAutoDesignerForm()
        {
            InitializeComponent();

            // マーク初期設定
            initSuit();

            // 絵柄初期設定
            initPicture();

            // ランク初期設定
            initRank();

            // 背景初期設定
            iniBackGround();

            System.IO.StreamReader sr1 = null;
            System.IO.StreamReader sr2 = null;
            System.IO.StreamReader sr3 = null;
            System.IO.StreamReader sr4 = null;
            try
            {
                System.Xml.Serialization.XmlSerializer serializer1 = new System.Xml.Serialization.XmlSerializer(typeof(Suit));
                System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(typeof(Picture));
                System.Xml.Serialization.XmlSerializer serializer3 = new System.Xml.Serialization.XmlSerializer(typeof(Rank));
                System.Xml.Serialization.XmlSerializer serializer4 = new System.Xml.Serialization.XmlSerializer(typeof(BackGround));
                sr1 = new System.IO.StreamReader("settings1.config", new System.Text.UTF8Encoding(false));
                sr2 = new System.IO.StreamReader("settings2.config", new System.Text.UTF8Encoding(false));
                sr3 = new System.IO.StreamReader("settings3.config", new System.Text.UTF8Encoding(false));
                sr4 = new System.IO.StreamReader("settings4.config", new System.Text.UTF8Encoding(false));
                m_suit = (Suit)serializer1.Deserialize(sr1);
                m_picture = (Picture)serializer2.Deserialize(sr2);
                m_rank = (Rank)serializer3.Deserialize(sr3);
                m_background = (BackGround)serializer4.Deserialize(sr4);

                comboBoxSuit.SelectedIndex = m_suit.SuitType;
                suitSize.Value = m_suit.SuitSize;
                suitLeftSpace.Value = m_suit.SuitLeftSpace;
                suitTopSpace.Value = m_suit.SuitTopSpace;

                pictureSizeA.Value = m_picture.PictureSizeA;
                pictureSizeN.Value = m_picture.PictureSizeN;
                pictureSizeX.Value = m_picture.PictureSizeX;
                pictureOffsetX1.Value = m_picture.PictureOffsetX1;
                pictureOffsetX2.Value = m_picture.PictureOffsetX2;
                pictureOffsetY1.Value = m_picture.PictureOffsetY1;
                pictureOffsetY2.Value = m_picture.PictureOffsetY2;
                pictureOffsetY3.Value = m_picture.PictureOffsetY3;
                pictureOffsetY4.Value = m_picture.PictureOffsetY4;

                comboBoxRank.SelectedIndex = m_rank.RankType;
                rankFontSize.Value = m_rank.RankFontSize;
                rankLeftSpace1.Value = m_rank.RankLeftSpace1;
                rankLeftSpace2.Value = m_rank.RankLeftSpace2;
                rankLeftSpace3.Value = m_rank.RankLeftSpace3;
                rankTopSpace.Value = m_rank.RankTopSpace;
                rankFontName.Text = m_rank.RankFontName;
                rankFontColorRed.Value = m_rank.RankFontColorRed;
                rankFontColorGreen.Value = m_rank.RankFontColorGreen;
                rankFontColorBlue.Value = m_rank.RankFontColorBlue;

                backgroundColorRed.Value = m_background.BackGroundColorRed;
                backgroundColorGreen.Value = m_background.BackGroundColorGreen;
                backgroundColorBlue.Value = m_background.BackGroundColorBlue;
            }
            catch
            {

            }
            finally
            {
                if (sr1 != null)
                {
                    sr1.Close();
                }
                if (sr2 != null)
                {
                    sr2.Close();
                }
                if (sr3 != null)
                {
                    sr3.Close();
                }
                if (sr4 != null)
                {
                    sr4.Close();
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            System.IO.StreamWriter sw1 = null;
            System.IO.StreamWriter sw2 = null;
            System.IO.StreamWriter sw3 = null;
            System.IO.StreamWriter sw4 = null;
            try
            {
                sw1 = new System.IO.StreamWriter("settings1.config", false, new System.Text.UTF8Encoding(false));
                sw2 = new System.IO.StreamWriter("settings2.config", false, new System.Text.UTF8Encoding(false));
                sw3 = new System.IO.StreamWriter("settings3.config", false, new System.Text.UTF8Encoding(false));
                sw4 = new System.IO.StreamWriter("settings4.config", false, new System.Text.UTF8Encoding(false));
                System.Xml.Serialization.XmlSerializer serializer1 = new System.Xml.Serialization.XmlSerializer(typeof(Suit));
                System.Xml.Serialization.XmlSerializer serializer2 = new System.Xml.Serialization.XmlSerializer(typeof(Picture));
                System.Xml.Serialization.XmlSerializer serializer3 = new System.Xml.Serialization.XmlSerializer(typeof(Rank));
                System.Xml.Serialization.XmlSerializer serializer4 = new System.Xml.Serialization.XmlSerializer(typeof(BackGround));
                serializer1.Serialize(sw1, m_suit);
                serializer2.Serialize(sw2, m_picture);
                serializer3.Serialize(sw3, m_rank);
                serializer4.Serialize(sw4, m_background);
            }
            catch
            {

            }
            finally
            {
                if (sw1 != null)
                {
                    sw1.Close();
                }
                if (sw2 != null)
                {
                    sw2.Close();
                }
                if (sw3 != null)
                {
                    sw3.Close();
                }
                if (sw4 != null)
                {
                    sw4.Close();
                }
            }
        }

        /// <summary>
        /// マーク初期設定
        /// </summary>
        private void initSuit()
        {
            // マークコンボボックス初期設定処理
            initSuitComboBox();

            // Suitクラスオブジェクト生成
            m_suit = new Suit();
            m_suit.SuitSize = suitSize.Value;
            m_suit.SuitLeftSpace = suitLeftSpace.Value;
            m_suit.SuitTopSpace = suitTopSpace.Value;
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
            for (Suit.ENUM_SUIT_TYPE ii = Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_START; ii < Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_END; ++ii )
            {
                switch (ii)
                {
                    case Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_CLUB:
                        strSuitKey1 = "SuitViewNameClub";
                        strSuitKey2 = "SuitFileNameClub";
                        break;
                    case Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_DIAMOND:
                        strSuitKey1 = "SuitViewNameDiamond";
                        strSuitKey2 = "SuitFileNameDiamond";
                        break;
                    case Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_HEART:
                        strSuitKey1 = "SuitViewNameHeart";
                        strSuitKey2 = "SuitFileNameHeart";
                        break;
                    case Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_SPADE:
                        strSuitKey1 = "SuitViewNameSpade";
                        strSuitKey2 = "SuitFileNameSpade";
                        break;
                    case Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_JOKER:
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

                comboBoxSuit.Items.Add(new Suit(strSuitViewName, strSuitFileName, (int)ii));
            }
            comboBoxSuit.DisplayMember = "SuitViewName";
        }

        /// <summary>
        /// 絵柄初期設定
        /// </summary>
        public void initPicture()
        {
            // Pictureクラスオブジェクト生成
            m_picture = new Picture();
            m_picture.PictureSizeA = pictureSizeA.Value;
            m_picture.PictureSizeN = pictureSizeN.Value;
            m_picture.PictureSizeX = pictureSizeX.Value;
            m_picture.PictureOffsetX1 = pictureOffsetX1.Value;
            m_picture.PictureOffsetX2 = pictureOffsetX2.Value;
            m_picture.PictureOffsetY1 = pictureOffsetY1.Value;
            m_picture.PictureOffsetY2 = pictureOffsetY2.Value;
            m_picture.PictureOffsetY3 = pictureOffsetY3.Value;
            m_picture.PictureOffsetY4 = pictureOffsetY4.Value;
        }

        /// <summary>
        /// ランク初期設定
        /// </summary>
        public void initRank()
        {
            // 番号コンボボックス初期設定処理
            initRankComboBox();

            // Rankクラスオブジェクト生成
            m_rank = new Rank();
            m_rank.RankFontSize = rankFontSize.Value;
            m_rank.RankLeftSpace1 = rankLeftSpace1.Value;
            m_rank.RankLeftSpace2 = rankLeftSpace2.Value;
            m_rank.RankLeftSpace3 = rankLeftSpace3.Value;
            m_rank.RankTopSpace = rankTopSpace.Value;
            m_rank.RankFontName = rankFontName.Text;
            m_rank.RankFontColorRed = (int)rankFontColorRed.Value;
            m_rank.RankFontColorGreen = (int)rankFontColorGreen.Value;
            m_rank.RankFontColorBlue = (int)rankFontColorBlue.Value;
        }

        /// <summary>
        /// ランクコンボボックス初期設定処理
        /// </summary>
        private void initRankComboBox()
        {
            string strRankKey = "";
            string strRankName = "";
            for (Rank.ENUM_RANK_TYPE ii = Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_START; ii < Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_END; ++ii)
            {
                switch (ii)
                {
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_ACE:
                        strRankKey = "RankNameAce";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R2:
                        strRankKey = "RankNameR2";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R3:
                        strRankKey = "RankNameR3";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R4:
                        strRankKey = "RankNameR4";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R5:
                        strRankKey = "RankNameR5";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R6:
                        strRankKey = "RankNameR6";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R7:
                        strRankKey = "RankNameR7";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R8:
                        strRankKey = "RankNameR8";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R9:
                        strRankKey = "RankNameR9";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_R10:
                        strRankKey = "RankNameR10";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_JACK:
                        strRankKey = "RankNameJack";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_QUEEN:
                        strRankKey = "RankNameQueen";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_KING:
                        strRankKey = "RankNameKing";
                        break;
                    case Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_JOKER:
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
                comboBoxRank.Items.Add(new Rank(strRankName, (int)ii));
            }
            comboBoxRank.DisplayMember = "RankViewName";
        }

        /// <summary>
        /// 背景初期設定
        /// </summary>
        private void iniBackGround()
        {
            // 画像表示領域初期設定
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;

            // BackGroundクラスオブジェクト生成
            m_background = new BackGround();
            m_background.BackGroundColorRed = (int)backgroundColorRed.Value;
            m_background.BackGroundColorGreen = (int)backgroundColorGreen.Value;
            m_background.BackGroundColorBlue = (int)backgroundColorBlue.Value;
        }

        /// <summary>
        /// メイン画面起動時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            //ランク描画用ブラシ生成
            makeRankSolidBrush();

            //背景描画用ブラシ生成
            makeBackGroundSolidBrush();

            pictureBox1.Image = getImage(0);
            pictureBox1.Refresh();
        }

        /// <summary>
        /// ランク描画用ブラシ生成
        /// </summary>
        private void makeRankSolidBrush()
        {
            if (m_fontBrush == null)
            {
                m_fontBrush = Brushes.Black;
            }
            else
            {
                m_fontBrush.Dispose();
                Color colorSolidBrush = Color.FromArgb(m_rank.RankFontColorRed, m_rank.RankFontColorGreen, m_rank.RankFontColorBlue);
                m_fontBrush = new SolidBrush(colorSolidBrush);
            }
        }

        /// <summary>
        /// 背景描画用ブラシ生成
        /// </summary>
        private void makeBackGroundSolidBrush()
        {
            if (m_backgroundBrush == null)
            {
                m_backgroundBrush = Brushes.White;
            }
            else
            {
                m_backgroundBrush.Dispose();
                Color colorSolidBrush = Color.FromArgb(m_background.BackGroundColorRed, m_background.BackGroundColorGreen, m_background.BackGroundColorBlue);
                m_backgroundBrush = new SolidBrush(colorSolidBrush);
            }
        }

        /// <summary>
        /// カード描画イメージ取得処理
        /// </summary>
        /// <param name="mode"></param>
        /// <returns></returns>
        private Bitmap getImage(int mode)
        {
            Bitmap newImage = null;
            Bitmap logoImage1 = null;
            Bitmap logoImage2 = null;
            Bitmap logoImage3 = null;
            Graphics graphics = null;
            Font fnt = null;

            int intModeScale = 1;
            int intFontSize = (int)m_rank.RankFontSize * 10;

            try
            {
                if (mode == 0 )
                {
                    intModeScale = 10;
                }

                // ロゴ取得
                string strLogoImagePath = m_picture.PicturePath;
                if (!string.IsNullOrEmpty(strLogoImagePath))
                {
                    logoImage1 = new Bitmap(strLogoImagePath);
                }

                // マーク取得
                string strMarkFileName = m_suit.SuitFileName;
                if (!string.IsNullOrEmpty(strMarkFileName))
                {
                    logoImage2 = new Bitmap(strMarkFileName);
                }

                // カード番号取得
                string strCardNumber = m_rank.RankViewName;
                if (!string.IsNullOrEmpty(strCardNumber))
                {
                    string strFontName = m_rank.RankFontName;
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
                graphics.FillRectangle(m_backgroundBrush, graphics.VisibleClipBounds);
                graphics.DrawRectangle(Pens.Black, 0, 0, intCardWidth-1, intCardHeight-1);

                // 背景取得
                string strBackGroundImagePath = m_background.BackgroundPath;
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
                decimal decMarkScale = m_suit.SuitSize;
                decMarkScale = decMarkScale / intModeScale;

                int intMarkWidth = 0;
                int intMarkHeight = 0;
                if (logoImage2 != null)
                {
                    intMarkWidth = (int)(logoImage2.Width * decMarkScale);
                    intMarkHeight = (int)(logoImage2.Height * decMarkScale);
                }

                double intLogoScale = 0;
                switch (strCardNumber)
                {
                    case "A":
                        intLogoScale = (double)m_picture.PictureSizeA;
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
                        intLogoScale = (double)m_picture.PictureSizeN;
                        break;

                    case "J":
                    case "Q":
                    case "K":
                        intLogoScale = (double)m_picture.PictureSizeX;
                        break;

                    default:
                        intLogoScale = (double)m_picture.PictureSizeA;
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
                        int intMarkOffsetX = (int)m_suit.SuitLeftSpace * 10;
                        int intMarkOffsetY = (int)m_suit.SuitTopSpace * 10;
                        graphics.DrawImage(logoImage2, intMarkOffsetX / intModeScale, intMarkOffsetY / intModeScale, intMarkWidth, intMarkHeight);
                    }

                    // カード番号描画
                    if (!string.IsNullOrEmpty(strCardNumber))
                    {
                        int intCardNumberOffsetX1 = (int)m_rank.RankLeftSpace1 * 10;
                        int intCardNumberOffsetX2 = (int)m_rank.RankLeftSpace2 * 10;
                        int intCardNumberOffsetX3 = (int)m_rank.RankLeftSpace3 * 10;
                        int intCardNumberOffsetY = (int)m_rank.RankTopSpace * 10;

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

                            case "A":
                            case "J":
                            case "Q":
                            case "K":
                                graphics.DrawString(strCardNumber, fnt, m_fontBrush, intCardNumberOffsetX3 / intModeScale, intCardNumberOffsetY / intModeScale);
                                break;

                            default:
                                StringFormat sf = new StringFormat();
                                if (!string.IsNullOrEmpty(m_rank.RankFontName) && m_rank.RankFontName[0] == '@')
                                {
                                    sf.FormatFlags = StringFormatFlags.DirectionVertical;
                                }
                                graphics.DrawString(strCardNumber, fnt, m_fontBrush, intCardNumberOffsetX3 / intModeScale, intCardNumberOffsetY / intModeScale, sf);
                                break;
                        }
                    }

                    // ロゴ描画
                    if (!string.IsNullOrEmpty(strLogoImagePath))
                    {
                        int intMarkOffsetX1 = (int)m_picture.PictureOffsetX1 * 10;
                        int intMarkOffsetX2 = (int)m_picture.PictureOffsetX2 * 10;
                        int intMarkOffsetY1 = (int)m_picture.PictureOffsetY1 * 10;
                        int intMarkOffsetY2 = (int)m_picture.PictureOffsetY2 * 10;
                        int intMarkOffsetY3 = (int)m_picture.PictureOffsetY3 * 10;
                        int intMarkOffsetY4 = (int)m_picture.PictureOffsetY4 * 10;

                        if (mode == 0)
                        {
                            intMarkOffsetX1 = intMarkOffsetX1 / intModeScale;
                            intMarkOffsetX2 = intMarkOffsetX2 / intModeScale;
                            intMarkOffsetY1 = intMarkOffsetY1 / intModeScale;
                            intMarkOffsetY2 = intMarkOffsetY2 / intModeScale;
                            intMarkOffsetY3 = intMarkOffsetY3 / intModeScale;
                            intMarkOffsetY4 = intMarkOffsetY4 / intModeScale;
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
                                    image1_h - intMarkOffsetY1 - intMarkOffsetY2 - intMarkOffsetY4,
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
                                    image1_h - intMarkOffsetY1 - intMarkOffsetY2,
                                    intLogoWidth,
                                    intLogoHeight);
                                // 右上部
                                graphics.DrawImage(logoImage1,
                                    image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                    image2_h - intMarkOffsetY1 - intMarkOffsetY2,
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
                                    image2_h + image2_h / 2 - intMarkOffsetY1 - intMarkOffsetY4,
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
                                    image1_h - intMarkOffsetY1 - intMarkOffsetY2,
                                    intLogoWidth,
                                    intLogoHeight);
                                graphics.DrawImage(logoImage1,
                                    image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                    image2_h - intMarkOffsetY1 - intMarkOffsetY2,
                                    intLogoWidth,
                                    intLogoHeight);
                                graphics.DrawImage(logoImage1,
                                    image1_w + intMarkOffsetX1 - intMarkOffsetX2,
                                    image1_h + image1_h - intMarkOffsetY1 - intMarkOffsetY3,
                                    intLogoWidth,
                                    intLogoHeight);
                                graphics.DrawImage(logoImage1,
                                    image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                    image2_h + image2_h - intMarkOffsetY1 - intMarkOffsetY3,
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
                                    image2_h + intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY4,
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
                                        newImage.Height / 2 - intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY4,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;

                                case "J":
                                case "Q":
                                case "K":
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        newImage.Height / 2 - intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY4,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;

                                case "3":
                                case "5":
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        newImage.Height / 2 - intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY3 - intMarkOffsetY4,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;

                                case "9":
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        newImage.Height / 2 - intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY4,
                                        intLogoWidth,
                                        intLogoHeight);
                                    break;

                                case "2":
                                case "4":
                                case "6":
                                case "7":
                                case "8":
                                case "10":
                                    break;

                                default:
                                    graphics.DrawImage(logoImage1,
                                        newImage.Width / 2 - intLogoWidth / 2 + intMarkOffsetX1,
                                        newImage.Height / 2 - intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY4,
                                        intLogoWidth,
                                        intLogoHeight);
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
                                        newImage.Height / 2 - intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY3, 
                                        intLogoWidth, 
                                        intLogoHeight);
                                    graphics.DrawImage(logoImage1,
                                        image2_w + intMarkOffsetX1 + intMarkOffsetX2,
                                        newImage.Height / 2 - intLogoHeight / 2 - intMarkOffsetY1 - intMarkOffsetY3, 
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
                                        image2_h + image2_h / 2 - intMarkOffsetY1 - intMarkOffsetY4,
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

        /// <summary>
        /// 再描画処理
        /// </summary>
        private void redraw()
        {
            if (pictureBox1.Image != null)
            {
                pictureBox1.Image.Dispose();
            }
            pictureBox1.Image = getImage(0);
            pictureBox1.Refresh();
        }

        /// <summary>
        /// 絵柄選択ボタン押下時処理
        /// </summary>
        /// <param name="sender">絵柄選択ボタン</param>
        /// <param name="e"></param>
        private void selectPictureButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:

                    string strFilePath = openFileDialog1.FileName;
                    m_picture.PicturePath = strFilePath;
                    redraw();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 背景選択ボタン押下時処理
        /// </summary>
        /// <param name="sender">背景選択ボタン</param>
        /// <param name="e"></param>
        private void selectBackgroundImageButton_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:

                    string strFilePath = openFileDialog1.FileName;
                    m_background.BackgroundPath = strFilePath;
                    redraw();
                    break;

                default:
                    break;
            }
        }

        
        /// <summary>
        /// カードイメージ保存ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveCardImage_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:

                    string strSavePath = saveFileDialog1.FileName;
                    if (pictureBox1.Image != null)
                    {
                        pictureBox1.Image.Dispose();
                    }
                    Bitmap newImage = getImage(1);
                    newImage.Save(strSavePath, System.Drawing.Imaging.ImageFormat.Png);
                    newImage.Dispose();
                    break;

                default:
                    break;
            }
        }
 
        /// <summary>
        /// フォント選択ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectFontButton_Click(object sender, EventArgs e)
        {
            fontDialog1.Font = new Font(rankFontName.Text, (int)rankFontSize.Value);
            fontDialog1.MaxSize = 1000;

            DialogResult result = fontDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:

                    if ( fontDialog1.Font.GdiVerticalFont )
                    {
                        m_rank.RankFontName = "@";
                    }
                    else
                    {
                        m_rank.RankFontName = "";
                    }
                    m_rank.RankFontName += fontDialog1.Font.Name;
                    rankFontName.Text = m_rank.RankFontName;
                    redraw();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 文字色選択ボタン押下時処理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectFontColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:

                    rankFontColorRed.Value = colorDialog1.Color.R;
                    rankFontColorGreen.Value = colorDialog1.Color.G;
                    rankFontColorBlue.Value = colorDialog1.Color.B;

                    m_rank.RankFontColorRed = colorDialog1.Color.R;
                    m_rank.RankFontColorGreen = colorDialog1.Color.G;
                    m_rank.RankFontColorBlue = colorDialog1.Color.B;

                    makeRankSolidBrush();
                    redraw();
                    break;

                default:
                    break;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxSuit_SelectedIndexChanged(object sender, EventArgs e)
        {
            Suit suit = (Suit)comboBoxSuit.SelectedItem;
            if (suit.SuitType == (int)Suit.ENUM_SUIT_TYPE .ENUM_SUIT_TYPE_JOKER )
            {
                if (comboBoxRank.SelectedIndex != (int)Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_JOKER)
                {
                    comboBoxRank.SelectedIndex = (int)Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_JOKER;
                }
            }
            else
            {
                if (comboBoxRank.SelectedIndex == (int)Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_JOKER)
                {
                    comboBoxRank.SelectedIndex = (int)Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_START;
                }
            }
            m_suit.SuitType = suit.SuitType;
            m_suit.SuitViewName = suit.SuitViewName;
            m_suit.SuitFileName = suit.SuitFileName;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suitSize_ValueChanged(object sender, EventArgs e)
        {
            m_suit.SuitSize = suitSize.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suitLeftSpace_ValueChanged(object sender, EventArgs e)
        {
            m_suit.SuitLeftSpace = suitLeftSpace.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void suitTopSpace_ValueChanged(object sender, EventArgs e)
        {
            m_suit.SuitTopSpace = suitTopSpace.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureSizeA_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureSizeA = pictureSizeA.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureSizeN_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureSizeN = pictureSizeN.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureSizeX_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureSizeX = pictureSizeX.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureOffsetX1_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureOffsetX1 = pictureOffsetX1.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureOffsetX2_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureOffsetX2 = pictureOffsetX2.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureOffsetY1_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureOffsetY1 = pictureOffsetY1.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureOffsetY2_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureOffsetY2 = pictureOffsetY2.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureOffsetY3_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureOffsetY3 = pictureOffsetY3.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureOffsetY4_ValueChanged(object sender, EventArgs e)
        {
            m_picture.PictureOffsetY4 = pictureOffsetY4.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxRank_SelectedIndexChanged(object sender, EventArgs e)
        {
            Rank rank = (Rank)comboBoxRank.SelectedItem;
            if (rank.RankType == (int)Rank.ENUM_RANK_TYPE.ENUM_RANK_TYPE_JOKER)
            {
                if (comboBoxSuit.SelectedIndex != (int)Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_JOKER)
                {
                    comboBoxSuit.SelectedIndex = (int)Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_JOKER;
                }
            }
            else
            {
                if (comboBoxSuit.SelectedIndex == (int)Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_JOKER)
                {
                    comboBoxSuit.SelectedIndex = (int)Suit.ENUM_SUIT_TYPE.ENUM_SUIT_TYPE_START;
                }
            }
            m_rank.RankType = rank.RankType;
            m_rank.RankViewName = rank.RankViewName;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankFontSize_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankFontSize = rankFontSize.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankLeftSpace1_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankLeftSpace1 = rankLeftSpace1.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankLeftSpace2_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankLeftSpace2 = rankLeftSpace2.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankLeftSpace3_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankLeftSpace3 = rankLeftSpace3.Value;
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankTopSpace_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankTopSpace = rankTopSpace.Value;
            redraw();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankFontColorRed_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankFontColorRed = (int)rankFontColorRed.Value;
            makeRankSolidBrush();
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankFontColorG_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankFontColorGreen = (int)rankFontColorGreen.Value;
            makeRankSolidBrush();
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rankFontColorB_ValueChanged(object sender, EventArgs e)
        {
            m_rank.RankFontColorBlue = (int)rankFontColorBlue.Value;
            makeRankSolidBrush();
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundColorRed_ValueChanged(object sender, EventArgs e)
        {
            m_background.BackGroundColorRed = (int)backgroundColorRed.Value;
            makeBackGroundSolidBrush();
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundColorGreen_ValueChanged(object sender, EventArgs e)
        {
            m_background.BackGroundColorGreen = (int)backgroundColorGreen.Value;
            makeBackGroundSolidBrush();
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundColorBlue_ValueChanged(object sender, EventArgs e)
        {
            m_background.BackGroundColorBlue = (int)backgroundColorBlue.Value;
            makeBackGroundSolidBrush();
            redraw();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selectBackGroundColorButton_Click(object sender, EventArgs e)
        {
            DialogResult result = colorDialog1.ShowDialog();
            switch (result)
            {
                case DialogResult.OK:

                    if (m_backgroundBrush != null)
                    {
                        m_backgroundBrush.Dispose();
                    }
                    m_backgroundBrush = new SolidBrush(colorDialog1.Color);

                    backgroundColorRed.Value = colorDialog1.Color.R;
                    backgroundColorGreen.Value = colorDialog1.Color.G;
                    backgroundColorBlue.Value = colorDialog1.Color.B;

                    m_background.BackGroundColorRed = colorDialog1.Color.R;
                    m_background.BackGroundColorGreen = colorDialog1.Color.G;
                    m_background.BackGroundColorBlue = colorDialog1.Color.B;

                    redraw();
                    break;

                default:
                    break;
            }
        }
    }
}
