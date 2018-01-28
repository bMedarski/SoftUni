using System;
using System.Collections.Generic;
using System.Text;

namespace Root_Node
{
    public class Tree<T>
    {
	    public Tree(T value)
	    {
		    this.Value = value;
		    this.Children = new List<Tree<T>>();

	    }

		public T Value { get; set; }
		public List<Tree<T>> Children { get; set; }
	    public Tree<T> Parent;
    }
}
