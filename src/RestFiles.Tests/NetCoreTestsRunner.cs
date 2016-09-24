using System;
using System.Reflection;
using NUnit.Common;
using NUnitLite;
using ServiceStack.Text;

namespace RestFiles.Tests
{
    public class NetCoreTestsRunner
    {
        public static int Main(string[] args)
        {
            var writer = new ExtendedTextWrapper(Console.Out);
            var result = new AutoRun(((IReflectableType)typeof(NetCoreTestsRunner)).GetTypeInfo().Assembly).Execute(args, writer, Console.In);

#if DEBUG
            "Press Any Key to Quit.".Print();
            Console.Read();
#endif
            return result;
        }
    }
}