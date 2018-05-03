import math
holidays = int(input())

timeForPlay = ((365 - holidays) * 63) + (holidays * 127)

if timeForPlay <= 30000:
    print('Tom sleeps well')
    hours = math.fabs(30000 - timeForPlay) // 60
    hours = int(hours)
    minutes = math.fabs(30000 - timeForPlay) % 60
    minutes = int(minutes)
    print(str(hours) + ' hours and ' + str(minutes) + ' minutes less for play')
else:
    print('Tom will run away')
    hours = math.fabs(30000 - timeForPlay) // 60
    hours = int(hours)
    minutes = math.fabs(30000 - timeForPlay) % 60
    minutes = int(minutes)
    print(str(hours) + ' hours and ' + str(minutes) + ' minutes more for play')
