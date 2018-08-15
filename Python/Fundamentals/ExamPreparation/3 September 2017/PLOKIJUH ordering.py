import math
list = {}
allowed_components = ["SAHRA","BINGIL","AMZGA"]
class Plok():
    def __init__(self,name,price=0.0):
        self.name = name
        self.price = price
        self.bozatronic = []

    def __str__(self):
        print(f"$$# PLOKIJUH: {self.name}")
        print(f"$#$ Price: {self.price:.1f}")
        print(f"#$$ Components: ",end="")
        print(", ".join(self.bozatronic))

while True:
    data = input()
    if data == "STOPAAJUHIT!":
        break

    data_args = data.split()
    command = data_args[0]

    if command == "NEW":
        name = data_args[1]
        if name not in list:
            list[name] = Plok(name)
        else:
            print("STUPIDO!!1")
    elif command == "GEPRISEN":
        plok_name = data_args[1]
        plok_price = float(data_args[2])
        list[plok_name].price = plok_price
    elif command == "KOMPONENTUNG":
        plok_name = data_args[1]
        plok_component = data_args[2]
        if plok_component not in allowed_components:
            print("BLAH!")
        else:
            list[plok_name].bozatronic.append(plok_component)
    elif command == "DECOMPING":
        plok_name = data_args[1]
        plok_component = data_args[2]
        if plok_component in allowed_components:
            if plok_component in list[plok_name].bozatronic:
                list[plok_name].bozatronic.remove(plok_component)
            else:
                print("YACK!")
        else:
            print("YACK!")
    elif command == "BLUSS":
        name1 = data_args[1]
        name2 = data_args[2]
        new_name = name1[:len(name1)//2] + name2[len(name2)//2:]
        new_price = (list[name1].price + list[name2].price)/2
        list[new_name] = Plok(new_name,new_price)

        for p in list[name1].bozatronic:
            list[new_name].bozatronic.append(p)

        for p in list[name2].bozatronic:
            list[new_name].bozatronic.append(p)
    elif command == "TULOSTASE":
        if not list:
            print("INTEPLOKIJUHAR:(")
        else:
            list = sorted(list.items(), key=lambda ploka: (ploka[1].price,len(ploka[1].bozatronic)))
            # list = sorted(list.items(), key=lambda kv: len(kv[1].bozatronic))


for r in list.keys():
    list[r].__str__()



# TULOSTASE
# NEW nqikoisi
# GEPRISEN nqikoisi 3.14
# KOMPONENTUNG nqikoisi AMZGA
# KOMPONENTUNG nqikoisi AMZGA
# KOMPONENTUNG nqikoisi BINGIL
# DECOMPING nqikoisi AMZGA
# NEW nqikoisi
# KOMPONENTUNG nqikoisi NQMAME
# DECOMPING nqikoisi SAHRA
# NEW nqkoqsi
# KOMPONENTUNG nqkoqsi AMZGA
# KOMPONENTUNG nqkoqsi SAHRA
# TULOSTASE
# BLUSS nqikoisi nqkoqsi
# TULOSTASE
# STOPAAJUHIT!
