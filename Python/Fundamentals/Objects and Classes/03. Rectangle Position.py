class Rectangle:
    def __init__(self,left,top,width,height):
        self.left = left
        self.top = top
        self.width = width
        self.height = height
        self.right = self.left + self.width
        self.bottom = self.top + self.height

    def is_inside(self,r2):
        if self.left >= r2.left and self.right <= r2.right and self.top <= r2.top and self.bottom <= r2.bottom:
            return True
        else:
            return False

r1 = list(map(int,input().split()))
r2 = list(map(int,input().split()))

rectangle1 = Rectangle(r1[0],r1[1],r1[2],r1[3])
rectangle2 = Rectangle(r2[0],r2[1],r2[2],r2[3])


if rectangle1.is_inside(rectangle2):
    print("Inside")
else:
    print("Not inside")