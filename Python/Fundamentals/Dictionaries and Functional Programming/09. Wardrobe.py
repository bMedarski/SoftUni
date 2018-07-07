lines = int(input())

colors = {}

for i in range(0,lines):
    line = input()
    line_args = line.split(" -> ")
    color = line_args[0]
    clothes = line_args[1].split(",")

    if color not in colors:
        colors[color]= {}

    for cloth in clothes:
        if cloth not in colors[color]:
            colors[color][cloth] = 1
        else:
            colors[color][cloth] += 1

searched_cloth = input().split()

s_color = searched_cloth[0]
s_cloth = searched_cloth[1]
suffix = " (found!)"

for c in colors.keys():
    print(f"{c} clothes:")
    for cl in colors[c].keys():
        if c == s_color and cl == s_cloth:
            print(f"* {cl} - {colors[c][cl]}"+suffix)
        else:
            print(f"* {cl} - {colors[c][cl]}")