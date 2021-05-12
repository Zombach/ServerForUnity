using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests.Abstracts
{
    public abstract class AbstractSoloRequest: IRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        public string TypeName { get; set; }

        protected AbstractSoloRequest()
        {
        }

        protected AbstractSoloRequest(IRequest request)
        {
            TypeName = request.TypeName;
        }
    }
}