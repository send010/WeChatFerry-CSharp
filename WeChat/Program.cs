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
using System.Runtime.InteropServices;
using System.Text;
using Wcf;

namespace WeChatFerry
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




        private delegate void WxInitSDKDelegate(bool isHook, int pid);
        private delegate void WxDestroySDKDelegate();


        static void Main(string[] args)
        {

            //{
            //    //启动wcfbin
            //    // wcf 39.0.14 版本 微信 3.9.2.23版本   启动方式
            //    string wcfexe = Directory.GetCurrentDirectory() + "\\wcfbin\\v39.0.14\\wcf.exe";
            //    ProcessStartInfo startInfo = new ProcessStartInfo(wcfexe);
            //    startInfo.Arguments = "start 6666 [debug]";
            //    var process = Process.Start(startInfo);
            //}



            {
                string dllPath = Directory.GetCurrentDirectory() + "\\wcfbin\\v3.9.10.27\\sdk.dll";
                IntPtr pDll = NativeMethods.LoadLibrary(dllPath);
                if (pDll == IntPtr.Zero)
                {
                    Console.WriteLine("Failed to load DLL.");
                    return;
                }

                // 获取函数指针
                IntPtr pInitSDK = NativeMethods.GetProcAddress(pDll, "WxInitSDK");
                IntPtr pDestroySDK = NativeMethods.GetProcAddress(pDll, "WxDestroySDK");

                // 将函数指针转换为委托
                WxInitSDKDelegate WxInitSDK = (WxInitSDKDelegate)Marshal.GetDelegateForFunctionPointer(pInitSDK, typeof(WxInitSDKDelegate));
                WxDestroySDKDelegate WxDestroySDK = (WxDestroySDKDelegate)Marshal.GetDelegateForFunctionPointer(pDestroySDK, typeof(WxDestroySDKDelegate));

                // 调用 DLL 函数
                WxInitSDK(false, 6666);
            }



            wcfClient = new WcfClient(6666);
            wcfClient.EnableRecvTxt(RecvText);
            ChatRooms = wcfClient.GetChatRooms();
            Console.Read();
        }

    }
}