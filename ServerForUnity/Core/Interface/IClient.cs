using System.Net.Sockets;
using System.Text;

namespace ServerForUnity.Core.Interface
{
    public interface IClient
    {
        string Id { get; set; }
        string UserName { get; set; }
        StringBuilder Message { get; set; }
        NetworkStream NetworkStream { get; set; }
        TcpClient TcpClient { get; set; }
    }
}