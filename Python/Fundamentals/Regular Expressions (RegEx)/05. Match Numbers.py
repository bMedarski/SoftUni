import re

nums = input()

regex = r"(^|(?<=\s))-?\d+(\.\w+)?($|(?=\s))"

matches = re.finditer(regex,nums)

for match in matches:
    print(match.group(), end=" ")