with open("Input.txt","r") as f:
    lines = f.readlines()

with open("Result","a") as a:
    for i in range(len(lines)):
            a.writelines(str(i+1)+"."+lines[i])