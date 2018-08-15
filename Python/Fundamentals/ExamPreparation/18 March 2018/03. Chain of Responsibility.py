import re

regex = r"\d+[A-Z][a-z]+\w{2,}|[A-Z]{2,}"

lines_count = int(input())

robot_list = []
manager = ""

broke_chain = False

for i in range(lines_count):
    line = input()

    matches = re.findall(regex,line)

    if len(matches)==1:
        if line[-2:] == "!!":
            manager = matches[0]
    elif i == 0:
        robot_list.append(matches[0])
        robot_list.append(matches[1])
    elif i >0:
        last = robot_list[-1]
        if last != matches[0]:
            broke_chain = True
        else:
            robot_list.append(matches[1])

if broke_chain:
    print("Broke the chain!")
elif manager != "":
    print(f"Found the manager!: {manager}")
else:
    print("Did not find the manager!")
print("Chain: ",end="")
print("->".join(robot_list))
