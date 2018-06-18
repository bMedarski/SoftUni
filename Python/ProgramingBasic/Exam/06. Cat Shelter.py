totalFood = int(input())*1000
foodGiven = 0
while True:

    food = input()
    if food == "Adopted":
        break

    foodQuantity = int(food)
    foodGiven += foodQuantity




if totalFood >= foodGiven:
    left = int(totalFood-foodGiven)
    print("Food is enough! Leftovers: {0} grams.".format(left))
else:
    needed = foodGiven - totalFood
    print("Food is not enough. You need {0} grams more.".format(needed))