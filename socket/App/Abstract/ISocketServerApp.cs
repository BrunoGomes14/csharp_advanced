using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;


namespace socket.App.Abstract
{
    public interface ISocketServerApp : ISocketApp
    {
        void ReceiveMessage(Action<string, Socket> action);
    }



}

