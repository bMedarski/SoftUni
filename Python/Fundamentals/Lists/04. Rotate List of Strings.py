list = input().split(" ")

last = list[-1]
list.pop(-1)
list.insert(0,last)

print(" ".join(list))