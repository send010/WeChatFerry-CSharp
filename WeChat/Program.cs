/// <summary>
/// C# version of nngcat.
/// https://nanomsg.github.io/nng/man/v1.1.0/nngcat.1
/// </summary>
/// <example>
/// <code>
/// dotnet run -- --rep --listen tcp://localhost:8080 --data "42" &
/// dotnet run -- --req --dial tcp://localhost:8080 --data "what"
/// </code>
/// </example>
using Google.Protobuf;
using Microsoft.Extensions.CommandLineUtils;
using nng;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Text;
using Wcf;
using WeChat;

namespace nngcat
{
    class Program
    {
        static WcfClient wcfClient;
        static List<global::Wcf.RpcContact> ChatRooms;
        public static void RecvText(WxMsg msg)
        {
            if(msg.IsGroup && msg.Roomid == "51633019611@chatroom")
            {
                var a = ChatRooms.FirstOrDefault(p => p.Wxid == msg.Roomid);
                Console.WriteLine(a.Name +" "+ wcfClient.GetAliasInChatRoom(msg.Sender, msg.Roomid) +" " +msg.Content);
            }
        }
        static void Main(string[] args)
        {

            //启动wcfbin
            string wcfexe = Directory.GetCurrentDirectory()  + "\\wcfbin\\v39.0.14\\wcf.exe";
            ProcessStartInfo startInfo = new ProcessStartInfo(wcfexe);
            startInfo.Arguments = "start 6666 [debug]";
            var process = Process.Start(startInfo);


            wcfClient = new WcfClient(6666);
            wcfClient.EnableRecvTxt(RecvText);


            ChatRooms = wcfClient.GetChatRooms();

            Console.Read();

        }

    }
}