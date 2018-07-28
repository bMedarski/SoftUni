import re

word_list = []
params = input()
char = params[0]
count = int(params[1])

while True:
    data = input()
    if data == "end":
        break

    if not data[0].isupper():
        continue

    end = len(data)-1

    if not (data[end] == "." or data[end] == "?" or data[end] == "!"):
        continue

    regex = r"\w+"

    matches = re.findall(regex,data)

    for match in matches:
        if match.count(char)>=count:
            word_list.append(match)


print(", ".join(word_list))