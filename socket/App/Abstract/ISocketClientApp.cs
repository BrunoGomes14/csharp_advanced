using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;


namespace socket.App.Abstract
{
    public interface ISocketClientApp : ISocketApp
    {
        string SendMessage(string message);
        void Close();
    }



}

