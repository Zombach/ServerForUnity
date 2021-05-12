using System;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests
{
    public class ProcessingStruct
    {
        /// <summary>
        /// Метод для разворачивания структуры запроса
        /// </summary>
        /// <param name="structRequest">Запрос в виде структуры</param>
        /// <returns>Собранный запрос на основе предоставленной структуры</returns>
        public IRequest PreparingRequest(IStructRequest structRequest)
        {
            IRequest request = null;
            string typeName = structRequest.TypeName;
            Type type = Type.GetType(typeName);
            if (type != null)
            {
                request = CreateStructRequest(type, structRequest);
            }
            return request;
        }

        /// <summary>
        /// Создание запрос на основе предоставленной структуры по средствам активатора
        /// </summary>
        /// <param name="type">Тип запроса</param>
        /// <param name="structRequest">Запрос в виде структуры</param>
        /// <returns>Собранный запрос на основе предоставленной структуры</returns>
        private IRequest CreateStructRequest(Type type, IStructRequest structRequest)
        {
            var structType = Activator.CreateInstance(type, structRequest);
            IRequest request = (IRequest) structType;
            return request;
        }
    }
}