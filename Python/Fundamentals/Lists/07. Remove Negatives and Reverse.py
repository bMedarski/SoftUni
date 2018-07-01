list_input =list(map(int, input().split(" ")))

new_list = []

if len(list_input)==0:
    print("empty")
else:
    for num in list_input:
        if num>=0:
            new_list.append(num)

new_list.reverse()
new_list = list(map(str,new_list))

if len(new_list)==0:
    print("empty")
print(" ".join(new_list))