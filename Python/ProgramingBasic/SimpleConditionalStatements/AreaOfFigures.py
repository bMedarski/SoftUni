import math

figure = input()
area = 0
if figure=='square':
    size = float(input())
    area = size*size
elif figure =='rectangle':
    size1 = float(input())
    size2 = float(input())
    area = size1*size2
elif figure == 'circle':
    r = float(input())
    area = math.pi * r *r
elif figure == 'triangle':
    size1 = float(input())
    size2 = float(input())
    area = size1*size2 / 2

print("{0:.3f}".format(area))