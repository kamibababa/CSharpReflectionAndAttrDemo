using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.orm
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    class SqlGenerator
    {
        public static string GenerateInsertSql(object obj)
        {
            Type type = obj.GetType();
            var tableAttr = type.GetCustomAttribute<TableAttribute>();
            if (tableAttr == null)
                throw new InvalidOperationException("Missing [Table] attribute.");

            string tableName = tableAttr.Name;
            var props = type.GetProperties()
                            .Where(p => p.GetCustomAttribute<ColumnAttribute>() != null);

            var columnNames = props.Select(p => p.GetCustomAttribute<ColumnAttribute>().Name);
            var values = props.Select(p => $"'{p.GetValue(obj)}'");

            string sql = $"INSERT INTO {tableName} ({string.Join(", ", columnNames)}) " +
                         $"VALUES ({string.Join(", ", values)});";

            return sql;
        }
    }

}
