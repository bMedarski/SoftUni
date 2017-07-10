using _05.Pizza_Calories;

namespace p05_PizzaCalories
{
    using System;

    public class PizzaCalories
    {
        public static void Main()
        {
            string input;

            while ((input = Console.ReadLine()) != "END")
            {
                string[] inParams = input.Split(' ');

                try
                {
                    switch (inParams[0])
                    {
                        case "Dough":
                            Dough dough = new Dough(inParams[1], inParams[2], double.Parse(inParams[3]));
                            Console.WriteLine($"{dough.Calories():f2}");
                            break;

                        case "Topping":
                            Topping topping = new Topping(inParams[1], double.Parse(inParams[2]));
                            Console.WriteLine($"{topping.Calories():f2}");
                            break;

                        case "Pizza":
                            MakePizza(inParams);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
        }


        public static void MakePizza(string[] inParams)
        {
            int numberToppings = int.Parse(inParams[2]);
            Pizza pizza = new Pizza(inParams[1], numberToppings);

            string[] doughInfo = Console.ReadLine().Split(' ');
            Dough dough = new Dough(doughInfo[1], doughInfo[2], double.Parse(doughInfo[3]));
            pizza.Dough = dough;

            for (var i = 0; i < numberToppings; i++)
            {
                string[] toppingInfo = Console.ReadLine().Split(' ');
                Topping topping = new Topping(toppingInfo[1], double.Parse(toppingInfo[2]));
                pizza.AddTopping(topping);
            }

            Console.WriteLine($"{pizza.Name} - {pizza.TotalCalories():f2} Calories.");
        }

    }
}