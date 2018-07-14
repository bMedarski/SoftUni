animals = []

class Animal:
    def __init__(self,name,age):
        self.name = name
        self.age = age
        self.message = ""

    def __str__(self):
        return self.name + ", Age: " + str(self.age)

class Dog(Animal):
    def __init__(self, name, age, legs):
        super().__init__(name, age)
        self.legs = legs
        self.message = "I'm a Distinguishedog, and I will now produce a distinguished sound! Bau Bau."

    def __str__(self):
        return super().__str__() + ", Number Of Legs: " + str(self.legs)

class Cat(Animal):
    def __init__(self, name, age, iq):
        super().__init__(name, age)
        self.iq = iq
        self.message="I'm an Aristocat, and I will now produce an aristocratic sound! Myau Myau."
    def __str__(self):
        return super().__str__() + ", IQ: " + str(self.iq)

class Snake(Animal):
    def __init__(self, name, age, cruelty):
        super().__init__(name, age)
        self.cruelty = cruelty
        self.message = "I'm a Sophistisnake, and I will now produce a sophisticated sound! Honey, I'm home."
    def __str__(self):
        return super().__str__() + ", Cruelty: " + str(self.cruelty)


while True:
    user_input = input()
    if user_input == "I'm your Huckleberry":
        break

    animal_arg = user_input.split()

    type = animal_arg[0]

    if type == "Dog":
        name = animal_arg[1]
        age = int(animal_arg[2])
        param = int(animal_arg[3])
        dog = Dog(name, age, param)
        animals.append(dog)
    elif type == "Cat":
        name = animal_arg[1]
        age = int(animal_arg[2])
        param = int(animal_arg[3])
        cat = Cat(name, age, param)
        animals.append(cat)
    elif type == "Snake":
        name = animal_arg[1]
        age = int(animal_arg[2])
        param = int(animal_arg[3])
        snake = Snake(name, age, param)
        animals.append(snake)
    elif type=="talk":
        name = animal_arg[1]
        animal = list(filter(lambda a: a.name == name,animals))
        print(animal[0].message)



dogs = []
cats = []
snakes  = []

for a in animals:
    if a.__class__.__name__=="Dog":
        dogs.append(a)
    elif a.__class__.__name__=="Cat":
        cats.append(a)
    elif a.__class__.__name__=="Snake":
        snakes.append(a)


for dog in dogs:
    print(f"{dog.__class__.__name__}: {dog.__str__()}")

for cat in cats:
    print(f"{cat.__class__.__name__}: {cat.__str__()}")

for snake in snakes:
    print(f"{snake.__class__.__name__}: {snake.__str__()}")


# for a in animals:
#     print(f"{a.__class__.__name__}: {a.__str__()}")




