pages = 899
covers = 2

pricePerPage = float(input())
pricePerCover = float(input())
discount = int(input())
designerFee = float(input())
percentPaidByTheTeam = float(input())


money = pricePerCover*covers + pricePerPage * pages
money = money - (money*discount)/100
money += designerFee

money = money - (money*percentPaidByTheTeam)/100

print("Avtonom should pay {0:.2f} BGN.".format(money))
