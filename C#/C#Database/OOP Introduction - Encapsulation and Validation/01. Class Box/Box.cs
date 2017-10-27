using System;

public class Box
{
	private double length;
	private double height;
	private double width;

	public Box(double length, double height, double width)
	{
		this.Length = length;
		this.Height = height;
		this.Width = width;
	}

	public double Length
	{
		get { return this.length; }

		set{
			if (value <= 0)
			{
				throw  new ArgumentException("Length cannot be zero or negative.");
			}
			else
			{
				this.length = value;
			}
			
		}
	}

	public double Width
	{
		get { return this.width; }

		set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Width cannot be zero or negative.");
			}
			else
			{
				this.width = value;
			}

		}
	}
	public double Height
	{
		get { return this.height; }

		set
		{
			if (value <= 0)
			{
				throw new ArgumentException("Height cannot be zero or negative.");
			}
			else
			{
				this.height = value;
			}

		}
	}
	public double SurfaceArea()
	{
		double surface = 2 * this.height * this.length + 2 * this.height * this.width + 2 * this.length * this.width;
		return surface;
	}

	public double LateralSurfaceArea()
	{
		double lateralSurface = 2 * this.height * this.length + 2*this.height * this.width;
		return lateralSurface;
	}

	public double Volume()
	{
		var volume = this.height * this.length * this.width;
		return volume;
	}
}

