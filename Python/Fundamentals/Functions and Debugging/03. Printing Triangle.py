n = int(input())


def print_number_line(n):
    for i in range(1,n+1):
        print(i,end=" ")

for i in range(1,n+1):
    print_number_line(i)
    print()

for i in range(n-1,0,-1):
    print_number_line(i)
    print()