startNum = int(input())
endNum = int(input()) + 1


for a in range(startNum,endNum):
    for b in range(startNum, endNum):
        for c in range(startNum, endNum):
            for d in range(startNum, endNum):
                if (a%2==0 and d%2!=0)or(a%2!=0 and d%2==0):
                    if a>d and (b+c)%2==0:
                        plate = ""+str(a)+str(b)+str(c)+str(d)
                        print(plate,end=' ')