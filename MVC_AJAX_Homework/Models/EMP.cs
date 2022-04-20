using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_AJAX_Homework.Models
{
    public class EMP
    {
        public int Empno { get; set; }
        public string Ename { get; set; }
        public string Job { get; set; }
        public int? MGR { get; set; }
        public string HireDate { get; set; }
        public int Sal { get; set; }
        public int Comm { get; set; }
        public int Deptno { get; set; }
    }
}