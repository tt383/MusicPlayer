using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class LrcDt
    {
        public bool bIsLrcValid
        {
            get;
            private set;
        }

        /// <summary>
        /// 歌曲
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 艺术家
        /// </summary>
        public string Artist { get; set; }

        /// <summary>
        /// 专辑
        /// </summary>
        public string Album { get; set; }

        /// <summary>
        /// 歌词作者
        /// </summary>
        public string LrcBy { get; set; }

        /// <summary>
        /// 偏移量
        /// </summary>
        public string Offset { get; set; }

        /// <summary>
        /// 歌词
        /// </summary>
        public DataTable LrcWord = new DataTable();

        /// <summary>
        /// LCR歌词路径
        /// </summary>
        public string LrcPath = "";

        /// <summary>
        /// 获得歌词信息
        /// </summary>
        /// <param name="LrcPath">歌词路径</param>
        /// <returns>返回歌词信息(Lrc实例)</returns>
        public static LrcDt InitLrc(string lrcpath)
        {
            LrcDt lrc = new LrcDt();

            DataTable dtword = new DataTable();
            dtword.Columns.Add("TimeTag", Type.GetType("System.Double"));
            dtword.Columns.Add("LrcWord", Type.GetType("System.String"));
            using (FileStream fs = new FileStream(lrcpath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                string line;
                using (StreamReader sr = OpenStream(fs,Encoding.UTF8,Encoding.Default))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("[ti:"))
                        {
                            lrc.Title = SplitInfo(line);
                            dtword.TableName = lrc.Title;
                        }
                        else if (line.StartsWith("[ar:"))
                        {
                            lrc.Artist = SplitInfo(line);
                        }
                        else if (line.StartsWith("[al:"))
                        {
                            lrc.Album = SplitInfo(line);
                        }
                        else if (line.StartsWith("[by:"))
                        {
                            lrc.LrcBy = SplitInfo(line);
                        }
                        else if (line.StartsWith("[offset:"))
                        {
                            lrc.Offset = SplitInfo(line);
                        }
                        else
                        {
                            try
                            {
                                // Regex regexword = new Regex(@".*\](.*)");
                                Regex regexword = new Regex(@".*\](.*)");
                                Match mcw = regexword.Match(line);
                                string word = mcw.Groups[1].Value;
                                Regex regextime = new Regex(@"\[([0-9.:]*)\]", RegexOptions.Compiled);
                                MatchCollection mct = regextime.Matches(line);
                                foreach (Match item in mct)
                                {
                                    double time = TimeSpan.Parse("00:" + item.Groups[1].Value).TotalSeconds;
                                    dtword.Rows.Add(time, word);
                                }
                            }
                            catch
                            {
                                continue;
                            }
                           
                        }
                    }
                }
            }

            if (dtword.Rows.Count > 0)
            {
                DataView dv = dtword.DefaultView;
                dv.Sort = "TimeTag";
                lrc.LrcWord = dv.ToTable();
                lrc.LrcPath = lrcpath;
                return lrc;
                //lrc.bIsLrcValid = true;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// 处理信息(私有方法)
        /// </summary>
        /// <param name="line"></param>
        /// <returns>返回基础信息</returns>
        static string SplitInfo(string line)
        {
            return line.Substring(line.IndexOf(":") + 1).TrimEnd(']');
        }

        /// <summary>
        /// 清空歌词内容
        /// </summary>
        public void Free()
        {
            Title = String.Empty;
            Album = String.Empty;
            Artist = String.Empty;
            Offset = String.Empty;
            LrcBy = String.Empty;
            LrcPath = String.Empty;
            LrcWord = new DataTable();
        }

        private static StreamReader OpenStream(FileStream fs, Encoding suggestedEncoding, Encoding defaultEncoding)
        {
            if (fs.Length > 3)
            {
                // the autodetection of StreamReader is not capable of detecting the difference
                // between ISO-8859-1 and UTF-8 without BOM.
                int firstByte = fs.ReadByte();
                int secondByte = fs.ReadByte();
                switch ((firstByte << 8) | secondByte)
                {
                    case 0x0000: // either UTF-32 Big Endian or a binary file; use StreamReader
                    case 0xfffe: // Unicode BOM (UTF-16 LE or UTF-32 LE)
                    case 0xfeff: // UTF-16 BE BOM
                    case 0xefbb: // start of UTF-8 BOM
                        // StreamReader autodetection works
                        fs.Position = 0;
                        return new StreamReader(fs);
                    default:
                        return AutoDetect(fs, (byte)firstByte, (byte)secondByte, defaultEncoding);
                }
            }
            else
            {
                if (suggestedEncoding != null)
                {
                    return new StreamReader(fs, suggestedEncoding);
                }
                else
                {
                    return new StreamReader(fs);
                }
            }
        }

        static StreamReader AutoDetect(FileStream fs, byte firstByte, byte secondByte, Encoding defaultEncoding)
        {
            int max = (int)Math.Min(fs.Length, 500000); // look at max. 500 KB
            const int ASCII = 0;
            const int Error = 1;
            const int UTF8 = 2;
            const int UTF8Sequence = 3;
            int state = ASCII;
            int sequenceLength = 0;
            byte b;
            for (int i = 0; i < max; i++)
            {
                if (i == 0)
                {
                    b = firstByte;
                }
                else if (i == 1)
                {
                    b = secondByte;
                }
                else
                {
                    b = (byte)fs.ReadByte();
                }
                if (b < 0x80)
                {
                    // normal ASCII character
                    if (state == UTF8Sequence)
                    {
                        state = Error;
                        break;
                    }
                }
                else if (b < 0xc0)
                {
                    // 10xxxxxx : continues UTF8 byte sequence
                    if (state == UTF8Sequence)
                    {
                        --sequenceLength;
                        if (sequenceLength < 0)
                        {
                            state = Error;
                            break;
                        }
                        else if (sequenceLength == 0)
                        {
                            state = UTF8;
                        }
                    }
                    else
                    {
                        state = Error;
                        break;
                    }
                }
                else if (b >= 0xc2 && b < 0xf5)
                {
                    // beginning of byte sequence
                    if (state == UTF8 || state == ASCII)
                    {
                        state = UTF8Sequence;
                        if (b < 0xe0)
                        {
                            sequenceLength = 1; // one more byte following
                        }
                        else if (b < 0xf0)
                        {
                            sequenceLength = 2; // two more bytes following
                        }
                        else
                        {
                            sequenceLength = 3; // three more bytes following
                        }
                    }
                    else
                    {
                        state = Error;
                        break;
                    }
                }
                else
                {
                    // 0xc0, 0xc1, 0xf5 to 0xff are invalid in UTF-8 (see RFC 3629)
                    state = Error;
                    break;
                }
            }
            fs.Position = 0;
            switch (state)
            {
                case ASCII:
                case Error:
                    // when the file seems to be ASCII or non-UTF8,
                    // we read it using the user-specified encoding so it is saved again
                    // using that encoding.
                    if (IsUnicode(defaultEncoding))
                    {
                        // the file is not Unicode, so don't read it using Unicode even if the
                        // user has choosen Unicode as the default encoding.

                        // If we don't do this, SD will end up always adding a Byte Order Mark
                        // to ASCII files.
                        defaultEncoding = Encoding.Default; // use system encoding instead
                    }
                    return new StreamReader(fs, defaultEncoding);
                default:
                    return new StreamReader(fs);
            }
        }

        private static bool IsUnicode(Encoding encoding)
        {
            int codepage = encoding.CodePage;
            // return true if codepage is any UTF codepage
            return codepage == 65001 || codepage == 65000 || codepage == 1200 || codepage == 1201;
        }
    }
}

