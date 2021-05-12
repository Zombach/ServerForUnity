using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class Login : AbstractGeneralRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }

        public Login() : base()
        {
            TypeName = GetType().FullName;
        }

        public Login(IRequest request) : base(request)
        {
            Login login = (Login) request;
            Name = login.Name;
            Password = login.Password;
        }
    }
}