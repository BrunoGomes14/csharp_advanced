using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using socket.App.Abstract;
using System.Threading.Tasks;
using socket.App.Utils;

namespace socket.App.Server
{

    public class Server : Abstract.ISocketServerApp
    {
        Socket socket;
        Action<string, Socket> onMessageReceive;

        public void Start(IPAddress host, int port)
        {
            IPEndPoint localEP = new IPEndPoint(host, port);

            socket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            socket.Bind(localEP);
            socket.Listen();


           Task.Factory.StartNew(StartListening);
        }

        
        public void ReceiveMessage(Action<string, Socket> action)
        {
            this.onMessageReceive = action;
        }

        void StartListening()
        {
            while (true) 
            {
                try
                {
                    Socket clientConnected = socket.Accept();
                    Task.Factory.StartNew(HandleClient, clientConnected);
                }
                catch (System.Exception ex)
                {
                    ex.LogError();
                }
            }
        }

        void HandleClient(object clientObj)
        {
            Socket clientConnected = clientObj as Socket;
            try
            {
                while (true)
                {
                    string receivedMessage = ReceiveMessage(clientConnected);
                    onMessageReceive(receivedMessage, clientConnected);

                    clientConnected.Send(DefaultSocketResponse.GotIt);
                }
            }
            catch (System.Exception ex)
            {
                ex.LogError();
                clientConnected.Shutdown(SocketShutdown.Both);
                clientConnected.Close();
            }
        }

        string ReceiveMessage(Socket clientConnected)
        {
            string receivedMessage = string.Empty;
            byte[] bytes = new byte[1024];

            while (true)
            {
                int bytesReceived = clientConnected.Receive(bytes);
                receivedMessage += Encoding.UTF8.GetString(bytes, 0, bytesReceived);
                
                if (receivedMessage.Contains(SocketOptions.EOF_CLOSE))
                    throw new ClientCloseConnectionException();
                
                if (receivedMessage.Contains(SocketOptions.EOF))
                {
                    receivedMessage = receivedMessage.Replace(SocketOptions.EOF, string.Empty);
                    break;
                }
            }
            return receivedMessage;
        }
 

        public void Dispose()
        {
            socket.Close();
            socket.Dispose();
            socket = null;
        }

    }

}