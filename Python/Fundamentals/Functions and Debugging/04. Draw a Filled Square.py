n = int(input())

def print_square(n):
    print("-" * n * 2)
    for i in range(1,n-1):
        print("-", end='')
        print("\/"*(n-1),end='')
        print("-")
    print("-" * n * 2)

print_square(n)
