forum = {}

while True:
    user_input = input()
    if user_input == "filter":
        break

    user_input_args = user_input.split(" -> ")

    topic = user_input_args[0]

    if topic not in forum:
        forum[topic] = []

    tags = user_input_args[1].split(", ")

    for t in tags:
        if t in forum[topic]:
            continue
        else:
            forum[topic].append(t)

user_tags = input().split(", ")

def if_any(topic,tags):
    for tag in tags:
        if tag not in forum[topic]:
            return False
        else:
            continue
    return True


for topic in forum:
    if if_any(topic,user_tags):
        print(f"{topic} | #"+", #".join(forum[topic]))