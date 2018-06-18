h = float(input())
w = float(input())

rows = h // 1.2
cols = (w - 1) // 0.7

placesCount = rows*cols - 3
print(f'{placesCount:.0f}')
