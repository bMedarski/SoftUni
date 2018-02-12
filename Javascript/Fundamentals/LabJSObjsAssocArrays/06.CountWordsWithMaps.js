function Solve(input){
    const regex = /[\W]+/g;
    for (let i = 0; i < input.length; i++) {
        let words = new Map();
        let wordsArgs = input[i].toLowerCase().split(regex).filter(w=>w!=="");

        for (let j = 0; j < wordsArgs.length; j++) {

            if (words.has(wordsArgs[j])) {
                //console.log(wordsArgs[j]);
                let value = words.get(wordsArgs[j]) + 1;
                //console.log(value);
                words.set(wordsArgs[j], value);
            } else {
                words.set(wordsArgs[j], 1);
            }
        }


        let allWords = Array.from(words.keys()).sort();
        allWords.forEach(w =>
            console.log(`'${w}' -> ${words.get(w)} times`));

    }
}

Solve(["Far too slow, you're far too slow."]);
Solve(['JS devs use Node.js for server-side JS. JS devs use JS. -- JS for devs --']);

//countWords(["Far too slow, you're far too slow."]);