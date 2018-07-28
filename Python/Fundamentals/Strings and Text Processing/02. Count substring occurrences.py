text = input()
pattern = input()
count = 0
index = 0
last_occur = 0
while True:

    occur = text.lower().find(pattern.lower(),last_occur)
    if occur >= 0:
        count+=1
    else:
        break

    last_occur = occur+1

print(count)

