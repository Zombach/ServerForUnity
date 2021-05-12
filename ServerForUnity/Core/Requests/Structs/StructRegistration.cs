using System;
using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests.Structs
{
    public struct StructRegistration : IStructRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        public string TypeName { get; set; }

        public StructRegistration(Registration registration)
        {
            TypeName = registration.TypeName;
        }
    }
}