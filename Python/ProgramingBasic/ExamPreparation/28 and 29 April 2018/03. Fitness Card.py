
mans = {
    "Gym":42,
    "Boxing":41,
    "Yoga":45,
    "Zumba":34,
    "Dances":51,
    "Pilates":39,
}

womans = {
    "Gym":35,
    "Boxing":37,
    "Yoga":42,
    "Zumba":31,
    "Dances":53,
    "Pilates":37,
}

availableMoney = float(input())
gender = input()
age = int(input())
sport = input()

if gender is "m":
    if age<20:
        if availableMoney >= mans[sport]*0.8:
            print("You purchased a 1 month pass for {0}.".format(sport))
        else:
            print("You don't have enough money! You need ${0:.2f} more.".format(mans[sport]*0.8-availableMoney))
    else:
        if availableMoney >= mans[sport]:
            print("You purchased a 1 month pass for {0}.".format(sport))
        else:
            print("You don't have enough money! You need ${0:.2f} more.".format(mans[sport]-availableMoney))
else:
    if age<20:
        if availableMoney >= womans[sport]*0.8:
            print("You purchased a 1 month pass for {0}.".format(sport))
        else:
            print("You don't have enough money! You need ${0:.2f} more.".format(womans[sport]*0.8-availableMoney))
    else:
        if availableMoney >= womans[sport]:
            print("You purchased a 1 month pass for {0}.".format(sport))
        else:
            print("You don't have enough money! You need ${0:.2f} more.".format(womans[sport]-availableMoney))