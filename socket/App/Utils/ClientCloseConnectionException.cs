using System;

namespace socket.App.Utils
{
    public class ClientCloseConnectionException : Exception
    {
        public ClientCloseConnectionException()
            : base ("Client has disconnected.") {}
    }
}