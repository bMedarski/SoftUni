import math

class Point:
    def __init__(self,x,y):
        self.x = x
        self.y = y

    def distance_between_points(self,p2):
        delta_x = p2.x - self.x
        delta_y = p2.y - self.y
        return math.sqrt(delta_x ** 2 + delta_y ** 2)

def distance_between_points(p1,p2):
    delta_x = p2.x - p1.x
    delta_y = p2.y - p1.y
    return math.sqrt(delta_x ** 2 + delta_y ** 2)



point1_args = list(map(int,input().split()))
point1 = Point(point1_args[0],point1_args[1])

point2_args = list(map(int,input().split()))
point2 = Point(point2_args[0],point2_args[1])

print(f"{point1.distance_between_points(point2):.3f}")

#print(f"{distance_between_points(point1,point2):.3f}")