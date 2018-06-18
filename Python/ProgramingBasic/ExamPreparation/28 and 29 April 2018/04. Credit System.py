courses = int(input())

creditsParts = [0,0,0,0.5,0.7,0.85,1]
sumOfGrades = 0
totalCredits = 0


for c in range(1,courses+1):
    currentCourse = int(input())

    grade = currentCourse%10
    sumOfGrades+= grade

    credits = ((currentCourse - grade)/10) * creditsParts[grade]
    totalCredits += credits

print("{:.2f}".format(totalCredits))
print("{:.2f}".format(sumOfGrades/courses))