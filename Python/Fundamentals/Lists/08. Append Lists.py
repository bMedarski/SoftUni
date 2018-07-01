input = list(input().split("|"))

result = []

for item in input:
    current_list = item.split(" ")
    current_list = list(filter(None, current_list))
    current_list.extend(result)
    result = current_list

print(" ".join(result))
