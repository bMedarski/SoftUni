n = int(input())


height = 3 * (n-2)

for i in range(0,n-2):
    print("  ", end='')
    print("||",end='')
    print("_"*(n-2),end='')
    print("||", end='')
    print("   ", end='')
    print()

print(" //", end='')
print(" "*(n),end='')
print("\\\\", end='')
print()

heightMiddle = n-4

for i in range(0,heightMiddle):

    buttonHeight = heightMiddle//2
    if n %2 ==0:
        buttonHeight-= 1
    if i == buttonHeight:
        print("||", end='')
        print(" " * (n+2), end='')
        print("||]", end='')
    else:
        print("||", end='')
        print(" " * (n + 2), end='')
        print("||", end='')
    print()

print(" \\\\", end='')
print(" "*(n),end='')
print("//", end='')
print()

for i in range(0,n-2):
    print("  ", end='')
    print("||",end='')
    print("_"*(n-2),end='')
    print("||", end='')
    print("   ", end='')
    print()