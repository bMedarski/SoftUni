inventory = input().split()

while True:
    data = input()
    if data == "Fight!":
        break

    data_args = data.split()
    command = data_args[0]

    if command == "Buy":
        item = data_args[1]

        if item in inventory:
            continue
        else:
            inventory.append(item)
    elif command == "Trash":
        item = data_args[1]

        if item not in inventory:
            continue
        else:
            inventory.remove(item)
    elif command == "Repair":
        item = data_args[1]

        if item not in inventory:
            continue
        else:
            index = inventory.index(item)
            repaired_item = inventory.pop(index)
            inventory.append(repaired_item)
    elif command == "Upgrade":
        args = data_args[1].split("-")
        item = args[0]
        if len(args)==1:
            if item in inventory:
                position_item = inventory.index(item)
                position_upgrade = position_item + 1
                upgraded_item = item + ":"
                inventory.insert(position_upgrade, upgraded_item)
        else:
            upgrade = args[1]
            if item in inventory:
                position_item = inventory.index(item)
                position_upgrade = position_item+1
                upgraded_item = item +":" + upgrade
                inventory.insert(position_upgrade,upgraded_item)

print(" ".join(inventory))