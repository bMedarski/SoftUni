number = float(input())
inputType = input()
output = input()


mm = 1000.0
cm = 100.0
mi = 0.000621371192
inn = 39.3700787
km = 0.001
ft = 3.2808399
yd = 1.0936133
m = 1.0

if inputType == "mm":
    number = number / mm
elif inputType == "cm":
    number = number / cm
elif inputType == "mi":
    number = number / mi
elif inputType == "in":
    number = number / inn
elif inputType == "km":
    number = number / km
elif inputType == "ft":
    number = number / ft
elif inputType == "yd":
    number = number / yd
elif inputType == "m":
    number = number / m

if output == "mm":
    number = number * mm
elif output == "cm":
    number = number * cm
elif output == "mi":
    number = number * mi
elif output == "in":
    number = number * inn
elif output == "km":
    number = number * km
elif output == "ft":
    number = number * ft
elif output == "yd":
    number = number * yd
elif output == "m":
    number = number * m

print(str(number)+" "+output)