oddSum = 0
evenSum = 0
oddMax = -1000000000.0
evenMax = -1000000000.0
oddMin = 1000000000.0
evenMin = 1000000000.0

n = int(input())

for i in range (1,n+1):

    num = float(input())

    if i%2 == 0:
        evenSum += num
        if num > evenMax:
            evenMax = num
        if num < evenMin:
            evenMin = num
    else:
        oddSum += num
        if num > oddMax:
            oddMax = num
        if num < oddMin:
            oddMin = num

print('OddSum={0:g},'.format(oddSum))

if oddMin == 1000000000.0:
    print('OddMin=No,')
else:
    print('OddMin={0:g},'.format(oddMin))

if oddMax == -1000000000.0:
    print('OddMax=No,')
else:
    print('OddMax={0:g},'.format(oddMax))

print('EvenSum={0:g},'.format(evenSum))

if evenMin == 1000000000.0:
    print('EvenMin=No,')
else:
    print('EvenMin={0:g},'.format(evenMin))

if evenMax == -1000000000.0:
    print('EvenMax=No,')
else:
    print('EvenMax={0:g}'.format(evenMax))
