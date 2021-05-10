using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using ServerForUnity.Core.Interface;

namespace ServerForUnity.Core
{
    public abstract class AbstractClient :IClient
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public NetworkStream NetworkStream { get; set; }
        public TcpClient TcpClient { get; set; }
        public Server Server { get; set; }

        public AbstractClient(TcpClient tcpClient, Server server)
        {
        }

        public virtual void Process()
        {
            try
            {
                NetworkStream = TcpClient.GetStream();
                // получаем имя пользователя
                string message = GetMessage();
                UserName = message;
                message = "║ " + UserName + " вошел в чат" + " ║";
                var line = "╔" + new string('═', message.Length - 2) + "╗";
                var line2 = "╚" + new string('═', message.Length - 2) + "╝";
                


                // посылаем сообщение о входе в чат всем подключенным пользователям
                Server.BroadcastMessage(message, this.Id);
                Console.WriteLine("===============");
                Console.WriteLine(line);
                Console.WriteLine(message);
                Console.WriteLine(line2);
                Console.WriteLine("===============");
                // в бесконечном цикле получаем сообщения от клиента
                while (true)
                {
                    try
                    {
                        message = GetMessage();
                        message = message.ToString();
                        string userName = "║ " + UserName.ToString() + " ║";

                        line = "╔" + new string('═', userName.Length - 2) + "╗";

                        line2 = "╚" + new string('═', userName.Length - 2) + "╝";

                        ;

                        Console.WriteLine(line);
                        Console.WriteLine(UserName + " " + message);
                        Console.WriteLine(line2);
                        Server.BroadcastMessage(message, this.Id);
                    }
                    catch
                    {
                        Console.WriteLine("===============");
                        message = "║ " + String.Format("{0} покинул чат", UserName) + " ║";


                        line = "╔" + new string('═', message.Length - 2) + "╗";

                        line2 = "╚" + new string('═', message.Length - 2) + "╝";

                        Console.WriteLine(line);
                        Console.WriteLine(message);
                        Console.WriteLine(line2);
                        Console.WriteLine("===============");
                        Server.BroadcastMessage(message, this.Id);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
            finally
            {
                // в случае выхода из цикла закрываем ресурсы
                Server.RemoveConnection(this.Id);
                Close();
            }
        }


        //чтение входящего сообщения и преобразование в строку
        public virtual string GetMessage()
        {
            return "";
        }

        // закрытие подключения
        public virtual void Close()
        {
        }
    }
}