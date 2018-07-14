class User:
    def __init__(self,username):
        self.username = username
        self.received_msg = []

class Message:
    def __init__(self,content,user):
        self.content = content
        self.user = user

users = []

while True:
    #Read input
    user_input = input()

    #Check if exit
    if user_input == "exit":
        break

    #Split input by space
    user_input_args = user_input.split(" ")

    #if input is for registering
    if user_input_args[0]=="register":
        #make new User with username
        user = User(user_input_args[1])
        #Add username to users list
        users.append(user)
    else:

        sender = user_input_args[0]
        receiver = user_input_args[2]

        #If does not have registration for receiver or sender
        receiver_exist = False
        sender_exist = False


        for u in users:
            #Check if sender exists
            if u.username == sender:
                sender_exist = True
            #Check if receiver exists
            if u.username == receiver:
                receiver_exist = True

        #Skip if someone not exists
        if not receiver_exist or not sender_exist:
            continue

        #Create new message
        content = user_input_args[3]
        message = Message(content,sender)

        #Find the user who received message and add to his list of messages
        user_receiver = list(filter(lambda u : u.username == sender,users))[0]
        user_receiver.received_msg.append(message)

#Read users for report
users_input = input().split()
first = users_input[0]
second = users_input[1]

#Find users from the list of users
first_user = list(filter(lambda u : u.username == first,users))[0]
second_user = list(filter(lambda u : u.username == second,users))[0]

#Get users messages lists
first_user_messages = first_user.received_msg
second_user_messages = second_user.received_msg

#Get biggest list count
steps = max(len(first_user.received_msg),len(second_user.received_msg))

#If no messages - print
if steps == 0:
    print("No messages")


for i in range(steps):
    #If more messages print first
    if len(first_user_messages) > 0:
        msg = first_user_messages.pop(0)
        print(f"{first_user.username}: {msg.content}")
    # If more messages print first
    if len(second_user_messages) > 0:
        msg = second_user_messages.pop(0)
        print(f"{msg.content} :{second_user.username}")

