using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace MusicPlayer
{
    public partial class COVERSEARCHFORM : Form
    {
        DataTable dt_CoverSearchResult = new DataTable();
        public EventHandler UseCover;

        public string CoverPath { get; private set; }

        string _artist = "";
        string _album = "";
        string _title = "";
        string _filepath = "";
        string _dirpath = "";

        public COVERSEARCHFORM(DataRow dr)
        {
            InitializeComponent();

            _artist = dr["Artist"].ToString();
            _album = dr["Album"].ToString();
            _title = dr["Title"].ToString();
            _filepath = dr["FilePath"].ToString();
            _dirpath = _filepath.Substring(0, _filepath.LastIndexOf("\\") + 1);

            txt_Album.Text = _album;
            txt_Artist.Text = _artist;
            //txt_Title.Text = _title;

            dt_CoverSearchResult.Columns.Add("Index");
            dt_CoverSearchResult.Columns.Add("Artist");
            dt_CoverSearchResult.Columns.Add("Album");
            dt_CoverSearchResult.Columns.Add("CoverPreview");
            dt_CoverSearchResult.Columns.Add("UseCover");
            dt_CoverSearchResult.Columns.Add("CoverUrl");

            dgv_CoverSearchResult.DataSource = dt_CoverSearchResult;
        }


        private void btn_CoverSearch_Click(object sender, EventArgs e)
        {

            if ((txt_Album.Text == "") && (txt_Artist.Text == ""))
                return;

            if (dt_CoverSearchResult.Rows.Count > 0)
                dt_CoverSearchResult.Rows.Clear();

            try
            {
                SearchOnlineLrc(txt_Artist.Text, txt_Album.Text);
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message.ToString();
            }
            Application.DoEvents();
        }


        private void SearchOnlineLrc(string artist, string album)
        {
            string postdata = "";

            string url1 = "http://coverbox.sinaapp.com/list";

            if (artist == "" && album != "")
            {
                postdata = "input=" + HttpUtility.UrlEncode(album);
            }
            else if (artist != "" && album == "")
            {
                postdata = "input=" + HttpUtility.UrlEncode(artist);
            }

            else if (artist != "" && album != "")
            {
                postdata = "input=" + HttpUtility.UrlEncode(artist + " " + album);
            }
            else
            {
                MessageBox.Show("请至少输入一个关键词");
                return;
            }

            toolStripStatusLabel1.Text = "正在搜索 ... ";
            this.Cursor = Cursors.WaitCursor;
            string res = Utilities.GetHttpResult(url1, postdata, "utf-8");
            if (res.Substring(res.IndexOf("\"resultCount\":") + 14, 1) != "0")
            {
                int start = res.IndexOf("resultCount") - 4;
                int end = res.IndexOf("}", res.LastIndexOf("]"));
                res = res.Substring(start, end - start + 4);

                CoverResultJson coverresult = Newtonsoft.Json.JsonConvert.DeserializeObject<CoverResultJson>(res);

                for (int i = 0; i < coverresult.resultCount; i++)
                {
                    coverresult.results[i].artworkUrl100 = coverresult.results[i].artworkUrl100.Replace("100x100bb", "600x600bb");
                }

                for (int i = 0; i < coverresult.resultCount; i++)
                {

                    DataRow dr = dt_CoverSearchResult.NewRow();

                    dr[0] = (i + 1).ToString();
                    dr[1] = coverresult.results[i].artistName.ToString();
                    dr[2] = coverresult.results[i].collectionName.ToString();
                    dr[3] = "预览封面";
                    dr[4] = "使用封面";
                    dr[5] = coverresult.results[i].artworkUrl100.ToString();

                    dt_CoverSearchResult.Rows.Add(dr);
                }
                toolStripStatusLabel1.Text = "找到" + coverresult.resultCount.ToString() + "个符合条件的专辑封面";
            }
            else
                toolStripStatusLabel1.Text = "未找到符合条件的专辑封面";

            this.Cursor = Cursors.Default;

        }


        private void dgv_CoverSearchResult_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                //预览专辑封面
                if (e.ColumnIndex == 3 && e.RowIndex > -1)
                {
                    wb_CoverPreview.Navigate(dt_CoverSearchResult.Rows[e.RowIndex]["CoverUrl"].ToString());

                    Application.DoEvents();
                }

                if (e.ColumnIndex == 4 && e.RowIndex > -1)
                {
                    //使用专辑封面
                    if (UseCover != null)
                    {
                        string coverurl = dt_CoverSearchResult.Rows[e.RowIndex]["CoverUrl"].ToString();
                        string coverformate = Path.GetExtension(coverurl);
                        try
                        {
                            // TODO PicBox占用此文件需要释放资源才能强制使用指定的专辑封面
                            string coverpath = _dirpath + _artist + " - " + _album + coverformate;
                            if (File.Exists(coverpath) == true)
                            {
                                File.Delete(coverpath);
                            }

                            // TODO 保存文件时需进行文件名合法性检测或者在导入目录或者导入歌曲时检测 歌手名 专辑名 歌名等可能作为文件名的字段
                            CoverPath = Utilities.HttpDownloadFile(coverurl, _dirpath + _artist + " - " + _album + coverformate);
                        }
                        catch (Exception ex)
                        {
                            this.toolStripStatusLabel1.Text = ex.Message.ToString();
                        }

                        if (CoverPath != null)
                            UseCover(this, e);
                    }
                }
            }
            catch (Exception ex)
            {
                toolStripStatusLabel1.Text = ex.Message.ToString();
                //dgv_CoverSearchResult.f
            }
        }


        private void CoverSearchForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            wb_CoverPreview.Dispose();
        }
    }
}
