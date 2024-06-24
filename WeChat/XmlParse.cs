using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Wcf;

namespace WeChatFerry
{
    public class XmlParse
    {
        public static T XmlToObject<T>(string xml)
        {
            try
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));

                // 将XML字符串转换为流
                using (StringReader reader = new StringReader(xml))
                {
                    // 使用XmlSerializer来反序列化XML
                    return (T)serializer.Deserialize(reader);

                }
            }
            catch (Exception ex)
            {

            }
            return default(T);
        }
    }
}
