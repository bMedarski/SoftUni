total_numbers = []
while True:
    line = input()
    if line == "DEBUG":
        break
    numbers = list(map(int,line.split()))
    total_numbers.extend(numbers)

for i in range(len(total_numbers)):
    if total_numbers[i] == 32656:
        if total_numbers[i+1]==19759 \
                and total_numbers[i+2]==32763 \
                and total_numbers[i+3] == 0 \
                and total_numbers[i+4]!=0 \
                and total_numbers[i+5]==0:
            letters = total_numbers[i+4]
            word = ""
            for y in range(letters):
                word+= chr(total_numbers[i+6+y])
            print(word)
    else:
        continue