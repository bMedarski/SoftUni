
days = int(input())

totalTime = 0
totalDistance = 0


for d in range(0,days):
    runningTime = int(input())
    distance = int(input())
    measurement = input()

    if measurement == "m":
        distance /= 1000

    totalDistance += distance
    totalTime += runningTime

calories = totalTime * 400/20
print("He ran {0:.2f}km for {1:.0f} minutes and burned {2:.0f} calories.".format(totalDistance,totalTime,calories))
