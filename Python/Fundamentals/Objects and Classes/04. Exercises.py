class Exercise:
    def __init__(self,topic,course_name,judge_contest_link,):
        self.topic = topic
        self.course_name = course_name
        self.judge_contest_link = judge_contest_link
        self.problems = []


    def add_problems(self,list_of_problems):
        for problem in list_of_problems:
            self.problems.append(problem)

    def print_problem(self):
        print(f"Exercises: {self.topic}")
        print(f"Problems for exercises and homework for the \"{self.course_name}\" course @ SoftUni.")
        print(f"Check your solutions here: {self.judge_contest_link}")
        problem_count = len(self.problems)
        for i in range(0,problem_count):
            print(f"{i+1}. {self.problems[i]}")

list_of_exercises = []

while True:
    user_input = input()
    if user_input == "go go go":
        break

    exercise_args = user_input.split(" -> ")
    problems = exercise_args[3].split(", ")
    exercise = Exercise(exercise_args[0],exercise_args[1],exercise_args[2])
    exercise.add_problems(problems)
    list_of_exercises.append(exercise)

for exercise in list_of_exercises:
    exercise.print_problem()


