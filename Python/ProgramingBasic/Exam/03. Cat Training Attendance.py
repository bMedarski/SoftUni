weekDayBonus = {
    "Monday":0.6,
    "Tuesday":0.8,
    "Wednesday":0.6,
    "Thursday":0.8,
    "Friday":0.6,
    "Saturday":0.8,
    "Sunday":2,
}

lectureTimeStart = int(input())
visitHour = int(input())
visitMinute = int(input())
day = input()

bonus = weekDayBonus[day]

if lectureTimeStart>visitHour:
    bonus += 1.5
elif lectureTimeStart == visitHour and visitMinute < 30:
    bonus += 1
else:
    bonus += 0.5

print("{0:.2f}".format(bonus))