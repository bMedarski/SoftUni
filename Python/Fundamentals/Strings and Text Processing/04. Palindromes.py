list = input().split()
palindromes = []

for word in list:
    is_palindrome = True
    for c in range(len(word)//2):
        last = len(word)-1
        if word[c] != word[last-c]:
            is_palindrome = False
    if is_palindrome:
        if word not in palindromes:
            palindromes.append(word)

print(", ".join(sorted(palindromes, key=lambda word:word.lower())))

