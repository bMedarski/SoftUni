list = map(int,input().split(" "))

odd_count = 0

for item in list:
    if item%2!=0:
        odd_count+=1

print(odd_count)