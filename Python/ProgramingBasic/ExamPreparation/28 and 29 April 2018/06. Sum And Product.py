n = int(input())

def getMagicNum(n):
    for a in range(1,10):
        for b in range(9,a,-1):
            for c in range(0,10):
                for d in range(9,c-1,-1):

                    #print("" + "a="+str(a)+ " b="+ str(b) +" c="+ str(c)+" d=" + str(d))
                    mult = a*b*c*d
                    sum = a+b+c+d
                    if sum == 0:
                        print("-----" + "a=" + str(a) + " b=" + str(b) + " c=" + str(c) + " d=" + str(d))
                    if (sum == mult) and n%10==5:
                        #print(""+str(a)+str(b)+str(c)+str(d))
                        return ""+str(a)+str(b)+str(c)+str(d)
                    elif mult//sum==3 and n%3 ==0:
                        #print(""+str(d)+str(c)+str(b)+str(a))
                        return ""+str(d)+str(c)+str(b)+str(a)


num = getMagicNum(n)
if num == None:
    print("Nothing found")
else:
    print(num)