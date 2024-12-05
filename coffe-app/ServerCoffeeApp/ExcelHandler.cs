using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.ComponentModel;

namespace ServerCoffeeApp
{
    /// <summary>
    /// Класс для взаимодействия с Excel-файлами.
    /// </summary>
    public static class ExcelHandler         
    {

        public static string filePath = "../../Users.xlsx";
        public static string filePathArchive = "../../arxiv.xlsx";

        /// <summary>
        /// Регистрирует нового пользователя в Excel-файле.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="phone">Номер телефона пользователя.</param>
        /// <param name="email">Электронная почта пользователя.</param>
        /// <param name="birthdate">Дата рождения пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <param name="admin">Роль пользователя (по умолчанию "user").</param>
        /// <returns>true, если регистрация успешна; false, если пользователь уже существует.</returns>
        public static bool RegisterUser(string username, string phone, string email, string birthdate, string password, string admin = "user")
        {
            // Устанавливаем контекст лицензии для использования библиотеки OfficeOpenXml
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Открываем Excel-файл
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Получаем первый лист в книге
                var worksheet = package.Workbook.Worksheets["Лист1"];

                // Проверяем, существует ли уже пользователь с таким именем
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username)
                    {
                        return false; // Пользователь уже существует
                    }
                }

                // Добавляем нового пользователя в следующую строку
                int newRow = worksheet.Dimension.End.Row + 1;
                worksheet.Cells[newRow, 1].Value = username;
                worksheet.Cells[newRow, 2].Value = phone;
                worksheet.Cells[newRow, 3].Value = email;
                worksheet.Cells[newRow, 4].Value = birthdate;
                worksheet.Cells[newRow, 5].Value = password;
                worksheet.Cells[newRow, 6].Value = admin;

                // Сохраняем изменения в Excel-файле
                package.Save();
            }

            return true; // Регистрация успешна
        }


        /// <summary>
        /// Аутентифицирует пользователя по имени и паролю.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="password">Пароль пользователя.</param>
        /// <returns>true, если аутентификация успешна; false, если имя пользователя или пароль неверны.</returns>
        public static bool AuthenticateUser(string username, string password)
        {
            // Устанавливаем контекст лицензии для использования библиотеки OfficeOpenXml
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Открываем Excel-файл
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Получаем первый лист в книге
                var worksheet = package.Workbook.Worksheets["Лист1"];

                // Проверяем имя пользователя и пароль
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username && worksheet.Cells[row, 5].Text == password)
                    {
                        return true; // Аутентификация успешна
                    }
                }
            }

            return false; // Аутентификация не удалась
        }


        /// <summary>
        /// Проверяет, является ли пользователь администратором.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>true, если пользователь является администратором; false, если нет.</returns>
        public static bool checkAdmin(string username)
        {
            // Устанавливаем контекст лицензии для использования библиотеки OfficeOpenXml
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Открываем Excel-файл
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Получаем первый лист в книге
                var worksheet = package.Workbook.Worksheets["Лист1"];

                // Проверяем, является ли пользователь администратором
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username && worksheet.Cells[row, 6].Text == "admin")
                    {
                        return true; // Пользователь является администратором
                    }
                }
            }

            return false; // Пользователь не является администратором
        }


        /// <summary>
        /// Получает детали пользователя по имени.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <returns>Строка с деталями пользователя, разделенными символом '|', или null, если пользователь не найден.</returns>
        public static string GetUserDetails(string username)
        {
            // Устанавливаем контекст лицензии для использования библиотеки OfficeOpenXml
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Открываем Excel-файл
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Получаем первый лист в книге
                var worksheet = package.Workbook.Worksheets["Лист1"];

                // Ищем пользователя по имени
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username)
                    {
                        // Извлекаем детали пользователя
                        string phone = worksheet.Cells[row, 2].Text;
                        string email = worksheet.Cells[row, 3].Text;
                        string birthdate = worksheet.Cells[row, 4].Text;
                        string admin = worksheet.Cells[row, 6].Text;

                        // Возвращаем детали пользователя в виде строки
                        return $"{phone}|{email}|{birthdate}|{admin}";
                    }
                }
            }

            return null; // Возвращаем null, если пользователь не найден
        }


        /// <summary>
        /// Метод для добавления данных в файл Archive.xlsx.
        /// </summary>
        /// <param name="username">Имя пользователя.</param>
        /// <param name="date">Дата завершенного заказа</param>
        /// <param name="price">Сумма заказа</param>
        public static void AddToArchive(string username, string date, double price)
        {
            // Устанавливаем контекст лицензии для использования библиотеки OfficeOpenXml
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            // Открываем Excel-файл
            using (var package = new ExcelPackage(new FileInfo(filePathArchive)))
            {
                // Получаем лист "Архив" или создаем его, если он не существует
                var worksheet = package.Workbook.Worksheets["Архив"];
                if (worksheet == null)
                {
                    worksheet = package.Workbook.Worksheets.Add("Архив");
                }

                // Определяем новую строку для добавления данных
                int newRow = worksheet.Dimension?.End.Row + 1 ?? 1;
                worksheet.Cells[newRow, 1].Value = username;
                worksheet.Cells[newRow, 2].Value = date;
                worksheet.Cells[newRow, 3].Value = price;

                // Сохраняем изменения в Excel-файле
                package.Save();
            }
        }

        /// <summary>
        /// Получает данные из файла Archive.xlsx.
        /// </summary>
        /// <returns>Строка с данными из архива, разделенными символом '|', или пустая строка в случае ошибки.</returns>
        public static string GetArchiveData()
        {
            // Устанавливаем контекст лицензии для использования библиотеки OfficeOpenXml
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            try
            {
                // Открываем Excel-файл
                using (var package = new ExcelPackage(new FileInfo(filePathArchive)))
                {
                    // Получаем лист "Архив"
                    var worksheet = package.Workbook.Worksheets["Архив"];
                    if (worksheet == null)
                    {
                        Console.WriteLine("Worksheet Архив не найден");
                        return string.Empty; // Возвращаем пустую строку, если лист не найден
                    }

                    var sb = new StringBuilder();
                    int rowCount = worksheet.Dimension?.Rows ?? 0;

                    if (rowCount == 0)
                    {
                        Console.WriteLine("Файл Archive.xlsx пуст");
                        return string.Empty; // Возвращаем пустую строку, если файл пуст
                    }

                    // Читаем данные из каждой строки
                    for (int row = 1; row <= rowCount; row++)
                    {
                        var username = worksheet.Cells[row, 1].Text;
                        var date = worksheet.Cells[row, 2].Text;
                        var price = worksheet.Cells[row, 3].Text;

                        sb.Append($"{username} {date} {price}");
                        if (row < rowCount)
                        {
                            sb.Append("|"); // Добавляем разделитель, если это не последняя строка
                        }
                    }

                    return sb.ToString(); // Возвращаем строку с данными
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных из архива: {ex.Message}");
                return string.Empty; // Возвращаем пустую строку в случае ошибки
            }
        }


    }
}