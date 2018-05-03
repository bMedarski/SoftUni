vegetablePrice = float(input())
fruitPrice = float(input())
vegetableWeight = float(input())
fruitWeight = float(input())

ammountInBG = vegetablePrice * vegetableWeight + fruitPrice * fruitWeight
ammountInEUR = ammountInBG / 1.94

print(ammountInEUR)