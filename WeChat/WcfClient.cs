using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using nng;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Wcf;
using Wcferry;
using WeChatFerry;
using WeChatFerry.Model;

namespace WeChatFerry
{
    public class WcfClient
    {
        private readonly string _host;
        private readonly int _port;

        public Action<string> RecvText;

        public IPairSocket CmdSocket;
        public IPairSocket MsgSocket;
        IAPIFactory<INngMsg> Factory;

        string msgurl = "";

        public WcfClient(int port)
        {

            var url = "tcp://127.0.0.1";
            msgurl = url + ":" + (port + 1);

            var managedAssemblyPath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
            var alc = new NngLoadContext(managedAssemblyPath);
            Factory = NngLoadContext.Init(alc, "nng.Factories.Latest.Factory");

            CmdSocket = Factory.PairOpen().ThenDial(url+":"+port).Unwrap();

        }

        public bool ConnectionStatus()
        {
            return CmdSocket.IsValid();
        }

        // 检查登录状态
        // return bool 是否已登录
        public bool isLogin()
        {
            Request request1 = new Request() { Func = Functions.FuncIsLogin };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();

            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            return response.Status == 1;
        }

        // 开启消息接收服务
        // param pyq bool 是否接收朋友圈消息
        // return int32 0 为成功，其他失败
        public int EnableRecvTxt(Action<WxMsg> func,bool pyq=false)
        {
            Request request1 = new Request() { Func = Functions.FuncEnableRecvTxt,Flag = pyq};
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            if(MsgSocket != null)
            {
                MsgSocket.Dispose();
                MsgSocket = null;

            }
            Task.Run(() =>
            {

                MsgSocket = Factory.PairOpen().ThenDial(msgurl).Unwrap();
                //Request request1 = new Request() { Func = Functions.FuncIsLogin };
                //socket.Send(request1.ToByteArray());

                try
                {
                    while (MsgSocket != null)
                    {
                        var recvMsg = MsgSocket.RecvMsg().Unwrap();

                        var recvData = recvMsg.AsSpan().ToArray();
                        var response = Response.Parser.ParseFrom(recvData);
                        func(response.Wxmsg);
                    }
                }
                catch (Exception ex)
                {

                }


            });

            return response.Status;
        }

        // 停止消息接收服务
        // return int32 0 为成功，其他失败
        public int DisableRecvTxt()
        {
            Request request1 = new Request() { Func = Functions.FuncDisableRecvTxt };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            return response.Status;
        }


        public int SendText(string msg, string receiver, string at = "")
        {
            var request1 = new Request() { Func = Functions.FuncSendTxt, Txt = new TextMsg() { Msg = msg, Receiver = receiver, Aters = at } };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            return response.Status;
        }

        public int SendImg(string imgpath, string receiver)
        {
            var request1 = new Request() { Func = Functions.FuncSendImg, File =  new PathMsg() { Path = imgpath, Receiver = receiver } };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            return response.Status;
        }
        public int SendFile(string imgpath, string receiver)
        {
            var request1 = new Request() { Func = Functions.FuncSendFile, File =  new PathMsg() { Path = imgpath, Receiver = receiver } };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            return response.Status;
        }
        public int SendEmotion(string imgpath, string receiver)
        {
            var request1 = new Request() { Func = Functions.FuncSendEmotion, File =new PathMsg { Path = imgpath, Receiver = receiver } };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            return response.Status;
        }
        
        public int ForwardMsg(ulong msgid, string receiver,int count = 3)
        {
            var request1 = new Request() { Func = Functions.FuncForwardMsg, Fm = new ForwardMsg {  Id = msgid, Receiver = receiver } };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            if(response.Status != 1 && count != 0)
            {
                return ForwardMsg(msgid, receiver, count-1);
            }

            return response.Status;
        }


        // 获取完整通讯录
        // return []*RpcContact 完整通讯录
        public List<global::Wcf.RpcContact> GetContacts()
        {
            Request request1 = new Request() { Func = Functions.FuncGetContacts };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            return response?.Contacts?.Contacts.ToList();
        }

        // 获取好友列表
        // return []*RpcContact 好友列表
        public List<global::Wcf.RpcContact> GetFriends()
        {
            var result = new List<global::Wcf.RpcContact>();
            var data = GetContacts();

            foreach (var item in data)
            {
                if(CmdHelper.ContactType(item.Wxid) == "好友")
                {
                    result.Add(item);
                }
            }

            return result;
        }
        // 获取群聊列表
        public List<global::Wcf.RpcContact> GetChatRooms()
        {
            var result = new List<global::Wcf.RpcContact>();
            var data = GetContacts();
            if (data != null)
            {
                foreach (var item in data)
                {
                    if (CmdHelper.ContactType(item.Wxid) == "群聊")
                    {
                        result.Add(item);
                    }
                }

            }
            return result;
        }

        // 从数据库文件中获取群信息
        public List<IDNameModel> GetChatRoomsByDB()
        {
            var result = new List<IDNameModel>();
            var sessionlist = DbSqlQuery("MicroMsg.db", "SELECT strUsrName,strNickName FROM Session;");

            for (int i = 0; i< sessionlist.Rows.Count; i++)
            {
                var id = sessionlist.Rows[i]["strUsrName"].ToString();

                if (id.EndsWith("@chatroom") && !result.Any(p=>p.Id == id))
                {
                    result.Add(new IDNameModel() { Id = id, Name = sessionlist.Rows[i]["strNickName"].ToString() });
                }

            }
            return result;
        }

        public RpcContact GetInfoByWxid(string wxid)
        {
            Request request1 = new Request() { Func = Functions.FuncGetContactInfo , Str = wxid };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            if(response.Contacts?.Contacts?.Count > 0)
            {
                return response.Contacts.Contacts[0];
            }

            return null;
        }

        public DataTable DbSqlQuery(string db,string sql)
        {
            Request request1 = new Request() { Func = Functions.FuncExecDbQuery,Query = new DbQuery() { Db = db, Sql = sql } };
            CmdSocket.Send(request1.ToByteArray());

            var recvMsg = CmdSocket.RecvMsg().Unwrap();
            var recvData = recvMsg.AsSpan().ToArray();
            var response = Response.Parser.ParseFrom(recvData);

            DataTable dt = new DataTable();

            if(response.Rows != null)
            {
                foreach (DbRow row in response.Rows?.Rows)
                {
                    var nrow = dt.NewRow();
                    foreach (var item in row.Fields)
                    {
                        if (!dt.Columns.Contains(item.Column))
                        {
                            dt.Columns.Add(item.Column);
                        }
                        if (item.Type == 4)
                        {
                            nrow[item.Column] = item.Content.ToBase64();
                        }
                        else
                        {
                            nrow[item.Column] = item.Content.ToStringUtf8();
                        }
                    }
                    dt.Rows.Add(nrow);
                }

            }

            return dt;
        }

        // 获取群成员昵称
        // param wxid string wxid
        // param roomid string 群的 id
        // return string 群成员昵称
        public string GetAliasInChatRoom(string wxid,string roomid)
        {
            var nickName = "";

            var userlist = DbSqlQuery("MicroMsg.db", "SELECT NickName FROM Contact WHERE UserName = '" + wxid + "';");
            if (userlist.Rows.Count > 0 )
            {
                nickName = userlist.Rows[0]["NickName"].ToString();
            }

            var roomList = DbSqlQuery("MicroMsg.db", "SELECT RoomData FROM ChatRoom WHERE ChatRoomName = '" + roomid + "';");
            if (roomList.Rows.Count == 0 || userlist.Rows[0][0] == null)
            {
                return nickName;
            }
            //userlist.Rows[0][0]
            var str = roomList.Rows[0][0].ToString();
            var data = Convert.FromBase64String(roomList.Rows[0][0].ToString());
            var roomData = RoomData.Parser.ParseFrom(data);

            foreach (var item in roomData.Members)
            {
                if(item.Wxid == wxid)
                {
                    if(!string.IsNullOrEmpty(item.Name))
                    {
                        nickName = item.Name;
                    }
                    break;
                }
            }

            return nickName;
        }


    }
}
