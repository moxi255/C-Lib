using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace ConsoleApp1.Library
{
    /// <summary>
    /// 字符串操作
    /// </summary>
    class StringOperate
    {
        /// <summary>
        /// 隐藏敏感信息
        /// </summary>
        /// <param name="info">信息实体</param>
        /// <param name="left">左边保留的字符数</param>
        /// <param name="right">右边保留的字符数</param>
        /// <param name="basedOnLeft">当长度异常时，是否显示左边 
        /// <code>true</code>显示左边，<code>false</code>显示右边
        /// </param>
        /// <returns></returns>
        public static string HideSensitiveInfo(string info, int left, int right, bool basedOnLeft = true)
        {
            if (string.IsNullOrEmpty(info))
            {
                throw new ArgumentNullException(info);
            }
            var sbText = new StringBuilder();
            var hiddenCharCount = info.Length - left - right;
            if (hiddenCharCount > 0)
            {
                string prefix = info.Substring(0, left), suffix = info.Substring(info.Length - right);
                sbText.Append(prefix);
                for (var i = 0; i < hiddenCharCount; i++)
                {
                    sbText.Append("*");
                }
                sbText.Append(suffix);
            }
            else
            {
                if (basedOnLeft)
                {
                    if (info.Length > left && left > 0)
                    {
                        sbText.Append(info.Substring(0, left) + "****");
                    }
                    else
                    {
                        sbText.Append(info.Substring(0, 1) + "****");
                    }
                }
                else
                {
                    if (info.Length > right && right > 0)
                    {
                        sbText.Append("****" + info.Substring(info.Length - right));
                    }
                    else
                    {
                        sbText.Append("****" + info.Substring(info.Length - 1));
                    }
                }
            }
            return sbText.ToString();
        }
        /// <summary>
        /// 百分数转为小数，小数不转换
        /// </summary>
        /// <param name="dd">带百分号的数，不带百分号的数，小数</param>
        /// <returns></returns>
        public static decimal PercentToDecimal(string dd)
        {
            if (dd.IndexOf('.') != -1)
            {
                return Convert.ToDecimal(dd);
            }
            decimal a = Convert.ToDecimal(dd.Replace("%", "")) * (Decimal)0.01;
            return a;
        }
        /// <summary>
        /// Html 中提起文字
        /// </summary>
        /// <param name="strHtml"></param>
        /// <returns></returns>
        public static string StripHT(string strHtml)  //从html中提取纯文本
        {
            Regex regex = new Regex("<.+?>", RegexOptions.IgnoreCase);
            string strOutput = regex.Replace(strHtml, "");//替换掉"<"和">"之间的内容
            strOutput = strOutput.Replace("<", "");
            strOutput = strOutput.Replace(">", "");
            strOutput = strOutput.Replace("&nbsp;", "");
            return strOutput;
        }
        /// <summary>
        /// 过滤字符串-只保留汉字
        /// </summary>
        /// <param name="input">需要过滤的字符串</param>
        /// <returns></returns>
        public static string FilterChar(string input)
        {
            Regex r = new Regex("^[0-9]{1,}$"); //正则表达式 表示数字的范围 ^符号是开始，$是关闭
            StringBuilder sb = new StringBuilder();
            foreach (var item in input)
            {
                if (item >= 0x4e00 && item <= 0x9fbb)//汉字范围
                {
                    sb.Append(item);
                }


            }
            return sb.ToString();
        }
        private static char[] constant =
       {
        '0','1','2','3','4','5','6','7','8','9',
        'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z',
        'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'
        };
        /// <summary>
        /// 创建数字字母随机数
        /// </summary>
        /// <param name="Length"></param>
        /// <returns></returns>
        public static string GenerateRandomNumber(int Length)
        {
            System.Text.StringBuilder newRandom = new System.Text.StringBuilder(62);
            Random rd = new Random();
            for (int i = 0; i < Length; i++)
            {
                newRandom.Append(constant[rd.Next(62)]);
            }
            return newRandom.ToString();
        }
        /// <summary>
        /// SerializeDictionaryToJsonString
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="dict">要序列化的字典数据</param>
        /// <returns>json字符串</returns>
        public static string SerializeDictionaryToJsonString<TKey, TValue>(Dictionary<TKey, TValue> dict)
        {
            if (dict.Count == 0)
                return "";

            string jsonStr = JsonConvert.SerializeObject(dict);
            return jsonStr;
        }

        /// <summary>
        /// 将json字符串反序列化为字典类型
        /// </summary>
        /// <typeparam name="TKey">字典key</typeparam>
        /// <typeparam name="TValue">字典value</typeparam>
        /// <param name="jsonStr">json字符串</param>
        /// <returns>字典数据</returns>
        public static Dictionary<TKey, TValue> DeserializeStringToDictionary<TKey, TValue>(string jsonStr)
        {
            if (string.IsNullOrEmpty(jsonStr))
                return new Dictionary<TKey, TValue>();

            Dictionary<TKey, TValue> jsonDict = JsonConvert.DeserializeObject<Dictionary<TKey, TValue>>(jsonStr);

            return jsonDict;

        }
        /// <summary>
        ///json 转为对象
        /// </summary>
        /// <param name="json">json 字符串</param>
        /// <returns></returns>
        public static Dictionary<string, object> JsonToDict(dynamic json)
        {
            Dictionary<string, object> dict = JsonConvert.DeserializeObject<Dictionary<string, object>>(JObject.FromObject(json).ToString());
            return dict;
        }

    }
}
