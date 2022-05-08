using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace socket.App.Client
{

    public class Client : Abstract.ISocketClientApp
    {
        Socket socket;

        public void Start(IPAddress host, int port)
        {
            IPEndPoint remoteEP = new IPEndPoint(host, port);

            socket = new Socket(
                host.AddressFamily,
                SocketType.Stream,
                ProtocolType.Tcp);
            
            socket.Connect(remoteEP);
        }

        public string SendMessage(string message)
        {
            byte[] msg = Encoding.UTF8.GetBytes($"{message}{SocketOptions.EOF}");

            int bytesSent = socket.Send(msg);

            byte[] bytes = new byte[1024];
            int bytesRec = socket.Receive(bytes);

            return Encoding.UTF8.GetString(bytes, 0, bytesRec);
        }

        public void Close()
        {
            SendMessage(SocketOptions.EOF_CLOSE);
        }

        
        public void Dispose()
        {
            socket.Close();
            socket.Dispose();
            socket = null;
        }
    }

}