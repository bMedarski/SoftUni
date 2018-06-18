sec1 = int(input())
sec2 = int(input())
sec3 = int(input())

totalSecs = sec1 + sec2 + sec3

if totalSecs < 60:
    print('0:',end='')
    if totalSecs < 10:
        print('0',end='')
        print(totalSecs)
    else:
        print(totalSecs)
elif totalSecs < 120:
    print('1:', end='')
    totalSecs-=60
    if totalSecs < 10:
        print('0',end='')
        print(totalSecs)
    else:
        print(totalSecs)
elif totalSecs < 180:
    print('2:', end='')
    totalSecs-=120
    if totalSecs < 10:
        print('0',end='')
        print(totalSecs)
    else:
        print(totalSecs)