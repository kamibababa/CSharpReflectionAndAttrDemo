using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo
{
    [TestClass]
    public class MathTests
    {
        [TestMethod]
        public void AddTest()
        {
            int result = 2 + 3;
            if (result != 5)
                throw new Exception("AddTest failed!");
        }

        [TestMethod]
        public void DivideTest()
        {
            int result = 10 / 2;
            if (result != 5)
                throw new Exception("DivideTest failed!");
        }

        [TestMethod]
        public void DivideByZeroTest()
        {
            int x = 0;
            int result = 1 / x; // 期望抛出异常
        }
    }

}
