using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string investigateClass, params string[] investigateFields)
        {
            var type = Type.GetType(investigateClass);
            var neededFields = type.GetFields(BindingFlags.Instance | BindingFlags.Public
                | BindingFlags.NonPublic | BindingFlags.Static);

            StringBuilder sb = new StringBuilder();

            var hackerInstance = Activator.CreateInstance(type, new object[] { });
            sb.AppendLine($"Class under investigation: {investigateClass}");

            foreach (var field in neededFields.Where(f => investigateFields.Contains(f.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(hackerInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            var invClassType = Type.GetType(className);
            var invFileds = invClassType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            var classPublicMethods = invClassType.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            var classNonPublicMethods = invClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder bb = new StringBuilder();

            foreach (FieldInfo field in invFileds)
            {
                bb.AppendLine($"{field.Name} must be private!");
            }

            foreach (MethodInfo method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
            {
                bb.AppendLine($"{method.Name} have to be public!");
            }

            foreach (MethodInfo method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
            {
                bb.AppendLine($"{method.Name} have to be private!");
            }

            return bb.ToString().Trim();
        }

        public string RevealPrivateMethods(string InvastigatedClass)
        {
            Type invClassType = Type.GetType(InvastigatedClass);
            MethodInfo[] invMethods = invClassType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            StringBuilder bbb = new StringBuilder();

            bbb.AppendLine($"All Private Methods of Class: {InvastigatedClass}");
            bbb.AppendLine($"Base Class: {invClassType.BaseType.Name}");

            foreach (MethodInfo method in invMethods)
            {
                bbb.AppendLine($"{method.Name}");
            }

            return bbb.ToString().Trim();

        }

        public string CollectGettersAndSetters(string invastigatedClass)
        {
            Type invClassType = Type.GetType(invastigatedClass);

            MethodInfo[] invMethods = invClassType.GetMethods(BindingFlags.NonPublic
                | BindingFlags.Instance | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            foreach (MethodInfo method in invMethods.Where(m => m.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} will return {method.ReturnType}");
            }

            foreach (MethodInfo method in invMethods.Where(m => m.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
