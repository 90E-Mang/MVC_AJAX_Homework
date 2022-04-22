using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPICRUD_LINQ.Models;

namespace WebAPICRUD_LINQ.Controllers
{
    public class DeptsController : ApiController
    {
        static readonly DeptRepository repository = new DeptRepository();

        public IQueryable<DEPT> GetAllDepts()    // 함수의 이름이 중요 Get으로 시작
        {
            return repository.GetAll();
        }

        public DEPT GetDept(int id)
        {
            DEPT item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return item;
        }

        public DEPT PostDept(DEPT item)
        {
            return repository.Add(item);
        }
        public void PutDept(DEPT item)
        {           
            if (!repository.Update(item))
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }
        public void DeleteDept(int id)
        {
            DEPT item = repository.Get(id);
            if (item == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            repository.Remove(id);
        }
    }
}
