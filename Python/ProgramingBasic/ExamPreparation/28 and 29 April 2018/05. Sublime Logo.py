n = int(input())
count = 1

for x in range(0,n):
    print(' '*(2*n-count*2), end='')
    print('*'*(count*2), end='')
    count+=1
    print()

print('*'*(2*n-2), end='')
print(' '*(2), end='')
print()
print('*'*(2*n-4), end='')
print(' '*(4), end='')
print()
print('*'*(2*n-2), end='')
print(' '*(2), end='')
print()
print('*'*2*n,end='')
print()
print(' '*(2), end='')
print('*'*(2*n-2), end='')
print()
print(' '*(4), end='')
print('*'*(2*n-4), end='')
print()
print(' '*(2), end='')
print('*'*(2*n-2), end='')
print()

count = n
for x in range(n,0,-1):
    print('*' * (count * 2), end='')
    print(' '*(2*n-count*2), end='')
    count-=1
    print()