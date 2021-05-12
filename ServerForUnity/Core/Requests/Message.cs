using System.Collections.Generic;
using ServerForUnity.Core.Clients;
using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class Message  : AbstractMultiRequest
    {
        public List<string> Texts { get; set; }
        public AbstractClient ForClient { get; set; }

        public Message() : base()
        {
            TypeName = this.GetType().FullName;
            Texts = new List<string>();
            ForClient = null;
        }

        public Message(IRequest request) : base(request)
        {
            Message message = (Message) request;
            Texts = message.Texts;
            ForClient = message.ForClient;
        }
    }
}