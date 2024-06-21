using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeChatFerry
{
    public class CmdHelper
    {
        private static readonly Dictionary<string, string> NotFriends = new Dictionary<string, string>
    {
        { "fmessage", "朋友推荐消息" },
        { "filehelper", "文件传输助手" },
        { "floatbottle", "漂流瓶" },
        { "medianote", "语音记事本" },
        { "mphelper", "公众平台助手" },
        { "newsapp", "新闻" }
    };

        public static string ContactType(string wxid)
        {
            if (NotFriends.ContainsKey(wxid))
            {
                return NotFriends[wxid];
            }

            if (wxid.EndsWith("@chatroom"))
            {
                return "群聊";
            }

            if (wxid.EndsWith("@openim"))
            {
                return "企业微信";
            }

            if (wxid.StartsWith("gh_"))
            {
                return "公众号";
            }

            return "好友";
        }
    }
}
