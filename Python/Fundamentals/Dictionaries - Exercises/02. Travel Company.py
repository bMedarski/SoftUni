cities = {}

while True:
    user_input = input()
    if user_input == "ready":
        break

    #sptit between city and different transports
    user_input_args = user_input.split(":")
    #current city
    city = user_input_args[0]

    #add missing cities
    if city not in cities:
        cities[city] = {}

    # split different transports
    transports = user_input_args[1].split(",")


    for t in transports:
        #split current transport on type and people capacity
        t_args = t.split("-")

        #people capacity
        transport_capacity = int(t_args[1])
        #transport type
        transport_type = t_args[0]

        cities[city][transport_type] = transport_capacity

while True:
    user_input = input()
    if user_input == "travel time!":
        break

    user_input_args = user_input.split(" ")
    city = user_input_args[0]
    people_needed = int(user_input_args[1])

    capacity_needed = sum(cities[city].values() )
    if people_needed < capacity_needed:
        print(f"{city} -> all {people_needed} accommodated ")
    else:
        print(f"{city} -> all except {people_needed - capacity_needed} accommodated")
