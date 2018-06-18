import math

distanceToMoon = 384400

speed = float(input())
fuel = float(input())

time = math.ceil(distanceToMoon*2/speed)

print(time+3)

fuelNeeded = (fuel*(distanceToMoon*2))/100
print(int(fuelNeeded))