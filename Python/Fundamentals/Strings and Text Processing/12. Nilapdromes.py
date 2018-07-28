import re

regex = r"^(.+)(.+)(\1)$"

while True:
    data = input()
    if data=="end":
        break

    if re.match(regex,data):
        groups = re.match(regex,data).groups(1)
        print(groups[1]+groups[0]+groups[1])
