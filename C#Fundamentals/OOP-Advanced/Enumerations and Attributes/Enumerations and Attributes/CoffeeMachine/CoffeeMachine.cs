using System;
using System.Collections.Generic;

	public class CoffeeMachine
	{
		private int currentMoney;

		public CoffeeMachine()
		{
			this.CoffeesSold = new List<CoffeeType>();
		}

		public void BuyCoffee(string size, string type)
		{

			var coffeeType = (CoffeeType) Enum.Parse(typeof(CoffeeType), type);
			var coffeePrice = (int)(CoffeePrice)Enum.Parse(typeof(CoffeePrice), size);
			if (this.currentMoney>=coffeePrice)
			{
				this.CoffeesSold.Add(coffeeType);
				this.currentMoney = 0;
			}
		}

		public void InsertCoin(string coin)
		{
			this.currentMoney += (int) ((Coin) Enum.Parse(typeof(Coin), coin));
			
		}
		public IList<CoffeeType> CoffeesSold { get; }

	}

