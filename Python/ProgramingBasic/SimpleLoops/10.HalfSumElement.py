import math
n = int(input())
max = 0
sum = 0

for i in range(0,n):
    num = int(input())
    sum+= num
    if max < num:
        max = num

if sum / 2 == max:
    print('Yes')
    print('Sum = {}'.format(max))
else:
    print('No')
    diff = math.fabs(max - (sum - max))
    print('Diff = {}'.format(diff))