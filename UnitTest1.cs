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
        private CartView cartView;  // ���������� ��� �������� ���������� CartView
        private Mock<ICartPresenter> mockPresenter;  // ��� ��� ICartPresenter

        public CartViewTests()
        {
            mockPresenter = new Mock<ICartPresenter>();  // ������������� ����
            cartView = new CartView();  // ������������� CartView
        }

        [Fact]
        public async Task BonusesCount_ShouldDisplayBonuses() // ���������, ��� ����� BonusesCount ������ CartView ��������� ���������� ���������� �������
        {
            // Arrange
            var bonus = new Bonus { Bonuses = 10 };  // �������� ������� Bonus � ����������� ������� 10
            mockPresenter.Setup(p => p.BonusesForBuy()).Returns(Task.FromResult(bonus));  // ��������� ���� ��� ����������� ������� bonus ��� ������ BonusesForBuy

            // Act
            await cartView.BonusesCount();  // ����� ������ ��� �������� �������

            // Assert
            Xunit.Assert.Equal("10", cartView.Bonuses.Text);  // ��������, ��� �������� Bonuses ������� cartView ����� "10"
        }

        [Fact]
        public async Task SumPrice_ShouldCalculateSum() // ���������, ��� ����� SumPrice ������ CartView ��������� ��������� ����� ����� ��������� � �������
        {
            // Arrange
            var productsBuy = new List<CartItem>  // �������� ������ ��������� ��� �������
            {
                new CartItem { productId = 1, count = 2 },  // ������� � ID 1 � ����������� 2
                new CartItem { productId = 2, count = 1 }   // ������� � ID 2 � ����������� 1
            };
            var product1 = new Product { Id = 1, Name = "Product1", Price = 10 };  // �������� �������� � ID 1, ������ "Product1" � ����� 10
            var product2 = new Product { Id = 2, Name = "Product2", Price = 20 };  // �������� �������� � ID 2, ������ "Product2" � ����� 20
            mockPresenter.Setup(p => p.OneProduct(1)).Returns(Task.FromResult(product1));  // ��������� ���� ��� ����������� �������� product1 ��� ������ OneProduct � ���������� 1
            mockPresenter.Setup(p => p.OneProduct(2)).Returns(Task.FromResult(product2));  // ��������� ���� ��� ����������� �������� product2 ��� ������ OneProduct � ���������� 2

            // Act
            await cartView.SumPrice(productsBuy);  // ����� ������ ��� �������� ����� ����� �������

            // Assert
            Xunit.Assert.Equal("40", cartView.Sum.Text);  // ��������, ��� ����� �������� Sum ������� cartView ����� "40"
        }

        [Fact]
        public async Task DeleteNullProducts_ShouldDeleteProducts() // ���������, ��� ����� DeleteNullProducts ������ CartView ��������� ������� �������� � ������� ����������� �� �������
        {
            // Arrange
            var products = new List<Product>  // �������� ������ ���������
            {
                new Product { Id = 1, Name = "Product1", Count = 0 },  // ������� � ID 1, ������ "Product1" � ����������� 0
                new Product { Id = 2, Name = "Product2", Count = 5 }   // ������� � ID 2, ������ "Product2" � ����������� 5
            };
            mockPresenter.Setup(p => p.AllProducts()).Returns(Task.FromResult(products));  // ��������� ���� ��� ����������� ������ ��������� ��� ������ ������ AllProducts

            // Act
            await cartView.DeleteNullProducts();  // ����� ������ ��� �������� ��������� � ����������� 0

            // Assert
            mockPresenter.Verify(p => p.DeleteProduct(1), Times.Once);  // ��������, ��� ����� DeleteProduct ��� ������ ���� ��� ��� �������� � ID 1
            mockPresenter.Verify(p => p.DeleteProduct(2), Times.Never);  // ��������, ��� ����� DeleteProduct �� ��� ������ ��� �������� � ID 2
        }
    }
}
