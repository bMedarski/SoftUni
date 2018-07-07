def is_float_try(str):
    try:
        float(str)
        return True
    except ValueError:
        return False


def is_int_try(str):
    try:
        int(str)
        return True
    except ValueError:
        return False


in_line = input()
dict = {}
age = {}
salary = {}
position = {}

while in_line != "filter base":
    params = in_line.split(" -> ")
    in_name = params[0].strip(" ")

    in_param = params[1].strip(" ")

    if is_float_try(in_name):
        if is_int_try(in_name):
            age[in_name] = abs(int(in_param))
        else:
            salary[in_name] = abs(float(in_param))
    else:
        position[in_name] = in_param

    in_line = input()

## Read sort coloumn
sort_criteria = input().strip(" ")

if sort_criteria.lower() == "age":
    for i in age:
        if len(i) == 0:
            continue
        print(f"Name: {i}")
        print(f"Age: {age[i]}")
        print("====================")
elif sort_criteria.lower() == "salary":
    for i in salary:
        if len(i) == 0:
            continue
        print(f"Name: {i}")
        print(f"Salary: {salary[i]}")
        print("====================")
elif sort_criteria.lower() == "position":
    for i in position:
        if len(i) == 0:
            continue
        print(f"Name: {i}")
        print(f"Position: {position[i]}")
        print("====================")