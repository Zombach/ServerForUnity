using System.Threading;

namespace ServerForUnity.Core
{
    public class Singleton
    {
        private static Singleton _singleton;
        public string Ip { get; }
        public int Port { get; }
        public Server Server { get; }

        private Singleton()
        {
            Server = new Server();
            Ip = "127.0.0.1";
            Port = 8888;
        }

        public static Singleton GetSingleton()
        {
            return _singleton ?? (_singleton = new Singleton());
        }
    }
}