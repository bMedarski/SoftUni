programmers = []
first_add = input()
first_add_args = first_add.split()
programmers.append(first_add_args[1])

while True:
    if len(programmers)==0:
        break

    data = input()
    data_args = data.split()
    command = data_args[0]

    if command == "ADD":
        programmer = data_args[1]
        programmers.append(programmer)
    elif command == "NEXT":
        programmer = programmers.pop(0)
        print(programmer)
    elif command == "SKIP":
        programmer = programmers.pop(0)
    elif command == "REM":
        programmer = data_args[1]
        for p in programmers:
            if p == programmer:
                programmers.remove(p)
    elif command == "CLEANUP":
        is_not_over = True
        while is_not_over:
            try:
                for i in range(len(programmers)):
                    if len(programmers[i])%2 ==0:
                        print(programmers[i])
                        del programmers[i]
                        break
                    if i == len(programmers)-1:
                        is_not_over = False
                        break
            except:
                break
    elif command == "CLEANDOWN":
        programmers = [programmers[i] for i in range(0,len(programmers)) if not(i%2!=0 and len(programmers[i])%2==0)]

    elif command == "LIST":
        print(programmers)
