using Infrastructure.Interfaces;
using Assignment.DomainModel.Models;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly List<Product> _products = new()
        {
            new Product { ProductId = 1, Name = "Laptop", Category = "Electronics", Price = 1200.50, Stock = 25 },
            new Product { ProductId = 2, Name = "Headphones", Category = "Electronics", Price = 150.75, Stock = 100 },
            new Product { ProductId = 3, Name = "Coffee Maker", Category = "Appliances", Price = 80.00, Stock = 50 }
        };

        public IEnumerable<Product> GetAllProducts() => _products;

        public Product GetProductById(int productId) => _products.FirstOrDefault(p => p.ProductId == productId);

        public void AddProduct(Product product)
        {
            product.ProductId = _products.Max(p => p.ProductId) + 1; // Auto-increment ID
            _products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = GetProductById(product.ProductId);
            if (existingProduct != null)
            {
                existingProduct.Name = product.Name;
                existingProduct.Category = product.Category;
                existingProduct.Price = product.Price;
                existingProduct.Stock = product.Stock;
            }
        }

        public void DeleteProduct(int productId)
        {
            var product = GetProductById(productId);
            if (product != null) _products.Remove(product);
        }
    }
}
