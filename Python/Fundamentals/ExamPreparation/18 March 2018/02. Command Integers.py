import math

stateListInput = input()
commandListInput = input()

stateList = stateListInput.split(" ")
commandList = commandListInput.split(" ")

stateListLenght = len(stateList)


for i in range(0,stateListLenght):
    stateList[i] = int(stateList[i])

for i in range(0,len(commandList)):
    commandList[i] = int(commandList[i])

for c in commandList:
    if c%2 == 0:
        for s in range(0,stateListLenght):
            if stateList[s]%2 == 0:
                stateList[s]= stateList[s]*abs(c)
    else:
        for s in range(0, stateListLenght):
            if stateList[s]%2 != 0:
                stateList[s]= int(stateList[s]//abs(c))

    if c > 0 :
        for s in range(0, stateListLenght):
            if stateList[s] > 0:
                stateList[s] += c
    else:
        for s in range(0, stateListLenght):
            if stateList[s] < 0:
                stateList[s] += c

print(stateList)