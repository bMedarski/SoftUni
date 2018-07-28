import re

regex = r"[^\&|\?]+"



while True:
    data = input()
    if data == "END":
        break

    data_args = re.findall(regex,data)

    for i in data_args:
        print(i)