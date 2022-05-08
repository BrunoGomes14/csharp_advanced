using System.Text;

namespace socket.App.Utils
{
    public static class DefaultSocketResponse
    {
        public static byte[] GotIt => Encoding.UTF8.GetBytes("Got your message ;)");
        
    }
}
