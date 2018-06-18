n = int(input())
min = int(input())
for i in range(0,n-1):
    current = int(input())
    if current < min:
        min = current

print(min)