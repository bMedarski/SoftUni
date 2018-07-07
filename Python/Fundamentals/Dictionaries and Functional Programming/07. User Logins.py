password_storage= {}

while True:
    user_input = input()

    if user_input == "login":
        break

    user_input_args = user_input.split(" -> ")

    password_storage[user_input_args[0]]=user_input_args[1]

count = 0

while True:
    user_input = input()

    if user_input == "end":
        break
    user_input_args = user_input.split(" -> ")

    username = user_input_args[0]
    password = user_input_args[1]

    if username not in password_storage:
        print(f"{username}: login failed")
        count+=1
    elif password_storage[username] != password:
        print(f"{username}: login failed")
        count+=1
    else:
        print(f"{username}: logged in successfully")

print(f"unsuccessful login attempts: {count}")