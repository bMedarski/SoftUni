final_string = {}

while True:
    line = input()
    if line == "end":
        break

    line_split = line.split(":")
    ch = line_split[0]
    final_string[ch] = []
    positions = list(map(int,line_split[1].split("/")))

    for pos in positions:
        final_string[ch].append(pos)


max_num = 0
for c in final_string.values():
    if max(c) > max_num:
        max_num = max(c)

string = [None]*(max_num+1)

for k,v in final_string.items():
    for p in v:
        string[p] = k

print("".join(string))