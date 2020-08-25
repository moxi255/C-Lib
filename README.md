# C# 工具类:该类为自己平时工作的时候总结出来用的

- AESOperate 加密操作类
    * CreateSalt 创建随机盐
    * Encode 加密字符串
    * Decode 解密字符串
- DateOperate日期操作类
    * ConvertToTimeStamp 日期转换为时间戳（时间戳单位毫秒）
    * ConvertToDateTime 时间戳转换为日期（时间戳单位毫秒）
    * FirstDayOfYear 取得某年的第一天
    * LastDayOfYear 获取今年的最后一天
    * FirstDayOfMonth 取得某月的第一天
    * LastDayOfMonth 取得某月的最后一天
    * FirstDayOfPreviousMonth 取得上个月第一天
    * GetWeekSpan 得到这一周的起止日期
    * LastDayOfPrdviousMonth 取得上个月的最后一天
- ImageOperate 图像操作类
    * DownloadFileAsync 下载图片到本地
    * GetImgStr 获取富文本图片的路径
- ImageOperate 地图操作类
    * LLSquarePoint 根据一个给定经纬度的点和距离，进行附近地点查询
    * GetDistance 计算两点位置的距离，返回两点的距离，单位 米
- ObjectOperate 对象操作类
    * ContainProperty 利用反射来判断对象是否包含某个属性
    * GetObjectPropertyValue 获取对象属性值
    * GetObjectProperty 获取属性列表
- StringOperate 字符串操作类
    * HideSensitiveInfo 隐藏敏感信息
    * PercentToDecimal 百分数转为小数，小数不转换
    * StripHT Html 中提起文字
    * FilterChar 过滤字符串-只保留汉字
    * GenerateRandomNumber 创建数字字母随机数
    * SerializeDictionaryToJsonString SerializeDictionaryToJsonString
    * DeserializeStringToDictionary 将json字符串反序列化为字典类型
    * JsonToDict json 转为对象