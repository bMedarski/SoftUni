import math

list_input = list(map(int, input().split(" ")))
sqr_nums = []


for num in list_input:
    if num > 0:
        sqr_num = math.sqrt(num)
        if sqr_num == int(sqr_num):
            sqr_nums.append(num)

sqr_nums.sort(reverse=True)
sqr_nums = list(map(str,sqr_nums))
print(" ".join(sqr_nums))