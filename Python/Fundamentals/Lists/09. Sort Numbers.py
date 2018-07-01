list_input = list(map(int, input().split(" ")))

list_input.sort()
list_input = list(map(str,list_input))

print(" <= ".join(list_input))