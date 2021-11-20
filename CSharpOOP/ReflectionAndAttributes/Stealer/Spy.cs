using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string nameOfTheClass, params string[] namesOfFields)
        {
            var sb = new StringBuilder();

            sb.AppendLine($"Class under investigation: {nameOfTheClass}");

            var type = Type.GetType(nameOfTheClass);
            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);

            var classInstance = Activator.CreateInstance(type);

            foreach (var field in fields.Where(x => namesOfFields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAccessModifiers(string className)
        {
            var type = Type.GetType(className);

            var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            var incorrectGetters = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance).Where(x => x.Name.Contains("get")).ToList();

            var incorrectSetters = type.GetMethods(BindingFlags.Public | BindingFlags.Instance).Where(x => x.Name.Contains("set")).ToList();

            var classInstance = Activator.CreateInstance(type);

            var sb = new StringBuilder();

            foreach (var field in fields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var getter in incorrectGetters)
            {
                sb.AppendLine($"{getter.Name} have to be public!");
            }

            foreach (var setter in incorrectSetters)
            {
                sb.AppendLine($"{setter.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var type = Type.GetType(className);

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var sb = new StringBuilder();

            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");

            foreach (var method in methods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string className)
        {
            var type = Type.GetType(className);

            var methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic).ToList();

            var sb = new StringBuilder();

            foreach (var getter in methods.Where(x => x.Name.Contains("Get")))
            {
                sb.AppendLine($"{getter.Name} will return {getter.ReturnType.FullName}");
            }

            foreach (var setter in methods.Where(x => x.Name.Contains("Set")))
            {
                sb.AppendLine($"{setter.Name} will set field of {setter.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
