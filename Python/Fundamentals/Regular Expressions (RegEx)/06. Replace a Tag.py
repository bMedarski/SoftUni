import re

data = input()
while data != 'end':
    pattern = r'<a ?href=(.*)>(.*)</a>'
    replace = r'[URL href=\1]\2[/URL]'
    data = re.sub(pattern, replace, data)
    print(data)

    data = input()