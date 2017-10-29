using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    class DirectoryList
    {
        /*利用静态数据来存储文件路径列表*/
        private static ArrayList directorysList = new ArrayList();//存储目录列表数据

        public static ArrayList DirectorysList
        {
            get { return DirectoryList.directorysList; }
            set { DirectoryList.directorysList = value; }
        }
        private static ArrayList fileList = new ArrayList();//存储文件路径列表

        public static ArrayList FileList
        {
            get { return DirectoryList.fileList; }
            set { DirectoryList.fileList = value; }
        }
        public static void GetDirectory(string sourcePath)
        {
            if (Directory.Exists(sourcePath))//判断源文件夹是否存在
            {
                string[] tmp = Directory.GetFileSystemEntries(sourcePath);//获取源文件夹中的目录及文件路径，存入字符串
                //循环遍历
                for (int i = 0; i < tmp.Length; i++)
                {
                    if (File.Exists(tmp[i]))//如果是文件则存入FileList
                    {
                        FileList.Add(tmp[i]);
                    }
                    else
                    {
                        if ((Directory.GetDirectories(tmp[i])).Length == 0)//如果是最后一层目录则把其路径存入DirectorysList
                        {
                            DirectorysList.Add(tmp[i]);
                        }
                    }
                    //递归开始.......
                    GetDirectory(tmp[i]);
                }
            }
        }
    }
}
