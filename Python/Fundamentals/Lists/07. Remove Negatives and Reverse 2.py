#print(" ".join(map(str,list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1])))))




#print(" ".join(map(str,list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1]))))) if len(list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1])))>0 else print("empty")

#print(" ".join(map(str,list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1])))) if len(list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1])))>0 else "empty")


#print((" ".join(map(str,list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1])))), 'empty')[len(list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1])))>0])

print(len(list(filter(lambda x: x>0 ,list(map(int,input().split()))[::-1])))>0)