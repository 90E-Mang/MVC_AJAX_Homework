using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPICRUD.Models;

namespace WebAPICRUD.Controllers
{
    /*
        URI                     Method              처리
 /api/products                  GET                모든 제품의 목록을 조회                           >> GetAllProducts()
 /api/products/id               GET                id를 기준으로 조회해서 해당 제품(1건)을 조회         >> GetProduct(int id)
 /api/products?category=        GET                카테고리를 기준으로 해당하는 제품(들)을 조회          >> GetProductsByCategory(string category)
 /api/products                  POST               새로운 제품을 생성.(New(DB에서는 Insert))          >> PostProduct(Product item)
 /api/products/id               PUT                id에 해당하는 제품을 갱신(수정)(update where id)   >> PutProduct(int id, Product item)
 /api/products/id               DELETE             제품을 삭제(delete where id)                     >> DeleteProduct(int id)
 */
    public class ProductsController : ApiController
    {
        static readonly IProductRepository repository = new ProductRepository();

        public IEnumerable<Product> GetAllProducts()    // 함수의 이름이 중요 Get으로 시작
        {
            return repository.GetAll();
        }

        public Product GetProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public IEnumerable<Product> GetProductsByCategory(string category)  // 인터페이스에 이 함수 추가해도됨. 이렇게 쓰면 어려움
        {
            return repository.GetAll().Where(p=>string.Equals(p.Category, category, StringComparison.OrdinalIgnoreCase));
        }

        public Product PostProduct(Product item)
        {
            return repository.Add(item);
        }
        public void PutProduct(int id, Product item)
        {
            item.Id = id;
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteProduct(int id)
        {
            Product item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
