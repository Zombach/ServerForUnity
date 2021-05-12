using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class Login : AbstractGeneralRequest
    {
        public Login(IRequest request) : base(request)
        {
        }
    }
}