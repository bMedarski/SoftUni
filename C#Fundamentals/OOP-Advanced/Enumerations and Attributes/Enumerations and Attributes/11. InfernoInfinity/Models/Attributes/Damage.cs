public class Damage:IDamage
	{
		private int min;
		private int max;

		public Damage(int min, int max)
		{
			this.Min = min;
			this.Max = max;
		}

		public int Min
		{
			get => this.min;
			set => this.min = value;
		}

		public int Max
		{
			get => this.max;
			set => this.max = value;
		}

		public override string ToString()
		{
			return $"{this.Min}-{this.Max} Damage";
		}
	}
