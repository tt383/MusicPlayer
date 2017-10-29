using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class LrcJsonRes
    {
        /// <summary>
        /// 专辑ID
        /// </summary>
        public int aid { get; set; }
        /// <summary>
        /// 歌手ID
        /// </summary>
        public int artist_id { get; set; }
        /// <summary>
        /// 歌词地址
        /// </summary>
        public string lrc { get; set; }
        /// <summary>
        /// 歌曲ID
        /// </summary>
        public int sid { get; set; }
        /// <summary>
        /// 歌曲名称
        /// </summary>
        public string song { get; set; }
    }

    public class LrcJson
    {
        /// <summary>
        /// 
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public List<LrcJsonRes> result { get; set; }
    }
}
