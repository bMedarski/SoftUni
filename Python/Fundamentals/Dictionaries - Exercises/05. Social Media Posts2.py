data_input = input()
media_dict = {}
while not data_input == "drop the media":

    action = data_input.split()[0]
    name = data_input.split()[1]

    if action == "post":
        media_dict[name] = {"Likes": 0, "Dislikes": 0, "Comments": {}}
    elif action == 'like':
        media_dict[name]["Likes"] += 1
    elif action == "dislike":
        media_dict[name]["Dislikes"] += 1
    elif action == "comment":
        author = data_input.split(" ")[2]
        comment = data_input.split(" ")[3:]
        media_dict[name]["Comments"].update({author: comment})
    data_input = input()


for name, media_data in media_dict.items():
    print(f"Post: {name} ", end="")
    for key, value in media_data.items():
        if key == "Comments":
            print()
            print(f"Comments:")
            if value:
                for author, comment in value.items():
                    print(f"*  {author}: {' '.join(comment)}")
            else:
                print(f"None")

        else:
            print(f"| {key}: {value} ", end="")