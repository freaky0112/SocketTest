using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows;

namespace ClientTest {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        private Thread thread;

        private static Socket client;

        private static SocketHelper sh;
        public MainWindow() {
            InitializeComponent();
            //string msg;
            //Socket socket = socketInit();
            //thread = new Thread(socketChecked);
            //thread.Start();
            sh = new SocketHelper(8081, "127.0.0.1");
            sh.MsgRecived +=this. OnMsgRecived;
            sh.Begin();
            
            //client = socketInit();
            //msg = client.Connected ? "连接成功" : "连接失败";
            //lbxRecord.Items.Add(msg);
        }

        private void OnMsgRecived(string msg) {

        }

        private Socket socketInit() {

            int port = 8081;
            string host = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //socketConnect(socket, ipe);
            socket.Connect(ipe);
            return socket;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e) {
            string msg = tbxStr.Text;
            lbxRecord.Items.Add(msg);
            if (!sh.SocketState) {
                sh.Begin();
            }
            sh.SendMsg(msg);
            //Socket socket = socketInit();
            //byte[] bs = Encoding.UTF8.GetBytes(msg + "\n");
            //if (!client.Connected) {
            //        client = socketInit();
                    
            //}
            //client.Send(bs, bs.Length, 0);
        }

        private bool socketConnect() {
            int port = 8081;
            string host = "127.0.0.1";
            IPAddress ip = IPAddress.Parse(host);
            IPEndPoint ipe = new IPEndPoint(ip, port);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(ipe);
            return socket.Connected;
        }

        private void socketChecked() {
            while (true) {
                if (!client.Connected) {
                    client = socketInit();
                    string msg;
                    msg = client.Connected ? "连接成功" : "连接失败";
                    lbxRecord.Items.Add(msg);
                } else {

                }
           }
        }

        private event EventHandler OnConnected;
        private void RaseieConnectedEvent() {
            if (OnConnected == null) {

            } else {
                OnConnected(this, new EventArgs());
            }
        }
        
    }
}
