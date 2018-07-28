import re
regex = r"([2-9][SHDC])|(10[SHDC])|([AQKJ][SHDC])"
cards = input()
matches = re.finditer(regex,cards)

for match in matches:
   print(match.group(0),end=" ")
