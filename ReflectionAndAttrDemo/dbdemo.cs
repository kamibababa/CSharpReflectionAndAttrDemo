using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TaskSellTicketDemo
{
    public class Dept
    {
        public int deptno { get; set; }
        public string dname { get; set; }
        public string loc { get; set; }
    }


    public class DataReaderMapper
    {
        public static List<T> MapToList<T>(MySqlDataReader reader) where T : new()
        {
            var list = new List<T>();
            var props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var columnNames = Enumerable.Range(0, reader.FieldCount)
                                        .Select(i=>reader.GetName(i))
                                        .ToHashSet(StringComparer.OrdinalIgnoreCase); // 忽略大小写

            while (reader.Read())
            {
                var obj = new T();

                foreach (var prop in props)
                {
                    if (!columnNames.Contains(prop.Name)) continue;

                    var value = reader[prop.Name];

                    if (value != DBNull.Value)
                    {
                        // 处理类型转换（避免 IConvertible 问题）
                        var safeValue = Convert.ChangeType(value, prop.PropertyType);
                        prop.SetValue(obj, safeValue);
                    }
                }

                list.Add(obj);
            }

            return list;
        }
        static void Main(string[] args)
        {
            using (var conn = new MySqlConnection("server=localhost;port=3306;user=root;password=root;database=scott"))
            {
                conn.Open();
                var cmd = new MySqlCommand("SELECT * FROM dept", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    var people = DataReaderMapper.MapToList<Dept>(reader);
                    foreach (var p in people)
                    {
                        Console.WriteLine($"{p.deptno} - {p.dname} - {p.loc}");
                    }
                }
            }
        }
    }

}
