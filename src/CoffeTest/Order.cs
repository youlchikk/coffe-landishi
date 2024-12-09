using NUnit.Framework;
using MenuDLL;
using System.Collections.Generic;
using coffe_app;

namespace CoffeTest
{
    public class OrderTests
    {
        [Test]
        public void AddPromotion_ShouldUpdatePriceAndComponents()
        {
            // Arrange
            var order = new Order("user1", 100, new List<MenuDLL.Menu>());
            var promotion = new Promotion(
                "Special Discount",
                new List<MenuDLL.Menu>
                {
                    new MenuDLL.Menu { description = "Promotion Item", price = 0 }
                },
                -10,
                "2023-12-01",
                "2023-12-31"
            );

            // Act
            order.addPromotion(promotion);

            // Assert
            Assert.AreEqual(90, order.price);
            Assert.AreEqual(1, order.components.Count);
            Assert.AreEqual("Promotion Item", order.components[0].description);
        }

        [Test]
        public void Payment_ShouldSetPayToTrue()
        {
            // Arrange
            var order = new Order("user1", 100, new List<MenuDLL.Menu>());

            // Act
            order.payment();

            // Assert
            Assert.IsTrue(order.pay);
        }

        [Test]
        public void NextStatus_ShouldUpdateStatus()
        {
            // Arrange
            var order = new Order("user1", 100, new List<MenuDLL.Menu>());

            // Act
            order.nextStatus(3);

            // Assert
            Assert.AreEqual(3, order.status);
        }


            [Test]
            public void AddMultipleComponents_ShouldUpdatePriceAndComponents()
            {
                // Arrange
                var order = new Order("user1", 100, new List<MenuDLL.Menu>());
                var component1 = new MenuDLL.Menu { description = "Coffee", price = 50 };
                var component2 = new MenuDLL.Menu { description = "Donut", price = 30 };

                // Act
                order.components.Add(component1);
                order.price += component1.price;
                order.components.Add(component2);
                order.price += component2.price;

                // Assert
                Assert.AreEqual(180, order.price);
                Assert.AreEqual(2, order.components.Count);
                Assert.AreEqual("Coffee", order.components[0].description);
                Assert.AreEqual("Donut", order.components[1].description);
            }

            [Test]
            public void RemoveComponent_ShouldUpdatePriceAndComponents()
            {
                // Arrange
                var order = new Order("user1", 100, new List<MenuDLL.Menu>());
                var component = new MenuDLL.Menu { description = "Coffee", price = 50 };
                order.components.Add(component);
                order.price += component.price;

                // Act
                order.components.Remove(component);
                order.price -= component.price;

                // Assert
                Assert.AreEqual(100, order.price);
                Assert.AreEqual(0, order.components.Count);
            }
        }
    }
