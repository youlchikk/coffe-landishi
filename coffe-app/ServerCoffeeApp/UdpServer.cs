using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace ServerCoffeeApp
{
    public class UdpServer
    {
        public static string dnsAddress;
        private static int PORT = 11000; // Порт для прослушивания
        private static int SIZE = 512; // Размер буфера для сообщений
        private UdpClient udpClient;

        public void Start()
        {
            Console.WriteLine("Сервер активен...\n");

            // Объявление сокета с протоколом UDP
            Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
            // Объявление конечной точки сетевого соединения
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);
            // Привязка сокета к сетевому интерфейсу 
            s1.Bind(endPoint);

            // Ждем подключения клиентов в бесконечном цикле 
            while (true)
            {
                EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] byteRec = new byte[SIZE]; // Буфер для сообщений от клиентов 
                // Получаем данные из связанного объекта        
                int lenBytesReceived = s1.ReceiveFrom(byteRec, ref clientEndPoint);
                Console.WriteLine("получено сообщение от клиента");

                // Создаем новый поток для обработки сообщения
                ThreadPool.QueueUserWorkItem(state =>
                {
                    HandleClient(byteRec, lenBytesReceived, clientEndPoint, s1);
                });
            }
        }

        // Метод для обработки сообщения клиента в отдельном потоке
        private void HandleClient(byte[] byteRec, int lenBytesReceived, EndPoint clientEndPoint, Socket s1)
        {
            // Декодируем все байты из указанного массива байтов в строку 
            string dataRec = Encoding.UTF8.GetString(byteRec, 0, lenBytesReceived);
            // Обрабатываем запрос и получаем ответ
            string response = HandleRequest(dataRec);
            // Кодируем ответ в байты
            byte[] responseData = Encoding.UTF8.GetBytes(response);
            // Отправляем ответ клиенту
            s1.SendTo(responseData, clientEndPoint);
            Console.WriteLine();
        }

        // Метод для обработки запроса
        private string HandleRequest(string message)
        {
            string[] parts = message.Split('|');

            // Обработка команды регистрации
            if (parts[0] == "register")
            {
                return checkRegister(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
            }
            // Обработка команды аутентификации
            else if (parts[0] == "login")
            {
                return checkAuthenticate(parts[1], parts[2]);
            }
            else if (parts[0] == "admin?")
            {
                return checkAdminOrUser(parts[1]);
            }
            Console.WriteLine("Неизвестная команда");
            return "Неизвестная команда";
        }

        // Метод для проверки регистрации
        string checkRegister(string username, string phone, string email, string birthdate, string password, string admin)
        {
            if (ExcelHandler.RegisterUser(username, phone, email, birthdate, password, admin))
            {
                Console.WriteLine(username + ": регистрация успешна");
                return "Регистрация успешна";
            }
            else
            {
                Console.WriteLine(username + ": пользователь с таким логином уже зарегестрирован");
                return "Пользователь с таким логином уже зарегестрирован";
            }
        }

        // Метод для проверки аутентификации
        string checkAuthenticate(string username, string password)
        {
            if (ExcelHandler.AuthenticateUser(username, password))
            {
                Console.WriteLine(username + ": аутентификация успешна");
                return "Аутентификация успешна";
            }
            else
            {
                Console.WriteLine(username + ": ошибка аутентификации");
                return "Ошибка аутентификации";
            }
        }

        // метод для проверки на администратора 
        string checkAdminOrUser(string username)
        {
            if (ExcelHandler.checkAdmin(username))
            {
                Console.WriteLine(username + ": подтверждение прав администратора");
                return "администратор";
            }
            else
            {
                Console.WriteLine(username + ": права администратора не подтверждены");
                return "пользователь";
            }
        }
    }
}
