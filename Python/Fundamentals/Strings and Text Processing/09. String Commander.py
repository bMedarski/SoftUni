text = input()

class String_Commander:
    def __init__(self,text):
        self.text = text

    def Left(self,counts):
        list_chars = list(self.text)
        for i in range(counts):
            temp = list_chars.pop(0)
            list_chars.append(temp)
        self.text = "".join(list_chars)

    def Right(self,counts):
        list_chars = list(self.text)
        for i in range(counts):
            temp = list_chars.pop(len(list_chars)-1)
            list_chars.insert(0,temp)
        self.text = "".join(list_chars)

    def Insert(self,index,string):
        self.text = self.text[:index] + string + self.text[index:]

    def Delete(self,start,end):
        self.text = self.text[:start] + self.text[end+1:]

commander = String_Commander(text)

while True:
    command = input()
    if command == "end":
        break

    command_args = command.split()

    if command_args[0] == "Left":
        step = int(command_args[1])
        commander.Left(step)
    elif command_args[0] == "Right":
        step = int(command_args[1])
        commander.Right(step)
    elif command_args[0] == "Delete":
        start = int(command_args[1])
        end = int(command_args[2])
        commander.Delete(start,end)
    elif command_args[0] == "Insert":
        index = int(command_args[1])
        char = command_args[2]
        commander.Insert(index,char)

print(commander.text)