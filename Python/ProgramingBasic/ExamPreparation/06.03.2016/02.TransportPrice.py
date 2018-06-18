days = int(input())
time = input()
price = 0

if days < 20:
    price = 0.7
    if time == 'day':
        price += days*0.79
    else:
        price += days*0.9
elif days < 100:
    price = days * 0.09
else:
    price = days * 0.06

print(price)