import math

year = input()
holidays = int(input())
homeTownWeekends = int(input())
restWeekends = (48 - homeTownWeekends)*3/4

holidaysTime = holidays*2/3

totalDays = holidaysTime+restWeekends+homeTownWeekends
if year == 'leap':
    totalDays*=1.15

print(math.floor(totalDays))