using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using PostSharp.Aspects;
using PostSharp.Serialization;

namespace Services.Caching
{
    [PSerializable]
    public class CacheableResultAttribute : MethodInterceptionAspect
    {
        public int ExpireInMinutes { get; set; }

        private string _provider = "LocalMemoryCacheService"; //default provider

        public string Provider
        {
            get { return _provider; }
            set { _provider = value; }
        }

        /// <summary>
        /// on cacheable method invoked.
        /// </summary>
        /// <param name="args"></param>
        public override void OnInvoke(MethodInterceptionArgs args)
        {
            var cachePrviderType = Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(p => p.Name == _provider);

            if (cachePrviderType == null)
            {
                throw new ApplicationException($"{_provider} CacheProviderNotFound");
            }

            var cache = cachePrviderType.GetProperty("Instance").GetValue(null) as ICacheService;

            // get method args to have method result specific value

            //todo: change argument logic
            var arguments = args.Arguments.ToList();

            //todo: hash key
            var key = GetCacheKey(args.Method, arguments);

            var mi = args.Method as MethodInfo;

            var type = mi.ReturnType;

            MethodInfo method = cache.GetType().GetMethod("Get")
                             .MakeGenericMethod(new Type[] { type });

            var result = method.Invoke(cache, new object[] { key });
            if (result != null)
            {
                args.ReturnValue = result;
                return;
            }

            base.OnInvoke(args);

            cache.Add(key, args.ReturnValue, ExpireInMinutes);
        }

        private string GetCacheKey(MemberInfo methodInfo, IEnumerable<object> arguments)
        {
            var methodName = string.Format("{0}.{1}.{2}",
                                       methodInfo.ReflectedType.Namespace,
                                       methodInfo.ReflectedType.Name,
                                       methodInfo.Name);

            var key = string.Format(
              "{0}({1})",
              methodName,
              string.Join(", ", arguments.Select(x => x != null ? x.ToString() : "<Null>")));
            return key;
        }
    }
}
