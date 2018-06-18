n = int(input())
width = n*2 + 6

for i in range(0,n):
    first = n+2
    print('-'*first,end='')
    print('**',end='')
    print('-' * first, end='')
    print()

for i in range(0,n-3):
    second = n+1
    print('-' * second, end='')
    print('*'*4, end='')
    print('-' * second, end='')
    print()

print('-'*n,end='')
print('*'*6,end='')
print('-'*n,end='')
print()

third = n - 4

for i in range(0,third):
    print('-' * n, end='')
    print('*' * 2, end='')
    print('-' * 2, end='')
    print('*' * 2, end='')
    print('-' * n, end='')
    print()

forth = n - 3

for i in range(0,forth):
    print('-' * (n-1), end='')
    print('*' * 2, end='')
    print('-' * 4, end='')
    print('*' * 2, end='')
    print('-' * (n-1), end='')
    print()

fifth = int((width-10)/2)

print('-'*fifth,end='')
print('*'*10,end='')
print('-'*fifth,end='')
print()

middle = 8

for i in range(forth,0,-1):
    side = int((width - middle - 4) / 2)
    print('-' * side, end='')
    print('*' * 2, end='')
    print('-' * (middle), end='')
    print('*' * 2, end='')
    print('-' * side, end='')
    print()
    middle+=2

print('*'*3,end='')
print('-'*n*2,end='')
print('*'*3,end='')
print()