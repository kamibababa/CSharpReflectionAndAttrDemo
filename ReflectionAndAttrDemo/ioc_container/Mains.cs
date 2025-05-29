using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.ioc_container
{
    using System;

    class Program
    {
        static void Main()
        {
            var container = new SimpleContainer();

            // 先注册所有可能的实现（或者通过反射自动扫描，这里先写死）
            //container.Register<ILogger, ConsoleLogger>(); // 默认先注册ConsoleLogger
            //container.Register<ILogger, FileLogger>();    // 注册FileLogger也允许，只是会覆盖

            // 读配置，动态选择具体实现
            string loggerTypeName = ConfigReader.GetLoggerType("ioc_container/config.xml");

            // 根据配置替换容器里的注册映射
            Type loggerType = loggerTypeName switch
            {
                "ConsoleLogger" => typeof(ConsoleLogger),
                "FileLogger" => typeof(FileLogger),
                _ => throw new Exception($"Unknown logger type {loggerTypeName}")
            };

            // 重新注册 ILogger 到指定类型
            //container.Register<ILogger, ConsoleLogger>(); // 先移除或覆盖，简单示范，直接覆盖
            //container.Register<ILogger, FileLogger>();    // 这里会覆盖上面的注册，模拟覆盖
                                                          // 实际用下面方式替换
            container.Register<ILogger>(loggerType);

            // 解析 ILogger
            var logger = container.Resolve<ILogger>();

            // 用日志
            logger.Log("This is a test log message.");
        }
    }

}
