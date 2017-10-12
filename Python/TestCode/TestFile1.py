import math
sheets_square_input = input()
height_input = input()
width_input = input()
length_input = input()


try:
    sheets_square, height, width, length = float(sheets_square_input), float(height_input), float(width_input), float(
        length_input)

    box_area = 2*(width*length+width*height+length*height)
    sheets_needed = sheets_square
    print(math.ceil((box_area/sheets_needed)/0.98))
except ValueError:
    print("INVALID INPUT")
