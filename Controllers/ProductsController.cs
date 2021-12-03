using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DockerAPI.Models;
using System.Net;

namespace DockerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        static readonly IProductRepository repository = new ProductRepository();

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return repository.GetAll();
        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }
        [HttpPost]
        public string PostProduct(Product item)
        {
            item = repository.Add(item);
            return "added successfully";
        }
        [HttpPut("{id}")]
        public void PutProduct(int id, Product Product)
        {
            Product.Id = id;
            if (!repository.Update(Product))
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        [HttpDelete("{id}")]
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
