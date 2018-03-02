using System;
using System.Net.Http;

namespace PwnedPasswordsChecker
{
    public static class Shared
    {
        public readonly static HttpClient HttpClient;

        static Shared()
        {
            HttpClient = new HttpClient();
        }
    }
}