using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;

namespace DynamicLoadingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string dllPath = @"D:\Dummy\DynamicLoadingLibrary\DynamicLoadingLibrary\bin\Debug\DynamicLoadingLibrary.dll";

            if (System.IO.File.Exists(dllPath))
            {
                Assembly libraryAssembly = Assembly.LoadFile(dllPath);

                Type serviceAType = libraryAssembly.GetType("DynamicLoadingLibrary.ServiceA");
                object serviceAInstance = Activator.CreateInstance(serviceAType);
                MethodInfo executeMethodA = serviceAType.GetMethod("Execute");
                string resultA = (string)executeMethodA.Invoke(serviceAInstance, null);
                Console.WriteLine(resultA);

                Type serviceBType = libraryAssembly.GetType("DynamicLoadingLibrary.ServiceB");
                object serviceBInstance = Activator.CreateInstance(serviceBType);
                MethodInfo executeMethodB = serviceBType.GetMethod("Execute");
                string resultB = (string)executeMethodB.Invoke(serviceBInstance, null);
                Console.WriteLine(resultB);
            }
            else
            {
                Console.WriteLine("DLL file not found.");
            }
        }
    }
}