using System;
using System.Net;

namespace socket.App.Utils
{
    public static class EnvironmentVariables
    {
        public static int GetInt(string key, string @default)
        {
            return Convert.ToInt32(
                Environment.GetEnvironmentVariable(key) ?? @default
            );
        }

        public static string GetString(string key, string @default)
        {
            return Environment.GetEnvironmentVariable(key) ?? @default;
        }
        
    }
}