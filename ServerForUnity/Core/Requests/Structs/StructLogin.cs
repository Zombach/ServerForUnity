using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests.Structs
{
    public struct StructLogin : IStructRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        public string TypeName { get; set; }

        public StructLogin(Login login)
        {
            TypeName = login.TypeName;
        }

    }
}