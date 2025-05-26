using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo
{
    public class TestRunner
    {
        public static void RunAllTests()
        {
            var testClasses = Assembly.GetExecutingAssembly()
                .GetTypes()
                .Where(t => t.GetCustomAttribute<TestClassAttribute>() != null);

            foreach (var testClass in testClasses)
            {
                Console.WriteLine($"\n📘 测试类: {testClass.Name}");
                var testMethods = testClass.GetMethods()
                    .Where(m => m.GetCustomAttribute<TestMethodAttribute>() != null);

                var instance = Activator.CreateInstance(testClass);
                foreach (var method in testMethods)
                {
                    try
                    {
                        method.Invoke(instance, null);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"✅ 通过: {method.Name}");
                    }
                    catch (TargetInvocationException tie)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"❌ 失败: {method.Name} - 异常: {tie.InnerException?.Message}");
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"❌ 失败: {method.Name} - 异常: {ex.Message}");
                    }
                    finally
                    {
                        Console.ResetColor();
                    }
                }
            }
        }
    }

}
