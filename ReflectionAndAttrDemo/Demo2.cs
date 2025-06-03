using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskSellTicketDemo
{
    // 使用示例：
    using System;
    using System.Collections.Generic;
    using System.Reflection;

    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class Program
    {
        static void Main()
        {
            Person person = new Person();

            // 模拟一个数据源：属性名 => 值
            Dictionary<string, object> values = new Dictionary<string, object>()
        {
            {"Name", "Charlie"},
            {"Age", 25},
            {"NonExistentProperty", "测试"} // 多余的属性名，代码会忽略
        };

            SetProperties(person, values);

            Console.WriteLine($"Name: {person.Name}, Age: {person.Age}");
        }

        static void SetProperties(object obj, Dictionary<string, object> values)
        {
            Type type = obj.GetType();
            PropertyInfo[] props = type.GetProperties();

            foreach (var prop in props)
            {
                if (prop.CanWrite && values.ContainsKey(prop.Name))
                {
                    try
                    {
                        object convertedValue = Convert.ChangeType(values[prop.Name], prop.PropertyType);
                        prop.SetValue(obj, convertedValue);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"设置属性 {prop.Name} 失败: {ex.Message}");
                    }
                }
            }
        }
    }



}
