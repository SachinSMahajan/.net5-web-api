using System;
using Microsoft.AspNetCore.Mvc;
using CatalogApi.Services;
using CatalogApi.Models;
namespace CatalogApi.Controllers
{
    [Route("/api/product")]
    public class ProductController : ControllerBase
    {   
        [HttpGet]
        [Route("all")]
        public ActionResult Get(){
            return Ok(ProductStoreService.GetAllProducts());
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult Get(int id){

            var requiredProduct = ProductStoreService.GetProductById(id);

            if (requiredProduct is null)
            {
                return NotFound();
            }
            
            return Ok(requiredProduct);
        }
        
        [HttpPost]
        public ActionResult AddProduct(Product product){

            ProductStoreService.CreateProduct(product);
            return CreatedAtAction("AddProduct", product.Id,product);
        }

         [HttpPut("{id}")]
        public ActionResult UpdateItemAsync(int id, Product updatedProduct)
        {
            var existingProduct = ProductStoreService.GetProductById(id);

            if (existingProduct is null)
            {
                return NotFound();
            }

            existingProduct.Name = updatedProduct.Name;
            existingProduct.Price = updatedProduct.Price;

            ProductStoreService.UpdateProduct(existingProduct);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteItemAsync(int id)
        {
            var existingProduct = ProductStoreService.GetProductById(id);

            if (existingProduct is null)
            {
                return NotFound();
            }

            ProductStoreService.DeleteProduct(id);

            return NoContent();
        }
    }
}
