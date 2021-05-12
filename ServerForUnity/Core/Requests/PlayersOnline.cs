using System.Collections.Generic;
using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class PlayersOnline : AbstractSoloRequest
    {
        public List<AbstractClient> Clients;

        public PlayersOnline() : base()
        {
            TypeName = GetType().FullName;
        }

        public PlayersOnline(IRequest request) : base(request)
        {
            PlayersOnline playersOnline = (PlayersOnline) request;
            Clients = playersOnline.Clients;
        }
    }
}