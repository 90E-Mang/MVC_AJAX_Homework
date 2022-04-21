using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var list = new List<Person>()
            { 
                new Person(){Name="홍길동",Age=20},
                new Person(){Name="김유신",Age=30},
                new Person(){Name="이순신",Age=52},
                new Person(){Name="유관순",Age=40},
                new Person(){Name="아무개",Age=32},
                new Person(){Name="이병철",Age=15},
                new Person(){Name="정주영",Age=22}
            };

            // 나이가 20살 이상인 사람
            //var firstobj = list.FirstOrDefault(p => p.Age >= 20);
            //Console.WriteLine(firstobj.Name);

            //var singleobj = list.SingleOrDefault(p => p.Age >= 20); // 여러건이 있어서 예외가 발생함
            //Console.WriteLine(singleobj);

            // singleor 는 
            var firstobj = list.FirstOrDefault(p => p.Age == 20);
            Console.WriteLine(firstobj.Name);
            var singleobj = list.SingleOrDefault(p => p.Age == 20);
            Console.WriteLine(singleobj.Name);
        }
    }
}
