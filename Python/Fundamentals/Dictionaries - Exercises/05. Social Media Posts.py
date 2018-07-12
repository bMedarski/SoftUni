posts = {}

while True:
    user_input = input()
    if user_input =="drop the media":
        break

    user_input_args = user_input.split()

    action = user_input_args[0]

    if action == "post":
        if user_input_args[1] not in posts:
            posts[user_input_args[1]] = {
                "like":0,
                "dislike":0,
                "comment":{}
            }
    elif action == "like":
        post = user_input_args[1]
        posts[post]["like"] += 1
    elif action == "dislike":
        post = user_input_args[1]
        posts[post]["dislike"] += 1
    else:
        user_input_args.pop(0)
        post = user_input_args.pop(0)
        commenter = user_input_args.pop(0)
        comment = user_input_args.pop(0)

        if commenter not in posts[post]["comment"]:
            posts[post]["comment"][commenter] = []

        posts[post]["comment"][commenter].append(comment)

for p in posts:
    print(f"Post: {p} | Likes: {posts[p]['like']} | Dislikes: {posts[p]['dislike']}")
    print("Comments:")
    if len(posts[p]["comment"])>0:
        for c in posts[p]["comment"]:
            comments = ", ".join(posts[p]['comment'][c])
            print(f"*  {c}: {comments}")
    else:
        print("None")