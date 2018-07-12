people = {}

while True:
    user_input = input()
    if user_input=="end":
        break

    user_input_args = user_input.split(" -> ")
    person = user_input_args[0]

    if person not in people:
        people[person] = []


    if "," in user_input_args[1]:
        nums = user_input_args[1].split(", ")
        for n in nums:
            people[person].append(int(n))
    else:
        if user_input_args[1].isdigit():
            people[person].append(int(user_input_args[1]))
        elif user_input_args[1] in people:
            people[person].extend(people[user_input_args[1]])
        else:
            continue

for p in people.items():
    if len(people[p[0]])>0:
        print(f"{p[0]} === ",end="")
        print(*p[1],sep=", ")