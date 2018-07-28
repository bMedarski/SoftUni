import os

extension = input()

for root, dirs, files in os.walk('../.'):
    print(root)
    print(dirs)
    print(files)
    for file in files:
        split = file.split(".")
        if split[-1]==extension:
            print(file)
