num = int(input())

string_list = [input() for i in range(num)]

char_list = set(char for sublist in string_list for char in sublist)

char_pyramid, char_len = '', 0

for char in char_list:
    len_pyramid = 0
    for i in range(0, num):
        if char in string_list[i] and len_pyramid == 0:
            len_pyramid = 1
        if string_list[i].count(char) >= 2 + len_pyramid:
            len_pyramid += 2
        else:
            pass
    if len_pyramid > char_len:
        char_len = len_pyramid
        char_pyramid = char

for i in range(1, char_len + 1, 2):
    print(char_pyramid * i)