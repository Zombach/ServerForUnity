using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests.Abstracts
{
    public abstract class AbstractMultiRequest : IRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        public string TypeName { get; set; }

        protected AbstractMultiRequest()
        {
        }

        protected AbstractMultiRequest(IRequest request)
        {
            TypeName = request.TypeName;
        }
    }
}