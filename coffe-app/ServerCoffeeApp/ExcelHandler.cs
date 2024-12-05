﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.IO;
using System.ComponentModel;

namespace ServerCoffeeApp
{
    public static class ExcelHandler
    {

        public static string filePath = "../../Users.xlsx";
        public static string filePathArchive = "../../arxiv.xlsx";
        public static bool RegisterUser(string username, string phone, string email, string birthdate, string password, string admin = "user")
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Лист1"];

                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username)
                    {
                        return false;
                    }
                }
                int newRow = worksheet.Dimension.End.Row + 1;
                worksheet.Cells[newRow, 1].Value = username;
                worksheet.Cells[newRow, 2].Value = phone;
                worksheet.Cells[newRow, 3].Value = email;
                worksheet.Cells[newRow, 4].Value = birthdate;
                worksheet.Cells[newRow, 5].Value = password;
                worksheet.Cells[newRow, 6].Value = admin;
                package.Save();
            }
            return true;
        }

        public static bool AuthenticateUser(string username, string password)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Лист1"];
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username && worksheet.Cells[row, 5].Text == password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool checkAdmin(string username)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Лист1"];
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username && worksheet.Cells[row, 6].Text == "admin")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static string GetUserDetails(string username)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets["Лист1"];
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username)
                    {
                        string phone = worksheet.Cells[row, 2].Text;
                        string email = worksheet.Cells[row, 3].Text;
                        string birthdate = worksheet.Cells[row, 4].Text;
                        string admin = worksheet.Cells[row, 6].Text;
                        return $"{phone}|{email}|{birthdate}|{admin}";
                    }
                }
            }
            return null; // Возвращаем null, если пользователь не найден
        }

        // метод для добавления данных в файл Archive.xlsx
        public static void AddToArchive(string username, string date, double price)
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            using (var package = new ExcelPackage(new FileInfo(filePathArchive)))
            {
                var worksheet = package.Workbook.Worksheets["Архив"];
                if (worksheet == null)
                {
                    worksheet = package.Workbook.Worksheets.Add("Архив");
                }

                int newRow = worksheet.Dimension?.End.Row + 1 ?? 1;
                worksheet.Cells[newRow, 1].Value = username;
                worksheet.Cells[newRow, 2].Value = date;
                worksheet.Cells[newRow, 3].Value = price;

                package.Save();
            }
        }
        public static string GetArchiveData()
        {
            OfficeOpenXml.ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            try
            {
                using (var package = new ExcelPackage(new FileInfo(filePathArchive)))
                {
                    var worksheet = package.Workbook.Worksheets["Архив"];
                    if (worksheet == null)
                    {
                        Console.WriteLine("Worksheet Архив не найден");
                        return string.Empty;
                    }

                    var sb = new StringBuilder();
                    int rowCount = worksheet.Dimension?.Rows ?? 0;

                    if (rowCount == 0)
                    {
                        Console.WriteLine("Файл Archive.xlsx пуст");
                        return string.Empty;
                    }

                    for (int row = 1; row <= rowCount; row++)
                    {
                        var username = worksheet.Cells[row, 1].Text;
                        var date = worksheet.Cells[row, 2].Text;
                        var price = worksheet.Cells[row, 3].Text;

                        sb.Append($"{username} {date} {price}");
                        if (row < rowCount)
                        {
                            sb.Append("|");
                        }
                    }

                    return sb.ToString();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении данных из архива: {ex.Message}");
                return string.Empty;
            }
        }


    }
}