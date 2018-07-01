text = input()

text = text.replace(","," ")
text = text.replace("["," ")
text = text.replace("]"," ")
text = text.replace("."," ")
text = text.replace(")"," ")
text = text.replace("("," ")
text = text.replace("!"," ")
text = text.replace("'"," ")
text = text.replace("\\"," ")
text = text.replace("/"," ")
text = text.replace("\""," ")
text = text.replace(":"," ")
text = text.replace(";"," ")
list = list(filter(None,text.split(" ")))

lower_case = []
middle_case = []
upper_case = []

for word in list:
    if word[0].isupper() or word[0].isdigit():
        if word[0].isdigit()or not word[1].isupper():
            middle_case.append(word)
        else:
            upper_case.append(word)
    else:
        lower_case.append(word)

lower  = ", ".join(lower_case)
middle  = ", ".join(middle_case)
upper  = ", ".join(upper_case)

print(f"Lower-case: {lower}")
print(f"Mixed-case: {middle}")
print(f"Upper-case: {upper}")