n = int(input())
max = int(input())
for i in range(0,n-1):
    current = int(input())
    if current > max:
        max = current

print(max)