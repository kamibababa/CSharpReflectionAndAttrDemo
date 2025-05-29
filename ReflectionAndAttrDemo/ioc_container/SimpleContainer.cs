using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionAndAttrDemo.ioc_container
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class SimpleContainer
    {
        private readonly Dictionary<Type, Type> _typeMap = new();

        public void Register<TInterface>(Type implementationType)
        {
            var interfaceType = typeof(TInterface);
            if (!interfaceType.IsAssignableFrom(implementationType))
                throw new ArgumentException($"{implementationType.Name} does not implement {interfaceType.Name}");

            _typeMap[interfaceType] = implementationType;
        }

        public TInterface Resolve<TInterface>()
        {
            return (TInterface)Resolve(typeof(TInterface));
        }

        private object Resolve(Type type)
        {
            if (!_typeMap.ContainsKey(type))
                throw new Exception($"Type {type.Name} not registered");

            var implType = _typeMap[type];
            var ctor = implType.GetConstructors().First();

            var parameters = ctor.GetParameters();
            if (parameters.Length == 0)
                return Activator.CreateInstance(implType);

            var parameterInstances = parameters.Select(p => Resolve(p.ParameterType)).ToArray();
            return ctor.Invoke(parameterInstances);
        }
    }

}
