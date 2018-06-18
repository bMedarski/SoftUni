productPrices = {
    "Linen":15,
    "Cotton":12,
    "Denim":20,
    "Twill":16,
    "Flannel":11
}

armLength = float(input())
upperPart = float(input())
material = input()
tie = input()

size = ((armLength * 2 + upperPart * 2)*1.1)/100
price = size*productPrices[material] + 10

if tie == "Yes":
    price=price*1.2

print("The price of the shirt is: {0:.2f}lv.".format(price))