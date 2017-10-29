using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MusicPlayer
{

    public partial class LRCSEARCHFORM : Form
    {
        delegate string DownloadLrc(string url, string path);

        public string LrcPath { get; private set; }

        public EventHandler UseLrc;
        DataTable dt_LrcSearchResult = new DataTable();

        string _artist = "";
        string _album = "";
        string _title = "";
        string _filepath = "";
        string _dirpath = "";

        public LRCSEARCHFORM(DataRow dr)
        {
            InitializeComponent();

            _artist = dr["Artist"].ToString();
            _album = dr["Album"].ToString();
            _title = dr["Title"].ToString();
            _filepath = dr["FilePath"].ToString();
            _dirpath = _filepath.Substring(0, _filepath.LastIndexOf("\\") + 1);

            txt_Artist.Text = _artist;
            txt_Title.Text = _title;

            dt_LrcSearchResult.Columns.Add("Index");
            dt_LrcSearchResult.Columns.Add("Artist");
            dt_LrcSearchResult.Columns.Add("Title");
            dt_LrcSearchResult.Columns.Add("PreviewLrc");
            dt_LrcSearchResult.Columns.Add("UseLrc");
            dt_LrcSearchResult.Columns.Add("LrcUrl");

            //dgv_LrcSearchResult.DataSource = dt_LrcSearchResult;
        }


        private void btn_LrcSeach_Click(object sender, EventArgs e)
        {

            if ((txt_Title.Text == "") && (txt_Artist.Text == ""))
                return;

            if (dt_LrcSearchResult.Rows.Count > 0)
                dt_LrcSearchResult.Rows.Clear();

            BackgroundWorker findollrc = new BackgroundWorker();
            findollrc.WorkerReportsProgress = true;
            findollrc.WorkerSupportsCancellation = true;
            findollrc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_SearchOnlineLrc_DoWork);
            findollrc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_AddFileProcess_ProgressChanged);
            findollrc.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.bgw_SearchOnlineLrc_RunWorkerCompleted);

            string[] arg = new string[] {txt_Title.Text, txt_Artist.Text};

            this.Cursor = Cursors.WaitCursor;
            dgv_LrcSearchResult.DataSource = dt_LrcSearchResult.Clone();
            findollrc.RunWorkerAsync(arg);
            //findollrc.RunWorkerAsync(CurrentPlayingInfo);

           // SearchOnlineLrc(txt_Artist.Text, txt_Title.Text);
            
        }

        /// <summary>
        /// 搜索LRC
        /// </summary>
        /// <param name="artist">歌手名</param>
        /// <param name="title">歌名</param>
        /// <returns></returns>
        private int SearchOnlineLrc(string artist, string title)
        {
            string artistinfo = HttpUtility.UrlEncode(artist);
            string titleinfo = HttpUtility.UrlEncode(title);
            string url1 = "";

            if (artistinfo == "" && titleinfo != "")
                url1 = "http://geci.me/api/lyric/" + (titleinfo).Replace("+", "%20");

            else if (artistinfo != "" && titleinfo != "")
                url1 = "http://geci.me/api/lyric/" + (titleinfo + "/" + artistinfo).Replace("+", "%20");

            else if (artistinfo == "" && titleinfo == "")
            {
                MessageBox.Show("至少给个歌名吧！");
                return 0;
            }

            string res = "";
            try
            {
                res = Utilities.GetHttpResult(url1, "", "utf-8");
            }
            catch (Exception ex)
            {

                toolStripStatusLabel1.Text = ex.Message.ToString();
            }
            

            LrcJson lrcjson = Newtonsoft.Json.JsonConvert.DeserializeObject<LrcJson>(res.Substring(1));
            if (lrcjson.count > 0)
            {
                //dgv_LrcSearchResult.DataSource = dt_LrcSearchResult.Clone();
                for (int i = 0; i < lrcjson.count; i++)
                {
                    string url2 = "http://gecimi.com/api/artist/" + lrcjson.result[i].artist_id;
                    string result = "";
                    try
                    {
                        result = Utilities.GetHttpResult(url2, "", "utf-8");
                    }
                    catch (Exception ex)
                    {

                        toolStripStatusLabel1.Text = ex.Message.ToString();
                    }
                    

                    ArtistNameJson artistnamejson = Newtonsoft.Json.JsonConvert.DeserializeObject<ArtistNameJson>(result.Substring(1));
                    if (artistnamejson.count > 0)
                    {
                        DataRow dr = dt_LrcSearchResult.NewRow();

                        dr[0] = (i + 1).ToString();
                        dr[1] = artistnamejson.result.name.ToString();
                        dr[2] = lrcjson.result[i].song.ToString();
                        dr[3] = "预览歌词";
                        dr[4] = "使用歌词";
                        dr[5] = lrcjson.result[i].lrc.ToString();

                        dt_LrcSearchResult.Rows.Add(dr);
                    }
                }

                //dgv_LrcSearchResult.DataSource = dt_LrcSearchResult;

                return lrcjson.count;
                //toolStripStatusLabel1.Text = "找到" + lrcjson.count.ToString().ToString() + "个符合条件的歌词";
            }
            else
                return 0;
        }

        /// <summary>
        /// 搜索结果DGV事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_LrcSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //预览歌词按钮
            if(e.ColumnIndex == 3 && e.RowIndex > -1)
            {
                textBox1.Text = Utilities.GetHttpResult(dt_LrcSearchResult.Rows[e.RowIndex]["LrcUrl"].ToString(), "", "utf-8");
            }
            //使用歌词按钮
            else if (e.ColumnIndex == 4 && e.RowIndex > -1)
            {
                if(UseLrc != null)
                {
                    string lrcurl = dt_LrcSearchResult.Rows[e.RowIndex]["LrcUrl"].ToString();
                    try
                    {
                        //保存文件时需进行文件名合法性检测或者在导入目录或者导入歌曲时检测 歌手名 专辑名 歌名等可能作为文件名的字段
                        string lrcpath = _dirpath + _artist + " - " + _title + ".lrc";
                        if(File.Exists(lrcpath) == true)
                        {
                            File.Delete(lrcpath);
                        }
                        DownloadLrc downloadlrc = new DownloadLrc(Utilities.HttpDownloadFile);

                        IAsyncResult result = downloadlrc.BeginInvoke(lrcurl, _dirpath + _artist + " - " + _title + ".lrc", null, null);
                        LrcPath = downloadlrc.EndInvoke(result);
                        //LrcPath = Utilities.HttpDownloadFile(lrcurl, _dirpath + _artist + " - " + _title + ".lrc");
                    }
                    catch (Exception ex)
                    {
                        this.toolStripStatusLabel1.Text = ex.Message.ToString();
                    }

                    if(LrcPath != null)
                        UseLrc(this, e);
                }
            }
        }

        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LrcSeachForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //wb_LrcPreview.Dispose();
        }

        /// <summary>
        /// 获取编码适配的HTML文件
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        private static string GetHTMLbyWebRequest(string url)
        {
            //获取输入的URL
            var request = (HttpWebRequest)WebRequest.Create(url);  //HTTP请求
            var response = (HttpWebResponse)request.GetResponse(); //HTTP应答
            Encoding encoding = System.Text.Encoding.Default;      //当前字符编码方式
                                                                   //响应状态为OK
            if (response.StatusDescription.ToUpper() == "OK")        //大写
            {
                //设置获取链接中网页的编码格式
                switch (response.CharacterSet.ToLower())           //小写
                {
                    case "gbk":
                        encoding = Encoding.GetEncoding("GBK");
                        break;
                    case "gb2312":
                        encoding = Encoding.GetEncoding("GB2312");
                        break;
                    case "utf-8":
                        encoding = Encoding.UTF8;
                        break;
                    case "iso-8859-1":
                        encoding = Encoding.GetEncoding("GBK");    //GB2312              
                        break;
                    case "big5":
                        encoding = Encoding.GetEncoding("Big5");
                        break;
                    default:
                        encoding = Encoding.UTF8;
                        break;
                }
                //流操作               
                Stream stream = response.GetResponseStream();
                StreamReader sr = new StreamReader(stream, encoding);
                string content = sr.ReadToEnd();
                File.WriteAllText("1.html", content, Encoding.UTF8);
                //关闭释放资源
                stream.Close();
                sr.Close();
                response.Close();
                return content;
            }
            else
            {
                MessageBox.Show("响应失败!");
                return string.Empty;
            }
        }

        /// <summary>
        /// 歌词搜索
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_SearchOnlineLrc_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] info = e.Argument as string[];
            BackgroundWorker bgw = sender as BackgroundWorker;

            int lrccount = SearchOnlineLrc(info[1], info[0]);

                bgw.ReportProgress(lrccount);



        }

        /// <summary>
        /// 歌词搜索更新进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AddFileProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            toolStripStatusLabel1.Text = "共找到" + e.ProgressPercentage.ToString() + "个符合要求的歌词";
        }

        /// <summary>
        /// 歌词搜索完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_SearchOnlineLrc_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Cursor = Cursors.Default;
            //dgv_LrcSearchResult.DataSource = dt_LrcSearchResult.Clone();
            dgv_LrcSearchResult.DataSource = dt_LrcSearchResult;
        }

        
    }
}
