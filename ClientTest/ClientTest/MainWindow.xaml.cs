using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientTest {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {

        private static Socket client;
        public MainWindow() {
            InitializeComponent();
            string msg;
            //Socket socket = socketInit();
            client = socketInit();
            msg = client.Connected ? "连接成功" : "连接失败";
            lbxRecord.Items.Add(msg);
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
            //Socket socket = socketInit();
            byte[] bs = Encoding.UTF8.GetBytes(msg + "\n");
            if (!client.Connected) {
                    client = socketInit();
                    
            }
            client.Send(bs, bs.Length, 0);
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
    }
}
