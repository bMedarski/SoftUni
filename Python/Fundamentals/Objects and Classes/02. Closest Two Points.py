import math

list_of_points = []

class Point:
    def __init__(self,x,y):
        self.x = x
        self.y = y

    def distance_between_points(self,p2):
        delta_x = p2.x - self.x
        delta_y = p2.y - self.y
        return math.sqrt(delta_x ** 2 + delta_y ** 2)

count = int(input())

for p in range(count):
    point1_args = list(map(int, input().split()))
    point1 = Point(point1_args[0], point1_args[1])
    list_of_points.append(point1)

min_distance = list_of_points[0].distance_between_points(list_of_points[1])
first_point = list_of_points[0]
second_point = list_of_points[1]

for p1 in list_of_points:
    for p2 in list_of_points:
        current_distance = p1.distance_between_points(p2)
        if list_of_points.index(p1) != list_of_points.index(p2) and current_distance < min_distance:
            min_distance = current_distance
            first_point = p1
            second_point = p2

print(f"{min_distance:.3f}")
print(f"({first_point.x}, {first_point.y})")
print(f"({second_point.x}, {second_point.y})")
