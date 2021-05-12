using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests.Abstracts
{
    public abstract class AbstractGeneralRequest : IRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        public string TypeName { get; set; }

        protected AbstractGeneralRequest()
        {
        }
        protected AbstractGeneralRequest(IRequest request)
        {
            TypeName = request.TypeName;
        }
    }
}