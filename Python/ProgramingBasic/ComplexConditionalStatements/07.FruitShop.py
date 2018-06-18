days = ['Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday']
fruits = ['banana','apple','orange','grapefruit','kiwi','pineapple','grapes']
normalPrice = [2.50,1.20,0.85,1.45,2.70,5.50,3.85]
weekendPrice = [2.70,1.25,0.90,1.60,3.00,5.60,4.20]

fruit = input()
day = input()
quantity = float(input())

if fruit in fruits:
    if day in days:
        if day=='Saturday' or day == 'Sunday':
            index = fruits.index(fruit)
            print("{0:.2f}".format(weekendPrice[index] * quantity))
        else:
            index = fruits.index(fruit)
            print("{0:.2f}".format(normalPrice[index] * quantity))
    else:
        print('error')
else:
    print('error')