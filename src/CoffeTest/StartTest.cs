using coffe_app;
using NUnit.Framework;

namespace CoffeTest
{
    public class ValidationHelperTests
    {
        [Test]
        public void IsValidPhone_ShouldReturnTrueForValidNumber()
        {
            // Arrange
            string validPhoneNumber = "+12345678901";

            // Act
            bool result = ValidationHelper.IsValidPhone(validPhoneNumber);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidPhone_ShouldReturnFalseForInvalidNumber()
        {
            // Arrange
            string invalidPhoneNumber = "12345";

            // Act
            bool result = ValidationHelper.IsValidPhone(invalidPhoneNumber);

            // Assert
            Assert.IsFalse(result);
        }

        [Test]
        public void IsValidEmail_ShouldReturnTrueForValidEmail()
        {
            // Arrange
            string validEmail = "example@example.com";

            // Act
            bool result = ValidationHelper.IsValidEmail(validEmail);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsValidEmail_ShouldReturnFalseForInvalidEmail()
        {
            // Arrange
            string invalidEmail = "example.com";

            // Act
            bool result = ValidationHelper.IsValidEmail(invalidEmail);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
