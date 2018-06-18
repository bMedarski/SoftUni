type = input()
cols = int(input())
rows = int(input())

totalSeats = cols*rows

if type == 'Premiere':
    print("{0:.2f} leva".format(totalSeats*12))
elif type == 'Normal':
    print("{0:.2f} leva".format(totalSeats * 7.5))
elif type == 'Discount':
    print("{0:.2f} leva".format(totalSeats * 5))