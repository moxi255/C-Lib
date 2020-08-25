using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Library
{
    /// <summary>
    /// 图像操作
    /// </summary>
   public class ImageOperate
    {
        /// <summary>
        /// 下载图片到本地
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static void DownloadFileAsync(string fileUrl, string path)
        {
            try
            {
                System.Net.WebClient client = new System.Net.WebClient();
                client.DownloadFile(new Uri(fileUrl, UriKind.RelativeOrAbsolute), path);
            }
            catch (Exception ex)
            {

            }
        }
        /// <summary>
        /// 获取富文本图片的路径
        /// </summary>
        /// <param name="htmlStr"></param>
        /// <returns></returns>
        public static List<String> getImgStr(String htmlStr)
        {

            List<String> list = new List<string>();
            String img = "";
            // String regEx_img = "<img.*src=(.*?)[^>]*?>"; //图片链接地址
            String regEx_img = "<img.*src\\s*=\\s*(.*?)[^>]*?>";
            MatchCollection mc = Regex.Matches(htmlStr, regEx_img);
            foreach (Match m in mc)
            {
                img = m.Value;
                MatchCollection mc1 = Regex.Matches(img, "(src|SRC)=(\"|\')(.*?)(\"|\')");
                if (mc1.Count >= 1)
                {
                  
                    string temp =(string) mc1.GetEnumerator().Current;
                    temp = temp.Replace("\"", "");
                    temp = temp.Replace("src=", "");

                    list.Add(temp);
                }
            }

            return list;
        }
    }
}
