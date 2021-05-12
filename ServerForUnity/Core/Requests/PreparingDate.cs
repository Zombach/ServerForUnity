using ServerForUnity.Core.Requests.Interfaces;
using System;

namespace ServerForUnity.Core.Requests
{
    public class PreparingDate
    {
        /// <summary>
        /// Метод для преобразования запроса в структуру запроса
        /// </summary>
        /// <param name="request">Полученный запрос</param>
        /// <returns>преобразованный запрос в структуру запроса</returns>
        public IStructRequest PreparingRequest(IRequest request)
        {
            IStructRequest structRequest = null;
            string typeName = request.TypeName;
            Type type = Type.GetType(typeName);
            if (type != null)
            {
                structRequest = CreateStructRequest(type, request);
            }
            return structRequest;
        }

        /// <summary>
        /// Создание структуры запрос на основе предоставленного запроса по средствам активатора
        /// </summary>
        /// <param name="type">Тип запроса</param>
        /// <param name="request">Полученный запрос</param>
        /// <returns>преобразованный запрос в структуру запроса</returns>
        private IStructRequest CreateStructRequest(Type type, IRequest request)
        {
            var structType = Activator.CreateInstance(type, request);
            IStructRequest structRequest = (IStructRequest)structType;
            return structRequest;
        }
    }
}