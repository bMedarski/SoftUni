word = input()
sum = 0
for i in range(0,len(word)):

    if word[i]=='a':
        sum+=1

    if word[i]=='e':
        sum+=2

    if word[i]=='i':
        sum+=3

    if word[i]=='o':
        sum+=4

    if word[i]=='u':
        sum+=5

print(sum)