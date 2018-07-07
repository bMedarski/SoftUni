list = list(map(int,input().split()))
isSorted = True
sortedStart =0
end = len(list)-1
while isSorted:

    isSorted = False
    for i in range(0,end):
        first = list[i]
        second = list[i+1]

        if first>list[i+1]:
            temp = list[i]
            list[i] = list[i+1]
            list[i + 1] = temp
            isSorted = True

print(" ".join(map(str,list)))