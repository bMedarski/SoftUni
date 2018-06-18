firstType = input()
firstCount = int(input())
secondType = input()
secondCount = int(input())
thirdType = input()
thirdCount = int(input())

onsiteCount = 0
onlineCount = 0




if firstType == "onsite":
    onsiteCount += firstCount
else:
    onlineCount += firstCount

if secondType == "onsite":
    onsiteCount += secondCount
else:
    onlineCount += secondCount

if thirdType == "onsite":
    onsiteCount += thirdCount
else:
    onlineCount += thirdCount

if onsiteCount>600:
    onlineCount += onsiteCount - 600
    onsiteCount = 600



print("Online students: {0}".format(onlineCount))
print("Onsite students: {0}".format(onsiteCount))
print("Total students: {0}".format(onlineCount+onsiteCount))