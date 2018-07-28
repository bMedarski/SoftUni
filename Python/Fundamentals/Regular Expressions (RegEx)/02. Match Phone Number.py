import re

pattern = r'\+359([ -])2\1\d{3}\1\d{4}\b'
text = input()

matches = re.finditer(pattern, text)
phones = [match.group() for match in matches]

print(*phones, sep=' ')
