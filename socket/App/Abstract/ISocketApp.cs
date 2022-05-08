using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Net;

namespace socket.App.Abstract
{
    public interface ISocketApp : IDisposable
    {
        void Start(IPAddress host, int port);
    }
}

