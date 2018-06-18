import math

x1 = float(input())
y1 = float(input())
x2 = float(input())
y2 = float(input())
a = math.fabs(y2-y1)
b = math.fabs(x2-x1)

print((a*b))
print((2*a+2*b))