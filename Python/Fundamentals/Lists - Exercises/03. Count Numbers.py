list = list(map(int,input().split()))

list.sort()
list.append(None)
count = 1
for i in range(len(list)-1):
    if list[i]==list[i+1]:
        count+=1
    else:
        print(f"{list[i]} -> {count}")
        count = 1

    #if i == len(list)-2 and list[i]!=list[i+1]:
        