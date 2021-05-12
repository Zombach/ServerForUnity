using ServerForUnity.Core.Requests.Abstracts;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class Registration : AbstractGeneralRequest
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string Tell { get; set; }
        public string Mail { get; set; }

        public Registration() : base()
        {
            TypeName = GetType().FullName;
        }

        public Registration(IRequest request) : base(request)
        {
            Registration registration = (Registration) request;
            Name = registration.Name;
            Password = registration.Password;
            Tell = registration.Tell;
            Mail = registration.Mail;
        }
    }
}