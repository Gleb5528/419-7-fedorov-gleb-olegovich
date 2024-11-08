using Microsoft.VisualStudio.TestTools.UnitTesting;
using Stripe;
using Assert = NUnit.Framework.Assert;

namespace TestProject1
{
    public class Tests
    {
        private ProductService productService;

        [TestInitialize]
        public void Setup()
        {
            productService = new ProductService();
            // ��������� �������� ������, ��������:
            productService.AddProduct("Electronics", 15);
            productService.AddProduct("Groceries", 30);
        }

        // 1. �������� �� ���������� ���������� ��� ������������� ���� ��������
        [TestMethod]
        public void GetQuantityForProduct_ExistingProductType_ShouldReturnCorrectQuantity()
        {
            int result = productService.GetQuantityForProduct("Electronics");
            Assert.AreEqual(15, result);
        }

        // 2. �������� �� ���������� ���� ��������
        [TestMethod]
        public void GetQuantityForProduct_NonExistentProductType_ShouldReturnMinusOne()
        {
            int result = productService.GetQuantityForProduct("NonExistentType");
            Assert.AreEqual(-1, result);
        }

        // 3. �������� �� null � �������� ��������� ���� ��������
        [TestMethod]
        public void GetQuantityForProduct_NullProductType_ShouldReturnMinusOne()
        {
            int result = productService.GetQuantityForProduct(null);
            Assert.AreEqual(-1, result);
        }

        // 4. �������� �� ������ ������ � �������� ���� ��������
        [TestMethod]
        public void GetQuantityForProduct_EmptyProductType_ShouldReturnMinusOne()
        {
            int result = productService.GetQuantityForProduct(string.Empty);
            Assert.AreEqual(-1, result);
        }

        // 5. �������� �� ��� �������� � ���������
        [TestMethod]
        public void GetQuantityForProduct_ProductTypeWithSpaces_ShouldReturnMinusOne()
        {
            int result = productService.GetQuantityForProduct("   ");
            Assert.AreEqual(-1, result);
        }

        // 6. �������� ���������������� � ��������
        [TestMethod]
        public void GetQuantityForProduct_ProductTypeCaseInsensitive_ShouldReturnCorrectQuantity()
        {
            int result = productService.GetQuantityForProduct("electronics");
            Assert.AreEqual(15, result);  // ������������, ��� ����� �������������� � ��������
        }

        // 7. �������� �� ����������� ���������� (��������, 0)
        [TestMethod]
        public void GetQuantityForProduct_ZeroQuantity_ShouldReturnZero()
        {
            productService.AddProduct("Books", 0);
            int result = productService.GetQuantityForProduct("Books");
            Assert.AreEqual(0, result);
        }

        // 8. �������� �� ������� ���������� ��������
        [TestMethod]
        public void GetQuantityForProduct_LargeQuantity_ShouldReturnLargeQuantity()
        {
            productService.AddProduct("Furniture", int.MaxValue);
            int result = productService.GetQuantityForProduct("Furniture");
            Assert.AreEqual(int.MaxValue, result);
        }

        // 9. �������� �� ������������� �������� ���������� (����������)
        [TestMethod]
        public void GetQuantityForProduct_NegativeQuantity_ShouldHandleGracefully()
        {
            productService.AddProduct("Toys", -5);  // �����������, ��� ������������� �������� - ������
            int result = productService.GetQuantityForProduct("Toys");
            Assert.AreEqual(-1, result); // ������������, ��� ����� ���������� -1 ��� ����������� ����������
        }

        // 10. �������� �� ���������� ����� ����������
        [TestMethod]
        public void GetQuantityForProduct_AfterUpdate_ShouldReturnUpdatedQuantity()
        {
            productService.AddProduct("Groceries", 30);
            productService.UpdateProductQuantity("Groceries", 50);
            int result = productService.GetQuantityForProduct("Groceries");
            Assert.AreEqual(50, result);
        }
    }
}