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
            //     Check all of the fields and methods access modifiers. Print on the console all of the mistakes in format:
            //    •	Fields
            //    o       { fieldName} must be private!
            //    •	Getters
            //            { methodName } have to be public!
            //    •	Setters
            //            { methodName } have to be private!
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
    }
}
