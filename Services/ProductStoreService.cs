using System;
using System.Collections.Generic;
using System.Linq;
using CatalogApi.Models;
namespace CatalogApi.Services
{
    public static class ProductStoreService
    {
        static List<Product> ProductStore { get; }
        
        static ProductStoreService()
        {
            ProductStore = new List<Product>();
        }

        public static List<Product> GetAllProducts() => ProductStore;

        public static Product GetProductById(int id) => ProductStore.FirstOrDefault(p => p.Id == id);

        public static void CreateProduct(Product product)
        {
            product.Id = new Random().Next();
            ProductStore.Add(product);
        }

        public static void DeleteProduct(int id)
        {
            var index = ProductStore.FindIndex(product => product.Id == id);
            ProductStore.RemoveAt(index);
        }

        public static void UpdateProduct(Product product)
        {
            var index = ProductStore.FindIndex(p => p.Id == product.Id);
            ProductStore[index] = product;
        }
    }
}
