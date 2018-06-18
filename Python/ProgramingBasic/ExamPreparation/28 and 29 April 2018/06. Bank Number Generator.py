first = int(input())
second = input()
third = input()
forth = input()
fifth = int(input())
n = int(input())

def getCode(n):
    for a in range(first,100):
        for b in range(ord(second),ord('Z')+1):
            for c in range(ord(third),ord('z')+1):
                for d in range(ord(forth),ord('Z')+1):
                    for e in range(fifth,10,-1):
                        if (a%10==2) and (e%10==5):
                            if n>1:
                                n-=1
                            elif n ==1:
                                return  str(a)+chr(b)+chr(c)+chr(d)+str(e)

print(getCode(n))
