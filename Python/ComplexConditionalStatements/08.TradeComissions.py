city = input()
sales = float(input())


if sales < 0:
    print('error')
elif sales <= 500:
    if city == 'Sofia':
        print("{0:.2f}".format(sales*0.05))
    elif city == 'Varna':
        print("{0:.2f}".format(sales*0.045))
    elif city == 'Plovdiv':
        print("{0:.2f}".format(sales * 0.055))
    else:
        print('error')
elif sales <= 1000:
    if city == 'Sofia':
        print("{0:.2f}".format(sales*0.07))
    elif city == 'Varna':
        print("{0:.2f}".format(sales*0.075))
    elif city == 'Plovdiv':
        print("{0:.2f}".format(sales * 0.08))
    else:
        print('error')
elif sales <= 10000:
    if city == 'Sofia':
        print("{0:.2f}".format(sales*0.08))
    elif city == 'Varna':
        print("{0:.2f}".format(sales*0.1))
    elif city == 'Plovdiv':
        print("{0:.2f}".format(sales * 0.12))
    else:
        print('error')
elif sales > 10000:
    if city == 'Sofia':
        print("{0:.2f}".format(sales*0.12))
    elif city == 'Varna':
        print("{0:.2f}".format(sales*0.13))
    elif city == 'Plovdiv':
        print("{0:.2f}".format(sales * 0.145))
    else:
        print('error')