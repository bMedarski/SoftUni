n = int(input())

text = []                                                           # list of the lines of text
alphas = []                                                         # list of the letters in class format
class Alpha():
    def __init__(self,letter,letter_count,line):
        self.letter = letter                                        # current letter
        self.letter_count = letter_count                            # count of letters on current line
        self.line = line                                            #last line of appearance
        self.size = 1                                               #count of lines
        self.best_size = 1                                          #best size recordet

    def __str__(self):
        return f"Letter: {self.letter}, size {self.best_size}, at count {self.letter_count}, starts at line {self.line}"


for i in range(n):
    data = input()
    text.append(data)

for l in range(len(text)):                                          # go through lines of text
    for a in text[l]:                                               # go through letters of line
        is_exist = False                                            # assume not such a letter yet
        count = text[l].count(a)                                    # count same letters on the line
        for c in alphas:                                            # go through list of letters
            if c.letter == a:                                       # is exists

                is_exist = True
                if c.line == l:                                     # if the line is the same continue
                    continue

                if count >= c.letter_count + 2:                     #if count of the letter is 2 or more then currently marked
                    c.letter_count += 2                             #add 2 more to the count
                    c.size += 1                                     #               add +1 to size


                    if c.size > c.best_size:                        #if new size is bigger then best, change new best
                        c.best_size = c.size

                c.line = l                                          # add next line


        if not is_exist:                                            #if letter not exist - create it and add it to the list
            letter = Alpha(a,1,l)
            alphas.append(letter)



best_size = 1                                                       #current best size
letter = ""                                                         #current letter

for i in alphas:                                                    #go through letters
    if i.best_size>best_size:                                       #find best size and letter
        best_size = i.best_size
        letter = i.letter


for i in range(1,best_size+1):                                          #print it
    print(letter*(i*2-1))


