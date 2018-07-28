import re

hex = input()
regex = r"\b(?:0x)?[0-9A-F]+\b"

matches = re.findall(regex,hex)

for match in matches:
    print(match, end=" ")