using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using OfficeOASystem.Common;
namespace OfficeOASystem.Transmission {
    public abstract class Transfer {
        private const int BufferSize = 4096;
        public static void sendFile(string hostname, int port, string filepath) {
            FileInfo file = new FileInfo(filepath);
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(hostname, port);

            int length = (int)file.Length;
            using(FileStream reader = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.None)) {
                //socket.Send(BitConverter.GetBytes(length));
                string fileName = Path.GetFileName(filepath);
                Byte[] fn_bytes = Encoding.Default.GetBytes(fileName);
                socket.Send(Methods.i2b(fn_bytes.Length));
                socket.Send(fn_bytes);

                socket.Send(Methods.i2b(length));
                long send = 0L;
                ////Console.WriteLine("Sending file:" + fileName + ".Plz wait...");
                byte[] buffer = new byte[BufferSize];
                int read, sent;
                //断点发送 在这里判断设置reader.Position即可
                while((read = reader.Read(buffer, 0, BufferSize)) !=0) {
                    sent = 0;
                    while((sent += socket.Send(buffer, sent, read, SocketFlags.None)) < read) {
                        send += (long)sent;
                        //Console.WriteLine("Sent " + send + "/" + length + ".");//进度
                    }
                }
                //Console.WriteLine("Send finish.");
            }
        }
    }
}
