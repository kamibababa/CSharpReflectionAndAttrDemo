using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.orm
{
    internal class TestSql
    {
        static void Main(string[] args)
        {
            var user = new User
            {
                Id = 1,
                Name = "Alice",
                Email = "alice@example.com"
            };

            string sql = SqlGenerator.GenerateInsertSql(user);
            Console.WriteLine(sql);
        }
    }
}
