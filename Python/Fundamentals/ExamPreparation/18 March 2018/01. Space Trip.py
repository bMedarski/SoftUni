starName = input()
distance = int(input())
budjet =int(input())            #Gm
fuelConsumption = float(input())    #litre per 100  Gm
fuelPrice = float(input())            #dolars for litre


litrePerGm = fuelConsumption/100
priceForGm = litrePerGm * fuelPrice
totalPrice = distance * priceForGm

diff = budjet - totalPrice

if diff>=0:
    print("Off to {0} with ${1:.2f} for snacks".format(starName,diff))
else:
    print("Maybe another time, need ${0:.2f} more".format(diff*-1))
