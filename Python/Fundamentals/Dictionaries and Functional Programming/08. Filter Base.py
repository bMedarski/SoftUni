import re

employee_age = {}
employee_salary = {}
employee_position = {}

while True:
    user_input = input()
    if user_input == "filter base":
        break

    user_input_args = user_input.split(" -> ")

    name = user_input_args[0]
    arg = user_input_args[1]

    age_pattern = r"^-?\d+$"
    salary_pattern = r"\d+.\d+"
    position_pattern = r"[a-zA-Z _-]+"


    if re.match(age_pattern,arg):
        employee_age[name] = arg
    elif re.match(position_pattern,arg):
        employee_position[name] = arg
    else:
        employee_salary[name]=arg

case = input()


if case=="Age":
    for p in employee_age:
        print(f"Name: {p}")
        print(f"Age: {employee_age[p]}")
        print("====================")
elif case=="Salary":
    for p in employee_salary:
        print(f"Name: {p}")
        print(f"Salary: {employee_salary[p]}")
        print("====================")
else:
    for p in employee_position:
        print(f"Name: {p}")
        print(f"Position: {employee_position[p]}")
        print("====================")

employee_string = input()
employee_age = {}
employee_position = {}
employee_salary = {}

while True:
    user_input = input()
    if user_input == "filter base":
        break

    user_input_args = user_input.split(" -> ")
    try:
        value = float(user_input[1])
        if value % 1 == 0.0:
            employee_age[user_input[0]] = int(value)
        else:
            employee_salary[user_input[0]] = value
    except ValueError:
        employee_position[user_input[0]] = user_input[1]

case = input()

if case=="Age":
    for p in employee_age:
        print(f"Name: {p}")
        print(f"Age: {employee_age[p]}")
        print("====================")
elif case=="Salary":
    for p in employee_salary:
        print(f"Name: {p}")
        print(f"Salary: {employee_salary[p]}")
        print("====================")
else:
    for p in employee_position:
        print(f"Name: {p}")
        print(f"Position: {employee_position[p]}")
        print("====================")