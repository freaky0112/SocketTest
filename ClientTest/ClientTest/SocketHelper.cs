using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ClientTest {
    class SocketHelper {
        /// <summary>
        /// 建立委托服务器监听事件
        /// </summary>
        /// <param name="msg"></param>
        public delegate void MsgReciveHandler(string msg);

        private Socket socket;
        private int port;
        private string host;
        private Thread reciveThread;
        CancellationTokenSource cts = new CancellationTokenSource();
        /// <summary>
        /// 委托事件
        /// </summary>
        private static MsgReciveHandler onMsgRecived;
        /// <summary>
        /// 收到服务器信息事件
        /// </summary>
        public event MsgReciveHandler MsgRecived {
            add { onMsgRecived += new MsgReciveHandler(value); }
            remove { onMsgRecived -= new MsgReciveHandler(value); }
        }
        /// <summary>
        /// 初始化socket连接
        /// </summary>
        /// <param name="port">端口号</param>
        /// <param name="host">服务器地址</param>
        public SocketHelper(int port,string host) {
            this.port = port;
            this.host = host;
            //connectThread = new Thread(this.Begin);
            //connectThread.Start();
        }
        /// <summary>
        /// 关闭连接
        /// </summary>
        /// <returns></returns>
        public int Close() {
            if (socket.Connected) {
                socket.Disconnect(false);
            }
            cts.Cancel();
            return 0;
        }

        /// <summary>
        /// 开始连接
        /// </summary>
        /// <returns>是否连接成功</returns>
        public bool Begin() {
            //int port = 8081;
            //string host = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipe);
            reciveThread = new Thread(this.ReciveMsg);//新建线程监听服务器信息
            reciveThread.Start();
            return socket.Connected;
        }
        /// <summary>
        /// 发送字符串
        /// </summary>
        /// <param name="text">内容</param>
        /// <returns></returns>
        public int SendMsg(string text) {
            byte[] bs = Encoding.UTF8.GetBytes(text + "\n");
            socket.Send(bs, bs.Length, 0);
            return 0;
        }
        /// <summary>
        /// 监听服务器信息
        /// </summary>
        public void ReciveMsg() {
            int bytes;
            string msg = "";
            while(SocketState){
                //Socket listenSocket = socket.Accept();
                if (cts.Token.IsCancellationRequested) {                    
                    socket.Close();
                    socket.Dispose();
                    break;
                }
                byte[] receiveBytes = new byte[1024];
                bytes = socket.Receive(receiveBytes, receiveBytes.Length, 0);
                msg = Encoding.UTF8.GetString(receiveBytes, 0, bytes);
                onMsgRecived(msg);
            }

            //return msg;
        }
       

        public bool SocketState {
            get {
                return socket.Connected;
            }
        }
        
    }
}
