import re

data = input()

# happy1 = r"[^D\[\]c\{\}:;\(\)][:;][\}\)\]D\*][^D\[\]c\{\}:;\(\)]"
# happy2 = r"[^D\[\]c\{\}:;\(\)][\(\[\{\*c][:;][^D\[\]c\{\}:;\(\)]"
# sad1 = r"[^D\[\]c\{\}:;\(\)][:;][\{\(\[D\*c][^D\[\]c\{\}:;\(\)]"
# sad2 = r"[^D\[\]c\{\}:;\(\)][\)\]\}\*D][:;][^D\[\]c\{\}:;\(\)]"

happy = r"(:\)|:D|;\)|:\*|:]|;]|:}|;}|\(:|\*:|c:|\[:|\[;)"
sad = r"(:\(|D:|;\(|:\[|;\[|:{|;{|\):|:c|\]:|\];)"



# matches1 = re.findall(happy1,data)
# matches2 = re.findall(happy2,data)
# matches3 = re.findall(sad1,data)
# matches4 = re.findall(sad2,data)

# total_emo = len(matches1)+len(matches2)+len(matches3)+len(matches4)
# happy_emo = len(matches1) + len(matches2)
# sad_emo = len(matches3) + len(matches4)

happy_matches = re.findall(happy,data)
sad_matches = re.findall(sad,data)
happy_emo = len(happy_matches)
sad_emo = len(sad_matches)
total_emo = happy_emo+sad_emo

index = happy_emo / sad_emo

if index>=2:
    status = ":D"
elif index>1:
    status = ":)"
elif index == 1:
    status = ":|"
else:
    status = ":("

print(f"Happiness index: {index:.2f} {status}")
print(f"[Happy count: {happy_emo}, Sad count: {sad_emo}]")
