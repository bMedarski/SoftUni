n = int(input())

def print_sigh(n):
    if n<0:
        print(f"The number {n} is negative.")
    elif n >0:
        print(f"The number {n} is positive.")
    else:
        print(f"The number {n} is zero.")

print_sigh(n)