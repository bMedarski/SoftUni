list = list(map(int,input().split()))

smallest = list[0]
for i in list:
    if i<smallest:
        smallest = i

print(smallest)