namespace ServerForUnity.Core.Requests.Interfaces
{
    public interface IRequest
    {
        /// <summary>
        /// Поле для записи названия типа
        /// </summary>
        string TypeName { get; set; }
    }
}