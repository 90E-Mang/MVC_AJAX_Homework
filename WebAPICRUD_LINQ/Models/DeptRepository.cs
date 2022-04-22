using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;


namespace WebAPICRUD_LINQ.Models
{
    public class DeptRepository
    {
        DeptDataContext db = new DeptDataContext();
        public IQueryable<DEPT> GetAll()
        {           
            var deptList = from Dept in db.GetTable<DEPT>()
                           select Dept;
            return deptList;
        }
        public DEPT Get(int id)
        {
            var dept = GetAll().SingleOrDefault(d => d.DEPTNO == id);
            return dept;
        }

        public DEPT Add(DEPT item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            db.DEPT.InsertOnSubmit(item);
            db.SubmitChanges();
            return item;
        }

        public bool Update(DEPT item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }
            DEPT dept = db.DEPT.FirstOrDefault(x => x.DEPTNO.Equals(item.DEPTNO));
            if (dept == null)
            {
                return false;
            }
            dept.DNAME = item.DNAME;
            dept.LOC = item.LOC;
            db.SubmitChanges();
            return true;
        }

        public void Remove(int id)
        {
            DEPT dept = db.DEPT.FirstOrDefault(x => x.DEPTNO.Equals(id));
            if (dept == null)
            {
                throw new ArgumentNullException("item");
            }
            db.DEPT.DeleteOnSubmit(dept);
            db.SubmitChanges();
        }
    }
}