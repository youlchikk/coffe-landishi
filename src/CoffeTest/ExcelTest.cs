using NUnit.Framework;
using ServerCoffeeApp;
using System.IO;
using OfficeOpenXml;
using System.ComponentModel;

namespace CoffeTest
{
    [TestFixture]
    public class ExcelHandlerTests
    {
        private string testFilePath = "TestUsers.xlsx";
        private string testFilePathArchive = "TestArxiv.xlsx";

        [SetUp]
        public void SetUp()
        {
            // Копируем тестовый файл перед каждым тестом, чтобы изменения не влияли на другие тесты
            File.Copy("../../Users.xlsx", testFilePath, true);
            ExcelHandler.filePath = testFilePath;
            ExcelHandler.filePathArchive = testFilePathArchive;

        }

        [TearDown]
        public void TearDown()
        {
            // Удаляем тестовый файл после каждого теста
            if (File.Exists(testFilePath))
            {
                File.Delete(testFilePath);
            }
        }

        [Test]
        public void RegisterUser_ShouldReturnTrueForNewUser()
        {
            // Arrange
            string username = "newuser";
            string phone = "+12345678901";
            string email = "newuser@example.com";
            string birthdate = "01/01/2000";
            string password = "password123";
            string admin = "user";

            // Act
            bool result = ExcelHandler.RegisterUser(username, phone, email, birthdate, password, admin);

            // Assert
            Assert.IsTrue(result);

            // Проверяем, что пользователь был добавлен в Excel
            using (var package = new ExcelPackage(new FileInfo(testFilePath)))
            {
                var worksheet = package.Workbook.Worksheets["Лист1"];
                bool userFound = false;
                for (int row = 2; row <= worksheet.Dimension.End.Row; row++)
                {
                    if (worksheet.Cells[row, 1].Text == username)
                    {
                        userFound = true;
                        break;
                    }
                }
                Assert.IsTrue(userFound);
            }
        }



        [Test]
        public void AuthenticateUser_ShouldReturnFalseForInvalidCredentials()
        {
            // Arrange
            string username = "invaliduser";
            string password = "invalidpassword";

            // Act
            bool result = ExcelHandler.AuthenticateUser(username, password);

            // Assert
            Assert.IsFalse(result);
        }



        [Test]
        public void CheckAdmin_ShouldReturnFalseForNonAdminUser()
        {
            // Arrange
            string username = "regularuser"; // Пользователь с таким именем и ролью user существует в тестовом файле

            // Act
            bool result = ExcelHandler.checkAdmin(username);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void GetUserDetails_ShouldReturnNullForNonExistingUser()
        {
            // Arrange
            string username = "nonexistinguser";

            // Act
            string userDetails = ExcelHandler.GetUserDetails(username);

            // Assert
            Assert.IsNull(userDetails);
        }
    }
}
