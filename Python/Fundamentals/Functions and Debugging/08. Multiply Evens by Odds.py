num = input()

num = str(abs(int(num)))

def get_sum_of_even_numbers(num):
    sum = 0

    for i in range(0,len(num)):
        current_num = int(num[i])
        if current_num%2 == 0:
            sum+=current_num
    return sum

def get_sum_of_odd_numbers(num):
    sum = 0
    for i in range(0,len(num)):
        current_num = int(num[i])
        if current_num % 2 != 0:
            sum += current_num
    return sum

def get_multiplication(odd,even):
    print(odd*even)

get_multiplication(get_sum_of_even_numbers(num),get_sum_of_odd_numbers(num))
