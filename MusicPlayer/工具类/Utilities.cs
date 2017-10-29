using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace MusicPlayer
{
    class Utilities
    {

        #region XmlDocment,DataSet互转
        /// <summary>
        /// DataSet转换为XmlDocument
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns>XmlDocument</returns>
        public static XmlDocument GetXmlDocFormDS(DataSet ds)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                using (MemoryStream mStrm = new MemoryStream())
                {

                    StreamReader sRead = new StreamReader(mStrm);

                    ds.WriteXml(mStrm, XmlWriteMode.IgnoreSchema);

                    mStrm.Seek(0, SeekOrigin.Begin);

                    doc.Load(sRead);
                }
            }
            catch (Exception ex)
            {
                //sendLog(ex.ToString());
                throw new Exception(ex.ToString());
            }
            return doc;
        }

        /// <summary>
        /// XmlDocument转换为DataSet
        /// </summary>
        /// <param name="doc">XmlDocument</param>
        /// <returns>DataSet</returns>
        public static DataSet GetDSFormXmlDoc(XmlDocument doc)
        {
            DataSet ds = new DataSet();
            try
            {
                using (XmlNodeReader reader = new XmlNodeReader(doc))
                {
                    ds.ReadXml(reader);

                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                //sendLog(ex.ToString());
                throw new Exception(ex.ToString());
            }
            return ds;
        }

        #endregion

        #region 获取文本文件编码方式
        /// <summary>   
        /// 取得一个文本文件的编码方式。如果无法在文件头部找到有效的前导符，Encoding.Default将被返回。   
        /// </summary>   
        /// <param name="fileName">文件名。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(string fileName)
        {
            return GetEncoding(fileName, Encoding.Default);
        }
        /// <summary>   
        /// 取得一个文本文件流的编码方式。   
        /// </summary>   
        /// <param name="stream">文本文件流。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(FileStream stream)
        {
            return GetEncoding(stream, Encoding.Default);
        }
        /// <summary>   
        /// 取得一个文本文件的编码方式。   
        /// </summary>   
        /// <param name="fileName">文件名。</param>   
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(string fileName, Encoding defaultEncoding)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            Encoding targetEncoding = GetEncoding(fs, defaultEncoding);
            fs.Close();
            return targetEncoding;
        }
        /// <summary>   
        /// 取得一个文本文件流的编码方式。   
        /// </summary>   
        /// <param name="stream">文本文件流。</param>   
        /// <param name="defaultEncoding">默认编码方式。当该方法无法从文件的头部取得有效的前导符时，将返回该编码方式。</param>   
        /// <returns></returns>   
        public static Encoding GetEncoding(FileStream stream, Encoding defaultEncoding)
        {
            Encoding targetEncoding = defaultEncoding;
            if (stream != null && stream.Length >= 2)
            {
                //保存文件流的前4个字节   
                byte byte1 = 0;
                byte byte2 = 0;
                byte byte3 = 0;
                byte byte4 = 0;
                //保存当前Seek位置   
                long origPos = stream.Seek(0, SeekOrigin.Begin);
                stream.Seek(0, SeekOrigin.Begin);

                int nByte = stream.ReadByte();
                byte1 = Convert.ToByte(nByte);
                byte2 = Convert.ToByte(stream.ReadByte());
                if (stream.Length >= 3)
                {
                    byte3 = Convert.ToByte(stream.ReadByte());
                }
                if (stream.Length >= 4)
                {
                    byte4 = Convert.ToByte(stream.ReadByte());
                }
                //根据文件流的前4个字节判断Encoding   
                //Unicode {0xFF, 0xFE};   
                //BE-Unicode {0xFE, 0xFF};   
                //UTF8 = {0xEF, 0xBB, 0xBF};   
                if (byte1 == 0xFE && byte2 == 0xFF)//UnicodeBe   
                {
                    targetEncoding = Encoding.BigEndianUnicode;
                }
                if (byte1 == 0xFF && byte2 == 0xFE && byte3 != 0xFF)//Unicode   
                {
                    targetEncoding = Encoding.Unicode;
                }
                if (byte1 == 0xEF && byte2 == 0xBB && byte3 == 0xBF)//UTF8   
                {
                    targetEncoding = Encoding.UTF8;
                }
                //恢复Seek位置         
                stream.Seek(origPos, SeekOrigin.Begin);
            }
            return targetEncoding;
        }



        // 新增加一个方法，解决了不带BOM的 UTF8 编码问题   

        /// <summary>   
        /// 通过给定的文件流，判断文件的编码类型   
        /// </summary>   
        /// <param name="fs">文件流</param>   
        /// <returns>文件的编码类型</returns>   
        public static System.Text.Encoding GetEncoding(Stream fs)
        {
            byte[] Unicode = new byte[] { 0xFF, 0xFE, 0x41 };
            byte[] UnicodeBIG = new byte[] { 0xFE, 0xFF, 0x00 };
            byte[] UTF8 = new byte[] { 0xEF, 0xBB, 0xBF }; //带BOM   
            Encoding reVal = Encoding.Default;

            BinaryReader r = new BinaryReader(fs, System.Text.Encoding.Default);
            byte[] ss = r.ReadBytes(4);
            if (ss[0] == 0xFE && ss[1] == 0xFF && ss[2] == 0x00)
            {
                reVal = Encoding.BigEndianUnicode;
            }
            else if (ss[0] == 0xFF && ss[1] == 0xFE && ss[2] == 0x41)
            {
                reVal = Encoding.Unicode;
            }
            else
            {
                if (ss[0] == 0xEF && ss[1] == 0xBB && ss[2] == 0xBF)
                {
                    reVal = Encoding.UTF8;
                }
                else
                {
                    int i;
                    int.TryParse(fs.Length.ToString(), out i);
                    ss = r.ReadBytes(i);

                    if (IsUTF8Bytes(ss))
                        reVal = Encoding.UTF8;
                }
            }
            r.Close();
            return reVal;

        }

        /// <summary>   
        /// 判断是否是不带 BOM 的 UTF8 格式   
        /// </summary>   
        /// <param name="data"></param>   
        /// <returns></returns>   
        private static bool IsUTF8Bytes(byte[] data)
        {
            int charByteCounter = 1;  //计算当前正分析的字符应还有的字节数   
            byte curByte; //当前分析的字节.   
            for (int i = 0; i < data.Length; i++)
            {
                curByte = data[i];
                if (charByteCounter == 1)
                {
                    if (curByte >= 0x80)
                    {
                        //判断当前   
                        while (((curByte <<= 1) & 0x80) != 0)
                        {
                            charByteCounter++;
                        }
                        //标记位首位若为非0 则至少以2个1开始 如:110XXXXX...........1111110X　   
                        if (charByteCounter == 1 || charByteCounter > 6)
                        {
                            return false;
                        }
                    }
                }
                else
                {
                    //若是UTF-8 此时第一位必须为1   
                    if ((curByte & 0xC0) != 0x80)
                    {
                        return false;
                    }
                    charByteCounter--;
                }
            }
            if (charByteCounter > 1)
            {
                throw new Exception("非预期的byte格式!");
            }
            return true;
        }

        #endregion

        #region HTTP模板

        private enum Compression
        {
            GZip,
            Deflate,
            None,
        }

        /// <summary>
        /// 获取HttpWebRequest模板
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postdata">POST</param>
        /// <returns></returns>
        public static HttpWebRequest GetHttpRequest(string url, string postdata)
        {
            HttpWebRequest request = HttpWebRequest.Create(new Uri(url)) as HttpWebRequest;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ServicePoint.ConnectionLimit = 300;
            request.Referer = url;
            request.Accept = "*/*"; ;
            request.UserAgent = "Mozilla/4.0 (compatible; MSIE 8.0; Windows NT 6.1; Trident/4.0; SLCC2; .NET CLR 2.0.50727; .NET CLR 3.5.30729; .NET CLR 3.0.30729; Media Center PC 6.0; .NET4.0C; .NET4.0E)";
            request.AllowAutoRedirect = true;
            if (postdata != null && postdata != "")
            {
                request.Method = "POST";
                byte[] byte_post = Encoding.Default.GetBytes(postdata);
                request.ContentLength = byte_post.Length;
                using (Stream stream = request.GetRequestStream())
                {
                    stream.Write(byte_post, 0, byte_post.Length);
                }
            }
            else
            {
                request.Method = "GET";
            }
            return request;
        }

        /// <summary>
        /// 获取HttpWebRequest返回值
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postdata">PostData</param>
        /// <returns></returns>
        public static string GetHttpResult(string url, string postdata, string charset)
        {
            HttpWebRequest request = GetHttpRequest(url, postdata);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return GetResponseContent(response, charset);
        }

        /// <summary>
        /// 获取HttpWebRequest返回值
        /// </summary>
        /// <param name="url">URL地址</param>
        /// <param name="postdata">PostData</param>
        /// <returns></returns>
        public static string GetHttpResult(string url, string postdata)
        {
            HttpWebRequest request = GetHttpRequest(url, postdata);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            return GetResponseContent(response, "");
        }

        /// <summary>
        /// 提取HttpWebResponse文本内容
        /// </summary>
        /// <param name="resp">HttpWebResponse响应包</param>
        /// <returns></returns>
        public static string GetResponseContent(HttpWebResponse resp, string charset)
        {

            if (resp.StatusCode != HttpStatusCode.OK)
                throw new Exception("远程服务器返回状态码: " + resp.StatusCode);

            if (charset == null || charset == "")
                charset = "gb2312";
            Encoding enc = Encoding.GetEncoding(charset);
            //if (resp.CharacterSet != "")
            //    enc = Encoding.GetEncoding(resp.CharacterSet);

            Compression comp = Compression.None;
            if (resp.ContentEncoding != null && resp.ContentEncoding.Trim().ToUpper() == "GZIP")
                comp = Compression.GZip;
            else if (resp.ContentEncoding != null && resp.ContentEncoding.Trim().ToUpper() == "DEFLATE")
                comp = Compression.Deflate;

            MemoryStream ms = new MemoryStream();
            using (StreamWriter sw = new StreamWriter(ms, enc))
            {
                StreamReader sr;
                switch (comp)
                {
                    case Compression.GZip:
                        sr = new StreamReader(new System.IO.Compression.GZipStream(resp.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress), enc);
                        break;
                    case Compression.Deflate:
                        sr = new StreamReader(new System.IO.Compression.DeflateStream(resp.GetResponseStream(), System.IO.Compression.CompressionMode.Decompress), enc);
                        break;
                    default:
                        sr = new StreamReader(resp.GetResponseStream(), enc);
                        break;
                }

                while (!sr.EndOfStream)
                {
                    char[] buf = new char[16000];
                    int read = sr.ReadBlock(buf, 0, 16000);
                    StringBuilder sb = new StringBuilder();
                    sb.Append(buf, 0, read);
                    sw.Write(buf, 0, read);
                }
                sr.Close();
            }

            byte[] mbuf = ms.GetBuffer();
            string sbuf = enc.GetString(mbuf);
            return sbuf;
        }

        /// <summary>
        /// Http下载文件
        /// </summary>
        /// <param name="url">要下载的文件地址</param>
        /// <param name="path">文件保存路径</param>
        /// <returns>下载到的文件路径</returns>
        public static string HttpDownloadFile(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;

            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            return path;
        }

        /// <summary>
        /// 搜索DataGridView
        /// </summary>
        /// <param name="DGV">目标DataGridView</param>
        /// <param name="strTxt">关键词</param>
        /// <param name="UpSearch">搜索方向</param>
        /// <param name="Show">匹配后是否提示</param>
        /// <returns></returns>
        public static bool SearchDGV(DataGridView DGV, string strTxt, bool UpSearch = true, bool Show = false )
        {
            int row = DGV.Rows.Count;//得到总行数  
            int cell = DGV.Rows[1].Cells.Count;//得到总列数  
            int curr = DGV.CurrentRow.Index;
            Regex r = new Regex(strTxt); // 定义一个Regex对象实例   
            for (int i = curr + 1; i < row; i++)//得到总行数并在之内循环  
            {
                for (int j = 0; j < cell; j++)//得到总列数并在之内循环  
                {
                    if (DGV.Columns[j].Visible == true)
                    {
                        Match m = r.Match(DGV.Rows[i].Cells[j].Value.ToString()); // 在字符串中模糊匹配   
                        if (m.Success)
                        {   //对比TexBox中的值是否与dataGridView中的值相同（上面这句）

                            //DGV.ClearSelection();
                            //DGV.Rows[i].Selected = true;//定位到相同的单元格
                            DGV.CurrentCell = DGV[j, i];
                            //DGV.S  
                            if (Show)
                            {
                                if (MessageBox.Show("是否需要继续查找？", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                {
                                    //如果选择了取消就会返回,如果选择了确定,就会继续查找匹配的.  
                                    return true;//返回  
                                }
                            }
                            else
                            {
                                return true;
                            }
                        }
                    }
                    else
                        continue;
                }
            }
            if (UpSearch)
            {
                for (int i = 0; i < curr; i++)//得到总行数并在之内循环  
                {
                    for (int j = 0; j < cell; j++)//得到总列数并在之内循环  
                    {
                        if (DGV.Columns[j].Visible == true)
                        {
                            Match m = r.Match(DGV.Rows[i].Cells[j].Value.ToString()); // 在字符串中模糊匹配   
                            if (m.Success)
                            {   //对比TexBox中的值是否与dataGridView中的值相同（上面这句）  
                                // DGV.Rows[i].Selected = true;//定位到相同的单元格  
                                DGV.CurrentCell = DGV[j, i];
                                if (Show)
                                {
                                    if (MessageBox.Show("是否需要继续查找？", "", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                                    {
                                        //如果选择了取消就会返回,如果选择了确定,就会继续查找匹配的.  
                                        return true;//返回  
                                    }
                                }
                                else
                                {
                                    return true;
                                }
                            }
                        }
                        else
                            continue;
                    }
                }
            }
            return false;
        }
        #endregion

    }
}
