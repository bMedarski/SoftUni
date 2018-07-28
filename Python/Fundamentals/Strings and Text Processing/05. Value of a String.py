text = input()
param = input()


sum = 0

for c in text:
    if param == "LOWERCASE":
        if c.isalpha() and c.islower():
            sum += ord(c)
    else:
        if c.isalpha() and c.isupper():
            sum += ord(c)

print(f"The total sum is: {sum}")