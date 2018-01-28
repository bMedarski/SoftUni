namespace TreeHomework
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

		public static void Main()
		{
			ReadTree();


			var root = GetRootNode();
			//Console.WriteLine($"Root node: {root.Value}");

			//root.Print();

			//PrintLeafNodes();
			PrintMiddleNodes();
		}

		static int DeepestNode()
		{
			int deepestNode=0;

			return deepestNode;
		}
		static void PrintMiddleNodes()
		{
			var nodes = nodeByValue.Values.Where(n => n.Children.Count > 0 && n.Parent != null).Select(n => n.Value).OrderBy(n => n)
				.ToList();

			Console.Write("Middle nodes: ");
			Console.WriteLine(string.Join(" ", nodes));
		}
		static void PrintLeafNodes()
		{

			var leafs = new List<int>();
			foreach (var tree in nodeByValue)
			{
				if (tree.Value.Children.Count == 0)
				{
					leafs.Add(tree.Key);
				}
			}

			leafs.Sort();
			Console.Write("Leaf nodes: ");
			Console.WriteLine(string.Join(" ",leafs));
		}
		static Tree<int> GetTreeNodeByValue(int value)
		{
			if (!nodeByValue.ContainsKey(value))
			{
				nodeByValue[value] = new Tree<int>(value);
			}

			return nodeByValue[value];
		}
		public static void AddEdge(int parent, int child)
		{
			Tree<int> parentNode = GetTreeNodeByValue(parent);
			Tree<int> childNode = GetTreeNodeByValue(child);

			parentNode.Children.Add(childNode);
			childNode.Parent = parentNode;
		}
		static void ReadTree()
		{
			int nodeCount = int.Parse(Console.ReadLine());
			for (int i = 1; i < nodeCount; i++)
			{
				string[] edge = Console.ReadLine().Split(' ');
				AddEdge(int.Parse(edge[0]), int.Parse(edge[1]));
			}
		}
		static Tree<int> GetRootNode()
		{
			return nodeByValue.Values.FirstOrDefault(x => x.Parent == null);
		}
	}
}