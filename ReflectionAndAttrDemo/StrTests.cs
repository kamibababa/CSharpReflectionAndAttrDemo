using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo
{
    [TestClass]
    public class StrTests
    {
        [TestMethod]
        public void ContainsTest()
        {
            string msg = "hello";
            if (msg.Contains("world"))
                throw new Exception("error");
        }

        
    }

}
