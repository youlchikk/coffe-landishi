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
using System.IO;

namespace ServerCoffeeApp
{
    /// <summary>
    /// Класс, представляющий UDP сервер.
    /// </summary>
    public class UdpServer
    {
        /// <summary>
        /// DNS адрес сервера.
        /// </summary>
        public static string dnsAddress;

        /// <summary>
        /// Порт для прослушивания.
        /// </summary>
        private static int PORT = 11000;

        /// <summary>
        /// Размер буфера для сообщений.
        /// </summary>
        private static int SIZE = 51200000;

        /// <summary>
        /// UDP клиент.
        /// </summary>
        private UdpClient udpClient;

        /// <summary>
        /// Список активных заказов.
        /// </summary>
        public List<MenuDLL.Order> aktiveOrder = new List<MenuDLL.Order>();

        /// <summary>
        /// Запускает сервер.
        /// </summary>
        public void Start()
        {
            string filePath = "../../log.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine("Сервер активен: " + DateTime.Now + "\n");
            }

            Console.WriteLine("Сервер активен: " + DateTime.Now + "\n");

            /// <summary>
            /// Объявление сокета с протоколом UDP.
            /// </summary>
            Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);

            /// <summary>
            /// Объявление конечной точки сетевого соединения.
            /// </summary>
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);

            /// <summary>
            /// Привязка сокета к сетевому интерфейсу.
            /// </summary>
            s1.Bind(endPoint);

            /// <summary>
            /// Ждем подключения клиентов в бесконечном цикле.
            /// </summary>
            while (true)
            {
                EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] byteRec = new byte[SIZE]; /// Буфер для сообщений от клиентов 

                                                 /// <summary>
                                                 /// Получаем данные из связанного объекта.
                                                 /// </summary>
                int lenBytesReceived = s1.ReceiveFrom(byteRec, ref clientEndPoint);
                Console.WriteLine("получено сообщение от клиента");

                /// <summary>
                /// Создаем новый поток для обработки сообщения.
                /// </summary>
                ThreadPool.QueueUserWorkItem(state =>
                {
                    HandleClient(byteRec, lenBytesReceived, clientEndPoint, s1);
                });
            }
        }

        /// <summary>
        /// Метод для обработки сообщения клиента в отдельном потоке.
        /// </summary>
        /// <param name="byteRec">Массив байтов, полученных от клиента.</param>
        /// <param name="lenBytesReceived">Длина полученного сообщения в байтах.</param>
        /// <param name="clientEndPoint">Конечная точка клиента.</param>
        /// <param name="s1">Сокет для отправки ответа.</param>
        private void HandleClient(byte[] byteRec, int lenBytesReceived, EndPoint clientEndPoint, Socket s1)
        {
            /// <summary>
            /// Декодируем все байты из указанного массива байтов в строку.
            /// </summary>
            string dataRec = Encoding.UTF8.GetString(byteRec, 0, lenBytesReceived);

            /// <summary>
            /// Обрабатываем запрос и получаем ответ.
            /// </summary>
            Console.WriteLine(dataRec);
            string response = HandleRequest(dataRec);

            /// <summary>
            /// Кодируем ответ в байты.
            /// </summary>
            byte[] responseData = Encoding.UTF8.GetBytes(response);

            /// <summary>
            /// Отправляем ответ клиенту.
            /// </summary>
            s1.SendTo(responseData, clientEndPoint);
            Console.WriteLine();

            string filePath = "../../log.txt";

            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(dataRec.Split('|')[0] + ": " + response);
            }
         }


        /// <summary>
        /// Метод для обработки запроса.
        /// </summary>
        /// <param name="message">Сообщение от клиента.</param>
        /// <returns>Ответ на запрос клиента.</returns>
        private string HandleRequest(string message)
        {
            string[] parts = message.Split('|');

            /// <summary>
            /// Обработка команды регистрации.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            /// <param name="parts[2]">Телефон.</param>
            /// <param name="parts[3]">Email.</param>
            /// <param name="parts[4]">Дата рождения.</param>
            /// <param name="parts[5]">Пароль.</param>
            /// <param name="parts[6]">Администратор.</param>
            if (parts[0] == "register")
            {
                return checkRegister(parts[1], parts[2], parts[3], parts[4], parts[5], parts[6]);
            }

            /// <summary>
            /// Обработка команды аутентификации.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            /// <param name="parts[2]">Пароль.</param>
            else if (parts[0] == "login")
            {
                return checkAuthenticate(parts[1], parts[2]);
            }

            /// <summary>
            /// Обработка команды проверки администратор/обычный пользователь.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            else if (parts[0] == "admin?")
            {
                return checkAdminOrUser(parts[1]);
            }

            /// <summary>
            /// Обработка команды передачи данных о пользователе.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            else if (parts[0] == "checkUser")
            {
                return checkUser(parts[1]);
            }

            /// <summary>
            /// Обработка команды создания заказа.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            /// <param name="parts[2]">Заказ в формате JSON.</param>
            else if (parts[0] == "createOrder")
            {
                string username = parts[1];
                string jsonOrder = parts[2];
                var order = JsonSerializer.Deserialize<Order>(jsonOrder);

                /// <summary>
                /// Логируем получение заказа.
                /// </summary>
                Console.WriteLine("Получен заказ:");
                Console.WriteLine(jsonOrder);

                /// <summary>
                /// Обработка заказа.
                /// </summary>
                string response = AddNewOrder(username, jsonOrder);

                /// <summary>
                /// Логируем ответ сервера.
                /// </summary>
                Console.WriteLine("Ответ сервера:");
                Console.WriteLine(response);

                return response;
            }

            /// <summary>
            /// Обработка команды подтверждения оплаты заказа.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            else if (parts[0] == "PaymentOrder")
            {
                return paymentOrder(parts[1]);
            }

            /// <summary>
            /// Обработка команды обновления статуса заказа.
            /// </summary>
            /// <param name="parts[1]">Статус.</param>
            /// <param name="parts[2]">Имя пользователя.</param>
            else if (parts[0] == "nextStatusOrder")
            {
                return nextStatusOrder(parts[1], parts[2]);
            }

            /// <summary>
            /// Обработка команды получения деталей заказа.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            else if (parts[0] == "detailsOrder")
            {
                return detailsOrder(parts[1]);
            }

            /// <summary>
            /// Обработка команды удаления заказа и добавления его в архив.
            /// </summary>
            /// <param name="parts[1]">Имя пользователя.</param>
            else if (parts[0] == "deleteOrder")
            {
                return deleteOrder(parts[1]);
            }

            /// <summary>
            /// Обработка команды получения всех заказов.
            /// </summary>
            else if (parts[0] == "getOrders")
            {
                return getOrders();
            }

            /// <summary>
            /// Обработка команды получения архива.
            /// </summary>
            else if (parts[0] == "getArchive")
            {
                return getArchive();
            }

            Console.WriteLine("Неизвестная команда: " + parts[0]);
            return "Неизвестная команда";
        }


        /// <summary>
        /// Метод для проверки регистрации.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="phone">Телефон.</param>
        /// <param name="email">Email.</param>
        /// <param name="birthdate">Дата рождения.</param>
        /// <param name="password">Пароль.</param>
        /// <param name="admin">Администратор.</param>
        /// <returns>Сообщение о результате регистрации.</returns>
        string checkRegister(string username, string phone, string email, string birthdate, string password, string admin)
        {
            if (ExcelHandler.RegisterUser(username, phone, email, birthdate, password, admin))
            {
                Console.WriteLine(username + ": регистрация успешна");
                return "Регистрация успешна";
            }
            else
            {
                Console.WriteLine(username + ": пользователь с таким логином уже зарегистрирован");
                return "Пользователь с таким логином уже зарегистрирован";
            }
        }

        /// <summary>
        /// Метод для проверки аутентификации.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Сообщение о результате аутентификации.</returns>
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

        /// <summary>
        /// Метод для проверки на администратора.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Статус пользователя (администратор или пользователь).</returns>
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


        /// <summary>
        /// Метод для проверки данных пользователя.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Детали пользователя или сообщение о том, что пользователь не найден.</returns>
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

        /// <summary>
        /// Метод для добавления нового заказа.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="dataRec">Данные заказа в формате JSON.</param>
        /// <returns>Сообщение о результате добавления заказа.</returns>
        string AddNewOrder(string username, string dataRec)
        {
            try
            {
                /// <summary>
                /// Логируем полученный JSON.
                /// </summary>
                Console.WriteLine("Полученный JSON:");
                Console.WriteLine(dataRec);

                /// <summary>
                /// Десериализация JSON в объект.
                /// </summary>
                MenuDLL.Order receivedObject = JsonSerializer.Deserialize<MenuDLL.Order>(dataRec);

                /// <summary>
                /// Логируем десериализованный объект.
                /// </summary>
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

        /// <summary>
        /// Метод для подтверждения оплаты заказа.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Сообщение о результате подтверждения оплаты.</returns>
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

        /// <summary>
        /// Метод для обновления статуса заказа.
        /// </summary>
        /// <param name="t">Новый статус заказа.</param>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Сообщение о результате обновления статуса.</returns>
        string nextStatusOrder(string t, string username)
        {
            try
            {
                for (int i = 0; i < aktiveOrder.Count; i++)
                {
                    if (aktiveOrder[i].username == username)
                    {
                        aktiveOrder[i].nextStatus(Convert.ToInt32(t));
                        Console.WriteLine(username + ": статус успешно обновлен " + aktiveOrder[i].status.ToString());
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

        /// <summary>
        /// Метод для получения деталей заказа.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Детали заказа в формате JSON или сообщение о том, что заказ не найден.</returns>
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

        /// <summary>
        /// Метод для удаления заказа и добавления его в архив.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Сообщение о результате удаления заказа.</returns>
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


        /// <summary>
        /// Метод для получения всех заказов.
        /// </summary>
        /// <returns>Данные о заказах в формате JSON или сообщение об ошибке.</returns>
        string getOrders()
        {
            try
            {
                string message = "";
                for (int i = 0; i < aktiveOrder.Count; i++)
                {
                    string str = JsonSerializer.Serialize(aktiveOrder[i]);
                    message += str;
                    if (i + 1 < aktiveOrder.Count) message += "|";
                }
                Console.WriteLine("данные о заказах успешно получены");
                return message;
            }
            catch
            {
                Console.WriteLine("ошибка при получении данных о заказах");
                return "ошибка при получении данных о заказах";
            }
        }

        /// <summary>
        /// Метод для получения архива.
        /// </summary>
        /// <returns>Данные архива.</returns>
        string getArchive()
        {
            Console.WriteLine("Архив успешно получен");
            return ExcelHandler.GetArchiveData();
        }


    }
}
