key = input()
value = input()
lines = int(input())

code = {}

for line in range(lines):
    correct_vals = []
    line_args = input().split(" => ")
    k = line_args[0]
    values = line_args[1].split(";")
    try:
        item = k.index(key)
    except:
        continue

    if k not in code:
        code[k] = []

    for val in values:
        try:
            v = val.index(value)
            code[k].append(val)
        except:
            continue

for k in code.keys():
    print(f"{k}:")
    for v in code[k]:
        print(f"-{v}")
