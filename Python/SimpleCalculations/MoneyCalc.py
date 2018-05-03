sum = float(input())
cur1 = input()
cur2 = input()
BGN_USD = sum/1.79549
USD_BGN = sum*1.79549
BGN_EUR = sum/1.95583
EUR_BGN = sum*1.95583
BGN_GBP = sum/2.53405
GBP_BGN = sum*2.53405
USD_EUR = sum/1.089301528
EUR_USD = sum*1.089301528
USD_GBP = sum/1.411341751
GBP_USD = sum*1.411341751
EUR_GBP = sum/1.295639192
GBP_EUR = sum*1.295639192
if cur1 == "BGN" and cur2 == "USD":
    print (float("{0:.2f}".format (BGN_USD)))
elif cur1 == "USD" and cur2 == "BGN":
    print (float("{0:.2f}".format (USD_BGN)))
elif cur1 == "BGN" and cur2 == "EUR":
    print(float("{0:.2f}".format(BGN_EUR)))
elif cur1 == "EUR" and cur2 == "BGN":
    print(float("{0:.2f}".format(EUR_BGN)))
elif cur1 == "BGN" and cur2 == "GBP":
    print(float("{0:.2f}".format(BGN_GBP)))
elif cur1 == "GBP" and cur2 == "BGN":
    print(float("{0:.2f}".format(GBP_BGN)))
elif cur1 == "USD" and cur2 == "EUR":
    print(float("{0:.2f}".format(USD_EUR)))
elif cur1 == "EUR" and cur2 == "USD":
    print(float("{0:.2f}".format(EUR_USD)))
elif cur1 == "USD" and cur2 == "GBP":
    print(float("{0:.2f}".format(USD_GBP)))
elif cur1 == "GBP" and cur2 == "USD":
    print(float("{0:.2f}".format(GBP_USD)))
elif cur1 == "EUR" and cur2 == "GBP":
    print(float("{0:.2f}".format(EUR_GBP)))
elif cur1 == "GBP" and cur2 == "EUR":
    print(float("{0:.2f}".format(GBP_EUR)))