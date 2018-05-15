days = ['Error','Monday','Tuesday','Wednesday','Thursday','Friday','Saturday','Sunday']

day = int(input())

if day<1 or day>7:
    print(days[0])
else:
    print(days[day])