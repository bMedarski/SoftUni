fruits = ['banana','apple','kiwi','cherry','lemon','grapes']
vegetables = ['tomato','cucumber','pepper','carrot']

input = input()

if input in fruits:
    print('fruit')
elif input in vegetables:
    print('vegetable')
else:
    print('unknown')