using System.Net.Sockets;

namespace ServerForUnity.Core.Interface
{
    public interface IClient
    {
        string Id { get; set; }
        string UserName { get; set; }
        NetworkStream NetworkStream { get; set; }
        TcpClient TcpClient { get; set; }
    }
}