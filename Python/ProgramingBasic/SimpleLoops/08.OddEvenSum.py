import math
n = int(input())

sum1 = 0
sum2 = 0

for i in range(0,n):
    num = int(input())

    if i %2==0:
        sum1+=num
    else:
        sum2+=num

if sum1==sum2:
    print('Yes')
    print('Sum = '+str(sum1))
else:
    diff = math.fabs(sum1-sum2)
    print('No')
    print('Diff = ' + str(diff))