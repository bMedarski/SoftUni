list = list(map(float,input().split()))

found = True

while found:
    index = -1
    found = False
    for n in range(0,len(list)-1):
        if list[n] == list[n+1]:
            list[n+1] = list[n] + list[n+1]
            list.pop(n)
            found = True
            break


for i in list:
    print(f"{i:.2g}", end=' ')