using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPICRUD.Models
{
    public class ProductRepository : IProductRepository
    {
        private List<Product> products = new List<Product>();
        private int _nextid = 1;

        public ProductRepository()
        {
            Add(new Product { Name = "soup", Category = "Food", Price = 1 });
            Add(new Product { Name = "yoyo", Category = "Toys", Price = 4 });
            Add(new Product { Name = "note", Category = "Elec", Price = 10 });
        }
        /*
         Product[] products = new Product[]
        {
            new Product{ Id=1, Name="soup",Category="Food",Price=1},
            new Product{ Id=2, Name="yoyo",Category="Toys",Price=4},
            new Product{ Id=3, Name="note",Category="Elec",Price=10}
        };
         */
        public IEnumerable<Product> GetAll()
        {
            return products;
        }
        public Product Get(int id)
        {
            return products.Find(p=>p.Id == id);
        }

        public Product Add(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            item.Id = _nextid++;
            products.Add(item);
            return item;
        }

        public bool Update(Product item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
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

        public void Remove(int id)
        {
            products.RemoveAll(p=>p.Id == id);
        }
    }
}