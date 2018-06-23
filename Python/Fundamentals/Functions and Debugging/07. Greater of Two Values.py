param_type = input()
a = input()
b = input()

def compare_int(num1,num2):

    if int(num1) >= int(num2):
        return int(num1)
    else:
        return int(num2)

def compare_char(char1,char2):
    if ord(char1)>=ord(char2):
        return char1
    else:
        return char2

def compare_string(str1,str2):
    if str1>=str2:
        return str1
    else:
        return str2

def compare(paramType):
    if paramType=="int":
        print(compare_int(a,b))
    elif paramType=="char":
        print(compare_char(a,b))
    else:
        print(compare_string(a,b))

compare(param_type)