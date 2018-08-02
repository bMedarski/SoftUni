import re

data = input()

pattern = r"(?P<tail>>*)<(?P<body>\(+)(?P<status>['x-])>"
match = re.finditer(pattern, data)

if not re.search(pattern, data):
    print("No fish found.")

tail_type = None
body_type = 0
status = None

count = 1
for x in match:
    tail_len = len(x.groupdict()['tail'])
    body_len = len(x.groupdict()['body'])
    fish_eye = x.group('status')

    if tail_len > 5:
        tail_type = 'Long'
    elif tail_len > 1:
        tail_type = 'Medium'
    elif tail_len == 1:
        tail_type = 'Short'
    else:
        tail_type = None

    tail_cm = 2 * tail_len
    body_cm = 2 * body_len

    if body_len > 10:
        body_type = 'Long'
    elif body_len > 5:
        body_type = 'Medium'
    else:
        body_type = 'Short'

    if fish_eye == "'":
        status = 'Awake'
    elif fish_eye == "-":
        status = 'Asleep'
    elif fish_eye == "x":
        status = 'Dead'

    print(f"Fish {count}: {x.group()}")
    if tail_type is None:
        print(f"  Tail type: None")
    else:
        print(f"  Tail type: {tail_type} ({tail_cm} cm)")
    print(f"  Body type: {body_type} ({body_cm} cm)")
    print(f"  Status: {status}")

    count += 1