import re
text = input()

pattern = r"<.*?>"

matches = re.findall(pattern,text)


if len(matches) == 0:
    print("Better luck next time")
else:
    for m in matches:
        current_count = 0
        for c in m:
            if c.isdigit():
                current_count += int(c)

        print(f"Found {current_count} carat diamond")
