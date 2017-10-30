sum = float(input())
fromMoney = input()
toMoney = input()


if fromMoney == 'BGN':
    if toMoney == 'USD':
        print(str(sum/1.79549))
    elif toMoney == 'EUR':
        print(str(sum / 1.95583))
    elif toMoney == 'GBP':
        print(str(sum / 2.53405))
elif fromMoney == 'USD':
    if toMoney == 'BGN':
        print(str(sum * 1.79549))
    elif toMoney == 'EUR':
        print(str(sum * 0.91801))
    elif toMoney == 'GBP':
        print(str(sum * 0.70854))
elif fromMoney == 'EUR':
    if toMoney == 'BGN':
        print(str(sum * 2.53405))
    elif toMoney == 'USD':
        print(str(sum * 1.08930))
    elif toMoney == 'GBP':
        print(str(sum * 0.77181))
elif fromMoney == 'GBP':
    if toMoney == 'BGN':
        print(str(sum * 0.39462))
    elif toMoney == 'USD':
        print(str(sum * 0.70854))
    elif toMoney == 'EUR':
        print(str(sum *  0.77181))