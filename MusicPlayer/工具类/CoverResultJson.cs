using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class CoverResult
    {
        /// <summary>
        /// 集合类型
        /// </summary>
        public string wrapperType { get; set; }
        /// <summary>
        /// 专辑类型
        /// </summary>
        public string collectionType { get; set; }
        /// <summary>
        /// 艺术家ID
        /// </summary>
        public int artistId { get; set; }
        /// <summary>
        /// 专辑ID
        /// </summary>
        public int collectionId { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public int amgArtistId { get; set; }
        /// <summary>
        /// 艺术家名称
        /// </summary>
        public string artistName { get; set; }
        /// <summary>
        /// 专辑名称
        /// </summary>
        public string collectionName { get; set; }
        /// <summary>
        /// 专辑主名称
        /// </summary>
        public string collectionCensoredName { get; set; }
        /// <summary>
        /// 艺术家主页
        /// </summary>
        public string artistViewUrl { get; set; }
        /// <summary>
        /// 专辑主页
        /// </summary>
        public string collectionViewUrl { get; set; }
        /// <summary>
        /// 60*60分辨率封面
        /// </summary>
        public string artworkUrl60 { get; set; }
        /// <summary>
        /// 100*100分辨率封面
        /// </summary>
        public string artworkUrl100 { get; set; }
        /// <summary>
        /// 专辑价格
        /// </summary>
        public double collectionPrice { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string collectionExplicitness { get; set; }
        /// <summary>
        /// 曲目数
        /// </summary>
        public int trackCount { get; set; }
        /// <summary>
        /// 版权
        /// </summary>
        public string copyright { get; set; }
        /// <summary>
        /// 国家
        /// </summary>
        public string country { get; set; }
        /// <summary>
        /// 币别
        /// </summary>
        public string currency { get; set; }
        /// <summary>
        /// 发行日期
        /// </summary>
        public string releaseDate { get; set; }
        /// <summary>
        /// 主通用名称
        /// </summary>
        public string primaryGenreName { get; set; }
    }

    public class CoverResultJson
    {
        /// <summary>
        /// 结果数量
        /// </summary>
        public int resultCount { get; set; }
        /// <summary>
        /// 结果
        /// </summary>
        public List<CoverResult> results { get; set; }
    }

}

