using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Net.Sockets;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace Laba10
{
    class Program
    {
        static string userName;
        private const string host = "127.0.0.1";
        private const int port = 8888;
        static TcpClient client;
        static NetworkStream stream;
        

        static void Main(string[] args)
        {
            
            Console.Title = "Клиент";
            Console.Write("Введите свое имя: ");
            userName = Console.ReadLine();
            Console.WriteLine("==========");
            client = new TcpClient();
            try
            {
                client.Connect(host, port); //подключение клиента
                
                stream = client.GetStream(); // получаем поток
             
                    
                        
                string message = userName;
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);

                // запускаем новый поток для получения данных
                Thread receiveThread = new Thread(new ThreadStart(ReceiveMessage));
                receiveThread.Start(); //старт потока
                string Greeting = "║ Добро пожаловать: " + userName.ToString() + " ║";
                
                var line = "╔" + new string('═', Greeting.Length - 2) + "╗";
                var line2 = "╚" + new string('═', Greeting.Length - 2) + "╝";
                Console.WriteLine(line);
                Console.WriteLine(Greeting);
                Console.WriteLine(line2);
                SendMessage();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            finally
            {
                Disconnect();
            }
        }

        private static void Log(string v)
        {
            throw new NotImplementedException();
        }

        // отправка сообщений
        static void SendMessage()
        {
            Console.WriteLine("==========");
            Console.WriteLine("Введите сообщение: ");

            while (true)
            {
                string message = Console.ReadLine();
                Console.WriteLine("==========");
                byte[] data = Encoding.Unicode.GetBytes(message);
                stream.Write(data, 0, data.Length);
            }
        }
        // получение сообщений
        static void ReceiveMessage()
        {
            while (true)
            {
                try
                {
                    byte[] data = new byte[64]; // буфер для получаемых данных
                    StringBuilder builder = new StringBuilder();
                    int bytes = 0;
                    do
                    {
                        bytes = stream.Read(data, 0, data.Length);
                        builder.Append(Encoding.Unicode.GetString(data, 0, bytes));
                    }
                    while (stream.DataAvailable);

                    string message = builder.ToString();
                    Console.WriteLine("==========");
                    Console.WriteLine(message);//вывод сообщения
                }
                catch
                {
                    Console.WriteLine("==========");
                    Console.WriteLine("Подключение прервано!"); //соединение было прервано
                    Console.WriteLine("==========");
                    Console.ReadLine();
                    Disconnect();
                }
            }
        }

        static void Disconnect()
        {
            if (stream != null)
                stream.Close();//отключение потока
            if (client != null)
                client.Close();//отключение клиента
            Environment.Exit(0); //завершение процесса
        }

       
    }
}

