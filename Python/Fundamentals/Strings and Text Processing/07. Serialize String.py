text = input()

chars = []

def allindices(string, sub, listindex=[], offset=0):
    i = string.find(sub, offset)
    while i >= 0:
        listindex.append(i)
        i = string.find(sub, i + 1)
    return listindex

for c in text:
    positions = []
    if c not in chars:
        chars.append(c)
        positions = allindices(text,c,positions)
    else:
        continue
    position_array = "/".join(list(map(str,positions)))
    print(f"{c}:"+position_array)

