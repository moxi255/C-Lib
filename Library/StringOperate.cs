using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
