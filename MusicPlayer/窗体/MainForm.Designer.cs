//using AlphaUtils;

using AlphaUtils;

namespace MusicPlayer
{
    partial class form_Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_Main));
            this.menuStrip_Menu = new System.Windows.Forms.MenuStrip();
            this.FilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_AddSongs = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_AddDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_ImportMusicLib = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_ExportMusicLib = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Setting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.ts_Close = new System.Windows.Forms.ToolStripMenuItem();
            this.PlaylistToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_NewPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_ImportPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_ExportPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_DeleteCurrentPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_RenameCurrentPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.LrcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_FindLrc = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_OpenLrc = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_OpenLrcPlane = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_LrcSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.ts_DeleteCurrentLrc = new System.Windows.Forms.ToolStripMenuItem();
            this.自动匹配在线专辑封面ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.搜寻本地专辑封面在ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tc_MusicLib = new System.Windows.Forms.TabControl();
            this.contextMsPlaylist = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm_PlaySong = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_RemoveFormPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_DeleteSongs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_MoveTo = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_CopyTo = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_SavePlaylistAs = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_DeleteCurrentPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_RenameCurrentPlaylist = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsm_LrcSeach = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_CoverSeach = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.AddDirDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.tmr_Tick = new System.Windows.Forms.Timer(this.components);
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.lab_CurrentPlayTime = new System.Windows.Forms.Label();
            this.lab_SongLastTime = new System.Windows.Forms.Label();
            this.hsb_PlayProcessBar = new System.Windows.Forms.HScrollBar();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_Pause = new System.Windows.Forms.Button();
            this.btn_Play = new System.Windows.Forms.Button();
            this.btn_Stop = new System.Windows.Forms.Button();
            this.btn_Next = new System.Windows.Forms.Button();
            this.btn_Previous = new System.Windows.Forms.Button();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip_ChannalInfo = new System.Windows.Forms.StatusStrip();
            this.tsm_DropDownButtonLoopMode = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsm_LoopModeSingle = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_LoopModeRandom = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_LoopModeOrder = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_LabelChannalInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabPlanel_Lrc = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.btn_LrcSave = new System.Windows.Forms.Button();
            this.btn_LrcDelay = new System.Windows.Forms.Button();
            this.btn_LrcAhead = new System.Windows.Forms.Button();
            this.combox_LrcMoveTime = new System.Windows.Forms.ComboBox();
            this.btn_LrcAdj = new System.Windows.Forms.Button();
            this.lable_LrcFindStatus = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.txtbox_LrcLast = new System.Windows.Forms.TextBox();
            this.txtbox_LrcCurrent = new System.Windows.Forms.TextBox();
            this.txtbox_LrcNext = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.picBox_AlbumCover = new System.Windows.Forms.PictureBox();
            this.contextMsAlbumCover = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm_ReplaeAlbumCover = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_DeleteAlbumCover = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_AddAlbumCover = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpBox_LogPanel = new System.Windows.Forms.GroupBox();
            this.listBox_Log = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.openLrcDialog = new System.Windows.Forms.OpenFileDialog();
            this.bgw_GetOnlineAlbumCover = new System.ComponentModel.BackgroundWorker();
            this.bgw_GetOnlineLrc = new System.ComponentModel.BackgroundWorker();
            this.toolTip_Cover = new System.Windows.Forms.ToolTip(this.components);
            this.bgw_AddFileProcess = new System.ComponentModel.BackgroundWorker();
            this.bgw_AddDirProcess = new System.ComponentModel.BackgroundWorker();
            this.abx_LrcCurrent = new AlphaUtils.AlphaTextBox();
            this.abx_LrcLast = new AlphaUtils.AlphaTextBox();
            this.abx_LrcNext = new AlphaUtils.AlphaTextBox();
            this.contextms_DgvColunmVisable = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsm_DgvColumnArtistVisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_DgvColumnTitleVisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_DgvColumnAlbumVisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_DgvColumnDurationVisable = new System.Windows.Forms.ToolStripMenuItem();
            this.tsm_DgvColumnCodeVisable = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip_Menu.SuspendLayout();
            this.contextMsPlaylist.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.statusStrip_ChannalInfo.SuspendLayout();
            this.tabPlanel_Lrc.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBox_AlbumCover)).BeginInit();
            this.contextMsAlbumCover.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpBox_LogPanel.SuspendLayout();
            this.contextms_DgvColunmVisable.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_Menu
            // 
            this.menuStrip_Menu.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip_Menu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_Menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FilesToolStripMenuItem,
            this.PlaylistToolStripMenuItem,
            this.LrcToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.menuStrip_Menu.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_Menu.MinimumSize = new System.Drawing.Size(375, 0);
            this.menuStrip_Menu.Name = "menuStrip_Menu";
            this.menuStrip_Menu.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip_Menu.Size = new System.Drawing.Size(400, 25);
            this.menuStrip_Menu.TabIndex = 6;
            this.menuStrip_Menu.Text = "menuStrip1";
            // 
            // FilesToolStripMenuItem
            // 
            this.FilesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_AddSongs,
            this.ts_AddDir,
            this.toolStripSeparator5,
            this.ts_ImportMusicLib,
            this.ts_ExportMusicLib,
            this.toolStripSeparator6,
            this.ts_Setting,
            this.toolStripSeparator7,
            this.ts_Close});
            this.FilesToolStripMenuItem.Name = "FilesToolStripMenuItem";
            this.FilesToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.FilesToolStripMenuItem.Text = "文件";
            // 
            // ts_AddSongs
            // 
            this.ts_AddSongs.Name = "ts_AddSongs";
            this.ts_AddSongs.Size = new System.Drawing.Size(136, 22);
            this.ts_AddSongs.Text = "添加歌曲...";
            this.ts_AddSongs.Click += new System.EventHandler(this.ts_AddSongs_Click);
            // 
            // ts_AddDir
            // 
            this.ts_AddDir.Name = "ts_AddDir";
            this.ts_AddDir.Size = new System.Drawing.Size(136, 22);
            this.ts_AddDir.Text = "添加目录...";
            this.ts_AddDir.Click += new System.EventHandler(this.ts_AddDir_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(133, 6);
            // 
            // ts_ImportMusicLib
            // 
            this.ts_ImportMusicLib.Name = "ts_ImportMusicLib";
            this.ts_ImportMusicLib.Size = new System.Drawing.Size(136, 22);
            this.ts_ImportMusicLib.Text = "导入音乐库";
            this.ts_ImportMusicLib.Click += new System.EventHandler(this.ts_ImportMusicLib_Click);
            // 
            // ts_ExportMusicLib
            // 
            this.ts_ExportMusicLib.Name = "ts_ExportMusicLib";
            this.ts_ExportMusicLib.Size = new System.Drawing.Size(136, 22);
            this.ts_ExportMusicLib.Text = "导出音乐库";
            this.ts_ExportMusicLib.Click += new System.EventHandler(this.ts_ExportMusicLib_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(133, 6);
            // 
            // ts_Setting
            // 
            this.ts_Setting.Name = "ts_Setting";
            this.ts_Setting.Size = new System.Drawing.Size(136, 22);
            this.ts_Setting.Text = "设置";
            this.ts_Setting.Click += new System.EventHandler(this.ts_Setting_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(133, 6);
            // 
            // ts_Close
            // 
            this.ts_Close.Name = "ts_Close";
            this.ts_Close.Size = new System.Drawing.Size(136, 22);
            this.ts_Close.Text = "退出 ";
            this.ts_Close.Click += new System.EventHandler(this.ts_Close_Click);
            // 
            // PlaylistToolStripMenuItem
            // 
            this.PlaylistToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_NewPlaylist,
            this.ts_ImportPlaylist,
            this.ts_ExportPlaylist,
            this.ts_DeleteCurrentPlaylist,
            this.ts_RenameCurrentPlaylist});
            this.PlaylistToolStripMenuItem.Name = "PlaylistToolStripMenuItem";
            this.PlaylistToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.PlaylistToolStripMenuItem.Text = "播放列表";
            // 
            // ts_NewPlaylist
            // 
            this.ts_NewPlaylist.Name = "ts_NewPlaylist";
            this.ts_NewPlaylist.Size = new System.Drawing.Size(184, 22);
            this.ts_NewPlaylist.Text = "新建播放列表";
            this.ts_NewPlaylist.Click += new System.EventHandler(this.ms_NewPlaylist_Click);
            // 
            // ts_ImportPlaylist
            // 
            this.ts_ImportPlaylist.Name = "ts_ImportPlaylist";
            this.ts_ImportPlaylist.Size = new System.Drawing.Size(184, 22);
            this.ts_ImportPlaylist.Text = "导入播放列表";
            this.ts_ImportPlaylist.Click += new System.EventHandler(this.ts_ImportPlaylist_Click);
            // 
            // ts_ExportPlaylist
            // 
            this.ts_ExportPlaylist.Name = "ts_ExportPlaylist";
            this.ts_ExportPlaylist.Size = new System.Drawing.Size(184, 22);
            this.ts_ExportPlaylist.Text = "导出当前播放列表";
            this.ts_ExportPlaylist.Click += new System.EventHandler(this.tsm_SavePlaylistAs_Click);
            // 
            // ts_DeleteCurrentPlaylist
            // 
            this.ts_DeleteCurrentPlaylist.Name = "ts_DeleteCurrentPlaylist";
            this.ts_DeleteCurrentPlaylist.Size = new System.Drawing.Size(184, 22);
            this.ts_DeleteCurrentPlaylist.Text = "删除当前播放列表";
            this.ts_DeleteCurrentPlaylist.Click += new System.EventHandler(this.ts_DeleteCurrentPlaylist_Click);
            // 
            // ts_RenameCurrentPlaylist
            // 
            this.ts_RenameCurrentPlaylist.Name = "ts_RenameCurrentPlaylist";
            this.ts_RenameCurrentPlaylist.Size = new System.Drawing.Size(184, 22);
            this.ts_RenameCurrentPlaylist.Text = "重命名当前播放列表";
            this.ts_RenameCurrentPlaylist.Click += new System.EventHandler(this.ts_RenameCurrentPlaylist_Click);
            // 
            // LrcToolStripMenuItem
            // 
            this.LrcToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ts_FindLrc,
            this.ts_OpenLrc,
            this.ts_OpenLrcPlane,
            this.ts_LrcSetting,
            this.ts_DeleteCurrentLrc,
            this.自动匹配在线专辑封面ToolStripMenuItem,
            this.搜寻本地专辑封面在ToolStripMenuItem});
            this.LrcToolStripMenuItem.Name = "LrcToolStripMenuItem";
            this.LrcToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.LrcToolStripMenuItem.Text = "歌词与封面";
            // 
            // ts_FindLrc
            // 
            this.ts_FindLrc.Name = "ts_FindLrc";
            this.ts_FindLrc.Size = new System.Drawing.Size(196, 22);
            this.ts_FindLrc.Text = "自动匹配";
            // 
            // ts_OpenLrc
            // 
            this.ts_OpenLrc.Name = "ts_OpenLrc";
            this.ts_OpenLrc.Size = new System.Drawing.Size(196, 22);
            this.ts_OpenLrc.Text = "手动加载";
            this.ts_OpenLrc.Click += new System.EventHandler(this.ts_OpenLrc_Click);
            // 
            // ts_OpenLrcPlane
            // 
            this.ts_OpenLrcPlane.Name = "ts_OpenLrcPlane";
            this.ts_OpenLrcPlane.Size = new System.Drawing.Size(196, 22);
            this.ts_OpenLrcPlane.Text = "打开歌词面板";
            this.ts_OpenLrcPlane.Click += new System.EventHandler(this.ms_OpenLrcPlane_Click);
            // 
            // ts_LrcSetting
            // 
            this.ts_LrcSetting.Name = "ts_LrcSetting";
            this.ts_LrcSetting.Size = new System.Drawing.Size(196, 22);
            this.ts_LrcSetting.Text = "设置";
            // 
            // ts_DeleteCurrentLrc
            // 
            this.ts_DeleteCurrentLrc.Name = "ts_DeleteCurrentLrc";
            this.ts_DeleteCurrentLrc.Size = new System.Drawing.Size(196, 22);
            this.ts_DeleteCurrentLrc.Text = "删除当前播放歌曲歌词";
            this.ts_DeleteCurrentLrc.Click += new System.EventHandler(this.ts_DeleteCurrentLrc_Click);
            // 
            // 自动匹配在线专辑封面ToolStripMenuItem
            // 
            this.自动匹配在线专辑封面ToolStripMenuItem.Name = "自动匹配在线专辑封面ToolStripMenuItem";
            this.自动匹配在线专辑封面ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.自动匹配在线专辑封面ToolStripMenuItem.Text = "自动匹配在线专辑封面";
            // 
            // 搜寻本地专辑封面在ToolStripMenuItem
            // 
            this.搜寻本地专辑封面在ToolStripMenuItem.Name = "搜寻本地专辑封面在ToolStripMenuItem";
            this.搜寻本地专辑封面在ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.搜寻本地专辑封面在ToolStripMenuItem.Text = "搜寻本地专辑封面 在 ";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "关于";
            // 
            // tc_MusicLib
            // 
            this.tc_MusicLib.Alignment = System.Windows.Forms.TabAlignment.Left;
            this.tc_MusicLib.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tc_MusicLib.Location = new System.Drawing.Point(2, 80);
            this.tc_MusicLib.Margin = new System.Windows.Forms.Padding(2);
            this.tc_MusicLib.Multiline = true;
            this.tc_MusicLib.Name = "tc_MusicLib";
            this.tc_MusicLib.SelectedIndex = 0;
            this.tc_MusicLib.Size = new System.Drawing.Size(396, 553);
            this.tc_MusicLib.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tc_MusicLib.TabIndex = 9;
            this.tc_MusicLib.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tc_MusicLib_Selecting);
            this.tc_MusicLib.Selected += new System.Windows.Forms.TabControlEventHandler(this.tc_MusicLib_Selected);
            // 
            // contextMsPlaylist
            // 
            this.contextMsPlaylist.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMsPlaylist.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_PlaySong,
            this.toolStripSeparator1,
            this.tsm_RemoveFormPlaylist,
            this.tsm_DeleteSongs,
            this.toolStripSeparator2,
            this.tsm_MoveTo,
            this.tsm_CopyTo,
            this.toolStripSeparator3,
            this.tsm_SavePlaylistAs,
            this.tsm_DeleteCurrentPlaylist,
            this.tsm_RenameCurrentPlaylist,
            this.toolStripSeparator4,
            this.tsm_LrcSeach,
            this.tsm_CoverSeach});
            this.contextMsPlaylist.Name = "contextMenuStrip";
            this.contextMsPlaylist.Size = new System.Drawing.Size(185, 248);
            // 
            // tsm_PlaySong
            // 
            this.tsm_PlaySong.Name = "tsm_PlaySong";
            this.tsm_PlaySong.Size = new System.Drawing.Size(184, 22);
            this.tsm_PlaySong.Text = "播放";
            this.tsm_PlaySong.Click += new System.EventHandler(this.ts_PlaySong_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // tsm_RemoveFormPlaylist
            // 
            this.tsm_RemoveFormPlaylist.Name = "tsm_RemoveFormPlaylist";
            this.tsm_RemoveFormPlaylist.Size = new System.Drawing.Size(184, 22);
            this.tsm_RemoveFormPlaylist.Text = "移除选中歌曲";
            this.tsm_RemoveFormPlaylist.Click += new System.EventHandler(this.ts_RemoveFormPlaylist_Click);
            // 
            // tsm_DeleteSongs
            // 
            this.tsm_DeleteSongs.Name = "tsm_DeleteSongs";
            this.tsm_DeleteSongs.Size = new System.Drawing.Size(184, 22);
            this.tsm_DeleteSongs.Text = "删除选中歌曲";
            this.tsm_DeleteSongs.Click += new System.EventHandler(this.ts_DeleteSongs_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(181, 6);
            // 
            // tsm_MoveTo
            // 
            this.tsm_MoveTo.Name = "tsm_MoveTo";
            this.tsm_MoveTo.Size = new System.Drawing.Size(184, 22);
            this.tsm_MoveTo.Text = "移动到";
            // 
            // tsm_CopyTo
            // 
            this.tsm_CopyTo.Name = "tsm_CopyTo";
            this.tsm_CopyTo.Size = new System.Drawing.Size(184, 22);
            this.tsm_CopyTo.Text = "复制到";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(181, 6);
            // 
            // tsm_SavePlaylistAs
            // 
            this.tsm_SavePlaylistAs.Name = "tsm_SavePlaylistAs";
            this.tsm_SavePlaylistAs.Size = new System.Drawing.Size(184, 22);
            this.tsm_SavePlaylistAs.Text = "导出当前播放列表";
            this.tsm_SavePlaylistAs.Click += new System.EventHandler(this.tsm_SavePlaylistAs_Click);
            // 
            // tsm_DeleteCurrentPlaylist
            // 
            this.tsm_DeleteCurrentPlaylist.Name = "tsm_DeleteCurrentPlaylist";
            this.tsm_DeleteCurrentPlaylist.Size = new System.Drawing.Size(184, 22);
            this.tsm_DeleteCurrentPlaylist.Text = "删除当前播放列表";
            this.tsm_DeleteCurrentPlaylist.Click += new System.EventHandler(this.ts_DeleteCurrentPlaylist_Click);
            // 
            // tsm_RenameCurrentPlaylist
            // 
            this.tsm_RenameCurrentPlaylist.Name = "tsm_RenameCurrentPlaylist";
            this.tsm_RenameCurrentPlaylist.Size = new System.Drawing.Size(184, 22);
            this.tsm_RenameCurrentPlaylist.Text = "重命名当前播放列表";
            this.tsm_RenameCurrentPlaylist.Click += new System.EventHandler(this.ts_RenameCurrentPlaylist_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(181, 6);
            // 
            // tsm_LrcSeach
            // 
            this.tsm_LrcSeach.Name = "tsm_LrcSeach";
            this.tsm_LrcSeach.Size = new System.Drawing.Size(184, 22);
            this.tsm_LrcSeach.Text = "搜索歌词";
            this.tsm_LrcSeach.Click += new System.EventHandler(this.tsm_LrcSeach_Click);
            // 
            // tsm_CoverSeach
            // 
            this.tsm_CoverSeach.Name = "tsm_CoverSeach";
            this.tsm_CoverSeach.Size = new System.Drawing.Size(184, 22);
            this.tsm_CoverSeach.Text = "搜索专辑封面";
            this.tsm_CoverSeach.Click += new System.EventHandler(this.tsm_CoverSeach_Click);
            // 
            // tmr_Tick
            // 
            this.tmr_Tick.Interval = 50;
            this.tmr_Tick.Tick += new System.EventHandler(this.tmr_Tick_Tick);
            // 
            // lab_CurrentPlayTime
            // 
            this.lab_CurrentPlayTime.AutoSize = true;
            this.lab_CurrentPlayTime.BackColor = System.Drawing.Color.Transparent;
            this.lab_CurrentPlayTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_CurrentPlayTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_CurrentPlayTime.Location = new System.Drawing.Point(0, 0);
            this.lab_CurrentPlayTime.Margin = new System.Windows.Forms.Padding(0);
            this.lab_CurrentPlayTime.Name = "lab_CurrentPlayTime";
            this.lab_CurrentPlayTime.Size = new System.Drawing.Size(129, 18);
            this.lab_CurrentPlayTime.TabIndex = 8;
            this.lab_CurrentPlayTime.Text = "--:--";
            this.lab_CurrentPlayTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lab_SongLastTime
            // 
            this.lab_SongLastTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lab_SongLastTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lab_SongLastTime.Location = new System.Drawing.Point(129, 0);
            this.lab_SongLastTime.Margin = new System.Windows.Forms.Padding(0);
            this.lab_SongLastTime.Name = "lab_SongLastTime";
            this.lab_SongLastTime.Size = new System.Drawing.Size(129, 18);
            this.lab_SongLastTime.TabIndex = 7;
            this.lab_SongLastTime.Text = "--:--";
            this.lab_SongLastTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // hsb_PlayProcessBar
            // 
            this.hsb_PlayProcessBar.AccessibleRole = System.Windows.Forms.AccessibleRole.Sound;
            this.hsb_PlayProcessBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.hsb_PlayProcessBar.Location = new System.Drawing.Point(2, 24);
            this.hsb_PlayProcessBar.Margin = new System.Windows.Forms.Padding(2);
            this.hsb_PlayProcessBar.Name = "hsb_PlayProcessBar";
            this.hsb_PlayProcessBar.Size = new System.Drawing.Size(258, 16);
            this.hsb_PlayProcessBar.TabIndex = 5;
            this.hsb_PlayProcessBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.hScrollBar1_Scroll);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.tc_MusicLib, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(400, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(400, 657);
            this.tableLayoutPanel1.TabIndex = 13;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Pause, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Play, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Stop, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Next, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.btn_Previous, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 28);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(396, 48);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.BackColor = System.Drawing.SystemColors.Control;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.hsb_PlayProcessBar, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(132, 2);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(262, 44);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.lab_SongLastTime, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lab_CurrentPlayTime, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(2, 2);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(258, 18);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // btn_Pause
            // 
            this.btn_Pause.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Pause.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Pause.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Pause.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Pause.Image = ((System.Drawing.Image)(resources.GetObject("btn_Pause.Image")));
            this.btn_Pause.Location = new System.Drawing.Point(28, 2);
            this.btn_Pause.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Pause.Name = "btn_Pause";
            this.btn_Pause.Size = new System.Drawing.Size(22, 44);
            this.btn_Pause.TabIndex = 1;
            this.btn_Pause.UseVisualStyleBackColor = true;
            this.btn_Pause.Click += new System.EventHandler(this.btn_Pause_Click);
            // 
            // btn_Play
            // 
            this.btn_Play.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Play.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Play.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Play.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Play.Image = ((System.Drawing.Image)(resources.GetObject("btn_Play.Image")));
            this.btn_Play.Location = new System.Drawing.Point(54, 2);
            this.btn_Play.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Play.Name = "btn_Play";
            this.btn_Play.Size = new System.Drawing.Size(22, 44);
            this.btn_Play.TabIndex = 2;
            this.btn_Play.UseVisualStyleBackColor = true;
            this.btn_Play.Click += new System.EventHandler(this.btn_Play_Click);
            // 
            // btn_Stop
            // 
            this.btn_Stop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Stop.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Stop.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Stop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Stop.Image = ((System.Drawing.Image)(resources.GetObject("btn_Stop.Image")));
            this.btn_Stop.Location = new System.Drawing.Point(106, 2);
            this.btn_Stop.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Stop.Name = "btn_Stop";
            this.btn_Stop.Size = new System.Drawing.Size(22, 44);
            this.btn_Stop.TabIndex = 4;
            this.btn_Stop.UseVisualStyleBackColor = true;
            this.btn_Stop.Click += new System.EventHandler(this.btn_Stop_Click);
            // 
            // btn_Next
            // 
            this.btn_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Next.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Next.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Next.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Next.Image = ((System.Drawing.Image)(resources.GetObject("btn_Next.Image")));
            this.btn_Next.Location = new System.Drawing.Point(80, 2);
            this.btn_Next.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Next.Name = "btn_Next";
            this.btn_Next.Size = new System.Drawing.Size(22, 44);
            this.btn_Next.TabIndex = 3;
            this.btn_Next.UseVisualStyleBackColor = true;
            this.btn_Next.Click += new System.EventHandler(this.btn_Next_Click);
            this.btn_Next.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Next_MouseDown);
            this.btn_Next.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Next_MouseUp);
            // 
            // btn_Previous
            // 
            this.btn_Previous.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_Previous.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.btn_Previous.FlatAppearance.CheckedBackColor = System.Drawing.Color.Transparent;
            this.btn_Previous.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_Previous.Image = ((System.Drawing.Image)(resources.GetObject("btn_Previous.Image")));
            this.btn_Previous.Location = new System.Drawing.Point(2, 2);
            this.btn_Previous.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Previous.Name = "btn_Previous";
            this.btn_Previous.Size = new System.Drawing.Size(22, 44);
            this.btn_Previous.TabIndex = 0;
            this.btn_Previous.UseVisualStyleBackColor = true;
            this.btn_Previous.Click += new System.EventHandler(this.btn_Previous_Click);
            this.btn_Previous.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btn_Previous_MouseDown);
            this.btn_Previous.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btn_Previous_MouseUp);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(0, 18);
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(56, 18);
            this.toolStripStatusLabel2.Text = "播放模式";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // statusStrip_ChannalInfo
            // 
            this.statusStrip_ChannalInfo.BackColor = System.Drawing.Color.Transparent;
            this.statusStrip_ChannalInfo.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip_ChannalInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.tsm_DropDownButtonLoopMode,
            this.tsm_LabelChannalInfo});
            this.statusStrip_ChannalInfo.Location = new System.Drawing.Point(0, 634);
            this.statusStrip_ChannalInfo.MinimumSize = new System.Drawing.Size(375, 0);
            this.statusStrip_ChannalInfo.Name = "statusStrip_ChannalInfo";
            this.statusStrip_ChannalInfo.Padding = new System.Windows.Forms.Padding(1, 0, 10, 0);
            this.statusStrip_ChannalInfo.Size = new System.Drawing.Size(400, 23);
            this.statusStrip_ChannalInfo.SizingGrip = false;
            this.statusStrip_ChannalInfo.TabIndex = 12;
            // 
            // tsm_DropDownButtonLoopMode
            // 
            this.tsm_DropDownButtonLoopMode.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsm_DropDownButtonLoopMode.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_LoopModeSingle,
            this.tsm_LoopModeRandom,
            this.tsm_LoopModeOrder});
            this.tsm_DropDownButtonLoopMode.Image = ((System.Drawing.Image)(resources.GetObject("tsm_DropDownButtonLoopMode.Image")));
            this.tsm_DropDownButtonLoopMode.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsm_DropDownButtonLoopMode.Name = "tsm_DropDownButtonLoopMode";
            this.tsm_DropDownButtonLoopMode.Size = new System.Drawing.Size(69, 21);
            this.tsm_DropDownButtonLoopMode.Text = "顺序循环";
            this.tsm_DropDownButtonLoopMode.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage;
            // 
            // tsm_LoopModeSingle
            // 
            this.tsm_LoopModeSingle.Name = "tsm_LoopModeSingle";
            this.tsm_LoopModeSingle.ShowShortcutKeys = false;
            this.tsm_LoopModeSingle.Size = new System.Drawing.Size(116, 22);
            this.tsm_LoopModeSingle.Text = "单曲循环";
            this.tsm_LoopModeSingle.Click += new System.EventHandler(this.tsm_LoopModeSingle_Click);
            // 
            // tsm_LoopModeRandom
            // 
            this.tsm_LoopModeRandom.Name = "tsm_LoopModeRandom";
            this.tsm_LoopModeRandom.ShowShortcutKeys = false;
            this.tsm_LoopModeRandom.Size = new System.Drawing.Size(116, 22);
            this.tsm_LoopModeRandom.Text = "随机循环";
            this.tsm_LoopModeRandom.Click += new System.EventHandler(this.tsm_LoopModeRandom_Click);
            // 
            // tsm_LoopModeOrder
            // 
            this.tsm_LoopModeOrder.Name = "tsm_LoopModeOrder";
            this.tsm_LoopModeOrder.ShowShortcutKeys = false;
            this.tsm_LoopModeOrder.Size = new System.Drawing.Size(116, 22);
            this.tsm_LoopModeOrder.Text = "顺序循环";
            this.tsm_LoopModeOrder.Click += new System.EventHandler(this.tsm_LoopModeOrder_Click);
            // 
            // tsm_LabelChannalInfo
            // 
            this.tsm_LabelChannalInfo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsm_LabelChannalInfo.Name = "tsm_LabelChannalInfo";
            this.tsm_LabelChannalInfo.Size = new System.Drawing.Size(264, 18);
            this.tsm_LabelChannalInfo.Spring = true;
            this.tsm_LabelChannalInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tabPlanel_Lrc
            // 
            this.tabPlanel_Lrc.BackColor = System.Drawing.Color.White;
            this.tabPlanel_Lrc.ColumnCount = 1;
            this.tabPlanel_Lrc.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabPlanel_Lrc.Controls.Add(this.tableLayoutPanel5, 0, 3);
            this.tabPlanel_Lrc.Controls.Add(this.lable_LrcFindStatus, 0, 4);
            this.tabPlanel_Lrc.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tabPlanel_Lrc.Controls.Add(this.label1, 0, 0);
            this.tabPlanel_Lrc.Controls.Add(this.label2, 0, 1);
            this.tabPlanel_Lrc.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabPlanel_Lrc.Location = new System.Drawing.Point(400, 0);
            this.tabPlanel_Lrc.Margin = new System.Windows.Forms.Padding(2);
            this.tabPlanel_Lrc.MinimumSize = new System.Drawing.Size(500, 173);
            this.tabPlanel_Lrc.Name = "tabPlanel_Lrc";
            this.tabPlanel_Lrc.RowCount = 5;
            this.tabPlanel_Lrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tabPlanel_Lrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tabPlanel_Lrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tabPlanel_Lrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tabPlanel_Lrc.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tabPlanel_Lrc.Size = new System.Drawing.Size(500, 657);
            this.tabPlanel_Lrc.TabIndex = 14;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel5.ColumnCount = 5;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel5.Controls.Add(this.btn_LrcSave, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_LrcDelay, 2, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_LrcAhead, 3, 0);
            this.tableLayoutPanel5.Controls.Add(this.combox_LrcMoveTime, 4, 0);
            this.tableLayoutPanel5.Controls.Add(this.btn_LrcAdj, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Font = new System.Drawing.Font("宋体", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tableLayoutPanel5.Location = new System.Drawing.Point(2, 602);
            this.tableLayoutPanel5.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(496, 29);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // btn_LrcSave
            // 
            this.btn_LrcSave.BackColor = System.Drawing.Color.Transparent;
            this.btn_LrcSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_LrcSave.Enabled = false;
            this.btn_LrcSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_LrcSave.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LrcSave.Location = new System.Drawing.Point(101, 2);
            this.btn_LrcSave.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LrcSave.Name = "btn_LrcSave";
            this.btn_LrcSave.Size = new System.Drawing.Size(95, 25);
            this.btn_LrcSave.TabIndex = 0;
            this.btn_LrcSave.Text = "保存";
            this.btn_LrcSave.UseVisualStyleBackColor = false;
            this.btn_LrcSave.Click += new System.EventHandler(this.btn_LrcSave_Click);
            // 
            // btn_LrcDelay
            // 
            this.btn_LrcDelay.BackColor = System.Drawing.Color.Transparent;
            this.btn_LrcDelay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_LrcDelay.Enabled = false;
            this.btn_LrcDelay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_LrcDelay.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LrcDelay.Location = new System.Drawing.Point(200, 2);
            this.btn_LrcDelay.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LrcDelay.Name = "btn_LrcDelay";
            this.btn_LrcDelay.Size = new System.Drawing.Size(95, 25);
            this.btn_LrcDelay.TabIndex = 1;
            this.btn_LrcDelay.Text = "延迟";
            this.btn_LrcDelay.UseVisualStyleBackColor = false;
            this.btn_LrcDelay.Click += new System.EventHandler(this.btn_LrcDelay_Click);
            // 
            // btn_LrcAhead
            // 
            this.btn_LrcAhead.BackColor = System.Drawing.Color.Transparent;
            this.btn_LrcAhead.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_LrcAhead.Enabled = false;
            this.btn_LrcAhead.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_LrcAhead.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LrcAhead.Location = new System.Drawing.Point(299, 2);
            this.btn_LrcAhead.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LrcAhead.Name = "btn_LrcAhead";
            this.btn_LrcAhead.Size = new System.Drawing.Size(95, 25);
            this.btn_LrcAhead.TabIndex = 2;
            this.btn_LrcAhead.Text = "提前";
            this.btn_LrcAhead.UseVisualStyleBackColor = false;
            this.btn_LrcAhead.Click += new System.EventHandler(this.btn_LrcAhead_Click);
            // 
            // combox_LrcMoveTime
            // 
            this.combox_LrcMoveTime.AllowDrop = true;
            this.combox_LrcMoveTime.AutoCompleteCustomSource.AddRange(new string[] {
            "0.25S",
            "0.5S",
            "1S",
            "2S"});
            this.combox_LrcMoveTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.combox_LrcMoveTime.Enabled = false;
            this.combox_LrcMoveTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.combox_LrcMoveTime.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combox_LrcMoveTime.ForeColor = System.Drawing.SystemColors.WindowText;
            this.combox_LrcMoveTime.ItemHeight = 16;
            this.combox_LrcMoveTime.Items.AddRange(new object[] {
            "0.25S",
            "0.5S",
            "1S",
            "2S"});
            this.combox_LrcMoveTime.Location = new System.Drawing.Point(398, 2);
            this.combox_LrcMoveTime.Margin = new System.Windows.Forms.Padding(2);
            this.combox_LrcMoveTime.Name = "combox_LrcMoveTime";
            this.combox_LrcMoveTime.Size = new System.Drawing.Size(96, 24);
            this.combox_LrcMoveTime.TabIndex = 3;
            this.combox_LrcMoveTime.Text = "0.5S";
            // 
            // btn_LrcAdj
            // 
            this.btn_LrcAdj.BackColor = System.Drawing.Color.Transparent;
            this.btn_LrcAdj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btn_LrcAdj.Enabled = false;
            this.btn_LrcAdj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_LrcAdj.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_LrcAdj.Location = new System.Drawing.Point(2, 2);
            this.btn_LrcAdj.Margin = new System.Windows.Forms.Padding(2);
            this.btn_LrcAdj.Name = "btn_LrcAdj";
            this.btn_LrcAdj.Size = new System.Drawing.Size(95, 25);
            this.btn_LrcAdj.TabIndex = 4;
            this.btn_LrcAdj.Text = "开始调整";
            this.btn_LrcAdj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btn_LrcAdj.UseVisualStyleBackColor = false;
            this.btn_LrcAdj.Click += new System.EventHandler(this.btn_LrcAdj_Click);
            // 
            // lable_LrcFindStatus
            // 
            this.lable_LrcFindStatus.AutoSize = true;
            this.lable_LrcFindStatus.BackColor = System.Drawing.SystemColors.Control;
            this.lable_LrcFindStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lable_LrcFindStatus.Location = new System.Drawing.Point(0, 633);
            this.lable_LrcFindStatus.Margin = new System.Windows.Forms.Padding(0);
            this.lable_LrcFindStatus.Name = "lable_LrcFindStatus";
            this.lable_LrcFindStatus.Size = new System.Drawing.Size(500, 24);
            this.lable_LrcFindStatus.TabIndex = 2;
            this.lable_LrcFindStatus.Text = "                                       ";
            this.lable_LrcFindStatus.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.txtbox_LrcLast, 0, 1);
            this.tableLayoutPanel6.Controls.Add(this.txtbox_LrcCurrent, 0, 2);
            this.tableLayoutPanel6.Controls.Add(this.txtbox_LrcNext, 0, 3);
            this.tableLayoutPanel6.Controls.Add(this.tableLayoutPanel7, 0, 5);
            this.tableLayoutPanel6.Controls.Add(this.grpBox_LogPanel, 0, 4);
            this.tableLayoutPanel6.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(0, 48);
            this.tableLayoutPanel6.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 6;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 104F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 169F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(500, 552);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // txtbox_LrcLast
            // 
            this.txtbox_LrcLast.BackColor = System.Drawing.Color.White;
            this.txtbox_LrcLast.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_LrcLast.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbox_LrcLast.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbox_LrcLast.ForeColor = System.Drawing.Color.Silver;
            this.txtbox_LrcLast.Location = new System.Drawing.Point(2, 29);
            this.txtbox_LrcLast.Margin = new System.Windows.Forms.Padding(2);
            this.txtbox_LrcLast.Multiline = true;
            this.txtbox_LrcLast.Name = "txtbox_LrcLast";
            this.txtbox_LrcLast.Size = new System.Drawing.Size(496, 100);
            this.txtbox_LrcLast.TabIndex = 0;
            this.txtbox_LrcLast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbox_LrcCurrent
            // 
            this.txtbox_LrcCurrent.BackColor = System.Drawing.Color.White;
            this.txtbox_LrcCurrent.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_LrcCurrent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbox_LrcCurrent.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbox_LrcCurrent.ForeColor = System.Drawing.Color.RoyalBlue;
            this.txtbox_LrcCurrent.Location = new System.Drawing.Point(2, 133);
            this.txtbox_LrcCurrent.Margin = new System.Windows.Forms.Padding(2);
            this.txtbox_LrcCurrent.Name = "txtbox_LrcCurrent";
            this.txtbox_LrcCurrent.Size = new System.Drawing.Size(496, 26);
            this.txtbox_LrcCurrent.TabIndex = 1;
            this.txtbox_LrcCurrent.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txtbox_LrcNext
            // 
            this.txtbox_LrcNext.BackColor = System.Drawing.Color.White;
            this.txtbox_LrcNext.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtbox_LrcNext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtbox_LrcNext.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtbox_LrcNext.ForeColor = System.Drawing.Color.Silver;
            this.txtbox_LrcNext.Location = new System.Drawing.Point(2, 170);
            this.txtbox_LrcNext.Margin = new System.Windows.Forms.Padding(2);
            this.txtbox_LrcNext.Multiline = true;
            this.txtbox_LrcNext.Name = "txtbox_LrcNext";
            this.txtbox_LrcNext.Size = new System.Drawing.Size(496, 100);
            this.txtbox_LrcNext.TabIndex = 2;
            this.txtbox_LrcNext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 2;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68F));
            this.tableLayoutPanel7.Controls.Add(this.picBox_AlbumCover, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 384);
            this.tableLayoutPanel7.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 1;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(494, 166);
            this.tableLayoutPanel7.TabIndex = 3;
            // 
            // picBox_AlbumCover
            // 
            this.picBox_AlbumCover.ContextMenuStrip = this.contextMsAlbumCover;
            this.picBox_AlbumCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBox_AlbumCover.Location = new System.Drawing.Point(2, 3);
            this.picBox_AlbumCover.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.picBox_AlbumCover.Name = "picBox_AlbumCover";
            this.picBox_AlbumCover.Size = new System.Drawing.Size(154, 160);
            this.picBox_AlbumCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBox_AlbumCover.TabIndex = 0;
            this.picBox_AlbumCover.TabStop = false;
            this.picBox_AlbumCover.Tag = "             ";
            this.toolTip_Cover.SetToolTip(this.picBox_AlbumCover, "双击预览图片");
            this.picBox_AlbumCover.DoubleClick += new System.EventHandler(this.picBox_AlbumCover_DoubleClick);
            // 
            // contextMsAlbumCover
            // 
            this.contextMsAlbumCover.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_ReplaeAlbumCover,
            this.tsm_DeleteAlbumCover,
            this.tsm_AddAlbumCover});
            this.contextMsAlbumCover.Name = "contextMsAlbumCover";
            this.contextMsAlbumCover.Size = new System.Drawing.Size(125, 70);
            // 
            // tsm_ReplaeAlbumCover
            // 
            this.tsm_ReplaeAlbumCover.Name = "tsm_ReplaeAlbumCover";
            this.tsm_ReplaeAlbumCover.Size = new System.Drawing.Size(124, 22);
            this.tsm_ReplaeAlbumCover.Text = "更换图片";
            this.tsm_ReplaeAlbumCover.Click += new System.EventHandler(this.tsm_ReplaeAlbumCover_Click);
            // 
            // tsm_DeleteAlbumCover
            // 
            this.tsm_DeleteAlbumCover.Name = "tsm_DeleteAlbumCover";
            this.tsm_DeleteAlbumCover.Size = new System.Drawing.Size(124, 22);
            this.tsm_DeleteAlbumCover.Text = "删除图片";
            this.tsm_DeleteAlbumCover.Click += new System.EventHandler(this.tsm_DeleteAlbumCover_Click);
            // 
            // tsm_AddAlbumCover
            // 
            this.tsm_AddAlbumCover.Name = "tsm_AddAlbumCover";
            this.tsm_AddAlbumCover.Size = new System.Drawing.Size(124, 22);
            this.tsm_AddAlbumCover.Text = "添加图片";
            this.tsm_AddAlbumCover.Click += new System.EventHandler(this.tsm_AddAlbumCover_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(161, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 160);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // grpBox_LogPanel
            // 
            this.grpBox_LogPanel.Controls.Add(this.listBox_Log);
            this.grpBox_LogPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBox_LogPanel.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.grpBox_LogPanel.Location = new System.Drawing.Point(3, 275);
            this.grpBox_LogPanel.Name = "grpBox_LogPanel";
            this.grpBox_LogPanel.Size = new System.Drawing.Size(494, 104);
            this.grpBox_LogPanel.TabIndex = 4;
            this.grpBox_LogPanel.TabStop = false;
            this.grpBox_LogPanel.Text = "日志";
            // 
            // listBox_Log
            // 
            this.listBox_Log.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBox_Log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_Log.FormattingEnabled = true;
            this.listBox_Log.Location = new System.Drawing.Point(3, 16);
            this.listBox_Log.Name = "listBox_Log";
            this.listBox_Log.Size = new System.Drawing.Size(488, 85);
            this.listBox_Log.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(500, 27);
            this.label3.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(500, 26);
            this.label1.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(0, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(500, 22);
            this.label2.TabIndex = 4;
            // 
            // openLrcDialog
            // 
            this.openLrcDialog.FileName = "打开歌词文件";
            this.openLrcDialog.Filter = "Lrc文件|*.lrc";
            this.openLrcDialog.Title = "打开歌词文件";
            // 
            // bgw_GetOnlineAlbumCover
            // 
            this.bgw_GetOnlineAlbumCover.WorkerReportsProgress = true;
            this.bgw_GetOnlineAlbumCover.WorkerSupportsCancellation = true;
            this.bgw_GetOnlineAlbumCover.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_GetOnlineAlbumCover_DoWork);
            this.bgw_GetOnlineAlbumCover.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_GetOnlineAlbumCover_ProgressChanged);
            // 
            // bgw_GetOnlineLrc
            // 
            this.bgw_GetOnlineLrc.WorkerReportsProgress = true;
            this.bgw_GetOnlineLrc.WorkerSupportsCancellation = true;
            this.bgw_GetOnlineLrc.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_GetOnlineLrc_DoWork);
            this.bgw_GetOnlineLrc.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_GetOnlineLrc_ProgressChanged);
            // 
            // bgw_AddFileProcess
            // 
            this.bgw_AddFileProcess.WorkerReportsProgress = true;
            this.bgw_AddFileProcess.WorkerSupportsCancellation = true;
            this.bgw_AddFileProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_AddFileProcess_DoWork);
            this.bgw_AddFileProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_AddFileProcess_ProgressChanged);
            this.bgw_AddFileProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_AddFileProcess_RunWorkerCompleted);
            // 
            // bgw_AddDirProcess
            // 
            this.bgw_AddDirProcess.WorkerReportsProgress = true;
            this.bgw_AddDirProcess.WorkerSupportsCancellation = true;
            this.bgw_AddDirProcess.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_AddDirProcess_DoWork);
            this.bgw_AddDirProcess.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bgw_AddDirProcess_ProgressChanged);
            this.bgw_AddDirProcess.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bgw_AddDirProcess_RunWorkerCompleted);
            // 
            // abx_LrcCurrent
            // 
            this.abx_LrcCurrent.AlphaAmount = 0;
            this.abx_LrcCurrent.AlphaBackColor = System.Drawing.Color.Empty;
            this.abx_LrcCurrent.BackColor = System.Drawing.Color.Transparent;
            this.abx_LrcCurrent.Location = new System.Drawing.Point(0, 0);
            this.abx_LrcCurrent.Name = "abx_LrcCurrent";
            this.abx_LrcCurrent.Size = new System.Drawing.Size(100, 20);
            this.abx_LrcCurrent.TabIndex = 0;
            // 
            // abx_LrcLast
            // 
            this.abx_LrcLast.AlphaAmount = 0;
            this.abx_LrcLast.AlphaBackColor = System.Drawing.Color.Empty;
            this.abx_LrcLast.BackColor = System.Drawing.Color.Transparent;
            this.abx_LrcLast.Location = new System.Drawing.Point(0, 0);
            this.abx_LrcLast.Name = "abx_LrcLast";
            this.abx_LrcLast.Size = new System.Drawing.Size(100, 20);
            this.abx_LrcLast.TabIndex = 0;
            // 
            // abx_LrcNext
            // 
            this.abx_LrcNext.AlphaAmount = 0;
            this.abx_LrcNext.AlphaBackColor = System.Drawing.Color.Empty;
            this.abx_LrcNext.BackColor = System.Drawing.Color.Transparent;
            this.abx_LrcNext.Location = new System.Drawing.Point(0, 0);
            this.abx_LrcNext.Name = "abx_LrcNext";
            this.abx_LrcNext.Size = new System.Drawing.Size(100, 20);
            this.abx_LrcNext.TabIndex = 0;
            // 
            // contextms_DgvColunmVisable
            // 
            this.contextms_DgvColunmVisable.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_DgvColumnArtistVisable,
            this.tsm_DgvColumnTitleVisable,
            this.tsm_DgvColumnAlbumVisable,
            this.tsm_DgvColumnDurationVisable,
            this.tsm_DgvColumnCodeVisable});
            this.contextms_DgvColunmVisable.Name = "contextms_DgvColunmVisable";
            this.contextms_DgvColunmVisable.Size = new System.Drawing.Size(125, 114);
            // 
            // tsm_DgvColumnArtistVisable
            // 
            this.tsm_DgvColumnArtistVisable.Checked = true;
            this.tsm_DgvColumnArtistVisable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsm_DgvColumnArtistVisable.Name = "tsm_DgvColumnArtistVisable";
            this.tsm_DgvColumnArtistVisable.Size = new System.Drawing.Size(124, 22);
            this.tsm_DgvColumnArtistVisable.Text = "演唱者";
            this.tsm_DgvColumnArtistVisable.Click += new System.EventHandler(this.tsm_DgvColumnArtistVisable_Click);
            // 
            // tsm_DgvColumnTitleVisable
            // 
            this.tsm_DgvColumnTitleVisable.Checked = true;
            this.tsm_DgvColumnTitleVisable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsm_DgvColumnTitleVisable.Name = "tsm_DgvColumnTitleVisable";
            this.tsm_DgvColumnTitleVisable.Size = new System.Drawing.Size(124, 22);
            this.tsm_DgvColumnTitleVisable.Text = "歌名";
            this.tsm_DgvColumnTitleVisable.Click += new System.EventHandler(this.tsm_DgvColumnTitleVisable_Click);
            // 
            // tsm_DgvColumnAlbumVisable
            // 
            this.tsm_DgvColumnAlbumVisable.Checked = true;
            this.tsm_DgvColumnAlbumVisable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsm_DgvColumnAlbumVisable.Name = "tsm_DgvColumnAlbumVisable";
            this.tsm_DgvColumnAlbumVisable.Size = new System.Drawing.Size(124, 22);
            this.tsm_DgvColumnAlbumVisable.Text = "专辑";
            this.tsm_DgvColumnAlbumVisable.Click += new System.EventHandler(this.tsm_DgvColumnAlbumVisable_Click);
            // 
            // tsm_DgvColumnDurationVisable
            // 
            this.tsm_DgvColumnDurationVisable.Name = "tsm_DgvColumnDurationVisable";
            this.tsm_DgvColumnDurationVisable.Size = new System.Drawing.Size(124, 22);
            this.tsm_DgvColumnDurationVisable.Text = "时长";
            this.tsm_DgvColumnDurationVisable.Click += new System.EventHandler(this.tsm_DgvColumnDurationVisable_Click);
            // 
            // tsm_DgvColumnCodeVisable
            // 
            this.tsm_DgvColumnCodeVisable.Name = "tsm_DgvColumnCodeVisable";
            this.tsm_DgvColumnCodeVisable.Size = new System.Drawing.Size(124, 22);
            this.tsm_DgvColumnCodeVisable.Text = "编码方式";
            this.tsm_DgvColumnCodeVisable.Click += new System.EventHandler(this.tsm_DgvColumnCodeVisable_Click);
            // 
            // form_Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 657);
            this.Controls.Add(this.menuStrip_Menu);
            this.Controls.Add(this.statusStrip_ChannalInfo);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.tabPlanel_Lrc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip_Menu;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(416, 564);
            this.Name = "form_Main";
            this.Text = "MusicPlayer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.form_Main_FormCloseing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.form_Main_KeyDown);
            this.menuStrip_Menu.ResumeLayout(false);
            this.menuStrip_Menu.PerformLayout();
            this.contextMsPlaylist.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.statusStrip_ChannalInfo.ResumeLayout(false);
            this.statusStrip_ChannalInfo.PerformLayout();
            this.tabPlanel_Lrc.ResumeLayout(false);
            this.tabPlanel_Lrc.PerformLayout();
            this.tableLayoutPanel5.ResumeLayout(false);
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.tableLayoutPanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picBox_AlbumCover)).EndInit();
            this.contextMsAlbumCover.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpBox_LogPanel.ResumeLayout(false);
            this.contextms_DgvColunmVisable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip_Menu;
        private System.Windows.Forms.ToolStripMenuItem FilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_AddSongs;
        private System.Windows.Forms.ToolStripMenuItem ts_AddDir;
        private System.Windows.Forms.ToolStripMenuItem ts_NewPlaylist;
        private System.Windows.Forms.ToolStripMenuItem ts_ImportPlaylist;
        private System.Windows.Forms.ToolStripMenuItem ts_ExportPlaylist;
        private System.Windows.Forms.TabControl tc_MusicLib;
        private System.Windows.Forms.ToolStripMenuItem LrcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ts_FindLrc;
        private System.Windows.Forms.ToolStripMenuItem ts_OpenLrc;
        private System.Windows.Forms.ToolStripMenuItem ts_OpenLrcPlane;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.FolderBrowserDialog AddDirDialog;
        private System.Windows.Forms.ToolStripMenuItem PlaylistToolStripMenuItem;
        private System.Windows.Forms.Timer tmr_Tick;
        private System.Windows.Forms.ToolStripMenuItem ts_ImportMusicLib;
        private System.Windows.Forms.ToolStripMenuItem ts_ExportMusicLib;
        private System.Windows.Forms.ToolStripMenuItem ts_Close;
        private System.Windows.Forms.ContextMenuStrip contextMsPlaylist;
        private System.Windows.Forms.ToolStripMenuItem tsm_RemoveFormPlaylist;
        private System.Windows.Forms.ToolStripMenuItem tsm_DeleteSongs;
        private System.Windows.Forms.ToolStripMenuItem tsm_PlaySong;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tsm_MoveTo;
        private System.Windows.Forms.ToolStripMenuItem tsm_CopyTo;
        private System.Windows.Forms.ToolStripMenuItem tsm_SavePlaylistAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem tsm_DeleteCurrentPlaylist;
        private System.Windows.Forms.ToolStripMenuItem ts_LrcSetting;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem ts_DeleteCurrentPlaylist;
        private System.Windows.Forms.Label lab_CurrentPlayTime;
        private System.Windows.Forms.Label lab_SongLastTime;
        private System.Windows.Forms.Button btn_Play;
        private System.Windows.Forms.Button btn_Next;
        private System.Windows.Forms.Button btn_Previous;
        private System.Windows.Forms.Button btn_Pause;
        private System.Windows.Forms.Button btn_Stop;
        private System.Windows.Forms.HScrollBar hsb_PlayProcessBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripDropDownButton tsm_DropDownButtonLoopMode;
        private System.Windows.Forms.ToolStripMenuItem tsm_LoopModeSingle;
        private System.Windows.Forms.ToolStripMenuItem tsm_LoopModeRandom;
        private System.Windows.Forms.ToolStripMenuItem tsm_LoopModeOrder;
        private System.Windows.Forms.StatusStrip statusStrip_ChannalInfo;
        private System.Windows.Forms.ToolStripStatusLabel tsm_LabelChannalInfo;
        private System.Windows.Forms.TableLayoutPanel tabPlanel_Lrc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.Button btn_LrcSave;
        private System.Windows.Forms.Button btn_LrcDelay;
        private System.Windows.Forms.Button btn_LrcAhead;
        private System.Windows.Forms.Button btn_LrcAdj;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.TextBox txtbox_LrcLast;
        private System.Windows.Forms.TextBox txtbox_LrcCurrent;
        private System.Windows.Forms.TextBox txtbox_LrcNext;
        private System.Windows.Forms.OpenFileDialog openLrcDialog;
        private System.Windows.Forms.Label lable_LrcFindStatus;
        private System.Windows.Forms.ComboBox combox_LrcMoveTime;
        private System.Windows.Forms.ToolStripMenuItem ts_DeleteCurrentLrc;
        private System.Windows.Forms.ToolStripMenuItem ts_RenameCurrentPlaylist;
        private System.Windows.Forms.ToolStripMenuItem tsm_RenameCurrentPlaylist;
        private AlphaTextBox abx_LrcCurrent = new AlphaTextBox();
        private AlphaTextBox abx_LrcLast = new AlphaTextBox();
        private AlphaTextBox abx_LrcNext = new AlphaTextBox();
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.PictureBox picBox_AlbumCover;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpBox_LogPanel;
        private System.Windows.Forms.ListBox listBox_Log;
        private System.ComponentModel.BackgroundWorker bgw_GetOnlineAlbumCover;
        private System.ComponentModel.BackgroundWorker bgw_GetOnlineLrc;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem tsm_LrcSeach;
        private System.Windows.Forms.ToolStripMenuItem tsm_CoverSeach;
        private System.Windows.Forms.ContextMenuStrip contextMsAlbumCover;
        private System.Windows.Forms.ToolStripMenuItem tsm_ReplaeAlbumCover;
        private System.Windows.Forms.ToolStripMenuItem tsm_DeleteAlbumCover;
        private System.Windows.Forms.ToolStripMenuItem tsm_AddAlbumCover;
        private System.Windows.Forms.ToolTip toolTip_Cover;
        private System.ComponentModel.BackgroundWorker bgw_AddFileProcess;
        private System.ComponentModel.BackgroundWorker bgw_AddDirProcess;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripMenuItem 自动匹配在线专辑封面ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 搜寻本地专辑封面在ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem ts_Setting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextms_DgvColunmVisable;
        private System.Windows.Forms.ToolStripMenuItem tsm_DgvColumnArtistVisable;
        private System.Windows.Forms.ToolStripMenuItem tsm_DgvColumnTitleVisable;
        private System.Windows.Forms.ToolStripMenuItem tsm_DgvColumnAlbumVisable;
        private System.Windows.Forms.ToolStripMenuItem tsm_DgvColumnDurationVisable;
        private System.Windows.Forms.ToolStripMenuItem tsm_DgvColumnCodeVisable;
    }
}

