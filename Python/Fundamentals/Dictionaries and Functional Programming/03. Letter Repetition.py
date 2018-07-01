user_input = input()

word_count = {}


for w in user_input:
    if w in word_count:
        word_count[w] += 1
    else:
        word_count[w] = 1

for key in word_count:
    print(f"{key} -> {word_count[key]}")

