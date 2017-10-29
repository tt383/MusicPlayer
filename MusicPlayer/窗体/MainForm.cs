using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Un4seen.Bass;
using Un4seen.Bass.Misc;
using Un4seen.Bass.AddOn.Tags;
using Un4seen.Bass.AddOn.Flac;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Web;
using System.Threading;
using FlacLibSharp;
using AlphaUtils;

namespace MusicPlayer
{
    #region 主窗口

    public partial class form_Main : Form
    {

        #region 变量定义
        private BassPlayer Player = new BassPlayer();
        private DataSet ds_MusicLib = new DataSet();
        private LrcDt Lrc = new LrcDt();
        private bool bIsLrcValid = false;
        private int CurrentLrcIndex = 0;
        private bool bIsLrcTunning = false;
        private volatile bool bIsScrolling = false;

        //AlphaTextBox a

        COVERSEARCHFORM CoverSearchForm;
        LRCSEARCHFORM LrcSearchForm;
        ADDFILEPROCESSFORM AddFlieProcessForm;

        string SelectedPlaylistName = "";

        SONGINFO CurrentPlayingInfo = new SONGINFO();

        // 可视化相关变量
        private int specIdx = 8;
        private int voicePrintIdx = 0;
        private Visuals _vis = new Visuals(); // visuals class instance

        // 定时器分频
        private int _tickCounter = 0;

        // 需要保存的设置项
        private string CurrentPlayListName = "";
        private int CurrentPlayIndex = 0;
        private LOOPMODE LoopMode = LOOPMODE.ORDER;
        private List<string> LrcSeachPaths = new List<string>();


        // 下一个播放内容
        private enum WHAT2PLAY
        {
            PREVIOUS,
            CURRENT,
            NEXT
        }

        // 歌词载入结果
        private enum LRCLOADRESULT
        {
            OK,
            LRCINVALID,
            NOTFOUND
        }

        // 循环模式
        private enum LOOPMODE
        {
            ORDER,
            SINGLE,
            RANDOM
        }

        // 歌曲信息
        public struct SONGINFO
        {
            public string title;
            public string artist;
            public string album;
            public string filepath;
            public string dirpath;
            public string lrcpath;
            public string coverpath;

            public SONGINFO(string a, string b, string c, string d, string e, string f, string g)
            {
                title = a;
                artist = b;
                album = c;
                filepath = d;
                dirpath = e;
                lrcpath = f;
                coverpath = g;
            }
        }


        #endregion

        #region 窗体控件事件

        /// <summary>
        /// 初始化数据及界面
        /// </summary>
        public form_Main()
        {
            InitializeComponent();

            #region 界面初始化

            ts_OpenLrcPlane.Text = "隐藏歌词面板";
            ts_OpenLrcPlane.Checked = true;



            ToolTip toolTipVisual = new ToolTip();
            toolTipVisual.AutoPopDelay = 5000; toolTipVisual.InitialDelay = 500; toolTipVisual.ReshowDelay = 500;
            toolTipVisual.ShowAlways = true;
            toolTipVisual.SetToolTip(this.pictureBox1, "单击更换可视化");


            //FindOnlineAlbumCover("陈奕迅", "2013 陳奕迅 Music Life 精選");
            //LrcSeach.Show();
            //CoverSeach.Show();

            #endregion

            #region 数据初始化

            //载入默认音乐库
            if (File.Exists("MyMusicLib.xml") == true)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load("MyMusicLib.xml");
                DataSet ds = new DataSet();
                ds = Utilities.GetDSFormXmlDoc(xml);
                if (ds.Tables.Count > 0)
                {
                    //tc_MusicLib.TabPages.RemoveAt(0);
                    foreach (DataTable dt_t in ds.Tables)
                    {
                        CreatPlaylist(dt_t.TableName);
                        foreach (DataRow dr in dt_t.Rows)
                            ds_MusicLib.Tables[dt_t.TableName].Rows.Add(dr.ItemArray);
                    }
                    CurrentPlayListName = ds_MusicLib.Tables[0].TableName;

                    CreatPlaylist("+");
                    //tc_Music

                    //SendLog("找到默认音乐库，已加载", "Asnc");
                }
                else
                {
                    File.Delete("MyMusicLib.xml");
                    //tc_MusicLib.TabPages.RemoveAt(0);
                    CreatPlaylist("默认播放列表");
                    CreatPlaylist("  +");
                    CurrentPlayListName = tc_MusicLib.TabPages[0].Name;
                }
            }

            else
            {
                //tc_MusicLib.TabPages.RemoveAt(0);
                CreatPlaylist("默认播放列表");
                CreatPlaylist("  +");
                CurrentPlayListName = tc_MusicLib.TabPages[0].Name;
                //SendLog("未找到默认音乐库，创建 默认播放列表", "Asnc");
            }

            // 默认循环模式 顺序循环
            LoopMode = LOOPMODE.ORDER;

            tc_MusicLib.TabPages[0].Select();
            SelectedPlaylistName = tc_MusicLib.TabPages[0].Name;
            #endregion

        }

        /// <summary>
        /// 下一曲鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Next_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Next.Image = Image.FromFile(@"../../Images/NxtPressed.png");
        }

        /// <summary>
        /// 下一曲鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Next_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Next.Image = Image.FromFile(@"../../Images/Nxt.png");
        }

        /// <summary>
        /// 上一曲鼠标按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Previous_MouseDown(object sender, MouseEventArgs e)
        {
            btn_Previous.Image = Image.FromFile(@"../../Images/PrvPressed.png");
        }

        /// <summary>
        /// 上一曲鼠标抬起事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Previous_MouseUp(object sender, MouseEventArgs e)
        {
            btn_Previous.Image = Image.FromFile(@"../../Images/Prv.png");
        }

        /// <summary>
        /// 循环模式菜单顺序循环点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_LoopModeOrder_Click(object sender, EventArgs e)
        {
            LoopMode = LOOPMODE.ORDER;
            tsm_LoopModeOrder.Checked = true;
            tsm_LoopModeRandom.Checked = false;
            tsm_LoopModeSingle.Checked = false;
            tsm_DropDownButtonLoopMode.Text = "顺序循环";
            SendLog("切换为 顺序循环 模式", "Asnc");
        }

        /// <summary>
        /// 循环模式菜单单曲循环点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_LoopModeSingle_Click(object sender, EventArgs e)
        {
            LoopMode = LOOPMODE.SINGLE;
            tsm_LoopModeSingle.Checked = true;
            tsm_LoopModeOrder.Checked = false;
            tsm_LoopModeRandom.Checked = false;
            tsm_DropDownButtonLoopMode.Text = "单曲循环";
            SendLog("切换为 单曲循环 模式", "Asnc");
        }

        /// <summary>
        /// 循环模式菜单随机循环点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_LoopModeRandom_Click(object sender, EventArgs e)
        {
            LoopMode = LOOPMODE.RANDOM;
            tsm_LoopModeRandom.Checked = true;
            tsm_LoopModeSingle.Checked = false;
            tsm_LoopModeOrder.Checked = false;
            tsm_DropDownButtonLoopMode.Text = "随机循环";
            SendLog("切换为 随机循环 模式", "Asnc");
        }

        #endregion

        #region 播放相关操作

        /// <summary>
        /// 进度条滚动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING)
            {
                if (e.Type == ScrollEventType.ThumbTrack)
                {
                    bIsScrolling = true;
                }
                else if (e.Type == ScrollEventType.EndScroll)
                {
                    //设置歌曲播放位置
                    if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING)
                        Player.SetPostion(hsb_PlayProcessBar.Value);
                    SendLog("设置播放位置到 " + hsb_PlayProcessBar.Value.ToString() + " 秒", "Asnc");

                    //同步歌词显示位置
                    SyncLrc();
                }
                else
                    bIsScrolling = false;
            }
            else
                hsb_PlayProcessBar.Value = 0;

        }

        /// <summary>
        /// 停止按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Stop_Click(object sender, EventArgs e)
        {
            btn_Play.Image = Image.FromFile(@"../../Images/Play.png");
            btn_Pause.Image = Image.FromFile(@"../../Images/Pause.png");
            btn_Stop.Image = Image.FromFile(@"../../Images/StopPressed.png");
            Player.Stop();
            tmr_Tick.Stop();
            this.Text = "MusicPalyer";
        }

        /// <summary>
        /// 下一曲按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Next_Click(object sender, EventArgs e)
        {
            btn_Play.Image = Image.FromFile(@"../../Images/PlayPressed.png");
            btn_Pause.Image = Image.FromFile(@"../../Images/Pause.png");
            btn_Stop.Image = Image.FromFile(@"../../Images/Stop.png");
            Play(WHAT2PLAY.NEXT);
        }

        /// <summary>
        /// 上一曲按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Previous_Click(object sender, EventArgs e)
        {
            btn_Play.Image = Image.FromFile(@"../../Images/PlayPressed.png");
            btn_Pause.Image = Image.FromFile(@"../../Images/Pause.png");
            btn_Stop.Image = Image.FromFile(@"../../Images/Stop.png");
            Play(WHAT2PLAY.PREVIOUS);
        }

        /// <summary>
        /// 暂停按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Pause_Click(object sender, EventArgs e)
        {
            if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING)
            {
                Player.Pause();
                btn_Play.Image = Image.FromFile(@"../../Images/Play.png");
                btn_Pause.Image = Image.FromFile(@"../../Images/PausePressed.png");
                btn_Stop.Image = Image.FromFile(@"../../Images/Stop.png");
                tmr_Tick.Stop();
                this.Text = "‖  " + ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Title"] + " - " + (int)(Player.ElapsedTime / Player.TotalTime * 100) + "%";
            }
            else
                return;
        }

        /// <summary>
        /// 播放按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Play_Click(object sender, EventArgs e)
        {

            btn_Play.Image = Image.FromFile(@"../../Images/PlayPressed.png");
            btn_Pause.Image = Image.FromFile(@"../../Images/Pause.png");
            btn_Stop.Image = Image.FromFile(@"../../Images/Stop.png");

            if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_STOPPED)
            {
                Play(WHAT2PLAY.CURRENT);

            }
            else if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED)
            {
                Player.Resume();

                tmr_Tick.Start();
            }
            else
                return;
        }

        /// <summary>
        /// 播放下一曲
        /// </summary>
        private void Play(WHAT2PLAY w2p)
        {
            //停止定时器
            tmr_Tick.Stop();
            Player.Stop();

            bIsLrcValid = false;
            btn_LrcAdj.Enabled = false;
            btn_LrcAdj.Text = "调整歌词";
            btn_LrcAhead.Enabled = false;
            btn_LrcDelay.Enabled = false;
            btn_LrcSave.Enabled = false;
            btn_LrcAdj.Enabled = false;
            hsb_PlayProcessBar.Value = 0;
            combox_LrcMoveTime.Enabled = false;
            txtbox_LrcCurrent.Text = "";
            txtbox_LrcLast.Text = "";
            txtbox_LrcNext.Text = "";

            CurrentPlayingInfo.title = "";
            CurrentPlayingInfo.album = "";
            CurrentPlayingInfo.filepath = "";
            CurrentPlayingInfo.artist = "";
            CurrentPlayingInfo.dirpath = "";
            CurrentPlayingInfo.lrcpath = "";
            CurrentPlayingInfo.coverpath = "";

            if (picBox_AlbumCover.Image != null)
            {
                picBox_AlbumCover.Image.Dispose();
                picBox_AlbumCover.Image = null;
            }

            Begin:
            if (ds_MusicLib.Tables[CurrentPlayListName].Rows.Count > 0)
            {
                switch (w2p)
                {
                    case WHAT2PLAY.CURRENT:
                        break;
                    case WHAT2PLAY.NEXT:
                        {
                            switch (LoopMode)
                            {
                                case LOOPMODE.SINGLE:
                                    break;
                                case LOOPMODE.ORDER:
                                    if (CurrentPlayIndex < ds_MusicLib.Tables[CurrentPlayListName].Rows.Count - 1)
                                        CurrentPlayIndex += 1;
                                    else
                                        CurrentPlayIndex = 0;
                                    break;
                                case LOOPMODE.RANDOM:
                                    Random rd = new Random();
                                    CurrentPlayIndex = rd.Next(ds_MusicLib.Tables[CurrentPlayListName].Rows.Count);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case WHAT2PLAY.PREVIOUS:
                        {
                            switch (LoopMode)
                            {
                                case LOOPMODE.SINGLE:
                                    break;
                                case LOOPMODE.ORDER:
                                    if (CurrentPlayIndex <= 0)
                                        CurrentPlayIndex = ds_MusicLib.Tables[CurrentPlayListName].Rows.Count - 1;
                                    else
                                        CurrentPlayIndex -= 1;
                                    break;
                                case LOOPMODE.RANDOM:
                                    Random rd = new Random();
                                    CurrentPlayIndex = rd.Next(ds_MusicLib.Tables[CurrentPlayListName].Rows.Count);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }

                if (File.Exists(ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["FilePath"].ToString()) == true)
                {

                    CurrentPlayingInfo.title = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Title"].ToString();
                    CurrentPlayingInfo.album = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Album"].ToString();
                    CurrentPlayingInfo.filepath = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["FilePath"].ToString();
                    CurrentPlayingInfo.artist = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Artist"].ToString();
                    CurrentPlayingInfo.dirpath = CurrentPlayingInfo.filepath.Substring(0, CurrentPlayingInfo.filepath.LastIndexOf('\\') + 1);
                    CurrentPlayingInfo.lrcpath = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["LrcPath"].ToString(); ;
                    CurrentPlayingInfo.coverpath = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"].ToString();


                    if (Player.PlaySongs(CurrentPlayingInfo.filepath) == true)
                    {
                        SendLog("歌曲 " + CurrentPlayingInfo.title + " 有效，开始播放", "cur");

                        //更新播放列表选中状态
                        (tc_MusicLib.TabPages[CurrentPlayListName].Controls[0] as DataGridView).ClearSelection();
                        (tc_MusicLib.TabPages[CurrentPlayListName].Controls[0] as DataGridView).Rows[CurrentPlayIndex].Selected = true;

                        lab_SongLastTime.Text = (new TimeSpan(0, 0, (Convert.ToInt32(ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex][3])))).ToString("mmss").Insert(2, ":");
                        tsm_LabelChannalInfo.Text = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["ChannalInfo"].ToString();
                        hsb_PlayProcessBar.Maximum = Convert.ToInt32(ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex][3]);

                        tmr_Tick.Start();

                        //匹配专辑封面
                        if (CurrentPlayingInfo.coverpath != "")
                        {
                            DisplayAlbumCover(CurrentPlayingInfo.coverpath);
                        }
                        else
                        {
                            string localcoverpath = FindLocalAlbumCover(CurrentPlayingInfo);
                            if (localcoverpath == "")
                            {
                                SendLog("未找到 " + CurrentPlayingInfo.album + " 的本地 专辑封面", "cur");

                                string innercoverpath = GetInnerAlbumCover(CurrentPlayingInfo);
                                if (innercoverpath != "")
                                {
                                    DisplayAlbumCover(innercoverpath);
                                }
                                else
                                {
                                    SendLog("未找到 " + CurrentPlayingInfo.album + " 的 内置 专辑封面", "cur");

                                    BackgroundWorker findolcover = new BackgroundWorker();
                                    findolcover.WorkerReportsProgress = true;
                                    findolcover.WorkerSupportsCancellation = true;
                                    findolcover.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_GetOnlineAlbumCover_DoWork);
                                    findolcover.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_GetOnlineAlbumCover_ProgressChanged);

                                    findolcover.RunWorkerAsync(CurrentPlayingInfo);
                                }
                            }
                            else
                            {
                                DisplayAlbumCover(localcoverpath);
                                SendLog("找到 " + CurrentPlayingInfo.album + " 的 本地 专辑封面", "cur");
                            }
                        }


                        //匹配歌词
                        if (CurrentPlayingInfo.lrcpath != "")
                        {
                            LoadLrc(CurrentPlayingInfo.lrcpath);
                        }
                        else
                        {
                            LRCLOADRESULT res = LoadLocalLrc(CurrentPlayingInfo);
                            if (res != LRCLOADRESULT.OK)
                            {
                                BackgroundWorker findollrc = new BackgroundWorker();
                                findollrc.WorkerReportsProgress = true;
                                findollrc.WorkerSupportsCancellation = true;
                                findollrc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_GetOnlineLrc_DoWork);
                                findollrc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_GetOnlineLrc_ProgressChanged);

                                findollrc.RunWorkerAsync(CurrentPlayingInfo);
                            }
                        }
                    }
                    else
                    {
                        SendLog("解码器初始化失败", "cur");
                    }
                }
                else
                {
                    SendLog("歌曲 " + CurrentPlayingInfo.title + " 对应的文件不存在，已将其从播放列表中移除", "cur");
                    ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows.RemoveAt(CurrentPlayIndex);
                    if (MessageBox.Show(CurrentPlayingInfo.title + " 歌曲文件不存在，已将其从播放列表中移除,继续播放下一曲？", "移除不存在的歌曲", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        SendLog("继续播放下一曲", "cur");
                        goto Begin;
                    }
                }
            }
            else
            {
                MessageBox.Show("当前播放列表无可播放歌曲，请添加！");

                btn_Play.Image = Image.FromFile(@"../../Images/Play.png");
                btn_Pause.Image = Image.FromFile(@"../../Images/Pause.png");
                btn_Stop.Image = Image.FromFile(@"../../Images/Stop.png");

            }

        }

        #endregion

        #region 播放列表操作


        /// <summary>
        /// 播放列表排序事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayList_Sorted(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;

            string SortStr = dgv.SortedColumn.Name; //排序列 
            SortOrder So = dgv.SortOrder;            //排序方向 
            if (So == SortOrder.Ascending)
                SortStr += " asc";
            else
                SortStr += " desc";

            DataView dv = ds_MusicLib.Tables[tc_MusicLib.SelectedIndex].DefaultView;

            ds_MusicLib.Tables.Remove(tc_MusicLib.SelectedTab.Name);

            dgv.DataSource = dv.ToTable();

            ds_MusicLib.Tables.Add(dv.ToTable());


            //ds_MusicLib.Tables[tc_MusicLib.SelectedIndex]. = SortStr;  //将排序后的datatable赋给 dt 
        }

        /// <summary>
        /// 导出音乐库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_ExportMusicLib_Click(object sender, EventArgs e)
        {

            if (ds_MusicLib.Tables.Count > 0)
            {

                XmlDocument xml = new XmlDocument();
                xml = Utilities.GetXmlDocFormDS(ds_MusicLib);

                saveFileDialog.Filter = "Xml Files(*.xml)| *.xml | All Files(*.*) | *.* ";
                saveFileDialog.InitialDirectory = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xml.Save(saveFileDialog.FileName);
                    saveFileDialog.Reset();
                }
            }
            else
            {
                MessageBox.Show("当前音乐库为空！");
            }
        }

        /// <summary>
        /// 导入音乐库
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_ImportMusicLib_Click(object sender, EventArgs e)
        {

            openFileDialog.Filter = "Xml文件|*.xml";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlDocument xml = new XmlDocument();
                xml.Load(openFileDialog.FileName);
                DataSet ds = new DataSet();
                ds = Utilities.GetDSFormXmlDoc(xml);

                if (ds.Tables.Count > 0)
                {
                    for (int i = 0; i < ds.Tables.Count; i++)
                    {
                        foreach (DataTable item in ds_MusicLib.Tables)
                        {
                            if (item.TableName == ds.Tables[i].TableName)
                                ds.Tables[i].TableName = item.TableName + DateTime.Now.ToLongTimeString().ToString().Replace(":", "");
                        }
                    }

                    foreach (DataTable dt in ds.Tables)
                    {
                        CreatPlaylist(dt.TableName);
                        foreach (DataRow dr in dt.Rows)
                        {
                            ds_MusicLib.Tables[dt.TableName].Rows.Add(dr.ItemArray);
                        }
                    }

                    SendLog("已加载选中的音乐库", "Asnc");
                }
                else
                {
                    MessageBox.Show("所选音乐库无效");
                }
            }
        }

        /// <summary>
        /// 重命名当前播放列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_RenameCurrentPlaylist_Click(object sender, EventArgs e)
        {

            TAG_RenameCurrentPlaylist:
            string response = Microsoft.VisualBasic.Interaction.InputBox("请输入新的播放列表名称", "重命名播放列表", "", 0, 0);

            if (response == "")
                //输入为空
                //由于VB INPUTBOX 特性（关闭inputbox会返回一个空字符串），这里对空字符串不做处理
                return;

            foreach (DataTable dt in ds_MusicLib.Tables)
            {
                if (dt.TableName == response)
                {

                    if (MessageBox.Show("您输入的播放列表名称与现有音乐库中播放列表名称重复，重新输入请按确定", "播放列表重复", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        goto TAG_RenameCurrentPlaylist;
                    }
                    else
                        return;
                }
            }

            ds_MusicLib.Tables[tc_MusicLib.SelectedIndex].TableName = response;
            tc_MusicLib.SelectedTab.Name = response;
            tc_MusicLib.SelectedTab.Text = response;


        }

        /// <summary>
        /// 添加歌曲按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_AddSongs_Click(object sender, EventArgs e)
        {
            int SongAddedCount = 0;
            openFileDialog.Filter = "Audio Files(*.mp3;*.flac;*.ape)|*.mp3;*.flac;*.ape|All Files(*.*) |*.*";
            openFileDialog.Multiselect = true;
            if (DialogResult.OK == this.openFileDialog.ShowDialog(this))
            {

                if (openFileDialog.FileNames.Length > 10)
                {
                    if (AddFlieProcessForm == null || AddFlieProcessForm.IsDisposed == true)
                    {
                        AddFlieProcessForm = new ADDFILEPROCESSFORM(openFileDialog.FileNames.Length, StopAddingFlies);
                        //AddFlieProcessForm.PbValue = openFileDialog.FileNames.Rank;
                        AddFlieProcessForm.Show();
                        bgw_AddFileProcess.RunWorkerAsync(openFileDialog.FileNames);
                    }
                }
                else
                {
                    foreach (string filename in openFileDialog.FileNames)
                    {
                        if (File.Exists(filename))
                        {

                            TAG_INFO SongInfo = new TAG_INFO();
                            SongInfo = BassPlayer.GetSongInfo(filename);
                            if (SongInfo != null)
                            {
                                DataRow dr = ds_MusicLib.Tables[CurrentPlayListName].NewRow();

                                dr[0] = SongInfo.title.ToString();
                                dr[1] = SongInfo.artist.ToString();
                                TimeSpan TS = new TimeSpan(0, 0, ((int)(SongInfo.duration)) + 1);
                                dr[2] = SongInfo.album.ToString();
                                dr[3] = (int)(SongInfo.duration);
                                dr[4] = filename;
                                dr[5] = SongInfo.channelinfo.ToString() + " ," + SongInfo.bitrate.ToString() + "kbps";
                                dr[6] = "";
                                dr[7] = "";
                                dr[8] = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper();

                                ds_MusicLib.Tables[CurrentPlayListName].Rows.Add(dr);

                                SongAddedCount++;
                            }

                        }
                    }
                    SendLog("增加 " + SongAddedCount.ToString() + " 首歌曲", "req");
                }
            }
        }

        /// <summary>
        /// 添加文件夹按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_AddDir_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == this.AddDirDialog.ShowDialog(this))
            {
                //DirectoryInfo folder = new DirectoryInfo(AddDirDialog.SelectedPath);
                if (Directory.Exists(AddDirDialog.SelectedPath))
                {

                    if (AddFlieProcessForm == null || AddFlieProcessForm.IsDisposed == true)
                    {
                        AddFlieProcessForm = new ADDFILEPROCESSFORM(390, StopAddingFlies);
                        bgw_AddDirProcess.RunWorkerAsync(AddDirDialog.SelectedPath);
                        AddFlieProcessForm.ShowDialog();
                    }
                }


            }
        }

        /// <summary>
        /// 双击曲目按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Songs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                CurrentPlayListName = tc_MusicLib.SelectedTab.Name;
                CurrentPlayIndex = e.RowIndex;
                btn_Play.Image = Image.FromFile(@"../../Images/PlayPressed.png");
                btn_Pause.Image = Image.FromFile(@"../../Images/Pause.png");
                btn_Stop.Image = Image.FromFile(@"../../Images/Stop.png");
                Play(WHAT2PLAY.CURRENT);
            }
        }

        /// <summary>
        /// 播放列表标签切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tc_MusicLib_Selected(object sender, TabControlEventArgs e)
        {
            SelectedPlaylistName = tc_MusicLib.SelectedTab.Name;
            (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).ClearSelection();
        }

        /// <summary>
        /// 删除当前播放列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_DeleteCurrentPlaylist_Click(object sender, EventArgs e)
        {
            //string ss = e.ToString();
            //ss = sender.ToString();
            if (tc_MusicLib.TabPages.Count < 2)
            {
                MessageBox.Show("请至少保留一个播放列表");
                return;
            }

            if (MessageBox.Show("从音乐库中删除当前播放列表，不会删除文件", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (tc_MusicLib.SelectedTab.Name == CurrentPlayListName)
                {
                    Player.Stop();
                    tmr_Tick.Stop();
                }
                tsm_CopyTo.DropDownItems.Remove(tsm_CopyTo.DropDownItems[tc_MusicLib.SelectedTab.Name]);
                tsm_MoveTo.DropDownItems.Remove(tsm_MoveTo.DropDownItems[tc_MusicLib.SelectedTab.Name]);

                ds_MusicLib.Tables.Remove(ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name]);
                tc_MusicLib.TabPages.Remove(tc_MusicLib.SelectedTab);
            }
        }

        /// <summary>
        /// 保存当前播放列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_SavePlaylistAs_Click(object sender, EventArgs e)
        {
            if (ds_MusicLib.Tables[tc_MusicLib.SelectedIndex].Rows.Count > 0)
            {
                DataSet ds = new DataSet();
                ds.Tables.Add(ds_MusicLib.Tables[tc_MusicLib.SelectedIndex].Copy());

                XmlDocument xml = new XmlDocument();
                xml = Utilities.GetXmlDocFormDS(ds);

                saveFileDialog.Filter = "Xml Files(*.xml)| *.xml | All Files(*.*) | *.* ";
                saveFileDialog.InitialDirectory = "";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    xml.Save(saveFileDialog.FileName);
                    saveFileDialog.Reset();
                }
            }
            else
            {
                MessageBox.Show("当前播放列表为空！");
            }
        }

        /// <summary>
        /// 导入播放列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_ImportPlaylist_Click(object sender, EventArgs e)
        {
            openFileDialog.Filter = "Xml Files(*.xml)| *.xml|All Files(*.*)|*.*";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                DataSet ds = new DataSet();

                XmlDocument xml = new XmlDocument();
                xml.Load(openFileDialog.FileName);
                ds = Utilities.GetDSFormXmlDoc(xml);

                foreach (DataTable dt in ds_MusicLib.Tables)
                {
                    if (dt.TableName == ds.Tables[0].TableName)
                    {
                        ds.Tables[0].TableName = ds.Tables[0].TableName + DateTime.Now.ToLongTimeString().ToString().Replace(":", "");
                        CreatPlaylist(ds.Tables[0].TableName);
                        foreach (DataRow dr in ds.Tables[0].Rows)
                            ds_MusicLib.Tables[ds.Tables[0].TableName].Rows.Add(dr.ItemArray);
                        break;
                    }
                }

                openFileDialog.Reset();
            }

        }

        /// <summary>
        /// 播放列表移动歌曲事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MoveTo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).SelectedRows)
            {
                if (dgvr.Cells[0].Value.ToString() == ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Title"].ToString())
                {
                    Player.Stop();
                    tmr_Tick.Stop();
                }
                ds_MusicLib.Tables[sender.ToString()].Rows.Add(ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows[dgvr.Index].ItemArray);
                ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows.RemoveAt(dgvr.Index);
            }
        }

        /// <summary>
        /// 播放列表复制歌曲事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CopyTo_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgvr in (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).SelectedRows)
            {
                if (dgvr.Cells[0].Value.ToString() == ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Title"].ToString())
                {
                    Player.Stop();
                    tmr_Tick.Stop();
                }
                ds_MusicLib.Tables[sender.ToString()].Rows.Add(ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows[dgvr.Index].ItemArray);
                //ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows.RemoveAt(dgvr.Index);
            }
        }

        /// <summary>
        /// 创建播放列表
        /// </summary>
        /// <param name="plylstname"></param>
        private void CreatPlaylist(string plylstname)
        {
            DataGridViewTextBoxColumn Tiele = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Artist = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Album = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Duration = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn FilePath = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn ChannalInfo = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn LrcPath = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn CoverPath = new DataGridViewTextBoxColumn();
            DataGridViewTextBoxColumn Encoder = new DataGridViewTextBoxColumn();

            // 
            // SongName
            // 
            Tiele.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Tiele.DataPropertyName = "Title";
            Tiele.HeaderText = "歌曲";
            Tiele.Name = "Title";
            Tiele.ReadOnly = true;

            // 
            // Singer
            // 
            Artist.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Artist.DataPropertyName = "Artist";
            Artist.HeaderText = "演唱者";
            Artist.Name = "Artist";
            Artist.ReadOnly = true;

            // 
            // Album
            // 
            Album.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Album.DataPropertyName = "Album";
            Album.HeaderText = "专辑";
            Album.Name = "Album";
            Album.ReadOnly = true;

            // 
            // LastTime
            // 
            Duration.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            Duration.DataPropertyName = "Duration";
            Duration.HeaderText = "时长";
            Duration.Name = "Duration";
            Duration.ReadOnly = true;
            Duration.Visible = false;
            Encoder.Width = 40;

            // 
            // Path
            // 
            FilePath.DataPropertyName = "FilePath";
            FilePath.HeaderText = "路径";
            FilePath.Name = "FilePath";
            FilePath.ReadOnly = true;
            FilePath.Visible = false;

            // 
            // ChannalInfo
            // 
            ChannalInfo.DataPropertyName = "ChannalInfo";
            ChannalInfo.HeaderText = "信息";
            ChannalInfo.Name = "ChannalInfo";
            ChannalInfo.ReadOnly = true;
            ChannalInfo.Visible = false;

            // 
            // ChannalInfo
            // 
            LrcPath.DataPropertyName = "LrcPath";
            LrcPath.HeaderText = "歌词路径";
            LrcPath.Name = "LrcPath";
            LrcPath.ReadOnly = true;
            LrcPath.Visible = false;

            // 
            // ChannalInfo
            // 
            CoverPath.DataPropertyName = "CoverPath";
            CoverPath.HeaderText = "封面路径";
            CoverPath.Name = "CoverPath";
            CoverPath.ReadOnly = true;
            CoverPath.Visible = false;

            // 
            // Encoder
            // 
            Encoder.DataPropertyName = "Encoder";
            Encoder.HeaderText = "编码方式";
            Encoder.Name = "Encoder";
            Encoder.ReadOnly = true;
            Encoder.Visible = false;
            Encoder.Width = 60;


            DataGridView dgv = new DataGridView();

            dgv.AllowUserToOrderColumns = true;
            dgv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { Tiele, Artist, Album, Duration, FilePath, ChannalInfo, LrcPath, CoverPath, Encoder });
            dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            dgv.Location = new System.Drawing.Point(3, 3);
            dgv.ContextMenuStrip = this.contextMsPlaylist;
            dgv.Name = plylstname;
            dgv.RowTemplate.Height = 27;
            dgv.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgv.Size = new System.Drawing.Size(602, 514);
            dgv.TabIndex = 0;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Songs_CellDoubleClick);
            dgv.CellMouseDown += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_DefaultPlaylist_CellMouseDown);
            dgv.AllowUserToResizeRows = true;
            dgv.Sorted += new EventHandler(PlayList_Sorted);
            dgv.AllowUserToDeleteRows = false;

            DataTable dt = new DataTable();

            dt.Columns.Add("Title");
            dt.Columns.Add("Artist");
            dt.Columns.Add("Album");
            dt.Columns.Add("Duration");
            dt.Columns.Add("FilePath");
            dt.Columns.Add("ChannalInfo");
            dt.Columns.Add("LrcPath");
            dt.Columns.Add("CoverPath");
            dt.Columns.Add("Encoder");

            dt.TableName = plylstname;

            dgv.DataSource = dt;


            TabPage Page = new TabPage();

            Page.Controls.Add(dgv);
            Page.Location = new System.Drawing.Point(26, 4);
            Page.Name = plylstname;
            Page.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            Page.Size = new System.Drawing.Size(608, 520);
            Page.TabIndex = 0;
            Page.Text = plylstname;
            Page.UseVisualStyleBackColor = true;

            tc_MusicLib.TabPages.Add(Page);

            ds_MusicLib.Tables.Add(dt);

            ToolStripMenuItem tsmMove = new System.Windows.Forms.ToolStripMenuItem();
            ToolStripMenuItem tsmCopy = new System.Windows.Forms.ToolStripMenuItem();

            tsmMove.Name = plylstname;
            tsmMove.Size = new System.Drawing.Size(298, 24);
            tsmMove.Text = plylstname;
            tsmMove.Click += new System.EventHandler(this.MoveTo_Click);
            tsm_MoveTo.DropDownItems.Add(tsmMove);

            tsmCopy.Name = plylstname;
            tsmCopy.Size = new System.Drawing.Size(298, 24);
            tsmCopy.Text = plylstname;
            tsmCopy.Click += new System.EventHandler(this.CopyTo_Click);
            tsm_CopyTo.DropDownItems.Add(tsmCopy);

            if (tc_MusicLib.TabPages.Count > 1)
            {
                tsm_CopyTo.Enabled = true;
                tsm_MoveTo.Enabled = true;
            }
            else
            {
                tsm_CopyTo.Enabled = false;
                tsm_MoveTo.Enabled = false;
            }
        }

        /// <summary>
        /// 播放列表右击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_DefaultPlaylist_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                DataGridView dgv = sender as DataGridView;

                if (e.RowIndex == -1)
                {
                    dgv.ContextMenuStrip = this.contextms_DgvColunmVisable;
                    contextms_DgvColunmVisable.Show( new Point(MousePosition.X, MousePosition.Y));

                }
                else if (e.RowIndex > -1)
                {
                    dgv.ContextMenuStrip = this.contextMsPlaylist;


                    //在不同的列表里弹出不同的移动到子菜单
                    foreach (ToolStripMenuItem tsm in tsm_CopyTo.DropDownItems)
                    {
                        tsm.Visible = true;
                    }

                    //在不同的列表里弹出不同的移动到子菜单
                    foreach (ToolStripMenuItem tsm in tsm_MoveTo.DropDownItems)
                    {
                        tsm.Visible = true;
                    }

                    tsm_CopyTo.DropDownItems[tc_MusicLib.SelectedTab.Name].Visible = false;
                    tsm_MoveTo.DropDownItems[tc_MusicLib.SelectedTab.Name].Visible = false;

                    contextMsPlaylist.Tag = e.RowIndex;
                    contextMsPlaylist.Show(new Point(MousePosition.X, MousePosition.Y));
                }
            }
        }

        /// <summary>
        /// 新建播放列表事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ms_NewPlaylist_Click(object sender, EventArgs e)
        {
            TAG_NewPlaylist:

            string response = Microsoft.VisualBasic.Interaction.InputBox("请输入播放列表名称", "新建播放列表", "", 0, 0);

            if (response == "")
            {
                return;
            }

            foreach (DataTable dt in ds_MusicLib.Tables)
                if (dt.TableName == response)
                {
                    if (MessageBox.Show("音乐库已包含此播放列表，重新输入请按确定", "播放列表重复", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        goto TAG_NewPlaylist;
                    else
                        return;
                }

            CreatPlaylist(response);
            tc_MusicLib.SelectedTab = tc_MusicLib.TabPages[response];

        }

        /// <summary>
        /// 播放列表右键菜单播放事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_PlaySong_Click(object sender, EventArgs e)
        {
            CurrentPlayListName = tc_MusicLib.SelectedTab.Name;
            if (((tc_MusicLib.SelectedTab.Controls[0] as DataGridView).DataSource as DataTable).Rows.Count > 0)
            {
                CurrentPlayIndex = (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).SelectedRows[0].Index;
                Play(WHAT2PLAY.CURRENT);
            }
            else
                MessageBox.Show("列表中没有可播放的歌曲");
        }

        /// <summary>
        /// 播放列表右键移除选中歌曲事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_RemoveFormPlaylist_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("仅从此列表中移除，文件不会被删除", "移除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED)
                {
                    foreach (DataGridViewRow dgvr in (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).SelectedRows)
                    {

                        if (dgvr.Cells[0].Value.ToString() == CurrentPlayingInfo.title.ToString())
                        {
                            Player.Stop();
                            tmr_Tick.Stop();
                            ResetUI();
                        }
                        ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows.RemoveAt(dgvr.Index);
                        //(tc_MusicLib.SelectedTab.Controls[0] as DataGridView).Rows.RemoveAt(dgvr.Index);
                    }
                }
                else
                {
                    foreach (DataGridViewRow dgvr in (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).SelectedRows)
                    {
                        ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows.RemoveAt(dgvr.Index);
                    }
                }
            }
        }

        /// <summary>
        /// 播放列表右键删除选中歌曲事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_DeleteSongs_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("此操作会删除硬盘中的对应文件，请确认", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                foreach (DataGridViewRow dgvr in (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).SelectedRows)
                {
                    if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING)
                    {
                        if (dgvr.Cells[0].Value.ToString() == CurrentPlayingInfo.title.ToString())
                        {
                            Player.Stop();
                            tmr_Tick.Stop();
                            ResetUI();
                        }
                    }

                    if (File.Exists(dgvr.Cells[4].Value.ToString()) == true)
                    {
                        File.Delete(dgvr.Cells[4].Value.ToString());
                    }

                    ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows.RemoveAt(dgvr.Index);
                }

            }
        }

        /// <summary>
        /// 添加文件BGW
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AddFileProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            string[] filenames = e.Argument as string[];
            BackgroundWorker bgw = sender as BackgroundWorker;
            int SongAddedCount = 0;
            foreach (string filename in filenames)
            {
                if (bgw.CancellationPending == true)//如果用户申请取消
                {
                    //标记10000 说明是
                    bgw.ReportProgress(10000, SongAddedCount);
                    Thread.Sleep(3000);
                    e.Cancel = true;
                    return;
                }

                if (File.Exists(filename))
                {
                    if (filename.EndsWith("flac") == true || filename.EndsWith("mp3") == true || filename.EndsWith("wma") == true || filename.EndsWith("ape") == true || filename.EndsWith("ape") == true || filename.EndsWith("wav") == true)
                    {
                        TAG_INFO SongInfo = new TAG_INFO();
                        SongInfo = BassPlayer.GetSongInfo(filename);
                        if (SongInfo != null)
                        {
                            DataRow dr = ds_MusicLib.Tables[SelectedPlaylistName].NewRow();

                            dr[0] = SongInfo.title.ToString();
                            dr[1] = SongInfo.artist.ToString();
                            TimeSpan TS = new TimeSpan(0, 0, ((int)(SongInfo.duration)) + 1);
                            dr[2] = SongInfo.album.ToString();
                            dr[3] = (int)(SongInfo.duration);
                            dr[4] = filename;
                            dr[5] = SongInfo.channelinfo.ToString() + " ," + SongInfo.bitrate.ToString() + "kbps";
                            dr[6] = "";
                            dr[7] = "";
                            dr[8] = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper();

                            ds_MusicLib.Tables[SelectedPlaylistName].Rows.Add(dr);

                            bgw.ReportProgress(SongAddedCount++, filename);

                        }
                    }
                    else
                        continue;
                }
            }

            bgw.ReportProgress(9999, SongAddedCount);
            Thread.Sleep(3000);
        }

        /// <summary>
        /// 添加文件界面响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AddFileProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 9999)
            {
                MessageBox.Show("共添加" + ((int)e.UserState).ToString() + "首歌曲", "添加成功");

            }
            else if (e.ProgressPercentage == 10000)
            {
                MessageBox.Show("共添加" + ((int)e.UserState).ToString() + "首歌曲", "终止添加");
            }
            else
            {
                AddFlieProcessForm.PbValue = e.ProgressPercentage;
                AddFlieProcessForm.CurAddFileName = e.UserState.ToString();
            }
        }

        /// <summary>
        /// 添加文件完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AddFileProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddFlieProcessForm.Close();

            (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).DataSource = ds_MusicLib.Tables[0].Clone();
            (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).DataSource = ds_MusicLib.Tables[tc_MusicLib.SelectedIndex];
        }

        /// <summary>
        /// 添加目录BGW
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AddDirProcess_DoWork(object sender, DoWorkEventArgs e)
        {
            string dirpath = e.Argument as string;
            BackgroundWorker bgw = sender as BackgroundWorker;
            //DirectoryList dirlist = new DirectoryList();

            DirectoryList.GetDirectory(dirpath);

            List<string> filelist = new List<string>();

            bgw.ReportProgress(0, "正在扫描文件夹");
            Thread.Sleep(10);

            foreach (string mp3file in DirectoryList.FileList)
            {
                if (mp3file.EndsWith("mp3") == true)
                    filelist.Add(mp3file);
            }
            // bgw.ReportProgress(0, "正在扫描MP3文件");

            foreach (string apefile in DirectoryList.FileList)
            {
                if (apefile.EndsWith("ape") == true)
                    filelist.Add(apefile);
            }
            // bgw.ReportProgress(0, "正在扫描APE文件");

            foreach (string wmafile in DirectoryList.FileList)
            {
                if (wmafile.EndsWith("wma") == true)
                    filelist.Add(wmafile);
            }
            // bgw.ReportProgress(0, "正在扫描WMA文件");

            foreach (string flacfile in DirectoryList.FileList)
            {
                if (flacfile.EndsWith("flac") == true)
                    filelist.Add(flacfile);
            }
            // bgw.ReportProgress(0, "正在扫描FLAC文件");

            foreach (string oggfile in DirectoryList.FileList)
            {
                if (oggfile.EndsWith("ogg") == true)
                    filelist.Add(oggfile);
            }
            // bgw.ReportProgress(0, "正在扫描FLAC文件");

            foreach (string wavfile in DirectoryList.FileList)
            {
                if (wavfile.EndsWith("wav") == true)
                    filelist.Add(wavfile);
            }
            // bgw.ReportProgress(0, "正在扫描WAV文件");


            bgw.ReportProgress(1, (filelist.Count + 5).ToString());
            Thread.Sleep(10);

            int SongAddedCount = 0;
            foreach (string filename in filelist)
            {
                if (bgw.CancellationPending)//如果用户申请取消
                {
                    bgw.ReportProgress(10000, SongAddedCount);
                    Thread.Sleep(1000);
                    e.Cancel = true;
                    return;
                }

                if (File.Exists(filename))
                {


                    TAG_INFO SongInfo = new TAG_INFO();
                    SongInfo = BassPlayer.GetSongInfo(filename);
                    if (SongInfo != null)
                    {
                        DataRow dr = ds_MusicLib.Tables[SelectedPlaylistName].NewRow();

                        dr[0] = SongInfo.title.ToString();
                        dr[1] = SongInfo.artist.ToString();
                        TimeSpan TS = new TimeSpan(0, 0, ((int)(SongInfo.duration)) + 1);
                        dr[2] = SongInfo.album.ToString();
                        dr[3] = (int)(SongInfo.duration);
                        dr[4] = filename;
                        dr[5] = SongInfo.channelinfo.ToString() + " ," + SongInfo.bitrate.ToString() + "kbps";
                        dr[6] = "";
                        dr[7] = "";
                        dr[8] = filename.Substring(filename.LastIndexOf(".") + 1).ToUpper();

                        ds_MusicLib.Tables[SelectedPlaylistName].Rows.Add(dr);

                        bgw.ReportProgress(SongAddedCount++ + 2, filename);
                        Thread.Sleep(10);
                    }

                }
            }

            bgw.ReportProgress(10000, SongAddedCount);
            Thread.Sleep(3000);
            e.Cancel = true;
            return;

        }

        /// <summary>
        /// 添加目录界面响应事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AddDirProcess_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (e.ProgressPercentage == 9999)
            {
                MessageBox.Show("共添加" + ((int)e.UserState).ToString() + "首歌曲", "添加成功");

            }
            else if (e.ProgressPercentage == 10000)
            {
                MessageBox.Show("共添加" + ((int)e.UserState).ToString() + "首歌曲", "终止添加");
            }
            else if (e.ProgressPercentage == 1)
            {
                AddFlieProcessForm.PbMaximum = Convert.ToInt32(e.UserState);
            }
            else
            {
                AddFlieProcessForm.PbValue = e.ProgressPercentage;
                AddFlieProcessForm.CurAddFileName = e.UserState.ToString();
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 添加目录完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_AddDirProcess_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            AddFlieProcessForm.Close();

            (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).DataSource = ds_MusicLib.Tables[0].Clone();
            (tc_MusicLib.SelectedTab.Controls[0] as DataGridView).DataSource = ds_MusicLib.Tables[tc_MusicLib.SelectedIndex];
        }

        /// <summary>
        /// 停止添加文件BGW
        /// </summary>
        public void StopAddingFlies()
        {
            if (bgw_AddDirProcess.IsBusy == true)
            {
                bgw_AddDirProcess.CancelAsync();
                bgw_AddDirProcess.Dispose();
            }
            if (bgw_AddFileProcess.IsBusy == true)
            {
                bgw_AddFileProcess.CancelAsync();
                bgw_AddFileProcess.Dispose();
            }
        }

        #endregion

        #region 歌词相关操作

        /// <summary>
        /// 删除当前歌词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_DeleteCurrentLrc_Click(object sender, EventArgs e)
        {
            if (bIsLrcValid == true)
            {
                File.Delete(Lrc.LrcPath);
                Lrc.Free();
                txtbox_LrcCurrent.Text = "";
                txtbox_LrcLast.Text = "";
                txtbox_LrcNext.Text = "";
                bIsLrcValid = false;
            }
        }

        /// <summary>
        /// 打开歌词面板按钮事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ms_OpenLrcPlane_Click(object sender, EventArgs e)
        {
            if (ts_OpenLrcPlane.Checked == true)
            {
                ts_OpenLrcPlane.Text = "打开歌词面板";
                ts_OpenLrcPlane.Checked = false;
                this.MinimumSize = new Size(416, 524);
                this.Width = this.Width - tabPlanel_Lrc.Width;
                tabPlanel_Lrc.Hide();
            }

            else
            {

                ts_OpenLrcPlane.Text = "隐藏歌词面板";
                ts_OpenLrcPlane.Checked = true;
                this.Width = this.Width + tabPlanel_Lrc.Width;
                this.MinimumSize = new Size(916, 524);
                tabPlanel_Lrc.Show();
            }
        }

        /// <summary>
        /// 寻找本地歌词
        /// </summary>
        /// <returns></returns>
        private LRCLOADRESULT LoadLocalLrc(SONGINFO info)
        {
            //TODO 搜寻多个目录歌词

            lable_LrcFindStatus.Text = "正在本地匹配歌曲 " + info.title + " 的歌词 ...";

            DirectoryInfo folder = new DirectoryInfo(info.dirpath);

            foreach (FileInfo file in folder.GetFiles("*.lrc"))
            {
                if ((file.FullName.Contains(info.title) == true) && (file.FullName.Contains(info.artist) == true))
                {
                    if (LoadLrc(file.FullName) == true)
                    {
                        SendLog("找到 " + info.title + " 的 本地 歌词，已加载", "req");

                        return LRCLOADRESULT.OK;
                    }
                    else
                    {
                        SendLog(info.title + " 的 本地 歌词文件无效，已删除", "req");
                        File.Delete(file.FullName);
                        return LRCLOADRESULT.LRCINVALID;
                    }

                }
            }



            lable_LrcFindStatus.Text = "在本地未找到歌曲 " + info.title + " 的歌词";
            btn_LrcAdj.Enabled = false;
            return LRCLOADRESULT.NOTFOUND;
        }

        /// <summary>
        /// 载入LRC
        /// </summary>
        /// <param name="lrcpath">LRC路径</param>
        /// <returns></returns>
        private bool LoadLrc(string lrcpath)
        {
            LrcDt lrc = new LrcDt();
            lrc = LrcDt.InitLrc(lrcpath);
            if (lrc != null)
            {
                Lrc.Free();
                Lrc = lrc;
                LrcPreProcess(Lrc);
                CurrentLrcIndex = 4;
                ts_DeleteCurrentLrc.Enabled = true;
                bIsLrcValid = true;
                btn_LrcAdj.Enabled = true;
                SyncLrc();

                return true;
            }
            else
                return false;

        }

        /// <summary>
        /// 寻找在线歌词
        /// </summary>
        /// <returns></returns>
        private string FindOnlineLrc(SONGINFO info)
        {

            //lable_LrcFindStatus.Text = "正在在线匹配歌曲 " + ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Title"].ToString() + " 的歌词 ...";

            string artistinfo = HttpUtility.UrlEncode(info.artist);
            string titleinfo = HttpUtility.UrlEncode(info.title);
            string url = "http://geci.me/api/lyric/" + (titleinfo + "/" + artistinfo).Replace("+", "%20");
            //string url = "http://geci.me/api/lyric/" + titleinfo;

            SendLog("正在歌词迷上寻找 " + info.title + " 的歌词", "req");
            string res = Utilities.GetHttpResult(url, "", "utf-8");

            if (res.Length > 100)
            {
                LrcJson lrcjson = Newtonsoft.Json.JsonConvert.DeserializeObject<LrcJson>(res.Substring(1));
                if (lrcjson.count > 0)
                {
                    SendLog("找到 " + info.title + " 的在线歌词", "req");
                    return lrcjson.result[0].lrc;
                }
                else
                    return "";
            }
            else
                return "";

        }

        /// <summary>
        /// 手动加载歌词菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_OpenLrc_Click(object sender, EventArgs e)
        {
            if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED)
            {
                openFileDialog.Filter = "";
                if (openLrcDialog.ShowDialog() == DialogResult.OK)
                {
                    Lrc = LrcDt.InitLrc(openLrcDialog.FileName);
                    StringCompute stringcompute1 = new StringCompute();
                    decimal rate = 0;

                    if (Lrc.Title == null)
                        rate = 0;
                    else
                    {
                        stringcompute1.SpeedyCompute(Lrc.Title, CurrentPlayingInfo.title);
                        rate = stringcompute1.ComputeResult.Rate;
                    }

                    if ((int)(rate * 100) < 80)
                    {
                        SendLog("歌词信息与歌曲信息不一致，", "Asnc");
                        if (MessageBox.Show("歌词信息与歌曲信息不符，继续使用此歌词？", "歌词信息不匹配", MessageBoxButtons.OKCancel) == DialogResult.OK)
                        {
                            Lrc.LrcWord.TableName = CurrentPlayingInfo.title;
                            Lrc.Title = CurrentPlayingInfo.title;

                            //拷贝歌词到歌曲文件夹
                            string lrcfilename = CurrentPlayingInfo.dirpath + "\\" + CurrentPlayingInfo.artist + " - " + CurrentPlayingInfo.title + ".lrc";
                            Lrc.LrcPath = lrcfilename;
                            SendLog("歌词已强制加载，", "Asnc");
                            File.Copy(openLrcDialog.FileName, lrcfilename);
                            SendLog("歌词文件已重新命名成 " + lrcfilename + " 并且拷贝到，歌曲所在目录", "Asnc");
                            LrcPreProcess(Lrc);
                            CurrentLrcIndex = 4;
                            bIsLrcValid = true;
                            lable_LrcFindStatus.Text = "歌曲 " + CurrentPlayingInfo.title + " 的歌词已加载";
                            btn_LrcAdj.Enabled = true;

                            SyncLrc();

                        }
                        else
                        {
                            Lrc.Free();
                            bIsLrcValid = false;
                            btn_LrcAdj.Enabled = false;
                            return;
                        }
                    }
                    else
                    {
                        SendLog("歌词信息匹配，已加载", "Asnc");
                        string filepath = CurrentPlayingInfo.filepath.ToString();
                        string dirpath = filepath.Substring(0, filepath.LastIndexOf('\\'));

                        //拷贝歌词到歌曲文件夹
                        string lrcfilename = dirpath + "\\" + CurrentPlayingInfo.artist + " - " + CurrentPlayingInfo.title + ".lrc";
                        File.Copy(openLrcDialog.FileName, lrcfilename);
                        LrcPreProcess(Lrc);
                        CurrentLrcIndex = 4;
                        bIsLrcValid = true;
                        lable_LrcFindStatus.Text = "歌曲 " + CurrentPlayingInfo.title + " 的歌词已加载";
                        btn_LrcAdj.Enabled = true;
                        SyncLrc();
                    }
                }
            }
        }

        /// <summary>
        /// LRC预处理
        /// </summary>
        /// <param name="lrc"></param>
        private void LrcPreProcess(LrcDt lrc)
        {
            DataRow dr = lrc.LrcWord.NewRow();
            dr[0] = (double)(lrc.LrcWord.Rows[lrc.LrcWord.Rows.Count - 1]["TimeTag"]) + 20;
            dr[1] = "";
            lrc.LrcWord.Rows.Add(dr.ItemArray);
            lrc.LrcWord.Rows.Add(dr.ItemArray);
            lrc.LrcWord.Rows.Add(dr.ItemArray);
            lrc.LrcWord.Rows.Add(dr.ItemArray);
            lrc.LrcWord.Rows.Add(dr.ItemArray);

            DataRow dr1 = lrc.LrcWord.NewRow();
            dr1[0] = 0;
            dr1[1] = "";
            DataRow dr2 = lrc.LrcWord.NewRow();
            dr2[0] = 0;
            dr2[1] = "";
            DataRow dr3 = lrc.LrcWord.NewRow();
            dr3[0] = 0;
            dr3[1] = "";
            DataRow dr4 = lrc.LrcWord.NewRow();
            dr4[0] = 0;
            dr4[1] = "";
            DataRow dr5 = lrc.LrcWord.NewRow();
            dr5[0] = 0;
            dr5[1] = "";
            lrc.LrcWord.Rows.InsertAt(dr1, 0);
            lrc.LrcWord.Rows.InsertAt(dr2, 0);
            lrc.LrcWord.Rows.InsertAt(dr3, 0);
            lrc.LrcWord.Rows.InsertAt(dr4, 0);
            lrc.LrcWord.Rows.InsertAt(dr5, 0);
        }

        /// <summary>
        /// 更新歌词面板内容
        /// </summary>
        private void UpdateLrcPlanel()
        {
            // SendLog("显示 " + TimeSpan.FromSeconds((double)Lrc.LrcWord.Rows[CurrentLrcIndex]["TimeTag"]).ToString("mmssfff").Insert(2, ":").Insert(5, ".") + " 位置的歌词");
            txtbox_LrcLast.Text = Lrc.LrcWord.Rows[CurrentLrcIndex - 4]["LrcWord"].ToString() + "\r\n" +
                                                  Lrc.LrcWord.Rows[CurrentLrcIndex - 3]["LrcWord"].ToString() + "\r\n" +
                                                  Lrc.LrcWord.Rows[CurrentLrcIndex - 2]["LrcWord"].ToString() + "\r\n" +
                                                  Lrc.LrcWord.Rows[CurrentLrcIndex - 1]["LrcWord"].ToString();
            txtbox_LrcCurrent.Text = Lrc.LrcWord.Rows[CurrentLrcIndex]["LrcWord"].ToString();
            txtbox_LrcNext.Text = Lrc.LrcWord.Rows[CurrentLrcIndex + 1]["LrcWord"].ToString() + "\r\n" +
                                  Lrc.LrcWord.Rows[CurrentLrcIndex + 2]["LrcWord"].ToString() + "\r\n" +
                                  Lrc.LrcWord.Rows[CurrentLrcIndex + 3]["LrcWord"].ToString() + "\r\n" +
                                  Lrc.LrcWord.Rows[CurrentLrcIndex + 4]["LrcWord"].ToString();
        }

        /// <summary>
        /// 同步歌词显示
        /// </summary>
        private void SyncLrc()
        {
            if (bIsLrcValid == true)
            {
                for (int i = 1; i < Lrc.LrcWord.Rows.Count; i++)
                {
                    if (hsb_PlayProcessBar.Value >= Convert.ToInt32((Lrc.LrcWord.Rows[i - 1]["TimeTag"])) &&
                       hsb_PlayProcessBar.Value <= Convert.ToInt32((Lrc.LrcWord.Rows[i]["TimeTag"])))
                    {
                        CurrentLrcIndex = i - 1;

                        if (CurrentLrcIndex > Lrc.LrcWord.Rows.Count - 5)
                            CurrentLrcIndex = Lrc.LrcWord.Rows.Count - 5;

                        if (CurrentLrcIndex < 4)
                            CurrentLrcIndex = 4;

                        SendLog("调整歌词到第 " + (CurrentLrcIndex - 3).ToString() + " 行", "Asnc");
                        UpdateLrcPlanel();

                        CurrentLrcIndex++;
                        break;
                    }
                }
                bIsScrolling = false;
            }
        }

        /// <summary>
        /// 歌词面板开始调整按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LrcAdj_Click(object sender, EventArgs e)
        {
            if (bIsLrcTunning == true)
            {
                btn_LrcAhead.Enabled = false;
                btn_LrcDelay.Enabled = false;
                btn_LrcSave.Enabled = false;
                combox_LrcMoveTime.Enabled = false;
                bIsLrcTunning = false;
                //btn_LrcMove.BackColor = Color.DimGray;
                btn_LrcAdj.Text = "调整歌词";
            }
            else
            {
                btn_LrcAhead.Enabled = true;
                btn_LrcDelay.Enabled = true;
                btn_LrcSave.Enabled = false;
                combox_LrcMoveTime.Enabled = true;
                bIsLrcTunning = true;

                btn_LrcAdj.Text = "结束调整";
            }
        }

        /// <summary>
        /// 歌词面板提前按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LrcAhead_Click(object sender, EventArgs e)
        {
            switch (combox_LrcMoveTime.SelectedItem.ToString())
            {
                case "0.5S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) - 0.5;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0.1;
                        }
                    }
                    SendLog("歌词提前 0.5 秒", "Asnc");
                    SyncLrc();
                    break;

                case "1S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) - 1;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0.1;
                        }
                    }
                    SendLog("歌词提前 1 秒", "Asnc");
                    SyncLrc();
                    break;

                case "2S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) - 2;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0.1;
                        }
                    }
                    SendLog("歌词提前 2 秒", "Asnc");
                    SyncLrc();
                    break;

                case "0.25S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) - 0.25;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            //设置为0.1 防止转换为TimeSpan时长度不一致
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0.1;
                        }
                    }
                    SendLog("歌词提前 0.25 秒", "Asnc");
                    SyncLrc();
                    break;

                default:
                    break;
            }
            btn_LrcSave.Enabled = true;
        }

        /// <summary>
        /// 歌词面板滞后按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LrcDelay_Click(object sender, EventArgs e)
        {
            switch (combox_LrcMoveTime.SelectedItem.ToString())
            {
                case "0.5S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) + 0.5;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0;
                        }
                    }
                    SendLog("歌词滞后 0.5 秒", "Asnc");
                    SyncLrc();
                    break;

                case "1S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) + 1;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0;
                        }
                    }
                    SendLog("歌词滞后 1 秒", "Asnc");
                    SyncLrc();
                    break;

                case "2S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) + 2;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0;
                        }
                    }
                    SendLog("歌词滞后 2 秒", "Asnc");
                    SyncLrc();
                    break;

                case "0.25S":
                    for (int i = 5; i < Lrc.LrcWord.Rows.Count; i++)
                    {
                        Lrc.LrcWord.Rows[i]["TimeTag"] = (double)(Lrc.LrcWord.Rows[i]["TimeTag"]) + 0.25;
                        if ((double)Lrc.LrcWord.Rows[i]["TimeTag"] < 0)
                        {
                            Lrc.LrcWord.Rows[i]["TimeTag"] = 0;
                        }
                    }
                    SendLog("歌词滞后 0.25 秒", "Asnc");
                    SyncLrc();
                    break;

                default:
                    break;
            }
            btn_LrcSave.Enabled = true;
        }

        /// <summary>
        /// 歌词面板保存按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_LrcSave_Click(object sender, EventArgs e)
        {
            string lrcstr = "";
            lrcstr += "[ti:" + Lrc.Title + "]\r\n";
            lrcstr += "[offset:" + Lrc.Offset + "]\r\n";
            lrcstr += "[by:" + Lrc.LrcBy + "]\r\n";
            lrcstr += "[al:" + Lrc.Album + "]\r\n";
            lrcstr += "[ar:" + Lrc.Artist + "]\r\n";
            for (int i = 5; i < Lrc.LrcWord.Rows.Count - 5; i++)
            {
                lrcstr += "[" + TimeSpan.FromSeconds((double)(Lrc.LrcWord.Rows[i]["TimeTag"])).ToString("mmssfff").Insert(2, ":").Insert(5, ".") + "]" + Lrc.LrcWord.Rows[i]["LrcWord"].ToString() + "\r\n";
            }
            string lrcfilename = ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["FilePath"].ToString();

            File.Delete(Lrc.LrcPath);

            Write2LrcFile(lrcstr, Lrc.LrcPath);

            SendLog("保存歌词 " + Lrc.LrcPath, "Asnc");

            btn_LrcSave.Enabled = false;
        }

        /// <summary>
        /// 保存歌词到LRC文件
        /// </summary>
        /// <param name="lrcstr">歌词字符串</param>
        /// <param name="lrcrile">完整的Lrc文件名</param>
        /// <returns></returns>
        public static string Write2LrcFile(string lrcstr, string lrcrile)
        {
            using (FileStream fileStream = new FileStream(lrcrile, FileMode.OpenOrCreate))
            {
                using (StreamWriter streamWriter = new StreamWriter(fileStream, Encoding.Default))
                {
                    streamWriter.Write(lrcstr + "\r\n");
                }
            }
            return "ture";
        }

        /// <summary>
        /// 获取在线歌词线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_GetOnlineLrc_DoWork(object sender, DoWorkEventArgs e)
        {
            SONGINFO info = (SONGINFO)(e.Argument);
            BackgroundWorker bgwkr = sender as BackgroundWorker;
            try
            {
                string lrcuri = FindOnlineLrc(info);
                if (lrcuri != "")
                {
                    string lrcpath = info.dirpath + info.artist + " - " + info.title + ".lrc";
                    SendLog("正在下载" + info.title + " 的歌词 " + lrcuri, "req");
                    if (lrcpath == Utilities.HttpDownloadFile(lrcuri, lrcpath))
                    {
                        SendLog(info.title + " 的歌词下载完成", "req");
                        bgwkr.ReportProgress(1, lrcpath);
                    }
                    else
                    {
                        SendLog(info.title + " 的歌词下载失败，请尝试手动加载", "req");
                        bgwkr.ReportProgress(0, "");
                    }

                }
                else
                {
                    SendLog(info.title + " 的歌词未找到", "Asnc");

                }

                e.Cancel = true;
            }
            catch (Exception ex)
            {
                SendLog(info.title + " 歌词获取异常：" + ex.Message.ToString(), "Asyn");
            }
        }

        /// <summary>
        /// 获取在线歌词完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_GetOnlineLrc_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BackgroundWorker bgwkr = sender as BackgroundWorker;

            if (e.ProgressPercentage == 1)
            {
                if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED)
                {
                    if (e.UserState.ToString().Contains(CurrentPlayingInfo.title) == true)
                    {
                        LRCLOADRESULT res = LoadLocalLrc(CurrentPlayingInfo);
                        if (res == LRCLOADRESULT.OK)
                        {
                            SendLog(CurrentPlayingInfo.title + " 的歌词已载入", "req");
                        }
                        else if (res == LRCLOADRESULT.LRCINVALID)
                        {
                            SendLog(CurrentPlayingInfo.title + " 的 歌词无效,已删除", "req");
                            File.Delete(e.UserState.ToString());
                            //Lrc.Free();
                        }
                    }
                }
            }
            bgwkr.CancelAsync();
        }

        /// <summary>
        /// 在播放列表内右键搜索歌词
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_LrcSeach_Click(object sender, EventArgs e)
        {
            //TODO 在弹出对话框中手动搜索歌词
            if (LrcSearchForm == null || LrcSearchForm.IsDisposed == true)
            {
                ToolStripMenuItem tsm = sender as ToolStripMenuItem;

                int rowindex = (int)(tsm.Owner.Tag);

                DataRow dr = ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows[rowindex];

                LrcSearchForm = new LRCSEARCHFORM(dr);
                LrcSearchForm.UseLrc += new EventHandler(ManualSearchLrcCallBack);
                LrcSearchForm.Text = "歌词搜索 | " + dr[0] + " - " + dr[1] + " - " + dr[2];
                LrcSearchForm.Show();
                Application.DoEvents();
            }
            else
                LrcSearchForm.Activate();
        }

        /// <summary>
        /// 歌词搜索窗口 使用歌词 回调方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualSearchLrcCallBack(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs eventinfo = e as DataGridViewCellEventArgs;
            string s = sender.ToString();
            if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING)
            {
                if (LrcSearchForm.LrcPath.Contains(CurrentPlayingInfo.title) == true)
                {
                    LRCLOADRESULT res = LoadLocalLrc(CurrentPlayingInfo);
                    if (res == LRCLOADRESULT.OK)
                    {
                        SendLog(CurrentPlayingInfo.title + " 的歌词已载入", "req");
                    }
                    else if (res == LRCLOADRESULT.LRCINVALID)
                    {
                        SendLog(CurrentPlayingInfo.title + " 的歌词无效，已删除", "req");
                        File.Delete(LrcSearchForm.LrcPath);
                    }
                }
            }
        }

        #endregion

        #region 可视化相关操作

        /// <summary>
        /// 绘制可视化
        /// </summary>
        private void DrawSpectrum()
        {
            switch (specIdx)
            {
                // normal spectrum (width = resolution)
                case 0:
                    this.pictureBox1.Image = _vis.CreateSpectrum(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.Lime, Color.Red, Color.Black, false, false, false);
                    break;
                // normal spectrum (full resolution)
                case 1:
                    this.pictureBox1.Image = _vis.CreateSpectrum(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.SteelBlue, Color.Pink, Color.Black, false, true, true);
                    break;
                // line spectrum (width = resolution)
                case 2:
                    this.pictureBox1.Image = _vis.CreateSpectrumLine(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.Lime, Color.Red, Color.Black, 2, 2, false, false, false);
                    break;
                // line spectrum (full resolution)
                case 3:
                    this.pictureBox1.Image = _vis.CreateSpectrumLine(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.SteelBlue, Color.Pink, Color.Black, 16, 4, false, true, true);
                    break;
                // ellipse spectrum (width = resolution)
                case 4:
                    this.pictureBox1.Image = _vis.CreateSpectrumEllipse(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.Lime, Color.Red, Color.Black, 1, 2, false, false, false);
                    break;
                // ellipse spectrum (full resolution)
                case 5:
                    this.pictureBox1.Image = _vis.CreateSpectrumEllipse(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.SteelBlue, Color.Pink, Color.Black, 2, 4, false, true, true);
                    break;
                // dot spectrum (width = resolution)
                case 6:
                    this.pictureBox1.Image = _vis.CreateSpectrumDot(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.Lime, Color.Red, Color.Black, 1, 0, false, false, false);
                    break;
                // dot spectrum (full resolution)
                case 7:
                    this.pictureBox1.Image = _vis.CreateSpectrumDot(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.SteelBlue, Color.Pink, Color.Black, 2, 1, false, false, true);
                    break;
                // peak spectrum (width = resolution)
                case 8:
                    this.pictureBox1.Image = _vis.CreateSpectrumLinePeak(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.SeaGreen, Color.LightGreen, Color.Orange, Color.Black, 2, 1, 2, 10, false, false, false);
                    break;
                // peak spectrum (full resolution)
                case 9:
                    this.pictureBox1.Image = _vis.CreateSpectrumLinePeak(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.GreenYellow, Color.RoyalBlue, Color.DarkOrange, Color.Black, 23, 5, 3, 5, false, true, true);
                    break;
                // wave spectrum (width = resolution)
                case 10:
                    this.pictureBox1.Image = _vis.CreateSpectrumWave(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.Yellow, Color.Orange, Color.Black, 1, false, false, false);
                    break;
                // dancing beans spectrum (width = resolution)
                case 11:
                    this.pictureBox1.Image = _vis.CreateSpectrumBean(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.Chocolate, Color.DarkGoldenrod, Color.Black, 4, false, false, true);
                    break;
                // dancing text spectrum (width = resolution)
                case 12:
                    this.pictureBox1.Image = _vis.CreateSpectrumText(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.White, Color.Tomato, Color.Black, "Never Lose Passion", false, false, true);
                    break;
                // frequency detection
                case 13:
                    float amp = _vis.DetectFrequency(Player._stream, 10, 500, true);
                    if (amp > 0.3)
                        this.pictureBox1.BackColor = Color.Red;
                    else
                        this.pictureBox1.BackColor = Color.Black;
                    break;
                // 3D voice print
                case 14:
                    // we need to draw directly directly on the picture box...
                    // normally you would encapsulate this in your own custom control
                    Graphics g = Graphics.FromHwnd(this.pictureBox1.Handle);
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    _vis.CreateSpectrum3DVoicePrint(Player._stream, g, new Rectangle(0, 0, this.pictureBox1.Width, this.pictureBox1.Height), Color.Black, Color.White, voicePrintIdx, false, false);
                    g.Dispose();
                    // next call will be at the next pos
                    voicePrintIdx++;
                    if (voicePrintIdx > this.pictureBox1.Width - 1)
                        voicePrintIdx = 0;
                    break;
                // WaveForm
                case 15:
                    this.pictureBox1.Image = _vis.CreateWaveForm(Player._stream, this.pictureBox1.Width, this.pictureBox1.Height, Color.Green, Color.Red, Color.Gray, Color.Black, 1, true, false, true);
                    break;
            }
        }

        /// <summary>
        /// 切换可视化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                specIdx++;
            else
                specIdx--;

            if (specIdx > 15)
                specIdx = 0;
            if (specIdx < 0)
                specIdx = 15;
            //this.labelVis.Text = String.Format("{0} of 16 (click L/R mouse to change)", specIdx + 1);
            this.pictureBox1.Image = null;
            _vis.ClearPeaks();
        }

        /// <summary>
        /// 双击显示封面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void picBox_AlbumCover_DoubleClick(object sender, EventArgs e)
        {
            if (picBox_AlbumCover.Image.Tag.ToString() != "默认专辑封面")
            {
                CoverShowForm covershow = new CoverShowForm(picBox_AlbumCover.Image);
                covershow.Width = picBox_AlbumCover.Image.Width;
                covershow.Height = picBox_AlbumCover.Image.Height;
                //covershow.MdiParent = this;
                covershow.StartPosition = FormStartPosition.CenterScreen;
                covershow.Show();
            }
        }

        /// <summary>
        /// 查找本地专辑封面
        /// </summary>
        /// <param name="albuminfo"></param>
        private string FindLocalAlbumCover(SONGINFO songinfo)
        {
            if (songinfo.artist == "" && songinfo.album == "")
            {
                return "";
            }

            DirectoryInfo folder = new DirectoryInfo(songinfo.dirpath);

            foreach (FileInfo file in folder.GetFiles("*.jpg"))
            {
                if ((file.FullName.Substring(file.FullName.LastIndexOf("\\"))).Contains(songinfo.artist) == true && (file.FullName.Substring(file.FullName.LastIndexOf("\\"))).Contains(songinfo.album) == true)
                {
                    return file.FullName;
                }
            }

            return "";

        }

        /// <summary>
        /// 查找在线专辑封面
        /// </summary>
        /// <param name="albuminfo">歌曲信息，支持模糊查找</param>
        private string FindOnlineAlbumCover(string artist, string album)
        {
            string url1 = "http://coverbox.sinaapp.com/list";
            string postdata = "input=" + HttpUtility.UrlEncode(artist + " " + album);
            string res = Utilities.GetHttpResult(url1, postdata, "utf-8");
            int start = res.IndexOf("resultCount") - 4;
            int end = res.IndexOf("}", res.LastIndexOf("]"));
            res = res.Substring(start, end - start + 4);

            CoverResultJson coverresult = Newtonsoft.Json.JsonConvert.DeserializeObject<CoverResultJson>(res);
            if (coverresult.resultCount > 0)
            {
                string coverurl = coverresult.results[0].artworkUrl100.Replace("100x100bb", "600x600bb");

                return coverurl;
            }

            return "";

        }

        /// <summary>
        /// 获取在线专辑封面线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_GetOnlineAlbumCover_DoWork(object sender, DoWorkEventArgs e)
        {
            SONGINFO info = (SONGINFO)(e.Argument);
            BackgroundWorker bgwkr = sender as BackgroundWorker;
            try
            {
                SendLog("在CoverBox上寻找 " + info.album + " 的专辑封面", "req");
                string onlinecoveruri = FindOnlineAlbumCover(info.artist, info.album);
                string[] arg = new string[2];
                if (onlinecoveruri != "")
                {
                    SendLog("找到 " + info.album + " 的 在线 专辑封面", "Asnc");
                    string coverpath = info.dirpath + info.artist + " - " + info.album + ".jpg";
                    SendLog("开始下载 " + info.album + " 的专辑封面", "req");
                    if (coverpath == Utilities.HttpDownloadFile(onlinecoveruri, coverpath))
                    {
                        arg[0] = coverpath;
                        arg[1] = info.album;
                        bgwkr.ReportProgress(1, arg);
                        SendLog(info.album + " 的专辑封面下载完成", "req");
                    }
                }
                else
                {
                    arg[0] = "";
                    arg[1] = info.album;
                    bgwkr.ReportProgress(0, arg);
                }

                e.Cancel = true;
            }
            catch (Exception ex)
            {
                SendLog("专辑封面获取异常：" + ex.Message.ToString(), "Asyn");
            }
        }

        /// <summary>
        /// 获取在线专辑封面完成事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_GetOnlineAlbumCover_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            BackgroundWorker bgwkr = sender as BackgroundWorker;
            string[] info = e.UserState as string[];
            if (e.ProgressPercentage == 1)
            {
                if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED)
                {
                    if (info[0].Contains(CurrentPlayingInfo.album))
                    {
                        DisplayAlbumCover(info[0]);
                        ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"] = info[0];
                        SendLog("专辑 " + info[1] + " 的封面已加载", "req");
                    }
                }
            }
            else
            {
                DisplayAlbumCover(@"../../Images/DefaultAlbumCover.jpg");
                SendLog("未找到" + info[1] + " 的内置/本地/在线 专辑封面，请手动添加", "Asnc");
            }
            bgwkr.CancelAsync();
        }

        /// <summary>
        /// 显示专辑封面
        /// </summary>
        /// <param name="FilePath">图片路径</param>
        private void DisplayAlbumCover(string path)
        {
            if (File.Exists(path) == true)
            {
                if (path.EndsWith("jpg") || path.EndsWith("png") || path.EndsWith("bmp"))
                {
                    //释放资源
                    if (picBox_AlbumCover.Image != null)
                    {
                        picBox_AlbumCover.Image.Dispose();
                        picBox_AlbumCover.Image = null;
                    }

                    using (StreamReader sr = new StreamReader(path))
                    {
                        picBox_AlbumCover.Image = Image.FromStream(sr.BaseStream);
                        //tabPlanel_Lrc.BackgroundImage = picBox_AlbumCover.Image;
                    }

                    //设置图片标签，以区分是否默认专辑封面
                    if (path.Contains("DefaultAlbumCover") == true)
                    {
                        picBox_AlbumCover.Image.Tag = "默认专辑封面";
                        toolTip_Cover.Active = false;
                        tsm_AddAlbumCover.Enabled = true;
                        tsm_ReplaeAlbumCover.Enabled = false;
                        tsm_DeleteAlbumCover.Enabled = false;
                    }
                    else
                    {
                        toolTip_Cover.Active = true;
                        picBox_AlbumCover.Image.Tag = path;
                        tsm_AddAlbumCover.Enabled = false;
                        tsm_ReplaeAlbumCover.Enabled = true;
                        tsm_DeleteAlbumCover.Enabled = true;
                    }
                }
            }
        }

        /// <summary>
        /// 更换专辑封面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_ReplaeAlbumCover_Click(object sender, EventArgs e)
        {
            if (picBox_AlbumCover.Image.Tag.ToString().Contains("默认专辑封面") != true)
            {
                openFileDialog.Reset();
                openFileDialog.Filter = "图片文件(*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png|All Files(*.*)| *.* ";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DisplayAlbumCover(openFileDialog.FileName);
                    ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"] = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// 删除专辑封面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_DeleteAlbumCover_Click(object sender, EventArgs e)
        {
            if (picBox_AlbumCover.Image.Tag.ToString().Contains("默认专辑封面") != true)
            {
                DisplayAlbumCover(@"../../Images/DefaultAlbumCover.jpg");
                ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"] = "";
            }

        }

        /// <summary>
        /// 添加专辑封面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_AddAlbumCover_Click(object sender, EventArgs e)
        {
            if (picBox_AlbumCover.Image.Tag.ToString().Contains("默认专辑封面") == true)
            {
                openFileDialog.Reset();
                openFileDialog.Filter = "图片文件(*.jpg;*.bmp;*.png)|*.jpg;*.bmp;*.png|All Files(*.*)| *.* ";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DisplayAlbumCover(openFileDialog.FileName);
                    ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"] = openFileDialog.FileName;
                }
            }
        }

        /// <summary>
        /// 在播放列表内搜索专辑封面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tsm_CoverSeach_Click(object sender, EventArgs e)
        {
            if (CoverSearchForm == null || CoverSearchForm.IsDisposed == true)
            {
                //获得播放列表右键点击时的点击位置
                ToolStripMenuItem tsm = sender as ToolStripMenuItem;
                int rowindex = (int)(tsm.Owner.Tag);

                //作为参数传递给显示出的封面搜索窗口
                DataRow dr = ds_MusicLib.Tables[tc_MusicLib.SelectedTab.Name].Rows[rowindex];

                CoverSearchForm = new COVERSEARCHFORM(dr);
                CoverSearchForm.UseCover += new EventHandler(ManualSearchCoverCallBack);
                CoverSearchForm.Text = "专辑封面搜索 | " + dr[0] + " - " + dr[1] + " - " + dr[2];
                CoverSearchForm.Show();

            }
            else
                CoverSearchForm.Activate();
        }

        /// <summary>
        /// 专辑封面搜索窗口 使用封面 回调方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ManualSearchCoverCallBack(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs eventinfo = e as DataGridViewCellEventArgs;
            string s = sender.ToString();

            if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING)
            {
                if (CoverSearchForm.CoverPath.Contains(CurrentPlayingInfo.album) == true)
                {
                    ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"] = CoverSearchForm.CoverPath;
                    DisplayAlbumCover(CoverSearchForm.CoverPath);
                }
            }
        }

        /// <summary>
        /// 获取歌曲内置专辑封面
        /// </summary>
        /// <param name="songinfo"></param>
        /// <returns></returns>
        public string GetInnerAlbumCover(SONGINFO songinfo)
        {
            if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING || Player.bIsPlaying == BASSActive.BASS_ACTIVE_PAUSED)
            {
                //if (songinfo.filepath.EndsWith("flac") == true)
                //{
                //    FlacFile flacfile = new FlacFile(songinfo.filepath);
                //    List<Picture> pics = new List<Picture>();
                //    pics = flacfile.GetAllPictures();
                //    if (pics.Count > 0)
                //    {
                //        Image img = Image.FromStream(new MemoryStream(pics[0].Data)).GetThumbnailImage((int)(pics[0].Width), (int)(pics[0].Height), null, IntPtr.Zero);

                //        img.Save(songinfo.dirpath + songinfo.artist + " - " + songinfo.album + ".jpg");
                //        ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"] = songinfo.dirpath + songinfo.artist + " - " + songinfo.album + ".jpg";

                //        img.Dispose();

                //        SendLog("找到 " + songinfo.album + " 的内置专辑封面", "req");
                //        return songinfo.dirpath + songinfo.artist + " - " + songinfo.album + ".jpg";
                //    }
                //    else
                //        return "";
                //}
                //else
                //{
                Image img = BassPlayer.GetSongInfo(CurrentPlayingInfo.filepath).PictureGetImage(0);

                if (img != null)
                {
                    img.Save(songinfo.dirpath + songinfo.artist + " - " + songinfo.album + ".jpg");
                    ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["CoverPath"] = songinfo.dirpath + songinfo.artist + " - " + songinfo.album + ".jpg";
                    SendLog("找到 " + songinfo.album + " 的内置专辑封面", "req");
                    return songinfo.dirpath + songinfo.artist + " - " + songinfo.album + ".jpg";
                }
                else
                    return "";
                //}
            }
            else
                return "";
        }
        #endregion

        #region 其它窗体事件

        /// <summary>
        /// 定时器事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tmr_Tick_Tick(object sender, EventArgs e)
        {
            _tickCounter++;
            if (_tickCounter == 3)
            {
                _tickCounter = 0;
                if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_PLAYING)
                {
                    //更新界面

                    //当前播放时间
                    lab_CurrentPlayTime.Text = (new TimeSpan(0, 0, ((int)(Player.ElapsedTime)))).ToString("mmss").Insert(2, ":");

                    //进度条
                    if (bIsScrolling == false)
                    {
                        hsb_PlayProcessBar.Value = (int)Player.ElapsedTime;
                    }

                    //标题栏
                    this.Text = "▶  " + ds_MusicLib.Tables[CurrentPlayListName].Rows[CurrentPlayIndex]["Title"] + " - " + ((int)(Player.ElapsedTime / Player.TotalTime * 100)).ToString() + "%";

                    //歌词
                    if (bIsLrcValid == true)
                    {

                        if (Convert.ToInt32((Lrc.LrcWord.Rows[CurrentLrcIndex]["TimeTag"])) == (int)Player.ElapsedTime)
                        {
                            if (CurrentLrcIndex > Lrc.LrcWord.Rows.Count - 5)
                                CurrentLrcIndex = Lrc.LrcWord.Rows.Count - 5;

                            UpdateLrcPlanel();

                            CurrentLrcIndex++;
                        }

                    }
                }
                //不是认为操作的停止则播放下一曲
                else if (Player.bIsPlaying == BASSActive.BASS_ACTIVE_STOPPED)
                {
                    SendLog("自动播放下一曲", "Asnc");
                    Play(WHAT2PLAY.NEXT);
                }
            }

            DrawSpectrum();
        }

        /// <summary>
        /// 退出菜单事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ts_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //base.Dispose()
        }

        /// <summary>
        /// 窗口关闭事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_Main_FormCloseing(object sender, FormClosingEventArgs e)
        {
            XmlDocument xml = new XmlDocument();
            xml = Utilities.GetXmlDocFormDS(ds_MusicLib);
            xml.Save("MyMusicLib.xml");

            Player.BassClose();
        }

        /// <summary>
        /// 界面快捷键
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void form_Main_KeyDown(object sender, KeyEventArgs e)
        {

            string response = "";

            if (e.KeyCode == Keys.P && e.Control)
                btn_Play.PerformClick();

            if (e.KeyCode == Keys.F && e.Control)
            {
                do
                {
                    response = Microsoft.VisualBasic.Interaction.InputBox("请输入关键词", "搜索播放列表", "", 0, 0);

                    if (response == "")
                        continue;

                    Utilities.SearchDGV(tc_MusicLib.SelectedTab.Controls[0] as DataGridView, response, true,true);

                    break;

                } while (true);
            }

            if (e.KeyCode == Keys.F1)
                ts_OpenLrcPlane.PerformClick();
        }

        /// <summary>
        /// 发送日志
        /// </summary>
        /// <param name="log">日志内容</param>
        /// <param name="req">日志类型</param>
        private void SendLog(string log, string req)
        {
            if (req == "cur")
            {
                this.listBox_Log.Items.Add(DateTime.Now.ToString("hh:mm:ss") + ": " + log);
                this.listBox_Log.TopIndex = this.listBox_Log.Items.Count - (int)(this.listBox_Log.Height / this.listBox_Log.ItemHeight);
            }
            else
            {
                BeginInvoke((MethodInvoker)delegate
                {
                    this.listBox_Log.Items.Add(DateTime.Now.ToString("hh:mm:ss") + ": " + log);
                    this.listBox_Log.TopIndex = this.listBox_Log.Items.Count - (int)(this.listBox_Log.Height / this.listBox_Log.ItemHeight);
                });
            }
        }

        /// <summary>
        /// 重置界面，用于非正常状态下停止播放
        /// </summary>
        private void ResetUI()
        {
            txtbox_LrcCurrent.Text = "";
            txtbox_LrcLast.Text = "";
            txtbox_LrcNext.Text = "";

            DisplayAlbumCover(@"../../Images/DefaultAlbumCover.jpg");

            this.Text = "MusicPlayer";

            lab_CurrentPlayTime.Text = "--:--";
            lab_SongLastTime.Text = "--:--";

            pictureBox1.Image = null;

            statusStrip_ChannalInfo.Text = "";

            btn_Play.Image = Image.FromFile(@"../../Images/Play.png");
            btn_Pause.Image = Image.FromFile(@"../../Images/Pause.png");
            btn_Stop.Image = Image.FromFile(@"../../Images/StopPressed.png");

            hsb_PlayProcessBar.Value = 0;
        }


        #endregion

        private void ts_Setting_Click(object sender, EventArgs e)
        {
            SettingForm settingform = new SettingForm();
            settingform.Show();
        }

        private void tsm_DgvColumnArtistVisable_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tc_MusicLib.SelectedTab.Controls[0] as DataGridView;

            if (tsm_DgvColumnArtistVisable.Checked == true)
                tsm_DgvColumnArtistVisable.Checked = false;
            else
                tsm_DgvColumnArtistVisable.Checked = true;

            dgv.Columns["Artist"].Visible = tsm_DgvColumnArtistVisable.Checked;
        }

        private void tsm_DgvColumnTitleVisable_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tc_MusicLib.SelectedTab.Controls[0] as DataGridView;

            if (tsm_DgvColumnTitleVisable.Checked == true)
                tsm_DgvColumnTitleVisable.Checked = false;
            else
                tsm_DgvColumnTitleVisable.Checked = true;

            dgv.Columns["Title"].Visible = tsm_DgvColumnTitleVisable.Checked;
        }

        private void tsm_DgvColumnAlbumVisable_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tc_MusicLib.SelectedTab.Controls[0] as DataGridView;

            if (tsm_DgvColumnAlbumVisable.Checked == true)
                tsm_DgvColumnAlbumVisable.Checked = false;
            else
                tsm_DgvColumnAlbumVisable.Checked = true;

            dgv.Columns["Album"].Visible = tsm_DgvColumnAlbumVisable.Checked;
        }

        private void tsm_DgvColumnDurationVisable_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tc_MusicLib.SelectedTab.Controls[0] as DataGridView;

            if (tsm_DgvColumnDurationVisable.Checked == true)
                tsm_DgvColumnDurationVisable.Checked = false;
            else
                tsm_DgvColumnDurationVisable.Checked = true;

            dgv.Columns["Duration"].Visible = tsm_DgvColumnDurationVisable.Checked;
        }

        private void tsm_DgvColumnCodeVisable_Click(object sender, EventArgs e)
        {
            DataGridView dgv = tc_MusicLib.SelectedTab.Controls[0] as DataGridView;

            if (tsm_DgvColumnCodeVisable.Checked == true)
                tsm_DgvColumnCodeVisable.Checked = false;
            else
                tsm_DgvColumnCodeVisable.Checked = true;

            dgv.Columns["Encoder"].Visible = tsm_DgvColumnCodeVisable.Checked;
        }

        private void tc_MusicLib_Selecting(object sender, TabControlCancelEventArgs e)
        {
            bool validinput = false;

            if(e.TabPage.Name == "+")
            {
                do
                {

                    string response = Microsoft.VisualBasic.Interaction.InputBox("请输入关键词", "搜索播放列表", "", 0, 0);

                    if (response != "")
                    {
                        e.TabPage.Name = response;
                        CreatPlaylist("  +");
                        validinput = true;
                    }

                } while (!validinput);
            }

        }
    }

    #endregion
}
