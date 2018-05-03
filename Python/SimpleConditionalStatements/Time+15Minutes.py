minutes = int(input())
seconds = int(input())

seconds += 15
if seconds>= 60:
    seconds-=60
    minutes+=1

if minutes == 24:
    minutes = 0

print(str(minutes),end=':')
if seconds < 10:
    print('0',end='')

print(seconds)