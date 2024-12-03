using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using MenuDLL;
using System.Text.Json;
using System.Xml.Linq;
using System.Text.Json.Serialization;

namespace ServerCoffeeApp
{

    public class UdpServer
    {


        public static string dnsAddress;
        private static int PORT = 11000; // Порт для прослушивания
        private static int SIZE = 512; // Размер буфера для сообщений
        private UdpClient udpClient;
        public class Order
        {
            public string username { get; set; }
            public double price { get; set; }
            public int status { get; set; } // принят - 1, готовится - 2, готов - 3, выдан - 4 
            public bool pay { get; set; } // true - оплачен, false - не оплачен
            public List<Menu> components { get; set; } = new List<Menu>();

            // Параметрless конструктор
            public Order() { }

            // Метод для изменения статуса оплаты
            public void payment()
            {
                this.pay = true;
            }

            // Метод для изменения статуса заказа
            public void nextStatus()
            {
                this.status++;
            }
        }


        public List <Order> aktiveOrder = new List <Order> ();

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
            if (parts[0] == "register")                     // команда для регистрации       username + phone + email + birthdate + password + admin
            {
                return checkRegister(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
            }
            // Обработка команды аутентификации
            else if (parts[0] == "login")                     // команда для аутентификации         username + password
            {
                return checkAuthenticate(parts[1], parts[2]);
            }
            else if (parts[0] == "admin?")                    // команда для проверки администратор/обычный пользователь      username
            {
                return checkAdminOrUser(parts[1]);
            }
            else if (parts[0] == "checkUser")                   // команда для передачи данных о пользователе     username
            {
                return checkUser(parts[1]);
            }
            else if(parts[0] == "createOrder")                      // команда для создания заказа       username + json
            {
                return AddNewOrder(parts[1], parts[2]);
            }
            else if (parts[0] == "PaymentOrder")                    // команда для подтверждения оплаты заказа      username
            {
                return paymentOrder(parts[1]);
            }
            else if (parts[0] == "nextStatusOrder")                    // команда для обновления статуса заказа      username
            {
                return nextStatusOrder(parts[1]);
            }
            else if (parts[0] == "detailsOrder")                    // команда для получения деталей заказа      username
            {
                return detailsOrder(parts[1]);
            }
            else if (parts[0] == "deleteOrder")                    // команда для удаления заказа и добавления его в архив      username
            {
                return deleteOrder(parts[1]);
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

        string checkUser(string username)
        {
            string details = ExcelHandler.GetUserDetails(username);
            if (details == null)
            {
                Console.WriteLine(username + ": пользователь не найден");
                return "пользователь не найден";
            }
            return details;
        }

        string AddNewOrder(string username, string dataRec)
        {
            try
            {
                // Логируем полученный JSON
                Console.WriteLine("Полученный JSON:");
                Console.WriteLine(dataRec);

                // Десериализация JSON в объект
                Order receivedObject = JsonSerializer.Deserialize<Order>(dataRec);

                // Логируем десериализованный объект
                Console.WriteLine("Десериализованный объект:");
                Console.WriteLine($"Username: {receivedObject.username}");
                Console.WriteLine($"Price: {receivedObject.price}");
                Console.WriteLine($"Status: {receivedObject.status}");
                Console.WriteLine($"Pay: {receivedObject.pay}");
                Console.WriteLine($"Components: {receivedObject.components.Count}");

                aktiveOrder.Add(receivedObject);
                Console.WriteLine(username + ": заказ успешно добавлен");
                return "заказ успешно добавлен";
            }
            catch (Exception ex)
            {
                Console.WriteLine(username + ": ошибка при добавлении заказа");
                Console.WriteLine("Ошибка: " + ex.Message);
                return "ошибка при добавлении заказа";
            }
        }



        string paymentOrder(string username)
        {
            try
            {
                for (int i = 0; i < aktiveOrder.Count; i++)
                {
                    if (aktiveOrder[i].username == username)
                    {
                        aktiveOrder[i].payment();
                        Console.WriteLine(username + ": оплата успешно подтверждена");
                        return "оплата успешно подтверждена";
                    }
                }
                Console.WriteLine(username + ": заказ не найден");
                return "заказ не найден";
            }
            catch
            {
                Console.WriteLine(username + ": ошибка при подтверждении оплаты заказа");
                return "ошибка при подтверждении оплаты";
            }
        }

        string nextStatusOrder(string username)
        {
            try
            {
                for (int i = 0; i < aktiveOrder.Count; i++)
                {
                    if (aktiveOrder[i].username == username)
                    {
                        aktiveOrder[i].payment();
                        Console.WriteLine(username + ": статус успешно обновлен");
                        return "статус успешно обновлен";
                    }
                }
                Console.WriteLine(username + ": заказ не найден");
                return "заказ не найден";
            }
            catch
            {
                Console.WriteLine(username + ": ошибка при обновлении статуса заказа");
                return "ошибка при обновлении статуса заказа";
            }
        }

        string detailsOrder(string username)
        {
            try
            {
                for (int i = 0; i < aktiveOrder.Count; i++)
                {
                    if (aktiveOrder[i].username == username)
                    {
                        string jsonString = JsonSerializer.Serialize(aktiveOrder[i]);

                        Console.WriteLine(username + ": данные о заказе успешно получены");
                        return jsonString;
                    }
                }
                Console.WriteLine(username + ": заказ не найден");
                return "заказ не найден";
            }
            catch
            {
                Console.WriteLine(username + ": ошибка при получении данных о заказе");
                return "ошибка при получении данных о заказе";
            }
        }

        string deleteOrder(string username)
        {
            try
            {
                for (int i = 0; i < aktiveOrder.Count; i++)
                {
                    if (aktiveOrder[i].username == username)
                    {
                        ExcelHandler.AddToArchive(aktiveOrder[i].username, DateTime.Now.ToString("yyyy-MM-dd"), aktiveOrder[i].price);
                        aktiveOrder.RemoveAt(i);
                        Console.WriteLine(username + ": заказ удален, данные занесены в архив");
                        return "заказ удален, данные занесены в архив";
                    }
                }
                Console.WriteLine(username + ": заказ не найден");
                return "заказ не найден";
            }
            catch
            {
                Console.WriteLine(username + ": ошибка при удалении заказа");
                return "ошибка при удалении заказа";
            }
        }

    }
}
