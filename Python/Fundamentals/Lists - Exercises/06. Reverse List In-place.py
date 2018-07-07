list = list(map(int,input().split()))
for i in range(0,int(len(list)/2)):
    temp = list[i-1-2*i]
    list[i-1-2*i] = list[i]
    list[i] = temp

print(*list,sep=" ")