namespace SIS.MvcFramework.Services
{
	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Reflection;
	using Contracts;

	public class DependencyContainer : IDependencyContainer
	{

		private readonly IDictionary<Type, Type> dependencyDictionary;

		public DependencyContainer(IDictionary<Type, Type> dependencyContainer)
		{
			this.dependencyDictionary = dependencyContainer;
		}

		private Type this[Type key]

			=> this.dependencyDictionary.ContainsKey(key) ? this.dependencyDictionary[key] : null;
		
		public T CreateInstance<T>()
		{
			return (T) this.CreateInstance(typeof(T));
		}

		public object CreateInstance(Type type)
		{
			Type instance = this[type] ?? type;

			if (instance.IsAbstract || instance.IsInterface)
			{
				throw new InvalidOperationException($"Type {instance} cannot ne instantiated");
			}

			ConstructorInfo constructor = instance.GetConstructors().OrderBy(x => x.GetParameters().Length).First();
			ParameterInfo[] constructorParameter = constructor.GetParameters();
			object[] constructorParameterObjects = new object[constructorParameter.Length];

			for (int i = 0; i < constructorParameter.Length; i++)
			{
				constructorParameterObjects[i] = this.CreateInstance(constructorParameter[i].ParameterType);
			}

			return constructor.Invoke(constructorParameterObjects);
		}

		public void RegisterDependency<TSource, TDestination>()
		{
			this.dependencyDictionary[typeof(TSource)] = typeof(TDestination);
		}
	}
}
