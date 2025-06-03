//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Text.Json;
//using System.Threading.Tasks;

//namespace TaskSellTicketDemo
//{
//    // 使用示例：
//    public class Person
//    {
//        public string Name { get; set; }
//        public int Age { get; set; }
//    }

//    public class SimpleJsonDeserializer
//    {
//        public static T Deserialize<T>(string json) where T : new()
//        {
//            var obj = new T();
//            var dict = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, object>>(json);
//            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

//            foreach (var prop in props)
//            {
//                if (dict.TryGetValue(prop.Name, out var value))
//                {
//                    var convertedValue = Convert.ChangeType(value.ToString(), prop.PropertyType);
//                    prop.SetValue(obj, convertedValue);
//                }
//            }
//            return obj;
//        }
//        static void Main(string[] args)
//        {
//            string json = "{\"Name\":\"Bob\",\"Age\":30}";
//            var person = SimpleJsonDeserializer.Deserialize<Person>(json);
//            //var person = JsonSerializer.Deserialize<Person>(json);
//            Console.WriteLine($"{person.Name} is {person.Age} years old");
//        }
//    }

    
//}
