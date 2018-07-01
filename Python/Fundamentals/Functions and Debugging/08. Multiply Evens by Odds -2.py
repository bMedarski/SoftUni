def sum_even(a):
    rez = 0
    for j in a:
        if int(j) & 1 == 0:
            rez += int(j)
    return (rez)


def sum_odd(a):
    rez = 0
    for j in a:
        if int(j) & 1 == 1:
            rez += int(j)
    return (rez)


n = input()
if n[0] == "-":
    line = n[1:]
else:
    line = n

result = sum_odd(line) * sum_even(line)
print(result)