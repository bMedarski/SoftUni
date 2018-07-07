list = list(map(int,input().split()))


list.sort()

list.reverse()
count_needed = int(input())
for i in range(0,count_needed):
    print(list[i],end=" ")


