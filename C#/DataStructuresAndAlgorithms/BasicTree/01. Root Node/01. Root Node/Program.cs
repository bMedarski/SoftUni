﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Root_Node
{
	public class Program
	{
		static Dictionary<int, Tree<int>> nodeByValue = new Dictionary<int, Tree<int>>();

		static void Main()
		{
			ReadTree();
			var root = GetRootNode();
			Console.WriteLine($"Root node: {root.Value}");
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
