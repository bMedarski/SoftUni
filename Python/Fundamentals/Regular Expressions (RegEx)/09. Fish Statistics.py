import re

regex = r"(?P<tail>>*)<(?P<body>\(+)(?P<status>'|-|x)>"

fishes = input()
count = 0
if len(re.findall(regex,fishes)) == 0:
    print("No fish found.")
else:
    matches = re.finditer(regex,fishes)

    for m in matches:
        count +=1
        fish = m.group(0)
        tail = m.group("tail")
        body = m.group("body")
        status = m.group("status")

        if len(tail) > 5:
            tail_size = f"Long ({len(tail)*2} cm)"
        elif len(tail) > 1:
            tail_size = f"Medium ({len(tail)*2} cm)"
        elif len(tail) == 1:
            tail_size = f"Short ({len(tail)*2} cm)"
        else:
            tail_size = "None"

        if len(body) > 10:
            body_size = f"Long ({len(body)*2} cm)"
        elif len(body) > 5:
            body_size = f"Medium ({len(body)*2} cm)"
        else:
            body_size = f"Short ({len(body)*2} cm)"

        if status == "'":
            current_status = "Awake"
        elif status == "-":
            current_status = "Asleep"
        elif status == "x":
            current_status = "Dead"


        print(f"Fish {count}: {fish}")
        print(f"    Tail type: {tail_size}")
        print(f"    Body type: {body_size}")
        print(f"    Status: {current_status}")