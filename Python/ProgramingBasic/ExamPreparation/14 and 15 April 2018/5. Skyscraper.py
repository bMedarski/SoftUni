n = int(input())

width = 2*n + 1


for i in range(0,n-3):
    print(" "*n,end='')
    print("|", end='')
    print(" " * n, end='')
    print()

print(" "*(n-1),end='')
print("_|_",end='')
print(" "*(n-1),end='')
print()

for i in range(0,n-3):
    print(" " * (n-1),end='')
    print("|-|", end='')
    print(" " * (n-1), end='')
    print()

print(" "*(n-2),end='')
print("_|-|_",end='')
print(" "*(n-2),end='')
print()

for i in range(0,n-3):
    print(" " * (n-2),end='')
    print("|***|", end='')
    print(" " * (n-2), end='')
    print()


if n>3:
    wall = n-3
    space = (width - wall - wall - 5)/2
    print(" " * int(space),end='')
    print("_"*(n-3),end='')
    print("|***|", end='')
    print("_" * (n - 3), end='')
    print(" " * int(space), end='')
    print()
else:
    print(" " * (n - 2), end='')
    print("|***|", end='')
    print(" " * (n - 2), end='')
    print()


for i in range(0,4*n-1):
    wall = n-2
    space = int(width - 2*wall - 3)
    print(" " * int(space/2),end='')              
    print("|" * wall,end='')
    print("---", end='')
    print("|" * wall, end='')
    print(" " * int(space/2), end='')
    print()
wall = n-2
space = int(width - 2*wall - 3)
print("_" * int(space/2),end='')
print("|" * wall,end='')
print("---", end='')
print("|" * wall, end='')
print("_" * int(space/2), end='')
print()

for i in range(0,n-2):
    print("|"*(2*n+1))