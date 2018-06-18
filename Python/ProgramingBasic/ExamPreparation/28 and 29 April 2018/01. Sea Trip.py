priceForLitre = 1.85
kilometers = 210*2
litersPer100Km = 7

priceForFuel = (litersPer100Km/100*kilometers)*priceForLitre

foodMoney = float(input())
suvenirsMoney = float(input())
hotelMoney = float(input())

foodMoney *= 3
suvenirsMoney *= 3

hotelMoneyFirstDay = hotelMoney - (hotelMoney*10)/100
hotelMoneySecondDay = hotelMoney - (hotelMoney*15)/100
hotelMoneyThirdDay = hotelMoney - (hotelMoney*20)/100

totalMoney = priceForFuel + foodMoney + suvenirsMoney + hotelMoneyFirstDay + hotelMoneySecondDay + hotelMoneyThirdDay

print("Money needed: {0:.2f}".format(totalMoney))