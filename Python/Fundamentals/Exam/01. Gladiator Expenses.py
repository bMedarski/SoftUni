lost_fights_count = int(input())
helmet_price = float(input())
sword_price = float(input())
shield_price = float(input())
armor_price = float(input())
broken_shield_count = 0
total_price = 0
for i in range(1,lost_fights_count+1):

    is_sword_broken = False
    is_helmet_broken = False

    if i%2 == 0:
        total_price += helmet_price
        is_helmet_broken = True

    if i%3 ==0:
        total_price += sword_price
        is_sword_broken = True

    if is_helmet_broken and is_sword_broken:
        total_price += shield_price
        broken_shield_count += 1
        if broken_shield_count%2 ==0:
            total_price+= armor_price


print(f"Gladiator expenses: {total_price:.2f} aureus")

