using System.Reflection;

namespace ReflectionAndAttrDemo.stepbystep
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Type type = typeof(Product);
            Console.WriteLine(type);

            //var instance = Activator.CreateInstance(type);

            //var nameProp = type.GetProperty("Name");
            //nameProp.SetValue(instance, "pen");
            //Console.WriteLine(instance);


            object[] parma = { "phone", 100, 1000 };
            var instance = Activator.CreateInstance(type, parma);
            Console.WriteLine(instance);
            Product product = (Product)instance;
            product.display();
            var nameProp = type.GetProperty("Name");
            Console.WriteLine(nameProp.GetValue(instance));


            //var DecreaseStock_fun = type.GetMethod("DecreaseStock");
            //DecreaseStock_fun.Invoke(instance, new object[] { 5 });
            //Console.WriteLine(instance);

            //var display_fun = type.GetMethod("display");
            //display_fun.Invoke(instance, null);

            //foreach (var method in type.GetMethods())
            //{
            //    try
            //    {
            //        Console.WriteLine(method.Name);
            //        ParameterInfo[] parameterInfos = method.GetParameters();
            //        method.Invoke(instance, parameterInfos);

            //    }
            //    catch (Exception ex)
            //    {

            //    }
            //}
        }
    }
}
