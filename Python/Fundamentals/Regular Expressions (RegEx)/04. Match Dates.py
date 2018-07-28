import re

dates = input()

regex = r"\b(?P<day>\d{2})(?P<separator>[/\-\.]{1})(?P<month>[A-Z][a-z]{2})(?P=separator)(?P<year>\d{4})"

matches = re.finditer(regex,dates)

for match in matches:
    day = match.group("day")
    month = match.group("month")
    year = match.group("year")
    print(f"Day: {day}, Month: {month}, Year: {year}")