list = list(map(int,input().split()))


for i in range(1,len(list)):

    current = i
    while True:
        if current == 0:
            break
        if list[current] < list[current-1]:
            temp = list[current]
            list[current] = list[current-1]
            list[current-1] = temp
            current = current-1
        else:
            break

print(" ".join(map(str,list)))
