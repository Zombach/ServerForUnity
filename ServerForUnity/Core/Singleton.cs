using System.Threading;

namespace ServerForUnity.Core
{
    public class Singleton
    {
        private static Singleton _singleton;
        public string Ip { get; set; } = "127.0.0.1";
        public Server Server { get; set; }
        public Thread Thread { get; set; }

        private Singleton()
        {
            Server = new Server();
            //Thread = new Thread(new ThreadStart(Server.Listen));
            //Thread = new Thread(Server.Listen); нужно проверить, будет так работать?
        }

        public static Singleton GetSingleton()
        {
            return _singleton ?? (_singleton = new Singleton());
        }
    }
}