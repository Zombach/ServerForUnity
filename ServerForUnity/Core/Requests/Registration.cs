using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class Registration : AbstractGeneralRequest
    {
        public Registration(IRequest request) : base(request)
        {
        }
    }
}