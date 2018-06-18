n = int(input())


for i in range(1,n+1):
    firstName = input()
    secondName = input()
    birthYear = int(input())

    firsNameFirstLetter = ord(firstName[0])
    secondNameFirstLetter = ord(secondName[0])

    uniqueNum = ""+str(birthYear)+str(firsNameFirstLetter)+str(secondNameFirstLetter) + str(i)
    print(uniqueNum)