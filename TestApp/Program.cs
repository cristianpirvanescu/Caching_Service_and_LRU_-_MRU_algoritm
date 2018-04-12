
using CachingLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person { Id = 1, Age = 10, Name = "" };
            Person p2 = new Person { Id = 2, Age = 11, Name = "" };
            Person p3 = new Person { Id = 3, Age = 12, Name = "" };
            ICachingService<int, Person> cache = new CachingService<int, Person>();
            //ICachingService<int, Person> cache = new CachingService<int, Person>(new LRUAlgorithm<int, Person>());
            //ICachingService<int, Person> cache = new CachingService<int, Person>(new MRUAlgorithm<int, Person>());
            cache.Add(1, p1);
            cache.Add(2, p2);
            cache.Add(3, p3);
            var rez = cache.Get(2);
            ICachingService<int, Person2> cache2 = new CachingService<int, Person2>();
            Person2 p4 = new Person2 { Id = 1, Age = 13, Name = "" };
            cache2.Add(1, p4);
            var rez2 = cache.Get(1);
            var rez3 = cache2.Get(1);
        }
    }
    class Person
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
    class Person2
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public string Name { get; set; }
    }
}
