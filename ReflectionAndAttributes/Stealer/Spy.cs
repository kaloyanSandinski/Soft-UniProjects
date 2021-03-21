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
                BindingFlags.NonPublic| 
                BindingFlags.Static |
                BindingFlags.Instance);
            object classInstance = Activator.CreateInstance(hackerType);
            sb.AppendLine($"Class under investigation: {hackerType.Name}");
            foreach (var currField in allFields.Where(x=>nameOfFieldsToInvestigate.Contains(x.Name)))
            {
                sb.AppendLine($"{currField.Name} = {currField.GetValue(classInstance)}");
            }

            return sb.ToString();
        }
    }
}
