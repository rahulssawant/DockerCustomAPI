using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DockerAPI.Models
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>();
        private int _nextId = 1;
        public ProductRepository()
        {
            Add(new Product { ProductName = "Car", Prize = 10000d });
            Add(new Product { ProductName = "Mobile", Prize = 5000d });
            Add(new Product { ProductName = "Bike", Prize = 7000d });
            Add(new Product { ProductName = "TV", Prize = 2000d });
        }
        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new NotImplementedException("item");
            }
            item.Id = _nextId++;
            products.Add(item);
            return item;
        }

        public Product Get(int id)
        {
            return products.Find(p => p.Id == id);
        }

        public IEnumerable<Product> GetAll()
        {
            return products;
        }

        public void Remove(int id)
        {
            products.RemoveAll(p => p.Id == id);
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new NotImplementedException("item");
            }
            int index = products.FindIndex(p => p.Id == item.Id);
            if (index == -1)
            {
                return false;
            }
            products.RemoveAt(index);
            products.Add(item);
            return true;
        }
    }
}
