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
    public static class ExcelHandler
    {

        public static string filePath = "../../Users.xlsx";

        public static bool RegisterUser(string username, string phone, string email, string birthdate, string password)
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
    }
}