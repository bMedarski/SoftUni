import re

names = input()
regex = r"\b[A-Z][a-z]+ [A-Z][a-z]+\b"

matches = re.findall(regex,names)

for match in matches:
    print(match, end=" ")