#AX=Rock     1
#BY=Paper    2
#CZ=Scissors 3
score = 0
with open("input.txt") as file:
    for line in file:
        opponent, you = line.split(" ")
        score += ord(you.strip()) - 87
        if( ord(opponent.strip()) == ord(you.strip()) - 23 ):
            score += 3
            continue #niet nodig, maar beter resource tense wise, scheelt weer een rekensommetje
        diff = ord(opponent.strip())-(ord(you.strip()) - 23)
        if(  diff == -1 or diff == 2 ):
            score += 6

print(score)