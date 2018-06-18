import math

physicalActivity = {
    "sedentary":1.2,
    "lightly active":1.375,
    "moderately active":1.55,
    "very active":1.725
}

sex = input()
weight = float(input())
height = float(input())
age = int(input())
physActivity = input()

bmp = 0

if(sex is "m"):
    bmp = (66 + (13.7 * weight) + (5 * height * 100) - (6.8 * age)) * physicalActivity[physActivity]
else:
    bmp = (655 + (9.6 * weight) + (1.8 * height * 100) - (4.7 * age)) * physicalActivity[physActivity]

bmp = math.ceil(bmp)

print("To maintain your current weight you will need {0} calories per day.".format(bmp))