using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests.Structs
{
    public struct StructMessage : IStructRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        public string TypeName { get; set; }

        public StructMessage(Message message)
        {
            TypeName = message.TypeName;
        }

    }
}