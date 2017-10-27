using System;

public class Car
{
	private string model;
	private double fuelAmount;
	private double fuelConsumption;
	private int distance;


	public Car(string model, double fuelAmount, double fuelConsumption)
	{
		this.Model = model;
		this.FuelConsumption = fuelConsumption;
		this.FuelAmount = fuelAmount;
		this.Distance = 0;
	}

	public string Model
	{
		get => this.model;
		set => this.model = value;
	}

	public double FuelAmount
	{
		get => this.fuelAmount;
		set => this.fuelAmount = value;
	}

	public double FuelConsumption
	{
		get => this.fuelConsumption;
		set => this.fuelConsumption = value;
	}

	public int Distance
	{
		get => this.distance;
		set => this.distance = value;
	}

	public void Drive(int distance)
	{

		var neededFuel = distance * this.FuelConsumption;
		if (neededFuel > this.FuelAmount)
		{
			Console.WriteLine("Insufficient fuel for the drive");
		}
		else
		{
			this.FuelAmount -= neededFuel;
			this.Distance += distance;
		}
	}

	public override string ToString()
	{
		return $"{this.Model} {this.FuelAmount:F2} {this.Distance}";
	}
}

