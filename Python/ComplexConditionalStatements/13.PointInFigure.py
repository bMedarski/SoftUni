h = int(input())
x = int(input())
y = int(input())

def onBoard(h,x,y):
    if x == 0 and (y >=0 and y <= h):
        return True
    if x == 3*h and (y >=0 and y <= h):
        return True
    if x == h and (y >=h and y <= 4*h):
        return True
    if x == 2*h and (y >=h and y <= 4*h):
        return True
    if y == 0 and (x >=0 and x <= 3*h):
        return True
    if y == h and (x >=0 and x <= h):
        return True
    if y == h and (x >=2*h and x <= 3*h):
        return True
    if y == 4*h and (x >=h and x <= 2*h):
        return True
    return False

def inside(h,x,y):
    if x >= 0 and x<=3*h:
        if y >= 0 and y <=h:
            return True
    if y >=0 and y <=4*h:
        if x >=h and x<=2*h:
            return True
    return False

if x <0 or y <0:
    print('outside')
elif onBoard(h,x,y):
    print('border')
elif inside(h,x,y):
    print('inside')
else:
    print('outside')

