using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.orm
{
    [Table("users")]
    public class User
    {
        [Column("user_id")]
        public int Id { get; set; }

        [Column("username")]
        public string Name { get; set; }

        [Column("email_address")]
        public string Email { get; set; }
    }

}
