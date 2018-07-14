import math
class Box:
    def __init__(self,upper_left,upper_right,bottom_left,bottom_right):
        self.upper_left = upper_left
        self.upper_right = upper_right
        self.bottom_left = bottom_left
        self.bottom_right = bottom_right
        self.width = int(self.upper_left.distance_between_points(self.upper_right))
        self.height = int(self.upper_left.distance_between_points(self.bottom_left))

    def calculate_perimeter(self):
        return int(2*self.width + 2*self.height)

    def calculate_area(self):
        return int(self.width*self.height)

class Point:
    def __init__(self,x,y):
        self.x = x
        self.y = y

    def distance_between_points(self,p2):
        delta_x = p2.x - self.x
        delta_y = p2.y - self.y
        return math.sqrt(delta_x ** 2 + delta_y ** 2)

boxes = []

while True:
    user_input = input()
    if user_input == "end":
        break

    boxes_args = user_input.split(" | ")
    points = []
    for b in boxes_args:
        p = b.split(":")
        point = Point(int(p[0]),int(p[1]))
        points.append(point)

    box = Box(points[0],points[1],points[2],points[3])
    boxes.append(box)

for b in boxes:
    print(f"Box: {b.width}, {b.height}")
    print(f"Perimeter: {b.calculate_perimeter()}")
    print(f"Area: {b.calculate_area()}")