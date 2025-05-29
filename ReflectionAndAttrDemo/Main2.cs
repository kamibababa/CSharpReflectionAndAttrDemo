//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Reflection;
//using System.Text;
//using System.Threading.Channels;
//using System.Threading.Tasks;

//namespace ReflectionAndAttrDemo
//{
//    public class DemoClass
//    {
//        public void Hello(string name)
//        {
//            Console.WriteLine($"Hello, {name}!");
//        }
//    }

//    internal class Main2
//    {
//        static void Main()
//        {
//            Assembly ass = Assembly.GetExecutingAssembly();
//            Console.WriteLine(ass.FullName);
//            Type[] types = ass.GetTypes();
//            foreach (var item in types)
//            {
//                Console.WriteLine(item.Name);
//            }
//        }
       
//    }
//}
