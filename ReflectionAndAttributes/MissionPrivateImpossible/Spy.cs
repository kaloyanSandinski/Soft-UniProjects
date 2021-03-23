using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfClass, string[] nameOfFieldsToInvestigate)
        {
            StringBuilder sb = new StringBuilder();
            Type hackerType = typeof(Hacker);
            FieldInfo[] allFields = hackerType.GetFields(
                BindingFlags.Public |
                BindingFlags.NonPublic |
                BindingFlags.Static |
                BindingFlags.Instance);
            object classInstance = Activator.CreateInstance(hackerType);
            sb.AppendLine($"Class under investigation: {hackerType.Name}");
            foreach (var currField in allFields.Where(x => nameOfFieldsToInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{currField.Name} = {currField.GetValue(classInstance)}");
            }

            return sb.ToString();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            StringBuilder sb = new StringBuilder();
            Type classType = Type.GetType(className);
            FieldInfo[] fieldInfos = classType.GetFields(BindingFlags.Static |
                                                         BindingFlags.Public |
                                                         BindingFlags.Instance);
            MethodInfo[] publicMethodInfos = classType.GetMethods(BindingFlags.Instance |
                                                                  BindingFlags.Public);
            MethodInfo[] nonPublicMethodInfos = classType.GetMethods(BindingFlags.Instance |
                                                                     BindingFlags.NonPublic);
            foreach (var fieldInfo in fieldInfos)
            {
                sb.AppendLine($"{fieldInfo.Name} must be private!");
            }

            foreach (var nonPublicMethodInfo in nonPublicMethodInfos.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{nonPublicMethodInfo.Name} have to be public!");
            }

            foreach (var publicMethodInfo in publicMethodInfos.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{publicMethodInfo.Name} have to be private!");
            }


            return sb.ToString();
        }
        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType($"{this.GetType().Namespace}.{className}");
            MethodInfo[] nonPublicMethodInfos = classType.GetMethods(BindingFlags.Instance |
                                                                     BindingFlags.NonPublic);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (var nonPublicMethodInfo in nonPublicMethodInfos)
            {
                sb.AppendLine(nonPublicMethodInfo.Name);
            }

            return sb.ToString();
        }

        public string CollectGettersAndSetters(string className)
        {
            Type classType = Type.GetType($"{this.GetType().Namespace}.{className}");
            MethodInfo[] allMethodInfos = classType.GetMethods(BindingFlags.Instance |
                                                               BindingFlags.Static |
                                                               BindingFlags.NonPublic |
                                                               BindingFlags.Public);
            StringBuilder sb = new StringBuilder();

            foreach (var methodInfo in allMethodInfos.Where(m=>m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{methodInfo.Name} will return {methodInfo.ReturnType}");
            }

            foreach (var methodInfo in allMethodInfos.Where(m=>m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{methodInfo.Name} will set field of {methodInfo.GetParameters().First().ParameterType}");
            }

            return sb.ToString();
        }
    }
}
