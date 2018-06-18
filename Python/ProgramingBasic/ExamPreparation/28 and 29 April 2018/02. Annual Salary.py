jobs = {
    "C# Developer":5400,
    "Java Developer":5700,
    "Front-End Web Developer":4100,
    "UX / UI Designer":3100,
    "Game Designer":3600,
}

ageOfExperience = int(input())
job = input()
salary = 12 * jobs[job]
if ageOfExperience<=5:
    salary *= 0.342

print("Total earned money: {:.2f} BGN".format(salary))