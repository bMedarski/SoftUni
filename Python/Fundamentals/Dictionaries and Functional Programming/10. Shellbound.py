import functools
import math
regions = {}

while True:
    line_input = input()
    if line_input == "Aggregate":
        break

    line_input_args = line_input.split()

    region = line_input_args[0]
    shells = int(line_input_args[1])

    if region not in regions:
        regions[region] = []
        regions[region].append(shells)
    else:
        if shells in regions[region]:
            continue
        else:
            regions[region].append(shells)

def sum_num(a,b):
    return a+b

for r in regions.keys():
    sum = functools.reduce(sum_num,regions[r])
    average = math.ceil(sum - (sum / len(regions[r])))
    print(f"{r} -> {', '.join(map(str, regions[r]))} ({average})")