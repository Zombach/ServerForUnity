using System.Collections.Generic;
using System.Threading;
using ServerForUnity.Core.Requests.Interfaces;
using ServerForUnity.Core.Servers;

namespace ServerForUnity.Core
{
    public class Singleton
    {
        private static Singleton _singleton;
        public string Ip { get; }
        public int Port { get; }
        public Server Server { get; }

        public List<IRequest> Requests { get; set; }
        public List<IStructRequest> StructRequests { get; set; }

        private Singleton()
        {
            Server = new Server();
            Ip = "127.0.0.1";
            Port = 8888;

            Requests = new List<IRequest>();
            StructRequests = new List<IStructRequest>();
        }

        public static Singleton GetSingleton()
        {
            return _singleton ?? (_singleton = new Singleton());
        }
        
        
    }
}