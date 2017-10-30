size = int(input())
inner = size - 2

print('*'*size)
x = 0
while (x<size-2):
    print('*',end='')
    print(' '*(inner),end='')
    print('*')
    x+=1

print('*'*size)