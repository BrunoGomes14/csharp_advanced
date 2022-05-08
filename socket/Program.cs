using System;
using socket.App.Utils;

namespace socket
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0) throw new ArgumentException("Parameter SocketType (client | server) not informed.");

            switch (args[0])
            {
                case "client":
                    StartClientSocket();
                    break;
                case "server":
                    StartServerSocket();
                    break;
                default:
                    throw new ArgumentException("SocketType not recognized. Try 'cliente' or 'server'.");
            }

            //StartClientSocket();
        }



        static void StartClientSocket()
        {
            Console.WriteLine($"When you're done, write <Close> to close the application..\n");

            int port = EnvironmentVariables.GetInt("PORT", "11000");
            Console.WriteLine($"...: Connecting to Server on port {port}");
            
            using (var client = new App.Client.Client())
            {
                client.Start(IPAddressFinder.GetLocalIPAddress(), port);

                Console.WriteLine("...: Conected!");
                Console.WriteLine("...: Type your messages and press <enter>. Enjoy!\n.\n.");

                while (true)
                {
                    string message = Console.ReadLine();
                    if (message?.Equals("Close") ?? true)
                    {
                        client.Close();
                        break;
                    }
                    else
                    {
                        string response = client.SendMessage(message);
                        response.LogReceivedMessage();
                    }
                }
            }
        }


        static void StartServerSocket()
        {
            Console.WriteLine("When you're done, press <enter> to close the application..\n");
            
            int port = EnvironmentVariables.GetInt("PORT", "11000");
            Console.WriteLine($"...: Starting Socket Server on port {port}");

            using (var server = new App.Server.Server())
            {
                server.Start(IPAddressFinder.GetLocalIPAddress(), port);

                Console.WriteLine("...: Conected!");
                Console.WriteLine("...: Waiting for Clients...\n.\n.");
                server.ReceiveMessage((message, client) => message.LogReceivedMessage());

                Console.Read();
            }
        }
    }
}
