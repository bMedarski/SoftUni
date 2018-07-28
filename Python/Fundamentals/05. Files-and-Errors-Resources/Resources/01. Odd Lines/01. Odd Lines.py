with open("Input.txt","r") as f:
    lines = f.readlines()

with open("Result","a") as a:
    for i in range(len(lines)):
        if i%2!=0:
            a.writelines(lines[i])