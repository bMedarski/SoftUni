namespace TreeHomework
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class StartUp
	{
		static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();
		private static int max;
		private static Tree<int> deepest;
		private static int sumToBe;
		public static void Main()
		{
			ReadTree();


			var root = GetRootNode();
			//Console.WriteLine($"Root node: {root.Value}");
			//root.Print();

			//PrintLeafNodes();
			//PrintMiddleNodes();
			//Console.WriteLine($"Deepest node: {DeepestNode(GetRootNode(), 0).Value}");
			//LongestPath();
			//sumToBe = int.Parse(Console.ReadLine());
			//Console.WriteLine($"Paths of sum {sumToBe}:");
			//SumOfPath(GetRootNode(), 0);
			//SumOfAll(GetRootNode());
			//Console.WriteLine(totalSum);
			var targetSum = int.Parse(Console.ReadLine());
			Console.WriteLine($"Subtrees of sum {targetSum}:");
			var subtreeRoots = GetSubtreeWithSum(root, targetSum);

			foreach (var node in subtreeRoots)
			{
				PrintPreOrder(node);
				Console.WriteLine();
			}

		}

		private static void PrintPreOrder(Tree<int> node)
		{
			Console.Write(node.Value + " ");
			foreach (var child in node.Children)
			{
				PrintPreOrder(child);
			}

		}

		private static List<Tree<int>> GetSubtreeWithSum(Tree<int> root, int targetSum)
		{
			var roots = new List<Tree<int>>();

			var sum = DfsTrees(root, targetSum, 0, roots);

			return roots;
		}

		private static int DfsTrees(Tree<int> node, int targetSum, int currentSum, List<Tree<int>> roots)
		{

			if (node == null)
			{
				return 0;
			}

			currentSum = node.Value;

			foreach (var child in node.Children)
			{
				currentSum += DfsTrees(child, targetSum, currentSum, roots);
			}

			if (currentSum == targetSum)
			{
				roots.Add(node);
			}

			return currentSum;
		}

		//static void EquilSum(Tree<int> node)
		//{
		//	foreach (var child in node.Children)
		//	{
		//		totalSum = 0;
		//		SumOfAll(child);
		//		if (totalSum == sumToBe)
		//		{
		//			Console.WriteLine("ura");
		//		}
		//		EquilSum(child);
		//	}
		//}
		//static void SumOfAll(Tree<int> node)
		//{
		//	totalSum += node.Value;
		//	foreach (var nodeChild in node.Children)
		//	{
		//		SumOfAll(nodeChild);
		//	}
		//}
		static void LongestPath()
		{


			var currentNode = DeepestNode(GetRootNode(), 0);
			var longestPah = new List<int>();

			while (true)
			{
				longestPah.Add(currentNode.Value);
				if (currentNode.Parent == null)
				{
					break;
				}

				currentNode = currentNode.Parent;
			}

			longestPah.Reverse();
			Console.WriteLine($"Longest path: {string.Join(" ", longestPah)}");
		}
		static void SumOfPath(Tree<int> node, int sum)
		{
			var currentSum = sum + node.Value;

			if (node.Children.Count > 0)
			{
				foreach (var nodeChild in node.Children)
				{
					SumOfPath(nodeChild, currentSum);
				}
			}
			if (currentSum == sumToBe)
			{
				PrintCurrentPath(node);
			}
			//Console.WriteLine(currentSum);
		}
		static void PrintCurrentPath(Tree<int> node)
		{
			List<int> values = new List<int>();

			var currentNode = node;
			while (true)
			{
				values.Add(currentNode.Value);
				if (currentNode.Parent == null)
				{
					break;
				}

				currentNode = currentNode.Parent;
			}

			values.Reverse();
			Console.WriteLine($"{string.Join(" ", values)}");
		}
		static Tree<int> DeepestNode(Tree<int> node, int count)
		{
			var currentCount = count + 1;
			if (currentCount > max)
			{
				max = currentCount;
				deepest = node;
			}
			var current = node;
			if (current.Children.Count > 0)
			{
				foreach (var currentChild in current.Children)
				{
					DeepestNode(currentChild, currentCount);
				}
			}
			return deepest;
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
			Console.WriteLine(string.Join(" ", leafs));
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