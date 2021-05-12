using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class Message  : AbstractMultiRequest
    {
        public Message(IRequest request) : base(request)
        {
        }
    }
}