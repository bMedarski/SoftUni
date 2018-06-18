mazniniPercent = int(input())
proteiniPercent = int(input())
vuglehidratiPercent = int(input())
totalCalories = int(input())
waterPercent = int(input())

mazniniTotal = mazniniPercent/100*totalCalories/9
proteiniTotal = proteiniPercent/100*totalCalories/4
vuglehedratiTotal = vuglehidratiPercent/100*totalCalories/4
weight = mazniniTotal + proteiniTotal + vuglehedratiTotal
caloriesPerGram = totalCalories / weight

oneGram = caloriesPerGram * (1 - waterPercent/100)

print("{0:.4f}".format(oneGram))