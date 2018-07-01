list_input = list(map(float, input().split(" ")))

items_count = {}
for item in list_input:
    if item in items_count:
        items_count[item] += 1
    else:
        items_count[item] = 1

for key in sorted(items_count.keys()):
    print(f"{key} -> {items_count[key]} times")