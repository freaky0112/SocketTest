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

        private Socket socket;

        public event EventHandler OnConnected;
        public SocketHelper(Socket socket) {
            this.socket = socket;
        }

        private void RasieConnect() {
            if (OnConnected == null) {

            } else {
                OnConnected(this, new EventArgs());
            }
        }
        private Thread connectThread;

        public bool Begin() {
            int port = 8081;
            string host = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipe);
            return socket.Connected;
        }
    }
}
