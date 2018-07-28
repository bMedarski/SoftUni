with open("FileOne.txt","r") as f:
    linesOne = f.read().split("\n")
with open("FileTwo.txt","r") as f:
    linesTwo = f.read().split("\n")



with open("Result","a") as a:
    for i in range(len(linesOne)):
        a.writelines(linesOne[i]+"\n")
        a.writelines(linesTwo[i]+"\n")