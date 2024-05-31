using Xunit;
using FlowerClient.View;
using FlowerClient.Model;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using FlowerClient.PresenterProducts;
using NUnit.Framework;

namespace FlowerClient.Tests
{
    public class CartViewTests
    {
        private CartView cartView;  // Переменная для хранения экземпляра CartView
        private Mock<ICartPresenter> mockPresenter;  // Мок для ICartPresenter

        public CartViewTests()
        {
            mockPresenter = new Mock<ICartPresenter>();  // Инициализация мока
            cartView = new CartView();  // Инициализация CartView
        }

        [Fact]
        public async Task BonusesCount_ShouldDisplayBonuses() // проверяет, что метод BonusesCount класса CartView корректно отображает количество бонусов
        {
            // Arrange
            var bonus = new Bonus { Bonuses = 10 };  // Создание объекта Bonus с количеством бонусов 10
            mockPresenter.Setup(p => p.BonusesForBuy()).Returns(Task.FromResult(bonus));  // Настройка мока для возвращения объекта bonus при вызове BonusesForBuy

            // Act
            await cartView.BonusesCount();  // Вызов метода для подсчета бонусов

            // Assert
            Xunit.Assert.Equal("10", cartView.Bonuses.Text);  // Проверка, что свойство Bonuses объекта cartView равно "10"
        }

        [Fact]
        public async Task SumPrice_ShouldCalculateSum() // проверяет, что метод SumPrice класса CartView корректно вычисляет общую сумму продуктов в корзине
        {
            // Arrange
            var productsBuy = new List<CartItem>  // Создание списка продуктов для покупки
            {
                new CartItem { productId = 1, count = 2 },  // Продукт с ID 1 и количеством 2
                new CartItem { productId = 2, count = 1 }   // Продукт с ID 2 и количеством 1
            };
            var product1 = new Product { Id = 1, Name = "Product1", Price = 10 };  // Создание продукта с ID 1, именем "Product1" и ценой 10
            var product2 = new Product { Id = 2, Name = "Product2", Price = 20 };  // Создание продукта с ID 2, именем "Product2" и ценой 20
            mockPresenter.Setup(p => p.OneProduct(1)).Returns(Task.FromResult(product1));  // Настройка мока для возвращения продукта product1 при вызове OneProduct с аргументом 1
            mockPresenter.Setup(p => p.OneProduct(2)).Returns(Task.FromResult(product2));  // Настройка мока для возвращения продукта product2 при вызове OneProduct с аргументом 2

            // Act
            await cartView.SumPrice(productsBuy);  // Вызов метода для подсчета общей суммы покупки

            // Assert
            Xunit.Assert.Equal("40", cartView.Sum.Text);  // Проверка, что текст свойства Sum объекта cartView равен "40"
        }

        [Fact]
        public async Task DeleteNullProducts_ShouldDeleteProducts() // проверяет, что метод DeleteNullProducts класса CartView корректно удаляет продукты с нулевым количеством из корзины
        {
            // Arrange
            var products = new List<Product>  // Создание списка продуктов
            {
                new Product { Id = 1, Name = "Product1", Count = 0 },  // Продукт с ID 1, именем "Product1" и количеством 0
                new Product { Id = 2, Name = "Product2", Count = 5 }   // Продукт с ID 2, именем "Product2" и количеством 5
            };
            mockPresenter.Setup(p => p.AllProducts()).Returns(Task.FromResult(products));  // Настройка мока для возвращения списка продуктов при вызове метода AllProducts

            // Act
            await cartView.DeleteNullProducts();  // Вызов метода для удаления продуктов с количеством 0

            // Assert
            mockPresenter.Verify(p => p.DeleteProduct(1), Times.Once);  // Проверка, что метод DeleteProduct был вызван один раз для продукта с ID 1
            mockPresenter.Verify(p => p.DeleteProduct(2), Times.Never);  // Проверка, что метод DeleteProduct не был вызван для продукта с ID 2
        }
    }
}
