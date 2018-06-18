num = int(input())


def printFirstDigit(number):
    if number == 1:
        return 'one'
    elif number == 2:
        return 'two'
    elif number == 3:
        return 'three'
    elif number == 4:
        return 'four'
    elif number == 5:
        return 'five'
    elif number == 6:
        return 'six'
    elif number == 7:
        return 'seven'
    elif number == 8:
        return 'eight'
    elif number == 9:
        return 'nine'
    elif number == 10:
        return 'ten'
    elif number == 0:
        return ''

def printSecondDigit(number):
    if number == 1:
        return 'one'
    elif number == 2:
        return 'twenty'
    elif number == 3:
        return 'thirty'
    elif number == 4:
        return 'forty'
    elif number == 5:
        return 'fifty'
    elif number == 6:
        return 'sixty'
    elif number == 7:
        return 'seventy'
    elif number == 8:
        return 'eighty'
    elif number == 9:
        return 'ninety'
    elif number == 10:
        return 'one hundred'

if num < 0:
    print('invalid number')
elif num == 0:
    print('zero')
elif num<=10:
    print(printFirstDigit(num))
elif num<=100:
    if num ==11:
        print('eleven')
    elif num ==12:
        print('twelve')
    elif num ==13:
        print('thirteen')
    elif num ==14:
        print('fourteen')
    elif num ==15:
        print('fifteen')
    elif num ==16:
        print('sixteen')
    elif num ==17:
        print('seventeen')
    elif num ==18:
        print('eighteen')
    elif num ==19:
        print('nineteen')
    elif num == 100:
        print('one hundred')
    else:
        firstNum = num%10
        secondNum = num//10
        out = printSecondDigit(secondNum)
        if firstNum!=0:
            out += ' '
        out += printFirstDigit(firstNum)
        out.strip()
        print(out)
else:
    print('invalid number')
