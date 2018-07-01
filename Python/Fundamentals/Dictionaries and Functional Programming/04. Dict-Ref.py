
dict = {}

while True:
    current = input()
    if current == "end":
        break

    current = current.split("=")
    current_key = current[0].strip(" ")
    current_value = current[1].strip(" ")
    if current_key in dict:
       if current_value.isdigit():
           dict[current_key] = int(current_value)
       else:
           if current_value in dict:
               dict[current_key] = dict[current_value]
           else:
               continue
    else:
        if current_value.isdigit():
            dict[current_key] = int(current_value)
        else:
            if current_value in dict:
                dict[current_key] = dict[current_value]
            else:
                continue

for key in dict:
    print(f"{key} === {dict[key]}")