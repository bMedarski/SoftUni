items_input = input().split(" ")

items_count = {}

for item in items_input:
    if item.lower() in items_count:
        items_count[item.lower()] += 1
    else:
        items_count[item.lower()] = 1

result_list = []

for key in items_count:
    if items_count[key]%2!=0:
        result_list.append(key)

print(", ".join(result_list))