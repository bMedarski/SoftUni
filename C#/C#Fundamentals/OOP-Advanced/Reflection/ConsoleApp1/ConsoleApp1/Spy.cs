using System;
using System.Linq;
using System.Reflection;
using System.Text;

public class Spy
{

	public Spy()
	{

	}

	public string StealFieldInfo(string name, params string[] fields)
	{
		Type className = Type.GetType(name, false);
		FieldInfo[] fieldInfos = className.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);
		StringBuilder sb = new StringBuilder();

		Object classInstance = Activator.CreateInstance(className, new object[] { });
		sb.AppendLine($"Class under investigation: {name}");
		foreach (var fieldInfo in fieldInfos.Where(f => fields.Contains(f.Name)))
		{
			sb.AppendLine($"{fieldInfo.Name} = {fieldInfo.GetValue(classInstance)}");
		}

		return sb.ToString().Trim();
	}

	public string AnalyzeAcessModifiers(string className)
	{
		StringBuilder sb = new StringBuilder();

		Type classUnderInvestigate = Type.GetType(className, false);
		FieldInfo[] fieldInfos = classUnderInvestigate.GetFields(BindingFlags.Instance | BindingFlags.Public);
		Object classInstance = Activator.CreateInstance(classUnderInvestigate, new object[] { });
		foreach (var fieldInfo in fieldInfos)
		{
			if (fieldInfo.IsPublic)
			{
				sb.AppendLine($"{fieldInfo.Name} must be private!");
			}
		}
		
		//								 BindingFlags.NonPublic);
		//foreach (var property in properties)
		//{
		//	if (property.GetMethod.IsPrivate)
		//	{
		//		sb.AppendLine($"{property.GetMethod.Name} have to be public!");
		//	}
		//}
		//foreach (var property in properties)
		//{
		//	if (property.SetMethod.IsPublic)
		//	{
		//		sb.AppendLine($"{property.SetMethod.Name} have to be private!");
		//	}
		//}

		return sb.ToString().Trim();
	}

	public string RevealPrivateMethods(string className)
	{
		StringBuilder sb = new StringBuilder();

		Type classUnderInvestigate = Type.GetType(className, false);
		sb.AppendLine($"All Private Methods of Class: {className}");
		var baseClassName = classUnderInvestigate.BaseType.Name;

		sb.AppendLine($"Base Class: { baseClassName}");
		var methods = classUnderInvestigate.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);
		foreach (var method in methods)
		{
			sb.AppendLine($"{method.Name}");
		}

		return sb.ToString().Trim();
	}

	public string CollectGettersAndSetters(string className)
	{
		StringBuilder sb = new StringBuilder();
		Type classUnderInvestigate = Type.GetType(className, false);
		var methods = classUnderInvestigate.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance|BindingFlags.Public);
		foreach (var method in methods.Where(m=>m.Name.StartsWith("get")))
		{
			sb.AppendLine($"{method.Name} will return {method.ReturnType}");
		}
		foreach (var method in methods.Where(m => m.Name.StartsWith("set")))
		{
			sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
		}
		return sb.ToString().Trim();
	}

}

