import math
n = int(input())

sum1 = 0
sum2 = 0

for i in range(0,2*n):
    num = int(input())

    if i < n:
        sum1+=num
    else:
        sum2+=num

if sum1==sum2:
    print('Yes, sum = '+str(sum1))
else:
    diff = math.fabs(sum1-sum2)
    print('No, diff = ' + str(diff))