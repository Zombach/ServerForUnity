using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class PlayersOnline : AbstractSoloRequest
    {
        public PlayersOnline(IRequest request) : base(request)
        {
        }
    }
}