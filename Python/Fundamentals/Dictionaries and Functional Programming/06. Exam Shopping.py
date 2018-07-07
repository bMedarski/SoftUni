
shop = {}

while True:
    stock = input()

    if stock == "shopping time":
        break

    stock_args = stock.split(" ")
    product = stock_args[1]
    quantity = int(stock_args[2])

    if product in shop:
        shop[product] += quantity
    else:
        shop[product] = quantity

while True:
    buy = input()

    if buy == "exam time":
        break

    buy_args = buy.split(" ")
    product = buy_args[1]
    quantity = int(buy_args[2])

    if product not in shop:
        print(f"{product} doesn't exist")
    elif shop[product] <= 0:
        print(f"{product} out of stock")
    else:
        shop[product] -= quantity

for pr in shop:
    if shop[pr]>0:
        print(f"{pr} -> {shop[pr]}")