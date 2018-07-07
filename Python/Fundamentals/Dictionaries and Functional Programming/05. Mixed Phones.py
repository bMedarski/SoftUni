phones = {}

while True:
    phone = input()

    if phone=="Over":
        break

    phone_args = phone.split(" : ")

    if phone_args[0].isdigit():
        phones[phone_args[1]] = phone_args[0]
    else:
        phones[phone_args[0]] = phone_args[1]

for phone in sorted(phones.keys()):
    print(f"{phone} -> {phones[phone]}")