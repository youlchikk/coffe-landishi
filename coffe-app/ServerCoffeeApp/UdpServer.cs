﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace ServerCoffeeApp
{
    public class UdpServer
    {
        public static string dnsAddress;
        private static int PORT = 11000;
        private static int SIZE = 512;
        private UdpClient udpClient;

        public void Start()
        {
            Console.WriteLine("Сервер активен...\n");

            Socket s1 = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);  //объявление сокета с протоколом UDP
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, PORT);  //объявление конечной точки сетевого соединения
            s1.Bind(endPoint);  //привязка сокета к сетевому интерфейсу 
            while (true) //ждем подключения клиентов в бесконечном цикле 
            {
                String dataRec = "";
                EndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                byte[] byteRec = new byte[SIZE]; // буфер для сообщений от клиентов 
                // получаем данные из связанного объекта        
                int lenBytesReceived = s1.ReceiveFrom(byteRec, ref clientEndPoint);
                Console.WriteLine("получено сообщение от клиента");
                // декодируем все байты из указанного массива байтов в строку 
                dataRec += Encoding.UTF8.GetString(byteRec, 0, lenBytesReceived);
                string response = HandleRequest(dataRec);
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                s1.SendTo(responseData, clientEndPoint);
                Console.WriteLine();
            }
        }

        private string HandleRequest(string message)
        {
            string[] parts = message.Split('|');
            string command = parts[0];
            string username = parts[1];
            string phone = "";
            if(parts.Length > 3) phone = parts[2];
            string email = "";
            if (parts.Length > 3) email = parts[3];
            string birthdate = "";
            if (parts.Length > 3) birthdate = parts[4];
            string password = parts[2];
            if(parts.Length > 3) password = parts[5];

            if (command == "register")
            {
                return checkRegister(username, phone, email, birthdate, password);
            }
            else if (command == "login")
            {
                return checkAuthenticate(username, password);
            }
            Console.WriteLine("Неизвестная команда");
            return "Неизвестная команда";
        }

        string checkRegister(string username, string phone, string email, string birthdate, string password)
        {
            if (ExcelHandler.RegisterUser(username, phone, email, birthdate, password))
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
    }
}
