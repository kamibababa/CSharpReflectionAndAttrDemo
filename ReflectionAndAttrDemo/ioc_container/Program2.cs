//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReflectionAndAttrDemo.ioc_container
//{
//    // 定义接口和实现
//    public interface IEngine { void Run(); }
//    public class V8Engine : IEngine
//    {
//        public void Run() => Console.WriteLine("V8 Engine running");
//    }

//    public class Car
//    {
//        private readonly IEngine engine;
//        public Car(IEngine engine)
//        {
//            this.engine = engine;
//        }
//        public void Drive() => engine.Run();
//    }

//    class Program2
//    {
//        static void Main()
//        {
//            var container = new SimpleContainer();

//            // 注册依赖
//            container.Register<IEngine>(typeof(V8Engine));
//            container.Register<Car>(typeof(Car));

//            // 解析实例，自动注入依赖
//            var car = container.Resolve<Car>();
//            car.Drive();  // 输出：V8 Engine running
//        }
//    }

//}
