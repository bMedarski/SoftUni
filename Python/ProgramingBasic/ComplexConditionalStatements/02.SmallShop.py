product = input().lower()
town = input().lower()
quantity = float(input())


if product == 'coffee' and town == 'sofia':
    print(quantity*0.5)
elif product == 'coffee' and town == 'plovdiv':
    print(quantity*0.4)
elif product == 'coffee' and town == 'varna':
    print(quantity * 0.45)
elif product == 'water' and town == 'sofia':
    print(quantity*0.8)
elif product == 'water' and town == 'plovdiv':
    print(quantity*0.7)
elif product == 'water' and town == 'varna':
    print(quantity * 0.7)
elif product == 'beer' and town == 'sofia':
    print(quantity*1.2)
elif product == 'beer' and town == 'plovdiv':
    print(quantity*1.15)
elif product == 'beer' and town == 'varna':
    print(quantity * 1.10)
elif product == 'sweets' and town == 'sofia':
    print(quantity*1.45)
elif product == 'sweets' and town == 'plovdiv':
    print(quantity*1.3)
elif product == 'sweets' and town == 'varna':
    print(quantity * 1.35)
elif product == 'peanuts' and town == 'sofia':
    print(quantity*1.60)
elif product == 'peanuts' and town == 'plovdiv':
    print(quantity*1.50)
elif product == 'peanuts' and town == 'varna':
    print(quantity * 1.55)