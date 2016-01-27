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
        public delegate void MsgReciveHandler(string msg);

        private Socket socket;
        private int port;
        private string host;
        private Thread connectThread;

        private static MsgReciveHandler onMsgRecived;
        public event MsgReciveHandler MsgRecived {
            add { onMsgRecived += new MsgReciveHandler(value); }
            remove { onMsgRecived -= new MsgReciveHandler(value); }
        }

        public SocketHelper(int port,string host) {
            this.port = port;
            this.host = host;
            connectThread = new Thread(this.Begin);
            connectThread.Start();
        }



        public void Begin() {
            //int port = 8081;
            //string host = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipe);
            while (true) {
                onMsgRecived(ReciveMsg());
            }
            //return socket.Connected;
        }

        public int SendMsg(string text) {
            byte[] bs = Encoding.UTF8.GetBytes(text + "\n");
            socket.Send(bs, bs.Length, 0);
            return 0;
        }

        public string ReciveMsg() {
            int bytes;
            string msg = "";
            byte[] receiveBytes = new byte[1024];
            bytes = socket.Receive(receiveBytes, receiveBytes.Length, 0);
            msg += Encoding.UTF8.GetString(receiveBytes,0,bytes);
            return msg;
        }
       

        public bool SocketState {
            get {
                return socket.Connected;
            }
        }
        
    }
}
