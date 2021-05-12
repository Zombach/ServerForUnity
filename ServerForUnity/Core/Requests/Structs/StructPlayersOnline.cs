using ServerForUnity.Core.Requests.Interfaces;

namespace ServerForUnity.Core.Requests.Structs
{
    public struct StructPlayersOnline : IStructRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        public string TypeName { get; set; }

        public StructPlayersOnline(PlayersOnline playersOnline)
        {
            TypeName = playersOnline.TypeName;
        }
    }
}